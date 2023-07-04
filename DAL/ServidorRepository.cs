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
                command.CommandText = "Insert Into SERVIDOR(IdServidor, Nombre, Comite, Cargo, Vigencia, Observacion) " +
                    "Values (@IdServidor, @Nombre, @Comite, @Cargo, @Vigencia, @Observacion)";
                command.Parameters.AddWithValue("IdServidor", servidor.IdServidor);
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
                command.CommandText = "Delete from Servidor where IdServidor=@IdServidor";
                command.Parameters.AddWithValue("@IdServidor", servidor.IdServidor);
                command.ExecuteNonQuery();
            }
        }
        public List<Servidor> ConsultarTodos()
        {
            List<Servidor> servidors = new List<Servidor>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select IdServidor, Nombre, Comite, Cargo, Vigencia, Observacion from SERVIDOR ";
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
        public Servidor BuscarPorIdentificacion(string idServidor)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SERVIDOR where IdServidor=@IdServidor";
                command.Parameters.AddWithValue("@IdServidor", idServidor);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Servidor servidor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update SERVIDOR set Nombre=@Nombre, Comite=@Comite, Cargo=@Cargo, Vigencia=@Vigencia, Observacion=@Observacion
                                        where IdServidor=@IdServidor";
                command.Parameters.AddWithValue("@IdServidor", servidor.IdServidor);
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
            servidor.IdServidor = (string)dataReader["IdServidor"];
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
