using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace UI
{
    public partial class InicioResumen : Form
    {
        
        public InicioResumen()
        {
            InitializeComponent();
        }

        private void InicioResumen_Load(object sender, EventArgs e)
        {
            Tiempo.Interval = 1000; // Intervalo de 1 segundo
            Tiempo.Start();
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
