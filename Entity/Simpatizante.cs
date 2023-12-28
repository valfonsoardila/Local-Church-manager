using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Simpatizante
    {
        public Simpatizante(
            byte[] imagenPerfil,
            string idContacto,
            string nombre,
            string apellido,
            string tipoDoc,
            string numeroDoc,
            DateTime fechaDeNacimiento,
            string genero,
            string oficio,
            int edad,
            string direccion,
            string telefono
        )
        {
            ImagenPerfil=imagenPerfil;
            IdContacto=idContacto;
            Nombre=nombre;
            Apellido=apellido;
            TipoDoc=tipoDoc;
            NumeroDoc=numeroDoc;
            FechaNacimiento=fechaDeNacimiento;
            Edad=edad;
            Genero = genero;
            Oficio = oficio;
            Direccion=direccion;
            Telefono=telefono;
        }
        public Simpatizante()
        {

        }
        public byte[] ImagenPerfil { get; set; }
        public string IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Oficio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public void CalcularEdad()
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - FechaNacimiento.Year;

            // Verificar si el cumpleaños ya ocurrió este año
            if (fechaActual.Month < FechaNacimiento.Month || (fechaActual.Month == FechaNacimiento.Month && fechaActual.Day < FechaNacimiento.Day))
            {
                edad--;
            }

            Edad = edad;
        }
    }
}
