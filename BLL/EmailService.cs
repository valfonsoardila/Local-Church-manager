using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class EmailService
    {
        private readonly EmailRepository EmailRepository;
        public EmailService()
        {
            EmailRepository = new EmailRepository();
        }

        public string Guardar(Email email)
        {
            try
            {
                EmailRepository.Guardar(email);
                return "Producto en txt registro Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Guardar:" + e.Message;
            }
        }

        public EmailConsultaResponse Consultar()
        {
            try
            {
                return new EmailConsultaResponse(EmailRepository.Consultar());
            }
            catch (Exception e)
            {
                return new EmailConsultaResponse("Error al Guardar:" + e.Message);
            }
        }

        public bool FiltroCorreo(string referencia)
        {
            try
            {
                return (EmailRepository.FiltroCorreo(referencia));
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public string ModificarEmail(Email Email, string correo)
        {
            try
            {
                EmailRepository.Modificar(Email, correo);
                return "Producto Modificado Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Modificar:" + e.Message;
            }
        }
        public string Eliminar(string referencia)
        {
            try
            {
                EmailRepository.Eliminar(referencia);
                return "Producto Eliminada";
            }
            catch (Exception)
            {
                return ("Error al Eliminar");
            }
        }
        public string EliminarHistorial()
        {
            try
            {
                EmailRepository.EliminarTodo();
                return "Productos de factura Eliminados";
            }
            catch (Exception)
            {
                return ("Error al Eliminar");
            }
        }
    }
}
