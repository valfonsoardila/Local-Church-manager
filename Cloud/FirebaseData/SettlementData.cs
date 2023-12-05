using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class SettlementData
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string FechaDeLiquidacion { get; set; }
        [FirestoreProperty]
        public string Comite { get; set; }
        [FirestoreProperty]
        public string Concepto { get; set; }
        [FirestoreProperty]
        public int Valor { get; set; }
        [FirestoreProperty]
        public string Detalle { get; set; }
        [FirestoreProperty]
        public string Estado { get; set; }
    }
}
