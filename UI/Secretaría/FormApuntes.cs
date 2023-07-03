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
    public partial class FormApuntes : Form
    {
        public FormApuntes()
        {
            InitializeComponent();
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible=false;
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
        private void textTitulo_Enter(object sender, EventArgs e)
        {
            if (textTitulo.Text == "Titulo")
            {
                textTitulo.Text = "";
            }
        }

        private void textTitulo_Leave(object sender, EventArgs e)
        {
            if (textTitulo.Text == "")
            {
                textTitulo.Text = "Titulo";
            }
        }

        private void textNota_Enter(object sender, EventArgs e)
        {
            if (textNota.Text == "Redactar")
            {
                textNota.Text = "";
            }
        }

        private void textNota_Leave(object sender, EventArgs e)
        {
            if (textNota.Text == "")
            {
                textNota.Text = "Redactar";
            }
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

        private void btnGestionarContactos_Click(object sender, EventArgs e)
        {
            tabApuntes.SelectedIndex = 1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            tabApuntes.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabApuntes.SelectedIndex = 0;
        }
    }
}
