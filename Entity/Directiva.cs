using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Directiva
    {
        public Directiva(string id, string nombre, string cargo, string comite, string vigencia, string observacion)
        {
            IdDirectiva = id;
            Nombre = nombre;
            Cargo = cargo;
            Comite = comite;
            Vigencia = vigencia;
            Observacion = observacion;
        }
        public Directiva()
        {

        }
        public string IdDirectiva { get; set; }
        public string Nombre { get; set;}
        public string Cargo { get; set; }
        public string Comite { get; set; }
        public string Vigencia { get; set;}
        public string Observacion { get; set; }
        public void GenerarIdDirectiva()
        {
            string a = "#Servidor";
            int b;
            string codigo;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            codigo = a + b;
            IdDirectiva = codigo;
        }
    }
}
