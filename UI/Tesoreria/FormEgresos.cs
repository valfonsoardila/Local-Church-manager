using BLL;
using Cloud;
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
using System.Windows.Forms;

namespace UI
{
    public partial class FormEgresos : Form
    {
        Egreso egreso;
        EgresoService egresoService;
        List<Egreso> egresos;
        EgressMap egressMaps;
        string originalText;
        bool encontrado = false;
        string comprobante = "";
        string id;
        public FormEgresos()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CalcularComprobante()
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            respuesta = egresoService.ConsultarTodos();
            egresos = respuesta.Egresos.ToList();
            if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
            {
                textTotal.Text = egresoService.Totalizar().Cuenta.ToString();
                var totalComprobante = Convert.ToInt32(textTotal.Text);
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
        private async void ConsultarEgresos()
        {
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
                    egresos = new List<EgressData> { egressData };
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
                    textTotal.Text = "0";
                }
            }
            catch(Exception e)
            {
                ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
                respuesta = egresoService.ConsultarTodos();
                if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
                {
                    dataGridEgresos.DataSource = null;
                    respuesta = egresoService.ConsultarTodos();
                    egresos = respuesta.Egresos.ToList();
                    if (respuesta.Egresos.Count != 0 && respuesta.Egresos != null)
                    {
                        dataGridEgresos.DataSource = respuesta.Egresos;
                        Borrar.Visible = true;
                        textTotal.Text = egresoService.Totalizar().Cuenta.ToString();
                    }
                    else
                    {
                        textTotal.Text = "0";
                    }
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
                var ingresos = new List<Egreso> { registro };
                textNumeroComprobante.Text = ingresos[0].CodigoComprobante;
                dateTimeEgreso.Value = ingresos[0].FechaDeEgreso;
                comboComite.Text = ingresos[0].Comite;
                comboConcepto.Text = ingresos[0].Concepto;
                textDineroIngreso.Text = ingresos[0].Valor.ToString();
                textDetalle.Text = ingresos[0].Detalle;
            }
        }
        private void btnGestionarEgresos_Click(object sender, EventArgs e)
        {
            tabEgresos.SelectedIndex = 1;
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
            egreso.Valor = int.Parse(textDineroIngreso.Text);
            egreso.Detalle = textDetalle.Text;
            return egreso;
        }
        private void Limpiar()
        {
            textNumeroComprobante.Text = "0000";
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
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("EgressData").Document(egress.VoucherCode.ToString());
                docRef.SetAsync(egress);
                // Guardamos localmente
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = egresoService.Guardar(egreso);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
        }
        private void EliminarIngreso(string id)
        {
            string mensaje = egresoService.Eliminar(id);
            MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        id = Convert.ToString(dataGridEgresos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
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
    }
}
