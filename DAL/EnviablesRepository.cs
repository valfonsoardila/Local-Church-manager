using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EnviablesRepository
    {
        private readonly SqlConnection _connection;
        public EnviablesRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Enviable enviable)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into ENVIABLE (Id, FechaDeEnvio, Comite, Concepto, Valor, Detalle) 
                                        values (@Id, @FechaDeEnvio, @Comite, @Concepto, @Valor, @Detalle)";
                command.Parameters.AddWithValue("@Id", enviable.Id);
                command.Parameters.AddWithValue("@FechaDeEnvio", enviable.FechaDeEnvio);
                command.Parameters.AddWithValue("@Comite", enviable.Comite);
                command.Parameters.AddWithValue("@Concepto", enviable.Concepto);
                command.Parameters.AddWithValue("@Valor", enviable.Valor);
                command.Parameters.AddWithValue("@Detalle", enviable.Detalle);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Enviable> BuscarPorFecha(string fecha)
        {
            List<Enviable> enviables = new List<Enviable>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from ENVIABLE where FechaDeEnvio=@FechaDeEnvio";
                command.Parameters.AddWithValue("@FechaDeEnvio", fecha);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Enviable enviable = DataReaderMapToUsuario(dataReader);
                        enviables.Add(enviable);
                    }
                }
            }
            return enviables;
        }
        public List<Enviable> BuscarPorComite(string comite)
        {
            List<Enviable> enviables = new List<Enviable>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from ENVIABLE where Comite=@Comite";
                command.Parameters.AddWithValue("@Comite", comite);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Enviable enviable = DataReaderMapToUsuario(dataReader);
                        enviables.Add(enviable);
                    }
                }
            }
            return enviables;
        }
        public List<Enviable> BuscarPorConcepto(string concepto)
        {
            List<Enviable> enviables = new List<Enviable>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from ENVIABLE where Concepto=@Concepto";
                command.Parameters.AddWithValue("@Concepto", concepto);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Enviable enviable = DataReaderMapToUsuario(dataReader);
                        enviables.Add(enviable);
                    }
                }
            }
            return enviables;
        }
        public Enviable BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from ENVIABLE where Id=@Id";
                command.Parameters.AddWithValue("@Id", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToUsuario(dataReader);
            }
        }
        public void Modificar(Enviable enviable)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update ENVIABLE set FechaDeEnvio=@FechaDeEnvio, Comite=@Comite, Concepto=@Concepto, Valor=@Valor, Detalle=@Detalle
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Id", enviable.Id);
                command.Parameters.AddWithValue("@FechaDeEnvio", enviable.FechaDeEnvio);
                command.Parameters.AddWithValue("@Comite", enviable.Comite);
                command.Parameters.AddWithValue("@Concepto", enviable.Concepto);
                command.Parameters.AddWithValue("@Valor", enviable.Valor);
                command.Parameters.AddWithValue("@Detalle", enviable.Detalle);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Enviable> ConsultarTodos()
        {
            List<Enviable> enviables = new List<Enviable>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Id, FechaDeEnvio, Comite, Concepto, Valor, Detalle from ENVIABLE";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Enviable enviable = DataReaderMapToUsuario(dataReader);
                        enviables.Add(enviable);
                    }
                }
            }
            return enviables;
        }
        public void Eliminar(Enviable enviable)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from ENVIABLE where Id=@Id";
                command.Parameters.AddWithValue("@Id", enviable.Id);
                command.ExecuteNonQuery();
            }
        }
        private Enviable DataReaderMapToUsuario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Enviable enviable = new Enviable();
            enviable.Id = (string)dataReader["Id"];
            enviable.FechaDeEnvio = (DateTime)dataReader["FechaDeEnvio"];
            enviable.Comite = (string)dataReader["Comite"];
            enviable.Concepto = (string)dataReader["Concepto"];
            enviable.Valor = (int)dataReader["Valor"];
            enviable.Detalle = (string)dataReader["Detalle"];
            return enviable;
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
