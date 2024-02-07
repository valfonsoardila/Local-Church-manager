using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PresupuestoComite
    {
        public PresupuestoComite(
            int id, 
            string añoPresupuesto, 
            string inicioIntervalo,
            string finIntervalo,
            string comite, 
            int ofrenda, 
            int actividad,
            int voto,
            int totalEgresos,
            int totalPresupuesto
        )
        {
            Id=id;
            AñoPresupuesto = añoPresupuesto;
            InicioIntervalo=inicioIntervalo;
            FinIntervalo=finIntervalo;
            Comite=comite;
            Ofrenda=ofrenda;
            Actividad=actividad;
            Voto=voto;
            TotalEgresos=totalEgresos;
            TotalPresupuesto =totalPresupuesto;
        }
        public PresupuestoComite()
        {

        }

        public int Id { get; set; }
        public string AñoPresupuesto { get; set; }
        public string InicioIntervalo { get; set; }
        public string FinIntervalo { get; set; }
        public string Comite { get; set; }
        public int Ofrenda { get; set; }
        public int Actividad { get; set; }
        public int Voto { get; set; }
        public string OtroConcepto { get; set; }
        public int ValorOtroConcepto { get; set; }
        public int TotalEgresos { get; set; }
        public int TotalPresupuesto { get; set; }
        public void GenerarCodigoPresupuesto()
        {
            int b;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            Id = b;
        }
    }
    public class PresupuestoIngresoLocal
    {
        public PresupuestoIngresoLocal
        (
            int id,
            string añoPresupuesto,
            string inicioIntervalo,
            string finIntervalo,
            string comite,
            string concepto,
            string valor
        )
        {
            Id = id;
            AñoPresupuesto = añoPresupuesto;
            InicioIntervalo = inicioIntervalo;
            FinIntervalo = finIntervalo;
            Comite = comite;
            Concepto = concepto;
            Valor = valor;
        }
        public PresupuestoIngresoLocal()
        {

        }
        public int Id { get; set; }
        public string AñoPresupuesto { get; set; }
        public string InicioIntervalo { get; set; }
        public string FinIntervalo { get; set; }
        public string Comite { get; set; }
        public string Concepto { get; set; }
        public string Valor { get; set; }
    }
    public class PresupuestoEgresoLocal
    {
        public PresupuestoEgresoLocal
        (
            int id,
            string añoPresupuesto,
            string inicioIntervalo,
            string finIntervalo,
            string comite,
            string concepto,
            string valor
        )
        {
            Id = id;
            AñoPresupuesto = añoPresupuesto;
            InicioIntervalo = inicioIntervalo;
            FinIntervalo = finIntervalo;
            Comite = comite;
            Concepto = concepto;
            Valor = valor;
        }
        public PresupuestoEgresoLocal()
        {

        }
        public int Id { get; set; }
        public string AñoPresupuesto { get; set; }
        public string InicioIntervalo { get; set; }
        public string FinIntervalo { get; set; }
        public string Comite { get; set; }
        public string Concepto { get; set; }
        public string Valor { get; set; }
    }

}
