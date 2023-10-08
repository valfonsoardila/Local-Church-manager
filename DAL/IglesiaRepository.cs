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
        public void Guardar(Iglesia iglesia)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into IGLESIA (Id_Iglesia, Nombre_De_Iglesia, NIT, CodigoCamara, Frase_Distintiva, Regimen, PBX,Direccion,Telefono) 
                                        values (@Id_Iglesia, @Nombre_De_Iglesia, @NIT, @CodigoCamara, @Frase_Distintiva, @Regimen, @PBX, @Direccion, @Telefono)";
                command.Parameters.AddWithValue("@Id_Iglesia", iglesia.IdIglesia);
                command.Parameters.AddWithValue("@Nombre_De_Iglesia", iglesia.NombreIglesia);
                command.Parameters.AddWithValue("@NIT", iglesia.NIT);
                command.Parameters.AddWithValue("@CodigoCamara", iglesia.CodigoDeCamara);
                command.Parameters.AddWithValue("@Frase_Distintiva", iglesia.FraseDistintiva);
                command.Parameters.AddWithValue("@Regimen", iglesia.Regimen);
                command.Parameters.AddWithValue("@PBX", iglesia.PBX);
                command.Parameters.AddWithValue("@Direccion", iglesia.Direccion);
                command.Parameters.AddWithValue("@Telefono", iglesia.Telefono);
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
                        Iglesia iglesia = DataReaderMapToIglesia(dataReader);
                        cajas.Add(iglesia);
                    }
                }
            }
            return cajas;
        }
        public void Modificar(Iglesia iglesia)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update IGLESIA set Nombre_De_Iglesia=@Nombre_De_Iglesia, NIT=@NIT, CodigoCamara=@CodigoCamara, Frase_Distintiva=@Frase_Distintiva, Regimen=@Regimen, PBX=@PBX, Direccion=@Direccion, Telefono=@Telefono
                                        where Id_Iglesia=@Id_Iglesia";
                command.Parameters.AddWithValue("@Id_Iglesia", iglesia.IdIglesia);
                command.Parameters.AddWithValue("@Nombre_De_Iglesia", iglesia.NombreIglesia);
                command.Parameters.AddWithValue("@NIT", iglesia.NIT);
                command.Parameters.AddWithValue("@CodigoCamara", iglesia.CodigoDeCamara);
                command.Parameters.AddWithValue("@Frase_Distintiva", iglesia.FraseDistintiva);
                command.Parameters.AddWithValue("@Regimen", iglesia.Regimen);
                command.Parameters.AddWithValue("@PBX", iglesia.PBX);
                command.Parameters.AddWithValue("@Direccion", iglesia.Direccion);
                command.Parameters.AddWithValue("@Telefono", iglesia.Telefono);
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
        public void Eliminar(Iglesia iglesia)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from IGLESIA where Id_Iglesia=@Id_Iglesia";
                command.Parameters.AddWithValue("@Id_Iglesia", iglesia.IdIglesia);
                command.ExecuteNonQuery();
            }
        }
        private Iglesia DataReaderMapToIglesia(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Iglesia iglesia = new Iglesia();
            iglesia.IdIglesia = (string)dataReader["Id_Iglesia"];
            iglesia.NombreIglesia = (string)dataReader["Nombre_De_Iglesia"];
            iglesia.NIT = (string)dataReader["NIT"];
            iglesia.CodigoDeCamara = (string)dataReader["CodigoCamara"];
            iglesia.FraseDistintiva = (string)dataReader["Frase_Distintiva"];
            iglesia.Regimen = (string)dataReader["Regimen"];
            iglesia.PBX = (string)dataReader["PBX"];
            iglesia.Direccion = (string)dataReader["Direccion"];
            iglesia.Telefono = (string)dataReader["Telefono"];
            return iglesia;
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
