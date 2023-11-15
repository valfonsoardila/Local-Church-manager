using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using System.Data;

namespace DAL
{
    public class IngresoRepository
    {
        private readonly SqlConnection _connection;
        public IngresoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Ingreso ingreso)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into INGRESO(CodigoComprobante, FechaDeIngreso, Comite, Concepto, Valor, Detalle) Values (@CodigoComprobante, @FechaDeIngreso, @Comite, @Concepto, @Valor, @Detalle)";
                command.Parameters.AddWithValue("@CodigoComprobante", ingreso.CodigoComprobante);
                command.Parameters.AddWithValue("@FechaDeIngreso", ingreso.FechaDeIngreso);
                command.Parameters.AddWithValue("@Comite", ingreso.Comite);
                command.Parameters.AddWithValue("@Concepto", ingreso.Concepto);
                command.Parameters.AddWithValue("@Valor", ingreso.Valor);
                command.Parameters.AddWithValue("@Detalle", ingreso.Detalle);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Ingreso ingreso)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from INGRESO where CodigoComprobante=@CodigoComprobante";
                command.Parameters.AddWithValue("@CodigoComprobante", ingreso.CodigoComprobante);
                command.ExecuteNonQuery();
            }
        }
        public List<Ingreso> ConsultarTodos()
        {
            List<Ingreso> ingresos = new List<Ingreso>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select CodigoComprobante, FechaDeIngreso, Comite, Concepto, Valor, Detalle from INGRESO ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Ingreso ingreso = DataReaderMapToIngreso(dataReader);
                        ingresos.Add(ingreso);
                    }
                }
            }
            return ingresos;
        }
        public List<Ingreso> FiltrarIngresosPorComite(string comite)
        {
            List<Ingreso> ingresos = new List<Ingreso>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from INGRESO where Comite=@Comite";
                command.Parameters.AddWithValue("@Comite", comite);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Ingreso ingreso = DataReaderMapToIngreso(dataReader);
                        ingresos.Add(ingreso);
                    }
                }
            }
            return ingresos;
        }
        public List<Ingreso> FiltrarIngresosPorConcepto(string concepto)
        {
            List<Ingreso> ingresos = new List<Ingreso>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from INGRESO where Concepto=@Concepto";
                command.Parameters.AddWithValue("@Concepto", concepto);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Ingreso ingreso = DataReaderMapToIngreso(dataReader);
                        ingresos.Add(ingreso);
                    }
                }
            }
            return ingresos;
        }
        public Ingreso BuscarPorIdentificacion(string codigo)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from INGRESO where CodigoComprobante=@CodigoComprobante";
                command.Parameters.AddWithValue("@CodigoComprobante", codigo);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToIngreso(dataReader);
            }
        }
        public void Modificar(Ingreso ingreso)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update INGRESO set FechaDeIngreso=@FechaDeIngreso, Comite=@Comite, Concepto=@Concepto, Valor=@Valor, Detalle=@Detalle
                                        where CodigoComprobante=@CodigoComprobante";
                command.Parameters.AddWithValue("@CodigoComprobante", ingreso.CodigoComprobante);
                command.Parameters.AddWithValue("@FechaDeIngreso", ingreso.FechaDeIngreso);
                command.Parameters.AddWithValue("@Comite", ingreso.Comite);
                command.Parameters.AddWithValue("@Concepto", ingreso.Concepto);
                command.Parameters.AddWithValue("@Valor", ingreso.Valor);
                command.Parameters.AddWithValue("@Detalle", ingreso.Detalle);
                var filas = command.ExecuteNonQuery();
            }
        }
        private Ingreso DataReaderMapToIngreso(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Ingreso ingreso = new Ingreso();
            ingreso.CodigoComprobante = (string)dataReader["CodigoComprobante"];
            ingreso.FechaDeIngreso = (DateTime)dataReader["FechaDeIngreso"];
            ingreso.Comite = (string)dataReader["Comite"];
            ingreso.Concepto = (string)dataReader["Concepto"];
            ingreso.Valor = (int)dataReader["Valor"];
            ingreso.Detalle = (string)dataReader["Detalle"];
            return ingreso;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Comite.Equals(tipo)).Count();
        }
    }
}
