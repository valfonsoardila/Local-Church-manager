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
    public class ContactoRepository
    {
        private readonly SqlConnection _connection;
        public ContactoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Contacto contacto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into CONTACTO(Id, Nombre, Apellido, TelefonoContacto, TelefonoWhatsapp, Oficio) " +
                    "Values (@Id, @Nombre, @Apellido, @TelefonoContacto, TelefonoWhatsapp, Oficio)";
                command.Parameters.AddWithValue("@Id", contacto.Id);
                command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                command.Parameters.AddWithValue("@TelefonoContacto", contacto.TelefonoContacto);
                command.Parameters.AddWithValue("@TelefonoWhatsapp", contacto.TelefonoWhatsapp);
                command.Parameters.AddWithValue("@Oficio", contacto.Oficio);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Contacto contacto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from CONTACTO where Id=@Id";
                command.Parameters.AddWithValue("@Id", contacto.Id);
                command.ExecuteNonQuery();
            }
        }
        public List<Contacto> ConsultarTodos()
        {
            List<Contacto> contactos = new List<Contacto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Id, Nombre, Apellido, TelefonoContacto, TelefonoWhatsapp, Oficio from CONTACTO ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Contacto contacto = DataReaderMapToCliente(dataReader);
                        contactos.Add(contacto);
                    }
                }
            }
            return contactos;
        }
        public Contacto BuscarPorIdentificacion(string id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from CONTACTO where Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Contacto contacto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update CONTACTO set Nombre=@Nombre, Apellido=@Apellido. TelefonoContacto=@TelefonoContacto, TelefonoWhatsapp=@TelefonoWhatsapp, Oficio=@Oficio
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Id", contacto.Id);
                command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                command.Parameters.AddWithValue("@TelefonoContacto", contacto.TelefonoContacto);
                command.Parameters.AddWithValue("@TelefonoWhatsapp", contacto.TelefonoWhatsapp);
                command.Parameters.AddWithValue("@Oficio", contacto.Oficio);
            }
        }
        private Contacto DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Contacto contacto = new Contacto();
            contacto.Id = (string)dataReader["Id"];
            contacto.Nombre = (string)dataReader["Nombre"];
            contacto.Apellido = (string)dataReader["Apellido"];
            contacto.TelefonoContacto = (string)dataReader["TelefonoContacto"];
            contacto.TelefonoWhatsapp = (string)dataReader["TelefonoWhatsapp"];
            contacto.Oficio = (string)dataReader["Oficio"];
            return contacto;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Nombre.Equals(tipo)).Count();
        }
    }
}
