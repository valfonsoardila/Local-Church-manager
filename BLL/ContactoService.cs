using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class ContactoService
    {
        private readonly ConnectionManager conexion;
        private readonly ContactoRepository repositorio;
        public ContactoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ContactoRepository(conexion);
        }
        public string Guardar(Contacto contacto)
        {
            try
            {
                contacto.GenerarId();
                contacto.GenerarWhatsapp();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(contacto.IdContacto) == null)
                {
                    repositorio.Guardar(contacto);
                    return $"Contacto registrado correctamente";
                }
                return $"Esta id de contacto ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaContactoRespuesta ConsultarTodos()
        {
            ConsultaContactoRespuesta respuesta = new ConsultaContactoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Contactos = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Contactos.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaContactoRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaContactoRespuesta respuesta = new BusquedaContactoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Contacto = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Contacto != null) ? "Se encontró la id de contacto buscado" : "la id de contacto buscada no existe";
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
                var contacto = repositorio.BuscarPorIdentificacion(identificacion);
                if (contacto != null)
                {
                    repositorio.Eliminar(contacto);
                    conexion.Close();
                    return ($"El registro {contacto.IdContacto} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Contacto contactoNuevo)
        {
            try
            {
                contactoNuevo.GenerarId();
                contactoNuevo.GenerarWhatsapp();
                conexion.Open();
                var contacto = repositorio.BuscarPorIdentificacion(contactoNuevo.IdContacto);
                if (contacto != null)
                {
                    repositorio.Modificar(contactoNuevo);
                    return ($"El registro de {contactoNuevo.IdContacto} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el contacto con IdContacto {contactoNuevo.IdContacto} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoContactoRespuesta Totalizar()
        {
            ConteoContactoRespuesta respuesta = new ConteoContactoRespuesta();
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
        public ConteoContactoRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoContactoRespuesta respuesta = new ConteoContactoRespuesta();
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
        public ConteoContactoRespuesta TotalizarTipo(string tipo)
        {
            ConteoContactoRespuesta respuesta = new ConteoContactoRespuesta();
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
    public class ConsultaContactoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Contacto> Contactos { get; set; }
    }
    public class BusquedaContactoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Contacto Contacto { get; set; }
    }
    public class ConteoContactoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
