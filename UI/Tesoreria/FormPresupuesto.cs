using BLL;
using Cloud;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UI
{
    public partial class FormPresupuesto : Form
    {
        PresupuestoService presupuestoService;
        TabPage tabPage;
        Presupuesto presupuesto;
        List<Presupuesto> presupuestos;
        BudgetData budgetData;
        int id = 0;
        string comite = "";
        bool detallo = false;
        bool encontrado = false;
        public FormPresupuesto()
        {
            presupuestoService = new PresupuestoService(ConfigConnection.ConnectionString);
            budgetData = new BudgetData();
            InitializeComponent();
            ConsultarPresupuesto();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string LecturaCifra(int totalDeIngresos)
        {
            // Convierte el total de ingresos a una cadena con separadores de miles
            string cifraFormateada = totalDeIngresos.ToString("N0");

            // Muestra la cifra formateada en el TextBox o donde desees
            string valorFormateado = $"${cifraFormateada}";
            return valorFormateado;
        }
        private async void ConsultarPresupuesto()
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                if (presupuestos.Count > 0)
                {
                    dataGridPresupuestos.DataSource = null;
                    dataGridPresupuestos.DataSource = presupuestos;
                }
                else
                {
                    dataGridPresupuestos.DataSource = null;
                    textTotal.Text = "0";
                }
            }
            catch(Exception ex)
            {
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.ConsultarTodos();
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    dataGridDetalle.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                    dataGridDetalle.DataSource = respuesta.Presupuestos;
                    Borrar.Visible = true;
                    textTotal.Text = presupuestoService.Totalizar().Cuenta.ToString();
                }
            }
        }

        private void FormPresupuesto_Load(object sender, EventArgs e)
        {
            if (tabPresupuestos.TabCount > 0)
            {
                tabPage = tabPresupuestos.TabPages["tabDetalle"];
                tabPresupuestos.TabPages.RemoveAt(2);
            }
        }
        private async void EliminarPresupuesto(int id)
        {

        }
        private async void FiltrarPresupuestosPorComite(string comite){
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var presupuestosComite = presupuestos.Where(presupuesto => presupuesto.Comite == comite).ToList();
                dataGridPresupuestos.DataSource = presupuestosComite;
                Borrar.Visible = true;
            }
            catch (Exception ex)
            {
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.FiltrarEgresosPorComite(comite);
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    dataGridPresupuestos.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                    if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                    {
                        dataGridPresupuestos.DataSource = respuesta.Presupuestos;
                        Borrar.Visible = true;
                    }
                }
                else
                {
                    dataGridPresupuestos.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                }
            }
        }
        private void dataGridPresupuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPresupuestos.DataSource != null)
            {
                if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                    EliminarPresupuesto(id);
                    ConsultarPresupuesto();
                }
                else
                {
                    if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Detallar")
                    {
                        comite = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["Comite"].Value.ToString());
                        FiltrarPresupuestosPorComite(comite);
                        tabPresupuestos.TabPages.Add(tabPage);
                        tabPresupuestos.SelectedIndex = 2;
                        detallo = true;
                    }
                    else
                    {
                        if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Editar")
                        {
                            id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabPresupuestos.SelectedIndex = 1;
                            }
                        }
                    }
                }
            }
        }

        private void btnGestionarPresupuesto_Click(object sender, EventArgs e)
        {
            tabPresupuestos.SelectedIndex = 1;
        }
        private async void FiltroPorId(int id)
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestoQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestoQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var presupuestosFiltrados = presupuestos.Where(presupuesto => presupuesto.Id == id.ToString()).ToList();
                if (presupuestosFiltrados.Any())
                {
                    var presupuestoFiltrado = presupuestosFiltrados.First(); // Obtener el primer elemento de la lista
                    //encontrado = true;
                    dateTimeFechaPresupuesto.Value = DateTime.Parse(FormatearFecha(presupuestoFiltrado.FechaPresupuesto));
                    comboComite.Text = presupuestoFiltrado.Comite;
                    textOfrendas.Text = presupuestoFiltrado.Ofrenda.ToString();
                    textActividades.Text = presupuestoFiltrado.Actividad.ToString();
                    textVotos.Text = presupuestoFiltrado.Voto.ToString();
                }
            }
            catch (Exception ex)
            {
                BusquedaPresupuestoRespuesta respuesta = new BusquedaPresupuestoRespuesta();
                respuesta = presupuestoService.BuscarPorIdentificacion(id);
                var registro = respuesta.Presupuesto;
                if (registro != null)
                {
                    encontrado = true;
                    var presupuestos = new List<Presupuesto> { registro };
                    dateTimeFechaPresupuesto.Value = presupuestos[0].FechaPresupuesto;
                    comboComite.Text = presupuestos[0].Comite;
                    textOfrendas.Text = presupuestos[0].Ofrenda.ToString();
                    textActividades.Text = presupuestos[0].Actividad.ToString();
                    textVotos.Text = presupuestos[0].Voto.ToString();
                    textPresupuesto.Text = presupuestos[0].TotalPresupuesto.ToString();
                }
            }
        }
        static string FormatearFecha(string fechaOriginal)
        {
            string fechaFormateada = "";
            if (fechaOriginal.Contains(" p. m."))
            {
                fechaFormateada = fechaOriginal.Replace(" p. m.", "");
                fechaFormateada = fechaFormateada + " PM";
            }
            else
            {
                if (fechaOriginal.Contains(" a. m."))
                {
                    fechaFormateada = fechaOriginal.Replace(" a. m.", "");
                    fechaFormateada = fechaFormateada + " AM";
                }
                else
                {
                    fechaFormateada = fechaOriginal;
                }
            }
            return fechaFormateada;
        }

    }
}
