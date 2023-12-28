using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class NoteMaps
    {
        NotesData notesData;
        public NotesData NoteMap(Apunte apunte)
        {
            if (CheckIfNoteAlreadyExist(apunte.IdNota))
            {
                return new NotesData()
                {
                    IdNota=apunte.IdNota,
                    Titulo=apunte.Titulo,
                    Nota=apunte.Nota
                };
            }
            else
            {
                return new NotesData()
                {
                    IdNota = apunte.IdNota,
                    Titulo = apunte.Titulo,
                    Nota = apunte.Nota
                };
            }
        }
        private bool CheckIfNoteAlreadyExist(string comprobante)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("NotesData").Document(comprobante);
            notesData = docRef.GetSnapshotAsync().Result.ConvertTo<NotesData>();
            if (notesData != null)
            {
                return true;
            }
            return false;
        }
    }
}
