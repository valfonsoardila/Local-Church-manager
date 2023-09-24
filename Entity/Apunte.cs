using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Apunte
    {
        public Apunte(string id, string titulo, string nota)
        {
            IdNota = id;
            Titulo = titulo;
            Nota = nota;
        }
        public Apunte()
        {

        }
        public string IdNota { get; set; }
        public string Titulo { get; set; }
        public string Nota { get; set; }
        public void GenerarIdNota()
        {
            string a = "#Note";
            int b;
            string codigo;
            Random aleatorio = new Random();
            b = aleatorio.Next(100000, 200000);
            codigo = a + b;
            IdNota = codigo;
        }
    }
}
