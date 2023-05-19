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
    public class SoftwareRepository
    {
        private readonly SqlConnection _connection;
        public SoftwareRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Software software)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into SOFTWARE(Nombre_De_Software, Fecha_De_Instalacion, Fecha_De_Expiracion, Hora_De_Expiracion, Fecha_De_Activacion, Hora_De_Activacion, Estado_De_Licencia) 
                                        Values(@Nombre_De_Software, @Fecha_De_Instalacion, @Fecha_De_Expiracion, @Hora_De_Expiracion, @Fecha_De_Activacion, @Hora_De_Activacion, @Estado_De_Licencia)";
                command.Parameters.AddWithValue("@Nombre_De_Software", software.NombreDeSoftware);
                command.Parameters.AddWithValue("@Fecha_De_Instalacion", software.FechaDeInstalacion);
                command.Parameters.AddWithValue("@Fecha_De_Expiracion", software.FechaDeExpiracion);
                command.Parameters.AddWithValue("@Hora_De_Expiracion", software.HoraDeExpiracion);
                command.Parameters.AddWithValue("@Fecha_De_Activacion", software.FechaDeActivacion);
                command.Parameters.AddWithValue("@Hora_De_Activacion", software.HoraDeActivacion);
                command.Parameters.AddWithValue("@Estado_De_Licencia", software.EstadoDeLicencia);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Software> BuscarPorEstado(string estado)
        {
            List<Software> softwares = new List<Software>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SOFTWARE where Estado_De_Licencia=@Estado_De_Licencia";
                command.Parameters.AddWithValue("@Estado_De_Licencia", estado);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Software software = DataReaderMapToSoftware(dataReader);
                        softwares.Add(software);
                    }
                }
            }
            return softwares;
        }
        public List<Software> ConsultarPorNombreDeSoftware(string nombre)
        {
            List<Software> softwares = new List<Software>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SOFTWARE where Nombre_De_Software=@Nombre_De_Software";
                command.Parameters.AddWithValue("@Nombre_De_Software", nombre);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Software software = DataReaderMapToSoftware(dataReader);
                        softwares.Add(software);
                    }
                }
            }
            return softwares;
        }
        public Software BuscarPorNombreDeSoftware(string nombre)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SOFTWARE where Nombre_De_Software=@Nombre_De_Software";
                command.Parameters.AddWithValue("@Nombre_De_Software", nombre);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToSoftware(dataReader);
            }
        }
        public void Modificar(Software software)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update SOFTWARE set Fecha_De_Instalacion=@Fecha_De_Instalacion, Fecha_De_Expiracion=@Fecha_De_Expiracion, Hora_De_Expiracion=@Hora_De_Expiracion, Fecha_De_Activacion=@Fecha_De_Activacion, Hora_De_Activacion=@Hora_De_Activacion, Estado_De_Licencia=@Estado_De_Licencia
                                        where Nombre_De_Software=@Nombre_De_Software";
                command.Parameters.AddWithValue("@Nombre_De_Software", software.FechaDeInstalacion);
                command.Parameters.AddWithValue("@Fecha_De_Instalacion", software.FechaDeInstalacion);
                command.Parameters.AddWithValue("@Fecha_De_Expiracion", software.FechaDeExpiracion);
                command.Parameters.AddWithValue("@Hora_De_Expiracion", software.HoraDeExpiracion);
                command.Parameters.AddWithValue("@Fecha_De_Activacion", software.FechaDeExpiracion);
                command.Parameters.AddWithValue("@Hora_De_Activacion", software.HoraDeExpiracion);
                command.Parameters.AddWithValue("@Estado_De_Licencia", software.HoraDeExpiracion);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Software> ConsultarTodos()
        {
            List<Software> softwares = new List<Software>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Nombre_De_Software, Fecha_De_Instalacion, Fecha_De_Expiracion, Hora_De_Expiracion, Fecha_De_Activacion, Hora_De_Activacion, Estado_De_Licencia from SOFTWARE";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Software software = DataReaderMapToSoftware(dataReader);
                        softwares.Add(software);
                    }
                }
            }
            return softwares;

        }
        public void Eliminar(Software software)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from SOFTWARE where Nombre_De_Software=@Nombre_De_Software";
                command.Parameters.AddWithValue("@Nombre_De_Software", software.NombreDeSoftware);
                command.ExecuteNonQuery();
            }
        }
        private Software DataReaderMapToSoftware(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Software software = new Software();
            software.NombreDeSoftware = (string)dataReader["Nombre_De_Software"];
            software.FechaDeInstalacion = (DateTime)dataReader["Fecha_De_Instalacion"];
            software.FechaDeExpiracion = (string)dataReader["Fecha_De_Expiracion"];
            software.HoraDeExpiracion = (string)dataReader["Hora_De_Expiracion"];
            software.FechaDeActivacion = (string)dataReader["Fecha_De_Activacion"];
            software.HoraDeActivacion = (string)dataReader["Hora_De_Activacion"];
            software.EstadoDeLicencia = (string)dataReader["Estado_De_Licencia"];
            return software;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {

            return ConsultarTodos().Where(p => p.EstadoDeLicencia.Equals(tipo)).Count();
        }
    }
}
