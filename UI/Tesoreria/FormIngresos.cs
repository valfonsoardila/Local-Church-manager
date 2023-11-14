using BLL;
using Cloud;
using Entity;
using Google.Cloud.Firestore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace UI
{
    public partial class FormIngresos : Form
    {
        Ingreso ingreso;
        IngresoService ingresoService;
        List<Ingreso> ingresos;
        IngressMaps ingressMaps;
        TabPage tabPage;
        string originalText;
        string comprobante = "";
        string id;
        string comite;
        bool encontrado = false;
        bool detallo = false;
        public FormIngresos()
        {
            ingresoService = new IngresoService(ConfigConnection.ConnectionString);
            ingressMaps = new IngressMaps();
            InitializeComponent();
            ConsultarIngresos();
            CalcularComprobante();
            TotalizarRegistros();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarDirectivas_Click(object sender, EventArgs e)
        {
            tabLibroIngresos.SelectedIndex = 1;
        }
        private async void TotalizarRegistros()
        {
            ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
            respuesta = ingresoService.ConsultarTodos();
            if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
            {
                dataGridIngresos.DataSource = null;
                ingresos = respuesta.Ingresos.ToList();
                if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
                {
                    textTotalLocal.Text = ingresoService.Totalizar().Cuenta.ToString();
                    var db = FirebaseService.Database;
                    var ingresos = new List<IngressData>();
                    Query ingressQuery = db.Collection("IngressData");
                    QuerySnapshot snap = await ingressQuery.GetSnapshotAsync();
                    foreach (DocumentSnapshot docsnap in snap.Documents)
                    {
                        IngressData ingressData = docsnap.ConvertTo<IngressData>();
                        ingresos.Add(ingressData);
                        textTotalNube.Text = ingresos.Count.ToString();
                    }
                }
                else
                {
                    textTotalLocal.Text = "0";
                    textTotalNube.Text = "0";
                }
            }
        }
        private void FormIngresos_Load(object sender, EventArgs e)
        {
            if (tabLibroIngresos.TabCount > 0)
            {
                tabPage = tabLibroIngresos.TabPages["tabDetalle"];
                tabLibroIngresos.TabPages.RemoveAt(2);
            }
        }
        private void CalcularComprobante()
        {
            ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
            respuesta = ingresoService.ConsultarTodos();
            ingresos = respuesta.Ingresos.ToList();
            if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
            {
                textTotalLocal.Text = ingresoService.Totalizar().Cuenta.ToString();
                var totalComprobante = Convert.ToInt32(textTotalLocal.Text);
                comprobante = (totalComprobante + 1).ToString("0000");
                textNumeroComprobante.Text = comprobante;
            }
            else
            {
                var totalFolio = 1;
                comprobante = totalFolio.ToString("0000");
                textNumeroComprobante.Text = comprobante;
            }
        }
        private async void ConsultarIngresos()
        {
            try
            {
                bool isNotEmpty = false;
                var db = FirebaseService.Database;
                var ingresos = new List<IngressData>();
                Query ingressQuery = db.Collection("IngressData");
                QuerySnapshot snap = await ingressQuery.GetSnapshotAsync();
                foreach(DocumentSnapshot docsnap in snap.Documents)
                {
                    IngressData ingressData = docsnap.ConvertTo<IngressData>();
                    ingresos.Add(ingressData);
                    if (ingresos.Count > 0)
                    {
                        isNotEmpty = true;
                    }
                }
                if (isNotEmpty)
                {
                    dataGridIngresos.DataSource = null;
                    dataGridIngresos.DataSource = ingresos;
                }
                else
                {
                    dataGridIngresos.DataSource = null;
                    textTotalLocal.Text = "0";
                }
            }
            catch (Exception e)
            {
                ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
                respuesta = ingresoService.ConsultarTodos();
                if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
                {
                    dataGridIngresos.DataSource = null;
                    ingresos = respuesta.Ingresos.ToList();
                    if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
                    {
                        dataGridIngresos.DataSource = respuesta.Ingresos;
                        Borrar.Visible = true;
                        textTotalLocal.Text = ingresoService.Totalizar().Cuenta.ToString();
                    }
                    else
                    {
                        textTotalLocal.Text = "0";
                    }
                }
            }
        }
        void FiltroPorId(string id)
        {
            BusquedaIngresoRespuesta respuesta = new BusquedaIngresoRespuesta();
            respuesta = ingresoService.BuscarPorIdentificacion(id);
            var registro = respuesta.Ingreso;
            if (registro != null)
            {
                encontrado = true;
                var ingresos = new List<Ingreso> { registro };
                textNumeroComprobante.Text = ingresos[0].CodigoComprobante;
                dateFechaIngreso.Value = ingresos[0].FechaDeIngreso;
                comboComite.Text = ingresos[0].Comite;
                comboConcepto.Text = ingresos[0].Concepto;
                textDineroIngreso.Text = ingresos[0].Valor.ToString();
                textDetalle.Text = ingresos[0].Detalle;
            }
        }
        void FiltrarIngresosPorComite(string comite)
        {
            ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
            respuesta = ingresoService.FiltrarIngresosPorComite(comite);
            if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
            {
                dataGridDetalle.DataSource = null;
                ingresos = respuesta.Ingresos.ToList();
                if (respuesta.Ingresos.Count != 0 && respuesta.Ingresos != null)
                {
                    dataGridDetalle.DataSource = respuesta.Ingresos;
                    Borrar.Visible = true;
                    textTotalComite.Text = ingresoService.TotalizarTipo(comite).Cuenta.ToString();
                }
                else
                {
                    textTotalComite.Text = "0";
                }
            }
        }

        private void dataGridIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridIngresos.DataSource != null)
            {
                if (dataGridIngresos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToString(dataGridIngresos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                    EliminarIngreso(id);
                    ConsultarIngresos();
                }
                else
                {
                    if (dataGridIngresos.Columns[e.ColumnIndex].Name == "Detallar")
                    {
                        comite = Convert.ToString(dataGridIngresos.CurrentRow.Cells["Comite"].Value.ToString());
                        FiltrarIngresosPorComite(comite);
                        tabLibroIngresos.TabPages.Add(tabPage);
                        tabLibroIngresos.SelectedIndex = 2;
                        detallo = true;
                    }
                    else
                    {
                        if (dataGridIngresos.Columns[e.ColumnIndex].Name == "Editar")
                        {
                            id = Convert.ToString(dataGridIngresos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabLibroIngresos.SelectedIndex = 1;
                            }
                        }
                    }
                }
            }
        }

        private void textDineroIngreo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textSerachLibreta_TextChanged(object sender, EventArgs e)
        {
            if(textSerachLibreta.Text!="" && textSerachLibreta.Text != "Buscar por detalle")
            {

            }
        }

        private void textSerachLibreta_Enter(object sender, EventArgs e)
        {
            if(textSerachLibreta.Text== "Buscar por detalle")
            {
                textSerachLibreta.Text = "";
            }
        }

        private void textSerachLibreta_Leave(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text == "")
            {
                textSerachLibreta.Text = "Buscar por detalle";
            }
        }

        private void textDineroIngreo_Enter(object sender, EventArgs e)
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

        private void textDineroIngreo_Leave(object sender, EventArgs e)
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

        private void comboComite_Enter(object sender, EventArgs e)
        {
            if (comboComite.Text == "Comite")
            {
                comboComite.Text = "";
            }
        }

        private void comboComite_Leave(object sender, EventArgs e)
        {
            if (comboComite.Text == "")
            {
                comboComite.Text = "Comite";
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

        private void textDineroIngreso_Validated(object sender, EventArgs e)
        {
            if (textDineroIngreso.Text != "" && textDineroIngreso.Text != "$ 000.00")
            {
                textDineroIngreso.Text = "$ " + textDineroIngreso.Text;
            }
        }

        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            if (textSerachLibreta.Visible == false)
            {
                textSerachLibreta.Visible = true;
                btSearchLibreta.Visible = false;
                btnCloseSearchLibreta.Visible = true;
            }
        }

        private void btnCloseSearchLibreta_Click(object sender, EventArgs e)
        {
            if (textSerachLibreta.Visible == true)
            {
                textSerachLibreta.Visible = false;
                btSearchLibreta.Visible = true;
                btnCloseSearchLibreta.Visible = false;
            }
        }
        private Ingreso MapearIngreso()
        {
            ingreso = new Ingreso();
            ingreso.CodigoComprobante = textNumeroComprobante.Text;
            ingreso.FechaDeIngreso = dateFechaIngreso.Value;
            ingreso.Comite = comboComite.Text;
            ingreso.Concepto = comboConcepto.Text;
            string cantidadConSigno = textDineroIngreso.Text; // Esto contiene "$ 30000"
            string cantidadSinSigno = cantidadConSigno.Replace("$", "").Trim(); // Esto quita el signo "$"
            int cantidadEntera = int.Parse(cantidadSinSigno); // Convierte el valor a un entero
            ingreso.Valor = cantidadEntera;
            ingreso.Detalle = textDetalle.Text;
            return ingreso;
        }
        private void Limpiar()
        {
            textNumeroComprobante.Text = "0000";
            CalcularComprobante();
            dateFechaIngreso.Value = DateTime.Now;
            comboComite.Text = "Comite";
            comboConcepto.Text = "Concepto";
            textDineroIngreso.Text = "$ 000.00";
            textDetalle.Text="Detalle";
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            Ingreso ingreso = MapearIngreso();
            try
            {
                var msg = ingresoService.Guardar(ingreso);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var ingress = ingressMaps.IngressMap(ingreso);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("IngressData").Document(ingress.CodigoComprobante.ToString());
                docRef.SetAsync(ingress);
                // Guardamos localmente
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarIngresos();
                Limpiar();
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = ingresoService.Guardar(ingreso);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
        }
        private void EliminarIngreso(string id)
        {
            try
            {
                string mensaje = ingresoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e)
            {
                string mensaje = ingresoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabLibroIngresos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabLibroIngresos.SelectedIndex != 2 && detallo!=false)
            {
                tabPage = tabLibroIngresos.TabPages["tabDetalle"];
                tabLibroIngresos.TabPages.RemoveAt(2);
                detallo = false;
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
