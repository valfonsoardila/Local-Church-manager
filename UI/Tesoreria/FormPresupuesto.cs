using BLL;
using Cloud;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UI
{
    public partial class FormPresupuesto : Form
    {
        Validaciones validaciones;
        PresupuestoService presupuestoService;
        TabPage tabPage;
        Presupuesto presupuesto;
        List<Presupuesto> presupuestos;
        BudgetData budgetData;
        BudgetMaps budgetMaps;
        int id = 0;
        int sumPresupuestos = 0;
        string comite = "";
        bool detallo = false;
        bool encontrado = false;
        public FormPresupuesto()
        {
            presupuestoService = new PresupuestoService(ConfigConnection.ConnectionString);
            budgetData = new BudgetData();
            InitializeComponent();
            ConsultarPresupuesto();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string LecturaCifra(int totalDeIngresos)
        {
            // Convierte el total de ingresos a una cadena con separadores de miles
            string cifraFormateada = totalDeIngresos.ToString("N0");

            // Muestra la cifra formateada en el TextBox o donde desees
            string valorFormateado = $"${cifraFormateada}";
            return valorFormateado;
        }
        private async void ConsultarPresupuesto()
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                if (presupuestos.Count > 0)
                {
                    dataGridPresupuestos.DataSource = null;
                    dataGridPresupuestos.DataSource = presupuestos;
                }
                else
                {
                    dataGridPresupuestos.DataSource = null;
                    textTotal.Text = "0";
                }
            }
            catch(Exception ex)
            {
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.ConsultarTodos();
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    dataGridDetalle.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                    dataGridDetalle.DataSource = respuesta.Presupuestos;
                    Borrar.Visible = true;
                    textTotal.Text = presupuestoService.Totalizar().Cuenta.ToString();
                }
            }
        }

        private void FormPresupuesto_Load(object sender, EventArgs e)
        {
            if (tabPresupuestos.TabCount > 0)
            {
                tabPage = tabPresupuestos.TabPages["tabDetalle"];
                tabPresupuestos.TabPages.RemoveAt(2);
            }
        }
        private async void EliminarPresupuesto(int id)
        {
            try
            {
                //Elimina primero de firebase o la nube
                var db = FirebaseService.Database;
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(id.ToString());
                await docRef.DeleteAsync();
                string mensaje = presupuestoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
            }
            catch (Exception e)
            {
                string mensaje = presupuestoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
            }
        }
        private async void FiltrarPresupuestosPorComite(string comite){
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var presupuestosComite = presupuestos.Where(presupuesto => presupuesto.Comite == comite).ToList();
                dataGridPresupuestos.DataSource = presupuestosComite;
                Borrar.Visible = true;
            }
            catch (Exception ex)
            {
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.FiltrarEgresosPorComite(comite);
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    dataGridPresupuestos.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                    if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                    {
                        dataGridPresupuestos.DataSource = respuesta.Presupuestos;
                        Borrar.Visible = true;
                    }
                }
                else
                {
                    dataGridPresupuestos.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                }
            }
        }
        private void dataGridPresupuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPresupuestos.DataSource != null)
            {
                if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                    EliminarPresupuesto(id);
                    ConsultarPresupuesto();
                }
                else
                {
                    if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Detallar")
                    {
                        comite = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["Comite"].Value.ToString());
                        FiltrarPresupuestosPorComite(comite);
                        tabPresupuestos.TabPages.Add(tabPage);
                        tabPresupuestos.SelectedIndex = 2;
                        detallo = true;
                    }
                    else
                    {
                        if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Editar")
                        {
                            id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabPresupuestos.SelectedIndex = 1;
                            }
                        }
                    }
                }
            }
        }

        private void btnGestionarPresupuesto_Click(object sender, EventArgs e)
        {
            tabPresupuestos.SelectedIndex = 1;
        }
        private async void FiltroPorId(int id)
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestoQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestoQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var presupuestosFiltrados = presupuestos.Where(presupuesto => presupuesto.Id == id.ToString()).ToList();
                if (presupuestosFiltrados.Any())
                {
                    var presupuestoFiltrado = presupuestosFiltrados.First(); // Obtener el primer elemento de la lista
                    //encontrado = true;
                    comboInicioIntervalo.Text = presupuestoFiltrado.InicioIntervalo;
                    comboFinIntervalo.Text = presupuestoFiltrado.FinIntervalo;
                    comboComite.Text = presupuestoFiltrado.Comite;
                    textOfrendas.Text = presupuestoFiltrado.Ofrenda.ToString();
                    textActividades.Text = presupuestoFiltrado.Actividad.ToString();
                    textVotos.Text = presupuestoFiltrado.Voto.ToString();
                }
            }
            catch (Exception ex)
            {
                BusquedaPresupuestoRespuesta respuesta = new BusquedaPresupuestoRespuesta();
                respuesta = presupuestoService.BuscarPorIdentificacion(id);
                var registro = respuesta.Presupuesto;
                if (registro != null)
                {
                    encontrado = true;
                    var presupuestos = new List<Presupuesto> { registro };
                    comboInicioIntervalo.Text = presupuestos[0].InicioIntervalo;
                    comboFinIntervalo.Text = presupuestos[0].FinIntervalo;
                    comboComite.Text = presupuestos[0].Comite;
                    textOfrendas.Text = presupuestos[0].Ofrenda.ToString();
                    textActividades.Text = presupuestos[0].Actividad.ToString();
                    textVotos.Text = presupuestos[0].Voto.ToString();
                    textPresupuesto.Text = presupuestos[0].TotalPresupuesto.ToString();
                }
            }
        }
        static string FormatearFecha(string fechaOriginal)
        {
            string fechaFormateada = "";
            if (fechaOriginal.Contains(" p. m."))
            {
                fechaFormateada = fechaOriginal.Replace(" p. m.", "");
                fechaFormateada = fechaFormateada + " PM";
            }
            else
            {
                if (fechaOriginal.Contains(" a. m."))
                {
                    fechaFormateada = fechaOriginal.Replace(" a. m.", "");
                    fechaFormateada = fechaFormateada + " AM";
                }
                else
                {
                    fechaFormateada = fechaOriginal;
                }
            }
            return fechaFormateada;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimeFechaPresupuesto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboComite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void CalculoDeSaldo()
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                // Realizar la suma directamente en la consulta Firestore
                var snapshotPresupuesto = await presupuestosQuery.GetSnapshotAsync();
                sumPresupuestos = snapshotPresupuesto.Documents.Sum(doc => doc.ConvertTo<BudgetData>().TotalPresupuesto);
                textTotalPresupuestos.Text = LecturaCifra(sumPresupuestos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular el saldo: {ex.Message}");
                // Manejar la excepción según tus necesidades
            }
        }
        private void Limpiar()
        {
            comboInicioIntervalo.Text = "Enero";
            comboFinIntervalo.Text = "Enero";
            comboComite.Text = "Comite";
            textOfrendas.Text = "$ 000.00";
            textActividades.Text = "$ 000.00";
            textVotos.Text = "$ 000.00";
            textOtroConcepto.Text = "Nuevo concepto";
            textOtroValor.Text = "$ 000.00";
            textPresupuesto.Text = "$ 000.00";
        }
        private Presupuesto MapearPresupuesto()
        {
            presupuesto = new Presupuesto();
            presupuesto.AñoPresupuesto = comboAño.Text;
            presupuesto.InicioIntervalo = comboInicioIntervalo.Text;
            presupuesto.FinIntervalo = comboFinIntervalo.Text;
            presupuesto.Comite = comboComite.Text;
            presupuesto.Ofrenda = int.Parse(textOfrendas.Text);
            presupuesto.Actividad = int.Parse(textActividades.Text);
            presupuesto.Voto = int.Parse(textVotos.Text);
            presupuesto.TotalEgresos = int.Parse(textEgresos.Text);
            presupuesto.TotalPresupuesto = int.Parse(textPresupuesto.Text);
            return presupuesto;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            Presupuesto presupuesto = MapearPresupuesto();
            try
            {
                var msg = presupuestoService.Guardar(presupuesto);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var budgetNuevo = budgetMaps.BudgetMap(presupuesto);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(budgetNuevo.Id);
                docRef.SetAsync(budgetNuevo);
                // Guardamos localmente
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
                CalculoDeSaldo();
                Limpiar();
                tabPresupuestos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = presupuestoService.Guardar(presupuesto);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarPresupuesto();
                    Limpiar();
                    tabPresupuestos.SelectedIndex = 0;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            Presupuesto presupuesto = MapearPresupuesto();
            try
            {
                var msg = presupuestoService.Guardar(presupuesto);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var budgetNuevo = budgetMaps.BudgetMap(presupuesto);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(budgetNuevo.Id);
                docRef.SetAsync(budgetNuevo);
                // Guardamos localmente
                MessageBox.Show(msg, "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
                CalculoDeSaldo();
                Limpiar();
                tabPresupuestos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = presupuestoService.Guardar(presupuesto);
                    MessageBox.Show(msg, "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarPresupuesto();
                    Limpiar();
                    tabPresupuestos.SelectedIndex = 0;
                }
            }
        }

        private void textOfrendas_Validated(object sender, EventArgs e)
        {
            if (textOfrendas.Text != "" && textOfrendas.Text != "$ 000.00")
            {
                int sumOfrendas = int.Parse(textOfrendas.Text);
                textOfrendas.Text = LecturaCifra(sumOfrendas);
            }
        }

        private void textActividades_Validated(object sender, EventArgs e)
        {
            if (textActividades.Text != "" && textActividades.Text != "$ 000.00")
            {
                int sumActividades = int.Parse(textActividades.Text);
                textActividades.Text = LecturaCifra(sumActividades);
            }
        }

        private void textVotos_Validated(object sender, EventArgs e)
        {
            if (textVotos.Text != "" && textVotos.Text != "$ 000.00")
            {
                int sumVotos = int.Parse(textVotos.Text);
                textVotos.Text = LecturaCifra(sumVotos);
            }
        }

        private void textOtroValor_Validated(object sender, EventArgs e)
        {
            if (textOtroValor.Text != "" && textOtroValor.Text != "$ 000.00")
            {
                int sumOtroValor = int.Parse(textOtroValor.Text);
                textOtroValor.Text = LecturaCifra(sumOtroValor);
            }
        }

        private void textPresupuesto_Validated(object sender, EventArgs e)
        {
            if (textPresupuesto.Text != "" && textPresupuesto.Text != "$ 000.00")
            {
                int sumPresupuesto = int.Parse(textPresupuesto.Text);
                textPresupuesto.Text = LecturaCifra(sumPresupuesto);
            }
        }

        private void textEgresos_Validated(object sender, EventArgs e)
        {
            if (textEgresos.Text != "" && textEgresos.Text != "$ 000.00")
            {
                int sumEgreso = int.Parse(textEgresos.Text);
                textEgresos.Text = LecturaCifra(sumEgreso);
            }
        }

        private void comboFiltroAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboFiltroComite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textOtroConcepto_Enter(object sender, EventArgs e)
        {
            string placeHolder = textOtroConcepto.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textOtroConcepto.Text = validaciones.TextoPlaceHolderEnter(placeHolder, nombreDelComponente);
        }

        private void textOtroConcepto_Leave(object sender, EventArgs e)
        {
            string placeHolder = textOtroConcepto.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textOtroConcepto.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textOfrendas_Enter(object sender, EventArgs e)
        {
            if (textOfrendas.Text == "$ 000.00")
            {
                textOfrendas.Text = "";
            }
        }

        private void textOfrendas_Leave(object sender, EventArgs e)
        {
            if (textOfrendas.Text == "")
            {
                textOfrendas.Text = "$ 000.00";
            }
        }

        private void textActividades_Enter(object sender, EventArgs e)
        {
            if (textActividades.Text == "$ 000.00")
            {
                textActividades.Text = "";
            }
        }

        private void textActividades_Leave(object sender, EventArgs e)
        {
            if (textActividades.Text == "")
            {
                textActividades.Text = "$ 000.00";
            }
        }

        private void textVotos_Enter(object sender, EventArgs e)
        {
            if (textVotos.Text == "$ 000.00")
            {
                textVotos.Text = "";
            }
        }

        private void textVotos_Leave(object sender, EventArgs e)
        {
            if (textVotos.Text == "")
            {
                textVotos.Text = "$ 000.00";
            }
        }

        private void textOtroValor_Enter(object sender, EventArgs e)
        {
            if (textOtroValor.Text == "$ 000.00")
            {
                textOtroValor.Text = "";
            }
        }

        private void textOtroValor_Leave(object sender, EventArgs e)
        {
            if (textOtroValor.Text == "")
            {
                textOtroValor.Text = "$ 000.00";
            }
        }

        private void textPresupuesto_Enter(object sender, EventArgs e)
        {
            if (textPresupuesto.Text == "$ 000.00")
            {
                textPresupuesto.Text = "";
            }
        }

        private void textPresupuesto_Leave(object sender, EventArgs e)
        {
            if (textPresupuesto.Text == "")
            {
                textPresupuesto.Text = "$ 000.00";
            }
        }

        private void textEgresos_Enter(object sender, EventArgs e)
        {
            if (textEgresos.Text == "$ 000.00")
            {
                textEgresos.Text = "";
            }
        }

        private void textEgresos_Leave(object sender, EventArgs e)
        {
            if (textEgresos.Text == "")
            {
                textEgresos.Text = "$ 000.00";
            }
        }
    }
}
