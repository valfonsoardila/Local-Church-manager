using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Ingreso
    {
        public Ingreso(int codigoComprobante, DateTime fechaDeIngreso, string comite, string concepto, int valor, string detalle)
        {
            CodigoComprobante=codigoComprobante;
            FechaDeIngreso = fechaDeIngreso;
            Comite = comite;
            Concepto = concepto;
            Valor = valor;
            Detalle = detalle;
        }
        public Ingreso()
        {

        }
        public int CodigoComprobante { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string Comite { get; set; }
        public string Concepto { get; set; }
        public int Valor { get; set; }
        public string Detalle { get; set; }

    }
}
