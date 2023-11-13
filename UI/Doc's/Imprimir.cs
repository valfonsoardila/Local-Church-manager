using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace UI
{
    public class Imprimir
    {
        public void ImprimirDoc()
        {

        }
        public void EditarDocumentoMiembros(string rutaDelArchivo)
        {
            // Abre el documento Word
            using (DocX doc = DocX.Load(rutaDelArchivo))
            {
                // Accede al contenido del documento
                Paragraph paragraph = doc.InsertParagraph();

                // Edita o agrega texto al documento
                paragraph.Append("Este es un nuevo párrafo en el documento.");

                // Guarda los cambios en el documento
                doc.Save();
                ImprimirDoc();
            }
        }
    }
}
