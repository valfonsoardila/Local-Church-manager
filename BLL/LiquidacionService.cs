using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionService
    {
        private readonly ConnectionManager conexion;
        private readonly LiquidacionesRepository repositorio;
        public LiquidacionService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new LiquidacionesRepository(conexion);
        }
        public string Guardar(Liquidacion liquidacion)
        {
            try
            {
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(liquidacion.Id) == null)
                {
                    repositorio.Guardar(liquidacion);
                    return $"Liquidacion registrado correctamente";
                }
                return $"Esta id de liquidacion ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaLiquidacionRespuesta ConsultarTodos()
        {
            ConsultaLiquidacionRespuesta respuesta = new ConsultaLiquidacionRespuesta();
            try
            {

                conexion.Open();
                respuesta.Liquidaciones = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Liquidaciones.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public ConsultaLiquidacionRespuesta FiltrarLiquidacionPorFecha(string fecha)
        {
            ConsultaLiquidacionRespuesta respuesta = new ConsultaLiquidacionRespuesta();
            try
            {
                conexion.Open();
                respuesta.Liquidaciones = repositorio.BuscarPorFecha(fecha);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Liquidaciones.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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

        public BusquedaLiquidacionRespuesta BuscarPorIdentificacion(string comprobante)
        {
            BusquedaLiquidacionRespuesta respuesta = new BusquedaLiquidacionRespuesta();
            try
            {

                conexion.Open();
                respuesta.Liquidacion = repositorio.BuscarPorIdentificacion(comprobante);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Liquidacion != null) ? "Se encontró la id de liquidacion buscado" : "la id de liquidacion buscada no existe";
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
        public string Eliminar(string comprobante)
        {
            try
            {
                conexion.Open();
                var liquidacion = repositorio.BuscarPorIdentificacion(comprobante);
                if (liquidacion != null)
                {
                    repositorio.Eliminar(liquidacion);
                    conexion.Close();
                    return ($"El registro {liquidacion.Id} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {comprobante} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Liquidacion liquidacion)
        {
            try
            {
                conexion.Open();
                var liquidacionNueva = repositorio.BuscarPorIdentificacion(liquidacion.Id);
                if (liquidacion != null)
                {
                    repositorio.Modificar(liquidacion);
                    return ($"El registro de {liquidacion.Id} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el liquidacion con IdNota {liquidacionNueva.Id} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoLiquidacionRespuesta Totalizar()
        {
            ConteoLiquidacionRespuesta respuesta = new ConteoLiquidacionRespuesta();
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
    }
    public class ConsultaLiquidacionRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Liquidacion> Liquidaciones { get; set; }
    }
    public class BusquedaLiquidacionRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Liquidacion Liquidacion { get; set; }
    }
    public class ConteoLiquidacionRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
