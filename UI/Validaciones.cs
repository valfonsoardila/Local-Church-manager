using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class Validaciones
    {
        public bool ValidacionEmail(string comprobarEmail)
        {
            string emailForm;
            emailForm = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(comprobarEmail, emailForm))
            {
                if (Regex.Replace(comprobarEmail, emailForm, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        //Valida el campo usuario
        public bool ValidacionUsuario(string comprobarUsuario)
        {
            string emailForm;
            emailForm = "^@[A-Za-z]+[0-9].*$";

            if (Regex.IsMatch(comprobarUsuario, emailForm))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Valida el contraseña
        public bool ValidacionContrasena(string comprobarContrasena)
        {
            bool estado = false;
            if (comprobarContrasena.Length > 8)
            {
                estado = true;
            }
            else
            {
                estado= false;
            }
            return estado;
        }
        //Valida que se cargue una foto
        public bool ValidarImagen(string rutaArchivo)
        {
            try
            {
                // Verifica si la ruta del archivo es nula o vacía
                if (string.IsNullOrEmpty(rutaArchivo))
                {
                    return false;
                }

                // Verifica si la extensión del archivo corresponde a una imagen
                string extension = Path.GetExtension(rutaArchivo);
                string[] extensionesValidas = { ".jpg", ".jpeg", ".png", ".gif" }; // Agrega aquí las extensiones de imagen permitidas

                if (!extensionesValidas.Contains(extension.ToLower()))
                {
                    return false;
                }

                // Intenta cargar la imagen desde el archivo para comprobar si está en un formato válido
                using (Image imagen = Image.FromFile(rutaArchivo))
                {
                    // Si no se produce ninguna excepción, se considera una imagen válida
                    return true;
                }
            }
            catch
            {
                // Si se produce una excepción, no se trata de una imagen válida
                return false;
            }
        }
        //validar rangos de campos
        public bool RangoCampos(TextBox textBox, string text, Label label, int num)
        {
            bool estado=false;
            if(textBox.Text != text && textBox.Text != "")
            {
                if (textBox.Text.Length < num)
                {
                    label.Visible = true;
                    label.ForeColor = Color.Red;
                    label.Text = text + "Rango minimo " + num;
                    estado = false;
                }
                else
                {
                    label.Visible = false;
                    estado = true;
                }
            }
            return estado;
        }
    }
}
