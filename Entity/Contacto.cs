using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contacto
    {
        public Contacto(string id, string nombre, string apellido, string telefonoContacto, string telefonoWhatsapp, string oficio)
        {
            IdContacto = oficio;
            Nombre=nombre;
            Apellido = apellido;
            TelefonoContacto=telefonoContacto;
            TelefonoWhatsapp=telefonoWhatsapp;
            Oficio=oficio;
        }
        public Contacto()
        {

        }
        public string IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TelefonoContacto { get; set; }
        public string TelefonoWhatsapp { get; set; }
        public string Oficio { get; set; }
        public void GenerarId()
        {
            string a = "#Contact";
            int b;
            string codigo;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            codigo = a + b;
            IdContacto = codigo;
        }
        public void GenerarWhatsapp()
        {
            string indicativo = "+57 ";
            string numeroCelular = TelefonoContacto;
            TelefonoWhatsapp = indicativo + numeroCelular;
        }

    }
}
