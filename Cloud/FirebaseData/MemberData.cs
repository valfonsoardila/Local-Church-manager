using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class MemberData
    {
        [FirestoreProperty]
        public string Folio { get; set; }

        [FirestoreProperty]
        public byte[] ImagenPerfil { get; set; }

        [FirestoreProperty]
        public string IdContacto { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Apellido { get; set; }

        [FirestoreProperty]
        public string TipoDoc { get; set; }

        [FirestoreProperty]
        public string NumeroDoc { get; set; }

        [FirestoreProperty]
        public string FechaNacimiento { get; set; }

        [FirestoreProperty]
        public int Edad { get; set; }

        [FirestoreProperty]
        public string Genero { get; set; }

        [FirestoreProperty]
        public string Oficio { get; set; }

        [FirestoreProperty]
        public string Direccion { get; set; }

        [FirestoreProperty]
        public string Telefono { get; set; }

        [FirestoreProperty]
        public string ParentezcoPadre { get; set; }

        [FirestoreProperty]
        public string ParentezcoMadre { get; set; }

        [FirestoreProperty]
        public string EstadoCivil { get; set; }

        [FirestoreProperty]
        public int NumeroHijos { get; set; }

        [FirestoreProperty]
        public string NombreConyugue { get; set; }

        [FirestoreProperty]
        public string Bautizado { get; set; }

        [FirestoreProperty]
        public string FechaDeBautizmo { get; set; }

        [FirestoreProperty]
        public string LugarBautizmo { get; set; }

        [FirestoreProperty]
        public string PastorOficiante { get; set; }

        [FirestoreProperty]
        public string Sellado { get; set; }

        [FirestoreProperty]
        public string SelladoRecuerdo { get; set; }

        [FirestoreProperty]
        public string FechaPromesa { get; set; }

        [FirestoreProperty]
        public int TiempoConversion { get; set; }

        [FirestoreProperty]
        public int TiempoPromesa { get; set; }

        [FirestoreProperty]
        public string IglesiaProcedente { get; set; }

        [FirestoreProperty]
        public string PastorAsistente { get; set; }

        [FirestoreProperty]
        public string CargosDesempenados { get; set; }

        [FirestoreProperty]
        public string Acto { get; set; }

        [FirestoreProperty]
        public string FechaCorreccion { get; set; }

        [FirestoreProperty]
        public int TiempoCorreccion { get; set; }

        [FirestoreProperty]
        public string Membresia { get; set; }

        [FirestoreProperty]
        public string LugarTraslado { get; set; }

        [FirestoreProperty]
        public string Observaciones { get; set; }
    }
}
