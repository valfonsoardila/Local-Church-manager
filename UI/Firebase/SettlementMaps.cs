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
        public SettlementData SettlementMap(Liquidacion liquidacion)
        {
            if (CheckIfSettlementAlreadyExist(liquidacion.Id.ToString()))
            {
                return new SettlementData()
                {
                    Id = liquidacion.Id,
                    FechaDeLiquidacion = liquidacion.FechaDeLiquidacion.ToString(),
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
                    Valor = liquidacion.Valor,
                    Detalle = liquidacion.Detalle,
                    Estado= liquidacion.Estado
                };
            }
        }
        private bool CheckIfSettlementAlreadyExist(string comprobante)
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
