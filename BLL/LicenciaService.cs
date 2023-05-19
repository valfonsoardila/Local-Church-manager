using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class LicenciaService
    {
        private readonly ConnectionManager conexion;
        private readonly LicenciaRepository repositorio;
        public LicenciaService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new LicenciaRepository(conexion);
        }
        public string Guardar(Licencia licencia)
        {
            try
            {
                conexion.Open();
                if (repositorio.BuscarPorLicencia(licencia.LicenciaSoftware) == null)
                {
                    repositorio.Guardar(licencia);
                    return $"Licencia registrado correctamente";
                }
                return $"Esta id de licencia ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaLicenciaRespuesta ConsultaTodasLicencias(string licenciaSoftware)
        {
            ConsultaLicenciaRespuesta respuesta = new ConsultaLicenciaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Licencias = repositorio.BuscarPorLicencias(licenciaSoftware);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Licencias != null) ? "Se consulto el estante buscado" : "el estante consultado no existe";
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
        public BusquedaLicenciaRespuesta BuscarPorLicencia(string identificacion)
        {
            BusquedaLicenciaRespuesta respuesta = new BusquedaLicenciaRespuesta();
            try
            {

                conexion.Open();
                respuesta.Licencia = repositorio.BuscarPorLicencia(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Licencia != null) ? "Se encontró la id de licencia buscado" : "la id de licencia buscada no existe";
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
        public string Eliminar(string licenciaSoftware)
        {
            try
            {
                conexion.Open();
                var licencia = repositorio.BuscarPorLicencia(licenciaSoftware);
                if (licencia != null)
                {
                    repositorio.Eliminar(licencia);
                    conexion.Close();
                    return ($"La licencia {licencia.LicenciaSoftware} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos la licencia, {licenciaSoftware} no es valida.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Licencia licenciaNuevo)
        {
            try
            {
                conexion.Open();
                var licencia = repositorio.BuscarPorLicencia(licenciaNuevo.LicenciaSoftware);
                if (licencia != null)
                {
                    repositorio.Modificar(licenciaNuevo);
                    return ($"La licencia {licencia.LicenciaSoftware} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el licencia con Id {licenciaNuevo.LicenciaSoftware} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoLicenciaRespuesta Totalizar()
        {
            ConteoLicenciaRespuesta respuesta = new ConteoLicenciaRespuesta();
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
        public ConteoLicenciaRespuesta TotalizarTipo(string tipo)
        {
            ConteoLicenciaRespuesta respuesta = new ConteoLicenciaRespuesta();
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
    public class ConsultaLicenciaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Licencia> Licencias { get; set; }
    }
    public class BusquedaLicenciaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Licencia Licencia { get; set; }
    }
    public class ConteoLicenciaRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
