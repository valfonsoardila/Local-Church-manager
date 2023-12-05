using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EnviableService
    {
        private readonly ConnectionManager conexion;
        private readonly EnviablesRepository repositorio;
        public EnviableService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new EnviablesRepository(conexion);
        }
        public string Guardar(Enviable enviable)
        {
            try
            {
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(enviable.Id) == null)
                {
                    repositorio.Guardar(enviable);
                    return $"Enviable registrado correctamente";
                }
                return $"Esta id de enviable ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaEnviableRespuesta ConsultarTodos()
        {
            ConsultaEnviableRespuesta respuesta = new ConsultaEnviableRespuesta();
            try
            {

                conexion.Open();
                respuesta.Enviables = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Enviables.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public ConsultaEnviableRespuesta FiltrarEnviablesPorComite(string comite)
        {
            ConsultaEnviableRespuesta respuesta = new ConsultaEnviableRespuesta();
            try
            {
                conexion.Open();
                respuesta.Enviables = repositorio.BuscarPorComite(comite);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Enviables.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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
        public ConsultaEnviableRespuesta FiltrarEnviablesPorConcepto(string concepto)
        {
            ConsultaEnviableRespuesta respuesta = new ConsultaEnviableRespuesta();
            try
            {
                conexion.Open();
                respuesta.Enviables = repositorio.BuscarPorConcepto(concepto);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Enviables.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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
        public ConsultaEnviableRespuesta FiltrarEnviablesPorFecha(string fecha)
        {
            ConsultaEnviableRespuesta respuesta = new ConsultaEnviableRespuesta();
            try
            {
                conexion.Open();
                respuesta.Enviables = repositorio.BuscarPorFecha(fecha);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Enviables.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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

        public BusquedaEnviableRespuesta BuscarPorIdentificacion(string comprobante)
        {
            BusquedaEnviableRespuesta respuesta = new BusquedaEnviableRespuesta();
            try
            {

                conexion.Open();
                respuesta.Enviable = repositorio.BuscarPorIdentificacion(comprobante);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Enviable != null) ? "Se encontró la id de enviable buscado" : "la id de enviable buscada no existe";
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
                var enviable = repositorio.BuscarPorIdentificacion(comprobante);
                if (enviable != null)
                {
                    repositorio.Eliminar(enviable);
                    conexion.Close();
                    return ($"El registro {enviable.Id} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {comprobante} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Enviable enviable)
        {
            try
            {
                conexion.Open();
                var enviableNuevo = repositorio.BuscarPorIdentificacion(enviable.Id);
                if (enviable != null)
                {
                    repositorio.Modificar(enviable);
                    return ($"El registro de {enviable.Id} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el enviable con IdNota {enviableNuevo.Id} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoEnviableRespuesta Totalizar()
        {
            ConteoEnviableRespuesta respuesta = new ConteoEnviableRespuesta();
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
        //public ConteoApunteRespuesta TotalizarTipo(string tipo)
        //{
        //    ConteoApunteRespuesta respuesta = new ConteoApunteRespuesta();
        //    try
        //    {

        //        conexion.Open();
        //        respuesta.Cuenta = repositorio.TotalizarTipo(tipo);
        //        conexion.Close();
        //        respuesta.Error = false;
        //        respuesta.Mensaje = "Se consultan los Datos";

        //        return respuesta;
        //    }
        //    catch (Exception e)
        //    {
        //        respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
        //        respuesta.Error = true;
        //        return respuesta;
        //    }
        //    finally { conexion.Close(); }
        //}

    }
    public class ConsultaEnviableRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Enviable> Enviables { get; set; }
    }
    public class BusquedaEnviableRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Enviable Enviable { get; set; }
    }
    public class ConteoEnviableRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
