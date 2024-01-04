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
            string oficio,
            string estadoCivil,
            int numeroHijos,
            string nombreConyugue,
            string bautizado,
            DateTime fechaDeBautizmo,
            string lugarBautizmo,
            string pastorOficiante,
            string sellado,
            string selladoRecuerdo,
            DateTime fechaPromesa,
            int tiempoPromesa,
            int tiempoConversion,
            string cargosDesempenados,
            string acto,
            DateTime fechaCorreccion,
            int tiempoCorreccion,
            string motivo,
            string membresia,
            string iglesiaProcedente,
            string pastorAsistente,
            string observaciones
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
            Edad = edad;
            Genero = genero;
            Oficio = oficio;
            Direccion = direccion;
            Telefono = telefono;
            ParentezcoPadre = parentezcoPadre;
            ParentezcoMadre = parentezcoMadre;
            EstadoCivil = estadoCivil;
            NumeroHijos = numeroHijos;
            NombreConyugue = nombreConyugue;
            Bautizado = bautizado;
            FechaDeBautizmo = fechaDeBautizmo;
            LugarBautizmo = lugarBautizmo;
            PastorOficiante = pastorOficiante;
            Sellado = sellado;
            SelladoRecuerdo = selladoRecuerdo;
            FechaPromesa = fechaPromesa;
            TiempoPromesa = tiempoPromesa;
            TiempoConversion = tiempoConversion;
            CargosDesempenados = cargosDesempenados;
            Acto = acto;
            FechaCorreccion = fechaCorreccion;
            TiempoCorreccion = tiempoCorreccion;
            Motivo = motivo;
            Membresia = membresia;
            IglesiaProcedente = iglesiaProcedente;
            PastorAsistente = pastorAsistente;
            Observaciones = observaciones;
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
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Oficio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string ParentezcoPadre { get; set; }
        public string ParentezcoMadre { get; set; }
        public string EstadoCivil { get; set; }
        public int NumeroHijos { get; set; }
        public string NombreConyugue { get; set; }
        public string Bautizado { get; set; }
        public DateTime FechaDeBautizmo { get; set; }
        public string LugarBautizmo { get; set; }
        public string PastorOficiante { get; set; }
        public string Sellado { get; set; }
        public string SelladoRecuerdo { get; set; }
        public DateTime FechaPromesa { get; set; }
        public int TiempoConversion { get; set; }
        public int TiempoPromesa { get; set; }
        public string IglesiaProcedente { get; set; }
        public string PastorAsistente { get; set; }
        public string CargosDesempenados { get; set; }
        public string Acto { get; set; }
        public DateTime FechaCorreccion { get; set; }
        public int TiempoCorreccion { get; set; }
        public string Motivo { get; set; }
        public string Membresia { get; set; }
        public string LugarTraslado { get; set; }
        public string Observaciones { get; set; }
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
            int tiempoDeConversion = fechaActual.Year - FechaDeBautizmo.Year;

            // Verificar si el aniversario de bautismo ya ocurrió este año
            if (fechaActual.Month < FechaDeBautizmo.Month || (fechaActual.Month == FechaDeBautizmo.Month && fechaActual.Day < FechaDeBautizmo.Day))
            {
                tiempoDeConversion--;
            }

            TiempoConversion = tiempoDeConversion;
        }
        public void CalculartTiempoDePromesa()
        {
            DateTime fechaActual = DateTime.Now;
            int mesDeRecepcion= FechaPromesa.Month;
            int mesActual = fechaActual.Month;

            int tiempoDePromesa = 0;

            if (mesActual >= mesDeRecepcion)
            {
                tiempoDePromesa = fechaActual.Year - FechaPromesa.Year;
            }
            else
            {
                // Si el mes actual es menor que el mes de membresía, significa que ha pasado un año completo.
                tiempoDePromesa = (fechaActual.Year - 1) - FechaPromesa.Year;
            }

            TiempoPromesa = tiempoDePromesa;
        }

        public void CalcularTiempoDeCorrecion()
        {
            DateTime fechaActual = DateTime.Now;
            int mesDeCorreccion = FechaCorreccion.Month;
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

            TiempoCorreccion = tiempoEnActoCorrectivo;
        }
    }
}
