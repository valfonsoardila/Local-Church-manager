using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class RutasTxtConsultaResponse
    {
        public List<RutasTxt> RutasTxts { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public bool Encontrado { get; set; }

        public RutasTxtConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }
        public RutasTxtConsultaResponse(List<RutasTxt> rutasTxts)
        {
            RutasTxts = new List<RutasTxt>();
            RutasTxts = rutasTxts;
            Encontrado = true;
        }
    }
}
