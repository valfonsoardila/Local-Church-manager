using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class IngressMap
    {
        IngressData ingressData;
        public IngressData Ingress_Map(Ingreso ingreso)
        {
            if (CheckIfUserAlreadyExist(ingreso.CodigoComprobante.ToString()))
            {
                return new IngressData()
                {
                    VoucherCode = ingreso.CodigoComprobante,
                    DateOfIngress = ingreso.FechaDeIngreso.ToString(),
                    Committee = ingreso.Comite,
                    Concept = ingreso.Concepto,
                    Ammount = ingreso.Valor,
                    Detail = ingreso.Detalle,
                };
            }
            else
            {
                return new IngressData()
                {
                    VoucherCode = ingreso.CodigoComprobante,
                    DateOfIngress = ingreso.FechaDeIngreso.ToString(),
                    Committee = ingreso.Comite,
                    Concept = ingreso.Concepto,
                    Ammount = ingreso.Valor,
                    Detail = ingreso.Detalle,
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
