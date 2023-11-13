using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class EgressMap
    {
        EgressData egressData;
        public EgressData Egress_Map(Egreso egreso)
        {
            if (CheckIfUserAlreadyExist(egreso.CodigoComprobante.ToString()))
            {
                return new EgressData()
                {
                    VoucherCode = egreso.CodigoComprobante.ToString(),
                    DateOfIngress = egreso.FechaDeEgreso.ToString(),
                    Committee = egreso.Comite,
                    Concept = egreso.Concepto,
                    Ammount = egreso.Valor,
                    Detail = egreso.Detalle,
                };
            }
            else
            {
                return new EgressData()
                {
                    VoucherCode = egreso.CodigoComprobante.ToString(),
                    DateOfIngress = egreso.FechaDeEgreso.ToString(),
                    Committee = egreso.Comite,
                    Concept = egreso.Concepto,
                    Ammount = egreso.Valor,
                    Detail = egreso.Detalle,
                };
            }
        }
        private bool CheckIfUserAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("EgressData").Document(comprobante);
            IngressData data = docRef.GetSnapshotAsync().Result.ConvertTo<IngressData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
