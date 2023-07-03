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
    public class MiembroRepository
    {
        private readonly SqlConnection _connection;
        public MiembroRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Miembro miembro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into MIEMBRO(Folio, ImagenPerfil, Nombre, TipoDoc, NumeroDoc, FechaDeNacimiento, Direccion, Telefono, " +
                    "ParentezcoPadre, ParentezcoMadre, FechaBautizo, TiempoDeConversion, FechaRecepcionEspirituSanto, LugarRecepcionespirituSanto, " +
                    "PastorOficiante, FechaMembresiaIglesiaProcedente, TiempoDeMembresiaIglesiaProcedente, EstadoServicio, FechaDeCorreccion, TiempoEnActoCorrectivo, " +
                    "EstadoMembresia, LugarDeTraslado) " +
                    "Values (@Folio, ImagenPerfil, @Nombre, @TipoDoc, @NumeroDoc, FechaDeNacimiento, Direccion, ParentezcoPadre, ParentezcoMadre, FechaBautizo, " +
                    "TiempoDeConversion, FechaRecepcionEspirituSanto, LugarRecepcionespirituSanto, PastorOficiante, FechaMembresiaIglesiaProcedente, TiempoDeMembresiaIglesiaProcedente, " +
                    "EstadoServicio, FechaDeCorreccion, TiempoEnActoCorrectivo, EstadoMembresia, LugarDeTraslado)";
                command.Parameters.AddWithValue("@Folio", miembro.Folio);
                command.Parameters.AddWithValue("@ImagenPerfil", miembro.ImagenPerfil);
                command.Parameters.AddWithValue("@Nombre", miembro.Nombre);
                command.Parameters.AddWithValue("@TipoDoc", miembro.TipoDoc);
                command.Parameters.AddWithValue("@NumeroDoc", miembro.NumeroDoc);
                command.Parameters.AddWithValue("@FechaDeNacimiento", miembro.FechaNacimiento);
                command.Parameters.AddWithValue("@Direccion", miembro.Direccion);
                command.Parameters.AddWithValue("@Telefono", miembro.Telefono);
                command.Parameters.AddWithValue("@ParentezcoPadre", miembro.ParentezcoPadre);
                command.Parameters.AddWithValue("@ParentezcoMadre", miembro.ParentezcoMadre);
                command.Parameters.AddWithValue("@FechaBautizo", miembro.FechaBautizmo);
                command.Parameters.AddWithValue("@TiempoDeConversion", miembro.TiempoDeConversion);
                command.Parameters.AddWithValue("@FechaRecepcionEspirituSanto", miembro.FechaRecepcionEspirituSanto);
                command.Parameters.AddWithValue("@LugarRecepcionespirituSanto", miembro.LugarRecepcionespirituSanto);
                command.Parameters.AddWithValue("@PastorOficiante", miembro.PastorOficiante);
                command.Parameters.AddWithValue("@FechaMembresiaIglesiaProcedente", miembro.FechaMembresiaIglesiaProcedente);
                command.Parameters.AddWithValue("@TiempoDeMembresiaIglesiaProcedente", miembro.TiempoDeMembresiaIglesiaProcedente);
                command.Parameters.AddWithValue("@EstadoServicio", miembro.EstadoServicio);
                command.Parameters.AddWithValue("@FechaDeCorreccion", miembro.FechaDeCorreccion);
                command.Parameters.AddWithValue("@TiempoEnActoCorrectivo", miembro.TiempoEnActoCorrectivo);
                command.Parameters.AddWithValue("@EstadoMembresia", miembro.EstadoMembresia);
                command.Parameters.AddWithValue("@LugarDeTraslado", miembro.LugarDeTraslado);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Miembro miembro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from MIEMBRO where Folio=@Folio";
                command.Parameters.AddWithValue("@Folio", miembro.Folio);
                command.ExecuteNonQuery();
            }
        }
        public List<Miembro> ConsultarTodos()
        {
            List<Miembro> miembros = new List<Miembro>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Folio, ImagenPerfil, Nombre, TipoDoc, NumeroDoc, FechaDeNacimiento, Direccion, Telefono, ParentezcoPadre, ParentezcoMadre, " +
                    "FechaBautizo, TiempoDeConversion, FechaRecepcionEspirituSanto, LugarRecepcionespirituSanto, PastorOficiante, FechaMembresiaIglesiaProcedente, TiempoDeMembresiaIglesiaProcedente, " +
                    "EstadoServicio, FechaDeCorreccion, TiempoEnActoCorrectivo, EstadoMembresia, LugarDeTraslado from MIEMBRO";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Miembro miembro = DataReaderMapToCliente(dataReader);
                        miembros.Add(miembro);
                    }
                }
            }
            return miembros;
        }
        public Miembro BuscarPorIdentificacion(string folio)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from MIEMBRO where Folio=@Folio";
                command.Parameters.AddWithValue("@Folio", folio);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
        }
        public void Modificar(Miembro miembro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update MIEMBRO set Folio=@Folio, ImagenPerfil=@ImagenPerfil, Nombre=@Nombre, TipoDoc=@TipoDoc, NumeroDoc=@NumeroDoc, FechaDeNacimiento=@FechaDeNacimiento, Direccion=@Direccion, Telefono=@Telefono, ParentezcoPadre=@ParentezcoPadre, ParentezcoMadre=@ParentezcoMadre, 
                    FechaBautizo=@FechaBautizo, TiempoDeConversion=@TiempoDeConversion, FechaRecepcionEspirituSanto=@FechaRecepcionEspirituSanto, LugarRecepcionespirituSanto=@LugarRecepcionespirituSanto, PastorOficiante=@PastorOficiante, FechaMembresiaIglesiaProcedente=@FechaMembresiaIglesiaProcedente, TiempoDeMembresiaIglesiaProcedente=@TiempoDeMembresiaIglesiaProcedente, 
                    EstadoServicio=@EstadoServicio, FechaDeCorreccion=@FechaDeCorreccion, TiempoEnActoCorrectivo=@TiempoEnActoCorrectivo, EstadoMembresia=@EstadoMembresia, LugarDeTraslado=@LugarDeTraslado 
                    where Folio=@Folio";
                command.Parameters.AddWithValue("@Folio", miembro.Folio);
                command.Parameters.AddWithValue("@ImagenPerfil", miembro.ImagenPerfil);
                command.Parameters.AddWithValue("@Nombre", miembro.Nombre);
                command.Parameters.AddWithValue("@TipoDoc", miembro.TipoDoc);
                command.Parameters.AddWithValue("@NumeroDoc", miembro.NumeroDoc);
                command.Parameters.AddWithValue("@FechaDeNacimiento", miembro.FechaNacimiento);
                command.Parameters.AddWithValue("@Direccion", miembro.Direccion);
                command.Parameters.AddWithValue("@Telefono", miembro.Telefono);
                command.Parameters.AddWithValue("@ParentezcoPadre", miembro.ParentezcoPadre);
                command.Parameters.AddWithValue("@ParentezcoMadre", miembro.ParentezcoMadre);
                command.Parameters.AddWithValue("@FechaBautizo", miembro.FechaBautizmo);
                command.Parameters.AddWithValue("@TiempoDeConversion", miembro.TiempoDeConversion);
                command.Parameters.AddWithValue("@FechaRecepcionEspirituSanto", miembro.FechaRecepcionEspirituSanto);
                command.Parameters.AddWithValue("@LugarRecepcionespirituSanto", miembro.LugarRecepcionespirituSanto);
                command.Parameters.AddWithValue("@PastorOficiante", miembro.PastorOficiante);
                command.Parameters.AddWithValue("@FechaMembresiaIglesiaProcedente", miembro.FechaMembresiaIglesiaProcedente);
                command.Parameters.AddWithValue("@TiempoDeMembresiaIglesiaProcedente", miembro.TiempoDeMembresiaIglesiaProcedente);
                command.Parameters.AddWithValue("@EstadoServicio", miembro.EstadoServicio);
                command.Parameters.AddWithValue("@FechaDeCorreccion", miembro.FechaDeCorreccion);
                command.Parameters.AddWithValue("@TiempoEnActoCorrectivo", miembro.TiempoEnActoCorrectivo);
                command.Parameters.AddWithValue("@EstadoMembresia", miembro.EstadoMembresia);
                command.Parameters.AddWithValue("@LugarDeTraslado", miembro.LugarDeTraslado);
            }
        }
        private Miembro DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Miembro miembro = new Miembro();
            miembro.Folio = (string)dataReader["Folio"];
            miembro.ImagenPerfil = (byte[])dataReader["ImagenPerfil"];
            miembro.Nombre = (string)dataReader["Nombre"];
            miembro.TipoDoc = (string)dataReader["TipoDoc"];
            miembro.NumeroDoc = (string)dataReader["NumeroDoc"];
            miembro.FechaNacimiento = (DateTime)dataReader["FechaDeNacimiento"];
            miembro.Direccion = (string)dataReader["Direccion"];
            miembro.Telefono = (string)dataReader["Telefono"];
            miembro.ParentezcoPadre = (string)dataReader["ParentezcoPadre"];
            miembro.ParentezcoMadre = (string)dataReader["ParentezcoMadre"];
            miembro.FechaBautizmo = (DateTime)dataReader["FechaBautizo"];
            miembro.TiempoDeConversion = (int)dataReader["TiempoDeConversion"];
            miembro.FechaRecepcionEspirituSanto = (DateTime)dataReader["FechaRecepcionEspirituSanto"];
            miembro.LugarRecepcionespirituSanto = (string)dataReader["LugarRecepcionespirituSanto"];
            miembro.PastorOficiante = (string)dataReader["PastorOficiante"];
            miembro.FechaMembresiaIglesiaProcedente = (DateTime)dataReader["FechaMembresiaIglesiaProcedente"];
            miembro.TiempoDeMembresiaIglesiaProcedente = (int)dataReader["TiempoDeMembresiaIglesiaProcedente"];
            miembro.EstadoServicio = (string)dataReader["EstadoServicio"];
            miembro.FechaDeCorreccion = (DateTime)dataReader["FechaDeCorreccion"];
            miembro.TiempoEnActoCorrectivo = (int)dataReader["TiempoDeConversion"];
            miembro.EstadoMembresia = (string)dataReader["FechaBautizo"];
            miembro.LugarDeTraslado = (string)dataReader["LugarDeTraslado"];
            return miembro;
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
