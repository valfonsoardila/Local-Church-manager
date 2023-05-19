using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class EmailConsultaResponse
    {
        public List<Email> Emails { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public bool Encontrado { get; set; }

        public EmailConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }
        public EmailConsultaResponse(List<Email> emails)
        {
            Emails = new List<Email>();
            Emails = emails;
            Encontrado = true;
        }
    }
}
