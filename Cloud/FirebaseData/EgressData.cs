using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class EgressData
    {
        [FirestoreProperty]
        public string VoucherCode { get; set; }
        [FirestoreProperty]
        public string DateOfIngress { get; set; }
        [FirestoreProperty]
        public string Committee { get; set; }
        [FirestoreProperty]
        public string Concept { get; set; }
        [FirestoreProperty]
        public int Ammount { get; set; }
        [FirestoreProperty]
        public string Detail { get; set; }
    }
}
