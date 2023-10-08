using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Miembro
    {
        public Miembro(
            string folio,
            byte[] imagenPerfil,
            string idContacto,
            string nombre,
            string apellido,
            string tipoDoc,
            string numeroDoc,
            DateTime fechaDeNacimiento,
            string genero,
            int edad,
            string direccion,
            string telefono,
            string parentezcoPadre,
            string parentezcoMadre,
            DateTime fechaBautizo,
            int tiempoDeConversion,
            DateTime fechaRecepcionEspirituSanto,
            string lugarRecepcionespirituSanto,
            string pastorOficiante,
            DateTime fechaMembresiaIglesiaProcedente,
            int tiempoDeMembresiaIglesiaProcedente,
            string estadoServicio,
            DateTime fechaDeCorreccion,
            int tiempoEnActoCorrectivo,
            string estadoMembresia,
            string lugarDeTraslado
        )
        {
            Folio = folio;
            ImagenPerfil= imagenPerfil;
            IdContacto = idContacto;
            Nombre = nombre;
            Apellido = apellido; 
            TipoDoc= tipoDoc;
            NumeroDoc= numeroDoc;
            FechaNacimiento = fechaDeNacimiento;
            Genero = genero;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
            ParentezcoPadre = parentezcoPadre;
            ParentezcoMadre = parentezcoMadre;
            FechaBautizmo = fechaBautizo;
            TiempoDeConversion = tiempoDeConversion;
            FechaRecepcionEspirituSanto = fechaRecepcionEspirituSanto;
            LugarRecepcionespirituSanto = lugarRecepcionespirituSanto;
            PastorOficiante = pastorOficiante;
            FechaMembresiaIglesiaProcedente = fechaMembresiaIglesiaProcedente;
            TiempoDeMembresiaIglesiaProcedente = tiempoDeMembresiaIglesiaProcedente;
            EstadoServicio = estadoServicio;
            FechaDeCorreccion = fechaDeCorreccion;
            TiempoEnActoCorrectivo = tiempoEnActoCorrectivo;
            EstadoMembresia = estadoMembresia;
            LugarDeTraslado = lugarDeTraslado;
        }
        public Miembro()
        {

        }
        public string Folio { get; set; }
        public byte[] ImagenPerfil { get; set; }
        public string IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string ParentezcoPadre { get; set; }
        public string ParentezcoMadre { get; set; }
        public DateTime FechaBautizmo { get; set; }
        public int TiempoDeConversion { get; set; }
        public DateTime FechaRecepcionEspirituSanto { get; set; }
        public string LugarRecepcionespirituSanto { get; set; }
        public string PastorOficiante { get; set; }
        public DateTime FechaMembresiaIglesiaProcedente { get; set; }
        public int TiempoDeMembresiaIglesiaProcedente { get; set; }
        public string EstadoServicio { get; set; }
        public DateTime FechaDeCorreccion { get; set; }
        public int TiempoEnActoCorrectivo { get; set; }
        public string EstadoMembresia { get; set; }
        public string LugarDeTraslado { get; set; }
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
        public void CalcularTiempoDeConversion()
        {
            DateTime fechaActual = DateTime.Now;
            int tiempoDeConversion = fechaActual.Year - FechaBautizmo.Year;

            // Verificar si el aniversario de bautismo ya ocurrió este año
            if (fechaActual.Month < FechaBautizmo.Month || (fechaActual.Month == FechaBautizmo.Month && fechaActual.Day < FechaBautizmo.Day))
            {
                tiempoDeConversion--;
            }

            TiempoDeConversion = tiempoDeConversion;
        }
        public void CalcularMembresiaIglesiaProcedente()
        {
            DateTime fechaActual = DateTime.Now;
            int mesDeMembresia = FechaMembresiaIglesiaProcedente.Month;
            int mesActual = fechaActual.Month;

            int tiempoDeMembresiaIglesiaProcedente = 0;

            if (mesActual >= mesDeMembresia)
            {
                tiempoDeMembresiaIglesiaProcedente = fechaActual.Year - FechaMembresiaIglesiaProcedente.Year;
            }
            else
            {
                // Si el mes actual es menor que el mes de membresía, significa que ha pasado un año completo.
                tiempoDeMembresiaIglesiaProcedente = (fechaActual.Year - 1) - FechaMembresiaIglesiaProcedente.Year;
            }

            TiempoDeMembresiaIglesiaProcedente = tiempoDeMembresiaIglesiaProcedente;
        }

        public void CalcularTiempoDeCorrecion()
        {
            DateTime fechaActual = DateTime.Now;
            int mesDeCorreccion = FechaDeCorreccion.Month;
            int mesActual = fechaActual.Month;

            int tiempoEnActoCorrectivo = 0;

            if (mesActual >= mesDeCorreccion)
            {
                tiempoEnActoCorrectivo = mesActual - mesDeCorreccion;
            }
            else
            {
                // Si el mes actual es menor que el mes de corrección, significa que ha pasado un año completo.
                tiempoEnActoCorrectivo = 12 - (mesDeCorreccion - mesActual);
            }

            TiempoEnActoCorrectivo = tiempoEnActoCorrectivo;
        }
    }
}
