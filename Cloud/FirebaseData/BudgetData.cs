using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class BudgetData
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
        public int Ofrenda { get; set; }
        [FirestoreProperty]
        public int Actividad { get; set; }
        [FirestoreProperty]
        public int Voto { get; set; }
        [FirestoreProperty]
        public string OtroConcepto { get; set; }
        [FirestoreProperty]
        public int ValorOtroConcepto { get; set; }
        [FirestoreProperty]
        public int TotalEgresos { get; set; }
        [FirestoreProperty]
        public int TotalPresupuesto { get; set; }
    }
}
