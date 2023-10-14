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
using UI.Properties;
using BLL;
using Entity;

namespace UI
{
    public partial class FormMiembros : Form
    {
        public readonly Validaciones validaciones;
        RutasTxtService rutasTxtService = new RutasTxtService();
        MiembroService miembroService;
        List<Miembro> miembros;
        Miembro miembro;
        ContactoService contactoService;
        List<Contacto> contactos;
        Contacto contacto;
        string id = "";
        string idContacto = "";
        string numeroWhatsapp = "";
        string folio = "";
        string nombres = "";
        string apellidos = "";
        byte[] imagenPicture = null;
        byte[] imagenPerfil = null;
        bool encontrado = false;
        bool encontradoNombre = false;
        bool encontradoApellido = false;
        public FormMiembros()
        {
            contactoService = new ContactoService(ConfigConnection.ConnectionString);
            miembroService = new MiembroService(ConfigConnection.ConnectionString);
            InitializeComponent();
            Inicializar();
            validaciones = new Validaciones();
        }
        private void Inicializar()
        {
            CalcularFolio();
            ConsultarYLlenarGridDeMiembros();
        }
        private Image ResizeImageToFitCell(DataGridViewImageCell cell, Image originalImage)
        {
            int cellWidth = cell.Size.Width - cell.Style.Padding.Horizontal;
            int cellHeight = cell.Size.Height - cell.Style.Padding.Vertical;

            float widthRatio = (float)cellWidth / originalImage.Width;
            float heightRatio = (float)cellHeight / originalImage.Height;
            float minRatio = Math.Min(widthRatio, heightRatio);

            int newWidth = (int)(originalImage.Width * minRatio);
            int newHeight = (int)(originalImage.Height * minRatio);

            return new Bitmap(originalImage, new Size(newWidth, newHeight));
        }
        private void ConsultarYLlenarGridDeMiembros()
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            string tipo = comboGenero.Text;
            if (tipo == "Genero" || tipo == "Todos")
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
                    textTotalHombres.Text = miembroService.TotalizarTipo("Masculino").Cuenta.ToString();
                    textTotalMujeres.Text = miembroService.TotalizarTipo("Femenino").Cuenta.ToString();
                    foreach (DataGridViewRow row in dataGridMiembros.Rows)
                    {
                        DataGridViewImageCell cell = row.Cells["ImagenPerfil"] as DataGridViewImageCell;
                        if (cell != null)
                        {
                            byte[] imageBytes = cell.Value as byte[];
                            if (imageBytes != null)
                            {
                                // Convierte los bytes en una imagen
                                Image originalImage;
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    originalImage = Image.FromStream(ms);
                                }

                                // Redimensiona la imagen para que quepa en la celda
                                Image resizedImage = ResizeImageToFitCell(cell, originalImage);

                                // Asigna la imagen redimensionada a la celda
                                cell.Value = resizedImage;
                            }
                        }
                    }
                }
            }
        }
        void LimpiarCampos()
        {
            textNombre.Text="Nombre";
            comboTipoDocumento.Text="CC";
            textNumeroDeIdentificacion.Text="# de documento";
            dateFechaDeNacimiento.Value=DateTime.Now;
            textDireccion.Text="Direccion";
            textTelefono.Text="Telefono";
            using (MemoryStream ms = new MemoryStream())
            {
                picturePerfil.Image = Properties.Resources.User;
            }
            textNombrePadre.Text="Nombre del padre";
            textNombreMadre.Text = "Nombre de la madre";
            dateFechaDeBautismo.Value = DateTime.Now;
            textTiempoDeConversion.Text="0";
            dateFechaEspirituSanto.Value = DateTime.Now;
            textLugarRecepcionPromesa.Text="Lugar de recepción";
            comboPastorOficiante.Text="Emiro Diaz";
            dateFechaMembresia.Value = DateTime.Now;
            textTiempoDeConversion.Text="0";
            comboEstadoMiembro.Text="Si";
            dateFechaDisciplina.Value = DateTime.Now;
            textTiempoDisciplina.Text="0";
            comboEstadoMiembro.Text="No definido";
            textLugar.Text="Lugar";
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarMiembros_Click(object sender, EventArgs e)
        {
            tabMiembros.SelectedIndex = 1;
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
        private void CalcularFolio()
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            respuesta = miembroService.ConsultarTodos();
            miembros = respuesta.Miembros.ToList();
            if (respuesta.Miembros.Count != 0 && respuesta.Miembros != null)
            {
                textTotal.Text = miembroService.Totalizar().Cuenta.ToString();
                var totalFolio = Convert.ToInt32(textTotal.Text);
                folio = (totalFolio + 1).ToString("0000");
                labelNumeroFolio.Text = folio;
            }
            else
            {
                var totalFolio = 1;
                folio = totalFolio.ToString("0000");
                labelNumeroFolio.Text = folio;
            }
        }
        private void ExtraerNombreYApellido()
        {
            var nombreCompleto = textNombre.Text;
            // Dividir el nombre completo en palabras usando espacio como separador
            string[] palabras = nombreCompleto.Split(' ');
            if (palabras.Length >= 4)
            {
                // Los dos primeros elementos son los nombres, los dos últimos son los apellidos
                nombres = palabras[0] + " " + palabras[1];
                apellidos = palabras[2] + " " + palabras[3];

                // Ahora tienes los nombres y apellidos en las variables 'nombres' y 'apellidos'
                // Puedes usar estas variables como desees
            }
            else
            {
                string mensaje = "Nombre mal digitado, por favor digite su nombre completo";
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private void GenerarIdContacto()
        {
            contacto = new Contacto();
            contacto.GenerarId();
            idContacto = contacto.IdContacto;
        }
        void FiltroPorIdentificacion(string filtro)
        {
            BusquedaMiembroRespuesta respuesta = new BusquedaMiembroRespuesta();
            respuesta = miembroService.BuscarPorIdentificacion(filtro);
            var registro = respuesta.Miembro;
            if (registro != null)
            {
                encontrado = true;
                idContacto = registro.IdContacto;
                labelNumeroFolio.Text = registro.Folio;
                textNombre.Text = registro.Nombre + " " + registro.Apellido;
                comboTipoDocumento.Text = registro.TipoDoc;
                textNumeroDeIdentificacion.Text = registro.NumeroDoc;
                dateFechaDeNacimiento.Value = registro.FechaNacimiento;
                textDireccion.Text = registro.Direccion;
                textTelefono.Text =registro.Telefono;
                imagenPerfil = registro.ImagenPerfil;
                using (MemoryStream ss = new MemoryStream(registro.ImagenPerfil))
                {
                    // Carga la imagen desde el MemoryStream
                    Image imagen = Image.FromStream(ss);
                    // Asigna la imagen al control PictureBox
                    picturePerfil.Image = imagen;
                    imagenPicture = ss.ToArray();
                }
                textNombrePadre.Text = registro.ParentezcoPadre;
                textNombreMadre.Text = registro.ParentezcoMadre;
                dateFechaDeBautismo.Value = registro.FechaNacimiento;
                textTiempoDeConversion.Text = registro.TiempoDeConversion.ToString();
                dateFechaEspirituSanto.Value = registro.FechaRecepcionEspirituSanto;
                textLugarRecepcionPromesa.Text = registro.LugarRecepcionespirituSanto;
                comboPastorOficiante.Text = registro.PastorOficiante;
                dateFechaMembresia.Value = registro.FechaMembresiaIglesiaProcedente;
                textTiempoMembresia.Text = registro.TiempoDeMembresiaIglesiaProcedente.ToString();
                comboEstadoMiembro.Text = registro.EstadoMembresia;
                dateFechaDisciplina.Value = registro.FechaDeCorreccion;
                textTiempoDisciplina.Text = registro.TiempoEnActoCorrectivo.ToString();
                comboEstadoMiembro.Text = registro.EstadoMembresia;
                textLugar.Text = registro.LugarDeTraslado;
            }
        }
        void FiltroPorApellido(string filtro)
        {
            BusquedaContactoRespuesta respuesta = new BusquedaContactoRespuesta();
            respuesta = contactoService.BuscarPorApellido(filtro);
            var registro = respuesta.Contacto;
            if (registro != null)
            {
                encontradoNombre = true;
            }
        }
        void FiltroPorNombre(string filtro)
        {
            BusquedaContactoRespuesta respuesta = new BusquedaContactoRespuesta();
            respuesta = contactoService.BuscarPorNombre(filtro);
            var registro = respuesta.Contacto;
            if (registro != null)
            {
                encontradoApellido = true;
            }
        }
        private Contacto MapearDatosContacto()
        {
            contacto = new Contacto();
            contacto.IdContacto = idContacto;
            contacto.Nombre = nombres;
            contacto.Apellido = apellidos;
            contacto.TelefonoContacto = textTelefono.Text;
            contacto.TelefonoWhatsapp = numeroWhatsapp;
            contacto.Oficio = comboOficio.Text;
            return contacto;
        }
        private Miembro MapearDatosMiembro()
        {
            miembro = new Miembro();
            miembro.IdContacto = idContacto;
            miembro.Folio = labelNumeroFolio.Text;
            miembro.Nombre = nombres;
            miembro.Apellido = apellidos;
            miembro.TipoDoc = comboTipoDocumento.Text;
            miembro.NumeroDoc = textNumeroDeIdentificacion.Text;
            miembro.FechaNacimiento = dateFechaDeNacimiento.Value;
            miembro.Genero = comboGeneroRegistrar.Text;
            miembro.Direccion = textDireccion.Text;
            miembro.Telefono = textTelefono.Text;
            if (imagenPerfil != null)
            {
                if (imagenPicture.Length != imagenPerfil.Length)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picturePerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        miembro.ImagenPerfil = ms.ToArray();
                    }
                }
                else
                {
                    miembro.ImagenPerfil = imagenPicture;
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picturePerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    miembro.ImagenPerfil = ms.ToArray();
                }
            }
            miembro.ParentezcoPadre = textNombrePadre.Text;
            miembro.ParentezcoMadre = textNombreMadre.Text;
            miembro.FechaBautizmo = dateFechaDeBautismo.Value;
            miembro.FechaRecepcionEspirituSanto = dateFechaEspirituSanto.Value;
            miembro.LugarRecepcionespirituSanto = textLugarRecepcionPromesa.Text;
            miembro.PastorOficiante = comboPastorOficiante.Text;
            miembro.FechaMembresiaIglesiaProcedente = dateFechaMembresia.Value;
            miembro.EstadoServicio = comboEstadoMiembro.Text;
            miembro.FechaDeCorreccion = dateFechaDisciplina.Value;
            miembro.EstadoMembresia = comboEstadoMiembro.Text;
            miembro.LugarDeTraslado = textLugar.Text;
            return miembro;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ExtraerNombreYApellido();
            GenerarIdContacto();
            Contacto contacto = MapearDatosContacto();
            Miembro miembro = MapearDatosMiembro();
            FiltroPorNombre(nombres);
            FiltroPorApellido(apellidos);
            if(encontradoNombre!=true && encontradoApellido != true)
            {
                contactoService.Guardar(contacto);
                string mensaje = miembroService.Guardar(miembro);
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ConsultarYLlenarGridDeMiembros();
                LimpiarCampos();
                tabMiembros.SelectedIndex = 0;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ExtraerNombreYApellido();
            Contacto contacto = MapearDatosContacto();
            Miembro miembro = MapearDatosMiembro();
            FiltroPorNombre(nombres);
            FiltroPorApellido(apellidos);
            if (encontradoNombre == true && encontradoApellido == true)
            {
                string mensaje = miembroService.Modificar(miembro);
                contactoService.Modificar(contacto);
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ConsultarYLlenarGridDeMiembros();
                LimpiarCampos();
                tabMiembros.SelectedIndex = 0;
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ventanaCargar = new OpenFileDialog();
            DialogResult dr = ventanaCargar.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (validaciones.ValidarImagen(ventanaCargar.FileName) == true)
                {
                    // La imagen cargada en picturePerfil es válida
                    picturePerfil.Image = Image.FromFile(ventanaCargar.FileName);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picturePerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Puedes cambiar el formato según sea necesario
                        imagenPicture = ms.ToArray();
                    }
                }
                else
                {
                    string mensaje = "Formato de imagen incorrecta";
                    MessageBox.Show(mensaje, "Error de carga de imagen", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }

        }
        void CalculosPorFecha()
        {
            miembro = new Miembro();
            miembro.FechaBautizmo = dateFechaDeBautismo.Value;
            miembro.CalcularTiempoDeConversion();
            textTiempoDeConversion.Text = miembro.TiempoDeConversion.ToString();

            miembro.FechaMembresiaIglesiaProcedente = dateFechaMembresia.Value;
            miembro.CalcularMembresiaIglesiaProcedente();
            textTiempoMembresia.Text = miembro.TiempoDeMembresiaIglesiaProcedente.ToString();

            miembro.FechaDeCorreccion = dateFechaDisciplina.Value;
            miembro.CalcularTiempoDeCorrecion();
            textTiempoDisciplina.Text = miembro.TiempoEnActoCorrectivo.ToString();
        }
        private void dateFechaDeBautismo_ValueChanged(object sender, EventArgs e)
        {
            CalculosPorFecha();
        }

        private void dateFechaMembresia_ValueChanged(object sender, EventArgs e)
        {
            CalculosPorFecha();
        }
        private void dateFechaDisciplina_ValueChanged(object sender, EventArgs e)
        {
            CalculosPorFecha();
        }

        private void textTelefono_TextChanged(object sender, EventArgs e)
        {
            if (textTelefono.Text != "")
            {
                numeroWhatsapp = "+57" + textTelefono.Text;
            }
        }
        void EliminarMiembro(string id)
        {
            string mensaje = miembroService.Eliminar(id);
            contactoService.Eliminar(idContacto);
            MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridMiembros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridMiembros.DataSource != null)
            {
                if (dataGridMiembros.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToString(dataGridMiembros.CurrentRow.Cells["Folio"].Value.ToString());
                    EliminarMiembro(id);
                    ConsultarYLlenarGridDeMiembros();
                }
                else
                {
                    if (dataGridMiembros.Columns[e.ColumnIndex].Name == "Editar")
                    {
                        id = Convert.ToString(dataGridMiembros.CurrentRow.Cells["Folio"].Value.ToString());
                        FiltroPorIdentificacion(id);
                        if (encontrado == true)
                        {
                            tabMiembros.SelectedIndex = 1;
                        }
                    }
                }
            }
        }
        void FiltroPorgenero(string filtro)
        {
            BusquedaMiembroRespuesta respuesta = new BusquedaMiembroRespuesta();
            respuesta = miembroService.BuscarPorGenero(filtro);
            var registro = respuesta.Miembro;
            if (registro != null)
            {
                //dataGridMiembros.DataSource = null;
                var miembros = new List<Miembro> { registro };
                dataGridMiembros.DataSource = miembros;
                foreach (DataGridViewRow row in dataGridMiembros.Rows)
                    {
                        DataGridViewImageCell cell = row.Cells["ImagenPerfil"] as DataGridViewImageCell;
                        if (cell != null)
                        {
                            byte[] imageBytes = cell.Value as byte[];
                            if (imageBytes != null)
                            {
                                // Convierte los bytes en una imagen
                                Image originalImage;
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    originalImage = Image.FromStream(ms);
                                }

                                // Redimensiona la imagen para que quepa en la celda
                                Image resizedImage = ResizeImageToFitCell(cell, originalImage);

                                // Asigna la imagen redimensionada a la celda
                                cell.Value = resizedImage;
                            }
                        }
                    }
            }
            else
            {
                dataGridMiembros.DataSource = null;
            }
        }

        private void comboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtro = comboGenero.Text;
            if (comboGenero.Text != "" && comboGenero.Text != "Todos")
            {
                FiltroPorgenero(filtro);
            }
            else
            {
                ConsultarYLlenarGridDeMiembros();
            }
        }

        private void FiltroPorFamilia(string apellidos)
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            respuesta = miembroService.BuscarPorFamilia(apellidos);
            miembros = respuesta.Miembros.ToList();
            if (respuesta.Miembros.Count != 0 && respuesta.Miembros != null)
            {
                dataGridMiembros.DataSource = respuesta.Miembros;
            }
        }

        private void btSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = false;
            btnCloseSearchLibreta.Visible = true;
            textSearch.Visible = true;
        }

        private void btnCloseSearchLibreta_Click(object sender, EventArgs e)
        {
            btSearchLibreta.Visible = true;
            btnCloseSearchLibreta.Visible = false;
            textSearch.Visible = false;
            if (textSearch.Text != "Buscar")
            {
                textSearch.Text = "Buscar";
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            var filtro = textSearch.Text;
            if (textSearch.Text != "" && textSearch.Text != "Buscar")
            {
                FiltroPorFamilia(filtro);
                if (encontrado == false)
                {
                    dataGridMiembros.CurrentCell = null;
                    foreach (DataGridViewRow fila in dataGridMiembros.Rows)
                    {
                        fila.Visible = false;
                    };
                    foreach (DataGridViewRow fila in dataGridMiembros.Rows)
                    {
                        int i = 0;
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            if (i == 7)
                            {
                                if ((celda.Value.ToString().ToUpper()).IndexOf(textSearch.Text.ToUpper()) == 0)
                                {
                                    fila.Visible = true;
                                    break;
                                }
                                else
                                {
                                    if ((celda.Value.ToString() == (textSearch.Text.ToUpper())))
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
                ConsultarYLlenarGridDeMiembros();
            }
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textSearch.Text == "Buscar")
            {
                textSearch.Text = "";
            }
        }

        private void textSearch_Leave(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                textSearch.Text = "Buscar";
            }
        }

        private void btnImprimirLista_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "ReporteMiembros.docx"; // Reemplaza con el nombre real del archivo
            string rutaDelArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UI\\Doc's", nombreArchivo);
            // Llama al método EditarDocumento
            Imprimir imprimir = new Imprimir();
            imprimir.EditarDocumentoMiembros(rutaDelArchivo);
        }
    }
}
