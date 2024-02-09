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
using System.Drawing;
using Cloud.FirebaseData;

namespace UI
{
    public class Reporte
    {
        public string year;
        public List<BudgetData> presupuestosGeneral;
        public List<IngressData> ingress;
        public List<EgressData> egress;
        public List<MemberData> members;
        public List<DirectivesData> directives;
        public List<MeetingsData> meetings;
        public List<NotesData> notes;
        public List<SympathizerData> sympathizers;
        public List<BudgetIngressLocalData> budgetIngressLocals;
        public List<BudgetEgressLocalData> budgetEgressLocals;

        private readonly string[] comites = {
            "Junta Local",
            "Damas Dorcas",
            "Jovenes",
            "Escuela Dominical",
            "Misiones y Evangelismo",
            "Adolescentes",
            "Alabanza",
            "Caballeros",
            "Familia",
            "Cultivadores",
            "Obra Social",
            "Entre Señas",
            "Damas Jovenes",
            "Primeros Auxilios",
            "Vigilancia",
            "Asistencia Escuela Dominical",
            "Labores",
            "Restauracion",
            "Sonido",
            "Edad Dorada",
            "Intercesión",
            "Decom",
            "Ujieres",
            "Decoración",
            "Donacion",
            "Aporte de Liquidación"
        };
        private readonly string[] rutaDeDocumentosSecretaria = { "Doc's", "Secretaria" };
        private readonly string[] rutaDeDocumentosTesoreria = { "Doc's", "Tesoreria" };
        //Reporte de tesoreria Junta local
        private List<int> ObtenerValoresJuntaLocalPorConceptos(string comite, string concepto)
        {
            int sumConceptIngress = 0;
            int sumConceptEgress = 0;
            int valorBase = 0;
            List<int> valoresRetorno = new List<int>(); ;
            string[] conceptosIngresos = { "Saldo del año anterior", "Ofrenda Domingo", "Ofrenda Jueves", "Aporte del 12%", "Otro ingreso"};
            string[] filasBase = { "SUBTOTAL INGRESOS, SUBTOTAL EGRESOS, EGRESOS, TOTAL, DEL FONDO LOCAL" };
            //Determinar los ingresos
            if (conceptosIngresos.Contains(concepto))
            {
                for (int i= 0; i < ingress.Count; i++)
                {
                    if (ingress[i].Comite.ToUpperInvariant().Trim() == comite)
                    {
                        if (ingress[i].Concepto == concepto)
                        {
                            sumConceptIngress = sumConceptIngress + ingress[i].Valor;
                        }
                    }
                }
                valoresRetorno.Add(sumConceptIngress);
            }
            else
            {
                if (filasBase.Contains(concepto))
                {
                    for(int i=0; i< filasBase.Length; i++)
                    {
                        if (filasBase[i]=="SUBTOTAL INGRESOS")
                        {
                            for (int j = 0; j < ingress.Count; j++)
                            {
                                if (ingress[j].Comite.ToUpperInvariant().Trim() == comite)
                                {
                                    valorBase = valorBase + ingress[j].Valor;
                                }
                            }
                            valoresRetorno.Add(valorBase);
                        }
                        else
                        {
                            if (filasBase[i] == "SUBTOTAL EGRESOS")
                            {
                                for (int j = 0; j < egress.Count; j++)
                                {
                                    if (egress[j].Comite.ToUpperInvariant().Trim() == comite)
                                    {
                                        valorBase = valorBase + egress[j].Valor;
                                    }
                                }
                                valoresRetorno.Add(valorBase);
                            }
                            else
                            {
                                if (filasBase[i] == "TOTAL, DEL FONDO LOCAL")
                                {
                                    valoresRetorno.Add(valorBase);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Determina los egresos
                    for (int i = 0; i < egress.Count; i++)
                    {
                        if (egress[i].Comite.ToUpperInvariant().Trim() == comite)
                        {
                            if (egress[i].Concepto == concepto)
                            {
                                sumConceptEgress = sumConceptEgress + egress[i].Valor;
                            }
                        }
                    }
                    valoresRetorno.Add(sumConceptEgress);
                }
            }
            valoresRetorno.Add(0);
            return valoresRetorno;
        }
        // Reportes de tesoreria Comite
        private List<int> ObtenerValoresComitePorConcepto(string comite, string concepto)
        {
            List<int> valores = new List<int>();
            int sumConcepto = 0;
            int porcentaje = 0;
            int ofrendas = 0;
            int actividad = 0;
            int votos = 0;
            int otroConcepto = 0;
            //Obtiene valor de rubros
            for (int i=0; i < presupuestosGeneral.Count; i++)
            {
                if (presupuestosGeneral[i].AñoPresupuesto == year)
                {
                    if (presupuestosGeneral[i].Comite.ToUpperInvariant().Trim() == comite)
                    {
                        ofrendas = presupuestosGeneral[i].Ofrenda;
                        actividad = presupuestosGeneral[i].Actividad;
                        votos = presupuestosGeneral[i].Voto;
                        otroConcepto = presupuestosGeneral[i].ValorOtroConcepto;
                    }
                }
            }
            //Hacer calculos
            for (int j = 0; j < ingress.Count; j++)
            {
                if (ingress[j].Comite.ToUpperInvariant().Trim() == comite)
                {
                    if (ingress[j].Concepto == concepto)
                    {
                        sumConcepto = sumConcepto + ingress[j].Valor;
                    }
                }
            }
            if(concepto.Contains("Actividad") || concepto.Contains( "Actividades"))
            {
                porcentaje = actividad!=0 ? sumConcepto * 100 / actividad: 0;
            }
            else
            {
                if(concepto.Contains("Voto") || concepto.Contains("Votos"))
                {
                    porcentaje = votos!=0 ? sumConcepto * 100 / votos: 0;
                }
                else
                {
                    if(concepto.Contains("Ofrenda") || concepto.Contains("Ofrendas"))
                    {
                        porcentaje = ofrendas != 0 ? sumConcepto * 100 / ofrendas : 0;
                    }
                    else
                    {
                        if(concepto.Contains("Otro") || concepto.Contains("Otro concepto") || concepto.Contains("Otro Cocepto"))
                        {
                            porcentaje = otroConcepto != 0 ? sumConcepto * 100 / otroConcepto : 0;
                        }
                        else
                        {
                            if (!concepto.Contains("Actividad") || !concepto.Contains("Actividades") && !concepto.Contains("Voto") || !concepto.Contains("Votos") && !concepto.Contains("Ofrenda") || !concepto.Contains("Ofrendas"))
                            {
                                porcentaje = 0;
                            }
                        }
                    }
                }
            }
            valores.Add(sumConcepto);
            valores.Add(porcentaje);
            return valores;
        }
        public void GenerarInformeGeneralTesoreria()
        {
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaDeDocumentosTesoreria[0], rutaDeDocumentosTesoreria[1], "InformeTesoreriaGeneral.docx");
            string comiteActual = "";
            string comiteSiguiente = "";
            // Cargar el documento
            if (File.Exists(rutaCompleta))
            {
                using (DocX documento = DocX.Load(rutaCompleta))
                {
                    // Reemplazar el espacio en blanco con el solicitado
                    documento.ReplaceText("______", "_" + year + "_");
                    Table tablaDeValores = documento.Tables[0];
                    Table tablaDeTotales = documento.Tables[1];
                    string[] conceptos = new string[10];
                    int indexComite = 0;
                    //Obtener el numero de filas de la tabla valores
                    for (int i = 2; i < tablaDeValores.Rows.Count; i++)
                    {
                        //Recorre celda tras celda de forma vertical
                        string contenidoCelda = tablaDeValores.Rows[i].Cells[0].Paragraphs[0].Text.Trim();
                        comiteActual = comites[indexComite].ToUpperInvariant().Trim();
                        if (indexComite + 1 <= comites.Length)
                        {
                            comiteSiguiente = comites[indexComite + 1].ToUpperInvariant();
                            //Compara si el comite actual de la lista esta en la tabla del documento
                            if (contenidoCelda.ToUpperInvariant().Trim() == comiteActual.ToUpperInvariant().Trim())
                            {
                                //Recorrer conceptos
                                for (int j = i; j < tablaDeValores.Rows.Count; j++)
                                {
                                    string conceptoRubros = tablaDeValores.Rows[j].Cells[0].Paragraphs[0].Text.Trim();
                                    if (conceptoRubros != comiteActual && conceptoRubros != comiteSiguiente)
                                    {
                                        List<int> valoresPorConcepto = comiteActual!="JUNTA LOCAL"?
                                            ObtenerValoresComitePorConcepto(comiteActual, conceptoRubros):
                                            ObtenerValoresJuntaLocalPorConceptos(comiteActual, conceptoRubros);
                                        int valor = valoresPorConcepto[0];
                                        int porcentaje = valoresPorConcepto[1];
                                        //Inserta valor
                                        tablaDeValores.Rows[j].Cells[1].Paragraphs[0].InsertText(valor.ToString());
                                        //Inserta porcentaje
                                        tablaDeValores.Rows[j].Cells[2].Paragraphs[0].InsertText(porcentaje.ToString()+"%");
                                    }
                                    else
                                    {
                                       if(conceptoRubros == comiteSiguiente)
                                       {
                                            //Llego al siguiente comite
                                            indexComite = indexComite + 1;
                                            break;
                                       }
                                    }
                                }
                            }
                            else
                            {
                                // Agregamos el nuevo comite y sus conceptos
                                //int rowIndex = tablaDeValores.Rows.Count; // Obtener el índice de la última fila
                                //Row nuevaFila = tablaDeValores.InsertRow();
                            }
                        }
                    }
                    // Guardar el documento modificado
                    documento.Save();
                    System.Diagnostics.Process.Start(rutaCompleta);
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
