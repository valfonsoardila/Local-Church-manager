using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Cloud
{
    [FirestoreData]
    public class ChurchData
    {
        [FirestoreProperty]
        public string IdIglesia { get; set; }
        [FirestoreProperty]
        public string NombreIglesia { get; set; }
        [FirestoreProperty]
        public string NIT { get; set; }
        [FirestoreProperty]
        public string Correo { get; set; }
        [FirestoreProperty]
        public string Direccion { get; set; }
        [FirestoreProperty]
        public string Telefono { get; set; }
    }
}
