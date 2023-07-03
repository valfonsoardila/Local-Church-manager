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
    public class ReunionRepository
    {
        private readonly SqlConnection _connection;
        public ReunionRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Reunion reunion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into REUNION(NumeroActa, FechaDeReunion, LugarDeReunion, OrdenDelDia, TextoActa) " +
                    "Values (@NumeroActa, @FechaDeReunion, @LugarDeReunion, @OrdenDelDia, @TextoActa)";
                command.Parameters.AddWithValue("@NumeroActa", reunion.NumeroActa);
                command.Parameters.AddWithValue("@FechaDeReunion", reunion.FechaDeReunion);
                command.Parameters.AddWithValue("@LugarDeReunion", reunion.LugarDeReunion);
                command.Parameters.AddWithValue("@OrdenDelDia", reunion.OrdenDelDia);
                command.Parameters.AddWithValue("@TextoActa", reunion.TextoActa);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Reunion reunion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Reunion where NumeroActa=@NumeroActa";
                command.Parameters.AddWithValue("@NumeroActa", reunion.NumeroActa);
                command.ExecuteNonQuery();
            }
        }
        public List<Reunion> ConsultarTodos()
        {
            List<Reunion> reunions = new List<Reunion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select NumeroActa, FechaDeReunion, LugarDeReunion, OrdenDelDia, TextoActa from REUNION ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Reunion reunion = DataReaderMapToCliente(dataReader);
                        reunions.Add(reunion);
                    }
                }
            }
            return reunions;
        }
        public Reunion BuscarPorIdentificacion(string numeroActa)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from REUNION where NumeroActa=@NumeroActa";
                command.Parameters.AddWithValue("@NumeroActa", numeroActa);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Reunion reunion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update REUNION set FechaDeReunion, LugarDeReunion, OrdenDelDia, TextoActa
                                        where NumeroActa=@NumeroActa";
                command.Parameters.AddWithValue("@NumeroActa", reunion.NumeroActa);
                command.Parameters.AddWithValue("@FechaDeReunion", reunion.FechaDeReunion);
                command.Parameters.AddWithValue("@LugarDeReunion", reunion.LugarDeReunion);
                command.Parameters.AddWithValue("@OrdenDelDia", reunion.OrdenDelDia);
                command.Parameters.AddWithValue("@TextoActa", reunion.TextoActa);
            }
        }
        private Reunion DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Reunion reunion = new Reunion();
            reunion.NumeroActa = (string)dataReader["NumeroActa"];
            reunion.FechaDeReunion = (DateTime)dataReader["FechaDeReunion"];
            reunion.LugarDeReunion = (string)dataReader["LugarDeReunion"];
            reunion.OrdenDelDia = (string)dataReader["OrdenDelDia"];
            reunion.TextoActa = (string)dataReader["TextoActa"];
            return reunion;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.FechaDeReunion.Equals(tipo)).Count();
        }
    }
}
