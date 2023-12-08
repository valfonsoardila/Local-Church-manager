using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LiquidacionesRepository
    {
        private readonly SqlConnection _connection;
        public LiquidacionesRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Liquidacion liquidacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into LIQUIDACION (Id, FechaDeLiquidacion, Valor, Detalle, Estado) 
                                        values (@Id, @FechaDeLiquidacion, @Valor, @Detalle, @Estado)";
                command.Parameters.AddWithValue("@Id", liquidacion.Id);
                command.Parameters.AddWithValue("@FechaDeLiquidacion", liquidacion.FechaDeLiquidacion);
                command.Parameters.AddWithValue("@Valor", liquidacion.Valor);
                command.Parameters.AddWithValue("@Detalle", liquidacion.Detalle);
                command.Parameters.AddWithValue("@Estado", liquidacion.Estado);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Liquidacion> BuscarPorFecha(string fecha)
        {
            List<Liquidacion> enviables = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from LIQUIDACION where FechaDeLiquidacion=@FechaDeLiquidacion";
                command.Parameters.AddWithValue("@FechaDeLiquidacion", fecha);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMapToUsuario(dataReader);
                        enviables.Add(liquidacion);
                    }
                }
            }
            return enviables;
        }
        public Liquidacion BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from LIQUIDACION where Id=@Id";
                command.Parameters.AddWithValue("@Id", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToUsuario(dataReader);
            }
        }
        public void Modificar(Liquidacion liquidacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update LIQUIDACION set FechaDeLiquidacion=@FechaDeLiquidacion, Valor=@Valor, Detalle=@Detalle, Estado=@Estado
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Id", liquidacion.Id);
                command.Parameters.AddWithValue("@FechaDeLiquidacion", liquidacion.FechaDeLiquidacion);
                command.Parameters.AddWithValue("@Valor", liquidacion.Valor);
                command.Parameters.AddWithValue("@Detalle", liquidacion.Detalle);
                command.Parameters.AddWithValue("@Estado", liquidacion.Estado);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Liquidacion> ConsultarTodos()
        {
            List<Liquidacion> enviables = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Id, FechaDeLiquidacion, Valor, Detalle, Estado from LIQUIDACION";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMapToUsuario(dataReader);
                        enviables.Add(liquidacion);
                    }
                }
            }
            return enviables;
        }
        public void Eliminar(Liquidacion liquidacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from LIQUIDACION where Id=@Id";
                command.Parameters.AddWithValue("@Id", liquidacion.Id);
                command.ExecuteNonQuery();
            }
        }
        private Liquidacion DataReaderMapToUsuario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Liquidacion liquidacion = new Liquidacion();
            liquidacion.Id = (string)dataReader["Id"];
            liquidacion.FechaDeLiquidacion = (DateTime)dataReader["FechaDeLiquidacion"];
            liquidacion.Valor = (int)dataReader["Valor"];
            liquidacion.Detalle = (string)dataReader["Detalle"];
            liquidacion.Estado = (string)dataReader["Estado"];
            return liquidacion;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        //public int TotalizarTipo(string tipo)
        //{
        //    return ConsultarTodos().Where(p => p.Sexo.Equals(tipo)).Count();
        //}
    }
}
