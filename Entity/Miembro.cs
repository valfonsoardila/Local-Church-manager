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
            string nombre,
            string tipoDoc,
            string numeroDoc,
            DateTime fechaDeNacimiento,
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
            Nombre= nombre;
            TipoDoc= tipoDoc;
            NumeroDoc= numeroDoc;
            FechaNacimiento = fechaDeNacimiento;
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
        public string Nombre { get; set; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaNacimiento { get; set; }
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
        public void GenerarFolio()
        {

        }
        public void CalcularTiempoDeConversion()
        {
            string añoActual = DateTime.Now.Year.ToString();
            int mesActual= Convert.ToInt32(DateTime.Now.Month.ToString());
            string añoBautizo = FechaBautizmo.Year.ToString();
            int mesBautizo = Convert.ToInt32(FechaBautizmo.Month.ToString());
            int difereciaAños;
            if (mesActual > mesBautizo) { 
                difereciaAños = Convert.ToInt32(añoActual) - Convert.ToInt32(añoBautizo);
                TiempoDeConversion = difereciaAños;
            }
            else
            {
                if (mesActual < mesBautizo)
                {
                    difereciaAños = (Convert.ToInt32(añoActual)-1) - Convert.ToInt32(añoBautizo);
                    TiempoDeConversion = difereciaAños;
                }
            }
        }
        public void CalcularMembresiaIglesiaProcedente()
        {
            string añoActual = DateTime.Now.Year.ToString();
            int mesActual = Convert.ToInt32(DateTime.Now.Month.ToString());
            string añoDeMembresia = FechaMembresiaIglesiaProcedente.Year.ToString();
            int mesDeMembresia = Convert.ToInt32(FechaMembresiaIglesiaProcedente.Month.ToString());
            int difereciaAños;
            if (mesActual > mesDeMembresia)
            {
                difereciaAños = Convert.ToInt32(añoActual) - Convert.ToInt32(añoDeMembresia);
                TiempoDeMembresiaIglesiaProcedente = difereciaAños;
            }
            else
            {
                if (mesActual < mesDeMembresia)
                {
                    difereciaAños = (Convert.ToInt32(añoActual) - 1) - Convert.ToInt32(añoDeMembresia);
                    TiempoDeMembresiaIglesiaProcedente = difereciaAños;
                }
            }
        }
        public void CalcularTiempoDeCorecion()
        {
            int mesDeInicio = Convert.ToInt32(FechaDeCorreccion.Month);
            int mesActual = Convert.ToInt32(DateTime.Now.Month.ToString());
            if(mesActual>= mesDeInicio)
            {
                TiempoEnActoCorrectivo=mesActual - mesDeInicio;
            }
        }
    }
}
