using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestoService
    {
        private readonly ConnectionManager conexion;
        private readonly PresupuestoRepository repositorio;
        public PresupuestoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new PresupuestoRepository(conexion);
        }
        public string Guardar(Presupuesto presupuesto)
        {
            try
            {
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(presupuesto.Id) == null)
                {
                    repositorio.Guardar(presupuesto);
                    return $"Presupuesto registrado correctamente";
                }
                return $"Esta id de presupuesto ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaPresupuestoRespuesta ConsultarTodos()
        {
            ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Presupuestos = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Presupuestos.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public BusquedaPresupuestoRespuesta BuscarPorIdentificacion(int id)
        {
            BusquedaPresupuestoRespuesta respuesta = new BusquedaPresupuestoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Presupuesto = repositorio.BuscarPorIdentificacion(id);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Presupuesto != null) ? "Se encontró la id de presupuesto buscado" : "la id de presupuesto buscada no existe";
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
        public ConsultaPresupuestoRespuesta FiltrarEgresosPorComite(string comite)
        {
            ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
            try
            {
                conexion.Open();
                respuesta.Presupuestos = repositorio.FiltrarPresupuestosPorComite(comite);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Presupuestos.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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

        public string Eliminar(int id)
        {
            try
            {
                conexion.Open();
                var presupuesto = repositorio.BuscarPorIdentificacion(id);
                if (presupuesto != null)
                {
                    repositorio.Eliminar(presupuesto);
                    conexion.Close();
                    return ($"El registro {presupuesto.Id} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {id} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public string Modificar(Presupuesto presupuestoNuevo)
        {
            try
            {
                conexion.Open();
                var presupuesto = repositorio.BuscarPorIdentificacion(presupuestoNuevo.Id);
                if (presupuesto != null)
                {
                    repositorio.Modificar(presupuestoNuevo);
                    return ($"El registro de {presupuestoNuevo.Id} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el presupuesto con IdContacto {presupuestoNuevo.Id} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConteoPresupuestoRespuesta Totalizar()
        {
            ConteoPresupuestoRespuesta respuesta = new ConteoPresupuestoRespuesta();
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
        public ConteoPresupuestoRespuesta TotalizarTipoRol(string tipo)
        {
            ConteoPresupuestoRespuesta respuesta = new ConteoPresupuestoRespuesta();
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
        public ConteoPresupuestoRespuesta TotalizarTipo(string tipo)
        {
            ConteoPresupuestoRespuesta respuesta = new ConteoPresupuestoRespuesta();
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
    public class ConsultaPresupuestoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Presupuesto> Presupuestos { get; set; }
    }
    public class BusquedaPresupuestoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Presupuesto Presupuesto { get; set; }
    }
    public class ConteoPresupuestoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
