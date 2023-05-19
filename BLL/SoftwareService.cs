using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class SoftwareService
    {
        private readonly ConnectionManager conexion;
        private readonly SoftwareRepository repositorio;
        public SoftwareService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new SoftwareRepository(conexion);
        }
        public string Guardar(Software software)
        {
            try
            {
                software.ObtenerFechaDeActivacion();
                software.ObtenerFechaDeCaducidad();
                software.ValidarEStadoLicencia();
                conexion.Open();
                if (repositorio.BuscarPorNombreDeSoftware(software.NombreDeSoftware) == null)
                {
                    repositorio.Guardar(software);
                    return $"Software registrado correctamente";
                }
                return $"Esta id de software ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaSoftwareRespuesta ConsultarTodos()
        {
            ConsultaSoftwareRespuesta respuesta = new ConsultaSoftwareRespuesta();
            try
            {

                conexion.Open();
                respuesta.Softwares = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Softwares.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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

        public BusquedaSoftwareRespuesta BuscarPorNombreDeSoftware(string nombre)
        {
            BusquedaSoftwareRespuesta respuesta = new BusquedaSoftwareRespuesta();
            try
            {

                conexion.Open();
                respuesta.Software = repositorio.BuscarPorNombreDeSoftware(nombre);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Software != null) ? "Se consulto el sexo buscado" : "el sexo consultado no existe";
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
        public ConsultaSoftwareRespuesta ConsultarPorNombreDeSoftware(string nombre)
        {
            ConsultaSoftwareRespuesta respuesta = new ConsultaSoftwareRespuesta();
            try
            {

                conexion.Open();
                respuesta.Softwares = repositorio.ConsultarPorNombreDeSoftware(nombre);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Softwares != null) ? "Se encontró la id de software buscado" : "la id de software buscada no existe";
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
        public string Eliminar(string nombre)
        {
            try
            {
                conexion.Open();
                var software = repositorio.BuscarPorNombreDeSoftware(nombre);
                if (software != null)
                {
                    repositorio.Eliminar(software);
                    conexion.Close();
                    return ($"El registro {software.NombreDeSoftware} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {nombre} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Software softwareNuevo)
        {
            try
            {
                softwareNuevo.ValidarEStadoLicencia();
                conexion.Open();
                var software = repositorio.BuscarPorNombreDeSoftware(softwareNuevo.NombreDeSoftware);
                if (software != null)
                {
                    repositorio.Modificar(softwareNuevo);
                    return ($"El registro de {softwareNuevo.NombreDeSoftware} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el software con Id {softwareNuevo.NombreDeSoftware} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoSoftwareRespuesta Totalizar()
        {
            ConteoSoftwareRespuesta respuesta = new ConteoSoftwareRespuesta();
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
        public ConteoSoftwareRespuesta TotalizarTipo(string tipo)
        {
            ConteoSoftwareRespuesta respuesta = new ConteoSoftwareRespuesta();
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
    public class ConsultaSoftwareRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Software> Softwares { get; set; }
    }
    public class BusquedaSoftwareRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Software Software { get; set; }
    }
    public class ConteoSoftwareRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
