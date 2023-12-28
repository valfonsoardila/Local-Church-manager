using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class DirectivesData
    {
        [FirestoreProperty]
        public string IdDirectiva { get; set; }
        [FirestoreProperty]
        public string Nombre { get; set; }
        [FirestoreProperty]
        public string Cargo { get; set; }
        [FirestoreProperty]
        public string Comite { get; set; }
        [FirestoreProperty]
        public string Vigencia { get; set; }
        [FirestoreProperty]
        public string Observacion { get; set; }
    }
}
