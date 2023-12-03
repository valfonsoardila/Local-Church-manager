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
                command.CommandText = @"Insert Into USUARIO (Codigo_Usuario, Id, Tipo_De_Id, Nombres, Apellidos, Fecha_De_Nacimiento, Edad, Sexo, Direccion_Domicilio, Telefono, Rol, Correo, NombreUsuario, Contraseña) 
                                        values (@Codigo_Usuario, @Id, @Tipo_De_Id, @Nombres, @Apellidos, @Fecha_De_Nacimiento, @Edad, @Sexo, @Direccion_Domicilio, @Telefono, @Rol, @Correo, @NombreUsuario, @Contraseña)";
                command.Parameters.AddWithValue("@Codigo_Usuario", enviable.CodigoUsuario);
                command.Parameters.AddWithValue("@Id", enviable.Identificacion);
                command.Parameters.AddWithValue("@Tipo_De_Id", enviable.TipoDeIdentificacion);
                command.Parameters.AddWithValue("@Nombres", enviable.Nombres);
                command.Parameters.AddWithValue("@Apellidos", enviable.Apellidos);
                command.Parameters.AddWithValue("@Fecha_De_Nacimiento", enviable.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Edad", enviable.Edad);
                command.Parameters.AddWithValue("@Sexo", enviable.Sexo);
                command.Parameters.AddWithValue("@Direccion_Domicilio", enviable.Direccion);
                command.Parameters.AddWithValue("@Telefono", enviable.Telefono);
                command.Parameters.AddWithValue("@Rol", enviable.Rol);
                command.Parameters.AddWithValue("@Correo", enviable.CorreoElectronico);
                command.Parameters.AddWithValue("@NombreUsuario", enviable.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", enviable.Contraseña);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Enviable> BuscarPorSexo(string sexo)
        {
            List<Enviable> enviables = new List<Enviable>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from USUARIO where Sexo=@Sexo";
                command.Parameters.AddWithValue("@Sexo", sexo);
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
                command.CommandText = "select * from USUARIO where Id=@Id";
                command.Parameters.AddWithValue("@Id", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToUsuario(dataReader);
            }
        }
        public Enviable BuscarPorRol(string rol)
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
        public Enviable BuscarPorNombreDeUsuario(string nombreDeUsuario)
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
        public void Modificar(Enviable enviable)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update USUARIO set Codigo_Usuario=@Codigo_Usuario, Tipo_De_Id=@Tipo_De_Id, Nombres=@Nombres, Apellidos=@Apellidos, Fecha_De_Nacimiento=@Fecha_De_Nacimiento, Edad=@Edad, Sexo=@Sexo, Direccion_Domicilio=@Direccion_Domicilio, Telefono=@Telefono, Rol=@Rol, Correo=@Correo, NombreUsuario=@NombreUsuario, Contraseña=@Contraseña
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Codigo_Usuario", enviable.CodigoUsuario);
                command.Parameters.AddWithValue("@Id", enviable.Identificacion);
                command.Parameters.AddWithValue("@Tipo_De_Id", enviable.TipoDeIdentificacion);
                command.Parameters.AddWithValue("@Nombres", enviable.Nombres);
                command.Parameters.AddWithValue("@Apellidos", enviable.Apellidos);
                command.Parameters.AddWithValue("@Fecha_De_Nacimiento", enviable.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Edad", enviable.Edad);
                command.Parameters.AddWithValue("@Sexo", enviable.Sexo);
                command.Parameters.AddWithValue("@Direccion_Domicilio", enviable.Direccion);
                command.Parameters.AddWithValue("@Telefono", enviable.Telefono);
                command.Parameters.AddWithValue("@Rol", enviable.Rol);
                command.Parameters.AddWithValue("@Correo", enviable.CorreoElectronico);
                command.Parameters.AddWithValue("@NombreUsuario", enviable.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", enviable.Contraseña);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Enviable> ConsultarTodos()
        {
            List<Enviable> enviables = new List<Enviable>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Codigo_Usuario, Id, Tipo_De_Id, Nombres, Apellidos, Fecha_De_Nacimiento, Edad, Sexo, Direccion_Domicilio, Telefono, Rol, Correo, NombreUsuario, Contraseña from USUARIO";
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
                command.CommandText = "Delete from USUARIO where Id=@Id";
                command.Parameters.AddWithValue("@Id", enviable.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        private Enviable DataReaderMapToUsuario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Enviable enviable = new Enviable();
            enviable.CodigoUsuario = (string)dataReader["Codigo_Usuario"];
            enviable.Identificacion = (string)dataReader["Id"];
            enviable.TipoDeIdentificacion = (string)dataReader["Tipo_De_Id"];
            enviable.Nombres = (string)dataReader["Nombres"];
            enviable.Apellidos = (string)dataReader["Apellidos"];
            enviable.FechaDeNacimiento = (DateTime)dataReader["Fecha_De_Nacimiento"];
            enviable.Edad = (int)dataReader["Edad"];
            enviable.Sexo = (string)dataReader["Sexo"];
            enviable.Direccion = (string)dataReader["Direccion_Domicilio"];
            enviable.Telefono = (string)dataReader["Telefono"];
            enviable.Rol = (string)dataReader["Rol"];
            enviable.CorreoElectronico = (string)dataReader["Correo"];
            enviable.NombreUsuario = (string)dataReader["NombreUsuario"];
            enviable.Contraseña = (string)dataReader["Contraseña"];
            return enviable;
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
