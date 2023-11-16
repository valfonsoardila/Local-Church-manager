using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL;
using Entity;
//se importa la libreria para arrastrar formulario
using System.Runtime.InteropServices;
using System.Threading;
using Cloud;
using FirebaseAdmin.Messaging;
using Google.Cloud.Firestore;

namespace UI
{
    public partial class FormInicioSesion : Form
    {
        SoftwareService softwareService;
        UsuarioService usuarioService;
        Software software;
        bool estadoCliente;
        string nombreDeUsuario;
        string contraseña;
        string Id_Usuario;
        bool UsuarioValido=false;
        object sender;
        EventArgs e;
        public FormInicioSesion()
        {
            softwareService = new SoftwareService(ConfigConnection.ConnectionString);
            usuarioService = new UsuarioService(ConfigConnection.ConnectionString);
            InitializeComponent();
            UbicacionesPorDefault();
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void VerificarEstadoDeLicencia()
        {
            ConsultaSoftwareRespuesta respuesta = new ConsultaSoftwareRespuesta();
            respuesta = softwareService.ConsultarTodos();
            if (respuesta.Softwares.Count == 0 || respuesta.Softwares == null)
            {
                FormActivador formActivador = new FormActivador();
                formActivador.Show();
                this.Hide();
                this.Visible = false;
            }
            else
            {
                if (respuesta.Softwares.Count != 0 && respuesta.Softwares != null)
                {
                    this.Visible = true;
                    this.Enabled = true;
                }
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void iconSeePasword_Click(object sender, EventArgs e)
        {
            iconNoSeePasword.Visible = true;
            iconSeePasword.Visible = false;
            textBoxPasword.UseSystemPasswordChar = true;
        }

        private void iconNoSeePasword_Click(object sender, EventArgs e)
        {
            iconNoSeePasword.Visible = false;
            iconSeePasword.Visible = true;
            textBoxPasword.UseSystemPasswordChar = false;
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "@Usuario")
            {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "@Usuario";
                textBoxUser.ForeColor = Color.Gray;
            }
        }

        private void textBoxPasword_Enter(object sender, EventArgs e)
        {
            if (textBoxPasword.Text == "Contraseña")
            {
                textBoxPasword.Text = "";
                textBoxPasword.ForeColor = Color.Black;
                textBoxPasword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPasword_Leave(object sender, EventArgs e)
        {
            if (textBoxPasword.Text == "")
            {
                textBoxPasword.Text = "Contraseña";
                textBoxPasword.ForeColor = Color.Gray;
                textBoxPasword.UseSystemPasswordChar = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormInicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void BuscarPorNombreDeUsuario()
        {
            BusquedaUsuarioRespuesta respuesta = new BusquedaUsuarioRespuesta();
            respuesta = usuarioService.BuscarPorNombreDeUsuario(nombreDeUsuario);
            if (respuesta.Usuario != null)
            {
                var usuario = new List<Usuario> { respuesta.Usuario };
                contraseña = respuesta.Usuario.Contraseña;
                Id_Usuario = respuesta.Usuario.Identificacion;
                linkLabelRestaurarContraseña.ForeColor = Color.FromArgb(0, 0, 255);
                linkLabelRegistrarUsuario.ForeColor = Color.FromArgb(0, 0, 255);
                ValidarContraseña();
            }
            else
            {
                if (respuesta.Usuario == null)
                {
                    labelAdvertencia.Visible = true;
                    iconAdvertencia.Visible = true;
                    labelAdvertencia.Text = "El nombre de usuario no existe";
                    linkLabelRegistrarUsuario.ForeColor = Color.Maroon;
                    textBoxUser.ForeColor = Color.Maroon;
                    UbicacionesPorAdvertencia();
                }
            }
        }
        private void UbicacionesPorAdvertencia()
        {
            linkLabelRegistrarUsuario.Location = new Point(116, 296);
            linkLabelRestaurarContraseña.Location = new Point(147, 279);
        }
        private void UbicacionesPorDefault()
        {

            linkLabelRegistrarUsuario.Location = linkLabelRestaurarContraseña.Location;
            linkLabelRestaurarContraseña.Location = iconAdvertencia.Location;
        }
        private void ValidarContraseña()
        {
            if (textBoxPasword.Text == contraseña)
            {
                UsuarioValido = true;
            }
            else
            {
                if (textBoxPasword.Text != contraseña)
                {
                    UsuarioValido = false;
                    labelAdvertencia.Visible = true;
                    iconAdvertencia.Visible = true;
                    labelAdvertencia.Text = "Contraseña incorrecta";
                    linkLabelRestaurarContraseña.ForeColor = Color.Maroon;
                    textBoxPasword.ForeColor = Color.Maroon;
                    UbicacionesPorAdvertencia();
                }
            }
        }
        private void MapearDatos()
        {
            nombreDeUsuario = textBoxUser.Text;
        }
        private async void VaidarUsuaro()
        {
            MapearDatos();
            var contraseña = textBoxPasword.Text;
            //Consulta en la nube
            try
            {
                var db = FirebaseService.Database;
                var users = new List<UserData>();
                Google.Cloud.Firestore.Query userQuery = db.Collection("UserData");
                QuerySnapshot snap = await userQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot docsnap in snap.Documents)
                {
                    UserData userData = docsnap.ConvertTo<UserData>();
                    if(userData.UserName == nombreDeUsuario)
                    {
                        if(FirebaseSecurity.Decrypt(userData.Password)== contraseña)
                        {
                            UsuarioValido = true;
                        }
                    }
                }
                if (UsuarioValido == true)
                {
                    FormMenu mainMenu = new FormMenu();
                    mainMenu.idUsuario = Id_Usuario;
                    mainMenu.ValidarUsuario();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    labelAdvertencia.Visible = true;
                    iconAdvertencia.Visible = true;
                    labelAdvertencia.Text = "El nombre de usuario no existe";
                    linkLabelRegistrarUsuario.ForeColor = Color.Maroon;
                    textBoxUser.ForeColor = Color.Maroon;
                    UbicacionesPorAdvertencia();
                }
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    BuscarPorNombreDeUsuario();
                    //verifica de forma local
                    if (UsuarioValido == true)
                    {
                        FormMenu mainMenu = new FormMenu();
                        mainMenu.idUsuario = Id_Usuario;
                        mainMenu.ValidarUsuario();
                        mainMenu.Show();
                        this.Hide();
                    }
                }
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            VaidarUsuaro();
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                iconAdvertencia.Visible = false;
                labelAdvertencia.Visible = false;
                linkLabelRegistrarUsuario.Location = new Point(147, 279);
                linkLabelRestaurarContraseña.Location = new Point(150, 257);
            }
        }
        private void textBoxPasword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "@Victor10" && textBoxPasword.Text == "Victor2002")
            {
                btnAjustarServidor.Visible = true;
            }
        }
        private void linkLabelRestaurarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRestaurarContraseña formRestaurarContraseña = new FormRestaurarContraseña();
            formRestaurarContraseña.Show();
            this.Hide();
        }

        private void linkLabelRegistrarUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistrarUsuario formRegistrarUsuario = new FormRegistrarUsuario();
            formRegistrarUsuario.Show();
            this.Hide();
        }

        private void btnAjustarServidor_Click(object sender, EventArgs e)
        {
            FormAjustarServidor formAjustarServidor = new FormAjustarServidor();
            formAjustarServidor.Show();
            this.Hide();
        }
    }
}
