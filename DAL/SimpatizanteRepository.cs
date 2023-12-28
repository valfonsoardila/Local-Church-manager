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
    public class SimpatizanteRepository
    {
        private readonly SqlConnection _connection;
        public SimpatizanteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Simpatizante simpatizante)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into SIMPATIZANTE (IdContacto, ImagenPerfil, Nombre, Apellido, TipoDoc, NumeroDoc, FechaDeNacimiento, Edad, Genero, Oficio, Direccion, Telefono)";
                command.Parameters.AddWithValue("@IdContacto", simpatizante.IdContacto);
                command.Parameters.AddWithValue("@ImagenPerfil", simpatizante.ImagenPerfil);
                command.Parameters.AddWithValue("@Nombre", simpatizante.Nombre);
                command.Parameters.AddWithValue("@Apellido", simpatizante.Apellido);
                command.Parameters.AddWithValue("@TipoDoc", simpatizante.TipoDoc);
                command.Parameters.AddWithValue("@NumeroDoc", simpatizante.NumeroDoc);
                command.Parameters.AddWithValue("@FechaDeNacimiento", simpatizante.FechaNacimiento);
                command.Parameters.AddWithValue("@Edad", simpatizante.Edad);
                command.Parameters.AddWithValue("@Genero", simpatizante.Genero);
                command.Parameters.AddWithValue("@Oficio", simpatizante.Oficio);
                command.Parameters.AddWithValue("@Direccion", simpatizante.Direccion);
                command.Parameters.AddWithValue("@Telefono", simpatizante.Telefono);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Simpatizante simpatizante)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from SIMPATIZANTE where NumeroDoc=@NumeroDoc";
                command.Parameters.AddWithValue("@NumeroDoc", simpatizante.NumeroDoc);
                command.ExecuteNonQuery();
            }
        }
        public List<Simpatizante> ConsultarTodos()
        {
            List<Simpatizante> miembros = new List<Simpatizante>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select IdContacto, ImagenPerfil, Nombre, Apellido, TipoDoc, NumeroDoc, FechaDeNacimiento, Edad, Genero, Oficio, Direccion, Telefono from SIMPATIZANTE";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Simpatizante simpatizante = DataReaderMapToCliente(dataReader);
                        miembros.Add(simpatizante);
                    }
                }
            }
            return miembros;
        }
        public List<Simpatizante> BuscarPorFamilia(string apellido)
        {
            List<Simpatizante> miembros = new List<Simpatizante>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SIMPATIZANTE where Apellido=@Apellido";
                command.Parameters.AddWithValue("@Apellido", apellido);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Simpatizante simpatizante = DataReaderMapToCliente(dataReader);
                        miembros.Add(simpatizante);
                    }
                }
            }
            return miembros;
        }
        public Simpatizante BuscarPorgnero(string genero)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SIMPATIZANTE where Genero=@Genero";
                command.Parameters.AddWithValue("@Genero", genero);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public Simpatizante BuscarPorIdentificacion(string folio)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from SIMPATIZANTE where Folio=@Folio";
                command.Parameters.AddWithValue("@Folio", folio);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Simpatizante simpatizanteNuevo)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update SIMPATIZANTE set ImagenPerfil=@ImagenPerfil, IdContacto=@IdContacto, Nombre=@Nombre, Apellido=@Apellido, TipoDoc=@TipoDoc, NumeroDoc=@NumeroDoc, FechaDeNacimiento=@FechaDeNacimiento, Edad=@Edad, Genero=@Genero, Oficio=@Oficio, Direccion=@Direccion, Telefono=@Telefono
                    where NumeroDoc=@NumeroDoc";
                command.Parameters.AddWithValue("@IdContacto", simpatizanteNuevo.IdContacto);
                command.Parameters.AddWithValue("@ImagenPerfil", simpatizanteNuevo.ImagenPerfil);
                command.Parameters.AddWithValue("@Nombre", simpatizanteNuevo.Nombre);
                command.Parameters.AddWithValue("@Apellido", simpatizanteNuevo.Apellido);
                command.Parameters.AddWithValue("@TipoDoc", simpatizanteNuevo.TipoDoc);
                command.Parameters.AddWithValue("@NumeroDoc", simpatizanteNuevo.NumeroDoc);
                command.Parameters.AddWithValue("@FechaDeNacimiento", simpatizanteNuevo.FechaNacimiento);
                command.Parameters.AddWithValue("@Edad", simpatizanteNuevo.Edad);
                command.Parameters.AddWithValue("@Genero", simpatizanteNuevo.Genero);
                command.Parameters.AddWithValue("@Oficio", simpatizanteNuevo.Oficio);
                command.Parameters.AddWithValue("@Direccion", simpatizanteNuevo.Direccion);
                command.Parameters.AddWithValue("@Telefono", simpatizanteNuevo.Telefono);
                var filas = command.ExecuteNonQuery();
            }
        }
        private Simpatizante DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Simpatizante simpatizante = new Simpatizante();
            simpatizante.ImagenPerfil = (byte[])dataReader["ImagenPerfil"];
            simpatizante.IdContacto = (string)dataReader["IdContacto"];
            simpatizante.Nombre = (string)dataReader["Nombre"];
            simpatizante.Apellido = (string)dataReader["Apellido"];
            simpatizante.TipoDoc = (string)dataReader["TipoDoc"];
            simpatizante.NumeroDoc = (string)dataReader["NumeroDoc"];
            simpatizante.FechaNacimiento = (DateTime)dataReader["FechaDeNacimiento"];
            simpatizante.Edad = (int)dataReader["Edad"];
            simpatizante.Genero = (string)dataReader["Genero"];
            simpatizante.Oficio = (string)dataReader["Oficio"];
            simpatizante.Direccion = (string)dataReader["Direccion"];
            simpatizante.Telefono = (string)dataReader["Telefono"];
            return simpatizante;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Genero.Equals(tipo)).Count();
        }
    }
}
