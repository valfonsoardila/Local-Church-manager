using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class MeetingsMaps
    {
        MeetingsData meetingsData;
        public MeetingsData MeetMap(Reunion reunion)
        {
            if (CheckIfMeetAlreadyExist(reunion.NumeroActa))
            {
                return new MeetingsData()
                {
                    NumeroActa=reunion.NumeroActa,
                    FechaDeReunion=reunion.FechaDeReunion.ToString(),
                    LugarDeReunion=reunion.LugarDeReunion,
                    OrdenDelDia=reunion.OrdenDelDia,
                    TextoActa=reunion.TextoActa
                };
            }
            else
            {
                return new MeetingsData()
                {
                    NumeroActa = reunion.NumeroActa,
                    FechaDeReunion = reunion.FechaDeReunion.ToString(),
                    LugarDeReunion = reunion.LugarDeReunion,
                    OrdenDelDia = reunion.OrdenDelDia,
                    TextoActa = reunion.TextoActa
                };
            }
        }
        private bool CheckIfMeetAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("MeetingsData").Document(comprobante);
            meetingsData = docRef.GetSnapshotAsync().Result.ConvertTo<MeetingsData>();
            if (meetingsData != null)
            {
                return true;
            }
            return false;
        }
    }
}
