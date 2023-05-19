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
    public class UsuarioRepository
    {
        private readonly SqlConnection _connection;
        public UsuarioRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Usuario Usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into USUARIO (Codigo_Usuario, Id, Tipo_De_Id, Nombres, Apellidos, Fecha_De_Nacimiento, Edad, Sexo, Direccion_Domicilio, Telefono, Rol, Correo, NombreUsuario, Contraseña) 
                                        values (@Codigo_Usuario, @Id, @Tipo_De_Id, @Nombres, @Apellidos, @Fecha_De_Nacimiento, @Edad, @Sexo, @Direccion_Domicilio, @Telefono, @Rol, @Correo, @NombreUsuario, @Contraseña)";
                command.Parameters.AddWithValue("@Codigo_Usuario", Usuario.CodigoUsuario);
                command.Parameters.AddWithValue("@Id", Usuario.Identificacion);
                command.Parameters.AddWithValue("@Tipo_De_Id", Usuario.TipoDeIdentificacion);
                command.Parameters.AddWithValue("@Nombres", Usuario.Nombres);
                command.Parameters.AddWithValue("@Apellidos", Usuario.Apellidos);
                command.Parameters.AddWithValue("@Fecha_De_Nacimiento", Usuario.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Edad", Usuario.Edad);
                command.Parameters.AddWithValue("@Sexo", Usuario.Sexo);
                command.Parameters.AddWithValue("@Direccion_Domicilio", Usuario.Direccion);
                command.Parameters.AddWithValue("@Telefono", Usuario.Telefono);
                command.Parameters.AddWithValue("@Rol", Usuario.Rol);
                command.Parameters.AddWithValue("@Correo", Usuario.CorreoElectronico);
                command.Parameters.AddWithValue("@NombreUsuario", Usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", Usuario.Contraseña);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Usuario> BuscarPorSexo(string sexo)
        {
            List<Usuario> Usuarios = new List<Usuario>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from USUARIO where Sexo=@Sexo";
                command.Parameters.AddWithValue("@Sexo", sexo);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Usuario Usuario = DataReaderMapToUsuario(dataReader);
                        Usuarios.Add(Usuario);
                    }
                }
            }
            return Usuarios;
        }
        public Usuario BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from USUARIO where Id=@Id";
                command.Parameters.AddWithValue("@Id", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToUsuario(dataReader);
            }
        }
        public Usuario BuscarPorRol(string rol)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from USUARIO where Rol=@Rol";
                command.Parameters.AddWithValue("@Rol", rol);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToUsuario(dataReader);
            }
        }
        public Usuario BuscarPorNombreDeUsuario(string nombreDeUsuario)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from USUARIO where NombreUsuario=@NombreUsuario";
                command.Parameters.AddWithValue("@NombreUsuario", nombreDeUsuario);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToUsuario(dataReader);
            }
        }
        public void Modificar(Usuario Usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update USUARIO set Codigo_Usuario=@Codigo_Usuario, Tipo_De_Id=@Tipo_De_Id, Nombres=@Nombres, Apellidos=@Apellidos, Fecha_De_Nacimiento=@Fecha_De_Nacimiento, Edad=@Edad, Sexo=@Sexo, Direccion_Domicilio=@Direccion_Domicilio, Telefono=@Telefono, Rol=@Rol, Correo=@Correo, NombreUsuario=@NombreUsuario, Contraseña=@Contraseña
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Codigo_Usuario", Usuario.CodigoUsuario);
                command.Parameters.AddWithValue("@Id", Usuario.Identificacion);
                command.Parameters.AddWithValue("@Tipo_De_Id", Usuario.TipoDeIdentificacion);
                command.Parameters.AddWithValue("@Nombres", Usuario.Nombres);
                command.Parameters.AddWithValue("@Apellidos", Usuario.Apellidos);
                command.Parameters.AddWithValue("@Fecha_De_Nacimiento", Usuario.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Edad", Usuario.Edad);
                command.Parameters.AddWithValue("@Sexo", Usuario.Sexo);
                command.Parameters.AddWithValue("@Direccion_Domicilio", Usuario.Direccion);
                command.Parameters.AddWithValue("@Telefono", Usuario.Telefono);
                command.Parameters.AddWithValue("@Rol", Usuario.Rol);
                command.Parameters.AddWithValue("@Correo", Usuario.CorreoElectronico);
                command.Parameters.AddWithValue("@NombreUsuario", Usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", Usuario.Contraseña);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Codigo_Usuario, Id, Tipo_De_Id, Nombres, Apellidos, Fecha_De_Nacimiento, Edad, Sexo, Direccion_Domicilio, Telefono, Rol, Correo, NombreUsuario, Contraseña from USUARIO";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Usuario Usuario = DataReaderMapToUsuario(dataReader);
                        Usuarios.Add(Usuario);
                    }
                }
            }
            return Usuarios;
        }
        public void Eliminar(Usuario Usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from USUARIO where Id=@Id";
                command.Parameters.AddWithValue("@Id", Usuario.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        private Usuario DataReaderMapToUsuario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Usuario Usuario = new Usuario();
            Usuario.CodigoUsuario = (string)dataReader["Codigo_Usuario"];
            Usuario.Identificacion = (string)dataReader["Id"];
            Usuario.TipoDeIdentificacion = (string)dataReader["Tipo_De_Id"];
            Usuario.Nombres = (string)dataReader["Nombres"];
            Usuario.Apellidos = (string)dataReader["Apellidos"];
            Usuario.FechaDeNacimiento = (DateTime)dataReader["Fecha_De_Nacimiento"];
            Usuario.Edad = (int)dataReader["Edad"];
            Usuario.Sexo = (string)dataReader["Sexo"];
            Usuario.Direccion = (string)dataReader["Direccion_Domicilio"];
            Usuario.Telefono = (string)dataReader["Telefono"];
            Usuario.Rol = (string)dataReader["Rol"];
            Usuario.CorreoElectronico = (string)dataReader["Correo"];
            Usuario.NombreUsuario = (string)dataReader["NombreUsuario"];
            Usuario.Contraseña = (string)dataReader["Contraseña"];
            return Usuario;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipoRol(string tipo)
        {
            return ConsultarTodos().Where(p => p.Rol.Equals(tipo)).Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Sexo.Equals(tipo)).Count();
        }
    }
}
