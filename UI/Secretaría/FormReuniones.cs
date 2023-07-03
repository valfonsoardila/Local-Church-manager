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
    public partial class FormReuniones : Form
    {
        public FormReuniones()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarReuniones_Click(object sender, EventArgs e)
        {
            tabReuniones.SelectedIndex = 1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            tabReuniones.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabReuniones.SelectedIndex = 0;
        }
        private void textSerachLibreta_Enter(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text == "Buscar")
            {
                textSerachLibreta.Text = "";
            }
        }

        private void textSerachLibreta_Leave(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text == "")
            {
                textSerachLibreta.Text = "Buscar";
            }
        }

        private void textSearchRegistrar_Enter(object sender, EventArgs e)
        {
            if (textSearchRegistrar.Text == "Buscar")
            {
                textSearchRegistrar.Text = "";
            }
        }

        private void textSearchRegistrar_Leave(object sender, EventArgs e)
        {
            if (textSearchRegistrar.Text == "")
            {
                textSearchRegistrar.Text = "Buscar";
            }
        }
        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = false;
            textSerachLibreta.Visible = true;
            btnCloseSearchLibreta.Visible = true;
        }

        private void btnCloseSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = true;
            textSerachLibreta.Visible = false;
            btnCloseSearchLibreta.Visible = false;
        }

        private void btnSearchRegistrar_Click(object sender, EventArgs e)
        {
            btnSearchRegistrar.Visible = false;
            textSearchRegistrar.Visible = true;
            btnCloseSearchRegistrar.Visible = true;
        }

        private void btnCloseSearchRegistrar_Click(object sender, EventArgs e)
        {
            btnSearchRegistrar.Visible = true;
            textSearchRegistrar.Visible = false;
            btnCloseSearchRegistrar.Visible = false;
        }

        private void textActa_Enter(object sender, EventArgs e)
        {
            if (textActa.Text == "Texto")
            {
                textActa.Text = "";
            }
        }

        private void textActa_Leave(object sender, EventArgs e)
        {
            if (textActa.Text == "")
            {
                textActa.Text = "Texto";
            }
        }

        private void textLugarReunion_Enter(object sender, EventArgs e)
        {
            if (textLugarReunion.Text == "Lugar")
            {
                textLugarReunion.Text = "";
            }
        }

        private void textLugarReunion_Leave(object sender, EventArgs e)
        {
            if (textLugarReunion.Text == "")
            {
                textLugarReunion.Text = "Lugar";
            }
        }

        private void textOrdenDja_Enter(object sender, EventArgs e)
        {
            if (textOrdenDja.Text == "Texto")
            {
                textOrdenDja.Text = "";
            }
        }

        private void textOrdenDja_Leave(object sender, EventArgs e)
        {
            if (textLugarReunion.Text == "")
            {
                textLugarReunion.Text = "Texto";
            }
        }
    }
}
