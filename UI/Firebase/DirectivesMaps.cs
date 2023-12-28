using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class DirectivesMaps
    {
        DirectivesData directivesData;
        public DirectivesData DirectivesMap(Directiva directiva)
        {
            if (CheckIfDirectiveAlreadyExist(directiva.IdDirectiva))
            {
                return new DirectivesData()
                {
                    IdDirectiva = directiva.IdDirectiva,
                    Nombre = directiva.Nombre,
                    Cargo = directiva.Cargo,
                    Comite = directiva.Comite,
                    Vigencia = directiva.Vigencia,
                    Observacion = directiva.Observacion
                };
            }
            else
            {
                return new DirectivesData()
                {
                    IdDirectiva = directiva.IdDirectiva,
                    Nombre = directiva.Nombre,
                    Cargo = directiva.Cargo,
                    Comite = directiva.Comite,
                    Vigencia = directiva.Vigencia,
                    Observacion = directiva.Observacion
                };
            }
        }
        private bool CheckIfDirectiveAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("DirectivesData").Document(comprobante);
            directivesData = docRef.GetSnapshotAsync().Result.ConvertTo<DirectivesData>();
            if (directivesData != null)
            {
                return true;
            }
            return false;
        }
    }
}
