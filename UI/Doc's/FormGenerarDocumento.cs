using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormGenerarDocumento : Form
    {
        public string rolLogueado = "";
        IdUsuarioTxt usuarioTxt;
        List<IdUsuarioTxt> idUsuarioTxts;
        public FormGenerarDocumento()
        {
            InitializeComponent();
            ObtenerRol();
        }

        private void ObtenerRol()
        {
            IdUsuarioTxtService idUsuarioTxtService = new IdUsuarioTxtService();
            var idUsuarioTxts = idUsuarioTxtService.Consultar();
            rolLogueado = idUsuarioTxts.IdEmpleadoTxts[0].Rol;
            textRol.Text = rolLogueado;
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelHeaderGenerarInforme_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormGenerarDocumento_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAbrirInforme_Click(object sender, EventArgs e)
        {

        }
    }
}
