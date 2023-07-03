using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servidor
    {
        public Servidor(string nombre, string comite, string cargo, string vigencia, string observacion)
        {
            Nombre = nombre;
            Comite = comite;
            Cargo = cargo;
            Vigencia = vigencia;
            Observacion = observacion;
        }
        public Servidor()
        {

        }
        public string Nombre { get; set; }
        public string Comite { get; set; }
        public string Cargo { get; set; }
        public string Vigencia { get; set; }
        public string Observacion { get; set; }
    }
}
