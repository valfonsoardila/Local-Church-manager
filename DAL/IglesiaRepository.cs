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
    public class IglesiaRepository
    {
        private readonly SqlConnection _connection;
        public IglesiaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Iglesia drogueria)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into IGLESIA (Id_Iglesia, Nombre_De_Iglesia, NIT, CodigoCamara, Frase_Distintiva, Regimen, PBX,Direccion,Telefono) 
                                        values (@Id_Iglesia, @Nombre_De_Iglesia, @NIT, @CodigoCamara, @Frase_Distintiva, @Regimen, @PBX, @Direccion, @Telefono)";
                command.Parameters.AddWithValue("@Id_Iglesia", drogueria.IdIglesia);
                command.Parameters.AddWithValue("@Nombre_De_Iglesia", drogueria.NombreIglesia);
                command.Parameters.AddWithValue("@NIT", drogueria.NIT);
                command.Parameters.AddWithValue("@CodigoCamara", drogueria.CodigoDeCamara);
                command.Parameters.AddWithValue("@Frase_Distintiva", drogueria.FraseDistintiva);
                command.Parameters.AddWithValue("@Regimen", drogueria.Regimen);
                command.Parameters.AddWithValue("@PBX", drogueria.PBX);
                command.Parameters.AddWithValue("@Direccion", drogueria.Direccion);
                command.Parameters.AddWithValue("@Telefono", drogueria.Telefono);
                var filas = command.ExecuteNonQuery();
            }
        }
        public List<Iglesia> ConsultarTodos()
        {
            List<Iglesia> cajas = new List<Iglesia>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Id_Iglesia, Nombre_De_Iglesia, NIT, CodigoCamara, Frase_Distintiva, Regimen, PBX, Direccion, Telefono from IGLESIA";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Iglesia drogueria = DataReaderMapToIglesia(dataReader);
                        cajas.Add(drogueria);
                    }
                }
            }
            return cajas;
        }
        public void Modificar(Iglesia drogueria)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update IGLESIA set Nombre_De_Iglesia=@Nombre_De_Iglesia, NIT=@NIT, CodigoCamara=@CodigoCamara, Frase_Distintiva=@Frase_Distintiva, Regimen=@Regimen, PBX=@PBX, Direccion=@Direccion, Telefono=@Telefono
                                        where Id_Iglesia=@Id_Iglesia";
                command.Parameters.AddWithValue("@Id_Iglesia", drogueria.IdIglesia);
                command.Parameters.AddWithValue("@Nombre_De_Iglesia", drogueria.NombreIglesia);
                command.Parameters.AddWithValue("@NIT", drogueria.NIT);
                command.Parameters.AddWithValue("@CodigoCamara", drogueria.CodigoDeCamara);
                command.Parameters.AddWithValue("@Frase_Distintiva", drogueria.FraseDistintiva);
                command.Parameters.AddWithValue("@Regimen", drogueria.Regimen);
                command.Parameters.AddWithValue("@PBX", drogueria.PBX);
                command.Parameters.AddWithValue("@Direccion", drogueria.Direccion);
                command.Parameters.AddWithValue("@Telefono", drogueria.Telefono);
                var filas = command.ExecuteNonQuery();
            }
        }
        public Iglesia BuscarPorId(string nit)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from IGLESIA where Id_Iglesia=@Id_Iglesia";
                command.Parameters.AddWithValue("@Id_Iglesia", nit);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToIglesia(dataReader);
            }
        }
        public void Eliminar(Iglesia drogueria)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from IGLESIA where Id_Iglesia=@Id_Iglesia";
                command.Parameters.AddWithValue("@Id_Iglesia", drogueria.IdIglesia);
                command.ExecuteNonQuery();
            }
        }
        private Iglesia DataReaderMapToIglesia(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Iglesia drogueria = new Iglesia();
            drogueria.IdIglesia = (string)dataReader["Id_Iglesia"];
            drogueria.NombreIglesia = (string)dataReader["Nombre_De_Iglesia"];
            drogueria.NIT = (string)dataReader["NIT"];
            drogueria.CodigoDeCamara = (string)dataReader["CodigoCamara"];
            drogueria.FraseDistintiva = (string)dataReader["Frase_Distintiva"];
            drogueria.Regimen = (string)dataReader["Regimen"];
            drogueria.PBX = (string)dataReader["PBX"];
            drogueria.Direccion = (string)dataReader["Direccion"];
            drogueria.Telefono = (string)dataReader["Telefono"];
            return drogueria;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {

            return ConsultarTodos().Where(p => p.IdIglesia.Equals(tipo)).Count();
        }
    }
}
