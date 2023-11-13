using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    [FirestoreData]
    public class UserData
    {
        [FirestoreProperty]
        public string ID { get; set; }
        [FirestoreProperty]
        public string TypeID { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string LastName { get; set; }
        [FirestoreProperty]
        public string Birthdate { get; set; }
        [FirestoreProperty]
        public string Age { get; set; }
        [FirestoreProperty]
        public string Gender { get; set; }
        [FirestoreProperty]
        public string Address { get; set; }
        [FirestoreProperty]
        public string PhoneNumber { get; set; }
        [FirestoreProperty]
        public string Rol { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string UserName { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public string UserCode { get; set; }
    }
}
