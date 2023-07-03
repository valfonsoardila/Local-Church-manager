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
    public partial class FormDirectivas : Form
    {
        public FormDirectivas()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarContactos_Click(object sender, EventArgs e)
        {
            tabDirectivas.SelectedIndex = 1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            tabDirectivas.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabDirectivas.SelectedIndex = 0;
        }
    }
}
