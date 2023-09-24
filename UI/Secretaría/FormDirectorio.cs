using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace UI
{
    public partial class FormDirectorio : Form
    {
        RutasTxtService rutasTxtService = new RutasTxtService();
        ContactoService contactoService;
        List<Contacto> contactos;
        Contacto contacto;
        public FormDirectorio()
        {
            contactoService = new ContactoService(ConfigConnection.ConnectionString);
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            ConsultarYLlenarGridDeContactos();
        }
        private void ConsultarYLlenarGridDeContactos()
        {
            ConsultaContactoRespuesta respuesta = new ConsultaContactoRespuesta();
            string tipo = comboOficioLibreta.Text;
            if (tipo == "Oficio")
            {
                textTotal.Enabled = true;
                textTotalHombres.Enabled = true;
                textTotalMujeres.Enabled = true;
                dataGridContactos.DataSource = null;
                respuesta = contactoService.ConsultarTodos();
                contactos = respuesta.Contactos.ToList();
                if (respuesta.Contactos.Count != 0 && respuesta.Contactos != null) {
                    dataGridContactos.DataSource = respuesta.Contactos;
                    Borrar.Visible = true;
                    textTotal.Text = contactoService.Totalizar().Cuenta.ToString();
                    textTotalHombres.Text = contactoService.TotalizarTipo("Hombre").Cuenta.ToString();
                    textTotalMujeres.Text = contactoService.TotalizarTipo("Mujer").Cuenta.ToString();
                }
            }
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
            if (textApellido.Text == "Apellido")
            {
                textApellido.Text = "";
            }
        }

        private void textApellido_Leave(object sender, EventArgs e)
        {
            if (textApellido.Text == "")
            {
                textApellido.Text = "Apellido";
            }
        }

        private void textCelular_Enter(object sender, EventArgs e)
        {
            if (textCelular.Text == "Celular")
            {
                textCelular.Text = "";
            }
        }

        private void textCelular_Leave(object sender, EventArgs e)
        {
            if (textCelular.Text == "")
            {
                textCelular.Text = "Celular";
            }
        }

        private void textNumeroWhatsapp_Enter(object sender, EventArgs e)
        {
            if (textNumeroWhatsapp.Text == "Numero de whatsapp")
            {
                textNumeroWhatsapp.Text = "";
            }
        }

        private void textNumeroWhatsapp_Leave(object sender, EventArgs e)
        {
            if (textNumeroWhatsapp.Text == "")
            {
                textNumeroWhatsapp.Text = "Numero de whatsapp";
            }
        }

        private void comboOficio_Enter(object sender, EventArgs e)
        {
            if (comboOficioRegistrar.Text == "Oficio")
            {
                comboOficioRegistrar.Text = "";
            }
        }

        private void comboOficio_Leave(object sender, EventArgs e)
        {
            if (comboOficioRegistrar.Text == "")
            {
                comboOficioRegistrar.Text = "Oficio";
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
        private Contacto MapearDatosContacto()
        {
            contacto = new Contacto();
            contacto.Nombre = textNombre.Text;
            contacto.Apellido = textApellido.Text;
            contacto.TelefonoContacto = textCelular.Text;
            contacto.TelefonoWhatsapp = textNumeroWhatsapp.Text;
            contacto.Oficio = comboOficioRegistrar.Text;
            return contacto;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Contacto contacto = MapearDatosContacto();
            string mensaje = contactoService.Guardar(contacto);
            MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            ConsultarYLlenarGridDeContactos();
            tabDirectorio.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabDirectorio.SelectedIndex = 0;
        }
    }
}
