using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IdUsuarioTxt
    {
        public IdUsuarioTxt(string identificacion, string rol)
        {
            Identificacion = identificacion;
            Rol = rol;
        }
        public IdUsuarioTxt()
        {

        }
        public string Identificacion { get; set; }
        public string Rol { get; set; }
    }
}
