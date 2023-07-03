using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Comite
    {
        public Comite(string nombreComite)
        {
            NombreDeComite = nombreComite;
        }
        public string NombreDeComite { get; set; }
    }
}
