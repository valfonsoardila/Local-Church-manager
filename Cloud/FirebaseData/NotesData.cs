using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class NotesData
    {
        [FirestoreProperty]
        public string IdNota { get; set; }
        [FirestoreProperty]
        public string Titulo { get; set; }
        [FirestoreProperty]
        public string Nota { get; set; }
    }
}
