using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class ShippableMaps
    {
        ShippableData shippableData;
        //Map to save in firestore
        public ShippableData ShippableMap(Enviable enviable)
        {
            if (CheckIfShippableAlreadyExist(enviable.Id.ToString()))
            {
                return new ShippableData()
                {
                    Id = enviable.Id,
                    FechaDeEnvio = enviable.FechaDeEnvio.ToString(),
                    Comite = enviable.Comite,
                    Concepto = enviable.Concepto,
                    Valor = enviable.Valor,
                    Detalle = enviable.Detalle,
                };
            }
            else
            {
                return new ShippableData()
                {
                    Id = enviable.Id,
                    FechaDeEnvio = enviable.FechaDeEnvio.ToString(),
                    Comite = enviable.Comite,
                    Concepto = enviable.Concepto,
                    Valor = enviable.Valor,
                    Detalle = enviable.Detalle,
                };
            }
        }
        private bool CheckIfShippableAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("ShippableData").Document(comprobante);
            ShippableData data = docRef.GetSnapshotAsync().Result.ConvertTo<ShippableData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
