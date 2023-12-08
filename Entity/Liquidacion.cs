using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidacion
    {
        public string Id { get; set; }
        public DateTime FechaDeLiquidacion { get; set; }
        public int Valor { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }

        public void GenerarCodigoLiquidacion()
        {
            string a = "#Liqu";
            int b;
            string codigo;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            codigo = a + b;
            Id = codigo;
        }
    }
}
