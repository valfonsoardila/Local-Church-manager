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
        MemberMaps memberMaps;
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
            memberMaps = new MemberMaps();
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
            textNombre.Text = "Nombre";
            comboTipoDocumento.Text = "CC";
            textNumeroDeId.Text = "# de documento";
            dateFechaDeNacimiento.Value = DateTime.Now;
            textDireccion.Text = "Direccion";
            textTelefono.Text = "Telefono";
            using (MemoryStream ms = new MemoryStream())
            {
                picturePerfil.Image = Properties.Resources.User;
            }
            textNombreDelPadre.Text = "Nombre del padre";
            textNombreDeLaMadre.Text = "Nombre de la madre";
            dateFechaDeBautismo.Value = DateTime.Now;
            textTiempoDeConversion.Text = "0";
            dateFechaEspirituSanto.Value = DateTime.Now;
            textLugarBautizmo.Text = "Lugar de recepción";
            comboPastorOficiante.Text = "Emiro Diaz";

            // Campos adicionales
            comboOficio.Text = "Oficio";
            comboEstadoCivil.Text = "Estado Civil";
            textNumeroDeHijos.Text = "0";
            textNombreDelConyugue.Text = "Nombre del cónyuge";
            comboBautizado.Text = "Sí";
            textLugarBautizmo.Text = "Lugar de bautismo";
            comboPastorOficiante.Text = "Nombre del pastor";
            comboSellado.Text = "Sí";
            comboRecuerda.Text = "Recuerdo";
            dateFechaEspirituSanto.Value = DateTime.Now;
            textTiempoDeConversion.Text = "0";
            textTiempoPromesa.Text = "0";
            textIglesiaProcedente.Text = "Iglesia de procedencia";
            comboPastorAsistente.Text = "Nombre del pastor asistente";
            textCargosDesempeñados.Text = "Cargos desempeñados";
            comboActoParaServir.Text = "Acto para servir";
            dateFechaDeCorreccion.Value = DateTime.Now;
            textTiempoCorreccion.Text = "0";
            comboMembresia.Text = "Membresía";
            textLugarTraslado.Text = "Lugar de traslado";
            textObservaciones.Text = "Observaciones";
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarMiembros_Click(object sender, EventArgs e)
        {
            tabMiembros.SelectedIndex = 1;
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
                textNumeroDeId.Text = registro.NumeroDoc;
                dateFechaDeNacimiento.Value = registro.FechaNacimiento;
                miembro.Oficio = comboOficio.Text;
                comboGenero.Text = registro.Genero;
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
                textNombreDelPadre.Text = registro.ParentezcoPadre;
                textNombreDeLaMadre.Text = registro.ParentezcoMadre;
                comboEstadoCivil.Text = registro.EstadoCivil;
                textNumeroDeHijos.Text= registro.NumeroHijos.ToString(); // Agregar número de hijos
                textNombreDelConyugue.Text = registro.NombreConyugue; // Agregar nombre del cónyuge
                comboBautizado.Text = registro.Bautizado; // Agregar campo de bautizado
                dateFechaDeBautismo.Value = registro.FechaDeBautizmo;
                textLugarBautizmo.Text = registro.LugarBautizmo; // Agregar lugar de bautismo
                comboPastorOficiante.Text = registro.PastorOficiante; // Agregar pastor oficiante en el bautismo
                comboSellado.Text= registro.Sellado; // Agregar campo de sellado
                comboRecuerda.Text = registro.SelladoRecuerdo; // Agregar sellado recuerdo
                dateFechaEspirituSanto.Value = registro.FechaPromesa; // Agregar fecha de promesa
                textTiempoDeConversion.Text=registro.TiempoConversion.ToString(); // Agregar tiempo de conversión
                textTiempoPromesa.Text = registro.TiempoPromesa.ToString(); // Agregar tiempo de promesa
                textIglesiaProcedente.Text= registro.IglesiaProcedente; // Agregar iglesia de procedencia
                comboPastorAsistente.Text=registro.PastorAsistente; // Agregar pastor asistente
                textCargosDesempeñados.Text = registro.CargosDesempenados; // Agregar cargos desempeñados
                comboActoParaServir.Text = registro.Acto; // Agregar acto
                dateFechaDeCorreccion.Value = registro.FechaCorreccion; // Agregar fecha de corrección
                textTiempoCorreccion.Text = registro.TiempoCorreccion.ToString(); // Agregar tiempo de corrección
                comboMembresia.Text = registro.Membresia; // Agregar membresía
                textLugarTraslado.Text = registro.LugarTraslado; // Agregar lugar de traslado
                textObservaciones.Text = registro.Observaciones; // Agregar observaciones

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
            miembro.NumeroDoc = textNumeroDeId.Text;
            miembro.FechaNacimiento = dateFechaDeNacimiento.Value;
            miembro.Genero = comboGeneroRegistrar.Text;
            miembro.Oficio=comboOficio.Text;
            miembro.Direccion = textDireccion.Text;
            miembro.Telefono = textTelefono.Text;

            // Mapeo de la imagen del perfil
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
            miembro.ParentezcoPadre = textNombreDelPadre.Text;
            miembro.ParentezcoMadre = textNombreDeLaMadre.Text;
            miembro.EstadoCivil = comboEstadoCivil.Text; // Agregar estado civil
            miembro.NumeroHijos = Convert.ToInt32(textNumeroDeHijos.Text); // Agregar número de hijos
            miembro.NombreConyugue = textNombreDelConyugue.Text; // Agregar nombre del cónyuge
            miembro.Bautizado = comboBautizado.Text; // Agregar campo de bautizado
            miembro.FechaDeBautizmo = dateFechaDeBautismo.Value;
            miembro.LugarBautizmo = textLugarBautizmo.Text; // Agregar lugar de bautismo
            miembro.PastorOficiante = comboPastorOficiante.Text; // Agregar pastor oficiante en el bautismo
            miembro.Sellado = comboSellado.Text; // Agregar campo de sellado
            miembro.SelladoRecuerdo = comboRecuerda.Text; // Agregar sellado recuerdo
            miembro.FechaPromesa = dateFechaEspirituSanto.Value; // Agregar fecha de promesa
            miembro.TiempoConversion = Convert.ToInt32(textTiempoDeConversion.Text); // Agregar tiempo de conversión
            miembro.TiempoPromesa = Convert.ToInt32(textTiempoPromesa.Text); // Agregar tiempo de promesa
            miembro.IglesiaProcedente = textIglesiaProcedente.Text; // Agregar iglesia de procedencia
            miembro.PastorAsistente = comboPastorAsistente.Text; // Agregar pastor asistente
            miembro.CargosDesempenados = textCargosDesempeñados.Text; // Agregar cargos desempeñados
            miembro.Acto = comboActoParaServir.Text; // Agregar acto
            miembro.FechaCorreccion = dateFechaDeCorreccion.Value; // Agregar fecha de corrección
            miembro.TiempoCorreccion = Convert.ToInt32(textTiempoCorreccion.Text); // Agregar tiempo de corrección
            miembro.Membresia = comboMembresia.Text; // Agregar membresía
            miembro.LugarTraslado = textLugarTraslado.Text; // Agregar lugar de traslado
            miembro.Observaciones = textObservaciones.Text; // Agregar observaciones

            return miembro;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ExtraerNombreYApellido();
            GenerarIdContacto();
            Contacto contacto = MapearDatosContacto();
            Miembro nuevoMiembro = MapearDatosMiembro();
            FiltroPorNombre(nombres);
            FiltroPorApellido(apellidos);
            try
            {
                if (encontradoNombre != true && encontradoApellido != true)
                {
                    contactoService.Guardar(contacto);
                    string mensaje = miembroService.Guardar(nuevoMiembro);
                    //Guardamos en la nube
                    var db = FirebaseService.Database;
                    var member = memberMaps.MemberMap(nuevoMiembro);
                    Google.Cloud.Firestore.DocumentReference docRef = db.Collection("MembersData").Document(member.Folio.ToString());
                    docRef.SetAsync(member);
                    MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ConsultarYLlenarGridDeMiembros();
                    LimpiarCampos();
                    CalcularFolio();
                    tabMiembros.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                if (encontradoNombre != true && encontradoApellido != true)
                {
                    contactoService.Guardar(contacto);
                    string mensaje = miembroService.Guardar(miembro);
                    MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ConsultarYLlenarGridDeMiembros();
                    LimpiarCampos();
                    CalcularFolio();
                    tabMiembros.SelectedIndex = 0;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ExtraerNombreYApellido();
            Contacto contacto = MapearDatosContacto();
            Miembro miembro = MapearDatosMiembro();
            FiltroPorNombre(nombres);
            FiltroPorApellido(apellidos);
            try
            {
                if (encontradoNombre == true && encontradoApellido == true)
                {
                    contactoService.Modificar(contacto);
                    string mensaje = miembroService.Modificar(miembro);
                    var db = FirebaseService.Database;
                    var member = memberMaps.MemberMap(miembro);
                    Google.Cloud.Firestore.DocumentReference docRef = db.Collection("MembersData").Document(member.Folio.ToString());
                    docRef.SetAsync(member);
                    MessageBox.Show(mensaje, "Mensaje de modificacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ConsultarYLlenarGridDeMiembros();
                    LimpiarCampos();
                    tabMiembros.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
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
            miembro.FechaDeBautizmo = dateFechaDeBautismo.Value;
            miembro.CalcularTiempoDeConversion();
            textTiempoDeConversion.Text = miembro.TiempoConversion.ToString();

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
            try
            {
                //Elimina primero de firebase o la nube
                var db = FirebaseService.Database;
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("MembersData").Document(id);
                docRef.DeleteAsync();
                string mensaje = miembroService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarYLlenarGridDeMiembros();
            }
            catch(Exception ex)
            {
                string mensaje = miembroService.Eliminar(id);
                contactoService.Eliminar(idContacto);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        //Validaciones de campos
        private void textNombre_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNombre.Text;
            textNombre.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textNombre_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNombre.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNombre.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textNumeroDeId_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNombre.Text;
            textNumeroDeId.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textNumeroDeId_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNumeroDeId.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNumeroDeId.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void comboTipoDocumento_Enter(object sender, EventArgs e)
        {
            string placeHolder = comboTipoDocumento.Text;
            comboTipoDocumento.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void comboTipoDocumento_Leave(object sender, EventArgs e)
        {
            string placeHolder = comboTipoDocumento.Text;
            string nombreDelComponente = ((Control)sender).Name;
            comboTipoDocumento.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void comboGeneroRegistrar_Enter(object sender, EventArgs e)
        {
            string placeHolder = comboGeneroRegistrar.Text;
            comboGeneroRegistrar.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void comboGeneroRegistrar_Leave(object sender, EventArgs e)
        {
            string placeHolder = comboGeneroRegistrar.Text;
            string nombreDelComponente = ((Control)sender).Name;
            comboGeneroRegistrar.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void comboOficio_Enter(object sender, EventArgs e)
        {
            string placeHolder = comboOficio.Text;
            comboOficio.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void comboOficio_Leave(object sender, EventArgs e)
        {
            string placeHolder = comboOficio.Text;
            string nombreDelComponente = ((Control)sender).Name;
            comboOficio.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textDireccion_Enter(object sender, EventArgs e)
        {
            string placeHolder = textDireccion.Text;
            textDireccion.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textDireccion_Leave(object sender, EventArgs e)
        {
            string placeHolder = textDireccion.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textDireccion.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textTelefono_Enter(object sender, EventArgs e)
        {
            string placeHolder = textTelefono.Text;
            textTelefono.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textTelefono_Leave(object sender, EventArgs e)
        {
            string placeHolder = textTelefono.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textTelefono.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textNombreDelPadre_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNombreDelPadre.Text;
            textNombreDelPadre.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textNombreDelPadre_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNombreDelPadre.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNombreDelPadre.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textNombreDeLaMadre_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNombreDeLaMadre.Text;
            textNombreDeLaMadre.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textNombreDeLaMadre_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNombreDeLaMadre.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNombreDeLaMadre.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }
        private void textNumeroDeHijos_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNumeroDeHijos.Text;
            textNumeroDeHijos.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textNumeroDeHijos_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNumeroDeHijos.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNumeroDeHijos.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textNombreDelConyugue_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNombreDelConyugue.Text;
            textNombreDelConyugue.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textNombreDelConyugue_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNombreDelConyugue.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNombreDelConyugue.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textLugarBautizmo_Enter(object sender, EventArgs e)
        {
            string placeHolder = textLugarBautizmo.Text;
            textLugarBautizmo.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textLugarBautizmo_Leave(object sender, EventArgs e)
        {
            string placeHolder = textLugarBautizmo.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textLugarBautizmo.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textIglesiaProcedente_Enter(object sender, EventArgs e)
        {
            string placeHolder = textIglesiaProcedente.Text;
            textIglesiaProcedente.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textIglesiaProcedente_Leave(object sender, EventArgs e)
        {
            string placeHolder = textIglesiaProcedente.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textIglesiaProcedente.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textCargosDesempeñados_Enter(object sender, EventArgs e)
        {
            string placeHolder = textCargosDesempeñados.Text;
            textCargosDesempeñados.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textCargosDesempeñados_Leave(object sender, EventArgs e)
        {
            string placeHolder = textCargosDesempeñados.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textCargosDesempeñados.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textMotivo_Enter(object sender, EventArgs e)
        {
            string placeHolder = textMotivo.Text;
            textMotivo.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textMotivo_Leave(object sender, EventArgs e)
        {
            string placeHolder = textMotivo.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textMotivo.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textLugarTraslado_Enter(object sender, EventArgs e)
        {
            string placeHolder = textLugarTraslado.Text;
            textLugarTraslado.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textLugarTraslado_Leave(object sender, EventArgs e)
        {
            string placeHolder = textLugarTraslado.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textLugarTraslado.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textObservaciones_Enter(object sender, EventArgs e)
        {
            string placeHolder = textObservaciones.Text;
            textObservaciones.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void textObservaciones_Leave(object sender, EventArgs e)
        {
            string placeHolder = textObservaciones.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textObservaciones.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void comboEstadoCivil_Enter(object sender, EventArgs e)
        {
            string placeHolder = comboEstadoCivil.Text;
            comboEstadoCivil.Text = validaciones.TextoPlaceHolderEnter(placeHolder);
        }

        private void comboEstadoCivil_Leave(object sender, EventArgs e)
        {
            string placeHolder = comboEstadoCivil.Text;
            string nombreDelComponente = ((Control)sender).Name;
            comboEstadoCivil.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void comboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboEstadoCivil.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textNumeroDeHijos.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
            textNombreDelConyugue.Enabled= validaciones.ComboResponse(item, nombreDelComponente);
        }
        private void comboBautizado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboBautizado.Text;
            string nombreDelComponente = ((Control)sender).Name;
            dateFechaDeBautismo.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
            textLugarBautizmo.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
            comboPastorOficiante.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
        }
        private void comboSellado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboSellado.Text;
            string nombreDelComponente = ((Control)sender).Name;
            comboRecuerda.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
        }
        private void comboRecuerda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboRecuerda.Text;
            string nombreDelComponente = ((Control)sender).Name;
            dateFechaEspirituSanto.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
        }

        private void comboActoParaServir_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboActoParaServir.Text;
            string nombreDelComponente = ((Control)sender).Name;
            dateFechaDeCorreccion.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
            textMotivo.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
        }

        private void comboMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboMembresia.Text;
            string nombreDelComponente = ((Control)sender).Name;
            textLugarTraslado.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
            textObservaciones.Enabled = validaciones.ComboResponse(item, nombreDelComponente);
        }
    }
}
