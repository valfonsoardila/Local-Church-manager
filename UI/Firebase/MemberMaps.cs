using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud;
using Entity;

namespace UI
{
    public class MemberMaps
    {
        MemberData data;

        public MemberData MemberMap(Miembro miembro)
        {
            if (CheckIfMemberAlreadyExist(miembro.Folio))
            {
                return new MemberData
                {
                    Folio = miembro.Folio.Trim(),
                    ImagenPerfil = miembro.ImagenPerfil,
                    IdContacto = miembro.IdContacto,
                    Nombre = miembro.Nombre,
                    Apellido = miembro.Apellido,
                    TipoDoc = miembro.TipoDoc,
                    NumeroDoc = miembro.NumeroDoc,
                    FechaNacimiento = miembro.FechaNacimiento.ToString(),
                    Edad = miembro.Edad,
                    Genero = miembro.Genero,
                    Oficio = miembro.Oficio,
                    Direccion = miembro.Direccion,
                    Telefono = miembro.Telefono,
                    ParentezcoPadre = miembro.ParentezcoPadre,
                    ParentezcoMadre = miembro.ParentezcoMadre,
                    EstadoCivil = miembro.EstadoCivil,
                    NumeroHijos = miembro.NumeroHijos,
                    NombreConyugue = miembro.NombreConyugue,
                    Bautizado = miembro.Bautizado,
                    FechaDeBautizmo = miembro.FechaDeBautizmo.ToString(),
                    LugarBautizmo = miembro.LugarBautizmo,
                    PastorOficiante = miembro.PastorOficiante,
                    Sellado = miembro.Sellado,
                    SelladoRecuerdo = miembro.SelladoRecuerdo,
                    FechaPromesa = miembro.FechaPromesa.ToString(),
                    TiempoConversion = miembro.TiempoConversion,
                    TiempoPromesa = miembro.TiempoPromesa,
                    IglesiaProcedente = miembro.IglesiaProcedente,
                    PastorAsistente = miembro.PastorAsistente,
                    CargosDesempenados = miembro.CargosDesempenados,
                    Acto = miembro.Acto,
                    FechaCorreccion = miembro.FechaCorreccion.ToString(),
                    TiempoCorreccion = miembro.TiempoCorreccion,
                    Motivo=miembro.Motivo,
                    Membresia = miembro.Membresia,
                    LugarTraslado = miembro.LugarTraslado,
                    Observaciones = miembro.Observaciones
                };
            }
            else
            {
                // Lógica para crear una nueva instancia de MemberData si no existe
                // Implementa según tus necesidades
                return new MemberData
                {
                    Folio = miembro.Folio.Trim(),
                    ImagenPerfil = miembro.ImagenPerfil,
                    IdContacto = miembro.IdContacto,
                    Nombre = miembro.Nombre,
                    Apellido = miembro.Apellido,
                    TipoDoc = miembro.TipoDoc,
                    NumeroDoc = miembro.NumeroDoc,
                    FechaNacimiento = miembro.FechaNacimiento.ToString(),
                    Edad = miembro.Edad,
                    Genero = miembro.Genero,
                    Oficio = miembro.Oficio,
                    Direccion = miembro.Direccion,
                    Telefono = miembro.Telefono,
                    ParentezcoPadre = miembro.ParentezcoPadre,
                    ParentezcoMadre = miembro.ParentezcoMadre,
                    EstadoCivil = miembro.EstadoCivil,
                    NumeroHijos = miembro.NumeroHijos,
                    NombreConyugue = miembro.NombreConyugue,
                    Bautizado = miembro.Bautizado,
                    FechaDeBautizmo = miembro.FechaDeBautizmo.ToString(),
                    LugarBautizmo = miembro.LugarBautizmo,
                    PastorOficiante = miembro.PastorOficiante,
                    Sellado = miembro.Sellado,
                    SelladoRecuerdo = miembro.SelladoRecuerdo,
                    FechaPromesa = miembro.FechaPromesa.ToString(),
                    TiempoConversion = miembro.TiempoConversion,
                    TiempoPromesa = miembro.TiempoPromesa,
                    IglesiaProcedente = miembro.IglesiaProcedente,
                    PastorAsistente = miembro.PastorAsistente,
                    CargosDesempenados = miembro.CargosDesempenados,
                    Acto = miembro.Acto,
                    FechaCorreccion = miembro.FechaCorreccion.ToString(),
                    TiempoCorreccion = miembro.TiempoCorreccion,
                    Motivo = miembro.Motivo,
                    Membresia = miembro.Membresia,
                    LugarTraslado = miembro.LugarTraslado,
                    Observaciones = miembro.Observaciones
                };
            }
        }

        private bool CheckIfMemberAlreadyExist(string folio)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("MemberData").Document(folio);
            MemberData data = docRef.GetSnapshotAsync().Result.ConvertTo<MemberData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}

