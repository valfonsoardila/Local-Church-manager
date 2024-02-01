using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace UI
{
    public class Reporte
    {
        public List<IngressData> ingress;
        public List<EgressData> egress;
        public List<MemberData> members;
        public List<DirectivesData> directives;
        public List<MeetingsData> meetings;
        public List<NotesData> notes;
        public List<SympathizerData> sympathizers;
        private readonly string[] rutaDeDocumentosSecretaria = { "Doc's", "Secretaria" };
        private readonly string[] rutaDeDocumentosTesoreria = { "Doc's", "Tesoreria" };
        // Reportes de tesoreria
        public void GenerarInformeGeneralTesoreria()
        {
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaDeDocumentosTesoreria[0], rutaDeDocumentosTesoreria[1], "InformeTesoreriaGeneral.docx");
            // Cargar el documento
            if (!File.Exists(rutaCompleta))
            {
                using (DocX documento = DocX.Load(rutaCompleta))
                {

                }
            }
        }
        public void GenerarInformeIndividualTesoreria()
        {

        }
        public void GenerarInformePresupuestalTesoreria()
        {

        }
        // Reportes de secretaria
        public void GenerarCartaRecomendacionSecretaria()
        {

        }
        public void GenerarActasDeReunionesSecretaria()
        {

        }
        public void GenerarListaDeNiñosSecretaria()
        {

        }
        public void GenerarListasRecientregadosSecretaria()
        {

        }
        public void GenerarListaFamiliasSecretaria()
        {

        }
        public void GenerarListaServidoresActualesSecretaria()
        {

        }
        public void GenerarLibroDeMiembrosSecretaria(List<Miembro> miembros)
        {
            if(miembros.Count > 0 && miembros.Count < 2)
            {
                // Obtener el primer miembro
                Miembro miembro = miembros[0];
                string rutaDePlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Doc's", "Secretaria", "ReporteMiembros.docx");
                // Cargar la plantilla desde un archivo existente
                using (DocX documento = DocX.Load(rutaDePlantilla))
                {
                    // Modificar el contenido del documento con los datos del miembro
                    documento.ReplaceText("{{Nombre del inscrito: }}", miembro.Nombre);

                    // Guardar el documento modificado con un nuevo nombre (Folio1 en este caso)
                    string nombreFolio = "Folio1.docx";
                    documento.SaveAs(nombreFolio);
                }
            }
            else
            {
                if(miembros.Count > 1)
                {

                }
                else
                {
                    MessageBox.Show("No se ha seleccionado los miembros", "Mensaje de base de datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }
        public void GenerarListaDeBautizadosSecretaria()
        {

        }
        public void GenerarListaPorGeneroSecretaria(string genero)
        {

        }
    }
}
