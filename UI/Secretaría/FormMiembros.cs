using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace UI
{
    public partial class FormMiembros : Form
    {
        RutasTxtService rutasTxtService = new RutasTxtService();
        MiembroService miembroService;
        List<Miembro> miembros;
        Miembro miembro;
        public FormMiembros()
        {
            miembroService = new MiembroService(ConfigConnection.ConnectionString);
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            ConsultarYLlenarGridDeMiembros();
        }
        private void ConsultarYLlenarGridDeMiembros()
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            string tipo = comboGenero.Text;
            if (tipo == "Genero")
            {
                textTotal.Enabled = true;
                textTotalHombres.Enabled = true;
                textTotalMujeres.Enabled = true;
                dataGridMiembros.DataSource = null;
                respuesta = miembroService.ConsultarTodos();
                miembros = respuesta.Miembros.ToList();
                if (respuesta.Miembros.Count != 0 && respuesta.Miembros != null)
                {
                    dataGridMiembros.DataSource = respuesta.Miembros;
                    Borrar.Visible = true;
                    textTotal.Text = miembroService.Totalizar().Cuenta.ToString();
                    textTotalHombres.Text = miembroService.TotalizarTipo("Hombre").Cuenta.ToString();
                    textTotalMujeres.Text = miembroService.TotalizarTipo("Mujer").Cuenta.ToString();
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarMiembros_Click(object sender, EventArgs e)
        {
            tabMiembros.SelectedIndex = 1;
        }

        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = false;
            btnCloseSearchLibreta.Visible = true;
            textSerachLibreta.Visible = true;
        }

        private void btnCloseSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = true;
            btnCloseSearchLibreta.Visible = false;
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
            btnSearchRegistrar.Visible = true;
            btnCloseSearchRegistrar.Visible = false;
            textSearchRegistrar.Visible = false;
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

        private void comboTipoDocumento_Enter(object sender, EventArgs e)
        {
            if (comboTipoDocumento.Text == "CC")
            {
                comboTipoDocumento.Text = "";
            }
        }

        private void comboTipoDocumento_Leave(object sender, EventArgs e)
        {
            if (comboTipoDocumento.Text == "")
            {
                comboTipoDocumento.Text = "CC";
            }
        }

        private void textNumeroDeIdentificacion_Enter(object sender, EventArgs e)
        {
            if(textNumeroDeIdentificacion.Text== "# de documento")
            {
                textNumeroDeIdentificacion.Text = "";
            }
        }

        private void textNumeroDeIdentificacion_Leave(object sender, EventArgs e)
        {
            if (textNumeroDeIdentificacion.Text == "")
            {
                textNumeroDeIdentificacion.Text = "# de documento";
            }
        }

        private void textDireccion_Enter(object sender, EventArgs e)
        {
            if (textDireccion.Text == "Direccion")
            {
                textDireccion.Text = "";
            }
        }

        private void textDireccion_Leave(object sender, EventArgs e)
        {
            if (textDireccion.Text == "")
            {
                textDireccion.Text = "Direccion";
            }
        }

        private void textTelefono_Enter(object sender, EventArgs e)
        {
            if (textTelefono.Text == "Telefono")
            {
                textTelefono.Text = "";
            }
        }

        private void textTelefono_Leave(object sender, EventArgs e)
        {
            if (textTelefono.Text == "")
            {
                textTelefono.Text = "Telefono";
            }
        }

        private void textNombrePadre_Enter(object sender, EventArgs e)
        {
            if (textNombrePadre.Text == "Nombre del padre")
            {
                textNombrePadre.Text = "";
            }
        }

        private void textNombrePadre_Leave(object sender, EventArgs e)
        {
            if (textNombrePadre.Text == "")
            {
                textNombrePadre.Text = "Nombre del padre";
            }
        }

        private void textNombreMadre_Enter(object sender, EventArgs e)
        {
            if (textNombreMadre.Text == "Nombre de la madre")
            {
                textNombreMadre.Text = "";
            }
        }

        private void textNombreMadre_Leave(object sender, EventArgs e)
        {
            if (textNombreMadre.Text == "")
            {
                textNombreMadre.Text = "Nombre de la madre";
            }
        }

        private void textLugarRecepcionPromesa_Enter(object sender, EventArgs e)
        {
            if(textLugarRecepcionPromesa.Text== "Lugar de recepción")
            {
                textLugarRecepcionPromesa.Text = "";
            }
        }

        private void textLugarRecepcionPromesa_Leave(object sender, EventArgs e)
        {
            if (textLugarRecepcionPromesa.Text == "")
            {
                textLugarRecepcionPromesa.Text = "Lugar de recepción";
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

        private void comboPastorOficiante_Enter(object sender, EventArgs e)
        {
            if(comboPastorOficiante.Text=="Emiro Diaz")
            {
                comboPastorOficiante.Text = "";
            }
        }

        private void comboPastorOficiante_Leave(object sender, EventArgs e)
        {
            if (comboPastorOficiante.Text == "")
            {
                comboPastorOficiante.Text = "Emiro Diaz";
            }
        }

        private void comboActoServicio_Enter(object sender, EventArgs e)
        {
            if (comboActoServicio.Text == "Si")
            {
                comboActoServicio.Text = "";
            }
        }

        private void comboActoServicio_Leave(object sender, EventArgs e)
        {
            if (comboActoServicio.Text == "")
            {
                comboActoServicio.Text = "Si";
            }
        }
        private void comboEstadoMiembro_Leave(object sender, EventArgs e)
        {
            if (comboEstadoMiembro.Text == "")
            {
                comboEstadoMiembro.Text = "No definido";
            }
        }

        private void comboEstadoMiembro_TextChanged(object sender, EventArgs e)
        {
            if (comboEstadoMiembro.Text != "")
            {
                if(comboEstadoMiembro.Text != "No definido")
                {
                    textLugar.Enabled = true;
                }
                else
                {
                    textLugar.Enabled = false;
                }
            }
        }

        private void textLugar_Enter(object sender, EventArgs e)
        {
            if (textLugar.Text == "Lugar")
            {
                textLugar.Text = "";
            }
        }

        private void textLugar_Leave(object sender, EventArgs e)
        {
            if (textLugar.Text == "")
            {
                textLugar.Text = "Lugar";
            }
        }
        private Miembro MapearDatosMiembro()
        {
            miembro = new Miembro();
            miembro.Folio = comboFolio.Text;
            miembro.Nombre = textNombre.Text;
            miembro.TipoDoc = comboTipoDocumento.Text;
            miembro.NumeroDoc = textNumeroDeIdentificacion.Text;
            miembro.FechaNacimiento = dateFechaDeNacimiento.Value;
            miembro.Direccion = textDireccion.Text;
            miembro.Telefono = textTelefono.Text;
            using (MemoryStream ms = new MemoryStream())
            {
                picturePerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                miembro.ImagenPerfil = ms.ToArray();
            }
            miembro.ParentezcoPadre = textNombrePadre.Text;
            miembro.ParentezcoMadre = textNombreMadre.Text;
            miembro.FechaBautizmo = dateFechaDeBautismo.Value;
            miembro.TiempoDeConversion = Convert.ToInt32(textTiempoDeConversion.Text);
            miembro.FechaRecepcionEspirituSanto = dateFechaEspirituSanto.Value;
            miembro.LugarRecepcionespirituSanto = textLugarRecepcionPromesa.Text;
            miembro.PastorOficiante = comboPastorOficiante.Text;
            miembro.FechaMembresiaIglesiaProcedente = dateFechaMembresia.Value;
            miembro.TiempoDeConversion = Convert.ToInt32(textTiempoDeConversion.Text);
            miembro.EstadoServicio = comboEstadoMiembro.Text;
            miembro.FechaDeCorreccion = dateFechaDisciplina.Value;
            miembro.TiempoEnActoCorrectivo = Convert.ToInt32(textTiempoDisciplina.Text);
            miembro.LugarRecepcionespirituSanto = textLugarRecepcionPromesa.Text;
            miembro.EstadoMembresia = comboEstadoMiembro.Text;
            miembro.LugarDeTraslado = textLugar.Text;
            return miembro;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Miembro miembro = MapearDatosMiembro();
            string mensaje = miembroService.Guardar(miembro);
            MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            ConsultarYLlenarGridDeMiembros();
            tabMiembros.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tabMiembros.SelectedIndex = 0;
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            
        }
    }
}
