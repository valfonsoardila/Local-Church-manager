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
    public class LicenciaRepository
    {
        private readonly SqlConnection _connection;
        public LicenciaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Licencia licencia)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into LICENCIA (Licencia) 
                                        values (@Licencia)";
                command.Parameters.AddWithValue("@Licencia", licencia.LicenciaSoftware);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Licencia> BuscarPorLicencias(string licenciaSoftware)
        {
            List<Licencia> licencias = new List<Licencia>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from LICENCIA where Licencia=@Licencia";
                command.Parameters.AddWithValue("@Licencia", licenciaSoftware);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Licencia licencia = DataReaderMapToLicencia(dataReader);
                        licencias.Add(licencia);
                    }
                }
            }
            return licencias;
        }
        public Licencia BuscarPorLicencia(string licenciaSoftware)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from LICENCIA where Licencia=@Licencia";
                command.Parameters.AddWithValue("@Licencia", licenciaSoftware);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToLicencia(dataReader);
            }
        }
        public void Modificar(Licencia licencia)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update LICENCIA set Licenciad=@Licenciad
                                        where Licenciad=@Licenciad";
                command.Parameters.AddWithValue("@Licenciad", licencia.LicenciaSoftware);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Licencia> ConsultarTodos()
        {
            List<Licencia> licencias = new List<Licencia>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Licenciad from LICENCIA";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Licencia licencia = DataReaderMapToLicencia(dataReader);
                        licencias.Add(licencia);
                    }
                }
            }
            return licencias;

        }
        public void Eliminar(Licencia licencia)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from LICENCIA where Licenciad=@Licenciad";
                command.Parameters.AddWithValue("@Licenciad", licencia.LicenciaSoftware);
                command.ExecuteNonQuery();
            }
        }
        private Licencia DataReaderMapToLicencia(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Licencia licencia = new Licencia();
            licencia.LicenciaSoftware = (string)dataReader["Licencia"];
            return licencia;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {

            return ConsultarTodos().Where(p => p.LicenciaSoftware.Equals(tipo)).Count();
        }
    }
}
