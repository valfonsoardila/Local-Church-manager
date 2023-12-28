using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SimpatizanteService
    {
        private readonly ConnectionManager conexion;
        private readonly SimpatizanteRepository repositorio;
        public SimpatizanteService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new SimpatizanteRepository(conexion);
        }
        public string Guardar(Simpatizante simpatizante)
        {
            try
            {
                simpatizante.CalcularEdad();
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(simpatizante.NumeroDoc) == null)
                {
                    repositorio.Guardar(simpatizante);
                    return $"Simpatizante registrado correctamente";
                }
                return $"Esta id de simpatizante ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaSimpatizanteRespuesta ConsultarTodos()
        {
            ConsultaSimpatizanteRespuesta respuesta = new ConsultaSimpatizanteRespuesta();
            try
            {

                conexion.Open();
                respuesta.Simpatizantes = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Simpatizantes.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaSimpatizanteRespuesta BuscarPorGenero(string genero)
        {
            BusquedaSimpatizanteRespuesta respuesta = new BusquedaSimpatizanteRespuesta();
            try
            {

                conexion.Open();
                respuesta.Simpatizante = repositorio.BuscarPorgnero(genero);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Simpatizante != null) ? "Se encontró la id de simpatizante buscado" : "la id de simpatizante buscada no existe";
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
        public ConsultaSimpatizanteRespuesta BuscarPorFamilia(string familia)
        {
            ConsultaSimpatizanteRespuesta respuesta = new ConsultaSimpatizanteRespuesta();
            try
            {

                conexion.Open();
                respuesta.Simpatizantes = repositorio.BuscarPorFamilia(familia);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Simpatizantes != null) ? "Se consulto el estante buscado" : "el estante consultado no existe";
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
        public BusquedaSimpatizanteRespuesta BuscarPorIdentificacion(string identificacion)
        {
            BusquedaSimpatizanteRespuesta respuesta = new BusquedaSimpatizanteRespuesta();
            try
            {

                conexion.Open();
                respuesta.Simpatizante = repositorio.BuscarPorIdentificacion(identificacion);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Simpatizante != null) ? "Se encontró la id de simpatizante buscado" : "la id de simpatizante buscada no existe";
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
                var simpatizante = repositorio.BuscarPorIdentificacion(identificacion);
                if (simpatizante != null)
                {
                    repositorio.Eliminar(simpatizante);
                    conexion.Close();
                    return ($"El registro {simpatizante.NumeroDoc} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Simpatizante simpatizanteNuevo)
        {
            try
            {
                conexion.Open();
                var simpatizanteAntiguo = repositorio.BuscarPorIdentificacion(simpatizanteNuevo.NumeroDoc);
                if (simpatizanteAntiguo != null)
                {
                    repositorio.Modificar(simpatizanteNuevo);
                    return ($"El registro de {simpatizanteNuevo.NumeroDoc} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el simpatizante con Id {simpatizanteNuevo.NumeroDoc} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoSimpatizanteRespuesta Totalizar()
        {
            ConteoSimpatizanteRespuesta respuesta = new ConteoSimpatizanteRespuesta();
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
        public ConteoSimpatizanteRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoSimpatizanteRespuesta respuesta = new ConteoSimpatizanteRespuesta();
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
        public ConteoSimpatizanteRespuesta TotalizarTipo(string tipo)
        {
            ConteoSimpatizanteRespuesta respuesta = new ConteoSimpatizanteRespuesta();
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
    public class ConsultaSimpatizanteRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Simpatizante> Simpatizantes { get; set; }
    }
    public class BusquedaSimpatizanteRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Simpatizante Simpatizante { get; set; }
    }
    public class ConteoSimpatizanteRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
