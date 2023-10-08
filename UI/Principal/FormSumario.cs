using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using BLL;
using Entity;

namespace UI
{
    public partial class InicioResumen : Form
    {
        ContactoService contactoService;
        List<Contacto> contactos;
        Contacto contacto;
        MiembroService miembroService;
        List<Miembro> miembros;
        Miembro miembro;
        public InicioResumen()
        {
            contactoService = new ContactoService(ConfigConnection.ConnectionString);
            miembroService = new MiembroService(ConfigConnection.ConnectionString);
            InitializeComponent();
            Inicializar();
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
        void Inicializar()
        {
            ConsultarContactos();
            ConsultarMiembros();
        }
        void ConsultarContactos()
        {
            ConsultaContactoRespuesta respuesta = new ConsultaContactoRespuesta();
            respuesta = contactoService.ConsultarTodos();
            contactos = respuesta.Contactos.ToList();
            if (respuesta.Contactos.Count != 0 && respuesta.Contactos != null)
            {
                labelDirectorio.Text = contactoService.Totalizar().Cuenta.ToString();
            }
            else
            {
                labelDirectorio.Text = "0";
            }
        }
        private void ConsultarMiembros()
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            respuesta = miembroService.ConsultarTodos();
            miembros = respuesta.Miembros.ToList();
            if (respuesta.Miembros.Count != 0 && respuesta.Miembros != null)
            {
                labelMiembros.Text=miembroService.Totalizar().Cuenta.ToString();
            }
            else
            {
                labelMiembros.Text = "0";
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ConsultarContactos();
            ConsultarMiembros();
        }
    }
}
