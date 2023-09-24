using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class ApunteService
    {
        private readonly ConnectionManager conexion;
        private readonly ApunteRepository repositorio;
        public ApunteService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ApunteRepository(conexion);
        }
        public string Guardar(Apunte apunte)
        {
            try
            {
                apunte.GenerarIdNota();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(apunte.IdNota) == null)
                {
                    repositorio.Guardar(apunte);
                    return $"Apunte registrado correctamente";
                }
                return $"Esta id de apunte ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaApunteRespuesta ConsultarTodos()
        {
            ConsultaApunteRespuesta respuesta = new ConsultaApunteRespuesta();
            try
            {

                conexion.Open();
                respuesta.Apuntees = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Apuntees.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaApunteRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaApunteRespuesta respuesta = new BusquedaApunteRespuesta();
            try
            {

                conexion.Open();
                respuesta.Apunte = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Apunte != null) ? "Se encontró la id de apunte buscado" : "la id de apunte buscada no existe";
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
        //public BusquedaApunteRespuesta BuscarPorSexo(string sexo)
        //{
        //    BusquedaApunteRespuesta respuesta = new BusquedaApunteRespuesta();
        //    try
        //    {

        //        conexion.Open();
        //        respuesta.Apunte = repositorio.BuscarPorSexo(sexo);
        //        conexion.Close();
        //        respuesta.Mensaje = (respuesta.Apunte != null) ? "Se encontró la id de apunte buscado" : "la id de apunte buscada no existe";
        //        respuesta.Error = false;
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
        //public BusquedaApunteRespuesta BuscarPorRol(string rol)
        //{
        //    BusquedaApunteRespuesta respuesta = new BusquedaApunteRespuesta();
        //    try
        //    {

        //        conexion.Open();
        //        respuesta.Apunte = repositorio.BuscarPorRol(rol);
        //        conexion.Close();
        //        respuesta.Mensaje = (respuesta.Apunte != null) ? "Se encontró la id de apunte buscado" : "la id de apunte buscada no existe";
        //        respuesta.Error = false;
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
        //public BusquedaApunteRespuesta BuscarPorNombreDeUsuario(string nombreDeUsuario)
        //{
        //    BusquedaApunteRespuesta respuesta = new BusquedaApunteRespuesta();
        //    try
        //    {

        //        conexion.Open();
        //        respuesta.Apunte = repositorio.BuscarPorNombreDeUsuario(nombreDeUsuario);
        //        conexion.Close();
        //        respuesta.Mensaje = (respuesta.Apunte != null) ? "Se encontró la id de apunte buscado" : "la id de apunte buscada no existe";
        //        respuesta.Error = false;
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
        public string Eliminar(string identificacion)
        {
            try
            {
                conexion.Open();
                var apunte = repositorio.BuscarPorIdentificacion(identificacion);
                if (apunte != null)
                {
                    repositorio.Eliminar(apunte);
                    conexion.Close();
                    return ($"El registro {apunte.IdNota} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Apunte apunteNuevo)
        {
            try
            {
                apunteNuevo.GenerarIdNota();
                conexion.Open();
                var apunte = repositorio.BuscarPorIdentificacion(apunteNuevo.IdNota);
                if (apunte != null)
                {
                    repositorio.Modificar(apunteNuevo);
                    return ($"El registro de {apunteNuevo.IdNota} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el apunte con IdNota {apunteNuevo.IdNota} no se encuentra registrada.");
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
    public class ConsultaApunteRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Apunte> Apuntes { get; set; }
    }
    public class BusquedaApunteRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Apunte Apunte { get; set; }
    }
    public class ConteoApunteRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
