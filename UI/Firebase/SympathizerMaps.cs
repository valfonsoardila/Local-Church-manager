using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class SympathizerMaps
    {
        SympathizerData data;

        public SympathizerData SympathizerMap(Simpatizante simpatizante)
        {
            if (CheckIfSympathizerAlreadyExist(simpatizante.NumeroDoc))
            {
                return new SympathizerData
                {
                    ImagenPerfil = simpatizante.ImagenPerfil,
                    IdContacto = simpatizante.IdContacto,
                    Nombre = simpatizante.Nombre,
                    Apellido = simpatizante.Apellido,
                    TipoDoc = simpatizante.TipoDoc,
                    NumeroDoc = simpatizante.NumeroDoc,
                    FechaNacimiento = simpatizante.FechaNacimiento.ToString(),
                    Edad = simpatizante.Edad,
                    Genero = simpatizante.Genero,
                    Oficio = simpatizante.Oficio,
                    Direccion = simpatizante.Direccion,
                    Telefono = simpatizante.Telefono
                };
            }
            else
            {
                // Lógica para crear una nueva instancia de SympathizerData si no existe
                // Implementa según tus necesidades
                return new SympathizerData
                {
                    ImagenPerfil = simpatizante.ImagenPerfil,
                    IdContacto = simpatizante.IdContacto,
                    Nombre = simpatizante.Nombre,
                    Apellido = simpatizante.Apellido,
                    TipoDoc = simpatizante.TipoDoc,
                    NumeroDoc = simpatizante.NumeroDoc,
                    FechaNacimiento = simpatizante.FechaNacimiento.ToString(),
                    Edad = simpatizante.Edad,
                    Genero = simpatizante.Genero,
                    Oficio = simpatizante.Oficio,
                    Direccion = simpatizante.Direccion,
                    Telefono = simpatizante.Telefono
                };
            }
        }
        private bool CheckIfSympathizerAlreadyExist(string folio)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("SympathizerData").Document(folio);
            SympathizerData data = docRef.GetSnapshotAsync().Result.ConvertTo<SympathizerData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
