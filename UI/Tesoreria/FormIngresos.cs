using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        string originalText;
        string id;
        string telefono;
        bool enciontrado;
        public FormIngresos()
        {
            ingresoService = new IngresoService(ConfigConnection.ConnectionString);
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarDirectivas_Click(object sender, EventArgs e)
        {
            tabLibroIngresos.SelectedIndex = 1;
        }

        private void FormIngresos_Load(object sender, EventArgs e)
        {
            if (tabLibroIngresos.TabCount > 0)
            {
                tabLibroIngresos.TabPages.RemoveAt(2);
            }
        }

        private void dataGridIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridIngresos.DataSource != null)
            {
                //if (dataGridIngresos.Columns[e.ColumnIndex].Name == "Borrar")
                //{
                //    id = Convert.ToString(dataGridIngresos.CurrentRow.Cells["IdContacto"].Value.ToString());
                //    telefono = Convert.ToString(dataGridIngresos.CurrentRow.Cells["TelefonoContacto"].Value.ToString());
                //    EliminarContacto(id);
                //    ConsultarYLlenarGridDeContactos();
                //}
                //else
                //{
                //    if (dataGridIngresos.Columns[e.ColumnIndex].Name == "Detallar")
                //    {
                //        telefono = Convert.ToString(dataGridIngresos.CurrentRow.Cells["TelefonoContacto"].Value.ToString());
                //        enviarMensajeAsync(telefono);
                //    }
                //    else
                //    {
                //        if (dataGridIngresos.Columns[e.ColumnIndex].Name == "Editar")
                //        {
                //            id = Convert.ToString(dataGridIngresos.CurrentRow.Cells["Comprobante"].Value.ToString());
                //            FiltroPorId(id);
                //            if (encontrado == true)
                //            {
                //                tabDirectorio.SelectedIndex = 1;
                //            }
                //        }
                //    }
                //}
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
            apunte = new Ingreso();
            apunte.IdNota = id;
            apunte.Titulo = textTitulo.Text;
            apunte.Nota = textNota.Text;
            return apunte;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
