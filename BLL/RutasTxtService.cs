using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class RutasTxtService
    {
        private readonly RutasTxtRepository rutasTxtRepository;
        public RutasTxtService()
        {
            rutasTxtRepository = new RutasTxtRepository();
        }

        public string Guardar(RutasTxt rutasTxt)
        {
            try
            {
                rutasTxtRepository.Guardar(rutasTxt);
                return "Producto en txt registro Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Guardar:" + e.Message;
            }
        }

        public RutasTxtConsultaResponse Consultar()
        {
            try
            {
                return new RutasTxtConsultaResponse(rutasTxtRepository.Consultar());
            }
            catch (Exception e)
            {
                return new RutasTxtConsultaResponse("Error al Guardar:" + e.Message);
            }
        }
        public bool FiltroIdentificaiconFacturaCierreDeCajas(string referencia)
        {

            try
            {
                return (rutasTxtRepository.FiltroIdentificaiconFacturaCierreDeCajas(referencia));
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool FiltroIdentificaiconFacturaDeVentas(string referencia)
        {

            try
            {
                return (rutasTxtRepository.FiltroIdentificaiconFacturaDeVentas(referencia));
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public string ModificarRutasTxt(RutasTxt rutasTxt, string referencia)
        {
            try
            {
                rutasTxtRepository.ModificarRutasTxt(rutasTxt, referencia);
                return "Producto Modificado Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Modificar:" + e.Message;
            }
        }
        public string ModificarFacturaCierreDeCajas(RutasTxt rutasTxt, string referencia)
        {
            try
            {
                rutasTxtRepository.ModificarFacturaCierreDeCajas(rutasTxt, referencia);
                return "Producto Modificado Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Modificar:" + e.Message;
            }
        }
        public string ModificarFacturaDeVentas(RutasTxt rutasTxt, string referencia)
        {
            try
            {
                rutasTxtRepository.ModificarFacturaDeVentas(rutasTxt, referencia);
                return "Producto Modificado Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Modificar:" + e.Message;
            }
        }
        public string EliminarFacturaCierreDeCajas(string referencia)
        {
            try
            {
                rutasTxtRepository.EliminarFacturaCierreDeCajas(referencia);
                return "Producto Eliminada";
            }
            catch (Exception)
            {
                return ("Error al Eliminar");
            }
        }
        public string EliminarFacturaDeVentas(string referencia)
        {
            try
            {
                rutasTxtRepository.EliminarFacturaDeVentas(referencia);
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
                rutasTxtRepository.EliminarTodo();
                return "Productos de factura Eliminados";
            }
            catch (Exception)
            {
                return ("Error al Eliminar");
            }
        }
        public string Totalizar()
        {
            try
            {
                var Cuenta = rutasTxtRepository.Totalizar().ToString();
                return Cuenta;
            }
            catch (Exception e)
            {
                var respuesta = "No se encontraron registros";
                return respuesta;
            }
        }
    }
}
