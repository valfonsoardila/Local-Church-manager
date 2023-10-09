using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class IglesiaService
    {
        private readonly ConnectionManager conexion;
        private readonly IglesiaRepository repositorio;
        public IglesiaService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new IglesiaRepository(conexion);
        }
        public string Guardar(Iglesia drogueria)
        {
            try
            {
                drogueria.GenerarIdIglesia();
                conexion.Open();
                if (repositorio.BuscarPorId(drogueria.NIT) == null)
                {
                    repositorio.Guardar(drogueria);
                    return $"Iglesia registrada correctamente";
                }
                return $"Esta id de drogueria ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaIglesiaRespuesta ConsultarTodos()
        {
            ConsultaIglesiaRespuesta respuesta = new ConsultaIglesiaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Iglesias = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Iglesias.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Iglesia drogueriaNueva)
        {
            try
            {
                conexion.Open();
                var drogueriaAntigua = repositorio.BuscarPorId(drogueriaNueva.IdIglesia);
                if (drogueriaAntigua != null)
                {
                    repositorio.Modificar(drogueriaNueva);
                    return ($"El registro de {drogueriaNueva.NIT} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, la iglesia con Id {drogueriaNueva.NIT} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public BusquedaIglesiaRespuesta BuscarPorId(string nit)
        {
            BusquedaIglesiaRespuesta respuesta = new BusquedaIglesiaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Iglesia = repositorio.BuscarPorId(nit);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Iglesia != null) ? "Se encontró la id de drogueria buscada" : "la id de drogueria buscada no existe";
                respuesta.Error = false;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }
        }
        public string Eliminar(string id)
        {
            try
            {
                conexion.Open();
                var drogueria = repositorio.BuscarPorId(id);
                if (drogueria != null)
                {
                    repositorio.Eliminar(drogueria);
                    conexion.Close();
                    return ($"El registro {drogueria.IdIglesia} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {id} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoIglesiaRespuesta Totalizar()
        {
            ConteoIglesiaRespuesta respuesta = new ConteoIglesiaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Cuenta = repositorio.Totalizar(); ;
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = "Se consultan los Datos";

                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }
        }
        public ConteoIglesiaRespuesta TotalizarTipo(string tipo)
        {
            ConteoIglesiaRespuesta respuesta = new ConteoIglesiaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Cuenta = repositorio.TotalizarTipo(tipo);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = "Se consultan los Datos";

                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }
        }
    }
    public class ConsultaIglesiaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Iglesia> Iglesias { get; set; }
    }
    public class BusquedaIglesiaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Iglesia Iglesia { get; set; }
    }
    public class ConteoIglesiaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
