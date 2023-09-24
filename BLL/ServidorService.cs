using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServidorService
    {
        private readonly ConnectionManager conexion;
        private readonly ServidorRepository repositorio;
        public ServidorService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ServidorRepository(conexion);
        }
        public string Guardar(Servidor servidor)
        {
            try
            {
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(servidor.IdServidor) == null)
                {
                    repositorio.Guardar(servidor);
                    return $"Servidor registrado correctamente";
                }
                return $"Esta id de servidor ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaServidorRespuesta ConsultarTodos()
        {
            ConsultaServidorRespuesta respuesta = new ConsultaServidorRespuesta();
            try
            {

                conexion.Open();
                respuesta.Servidores = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Servidores.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaServidorRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaServidorRespuesta respuesta = new BusquedaServidorRespuesta();
            try
            {

                conexion.Open();
                respuesta.Servidor = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Servidor != null) ? "Se encontró la id de servidor buscado" : "la id de servidor buscada no existe";
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
        public string Eliminar(string identificacion)
        {
            try
            {
                conexion.Open();
                var servidor = repositorio.BuscarPorIdentificacion(identificacion);
                if (servidor != null)
                {
                    repositorio.Eliminar(servidor);
                    conexion.Close();
                    return ($"El registro {servidor.IdServidor} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Servidor servidorNuevo)
        {
            try
            {
                conexion.Open();
                var servidor = repositorio.BuscarPorIdentificacion(servidorNuevo.IdServidor);
                if (servidor != null)
                {
                    repositorio.Modificar(servidorNuevo);
                    return ($"El registro de {servidorNuevo.IdServidor} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el servidor con Id {servidorNuevo.IdServidor} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoServidorRespuesta Totalizar()
        {
            ConteoServidorRespuesta respuesta = new ConteoServidorRespuesta();
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
        public ConteoServidorRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoServidorRespuesta respuesta = new ConteoServidorRespuesta();
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
        public ConteoServidorRespuesta TotalizarTipo(string tipo)
        {
            ConteoServidorRespuesta respuesta = new ConteoServidorRespuesta();
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
    public class ConsultaServidorRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Servidor> Servidores { get; set; }
    }
    public class BusquedaServidorRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Servidor Servidor { get; set; }
    }
    public class ConteoServidorRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
