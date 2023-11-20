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
                command.CommandText = "Insert Into MIEMBRO (Folio, ImagenPerfil, IdContacto, Nombre, Apellido, TipoDoc, NumeroDoc, FechaDeNacimiento, Edad, Genero, Oficio, Direccion, Telefono, " +
                    "ParentezcoPadre, ParentezcoMadre, EstadoCivil, NumeroHijos, NombreConyugue, Bautizado, " +
                    "FechaDeBautizmo, LugarBautizmo, PastorOficiante, Sellado, SelladoRecuerdo, TiempoConversion, " +
                    "TiempoPromesa, IglesiaProcedente, PastorAsistente, CargosDesempeñados, Acto, FechaCorreccion, TiempoCorreccion, Membresia, LugarTraslado, Observaciones) Values (@Folio, @ImagenPerfil, @IdContacto, @Nombre, @Apellido, @TipoDoc, @NumeroDoc, @FechaDeNacimiento, @Edad, @Genero, @Oficio, @Direccion, @Telefono, @ParentezcoPadre, @ParentezcoMadre, @EstadoCivil, " +
                    "@NumeroHijos, @NombreConyugue, @Bautizado, @FechaDeBautizmo, @LugarBautizmo, @PastorOficiante, " +
                    "@Sellado, @SelladoRecuerdo, @TiempoConversion, @TiempoPromesa, @IglesiaProcedente, @PastorAsistente, @CargosDesempeñados, @Acto, @FechaCorreccion, @TiempoCorreccion, @Membresia, @LugarTraslado, @Observaciones)";
                command.Parameters.AddWithValue("@Folio", miembro.Folio);
                command.Parameters.AddWithValue("@IdContacto", miembro.IdContacto);
                command.Parameters.AddWithValue("@ImagenPerfil", miembro.ImagenPerfil);
                command.Parameters.AddWithValue("@Nombre", miembro.Nombre);
                command.Parameters.AddWithValue("@Apellido", miembro.Apellido);
                command.Parameters.AddWithValue("@TipoDoc", miembro.TipoDoc);
                command.Parameters.AddWithValue("@NumeroDoc", miembro.NumeroDoc);
                command.Parameters.AddWithValue("@FechaDeNacimiento", miembro.FechaNacimiento);
                command.Parameters.AddWithValue("@Edad", miembro.Edad);
                command.Parameters.AddWithValue("@Genero", miembro.Genero);
                command.Parameters.AddWithValue("@Oficio", miembro.Oficio);
                command.Parameters.AddWithValue("@Direccion", miembro.Direccion);
                command.Parameters.AddWithValue("@Telefono", miembro.Telefono);
                command.Parameters.AddWithValue("@ParentezcoPadre", miembro.ParentezcoPadre);
                command.Parameters.AddWithValue("@ParentezcoMadre", miembro.ParentezcoMadre);
                command.Parameters.AddWithValue("@EstadoCivil", miembro.EstadoCivil);
                command.Parameters.AddWithValue("@NumeroHijos", miembro.NumeroHijos);
                command.Parameters.AddWithValue("@NombreConyugue", miembro.NombreConyugue);
                command.Parameters.AddWithValue("@Bautizado", miembro.Bautizado);
                command.Parameters.AddWithValue("@FechaDeBautizmo", miembro.FechaDeBautizmo);
                command.Parameters.AddWithValue("@LugarBautizmo", miembro.LugarBautizmo);
                command.Parameters.AddWithValue("@PastorOficiante", miembro.PastorOficiante);
                command.Parameters.AddWithValue("@Sellado", miembro.Sellado);
                command.Parameters.AddWithValue("@SelladoRecuerdo", miembro.SelladoRecuerdo);
                command.Parameters.AddWithValue("@TiempoConversion", miembro.TiempoConversion);
                command.Parameters.AddWithValue("@TiempoPromesa", miembro.TiempoPromesa);
                command.Parameters.AddWithValue("@IglesiaProcedente", miembro.IglesiaProcedente);
                command.Parameters.AddWithValue("@PastorAsistente", miembro.PastorAsistente);
                command.Parameters.AddWithValue("@CargosDesempeñados", miembro.CargosDesempenados);
                command.Parameters.AddWithValue("@Acto", miembro.Acto);
                command.Parameters.AddWithValue("@FechaCorreccion", miembro.FechaCorreccion);
                command.Parameters.AddWithValue("@TiempoCorreccion", miembro.TiempoCorreccion);
                command.Parameters.AddWithValue("@Membresia", miembro.Membresia);
                command.Parameters.AddWithValue("@LugarTraslado", miembro.LugarTraslado);
                command.Parameters.AddWithValue("@Observaciones", miembro.Observaciones);
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
                command.CommandText = "Select Folio, ImagenPerfil, IdContacto, Nombre, Apellido, TipoDoc, NumeroDoc, FechaDeNacimiento, Edad, Genero, Direccion, Telefono, ParentezcoPadre, ParentezcoMadre," +
                    "EstadoCivil, NumeroHijos, NombreConyugue, Bautizado, FechaDeBautizmo, LugarBautizmo, PastorOficiante, Sellado, SelladoRecuerdo, TiempoConversion, TiempoPromesa, IglesiaProcedente, " +
                    "PastorAsistente, CargosDesempeñados, Acto, FechaCorreccion, TiempoCorreccion, Membresia, LugarTraslado, Observaciones from MIEMBRO";
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
        public List<Miembro> BuscarPorFamilia(string apellido)
        {
            List<Miembro> miembros = new List<Miembro>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from MIEMBRO where Apellido=@Apellido";
                command.Parameters.AddWithValue("@Apellido", apellido);
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
        public Miembro BuscarPorgnero(string genero)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from MIEMBRO where Genero=@Genero";
                command.Parameters.AddWithValue("@Genero", genero);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToCliente(dataReader);
            }
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
        public void Modificar(Miembro miembroNuevo)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update MIEMBRO set Folio=@Folio, ImagenPerfil=@ImagenPerfil, IdContacto=@IdContacto, Nombre=@Nombre, Apellido=@Apellido, TipoDoc=@TipoDoc, NumeroDoc=@NumeroDoc, FechaDeNacimiento=@FechaDeNacimiento, Edad=@Edad, Genero=@Genero, Oficio=@Oficio, Direccion=@Direccion, Telefono=@Telefono, ParentezcoPadre=@ParentezcoPadre, ParentezcoMadre=@ParentezcoMadre, 
                    FechaBautizo=@FechaBautizo, TiempoDeConversion=@TiempoDeConversion, FechaRecepcionEspirituSanto=@FechaRecepcionEspirituSanto, LugarRecepcionespirituSanto=@LugarRecepcionespirituSanto, PastorOficiante=@PastorOficiante, FechaMembresiaIglesiaProcedente=@FechaMembresiaIglesiaProcedente, TiempoDeMembresiaIglesiaProcedente=@TiempoDeMembresiaIglesiaProcedente, 
                    EstadoCivil=@EstadoCivil, NumeroHijos=@NumeroHijos, NombreConyugue=@NombreConyugue, Bautizado=@Bautizado, FechaDeBautizmo=@FechaDeBautizmo, PastorOficiante=@PastorOficiante, Sellado=@Sellado, SelladoRecuerdo=@SelladoRecuerdo, TiempoConversion=@TiempoConversion, TiempoPromesa=@TiempoPromesa, IglesiaProcedente=@IglesiaProcedente, PastorAsistente=@PastorAsistente, CargosDesempeñados=@CargosDesempeñados, 
                    Acto=@Acto, FechaCorreccion=@FechaCorreccion, TiempoCorreccion=@TiempoCorreccion, Membresia=@Membresia, LugarTraslado=@LugarTraslado, Observaciones=@Observaciones
                    where Folio=@Folio";
                command.Parameters.AddWithValue("@Folio", miembroNuevo.Folio);
                command.Parameters.AddWithValue("@IdContacto", miembroNuevo.IdContacto);
                command.Parameters.AddWithValue("@ImagenPerfil", miembroNuevo.ImagenPerfil);
                command.Parameters.AddWithValue("@Nombre", miembroNuevo.Nombre);
                command.Parameters.AddWithValue("@Apellido", miembroNuevo.Apellido);
                command.Parameters.AddWithValue("@TipoDoc", miembroNuevo.TipoDoc);
                command.Parameters.AddWithValue("@NumeroDoc", miembroNuevo.NumeroDoc);
                command.Parameters.AddWithValue("@FechaDeNacimiento", miembroNuevo.FechaNacimiento);
                command.Parameters.AddWithValue("@Edad", miembroNuevo.Edad);
                command.Parameters.AddWithValue("@Genero", miembroNuevo.Genero);
                command.Parameters.AddWithValue("@Oficio", miembroNuevo.Oficio);
                command.Parameters.AddWithValue("@Direccion", miembroNuevo.Direccion);
                command.Parameters.AddWithValue("@Telefono", miembroNuevo.Telefono);
                command.Parameters.AddWithValue("@ParentezcoPadre", miembroNuevo.ParentezcoPadre);
                command.Parameters.AddWithValue("@ParentezcoMadre", miembroNuevo.ParentezcoMadre);
                command.Parameters.AddWithValue("@EstadoCivil", miembroNuevo.EstadoCivil);
                command.Parameters.AddWithValue("@NumeroHijos", miembroNuevo.NumeroHijos);
                command.Parameters.AddWithValue("@NombreConyugue", miembroNuevo.NombreConyugue);
                command.Parameters.AddWithValue("@Bautizado", miembroNuevo.Bautizado);
                command.Parameters.AddWithValue("@FechaDeBautizmo", miembroNuevo.FechaDeBautizmo);
                command.Parameters.AddWithValue("@LugarBautizmo", miembroNuevo.LugarBautizmo);
                command.Parameters.AddWithValue("@PastorOficiante", miembroNuevo.PastorOficiante);
                command.Parameters.AddWithValue("@Sellado", miembroNuevo.Sellado);
                command.Parameters.AddWithValue("@SelladoRecuerdo", miembroNuevo.SelladoRecuerdo);
                command.Parameters.AddWithValue("@TiempoConversion", miembroNuevo.TiempoConversion);
                command.Parameters.AddWithValue("@TiempoPromesa", miembroNuevo.TiempoPromesa);
                command.Parameters.AddWithValue("@IglesiaProcedente", miembroNuevo.IglesiaProcedente);
                command.Parameters.AddWithValue("@PastorAsistente", miembroNuevo.PastorAsistente);
                command.Parameters.AddWithValue("@CargosDesempeñados", miembroNuevo.CargosDesempenados);
                command.Parameters.AddWithValue("@Acto", miembroNuevo.Acto);
                command.Parameters.AddWithValue("@FechaCorreccion", miembroNuevo.FechaCorreccion);
                command.Parameters.AddWithValue("@TiempoCorreccion", miembroNuevo.TiempoCorreccion);
                command.Parameters.AddWithValue("@Membresia", miembroNuevo.Membresia);
                command.Parameters.AddWithValue("@LugarTraslado", miembroNuevo.LugarTraslado);
                command.Parameters.AddWithValue("@Observaciones", miembroNuevo.Observaciones);
                var filas = command.ExecuteNonQuery();
            }
        }
        private Miembro DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Miembro miembro = new Miembro();
            miembro.Folio = (string)dataReader["Folio"];
            miembro.ImagenPerfil = (byte[])dataReader["ImagenPerfil"];
            miembro.IdContacto = (string)dataReader["IdContacto"];
            miembro.Nombre = (string)dataReader["Nombre"];
            miembro.Apellido = (string)dataReader["Apellido"];
            miembro.TipoDoc = (string)dataReader["TipoDoc"];
            miembro.NumeroDoc = (string)dataReader["NumeroDoc"];
            miembro.FechaNacimiento = (DateTime)dataReader["FechaDeNacimiento"];
            miembro.Edad = (int)dataReader["Edad"];
            miembro.Genero = (string)dataReader["Genero"];
            miembro.Oficio = (string)dataReader["Oficio"];
            miembro.Direccion = (string)dataReader["Direccion"];
            miembro.Telefono = (string)dataReader["Telefono"];
            miembro.ParentezcoPadre = (string)dataReader["ParentezcoPadre"];
            miembro.ParentezcoMadre = (string)dataReader["ParentezcoMadre"];
            miembro.EstadoCivil = (string)dataReader["EstadoCivil"];
            miembro.NumeroHijos = (int)dataReader["NumeroHijos"];
            miembro.NombreConyugue = (string)dataReader["NombreConyugue"];
            miembro.PastorOficiante = (string)dataReader["Bautizado"];
            miembro.FechaDeBautizmo = (DateTime)dataReader["FechaDeBautizmo"];
            miembro.LugarBautizmo = (string)dataReader["LugarBautizmo"];
            miembro.PastorOficiante = (string)dataReader["PastorOficiante"];
            miembro.Sellado = (string)dataReader["Sellado"];
            miembro.SelladoRecuerdo = (string)dataReader["SelladoRecuerdo"];
            miembro.FechaPromesa = (DateTime)dataReader["FechaSellado"];
            miembro.TiempoConversion = (int)dataReader["TiempoConversion"];
            miembro.TiempoPromesa = (int)dataReader["TiempoPromesa"];
            miembro.IglesiaProcedente = (string)dataReader["IglesiaProcedente"];
            miembro.PastorAsistente = (string)dataReader["PastorAsistente"];
            miembro.CargosDesempenados = (string)dataReader["CargosDesempeñados"];
            miembro.Acto = (string)dataReader["Acto"];
            miembro.FechaCorreccion = (DateTime)dataReader["FechaCorreccion"];
            miembro.TiempoCorreccion = (int)dataReader["TiempoCorreccion"];
            miembro.Membresia = (string)dataReader["Membresia"];
            miembro.LugarTraslado = (string)dataReader["LugarTraslado"];
            miembro.Observaciones = (string)dataReader["Observaciones"];
            return miembro;
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
