using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class IngressMaps
    {
        IngressData ingressData;
        //Map to save in firestore
        public IngressData IngressMap(Ingreso ingreso)
        {
            if (CheckIfUserAlreadyExist(ingreso.CodigoComprobante.ToString()))
            {
                return new IngressData()
                {
                    CodigoComprobante = ingreso.CodigoComprobante,
                    FechaDeIngreso = ingreso.FechaDeIngreso.ToString(),
                    Comite = ingreso.Comite,
                    Concepto = ingreso.Concepto,
                    Valor = ingreso.Valor,
                    Detalle = ingreso.Detalle,
                };
            }
            else
            {
                return new IngressData()
                {
                    CodigoComprobante = ingreso.CodigoComprobante,
                    FechaDeIngreso = ingreso.FechaDeIngreso.ToString(),
                    Comite = ingreso.Comite,
                    Concepto = ingreso.Concepto,
                    Valor = ingreso.Valor,
                    Detalle = ingreso.Detalle,
                };
            }
        }
        private bool CheckIfUserAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("IngressMap").Document(comprobante);
            IngressData data = docRef.GetSnapshotAsync().Result.ConvertTo<IngressData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
