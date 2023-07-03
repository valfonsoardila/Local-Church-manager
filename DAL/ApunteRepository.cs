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
    public class ApunteRepository
    {
        private readonly SqlConnection _connection;
        public ApunteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Apunte apunte)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into APUNTE(Id, Titulo, Nota) " +
                    "Values (@Id, @Titulo, @Nota)";
                command.Parameters.AddWithValue("@Id", apunte.Id);
                command.Parameters.AddWithValue("@Titulo", apunte.Titulo);
                command.Parameters.AddWithValue("@Nota", apunte.Nota);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Apunte apunte)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Apunte where Id=@Id";
                command.Parameters.AddWithValue("@Id", apunte.Id);
                command.ExecuteNonQuery();
            }
        }
        public List<Apunte> ConsultarTodos()
        {
            List<Apunte> apuntes = new List<Apunte>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Id, Titulo, Nota from APUNTE ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Apunte apunte = DataReaderMapToCliente(dataReader);
                        apuntes.Add(apunte);
                    }
                }
            }
            return apuntes;
        }
        public Apunte BuscarPorIdentificacion(string id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from APUNTE where Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Apunte apunte)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update APUNTE set Titulo=@Titulo, Nota=@Nota
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Id", apunte.Id);
                command.Parameters.AddWithValue("@Titulo", apunte.Titulo);
                command.Parameters.AddWithValue("@Nota", apunte.Nota);
            }
        }
        private Apunte DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Apunte apunte = new Apunte();
            apunte.Id = (string)dataReader["Id"];
            apunte.Titulo = (string)dataReader["Titulo"];
            apunte.Nota = (string)dataReader["Nota"];
            return apunte;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Nota.Equals(tipo)).Count();
        }
    }
}
