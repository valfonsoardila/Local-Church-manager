using Cloud;
using Cloud.FirebaseData;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class BudgetLocalMaps
    {
        BudgetIngressLocalData budgetIngressLocalData;
        BudgetEgressLocalData budgetEgressLocalData;
        public BudgetIngressLocalData BudgetIngressLocalMap(PresupuestoIngresoLocal presupuesto)
        {
            if (CheckIfBudgetIngressLocalAlreadyExist(presupuesto.Id.ToString()))
            {
                return new BudgetIngressLocalData()
                {
                    Id = presupuesto.Id.ToString().Trim(),
                    AñoPresupuesto=presupuesto.AñoPresupuesto,
                    InicioIntervalo=presupuesto.InicioIntervalo,
                    FinIntervalo=presupuesto.FinIntervalo,
                    Comite=presupuesto.Comite,
                    Concepto=presupuesto.Concepto,
                    Valor=presupuesto.Valor
                };
            }
            else
            {
                return new BudgetIngressLocalData()
                {
                    Id = presupuesto.Id.ToString().Trim(),
                    AñoPresupuesto = presupuesto.AñoPresupuesto,
                    InicioIntervalo = presupuesto.InicioIntervalo,
                    FinIntervalo = presupuesto.FinIntervalo,
                    Comite = presupuesto.Comite,
                    Concepto = presupuesto.Concepto,
                    Valor = presupuesto.Valor
                };
            }
        }
        public BudgetEgressLocalData BudgetEgressLocalMap(PresupuestoEgresoLocal presupuesto)
        {
            if (CheckIfBudgetEgressLocalAlreadyExist(presupuesto.Id.ToString()))
            {
                return new BudgetEgressLocalData()
                {
                    Id = presupuesto.Id.ToString().Trim(),
                    AñoPresupuesto = presupuesto.AñoPresupuesto,
                    InicioIntervalo = presupuesto.InicioIntervalo,
                    FinIntervalo = presupuesto.FinIntervalo,
                    Comite = presupuesto.Comite,
                    Concepto = presupuesto.Concepto,
                    Valor = presupuesto.Valor
                };
            }
            else
            {
                return new BudgetEgressLocalData()
                {
                    Id = presupuesto.Id.ToString().Trim(),
                    AñoPresupuesto = presupuesto.AñoPresupuesto,
                    InicioIntervalo = presupuesto.InicioIntervalo,
                    FinIntervalo = presupuesto.FinIntervalo,
                    Comite = presupuesto.Comite,
                    Concepto = presupuesto.Concepto,
                    Valor = presupuesto.Valor
                };
            }
        }
        private bool CheckIfBudgetEgressLocalAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetEgressLocalData").Document(comprobante);
            BudgetEgressLocalData data = docRef.GetSnapshotAsync().Result.ConvertTo<BudgetEgressLocalData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
        private bool CheckIfBudgetIngressLocalAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetIngressLocalData").Document(comprobante);
            BudgetIngressLocalData data = docRef.GetSnapshotAsync().Result.ConvertTo<BudgetIngressLocalData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
