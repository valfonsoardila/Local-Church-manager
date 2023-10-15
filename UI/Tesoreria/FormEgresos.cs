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
        string originalText;
        public FormEgresos()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
