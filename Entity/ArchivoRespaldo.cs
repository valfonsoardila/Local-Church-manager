using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ArchivoRespaldo
    {
        public ArchivoRespaldo(string nombreDeArchivo)
        {
            NombreDeArchivo = nombreDeArchivo;
        }
        public ArchivoRespaldo()
        {

        }
        public string NombreDeArchivo { get; set; }
    }
}
