using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL
{
    public class DirectivaRepository
    {
        private readonly SqlConnection _connection;
        public DirectivaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Directiva directiva)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into DIRECTIVA(IdDirectiva, Nombre, Cargo, Comite, Vigencia, Observacion, ) " +
                    "Values (@IdDirectiva, @Nombre, @Cargo, @Comite, @Vigencia, Observacion, )";
                command.Parameters.AddWithValue("@IdDirectiva", directiva.IdDirectiva);
                command.Parameters.AddWithValue("@Nombre", directiva.Nombre);
                command.Parameters.AddWithValue("@Cargo", directiva.Cargo);
                command.Parameters.AddWithValue("@Comite", directiva.Comite);
                command.Parameters.AddWithValue("@Vigencia", directiva.Vigencia);
                command.Parameters.AddWithValue("@Observacion", directiva.Observacion);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Directiva directiva)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from DIRECTIVA where IdDirectiva=@IdDirectiva";
                command.Parameters.AddWithValue("@IdDirectiva", directiva.IdDirectiva);
                command.ExecuteNonQuery();
            }
        }
        public List<Directiva> ConsultarTodos()
        {
            List<Directiva> contactos = new List<Directiva>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select IdDirectiva, Nombre, Cargo, Comite, Vigencia, Observacion from DIRECTIVA ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Directiva directiva = DataReaderMapToCliente(dataReader);
                        contactos.Add(directiva);
                    }
                }
            }
            return contactos;
        }
        public Directiva BuscarPorIdentificacion(string id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from DIRECTIVA where IdDirectiva=@IdDirectiva";
                command.Parameters.AddWithValue("@IdDirectiva", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Directiva directiva)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update DIRECTIVA set Nombre=@Nombre, Cargo=@Cargo, Comite=@Comite. Vigencia=@Vigencia, Observacion=@Observacion
                                        where IdDirectiva=@IdDirectiva";
                command.Parameters.AddWithValue("@IdDirectiva", directiva.IdDirectiva);
                command.Parameters.AddWithValue("@Nombre", directiva.Nombre);
                command.Parameters.AddWithValue("@Cargo", directiva.Cargo);
                command.Parameters.AddWithValue("@Comite", directiva.Comite);
                command.Parameters.AddWithValue("@Vigencia", directiva.Vigencia);
                command.Parameters.AddWithValue("@Observacion", directiva.Observacion);
            }
        }
        private Directiva DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Directiva directiva = new Directiva();
            directiva.IdDirectiva = (string)dataReader["IdDirectiva"];
            directiva.Nombre = (string)dataReader["Nombre"];
            directiva.Cargo = (string)dataReader["Cargo"];
            directiva.Comite = (string)dataReader["Comite"];
            directiva.Vigencia = (string)dataReader["Vigencia"];
            directiva.Observacion = (string)dataReader["Observacion"];
            return directiva;
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
