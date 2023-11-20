using BLL;
using Cloud;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Entity;
using Google.Cloud.Firestore;
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
    public partial class FormEgresos : Form
    {
        Egreso egreso;
        EgresoService egresoService;
        List<Egreso> egresos;
        EgressMap egressMaps;
        TabPage tabPage;
        string originalText;
        string comprobante = "";
        string id;
        string comite;
        bool encontrado = false;
        bool detallo = false;
        public FormEgresos()
        {
            egresoService = new EgresoService(ConfigConnection.ConnectionString);
            egressMaps = new EgressMap();
            InitializeComponent();
            ConsultarEgresos();
            CalcularComprobante();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGestionarEgresos_Click(object sender, EventArgs e)
        {
            tabEgresos.SelectedIndex = 1;
        }
        private async void TotalizarEgresos()
        {
            int sumEgreso = 0;
            try
            {
                var db = FirebaseService.Database;
                var egresos = new List<EgressData>();
                Query egressQuery = db.Collection("EgressData");
                QuerySnapshot snap = await egressQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot docsnap in snap.Documents)
                {
                    EgressData egressData = docsnap.ConvertTo<EgressData>();
                    sumEgreso = sumEgreso + egressData.Valor;
                    if (sumEgreso > 0)
                    {
                        textTotalEgresos.Text = sumEgreso.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
                respuesta = egresoService.ConsultarTodos();
                if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
                {
                    egresos = respuesta.Egresos.ToList();
                    for (int i = 0; i < egresos.Count; i++)
                    {
                        sumEgreso = sumEgreso + respuesta.Egresos[i].Valor;
                    }
                }
            }
        }
        private async void TotalizarRegistros()
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            respuesta = egresoService.ConsultarTodos();
            if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
            {
                dataGridEgresos.DataSource = null;
                egresos = respuesta.Egresos.ToList();
                if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
                {
                    try
                    {
                        var db = FirebaseService.Database;
                        var egresos = new List<EgressData>();
                        Query egressQuery = db.Collection("EgressData");
                        QuerySnapshot snap = await egressQuery.GetSnapshotAsync();
                        foreach (DocumentSnapshot docsnap in snap.Documents)
                        {
                            EgressData egressData = docsnap.ConvertTo<EgressData>();
                            egresos.Add(egressData);
                            textTotalNube.Text = egresos.Count.ToString();
                        }
                        textTotalLocal.Text = egresoService.Totalizar().Cuenta.ToString();
                    }
                    catch(Exception ex)
                    {
                        textTotalLocal.Text = egresoService.Totalizar().Cuenta.ToString();
                        textTotalNube.Text = "0";
                    }
                }
                else
                {
                    textTotalLocal.Text = "0";
                    textTotalNube.Text = "0";
                }
            }
        }
        private void FormEgresos_Load(object sender, EventArgs e)
        {
            if (tabEgresos.TabCount > 0)
            {
                tabPage = tabEgresos.TabPages["tabDetalle"];
                tabEgresos.TabPages.RemoveAt(2);
            }
        }
        private void CalcularComprobante()
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            respuesta = egresoService.ConsultarTodos();
            egresos = respuesta.Egresos.ToList();
            if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
            {
                List<int> comprobantes = new List<int>();
                string numeroComprobanteFinal = "";

                for (int i = 0; i < respuesta.Egresos.Count; i++)
                {
                    // Obtener el número del comprobante del egreso actual
                    int numeroComprobanteActual = int.Parse(respuesta.Egresos[i].CodigoComprobante);

                    // Agregarlo a la lista de comprobantes
                    comprobantes.Add(numeroComprobanteActual);
                }

                // Verificar si hay elementos en la lista de comprobantes
                if (comprobantes.Count > 0)
                {
                    // Obtener el número mayor de la lista
                    int numeroMayor = comprobantes.Max();
                    numeroMayor = numeroMayor + 1;
                    // Asignar el número mayor a la variable final
                    // Supongamos que tienes una variable final llamada 'numeroComprobanteFinal'
                    numeroComprobanteFinal = numeroMayor.ToString("0000");
                    textNumeroComprobante.Text = numeroComprobanteFinal;
                }
            }
            else
            {
                var totalFolio = 1;
                comprobante = totalFolio.ToString("0000");
                textNumeroComprobante.Text = comprobante;
            }
        }
        private async void ConsultarEgresos()
        {
            TotalizarEgresos();
            TotalizarRegistros();
            try
            {
                bool isNotEmpty = false;
                var db = FirebaseService.Database;
                var egresos = new List<EgressData>();
                Query egressQuery = db.Collection("EgressData");
                QuerySnapshot snap = await egressQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot docsnap in snap.Documents)
                {
                    EgressData egressData = docsnap.ConvertTo<EgressData>();
                    egresos.Add(egressData);
                    if (egresos.Count > 0)
                    {
                        isNotEmpty = true;
                    }
                }
                if (isNotEmpty)
                {
                    dataGridEgresos.DataSource = null;
                    dataGridEgresos.DataSource = egresos;
                }
                else
                {
                    dataGridEgresos.DataSource = null;
                    textTotalLocal.Text = "0";
                }
            }
            catch (Exception e)
            {
                ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
                respuesta = egresoService.ConsultarTodos();
                if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
                {
                    dataGridDetalle.DataSource = null;
                    egresos = respuesta.Egresos.ToList();
                    dataGridDetalle.DataSource = respuesta.Egresos;
                    Borrar.Visible = true;
                    textTotalLocal.Text = egresoService.Totalizar().Cuenta.ToString();
                }
            }
        }
        void FiltroPorId(string id)
        {
            BusquedaEgresoRespuesta respuesta = new BusquedaEgresoRespuesta();
            respuesta = egresoService.BuscarPorIdentificacion(id);
            var registro = respuesta.Egreso;
            if (registro != null)
            {
                encontrado = true;
                var egresos = new List<Egreso> { registro };
                textNumeroComprobante.Text = egresos[0].CodigoComprobante;
                dateTimeEgreso.Value = egresos[0].FechaDeEgreso;
                comboComite.Text = egresos[0].Comite;
                comboConcepto.Text = egresos[0].Concepto;
                textDineroIngreso.Text = egresos[0].Valor.ToString();
                textDetalle.Text = egresos[0].Detalle;
            }
        }
        void FiltroPorComite(string comite)
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            respuesta = egresoService.FiltrarEgresosPorComite(comite);
            if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
            {
                dataGridEgresos.DataSource = null;
                egresos = respuesta.Egresos.ToList();
                if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
                {
                    dataGridEgresos.DataSource = respuesta.Egresos;
                    Borrar.Visible = true;
                }
            }
            else
            {
                dataGridEgresos.DataSource = null;
                egresos = respuesta.Egresos.ToList();
            }
        }
        void FiltrarEgresosPorComite(string comite)
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            respuesta = egresoService.FiltrarEgresosPorComite(comite);
            if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
            {
                dataGridDetalle.DataSource = null;
                egresos = respuesta.Egresos.ToList();
                int sumTotal = 0;
                dataGridDetalle.DataSource = respuesta.Egresos;
                Borrar.Visible = true;
                textTotalComite.Text = egresoService.TotalizarTipo(comite).Cuenta.ToString();
                for (int i = 0; i < respuesta.Egresos.Count; i++)
                {
                    sumTotal = sumTotal + respuesta.Egresos[i].Valor;
                    textValorConcepto.Text = sumTotal.ToString();
                }
            }
            else
            {
                textTotalComite.Text = "0";
            }
        }
        void FiltrarPorConcepto(string concepto)
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            respuesta = egresoService.FiltrarEgresosPorConcepto(concepto);
            if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
            {
                var conceptos = new List<Egreso>();
                var sumTotal = 0;
                dataGridDetalle.DataSource = null;
                egresos = respuesta.Egresos.ToList();
                for (int i = 0; i < egresos.Count; i++)
                {
                    if (egresos[i].Comite == comite)
                    {
                        conceptos.Add(egresos[i]);
                        sumTotal = sumTotal + egresos[i].Valor;
                    }
                }
                textValorConcepto.Text = sumTotal.ToString();
                dataGridDetalle.DataSource = conceptos;
                Borrar.Visible = true;
            }
            else
            {
                textValorConcepto.Text = "0";
                dataGridDetalle.DataSource = null;
            }
        }
        private void dataGridEgresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridEgresos.DataSource != null)
            {
                if (dataGridEgresos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToString(dataGridEgresos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                    EliminarIngreso(id);
                    ConsultarEgresos();
                }
                else
                {
                    if (dataGridEgresos.Columns[e.ColumnIndex].Name == "Detallar")
                    {
                        comite = Convert.ToString(dataGridEgresos.CurrentRow.Cells["Comite"].Value.ToString());
                        FiltrarEgresosPorComite(comite);
                        tabEgresos.TabPages.Add(tabPage);
                        tabEgresos.SelectedIndex = 2;
                        detallo = true;
                    }
                    else
                    {
                        if (dataGridEgresos.Columns[e.ColumnIndex].Name == "Editar")
                        {
                            id = Convert.ToString(dataGridEgresos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabEgresos.SelectedIndex = 1;
                            }
                        }
                    }
                }
            }
        }
        private void dataGridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridDetalle.DataSource != null)
            {
                if (dataGridDetalle.Columns[e.ColumnIndex].Name == "Borrar2")
                {
                    id = Convert.ToString(dataGridDetalle.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                    EliminarIngreso(id);
                    ConsultarEgresos();
                    tabEgresos.SelectedIndex = 0;
                }
                else
                {
                    if (dataGridDetalle.Columns[e.ColumnIndex].Name == "Editar2")
                    {
                        id = Convert.ToString(dataGridDetalle.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                        FiltroPorId(id);
                        if (encontrado == true)
                        {
                            tabEgresos.SelectedIndex = 1;
                        }
                    }
                }
            }
        }
        private void comboConcepto_Enter(object sender, EventArgs e)
        {
            if (comboConcepto.Text == "Concepto")
            {
                comboConcepto.Text = "";
            }
        }

        private void comboConcepto_Leave(object sender, EventArgs e)
        {
            if (comboConcepto.Text == "")
            {
                comboConcepto.Text = "Concepto";
            }
        }

        private void textDineroIngreso_Enter(object sender, EventArgs e)
        {
            originalText = textDineroIngreso.Text;
            if (textDineroIngreso.Text == "$ 000.00")
            {
                textDineroIngreso.Text = "";
            }
            else
            {

                if (textDineroIngreso.Text.StartsWith("$ "))
                {
                    // Borra el contenido del TextBox si comienza con "$ "
                    textDineroIngreso.Text = "";
                }
            }
        }

        private void textDineroIngreso_Leave(object sender, EventArgs e)
        {
            if (textDineroIngreso.Text == "")
            {
                textDineroIngreso.Text = "$ 000.00";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textDineroIngreso.Text))
                {
                    // Restaura el contenido original al salir del TextBox
                    textDineroIngreso.Text = originalText;
                }
            }
        }

        private void textDetalle_Enter(object sender, EventArgs e)
        {
            if (textDetalle.Text == "Detalle")
            {
                textDetalle.Text = "";
            }
        }

        private void textDetalle_Leave(object sender, EventArgs e)
        {
            if (textDetalle.Text == "")
            {
                textDetalle.Text = "Detalle";
            }
        }

        private void textDineroIngreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void textDineroIngreso_Validated(object sender, EventArgs e)
        {
            if (textDineroIngreso.Text != "" && textDineroIngreso.Text != "$ 000.00")
            {
                textDineroIngreso.Text = "$ " + textDineroIngreso.Text;
            }
        }

        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            textSerachLibreta.Visible = true;
            btSearchLibreta.Visible = false;
            btnCloseSearchLibreta.Visible = true;
        }

        private void btnCloseSearchLibreta_Click(object sender, EventArgs e)
        {
            textSerachLibreta.Visible = false;
            btSearchLibreta.Visible = true;
            btnCloseSearchLibreta.Visible = false;
            if (textSerachLibreta.Text == "")
            {
                textSerachLibreta.Text = "Buscar por fecha";
            }
        }

        private void textSerachLibreta_Enter(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text == "Buscar por fecha")
            {
                textSerachLibreta.Text = "";
            }
        }

        private void textSerachLibreta_Leave(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text == "")
            {
                textSerachLibreta.Text = "Buscar por fecha";
            }
        }
        private Egreso MapearEgreso()
        {
            egreso = new Egreso();
            egreso.CodigoComprobante = textNumeroComprobante.Text;
            egreso.FechaDeEgreso = dateTimeEgreso.Value;
            egreso.Comite = comboComite.Text;
            egreso.Concepto = comboConcepto.Text;
            string cantidadConSigno = textDineroIngreso.Text; // Esto contiene "$ 30000"
            string cantidadSinSigno = cantidadConSigno.Replace("$", "").Trim(); // Esto quita el signo "$"
            int cantidadEntera = int.Parse(cantidadSinSigno); // Convierte el valor a un entero
            egreso.Valor = cantidadEntera;
            egreso.Detalle = textDetalle.Text;
            return egreso;
        }
        private void Limpiar()
        {
            int seguimiento = int.Parse(textNumeroComprobante.Text);
            textNumeroComprobante.Text = (seguimiento + 1).ToString();
            CalcularComprobante();
            dateTimeEgreso.Value = DateTime.Now;
            comboComite.Text = "Comite";
            comboConcepto.Text = "Concepto";
            textDineroIngreso.Text = "$ 000.00";
            textDetalle.Text = "Detalle";
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            Egreso egreso = MapearEgreso();
            try
            {
                var msg = egresoService.Guardar(egreso);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var egress = egressMaps.EgressMaps(egreso);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("EgressData").Document(egress.CodigoComprobante);
                docRef.SetAsync(egress);
                // Guardamos localmente
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarEgresos();
                Limpiar();
                tabEgresos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = egresoService.Guardar(egreso);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarEgresos();
                    Limpiar();
                    tabEgresos.SelectedIndex = 0;
                }
            }
        }
        private void EliminarIngreso(string codigo)
        {
            try
            {
                //Elimina primero de firebase o la nube
                var db = FirebaseService.Database;
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("EgressData").Document(codigo);
                docRef.DeleteAsync();
                string mensaje = egresoService.Eliminar(codigo);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarEgresos();
            }
            catch (Exception e)
            {
                string mensaje = egresoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarEgresos();
            }
        }

        private void tabEgresos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEgresos.SelectedIndex != 2 && detallo != false)
            {
                tabPage = tabEgresos.TabPages["tabDetalle"];
                tabEgresos.TabPages.RemoveAt(2);
                detallo = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Egreso nuevoEgreso = MapearEgreso();
            try
            {
                nuevoEgreso.CodigoComprobante = id;
                string mensaje = egresoService.Modificar(nuevoEgreso);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var ingress = egressMaps.EgressMaps(nuevoEgreso);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("EgressData").Document(ingress.CodigoComprobante.ToString());
                docRef.SetAsync(ingress);
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ConsultarEgresos();
                Limpiar();
                tabEgresos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string mensaje = egresoService.Modificar(nuevoEgreso);
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ConsultarEgresos();
                Limpiar();
                tabEgresos.SelectedIndex = 0;
            }
        }

        private void comboFiltroComite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboFiltroComite.Text;
            if (filtro == "Todos")
            {
                ConsultarEgresos();
            }
            else
            {
                FiltroPorComite(filtro);
            }
        }

        private void comboConceptoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboConceptoDetalle.Text;
            if (filtro == "Ninguno")
            {
                FiltrarEgresosPorComite(comite);
            }
            else
            {
                FiltrarPorConcepto(filtro);
            }
        }

        private void btnImprimirDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}
