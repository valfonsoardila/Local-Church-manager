using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class DirectivaService
    {
        private readonly ConnectionManager conexion;
        private readonly DirectivaRepository repositorio;
        public DirectivaService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new DirectivaRepository(conexion);
        }
        public string Guardar(Directiva directiva)
        {
            try
            {
                directiva.GenerarIdDirectiva();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(directiva.IdDirectiva) == null)
                {
                    repositorio.Guardar(directiva);
                    return $"Directiva registrado correctamente";
                }
                return $"Esta id de directiva ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaDirectivaRespuesta ConsultarTodos()
        {
            ConsultaDirectivaRespuesta respuesta = new ConsultaDirectivaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Directivas = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Directivas.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaDirectivaRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaDirectivaRespuesta respuesta = new BusquedaDirectivaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Directiva = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Directiva != null) ? "Se encontró la id de directiva buscado" : "la id de directiva buscada no existe";
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
                var directiva = repositorio.BuscarPorIdentificacion(identificacion);
                if (directiva != null)
                {
                    repositorio.Eliminar(directiva);
                    conexion.Close();
                    return ($"El registro {directiva.IdDirectiva} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Directiva directivaNueva)
        {
            try
            {      
                conexion.Open();
                var directiva = repositorio.BuscarPorIdentificacion(directivaNueva.IdDirectiva);
                if (directiva != null)
                {
                    repositorio.Modificar(directivaNueva);
                    return ($"El registro de {directivaNueva.IdDirectiva} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el directiva con IdDirectiva {directivaNueva.IdDirectiva} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoDirectivaRespuesta Totalizar()
        {
            ConteoDirectivaRespuesta respuesta = new ConteoDirectivaRespuesta();
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
        public ConteoDirectivaRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoDirectivaRespuesta respuesta = new ConteoDirectivaRespuesta();
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
        public ConteoDirectivaRespuesta TotalizarTipo(string tipo)
        {
            ConteoDirectivaRespuesta respuesta = new ConteoDirectivaRespuesta();
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
    public class ConsultaDirectivaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Directiva> Directivas { get; set; }
    }
    public class BusquedaDirectivaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Directiva Directiva { get; set; }
    }
    public class ConteoDirectivaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
