using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IdUsuarioTxt
    {
        public IdUsuarioTxt(string identificacion)
        {
            Identificacion = identificacion;
        }
        public IdUsuarioTxt()
        {

        }
        public string Identificacion { get; set; }
    }
}
