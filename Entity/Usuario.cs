using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        //Constructor
        public Usuario(string identificacion, string tipoDeIdentificacion, string nombres, string apellidos, DateTime fechaDeNacimiento, int edad, string direccion, string sexo, string telefono, string rol, string correoElectronico, string nombreUsuario, string contraseña, string codigoUsuario)
        {
            Identificacion = identificacion;
            TipoDeIdentificacion = tipoDeIdentificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            FechaDeNacimiento = fechaDeNacimiento;
            Edad = edad;
            Direccion = direccion;
            Sexo = sexo;
            Telefono = telefono;
            Rol = rol;
            CorreoElectronico = correoElectronico;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            CodigoUsuario = codigoUsuario;
        }
        //Constructor Sobrecargado
        public Usuario()
        {

        }
        /*Atributos de la clase*/
        public string Identificacion { get; set; }
        public string TipoDeIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string CodigoUsuario { get; set; }

        /*Metodos de la clase*/
        public void GenerarCodigoUsuario()
        {
            string a = "#Em";
            int b;
            string codigo;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            codigo = a + b;
            CodigoUsuario = codigo;
        }
        public void CalcularEdad()
        {
            int AñoActual = DateTime.Now.Year;
            Edad = AñoActual - FechaDeNacimiento.Year;
        }
    }
}
