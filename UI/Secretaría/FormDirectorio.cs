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
    public partial class FormDirectorio : Form
    {
        public FormDirectorio()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = false;
            btnCloseSearchLibreta.Visible = true;
            textSerachLibreta.Visible = true;
        }

        private void btnCloseSearchLibreta_Click(object sender, EventArgs e)
        {
            btnCloseSearchLibreta.Visible = false;
            btSearchLibreta.Visible = true;
            textSerachLibreta.Visible = false;
        }

        private void btnSearchRegistrar_Click(object sender, EventArgs e)
        {
            btnSearchRegistrar.Visible = false;
            btnCloseSearchRegistrar.Visible = true;
            textSearchRegistrar.Visible = true;
        }

        private void btnCloseSearchRegistrar_Click(object sender, EventArgs e)
        {
            btnCloseSearchRegistrar.Visible = false;
            btnSearchRegistrar.Visible = true;
            textSearchRegistrar.Visible = false;
        }

        private void textNombre_Enter(object sender, EventArgs e)
        {
            if(textNombre.Text == "Nombre")
            {
                textNombre.Text = "";
            }
        }

        private void textNombre_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                textNombre.Text = "Nombre";
            }
        }

        private void textApellido_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "Apellido")
            {
                textNombre.Text = "";
            }
        }

        private void textApellido_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                textNombre.Text = "Apellido";
            }
        }

        private void textCelular_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "Celular")
            {
                textNombre.Text = "";
            }
        }

        private void textCelular_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                textNombre.Text = "Celular";
            }
        }

        private void textNumeroWhatsapp_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "Numero de whatsapp")
            {
                textNombre.Text = "";
            }
        }

        private void textNumeroWhatsapp_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                textNombre.Text = "Numero de whatsapp";
            }
        }

        private void comboOficio_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "Oficio")
            {
                textNombre.Text = "";
            }
        }

        private void comboOficio_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                textNombre.Text = "Oficio";
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

        private void btnGestionarContactos_Click(object sender, EventArgs e)
        {
            tabDirectorio.SelectedIndex = 1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            tabDirectorio.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabDirectorio.SelectedIndex = 0;
        }
    }
}
