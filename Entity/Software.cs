using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Entity
{
    public class Software
    {
        public Software(DateTime fechaDeInstalacion, string fechaDeExpiracion, string horaDeExpiracion, string fechaDeActivacion, string horaDeActivacion, string estadoDeLicencia)
        {
            FechaDeInstalacion = fechaDeInstalacion;
            FechaDeExpiracion = fechaDeExpiracion;
            HoraDeExpiracion = horaDeExpiracion;
            FechaDeActivacion = fechaDeActivacion;
            HoraDeActivacion = horaDeActivacion;
            EstadoDeLicencia = estadoDeLicencia;
        }
        public Software()
        {

        }
        public string NombreDeSoftware { get; set; }
        public DateTime FechaDeInstalacion { get; set; }
        public string FechaDeExpiracion { get; set; }
        public string HoraDeExpiracion { get; set; }
        public string FechaDeActivacion { get; set; }
        public string HoraDeActivacion { get; set; }
        public string EstadoDeLicencia { get; set; }

        public void ObtenerFechaDeActivacion()
        {
            DateTime fechaDeInstalacion = DateTime.Now;
            FechaDeInstalacion = fechaDeInstalacion;
            FechaDeActivacion = fechaDeInstalacion.ToString("dd/MM/yyyy");
            HoraDeActivacion= DateTime.Now.ToString("h:mm:ss tt");
        }
        public void ObtenerFechaDeCaducidad()
        {
            DateTime fechaDeExpiracion = DateTime.Now.AddMinutes(365);
            FechaDeExpiracion = fechaDeExpiracion.ToString("dd/MM/yyyy");
            HoraDeExpiracion= DateTime.Now.ToString("h:mm:ss tt");
            DateTime fechaActual = DateTime.Now;
        }
        public void ValidarEStadoLicencia()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaDeExpiracion = DateTime.Parse(FechaDeExpiracion);
            if (fechaActual <= fechaDeExpiracion)
            {
                EstadoDeLicencia = "Activa";
            }
            else
            {
                if (fechaActual > fechaDeExpiracion)
                {
                    EstadoDeLicencia = "Activa";
                }
            }
        }
    }
}
