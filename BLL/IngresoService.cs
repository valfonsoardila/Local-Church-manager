using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IngresoService
    {
        private readonly ConnectionManager conexion;
        private readonly IngresoRepository repositorio;
        public IngresoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new IngresoRepository(conexion);
        }
        public string Guardar(Ingreso ingreso)
        {
            try
            {
                conexion.Open();
                if (repositorio.BuscarPorIdentificacion(ingreso.CodigoComprobante) == null)
                {
                    repositorio.Guardar(ingreso);
                    return $"Ingreso registrado correctamente";
                }
                return $"Esta id de ingreso ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
        public ConsultaIngresoRespuesta ConsultarTodos()
        {
            ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Ingresos = repositorio.ConsultarTodos();
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Ingresos.Count > 0) ? "Se consultan los Datos" : "No hay datos para consultar";
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
        public ConsultaIngresoRespuesta FiltrarIngresosPorComite(string comite)
        {
            ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
            try
            {
                conexion.Open();
                respuesta.Ingresos = repositorio.FiltrarIngresosPorComite(comite);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Ingresos.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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
        public ConsultaIngresoRespuesta FiltrarIngresosPorConcepto(string concepto)
        {
            ConsultaIngresoRespuesta respuesta = new ConsultaIngresoRespuesta();
            try
            {
                conexion.Open();
                respuesta.Ingresos = repositorio.FiltrarIngresosPorConcepto(concepto);
                conexion.Close();
                respuesta.Error = false;
                respuesta.Mensaje = (respuesta.Ingresos.Count > 0) ? "Se filtraron los Datos concordantes" : "No hay datos para consultar";
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
        public BusquedaIngresoRespuesta BuscarPorIdentificacion(string comprobante)
        {
            BusquedaIngresoRespuesta respuesta = new BusquedaIngresoRespuesta();
            try
            {

                conexion.Open();
                respuesta.Ingreso = repositorio.BuscarPorIdentificacion(comprobante);
                conexion.Close();
                respuesta.Mensaje = (respuesta.Ingreso != null) ? "Se encontró la id de ingreso buscado" : "la id de ingreso buscada no existe";
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
        public string Eliminar(string comprobante)
        {
            try
            {
                conexion.Open();
                var ingreso = repositorio.BuscarPorIdentificacion(comprobante);
                if (ingreso != null)
                {
                    repositorio.Eliminar(ingreso);
                    conexion.Close();
                    return ($"El registro {ingreso.CodigoComprobante} se ha eliminado satisfactoriamente.");
                }
                return ($"Lo sentimos, {comprobante} no se encuentra registrada.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Modificar(Ingreso ingreso)
        {
            try
            {
                conexion.Open();
                var ingresoNuevo = repositorio.BuscarPorIdentificacion(ingreso.CodigoComprobante);
                if (ingreso != null)
                {
                    repositorio.Modificar(ingreso);
                    return ($"El registro de {ingresoNuevo.CodigoComprobante} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el ingreso con IdNota {ingresoNuevo.CodigoComprobante} no se encuentra registrada.");
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
    public class ConsultaIngresoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Ingreso> Ingresos { get; set; }
    }
    public class BusquedaIngresoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Ingreso Ingreso { get; set; }
    }
    public class ConteoIngresoRespuesta
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Cuenta { get; set; }
    }
}
