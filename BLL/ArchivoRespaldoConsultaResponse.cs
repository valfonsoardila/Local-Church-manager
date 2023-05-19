using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class ArchivoRespaldoConsultaResponse
    {
        public List<ArchivoRespaldo> ArchivoRespaldos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public bool Encontrado { get; set; }

        public ArchivoRespaldoConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }
        public ArchivoRespaldoConsultaResponse(List<ArchivoRespaldo> archivoRespaldos)
        {
            ArchivoRespaldos = new List<ArchivoRespaldo>();
            ArchivoRespaldos = archivoRespaldos;
            Encontrado = true;
        }
    }
}
