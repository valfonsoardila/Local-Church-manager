using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class ContactMaps
    {
        ContactData contactData;
        public ContactData ContactMap(Contacto contacto)
        {
            if (CheckIfContactAlreadyExist(contacto.IdContacto))
            {
                return new ContactData()
                {
                    IdContacto=contacto.IdContacto,
                    Nombre=contacto.Nombre,
                    Apellido=contacto.Apellido,
                    TelefonoContacto = contacto.TelefonoContacto,
                    TelefonoWhatsapp = contacto.TelefonoWhatsapp,
                    Oficio = contacto.Oficio
                };
            }
            else
            {
                return new ContactData()
                {
                    IdContacto = contacto.IdContacto,
                    Nombre = contacto.Nombre,
                    Apellido = contacto.Apellido,
                    TelefonoContacto = contacto.TelefonoContacto,
                    TelefonoWhatsapp = contacto.TelefonoWhatsapp,
                    Oficio = contacto.Oficio
                };
            }
        }
        private bool CheckIfContactAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("ContactsData").Document(comprobante);
            contactData = docRef.GetSnapshotAsync().Result.ConvertTo<ContactData>();
            if (contactData != null)
            {
                return true;
            }
            return false;
        }
    }
}
