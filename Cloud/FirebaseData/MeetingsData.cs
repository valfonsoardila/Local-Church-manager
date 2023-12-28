using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class MeetingsData
    {
        [FirestoreProperty]
        public string NumeroActa { get; set; }
        [FirestoreProperty]
        public string FechaDeReunion { get; set; }
        [FirestoreProperty]
        public string LugarDeReunion { get; set; }
        [FirestoreProperty]
        public string OrdenDelDia { get; set; }
        [FirestoreProperty]
        public string TextoActa { get; set; }
    }
}
