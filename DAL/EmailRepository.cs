using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class EmailRepository
    {
        private string ruta = @"SesionBackup.config";
        public void Guardar(Email Email)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{Email.CorreoElectronicoOrigen};{Email.CorreoElectronicoDestino};{Email.Contraseña}");
            escritor.Close();
            file.Close();
        }
        public List<Email> Consultar()
        {
            List<Email> Emails = new List<Email>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                Email Email = new Email()
                {
                    CorreoElectronicoOrigen = dato[0],
                    CorreoElectronicoDestino = dato[1],
                    Contraseña = dato[2],
                };
                Emails.Add(Email);
            }
            lector.Close();
            file.Close();
            return Emails;
        }
        public bool FiltroCorreo(string correo)
        {
            List<Email> Emails = new List<Email>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                if (dato[1].Equals(correo))
                {
                    lector.Close();
                    file.Close();
                    return true;
                }
            }
            lector.Close();
            file.Close();
            return false;
        }
        private bool EsEncontrado(string correoRegistrado, string correoBuscado)
        {
            return correoRegistrado == correoBuscado;
        }
        public void Modificar(Email Email, string referencia)
        {
            List<Email> Emails = new List<Email>();
            Emails = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in Emails)
            {
                if (!EsEncontrado(item.CorreoElectronicoOrigen, referencia))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(Email);
                }
            }
        }
        public void EliminarTodo()
        {
            File.Delete(ruta);
        }
        public void Eliminar(string correo)
        {
            List<Email> Emails = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in Emails)
            {
                if (!item.CorreoElectronicoOrigen.Equals(correo))
                {
                    Guardar(item);
                }
            }
        }
    }
}
