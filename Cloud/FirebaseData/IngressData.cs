using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class IngressData
    {
        [FirestoreProperty]
        public string CodigoComprobante { get; set; }
        [FirestoreProperty]
        public string FechaDeIngreso { get; set; }
        [FirestoreProperty]
        public string Comite { get; set; }
        [FirestoreProperty]
        public string Concepto { get; set; }
        [FirestoreProperty]
        public int Valor { get; set; }
        [FirestoreProperty]
        public string Detalle { get; set; }
    }
}
