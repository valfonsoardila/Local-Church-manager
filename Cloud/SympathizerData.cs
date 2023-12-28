using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Cloud
{
    [FirestoreData]
    public class SympathizerData
    {
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
    }
}
