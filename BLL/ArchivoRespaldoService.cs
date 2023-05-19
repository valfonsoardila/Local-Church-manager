using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class ArchivoRespaldoService
    {
        private readonly ArchivoRespaldoRepository archivoRespaldoRepository;
        public ArchivoRespaldoService()
        {
            archivoRespaldoRepository = new ArchivoRespaldoRepository();
        }

        public string Guardar(ArchivoRespaldo archivoRespaldo)
        {
            try
            {
                archivoRespaldoRepository.Guardar(archivoRespaldo);
                return "Producto en txt registro Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Guardar:" + e.Message;
            }
        }

        public ArchivoRespaldoConsultaResponse Consultar()
        {
            try
            {
                return new ArchivoRespaldoConsultaResponse(archivoRespaldoRepository.Consultar());
            }
            catch (Exception e)
            {
                return new ArchivoRespaldoConsultaResponse("Error al Guardar:" + e.Message);
            }
        }
        public bool FiltroIdentificaicon(string referencia)
        {
            try
            {
                return (archivoRespaldoRepository.FiltroIdentificaicon(referencia));
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public string Modificar(ArchivoRespaldo archivoRespaldo, string referencia)
        {
            try
            {
                archivoRespaldoRepository.Modificar(archivoRespaldo, referencia);
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
                archivoRespaldoRepository.Eliminar(referencia);
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
                archivoRespaldoRepository.EliminarTodo();
                return "Archivo eliminado satisfactoriamente";
            }
            catch (Exception)
            {
                return ("Error al Eliminar");
            }
        }
    }
}
