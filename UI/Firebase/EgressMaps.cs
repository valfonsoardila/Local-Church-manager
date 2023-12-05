using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class EgressMaps
    {
        EgressData egressData;
        public EgressData EgressMap(Egreso egreso)
        {
            if (CheckIfUserAlreadyExist(egreso.CodigoComprobante.ToString()))
            {
                return new EgressData()
                {
                    CodigoComprobante = egreso.CodigoComprobante.ToString(),
                    FechaDeEgreso = egreso.FechaDeEgreso.ToString(),
                    Comite = egreso.Comite,
                    Concepto = egreso.Concepto,
                    Valor = egreso.Valor,
                    Detalle = egreso.Detalle,
                };
            }
            else
            {
                return new EgressData()
                {
                    CodigoComprobante = egreso.CodigoComprobante.ToString(),
                    FechaDeEgreso = egreso.FechaDeEgreso.ToString(),
                    Comite = egreso.Comite,
                    Concepto = egreso.Concepto,
                    Valor = egreso.Valor,
                    Detalle = egreso.Detalle,
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
