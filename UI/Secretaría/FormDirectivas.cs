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
        string id = "";
        bool encontrado = false;
        public FormDirectivas()
        {
            directivaService = new DirectivaService(ConfigConnection.ConnectionString);
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            ConsultarYLlenarGridDeDirectivas();
            labelVigencia.Text = DateTime.Now.Year.ToString();
        }
        private void ConsultarYLlenarGridDeDirectivas()
        {
            ConsultaDirectivaRespuesta respuesta = new ConsultaDirectivaRespuesta();
            string tipo = comboDirectiva.Text;
            if (tipo == "Directiva" || tipo == "Todos")
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
        private void LimpiarCampos()
        {
            labelVigencia.Text = DateTime.Now.Year.ToString();
            comboFiltroComite.Text = "Labores";
            textNombre.Text = "Nombre";
            comboCargo.Text = "Presidente";
            textObservacion.Text = "Observacion";
        }
        private Directiva MapearDatosDirectiva()
        {
            directiva = new Directiva();
            directiva.IdDirectiva = id;
            directiva.Vigencia = labelVigencia.Text;
            directiva.Comite = comboFiltroComite.Text;
            directiva.Nombre = textNombre.Text;
            directiva.Cargo = comboCargo.Text;
            directiva.Observacion = textObservacion.Text;
            return directiva;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(textNombre.Text!="Nombre" && textObservacion.Text != "Observacion" && textNombre.Text != "" && textObservacion.Text != "")
            {
                Directiva directiva = MapearDatosDirectiva();
                string mensaje = directivaService.Guardar(directiva);
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ConsultarYLlenarGridDeDirectivas();
                LimpiarCampos();
                tabDirectivas.SelectedIndex = 0;
            }
            else
            {
                string mensaje = "No se puede registrar no ha llenado ningun campo";
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private void EliminarServidor(string id)
        {
            string mensaje = directivaService.Eliminar(id);
            MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "Nombre" && textObservacion.Text != "Observacion" && textNombre.Text != "" && textObservacion.Text != "")
            { 
                Directiva directiva = MapearDatosDirectiva();
                string mensaje = directivaService.Modificar(directiva);
                MessageBox.Show(mensaje, "Mensaje de campos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                comboDirectiva.Text = "Directiva";
                ConsultarYLlenarGridDeDirectivas();
                LimpiarCampos();
                tabDirectivas.SelectedIndex = 0;
            }
            else
            {
                string mensaje = "No se puede Modifica los campos no estan completos";
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
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
            if (textSerachLibreta.Text == "")
            {
                textSerachLibreta.Text = "Buscar por miembro";
            }
        }

        private void textSerachLibreta_Enter(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text != "Buscar por nombre")
            {
                textSerachLibreta.Text = "";
            }
        }

        private void textSerachLibreta_Leave(object sender, EventArgs e)
        {
            if (textSerachLibreta.Text != "")
            {
                textSerachLibreta.Text = "Buscar por nombre";
            }
        }
        private void FiltroPorId(string id)
        {
            BusquedaDirectivaRespuesta respuesta = new BusquedaDirectivaRespuesta();
            respuesta = directivaService.BuscarPorIdentificacion(id);
            var registro = respuesta.Directiva;
            if (registro != null)
            {
                encontrado = true;
                var directivas = new List<Directiva> { registro };
                textNombre.Text = directivas[0].Nombre;
                labelVigencia.Text = directivas[0].Vigencia;
                comboDirectiva.Text = directivas[0].Comite;
                comboCargo.Text = directivas[0].Cargo;
                textObservacion.Text = directivas[0].Observacion;
            }
        }

        private void dataGridDirectiva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridDirectiva.DataSource != null)
            {
                if (dataGridDirectiva.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToString(dataGridDirectiva.CurrentRow.Cells["IdDirectiva"].Value.ToString());
                    EliminarServidor(id);
                    ConsultarYLlenarGridDeDirectivas();
                }
                else
                {
                    if (dataGridDirectiva.Columns[e.ColumnIndex].Name == "Editar")
                    {
                        id = Convert.ToString(dataGridDirectiva.CurrentRow.Cells["IdDirectiva"].Value.ToString());
                        FiltroPorId(id);
                        if (encontrado == true)
                        {
                            tabDirectivas.SelectedIndex = 1;
                        }
                    }
                }
            }
        }
        void FiltroPorNombre(string filtro)
        {
            ConsultaDirectivaRespuesta respuesta = new ConsultaDirectivaRespuesta();
            respuesta = directivaService.BuscarPorNombre(filtro);
            var registro = respuesta.Directivas;
            if (registro != null)
            {
                dataGridDirectiva.DataSource = null;
                dataGridDirectiva.DataSource = registro;
                encontrado = true;
            }
        }
        private void textSerachLibreta_TextChanged(object sender, EventArgs e)
        {
            var filtro = textSerachLibreta.Text;
            if (textSerachLibreta.Text != "" && textSerachLibreta.Text != "Buscar por miembro")
            {
                FiltroPorNombre(filtro);
                if (encontrado == false)
                {
                    dataGridDirectiva.CurrentCell = null;
                    foreach (DataGridViewRow fila in dataGridDirectiva.Rows)
                    {
                        fila.Visible = false;
                    };
                    foreach (DataGridViewRow fila in dataGridDirectiva.Rows)
                    {
                        int i = 0;
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            if (i == 4)
                            {
                                if ((celda.Value.ToString().ToUpper()).IndexOf(textSerachLibreta.Text.ToUpper()) == 0)
                                {
                                    fila.Visible = true;
                                    break;
                                }
                                else
                                {
                                    if ((celda.Value.ToString() == (textSerachLibreta.Text.ToUpper())))
                                    {
                                        fila.Visible = true;
                                        break;
                                    }
                                }
                            }
                            i = i + 1;
                        }
                    }
                }
            }
            else
            {
                ConsultarYLlenarGridDeDirectivas();
            }
        }
        private void FiltroPorDirectiva(string filtro)
        {
            ConsultaDirectivaRespuesta respuesta = new ConsultaDirectivaRespuesta();
            respuesta = directivaService.BuscarPorDirectiva(filtro);
            var registro = respuesta.Directivas;
            if (registro != null)
            {
                dataGridDirectiva.DataSource = null;
                dataGridDirectiva.DataSource = registro;
                encontrado = true;
            }
            else
            {
                dataGridDirectiva.DataSource = null;
            }
        }
        private void comboDirectiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDirectiva.Text != "" && comboDirectiva.Text != "Todos" && comboDirectiva.Text != "Directiva")
            {
                if (textSerachLibreta.Text != "" && textSerachLibreta.Text != "Buscar por nombre")
                {
                    dataGridDirectiva.CurrentCell = null;
                    foreach (DataGridViewRow fila in dataGridDirectiva.Rows)
                    {
                        fila.Visible = false;
                    };
                    foreach (DataGridViewRow fila in dataGridDirectiva.Rows)
                    {
                        int i = 0;
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            if (i == 6)
                            {
                                if ((celda.Value.ToString().ToUpper()).IndexOf(comboDirectiva.Text.ToUpper()) == 0)
                                {
                                    fila.Visible = true;
                                    break;
                                }
                                else
                                {
                                    if ((celda.Value.ToString() == (comboDirectiva.Text.ToUpper())))
                                    {
                                        fila.Visible = true;
                                        break;
                                    }
                                }
                            }
                            i = i + 1;
                        }
                    }
                }
            }
            else
            {
                ConsultarYLlenarGridDeDirectivas();
            }
        }
    }
}
