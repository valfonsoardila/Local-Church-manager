using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReunionService
    {
        private readonly ConnectionManager conexion;
        private readonly ReunionRepository repositorio;
        public ReunionService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ReunionRepository(conexion);
        }
        public string Guardar(Reunion reunion)
        {
            try
            {
                reunion.GenerarNumeroActa();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(reunion.NumeroActa) == null)
                {
                    repositorio.Guardar(reunion);
                    return $"Reunion registrado correctamente";
                }
                return $"Esta id de reunion ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaReunionRespuesta ConsultarTodos()
        {
            ConsultaReunionRespuesta respuesta = new ConsultaReunionRespuesta();
            try
            {

                conexion.Open();
                respuesta.Reuniones = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Reuniones.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaReunionRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaReunionRespuesta respuesta = new BusquedaReunionRespuesta();
            try
            {

                conexion.Open();
                respuesta.Reunion = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Reunion != null) ? "Se encontró la id de reunion buscado" : "la id de reunion buscada no existe";
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
                var reunion = repositorio.BuscarPorIdentificacion(identificacion);
                if (reunion != null)
                {
                    repositorio.Eliminar(reunion);
                    conexion.Close();
                    return ($"El registro {reunion.NumeroActa} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Reunion reunionNuevo)
        {
            try
            {
                reunionNuevo.GenerarNumeroActa();
                conexion.Open();
                var reunion = repositorio.BuscarPorIdentificacion(reunionNuevo.NumeroActa);
                if (reunion != null)
                {
                    repositorio.Modificar(reunionNuevo);
                    return ($"El registro de {reunionNuevo.NumeroActa} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el reunion con Id {reunionNuevo.NumeroActa} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoReunionRespuesta Totalizar()
        {
            ConteoReunionRespuesta respuesta = new ConteoReunionRespuesta();
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
        public ConteoReunionRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoReunionRespuesta respuesta = new ConteoReunionRespuesta();
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
        public ConteoReunionRespuesta TotalizarTipo(string tipo)
        {
            ConteoReunionRespuesta respuesta = new ConteoReunionRespuesta();
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
    public class ConsultaReunionRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Reunion> Reuniones { get; set; }
    }
    public class BusquedaReunionRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Reunion Reunion { get; set; }
    }
    public class ConteoReunionRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
