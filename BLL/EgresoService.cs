using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EgresoService
    {
        private readonly ConnectionManager conexion;
        private readonly EgresoRepository repositorio;
        public EgresoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new EgresoRepository(conexion);
        }
        public string Guardar(Egreso egreso)
        {
            try
            {
                //egreso.GenerarIdNota();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(egreso.CodigoComprobante) == null)
                {
                    repositorio.Guardar(egreso);
                    return $"Egreso registrado correctamente";
                }
                return $"Esta id de egreso ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaEgresoRespuesta ConsultarTodos()
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Egresos = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Egresos.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public ConsultaEgresoRespuesta FiltrarIngresosPorComite(string comite)
        {
            ConsultaEgresoRespuesta respuesta = new ConsultaEgresoRespuesta();
            try
            {
                conexion.Open();
                respuesta.Egresos = repositorio.FiltrarIngresosPorComite(comite);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Egresos.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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
        public BusquedaEgresoRespuesta BuscarPorIdentificacion(string comprobante)
        {
            BusquedaEgresoRespuesta respuesta = new BusquedaEgresoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Egreso = repositorio.BuscarPorIdentificacion(comprobante);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Egreso != null) ? "Se encontró la id de egreso buscado" : "la id de egreso buscada no existe";
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
                var egreso = repositorio.BuscarPorIdentificacion(comprobante);
                if (egreso != null)
                {
                    repositorio.Eliminar(egreso);
                    conexion.Close();
                    return ($"El registro {egreso.CodigoComprobante} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {comprobante} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Egreso egreso)
        {
            try
            {
                conexion.Open();
                var egresoNuevo = repositorio.BuscarPorIdentificacion(egreso.CodigoComprobante);
                if (egreso != null)
                {
                    repositorio.Modificar(egresoNuevo);
                    return ($"El registro de {egresoNuevo.CodigoComprobante} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el egreso con IdNota {egresoNuevo.CodigoComprobante} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoApunteRespuesta Totalizar()
        {
            ConteoApunteRespuesta respuesta = new ConteoApunteRespuesta();
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
        public ConteoApunteRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoApunteRespuesta respuesta = new ConteoApunteRespuesta();
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
        public ConteoApunteRespuesta TotalizarTipo(string tipo)
        {
            ConteoApunteRespuesta respuesta = new ConteoApunteRespuesta();
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
    public class ConsultaEgresoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Egreso> Egresos { get; set; }
    }
    public class BusquedaEgresoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Egreso Egreso { get; set; }
    }
    public class ConteoEgresoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
