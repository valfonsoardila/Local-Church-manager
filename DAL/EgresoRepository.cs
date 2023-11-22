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
    public class EgresoRepository
    {
        private readonly SqlConnection _connection;
        public EgresoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Egreso egreso)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into EGRESO(CodigoComprobante, FechaDeEgreso, Comite, Concepto, Valor, Detalle) Values (@CodigoComprobante, @FechaDeEgreso, @Comite, @Concepto, @Valor, @Detalle)";
                command.Parameters.AddWithValue("@CodigoComprobante", egreso.CodigoComprobante);
                command.Parameters.AddWithValue("@FechaDeEgreso", egreso.FechaDeEgreso);
                command.Parameters.AddWithValue("@Comite", egreso.Comite);
                command.Parameters.AddWithValue("@Concepto", egreso.Concepto);
                command.Parameters.AddWithValue("@Valor", egreso.Valor);
                command.Parameters.AddWithValue("@Detalle", egreso.Detalle);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Egreso egreso)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from EGRESO where CodigoComprobante=@CodigoComprobante";
                command.Parameters.AddWithValue("@CodigoComprobante", egreso.CodigoComprobante);
                command.ExecuteNonQuery();
            }
        }
        public List<Egreso> ConsultarTodos()
        {
            List<Egreso> egresos = new List<Egreso>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select CodigoComprobante, FechaDeEgreso, Comite, Concepto, Valor, Detalle from EGRESO";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Egreso egreso = DataReaderMapToEgreso(dataReader);
                        egresos.Add(egreso);
                    }
                }
            }
            return egresos;
        }
        public List<Egreso> FiltrarIngresosPorComite(string comite)
        {
            List<Egreso> egresos = new List<Egreso>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from EGRESO where Comite=@Comite";
                command.Parameters.AddWithValue("@Comite", comite);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Egreso egreso = DataReaderMapToEgreso(dataReader);
                        egresos.Add(egreso);
                    }
                }
            }
            return egresos;
        }
        public List<Egreso> FiltrarEgresosPorConcepto(string concepto)
        {
            List<Egreso> egresos = new List<Egreso>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from EGRESO where Concepto=@Concepto";
                command.Parameters.AddWithValue("@Concepto", concepto);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Egreso egreso = DataReaderMapToEgreso(dataReader);
                        egresos.Add(egreso);
                    }
                }
            }
            return egresos;
        }
        public Egreso BuscarPorIdentificacion(string codigo)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from EGRESO where CodigoComprobante=@CodigoComprobante";
                command.Parameters.AddWithValue("@CodigoComprobante", codigo);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToEgreso(dataReader);
            }
        }
        public void Modificar(Egreso egreso)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update EGRESO set FechaDeEgreso=@FechaDeEgreso, Comite=@Comite, Concepto=@Concepto, Valor=@Valor, Detalle=@Detalle
                                        where CodigoComprobante=@CodigoComprobante";
                command.Parameters.AddWithValue("@FechaDeEgreso", egreso.FechaDeEgreso);
                command.Parameters.AddWithValue("@Comite", egreso.Comite);
                command.Parameters.AddWithValue("@Valor", egreso.Valor);
                command.Parameters.AddWithValue("@Detalle", egreso.Detalle);
                var filas = command.ExecuteNonQuery();
            }
        }
        private Egreso DataReaderMapToEgreso(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Egreso egreso = new Egreso();
            egreso.CodigoComprobante = (string)dataReader["CodigoComprobante"];
            egreso.FechaDeEgreso = (DateTime)dataReader["FechaDeEgreso"];
            egreso.Comite = (string)dataReader["Comite"];
            egreso.Concepto = (string)dataReader["Concepto"];
            egreso.Valor = (int)dataReader["Valor"];
            egreso.Detalle = (string)dataReader["Detalle"];
            return egreso;
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
