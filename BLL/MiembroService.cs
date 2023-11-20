using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MiembroService
    {
        private readonly ConnectionManager conexion;
        private readonly MiembroRepository repositorio;
        public MiembroService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new MiembroRepository(conexion);
        }
        public string Guardar(Miembro miembro)
        {
            try
            {
                miembro.CalcularEdad();
                miembro.CalcularTiempoDeConversion();
                miembro.CalculartTiempoDePromesa();
                miembro.CalcularTiempoDeCorrecion();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(miembro.Folio) == null)
                {
                    repositorio.Guardar(miembro);
                    return $"Miembro registrado correctamente";
                }
                return $"Esta id de miembro ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaMiembroRespuesta ConsultarTodos()
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            try
            {

                conexion.Open();
                respuesta.Miembros = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Miembros.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaMiembroRespuesta BuscarPorGenero(string genero)
        {
            BusquedaMiembroRespuesta respuesta = new BusquedaMiembroRespuesta();
            try
            {

                conexion.Open();
                respuesta.Miembro = repositorio.BuscarPorgnero(genero);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Miembro != null) ? "Se encontró la id de miembro buscado" : "la id de miembro buscada no existe";
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
        public ConsultaMiembroRespuesta BuscarPorFamilia(string familia)
        {
            ConsultaMiembroRespuesta respuesta = new ConsultaMiembroRespuesta();
            try
            {

                conexion.Open();
                respuesta.Miembros = repositorio.BuscarPorFamilia(familia);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Miembros != null) ? "Se consulto el estante buscado" : "el estante consultado no existe";
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
        public BusquedaMiembroRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaMiembroRespuesta respuesta = new BusquedaMiembroRespuesta();
            try
            {

                conexion.Open();
                respuesta.Miembro = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Miembro != null) ? "Se encontró la id de miembro buscado" : "la id de miembro buscada no existe";
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
                var miembro = repositorio.BuscarPorIdentificacion(identificacion);
                if (miembro != null)
                {
                    repositorio.Eliminar(miembro);
                    conexion.Close();
                    return ($"El registro {miembro.Folio} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Miembro miembroNuevo)
        {
            try
            {
                miembroNuevo.CalcularTiempoDeConversion();
                miembroNuevo.CalculartTiempoDePromesa();
                miembroNuevo.CalcularTiempoDeCorrecion();
                conexion.Open();
                var miembroAntiguo = repositorio.BuscarPorIdentificacion(miembroNuevo.Folio);
                if (miembroAntiguo != null)
                {
                    repositorio.Modificar(miembroNuevo);
                    return ($"El registro de {miembroNuevo.Folio} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el miembro con Id {miembroNuevo.Folio} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoMiembroRespuesta Totalizar()
        {
            ConteoMiembroRespuesta respuesta = new ConteoMiembroRespuesta();
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
        public ConteoMiembroRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoMiembroRespuesta respuesta = new ConteoMiembroRespuesta();
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
        public ConteoMiembroRespuesta TotalizarTipo(string tipo)
        {
            ConteoMiembroRespuesta respuesta = new ConteoMiembroRespuesta();
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
    public class ConsultaMiembroRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Miembro> Miembros { get; set; }
    }
    public class BusquedaMiembroRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Miembro Miembro { get; set; }
    }
    public class ConteoMiembroRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
