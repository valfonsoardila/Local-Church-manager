using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormDirectivas : Form
    {

        RutasTxtService rutasTxtService = new RutasTxtService();
        DirectivaService directivaService;
        List<Directiva> directivas;
        Directiva directiva;
        public FormDirectivas()
        {
            directivaService = new DirectivaService(ConfigConnection.ConnectionString);
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            ConsultarYLlenarGridDeDirectivas();
        }
        private void ConsultarYLlenarGridDeDirectivas()
        {
            ConsultaDirectivaRespuesta respuesta = new ConsultaDirectivaRespuesta();
            string tipo = comboDirectiva.Text;
            if (tipo == "Directiva")
            {
                textTotal.Enabled = true;
                textTotalHombres.Enabled = true;
                textTotalMujeres.Enabled = true;
                dataGridDirectiva.DataSource = null;
                respuesta = directivaService.ConsultarTodos();
                directivas = respuesta.Directivas.ToList();
                if (respuesta.Directivas.Count != 0 && respuesta.Directivas != null)
                {
                    dataGridDirectiva.DataSource = respuesta.Directivas;
                    Borrar.Visible = true;
                    textTotal.Text = directivaService.Totalizar().Cuenta.ToString();
                    textTotalHombres.Text = directivaService.TotalizarTipo("Hombre").Cuenta.ToString();
                    textTotalMujeres.Text = directivaService.TotalizarTipo("Mujer").Cuenta.ToString();
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarDirectivas_Click(object sender, EventArgs e)
        {
            tabDirectivas.SelectedIndex = 1;
        }
        private Directiva MapearDatosDirectiva()
        {
            directiva = new Directiva();
            directiva.Vigencia = labelVigencia.Text;
            directiva.Comite = comboFiltroComite.Text;
            directiva.Nombre = textNombre.Text;
            directiva.Cargo = comboCargo.Text;
            directiva.Observacion = textObservacion.Text;
            return directiva;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Directiva directiva = MapearDatosDirectiva();
            string mensaje = directivaService.Guardar(directiva);
            MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            ConsultarYLlenarGridDeDirectivas();
            tabDirectivas.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabDirectivas.SelectedIndex = 0;
        }

        private void textNombre_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "Nombre")
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

        private void textObservacion_Enter(object sender, EventArgs e)
        {
            if (textObservacion.Text == "Observacion")
            {
                textObservacion.Text = "";
            }
        }

        private void textObservacion_Leave(object sender, EventArgs e)
        {
            if (textObservacion.Text == "")
            {
                textObservacion.Text = "Observacion";
            }
        }
    }
}
