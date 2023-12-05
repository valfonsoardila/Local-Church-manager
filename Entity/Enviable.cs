using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Enviable
    {
        public string Id { get; set; }
        public DateTime FechaDeEnvio { get; set; }
        public string Comite { get; set; }
        public string Concepto { get; set; }
        public int Valor { get; set; }
        public string Detalle { get; set; }

        public void GenerarCodigoEnvio()
        {
            string a = "#Env";
            int b;
            string codigo;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            codigo = a + b;
            Id = codigo;
        }
    }
}
