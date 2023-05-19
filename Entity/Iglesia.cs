using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Iglesia
    {
        public Iglesia(string idIglesia, string nombreIglesia, string nit, string codigoDeCamara, string fraseDistintiva, string regimen,  string pbx, string direccion, string telefono)
        {
            IdIglesia = idIglesia;
            NombreIglesia = nombreIglesia;
            NIT = nit;
            CodigoDeCamara = codigoDeCamara;
            FraseDistintiva = fraseDistintiva;
            Regimen = regimen;
            PBX = pbx;
            Direccion = direccion;
            Telefono = telefono;
        }
        public Iglesia()
        {

        }
        public string IdIglesia { get; set; }
        public string NombreIglesia { get; set; }
        public string NIT { get; set; }
        public string CodigoDeCamara { get; set; }
        public string FraseDistintiva { get; set; }
        public string Regimen { get; set; }
        public string PBX { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public void GenerarIdIglesia()
        {
            IdIglesia = "#Iglesia";
        }
    }
}
