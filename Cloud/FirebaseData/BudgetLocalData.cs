using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Cloud.FirebaseData
{
    [FirestoreData]
    public class BudgetIngressLocalData
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string AñoPresupuesto { get; set; }
        [FirestoreProperty]
        public string InicioIntervalo { get; set; }
        [FirestoreProperty]
        public string FinIntervalo { get; set; }
        [FirestoreProperty]
        public string Comite { get; set; }
        [FirestoreProperty]
        public string Concepto { get; set; }
        [FirestoreProperty]
        public int Valor { get; set; }
    }
    [FirestoreData]
    public class BudgetEgressLocalData
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string AñoPresupuesto { get; set; }
        [FirestoreProperty]
        public string InicioIntervalo { get; set; }
        [FirestoreProperty]
        public string FinIntervalo { get; set; }
        [FirestoreProperty]
        public string Comite { get; set; }
        [FirestoreProperty]
        public string Concepto { get; set; }
        [FirestoreProperty]
        public int Valor { get; set; }
    }
}
