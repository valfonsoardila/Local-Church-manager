using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Presupuesto
    {
        public Presupuesto(
            int id, 
            DateTime fechaPresupuesto, 
            string comite, 
            int ofrenda, 
            int actividad,
            int voto,
            int totalPresupuesto
        )
        {
            Id=id;
            FechaPresupuesto=fechaPresupuesto;
            Comite=comite;
            Ofrenda=ofrenda;
            Actividad=actividad;
            Voto=voto;
            TotalPresupuesto=totalPresupuesto;
        }
        public Presupuesto()
        {

        }

        public int Id;
        public DateTime FechaPresupuesto { get; set; }
        public string Comite { get; set; }
        public int Ofrenda { get; set; }
        public int Actividad { get; set; }
        public int Voto { get; set; }
        public int TotalPresupuesto { get; set; }
    }
}
