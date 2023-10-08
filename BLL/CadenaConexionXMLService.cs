using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class CadenaConexionXMLService
    {
        private readonly CadenaConexionXMLRepository cadenaConexionRepository;
        public CadenaConexionXMLService()
        {
            cadenaConexionRepository = new CadenaConexionXMLRepository();
        }
        public string Consultar()
        {
            try
            {
                List<CadenaConexionXML> appConfig = cadenaConexionRepository.Consultar();
                string cadenaConvertida = appConfig[8].Cadena;
                return cadenaConvertida;
            }
            catch (Exception e)
            {
                // Manejo de excepciones aquí, si es necesario
                // Puedes lanzar una excepción personalizada o manejarla de otra manera
                throw e;
            }
        }
        public string Modificar(CadenaConexionXML cadenaConexion, string oldServer, string ui)
        {
            try
            {
                cadenaConexionRepository.Modificar(cadenaConexion, oldServer, ui);
                return "Producto en txt registro Satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error al Guardar:" + e.Message;
            }
        }
    }
}
