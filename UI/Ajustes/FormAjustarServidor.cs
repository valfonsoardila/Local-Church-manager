using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Forms;
using BLL;
using Entity;
using System.Xml;

namespace UI
{
    public partial class FormAjustarServidor : Form
    {
        CadenaConexionXMLService cadenaConexionService = new CadenaConexionXMLService();
        CadenaConexionXML cadenaConexion = new CadenaConexionXML();
        string Server;
        string newServer;
        string connectionString;
        string originalConnection;
        string primeraCadena;
        string segundaCadenaModificada;
        string segundaCadenaOriginal;
        public FormAjustarServidor()
        {
            InitializeComponent();
            EncontrarCadenaDeConexion();
        }
        private void EncontrarCadenaDeConexion()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            labelConnectionString.Text = connectionString;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xmlElement in xmlDocument.DocumentElement)
            {
                if (xmlElement.Name.Equals("connectionStrings"))
                {
                    foreach (XmlNode node in xmlElement.ChildNodes)
                    {
                        if (node.Attributes[0].Value == "conexion")
                        {
                            Server = node.Attributes[1].Value;
                        }
                    }
                }
            }
        }
        private void btnModificarConexion_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Está seguro de Modificar la conexion a la base de datos?", "Mensaje de Modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                ModificarCadenaConexion();
                EncontrarCadenaDeConexion();
            }
        }

        private void textCadenaConexion_TextChanged(object sender, EventArgs e)
        {
            newServer = textCadenaConexion.Text;
        }
        private void ModificarCadenaConexion()
        {
            if (textCadenaConexion.Text != "")
            {
                primeraCadena = "    <add name=" + '"' + "conexion" + '"' + " connectionString=" + '"';
                segundaCadenaModificada = "Server=" + newServer + ";Database=AdminPharm;Trusted_Connection = True; MultipleActiveResultSets = true" + '"' + " />";
                segundaCadenaOriginal = Server + '"' + " />";

                cadenaConexion.Cadena = primeraCadena + segundaCadenaModificada;
                originalConnection = primeraCadena + segundaCadenaOriginal;
                cadenaConexionService.Modificar(cadenaConexion, originalConnection);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
