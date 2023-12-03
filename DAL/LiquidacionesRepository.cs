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
                command.CommandText = @"Insert Into USUARIO (Codigo_Usuario, Id, Tipo_De_Id, Nombres, Apellidos, Fecha_De_Nacimiento, Edad, Sexo, Direccion_Domicilio, Telefono, Rol, Correo, NombreUsuario, Contraseña) 
                                        values (@Codigo_Usuario, @Id, @Tipo_De_Id, @Nombres, @Apellidos, @Fecha_De_Nacimiento, @Edad, @Sexo, @Direccion_Domicilio, @Telefono, @Rol, @Correo, @NombreUsuario, @Contraseña)";
                command.Parameters.AddWithValue("@Codigo_Usuario", liquidacion.CodigoUsuario);
                command.Parameters.AddWithValue("@Id", liquidacion.Identificacion);
                command.Parameters.AddWithValue("@Tipo_De_Id", liquidacion.TipoDeIdentificacion);
                command.Parameters.AddWithValue("@Nombres", liquidacion.Nombres);
                command.Parameters.AddWithValue("@Apellidos", liquidacion.Apellidos);
                command.Parameters.AddWithValue("@Fecha_De_Nacimiento", liquidacion.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Edad", liquidacion.Edad);
                command.Parameters.AddWithValue("@Sexo", liquidacion.Sexo);
                command.Parameters.AddWithValue("@Direccion_Domicilio", liquidacion.Direccion);
                command.Parameters.AddWithValue("@Telefono", liquidacion.Telefono);
                command.Parameters.AddWithValue("@Rol", liquidacion.Rol);
                command.Parameters.AddWithValue("@Correo", liquidacion.CorreoElectronico);
                command.Parameters.AddWithValue("@NombreUsuario", liquidacion.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", liquidacion.Contraseña);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Liquidacion> BuscarPorSexo(string sexo)
        {
            List<Liquidacion> liquidaciones = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from USUARIO where Sexo=@Sexo";
                command.Parameters.AddWithValue("@Sexo", sexo);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMapToUsuario(dataReader);
                        liquidaciones.Add(liquidacion);
                    }
                }
            }
            return liquidaciones;
        }
        public Liquidacion BuscarPorIdentificacion(string identificacion)
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
        public Liquidacion BuscarPorRol(string rol)
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
        public Liquidacion BuscarPorNombreDeUsuario(string nombreDeUsuario)
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
        public void Modificar(Liquidacion liquidacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update USUARIO set Codigo_Usuario=@Codigo_Usuario, Tipo_De_Id=@Tipo_De_Id, Nombres=@Nombres, Apellidos=@Apellidos, Fecha_De_Nacimiento=@Fecha_De_Nacimiento, Edad=@Edad, Sexo=@Sexo, Direccion_Domicilio=@Direccion_Domicilio, Telefono=@Telefono, Rol=@Rol, Correo=@Correo, NombreUsuario=@NombreUsuario, Contraseña=@Contraseña
                                        where Id=@Id";
                command.Parameters.AddWithValue("@Codigo_Usuario", liquidacion.CodigoUsuario);
                command.Parameters.AddWithValue("@Id", liquidacion.Identificacion);
                command.Parameters.AddWithValue("@Tipo_De_Id", liquidacion.TipoDeIdentificacion);
                command.Parameters.AddWithValue("@Nombres", liquidacion.Nombres);
                command.Parameters.AddWithValue("@Apellidos", liquidacion.Apellidos);
                command.Parameters.AddWithValue("@Fecha_De_Nacimiento", liquidacion.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Edad", liquidacion.Edad);
                command.Parameters.AddWithValue("@Sexo", liquidacion.Sexo);
                command.Parameters.AddWithValue("@Direccion_Domicilio", liquidacion.Direccion);
                command.Parameters.AddWithValue("@Telefono", liquidacion.Telefono);
                command.Parameters.AddWithValue("@Rol", liquidacion.Rol);
                command.Parameters.AddWithValue("@Correo", liquidacion.CorreoElectronico);
                command.Parameters.AddWithValue("@NombreUsuario", liquidacion.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", liquidacion.Contraseña);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Liquidacion> ConsultarTodos()
        {
            List<Liquidacion> liquidaciones = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Codigo_Usuario, Id, Tipo_De_Id, Nombres, Apellidos, Fecha_De_Nacimiento, Edad, Sexo, Direccion_Domicilio, Telefono, Rol, Correo, NombreUsuario, Contraseña from USUARIO";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMapToUsuario(dataReader);
                        liquidaciones.Add(liquidacion);
                    }
                }
            }
            return liquidaciones;
        }
        public void Eliminar(Liquidacion liquidacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from USUARIO where Id=@Id";
                command.Parameters.AddWithValue("@Id", Liquidacion.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        private Liquidacion DataReaderMapToUsuario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Liquidacion liquidacion = new Liquidacion();
            liquidacion.CodigoUsuario = (string)dataReader["Codigo_Usuario"];
            liquidacion.Identificacion = (string)dataReader["Id"];
            liquidacion.TipoDeIdentificacion = (string)dataReader["Tipo_De_Id"];
            liquidacion.Nombres = (string)dataReader["Nombres"];
            liquidacion.Apellidos = (string)dataReader["Apellidos"];
            liquidacion.FechaDeNacimiento = (DateTime)dataReader["Fecha_De_Nacimiento"];
            liquidacion.Edad = (int)dataReader["Edad"];
            liquidacion.Sexo = (string)dataReader["Sexo"];
            liquidacion.Direccion = (string)dataReader["Direccion_Domicilio"];
            liquidacion.Telefono = (string)dataReader["Telefono"];
            liquidacion.Rol = (string)dataReader["Rol"];
            liquidacion.CorreoElectronico = (string)dataReader["Correo"];
            liquidacion.NombreUsuario = (string)dataReader["NombreUsuario"];
            liquidacion.Contraseña = (string)dataReader["Contraseña"];
            return liquidacion;
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
