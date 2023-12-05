using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class SettlementMaps
    {
        SettlementData settlementData;
        public SettlementData ShippableMap(Liquidacion liquidacion)
        {
            if (CheckIfUserAlreadyExist(liquidacion.Id.ToString()))
            {
                return new SettlementData()
                {
                    Id = liquidacion.Id,
                    FechaDeLiquidacion = liquidacion.FechaDeLiquidacion.ToString(),
                    Comite = liquidacion.Comite,
                    Concepto = liquidacion.Concepto,
                    Valor = liquidacion.Valor,
                    Detalle = liquidacion.Detalle,
                    Estado=liquidacion.Estado
                };
            }
            else
            {
                return new SettlementData()
                {
                    Id = liquidacion.Id,
                    FechaDeLiquidacion = liquidacion.FechaDeLiquidacion.ToString(),
                    Comite = liquidacion.Comite,
                    Concepto = liquidacion.Concepto,
                    Valor = liquidacion.Valor,
                    Detalle = liquidacion.Detalle,
                };
            }
        }
        private bool CheckIfUserAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("SettlementData").Document(comprobante);
            SettlementData data = docRef.GetSnapshotAsync().Result.ConvertTo<SettlementData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
