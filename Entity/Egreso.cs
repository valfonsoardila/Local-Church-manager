using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Egreso
    {
        public Egreso(DateTime fechaDeEgreso, string comite, string concepto, int valor, string detalle)
        {
            FechaDeEgreso=fechaDeEgreso;
            Comite=comite;
            Concepto=concepto;
            Valor=valor;
            Detalle=detalle;
        }
        public Egreso()
        {

        }
        public int CodigoComprobante { get; set; }
        public DateTime FechaDeEgreso { get; set; }
        public string Comite { get; set; }
        public string Concepto { get; set; }
        public int Valor { get; set; }
        public string Detalle { get; set; }
    }
}
