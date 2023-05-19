using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class UsuarioService
    {
        private readonly ConnectionManager conexion;
        private readonly UsuarioRepository repositorio;
        public UsuarioService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new UsuarioRepository(conexion);
        }
        public string Guardar(Usuario usuario)
        {
            try
            {
                usuario.GenerarCodigoUsuario();
                usuario.CalcularEdad();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(usuario.Identificacion) == null)
                {
                    repositorio.Guardar(usuario);
                    return $"Usuario registrado correctamente";
                }
                return $"Esta id de usuario ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaUsuarioRespuesta ConsultarTodos()
        {
            ConsultaUsuarioRespuesta respuesta = new ConsultaUsuarioRespuesta();
            try
            {

                conexion.Open();
                respuesta.Usuarios = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Usuarios.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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

        public ConsultaUsuarioRespuesta BuscarPorSexo(string sexo)
        {
            ConsultaUsuarioRespuesta respuesta = new ConsultaUsuarioRespuesta();
            try
            {

                conexion.Open();
                respuesta.Usuarios = repositorio.BuscarPorSexo(sexo);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Usuarios != null) ? "Se consulto el sexo buscado" : "el sexo consultado no existe";
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
        public BusquedaUsuarioRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaUsuarioRespuesta respuesta = new BusquedaUsuarioRespuesta();
            try
            {

                conexion.Open();
                respuesta.Usuario = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Usuario != null) ? "Se encontró la id de usuario buscado" : "la id de usuario buscada no existe";
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
        public BusquedaUsuarioRespuesta BuscarPorRol(string rol)
        {
            BusquedaUsuarioRespuesta respuesta = new BusquedaUsuarioRespuesta();
            try
            {

                conexion.Open();
                respuesta.Usuario = repositorio.BuscarPorRol(rol);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Usuario != null) ? "Se encontró la id de usuario buscado" : "la id de usuario buscada no existe";
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
        public BusquedaUsuarioRespuesta BuscarPorNombreDeUsuario(string nombreDeUsuario)
        {
            BusquedaUsuarioRespuesta respuesta = new BusquedaUsuarioRespuesta();
            try
            {

                conexion.Open();
                respuesta.Usuario = repositorio.BuscarPorNombreDeUsuario(nombreDeUsuario);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Usuario != null) ? "Se encontró la id de usuario buscado" : "la id de usuario buscada no existe";
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
                var usuario = repositorio.BuscarPorIdentificacion(identificacion);
                if (usuario != null)
                {
                    repositorio.Eliminar(usuario);
                    conexion.Close();
                    return ($"El registro {usuario.Identificacion} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Usuario usuarioNuevo)
        {
            try
            {
                usuarioNuevo.GenerarCodigoUsuario();
                usuarioNuevo.CalcularEdad();
                conexion.Open();
                var cajaRegistradora = repositorio.BuscarPorIdentificacion(usuarioNuevo.Identificacion);
                if (cajaRegistradora != null)
                {
                    repositorio.Modificar(usuarioNuevo);
                    return ($"El registro de {usuarioNuevo.Identificacion} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el usuario con Id {usuarioNuevo.Identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoUsuarioRespuesta Totalizar()
        {
            ConteoUsuarioRespuesta respuesta = new ConteoUsuarioRespuesta();
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
        public ConteoUsuarioRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoUsuarioRespuesta respuesta = new ConteoUsuarioRespuesta();
            try
            {

                conexion.Open();
                respuesta.Cuenta = repositorio.TotalizarTipoRol(tipo);
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
        public ConteoUsuarioRespuesta TotalizarTipo(string tipo)
        {
            ConteoUsuarioRespuesta respuesta = new ConteoUsuarioRespuesta();
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
    public class ConsultaUsuarioRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Usuario> Usuarios { get; set; }
    }
    public class BusquedaUsuarioRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }
    }
    public class ConteoUsuarioRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
