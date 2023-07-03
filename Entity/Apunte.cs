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
            Id= id;
            Titulo= titulo;
            Nota= nota;
        }
        public Apunte()
        {

        }
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Nota { get; set; }
        public void GenerarIdNota()
        {

        }
    }
}
