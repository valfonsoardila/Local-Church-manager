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
    public class ServidorRepository
    {
        private readonly SqlConnection _connection;
        public ServidorRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Servidor servidor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into REUNION(Nombre, Comite, Cargo, Vigencia, Observacion) " +
                    "Values (@Nombre, @Comite, @Cargo, @Vigencia, @Observacion)";
                command.Parameters.AddWithValue("@Nombre", servidor.Nombre);
                command.Parameters.AddWithValue("@Comite", servidor.Comite);
                command.Parameters.AddWithValue("@Cargo", servidor.Cargo);
                command.Parameters.AddWithValue("@Vigencia", servidor.Vigencia);
                command.Parameters.AddWithValue("@Observacion", servidor.Observacion);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Servidor servidor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Servidor where Nombre=@Nombre";
                command.Parameters.AddWithValue("@Nombre", servidor.Nombre);
                command.ExecuteNonQuery();
            }
        }
        public List<Servidor> ConsultarTodos()
        {
            List<Servidor> servidors = new List<Servidor>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Nombre, Comite, Cargo, Vigencia, Observacion from REUNION ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Servidor servidor = DataReaderMapToCliente(dataReader);
                        servidors.Add(servidor);
                    }
                }
            }
            return servidors;
        }
        public Servidor BuscarPorIdentificacion(string numeroActa)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from REUNION where Nombre=@Nombre";
                command.Parameters.AddWithValue("@Nombre", numeroActa);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Servidor servidor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update REUNION set Comite, Cargo, Vigencia, Observacion
                                        where Nombre=@Nombre";
                command.Parameters.AddWithValue("@Nombre", servidor.Nombre);
                command.Parameters.AddWithValue("@Comite", servidor.Comite);
                command.Parameters.AddWithValue("@Cargo", servidor.Cargo);
                command.Parameters.AddWithValue("@Vigencia", servidor.Vigencia);
                command.Parameters.AddWithValue("@Observacion", servidor.Observacion);
            }
        }
        private Servidor DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Servidor servidor = new Servidor();
            servidor.Nombre = (string)dataReader["Nombre"];
            servidor.Comite = (string)dataReader["Comite"];
            servidor.Cargo = (string)dataReader["Cargo"];
            servidor.Vigencia = (string)dataReader["Vigencia"];
            servidor.Observacion = (string)dataReader["Observacion"];
            return servidor;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Cargo.Equals(tipo)).Count();
        }
    }
}
