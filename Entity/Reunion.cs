using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Reunion
    {
        public Reunion(string nuemeroActa, DateTime fechaDeReunion, string lugarDeReunion, string ordenDelDia, string textoActa)
        {
            NumeroActa = nuemeroActa;
            FechaDeReunion= fechaDeReunion;
            LugarDeReunion= lugarDeReunion;
            OrdenDelDia = ordenDelDia;
            TextoActa = textoActa;
        }
        public Reunion()
        {

        }
        public string NumeroActa { get; set; }
        public DateTime FechaDeReunion { get; set; }
        public string LugarDeReunion { get; set; }
        public string OrdenDelDia { get; set; }
        public string TextoActa { get; set; }
    }
}
