using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Email
    {
        public Email(string correoElectronicoOrigen, string correoElectronicoDestino, string contraseña)
        {
            CorreoElectronicoOrigen = correoElectronicoOrigen;
            CorreoElectronicoDestino = correoElectronicoDestino;
            Contraseña = contraseña;
        }
        public Email()
        {

        }
        public string CorreoElectronicoOrigen { get; set; }
        public string CorreoElectronicoDestino { get; set; }
        public string Contraseña { get; set; }
    }
}
