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
        public string TextoPlaceHolderEnter(string textPlaceHolder)
        {
            string textChanged="";
            if (textPlaceHolder != "")
            {
                textChanged = "";
            }
            return textChanged;
        }
        public string TextoPlaceHolderLeave(string textPlaceHolder, string nombreDelComponente)
        {
            string textChanged = "";
            if (textPlaceHolder == "")
            {
                if (nombreDelComponente.StartsWith("text"))
                {
                    // Elimina "text" del inicio para obtener el nombre deseado
                    nombreDelComponente = nombreDelComponente.Substring(4);
                    // Dividir el nombre por espacios
                    string[] palabras = Regex.Split(nombreDelComponente, @"(?<!^)(?=[A-Z])");
                    for (int i = 0; i < palabras.Length; i++)
                    {
                        if (i == 0)
                        {
                            palabras[i] = palabras[i].Substring(0, 1).ToUpper() + palabras[i].Substring(1).ToLower();
                        }
                        else
                        {
                            palabras[i] = palabras[i].ToLower();
                        }
                    }

                    // Unir las palabras nuevamente
                    textChanged = string.Join(" ", palabras);
                }
                else
                {
                    if (nombreDelComponente.StartsWith("combo"))
                    {
                        // Elimina "combo" del inicio para obtener el nombre deseado
                        nombreDelComponente = nombreDelComponente.Substring(5);
                        if (nombreDelComponente.Contains("Genero"))
                        {
                            textChanged = "Masculino";
                        }
                        else
                        {
                            if (nombreDelComponente.Contains("TipoDocumento"))
                            {
                                textChanged = "CC";
                            }
                            else
                            {
                                if (nombreDelComponente.Contains("EstadoCivil"))
                                {
                                    textChanged = "Sin especificar";
                                }
                                else
                                {
                                    if (nombreDelComponente.Contains("Bautizado"))
                                    {
                                        textChanged = "No";
                                    }
                                    else
                                    {
                                        if (nombreDelComponente.Contains("PastorOficiante"))
                                        {
                                            textChanged = "Emiro Diaz";
                                        }
                                        else
                                        {
                                            if (nombreDelComponente.Contains("Sellado"))
                                            {
                                                textChanged = "No";
                                            }
                                            else
                                            {
                                                if (nombreDelComponente.Contains("Recuerda"))
                                                {
                                                    textChanged = "No";
                                                }
                                                else
                                                {
                                                    if (nombreDelComponente.Contains("PastorAsistente"))
                                                    {
                                                        textChanged = "No";
                                                    }
                                                    else
                                                    {
                                                        if (nombreDelComponente.Contains("PastorAsistente"))
                                                        {
                                                            textChanged = "No";
                                                        }
                                                        else
                                                        {
                                                            if (nombreDelComponente.Contains("Membresia"))
                                                            {
                                                                textChanged = "Congregado";
                                                            }
                                                            else
                                                            {
                                                                if (nombreDelComponente.Contains("Oficio"))
                                                                {
                                                                    textChanged = "Oficio";
                                                                }
                                                                else
                                                                {
                                                                    if (nombreDelComponente.Contains("EstadoCivil"))
                                                                    {
                                                                        textChanged = "Sin especificar";
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return textChanged;
        }
        public bool ComboResponse(string item, string nombreDelComponente)
        {
            bool response = false;
            if (item != "" && item!="Sin especificar")
            {
                if (nombreDelComponente.StartsWith("combo"))
                {
                    nombreDelComponente = nombreDelComponente.Substring(5);
                    if (nombreDelComponente.Contains("EstadoCivil"))
                    {
                        if (item != "No")
                        {
                            response = true;
                        }
                    }
                    else
                    {
                        if (nombreDelComponente.Contains("Bautizado"))
                        {
                            if (item != "No")
                            {
                                response = true;
                            }
                        }
                        else
                        {
                            if (nombreDelComponente.Contains("Sellado"))
                            {
                                if (item != "No")
                                {
                                    response = true;
                                }
                            }
                            else
                            {
                                if (nombreDelComponente.Contains("Recuerda"))
                                {
                                    if (item != "No recuerda")
                                    {
                                        response = true;
                                    }
                                }
                                else
                                {
                                    if (nombreDelComponente.Contains("ActoParaServir"))
                                    {
                                        if (item == "Disciplina")
                                        {
                                            response = true;
                                        }
                                    }
                                    else
                                    {
                                        if (nombreDelComponente.Contains("Membresia"))
                                        {
                                            if (item != "Congregado")
                                            {
                                                response = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return response;
        }
    }
}
