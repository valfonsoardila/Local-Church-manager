using BLL;
using Cloud;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        List<BudgetData> presupuestosComite;
        List<BudgetData> presupuestosGeneral;
        int id = 0;
        int sumPresupuestos = 0;
        int ultimoId;
        string comite = "";
        bool detallo = false;
        bool encontrado = false;
        bool nuevoConcepto = false;
        public FormPresupuesto()
        {
            validaciones = new Validaciones();
            presupuestoService = new PresupuestoService(ConfigConnection.ConnectionString);
            budgetData = new BudgetData();
            budgetMaps = new BudgetMaps();
            InitializeComponent();
            ObtenerUltimoPresupuesto();
            ConsultarPresupuesto();
            ObtenerDatosGenerales();
            ObtenerDatosIndividuales();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void ObtenerUltimoPresupuesto()
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData").OrderByDescending("id").Limit(1);

                var snapshot = await presupuestosQuery.GetSnapshotAsync();

                if (snapshot.Documents.Count > 0)
                {
                    var ultimoRegistro = snapshot.Documents.First();
                    ultimoId = ultimoRegistro.GetValue<int>("id");
                }
            }catch(Exception ex)
            {
                FormMenu formMenu = new FormMenu(true); 
                formMenu.disponibilidadNube = true;
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.ConsultarTodos();
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    var ultimopresupuesto = respuesta.Presupuestos.Last();
                    ultimoId = ultimopresupuesto.Id;
                }
            }
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
                presupuestosGeneral = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestosGeneral = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                if (presupuestosGeneral.Count > 0)
                {
                    dataGridPresupuestos.DataSource = null;
                    dataGridPresupuestos.DataSource = presupuestosGeneral;
                }
                else
                {
                    dataGridPresupuestos.DataSource = null;
                    textTotal.Text = "0";
                }
            }
            catch(Exception ex)
            {
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.ConsultarTodos();
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    dataGridPresupuestos.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                    dataGridPresupuestos.DataSource = presupuestos;
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
                dataGridPresupuestos.DataSource = null;
                ConsultarPresupuesto();
            }
            catch (Exception e)
            {
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
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
                presupuestosComite = presupuestos.Where(presupuesto => presupuesto.Comite == comite).ToList();
                dataGridPresupuestos.DataSource = presupuestosComite;
                Borrar.Visible = true;
            }
            catch (Exception ex)
            {
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
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
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
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
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
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
            textNuevoConcepto.Text = "Nuevo concepto";
            textOtroValor.Text = "$ 000.00";
            textPresupuesto.Text = "$ 000.00";
        }
        private void ValidarNuevoConcepto()
        {
            if(textNuevoConcepto.Text!="" && textNuevoConcepto.Text=="Nuevo concepto")
            {
                nuevoConcepto = true;
            }
        }
        private int ObtenerCantidadEntera(string cantidad)
        {
            string cantidadSinSigno = cantidad.Replace("$", "").Trim(); // Esto quita el signo "$"
            string cantidadSinPuntos = cantidadSinSigno.Replace(".", "").Trim();
            int cantidadEntera = int.Parse(cantidadSinPuntos);
            return cantidadEntera;
        }
        private Presupuesto MapearPresupuesto()
        {
            presupuesto = new Presupuesto();
            presupuesto.Id = ultimoId != 0 ? ultimoId : 0;
            presupuesto.AñoPresupuesto = comboAño.Text;
            presupuesto.InicioIntervalo = comboInicioIntervalo.Text;
            presupuesto.FinIntervalo = comboFinIntervalo.Text;
            presupuesto.Comite = comboComite.Text;
            presupuesto.Ofrenda = ObtenerCantidadEntera(textOfrendas.Text);
            presupuesto.Actividad = ObtenerCantidadEntera(textActividades.Text);
            presupuesto.Voto = ObtenerCantidadEntera(textVotos.Text);
            presupuesto.OtroConcepto = nuevoConcepto ? "Ninguno" : textNuevoConcepto.Text;
            presupuesto.ValorOtroConcepto = nuevoConcepto ? 0:ObtenerCantidadEntera(textOtroValor.Text);
            presupuesto.TotalEgresos = ObtenerCantidadEntera(textEgresos.Text);
            presupuesto.TotalPresupuesto = ObtenerCantidadEntera(textPresupuesto.Text);
            return presupuesto;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            ValidarNuevoConcepto();
            Presupuesto presupuesto = MapearPresupuesto();
            try
            {
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var budgetNuevo = budgetMaps.BudgetMap(presupuesto);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(budgetNuevo.Id);
                docRef.SetAsync(budgetNuevo);
                // Guardamos localmente
                var msg = presupuestoService.Guardar(presupuesto);
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
                CalculoDeSaldo();
                Limpiar();
                tabPresupuestos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = presupuestoService.Guardar(presupuesto);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarPresupuesto();
                    //Limpiar();
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
                FormMenu formMenu = new FormMenu(false);
                formMenu.disponibilidadNube = false;
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

        //private void textPresupuesto_Validated(object sender, EventArgs e)
        //{
        //    if (textPresupuesto.Text != "" && textPresupuesto.Text != "$ 000.00")
        //    {
        //        int sumPresupuesto = int.Parse(textPresupuesto.Text);
        //        textPresupuesto.Text = LecturaCifra(sumPresupuesto);
        //    }
        //}

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
            string placeHolder = textNuevoConcepto.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textNuevoConcepto.Text = validaciones.TextoPlaceHolderEnter(placeHolder, nombreDelComponente);
        }

        private void textOtroConcepto_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNuevoConcepto.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textNuevoConcepto.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textOfrendas_Enter(object sender, EventArgs e)
        {
            if (textOfrendas.Text != "")
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
            if (textActividades.Text != "")
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
            if (textVotos.Text != "")
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
            if (textOtroValor.Text != "")
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
            if (textPresupuesto.Text != "")
            {
                textPresupuesto.Text = "";
            }
            TotalizarConceptos();
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
            if (textEgresos.Text != "")
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
        private void TotalizarConceptos()
        {
            int ofrendas = ObtenerCantidadEntera(textOfrendas.Text);
            int actividades = ObtenerCantidadEntera(textActividades.Text);
            int votos = ObtenerCantidadEntera(textVotos.Text);
            int otro = ObtenerCantidadEntera(textOtroValor.Text);
            int totalConceptos = ofrendas + actividades + votos + otro;
            textPresupuesto.Text = LecturaCifra(totalConceptos);
        }
        private void dataGridPresupuestos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPresupuestos.DataSource != null)
            {
                if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["Id"].Value.ToString());
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
                            id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["Id"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabPresupuestos.SelectedIndex = 1;
                            }
                        }
                        else
                        {
                            if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Seleccionar")
                            {
                                // Verificar si el clic se realizó en la columna de CheckBoxColumn
                                if (e.ColumnIndex == dataGridPresupuestos.Columns["Seleccionar"].Index && e.RowIndex != -1)
                                {
                                    // Obtener la celda de CheckBox clicada
                                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridPresupuestos.Rows[e.RowIndex].Cells["Seleccionar"];
                                    // Cambiar el estado del CheckBox
                                    checkBoxCell.Value = !Convert.ToBoolean(checkBoxCell.Value);
                                    // Consulta
                                    comite = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["Comite"].Value.ToString());
                                    FiltrarPresupuestosPorComite(comite);
                                    ObtenerDatosIndividuales();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ObtenerDatosIndividuales()
        {
            //Este se representará con los datos individuales de cada comite que son ofrendas, actividades, votos y otro.
            if (presupuestosComite != null && presupuestosComite.Any())
            {
                // Asegúrate de tener los nombres correctos de las propiedades según la estructura de tu clase BudgetData
                int ofrenda = presupuestosComite.Sum(p => p.Ofrenda);
                int actividad = presupuestosComite.Sum(p => p.Actividad);
                int voto = presupuestosComite.Sum(p => p.Voto);
                int otroConcepto = presupuestosComite.Sum(p => p.ValorOtroConcepto);

                // Calcula los porcentajes
                double porcentajeOfrenda = (double)ofrenda / presupuestosComite[0].TotalPresupuesto * 100;
                double porcentajeActividad = (double)actividad / presupuestosComite[0].TotalPresupuesto * 100;
                double porcentajeVoto = (double)voto / presupuestosComite[0].TotalPresupuesto * 100;
                double porcentajeOtroConcepto = (double)otroConcepto / presupuestosComite[0].TotalPresupuesto * 100;
                
                //limpia los puntos anteriores
                chartIndividual.Series[0].Points.Clear();

                // Agrega los nuevos puntos al gráfico
                chartIndividual.Series[0].Points.AddXY("Ofrenda", porcentajeOfrenda);
                chartIndividual.Series[0].Points.AddXY("Actividad", porcentajeActividad);
                chartIndividual.Series[0].Points.AddXY("Voto", porcentajeVoto);
                chartIndividual.Series[0].Points.AddXY("Otro Concepto", porcentajeOtroConcepto);

                // Configura el gráfico
                chartIndividual.Series[0].ChartType = SeriesChartType.Doughnut;
                chartIndividual.Series[0].IsValueShownAsLabel = true;
                chartIndividual.Series[0].LabelFormat = "P"; // Muestra los porcentajes
                chartIndividual.Titles.Clear();
                chartIndividual.Titles.Add("Distribución de Gastos");
            }
        }
        private void ObtenerDatosGenerales()
        {
            if (presupuestosGeneral != null && presupuestosGeneral.Any())
            {

            }
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            FormGenerarDocumento formGenerarDocumento = new FormGenerarDocumento();
            formGenerarDocumento.Show();
        }
    }
}