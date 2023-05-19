using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Licencia
    {
        public Licencia(string licenciaSoftware)
        {
            LicenciaSoftware = licenciaSoftware;
        }
        public Licencia()
        {

        }
        public string LicenciaSoftware { get; set; }
    }
}
