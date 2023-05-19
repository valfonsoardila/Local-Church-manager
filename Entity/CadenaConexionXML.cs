using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CadenaConexionXML
    {
        public CadenaConexionXML(string cadenaConexion)
        {
            Cadena = cadenaConexion;
        }
        public CadenaConexionXML()
        {

        }
        public string Cadena { get; set; }
    }
}
