using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Cloud
{
    [FirestoreData]
    public class ContactData
    {
        [FirestoreProperty]
        public string IdContacto { get; set; }
        [FirestoreProperty]
        public string Nombre { get; set; }
        [FirestoreProperty]
        public string Apellido { get; set; }
        [FirestoreProperty]
        public string TelefonoContacto { get; set; }
        [FirestoreProperty]
        public string TelefonoWhatsapp { get; set; }
        [FirestoreProperty]
        public string Oficio { get; set; }
    }
}
