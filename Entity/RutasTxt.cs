using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RutasTxt
    {
        public RutasTxt(int referencia, string rutaCierreDeCaja, string rutaFacturasVenta, string rutaProductosVendidos)
        {
            Referencia = referencia;
            RutaCierreDeCaja = rutaCierreDeCaja;
            RutaFacturasVenta = rutaFacturasVenta;
            RutaProductosVendidos = rutaProductosVendidos;
        }
        //Constructor Sobrecargado
        public RutasTxt()
        {

        }
        /*Atributos de la clase*/
        public int Referencia { get; set; }
        public string RutaCierreDeCaja { get; set; }
        public string RutaFacturasVenta { get; set; }
        public string RutaProductosVendidos { get; set; }
    }
}
