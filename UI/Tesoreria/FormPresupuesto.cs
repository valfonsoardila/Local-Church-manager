using BLL;
using Cloud;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UI
{
    public partial class FormPresupuesto : Form
    {
        Validaciones validaciones;
        PresupuestoService presupuestoService;
        TabPage tabPage;
        Presupuesto presupuesto;
        List<Presupuesto> presupuestos;
        BudgetData budgetData;
        BudgetMaps budgetMaps;
        List<BudgetData> presupuestosComite;
        List<BudgetData> presupuestosGeneral;
        int id = 0;
        int sumPresupuestos = 0;
        int ultimoId;
        int ofrendasIngresos;
        int votosIngresos;
        int activIdadesIngresos;
        int otrosIngresos;
        int sumEgresos;
        string comite = "";
        bool detallo = false;
        bool encontrado = false;
        bool nuevoConcepto = false;
        public FormPresupuesto()
        {
            validaciones = new Validaciones();
            presupuestoService = new PresupuestoService(ConfigConnection.ConnectionString);
            budgetData = new BudgetData();
            budgetMaps = new BudgetMaps();
            InitializeComponent();
            ObtenerUltimoPresupuesto();
            ConsultarPresupuesto();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void ObtenerUltimoPresupuesto()
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData").OrderByDescending("id").Limit(1);

                var snapshot = await presupuestosQuery.GetSnapshotAsync();

                if (snapshot.Documents.Count > 0)
                {
                    var ultimoRegistro = snapshot.Documents.First();
                    ultimoId = ultimoRegistro.GetValue<int>("id");
                }
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.ConsultarTodos();
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    var ultimopresupuesto = respuesta.Presupuestos.Last();
                    ultimoId = ultimopresupuesto.Id;
                }
            }
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
                presupuestosGeneral = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestosGeneral = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                if (presupuestosGeneral.Count > 0)
                {
                    dataGridPresupuestos.DataSource = null;
                    dataGridPresupuestos.DataSource = presupuestosGeneral;
                    textTotal.Text = presupuestosGeneral.Count.ToString();
                    textTotalPresupuestos.Text = snapshot.Documents.Sum(doc => doc.ConvertTo<BudgetData>().TotalPresupuesto).ToString();
                    ObtenerDatosGenerales();
                }
                else
                {
                    dataGridPresupuestos.DataSource = null;
                    textTotal.Text = "0";
                }
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.ConsultarTodos();
                if (respuesta.Presupuestos.Count != 0 && respuesta.Presupuestos != null)
                {
                    dataGridPresupuestos.DataSource = null;
                    presupuestos = respuesta.Presupuestos.ToList();
                    dataGridPresupuestos.DataSource = presupuestos;
                    Borrar.Visible = true;
                    textTotal.Text = presupuestoService.Totalizar().Cuenta.ToString();
                    ObtenerDatosGenerales();
                }
            }
        }

        private void FormPresupuesto_Load(object sender, EventArgs e)
        {
            if (tabPresupuestos.TabCount > 0)
            {
                tabPage = tabPresupuestos.TabPages["tabPorcentajes"];
                tabPresupuestos.TabPages.RemoveAt(2);
            }
            comboFiltroAño.Text = DateTime.Now.Year.ToString();
            comboAño.Text = DateTime.Now.Year.ToString();
        }
        private async void EliminarPresupuesto(int id)
        {
            try
            {
                //Elimina primero de firebase o la nube
                var db = FirebaseService.Database;
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(id.ToString());
                await docRef.DeleteAsync();
                string mensaje = presupuestoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridPresupuestos.DataSource = null;
                ConsultarPresupuesto();
                ObtenerDatosGenerales();
                ObtenerDatosIndividuales();
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                string mensaje = presupuestoService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
            }
        }
        private void AgregarAGridRubros()
        {
            List<double> porcentajes = CalcularPorcentajeRubros();
            double porcentajeOfrenda = porcentajes[0];
            double porcentajeActividad = porcentajes[1];
            double porcentajeVoto = porcentajes[2];
            double porcentajeOtroConcepto = porcentajes[3];
            double porcentajeOfrendaRestante = porcentajes[4];
            double porcentajeActividadesRestante = porcentajes[5];
            double porcentajeVotosRestante = porcentajes[6];
            double porcentajeOtrosRestante = porcentajes[7];
            
            // Agregar filas al DataGridView con los valores necesarios
            dataGridRubros.Rows.Clear();
            dataGridRubros.Rows.Add("1", "Ofrenda", LecturaCifra(ofrendasIngresos), porcentajeOfrenda.ToString() + "%", porcentajeOfrendaRestante.ToString()+"%");
            dataGridRubros.Rows.Add("2", "Voto", LecturaCifra(votosIngresos), porcentajeActividad.ToString() + "%", porcentajeActividadesRestante.ToString()+"%");
            dataGridRubros.Rows.Add("3", "Actividades", LecturaCifra(activIdadesIngresos), porcentajeVoto.ToString() + "%", porcentajeVotosRestante.ToString()+"%");
            dataGridRubros.Rows.Add("4", "Otros", LecturaCifra(otrosIngresos), porcentajeOtroConcepto.ToString() + "%", porcentajeOtrosRestante.ToString()+"%");

            //Agregar a las graficas
            //limpia los puntos anteriores
            chartOfrendas.Series[0].Points.Clear();
            chartActividades.Series[0].Points.Clear();
            chartVotos.Series[0].Points.Clear();
            chartOtroConcepto.Series[0].Points.Clear();

            // Agrega los nuevos puntos al gráfico
            chartOfrendas.Series[0].Points.AddXY("Porcentaje de Ofrendas ingresadas ", porcentajeOfrenda);
            chartOfrendas.Series[0].Points.AddXY("Porcentaje de Ofrenda restante", porcentajeOfrendaRestante);
            chartActividades.Series[0].Points.AddXY("Porcentaje de Actividades ingresadas ", porcentajeActividad);
            chartActividades.Series[0].Points.AddXY("Porcentaje de Actividades restante", porcentajeActividadesRestante);
            chartVotos.Series[0].Points.AddXY("Porcentaje de Votos ingresados ", porcentajeVoto);
            chartVotos.Series[0].Points.AddXY("Porcentaje de Votos restante", porcentajeVotosRestante);
            chartOtroConcepto.Series[0].Points.AddXY("Porcentaje de Otros conceptos ingresados ",porcentajeOtroConcepto);
            chartOtroConcepto.Series[0].Points.AddXY("Porcentaje de Otro conceptos restante", porcentajeOtrosRestante);

            // Configura el gráfico para ofrendas
            chartOfrendas.Series[0].ChartType = SeriesChartType.Doughnut;
            chartOfrendas.Series[0].IsValueShownAsLabel = true;
            chartOfrendas.Series[0].LabelFormat = "#,##";
            chartOfrendas.Titles.Clear();
            chartOfrendas.Titles.Add("Porcentaje de ofrendas para " + comite);
            // Configura el gráfico para actividades
            chartActividades.Series[0].ChartType = SeriesChartType.Doughnut;
            chartActividades.Series[0].IsValueShownAsLabel = true;
            chartActividades.Series[0].LabelFormat = "#,##";
            chartActividades.Titles.Clear();
            chartActividades.Titles.Add("Porcentaje de actividades para " + comite);
            // Configura el gráfico para actividades
            chartVotos.Series[0].ChartType = SeriesChartType.Doughnut;
            chartVotos.Series[0].IsValueShownAsLabel = true;
            chartVotos.Series[0].LabelFormat = "#,##";
            chartVotos.Titles.Clear();
            chartVotos.Titles.Add("Porcentaje de votos para " + comite);
            // Configura el gráfico para Otros conceptos
            chartOtroConcepto.Series[0].ChartType = SeriesChartType.Doughnut;
            chartOtroConcepto.Series[0].IsValueShownAsLabel = true;
            chartOtroConcepto.Series[0].LabelFormat = "#,##";
            chartOtroConcepto.Titles.Clear();
            chartOtroConcepto.Titles.Add("Porcentaje de Otros conceptos para " + comite);

            tabPresupuestos.TabPages.Add(tabPage);
            tabPresupuestos.SelectedIndex = 2;
            detallo = true;
        }
        private List<double> CalcularPorcentajeRubros()
        {
            // Porcentajes del presupuesto
            int ofrenda = presupuestosComite.Sum(p => p.Ofrenda);
            int actividad = presupuestosComite.Sum(p => p.Actividad);
            int voto = presupuestosComite.Sum(p => p.Voto);
            int otroConcepto = presupuestosComite.Sum(p => p.ValorOtroConcepto);

            double porcentajeOfrenda = ofrendasIngresos * 100 / ofrenda;
            double porcentajeActividad = activIdadesIngresos * 100 / actividad;
            double porcentajeVoto = votosIngresos * 100 / voto;
            double porcentajeOtroConcepto = otroConcepto != 0 ? otrosIngresos * 100 / otroConcepto : 0;

            double diferenciaOfrenda = 100 - porcentajeOfrenda;
            double diferenciaActividad = 100 - porcentajeActividad;
            double diferenciaVoto = 100 - porcentajeVoto;
            double diferenciaOtroConcepto = 100 - porcentajeOtroConcepto;

            return new List<double> { 
                porcentajeOfrenda, 
                porcentajeActividad, 
                porcentajeVoto, 
                porcentajeOtroConcepto,
                diferenciaOfrenda,
                diferenciaActividad,
                diferenciaVoto,
                diferenciaOtroConcepto
            };
        }
        private async void FiltrarPresupuestosPorComite(string comite)
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                var presupuestos = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                presupuestosComite = presupuestos.Where(presupuesto => presupuesto.Comite == comite).ToList();
                ObtenerIngresosYEgresos();
                dataGridPresupuestos.DataSource = presupuestosComite;
                Borrar.Visible = true;
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.FiltrarPresupuestosPorComite(comite);
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
                    comboInicioIntervalo.Text = presupuestoFiltrado.InicioIntervalo;
                    comboFinIntervalo.Text = presupuestoFiltrado.FinIntervalo;
                    comboComite.Text = presupuestoFiltrado.Comite;
                    textOfrendas.Text = presupuestoFiltrado.Ofrenda.ToString();
                    textActividades.Text = presupuestoFiltrado.Actividad.ToString();
                    textVotos.Text = presupuestoFiltrado.Voto.ToString();
                }
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                BusquedaPresupuestoRespuesta respuesta = new BusquedaPresupuestoRespuesta();
                respuesta = presupuestoService.BuscarPorIdentificacion(id);
                var registro = respuesta.Presupuesto;
                if (registro != null)
                {
                    encontrado = true;
                    var presupuestos = new List<Presupuesto> { registro };
                    comboInicioIntervalo.Text = presupuestos[0].InicioIntervalo;
                    comboFinIntervalo.Text = presupuestos[0].FinIntervalo;
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
        private async void CalculoDeSaldo()
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                // Realizar la suma directamente en la consulta Firestore
                var snapshotPresupuesto = await presupuestosQuery.GetSnapshotAsync();
                sumPresupuestos = snapshotPresupuesto.Documents.Sum(doc => doc.ConvertTo<BudgetData>().TotalPresupuesto);
                textTotalPresupuestos.Text = LecturaCifra(sumPresupuestos);
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                Console.WriteLine($"Error al calcular el saldo: {ex.Message}");
                // Manejar la excepción según tus necesidades
            }
        }
        private void Limpiar()
        {
            comboInicioIntervalo.Text = "Enero";
            comboFinIntervalo.Text = "Enero";
            comboComite.Text = "Comite";
            textOfrendas.Text = "$ 000.00";
            textActividades.Text = "$ 000.00";
            textVotos.Text = "$ 000.00";
            textNuevoConcepto.Text = "Nuevo concepto";
            textOtroValor.Text = "$ 000.00";
            textPresupuesto.Text = "$ 000.00";
        }
        private void ValidarNuevoConcepto()
        {
            if (textNuevoConcepto.Text != "" && textNuevoConcepto.Text == "Nuevo concepto")
            {
                nuevoConcepto = true;
            }
        }
        private int ObtenerCantidadEntera(string cantidad)
        {
            string cantidadSinSigno = cantidad.Replace("$", "").Trim(); // Esto quita el signo "$"
            string cantidadSinPuntos = cantidadSinSigno.Replace(".", "").Trim();
            int cantidadEntera = int.Parse(cantidadSinPuntos);
            return cantidadEntera;
        }
        private Presupuesto MapearPresupuesto()
        {
            presupuesto = new Presupuesto();
            presupuesto.Id = ultimoId != 0 ? ultimoId : 0;
            presupuesto.AñoPresupuesto = comboAño.Text;
            presupuesto.InicioIntervalo = comboInicioIntervalo.Text;
            presupuesto.FinIntervalo = comboFinIntervalo.Text;
            presupuesto.Comite = comboComite.Text;
            presupuesto.Ofrenda = ObtenerCantidadEntera(textOfrendas.Text);
            presupuesto.Actividad = ObtenerCantidadEntera(textActividades.Text);
            presupuesto.Voto = ObtenerCantidadEntera(textVotos.Text);
            presupuesto.OtroConcepto = nuevoConcepto ? "Ninguno" : textNuevoConcepto.Text;
            presupuesto.ValorOtroConcepto = nuevoConcepto ? 0 : ObtenerCantidadEntera(textOtroValor.Text);
            presupuesto.TotalEgresos = ObtenerCantidadEntera(textEgresos.Text);
            presupuesto.TotalPresupuesto = ObtenerCantidadEntera(textPresupuesto.Text);
            return presupuesto;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            ValidarNuevoConcepto();
            Presupuesto presupuesto = MapearPresupuesto();
            try
            {
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var budgetNuevo = budgetMaps.BudgetMap(presupuesto);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(budgetNuevo.Id);
                docRef.SetAsync(budgetNuevo);
                // Guardamos localmente
                var msg = presupuestoService.Guardar(presupuesto);
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
                CalculoDeSaldo();
                Limpiar();
                tabPresupuestos.SelectedIndex = 0;
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = presupuestoService.Guardar(presupuesto);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarPresupuesto();
                    //Limpiar();
                    tabPresupuestos.SelectedIndex = 0;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            Presupuesto presupuesto = MapearPresupuesto();
            try
            {
                var msg = presupuestoService.Guardar(presupuesto);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var budgetNuevo = budgetMaps.BudgetMap(presupuesto);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("BudgetData").Document(budgetNuevo.Id);
                docRef.SetAsync(budgetNuevo);
                // Guardamos localmente
                MessageBox.Show(msg, "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarPresupuesto();
                CalculoDeSaldo();
                Limpiar();
                tabPresupuestos.SelectedIndex = 0;
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = presupuestoService.Guardar(presupuesto);
                    MessageBox.Show(msg, "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarPresupuesto();
                    Limpiar();
                    tabPresupuestos.SelectedIndex = 0;
                }
            }
        }

        private void textOfrendas_Validated(object sender, EventArgs e)
        {
            if (textOfrendas.Text != "" && textOfrendas.Text != "$ 000.00")
            {
                int sumOfrendas = int.Parse(textOfrendas.Text);
                textOfrendas.Text = LecturaCifra(sumOfrendas);
            }
        }

        private void textActividades_Validated(object sender, EventArgs e)
        {
            if (textActividades.Text != "" && textActividades.Text != "$ 000.00")
            {
                int sumActividades = int.Parse(textActividades.Text);
                textActividades.Text = LecturaCifra(sumActividades);
            }
        }

        private void textVotos_Validated(object sender, EventArgs e)
        {
            if (textVotos.Text != "" && textVotos.Text != "$ 000.00")
            {
                int sumVotos = int.Parse(textVotos.Text);
                textVotos.Text = LecturaCifra(sumVotos);
            }
        }

        private void textOtroValor_Validated(object sender, EventArgs e)
        {
            if (textOtroValor.Text != "" && textOtroValor.Text != "$ 000.00")
            {
                int sumOtroValor = int.Parse(textOtroValor.Text);
                textOtroValor.Text = LecturaCifra(sumOtroValor);
            }
        }

        //private void textPresupuesto_Validated(object sender, EventArgs e)
        //{
        //    if (textPresupuesto.Text != "" && textPresupuesto.Text != "$ 000.00")
        //    {
        //        int sumPresupuesto = int.Parse(textPresupuesto.Text);
        //        textPresupuesto.Text = LecturaCifra(sumPresupuesto);
        //    }
        //}

        private void textEgresos_Validated(object sender, EventArgs e)
        {
            if (textEgresos.Text != "" && textEgresos.Text != "$ 000.00")
            {
                int sumEgreso = int.Parse(textEgresos.Text);
                textEgresos.Text = LecturaCifra(sumEgreso);
            }
        }

        private void textOtroConcepto_Enter(object sender, EventArgs e)
        {
            string placeHolder = textNuevoConcepto.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textNuevoConcepto.Text = validaciones.TextoPlaceHolderEnter(placeHolder, nombreDelComponente);
        }

        private void textOtroConcepto_Leave(object sender, EventArgs e)
        {
            string placeHolder = textNuevoConcepto.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textNuevoConcepto.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }

        private void textOfrendas_Enter(object sender, EventArgs e)
        {
            if (textOfrendas.Text != "")
            {
                textOfrendas.Text = "";
            }
        }

        private void textOfrendas_Leave(object sender, EventArgs e)
        {
            if (textOfrendas.Text == "")
            {
                textOfrendas.Text = "$ 000.00";
            }
        }

        private void textActividades_Enter(object sender, EventArgs e)
        {
            if (textActividades.Text != "")
            {
                textActividades.Text = "";
            }
        }

        private void textActividades_Leave(object sender, EventArgs e)
        {
            if (textActividades.Text == "")
            {
                textActividades.Text = "$ 000.00";
            }
        }

        private void textVotos_Enter(object sender, EventArgs e)
        {
            if (textVotos.Text != "")
            {
                textVotos.Text = "";
            }
        }

        private void textVotos_Leave(object sender, EventArgs e)
        {
            if (textVotos.Text == "")
            {
                textVotos.Text = "$ 000.00";
            }
        }

        private void textOtroValor_Enter(object sender, EventArgs e)
        {
            if (textOtroValor.Text != "")
            {
                textOtroValor.Text = "";
            }
        }

        private void textOtroValor_Leave(object sender, EventArgs e)
        {
            if (textOtroValor.Text == "")
            {
                textOtroValor.Text = "$ 000.00";
            }
        }

        private void textPresupuesto_Enter(object sender, EventArgs e)
        {
            if (textPresupuesto.Text != "")
            {
                textPresupuesto.Text = "";
            }
            TotalizarConceptos();
        }

        private void textPresupuesto_Leave(object sender, EventArgs e)
        {
            if (textPresupuesto.Text == "")
            {
                textPresupuesto.Text = "$ 000.00";
            }
        }

        private void textEgresos_Enter(object sender, EventArgs e)
        {
            if (textEgresos.Text != "")
            {
                textEgresos.Text = "";
            }
        }

        private void textEgresos_Leave(object sender, EventArgs e)
        {
            if (textEgresos.Text == "")
            {
                textEgresos.Text = "$ 000.00";
            }
        }
        private void TotalizarConceptos()
        {
            int ofrendas = ObtenerCantidadEntera(textOfrendas.Text);
            int actividades = ObtenerCantidadEntera(textActividades.Text);
            int votos = ObtenerCantidadEntera(textVotos.Text);
            int otro = ObtenerCantidadEntera(textOtroValor.Text);
            int totalConceptos = ofrendas + actividades + votos + otro;
            textPresupuesto.Text = LecturaCifra(totalConceptos);
        }
        private async void ObtenerIngresosYEgresos()
        {
            try
            {
                var db = FirebaseService.Database;
                var ingresosQuery = db.Collection("IngressData").WhereEqualTo("Comite", comite);
                var ingresos = new List<IngressData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await ingresosQuery.GetSnapshotAsync();
                ingresos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<IngressData>()).ToList();
                // Filtrar ingresos por concepto y contar la cantidad de cada uno
                ofrendasIngresos = ingresos.Where(i => i.Concepto == "Ofrenda").Sum(p => p.Valor);
                votosIngresos = ingresos.Where(i => i.Concepto == "Voto").Sum(p => p.Valor);
                activIdadesIngresos = ingresos.Where(i => i.Concepto == "Actividades").Sum(p => p.Valor);
                otrosIngresos = ingresos.Where(i => i.Concepto == "Otros").Sum(p => p.Valor);
                var egresosQuery = db.Collection("EgressData").WhereEqualTo("Comite", comite);
                var egresos = new List<EgressData>();
                // Realizar la suma directamente en la consulta Firestore
                snapshot = await egresosQuery.GetSnapshotAsync();
                egresos = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<EgressData>()).ToList();
                sumEgresos = egresos.Sum(p => p.Valor);
                ObtenerDatosIndividuales();
                AgregarAGridRubros();
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ObtenerDatosIndividuales()
        {
            //Este se representará con los datos individuales de cada comite que son ofrendas, actividades, votos y otro.
            if (presupuestosComite != null && presupuestosComite.Any())
            {
                // Presupuestos 100% por conceptos
                int ofrenda = presupuestosComite.Sum(p => p.Ofrenda);
                int actividad = presupuestosComite.Sum(p => p.Actividad);
                int voto = presupuestosComite.Sum(p => p.Voto);
                int otroConcepto = presupuestosComite.Sum(p => p.ValorOtroConcepto);
                int egresos = presupuestosComite.Sum(p => p.TotalEgresos);

                // Calcula los porcentajes con respecto a los ingresos
                double porcentajeOfrenda = ofrendasIngresos * 100 / ofrenda;
                double porcentajeActividad = activIdadesIngresos * 100 / actividad;
                double porcentajeVoto = votosIngresos * 100 / voto;
                double porcentajeOtroConcepto = otrosIngresos != 0 ? otrosIngresos * 100 / otroConcepto : 0;

                double porcentajeEgresos = sumEgresos * 100 / egresos;
                double porcentajeEgresosRestante = 100 - porcentajeEgresos;

                //Calcula los nuevos porcentajes con respecto al presupuesto
                var OfrendaRebasada = "";
                var ActividadRebasada = "";
                var VotoRebasado = "";
                var OtroConceptoRebosado = "";
                var EgresosRebasados = "";
                if (porcentajeOfrenda > 100)
                {
                    OfrendaRebasada = "rebasada en un " + (porcentajeOfrenda - 100).ToString() + "%";
                    porcentajeOfrenda = (ofrenda * 100) / presupuestosComite[0].TotalPresupuesto;
                    if (porcentajeActividad > 100)
                    {
                        ActividadRebasada = "rebasada en un " + (porcentajeActividad - 100).ToString() + "%";
                        porcentajeActividad = (actividad * 100) / presupuestosComite[0].TotalPresupuesto;
                        if (porcentajeVoto > 100)
                        {
                            VotoRebasado = "rebasado en un " + (porcentajeVoto - 100).ToString() + "%";
                            porcentajeVoto = (voto * 100) / presupuestosComite[0].TotalPresupuesto;
                        }
                    }
                }
                if (porcentajeOtroConcepto > 100)
                {
                    OtroConceptoRebosado = "rebasado en un " + (porcentajeOtroConcepto - 100).ToString() + "%";
                    porcentajeOtroConcepto = (otroConcepto * 100) / presupuestosComite[0].TotalPresupuesto;
                }
                if (porcentajeEgresos > 100)
                {
                    EgresosRebasados = "rebasados en un " + (porcentajeEgresos - 100).ToString() + "%";
                    porcentajeEgresos = (egresos * 100) / presupuestosComite[0].TotalEgresos;

                }

                //limpia los puntos anteriores
                chartIngresoIndividual.Series[0].Points.Clear();
                chartEgresoIndividual.Series[0].Points.Clear();

                // Agrega los nuevos puntos al gráfico
                chartIngresoIndividual.Series[0].Points.AddXY("Ofrenda " + OfrendaRebasada, porcentajeOfrenda);
                chartIngresoIndividual.Series[0].Points.AddXY("Actividad " + ActividadRebasada, porcentajeActividad);
                chartIngresoIndividual.Series[0].Points.AddXY("Voto " + VotoRebasado, porcentajeVoto);
                chartIngresoIndividual.Series[0].Points.AddXY("Otro Concepto " + OtroConceptoRebosado, porcentajeOtroConcepto);

                chartEgresoIndividual.Series[0].Points.AddXY("Egresos " + EgresosRebasados, porcentajeEgresos);
                chartEgresoIndividual.Series[0].Points.AddXY("Egresos restantes", porcentajeEgresosRestante);

                // Configura el gráfico ingresos
                chartIngresoIndividual.Series[0].ChartType = SeriesChartType.Doughnut;
                chartIngresoIndividual.Series[0].IsValueShownAsLabel = true;
                chartIngresoIndividual.Series[0].LabelFormat = "#,##";
                chartIngresoIndividual.Titles.Clear();
                chartIngresoIndividual.Titles.Add("Distribución de ingresos para " + comite);
                // Configura el gráfico egresos
                chartEgresoIndividual.Series[0].ChartType = SeriesChartType.Doughnut;
                chartEgresoIndividual.Series[0].IsValueShownAsLabel = true;
                chartEgresoIndividual.Series[0].LabelFormat = "#,##";
                chartEgresoIndividual.Titles.Clear();
                chartEgresoIndividual.Titles.Add("Distribución de egresos para " + comite);
            }
        }
        private void ObtenerDatosGenerales()
        {
            if (presupuestosGeneral != null && presupuestosGeneral.Any())
            {

            }
        }

        private void tabPresupuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPresupuestos.SelectedIndex != 2 && detallo != false)
            {
                tabPage = tabPresupuestos.TabPages["tabPorcentajes"];
                tabPresupuestos.TabPages.RemoveAt(2);
                detallo = false;
            }
        }

        private void dataGridPresupuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPresupuestos.DataSource != null)
            {
                if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["Id"].Value.ToString());
                    EliminarPresupuesto(id);
                    ConsultarPresupuesto();
                }
                else
                {
                    if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Detallar")
                    {
                        comite = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["Comite"].Value.ToString());
                        FiltrarPresupuestosPorComite(comite);
                    }
                    else
                    {
                        if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Editar")
                        {
                            id = Convert.ToInt32(dataGridPresupuestos.CurrentRow.Cells["Id"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabPresupuestos.SelectedIndex = 1;
                            }
                        }
                        else
                        {
                            if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Seleccionar")
                            {
                                // Verificar si el clic se realizó en la columna de CheckBoxColumn
                                if (e.ColumnIndex == dataGridPresupuestos.Columns["Seleccionar"].Index && e.RowIndex != -1)
                                {
                                    // Obtener la celda de CheckBox clicada
                                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridPresupuestos.Rows[e.RowIndex].Cells["Seleccionar"];
                                    // Cambiar el estado del CheckBox
                                    checkBoxCell.Value = !Convert.ToBoolean(checkBoxCell.Value);
                                    // Consulta
                                    comite = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["Comite"].Value.ToString());
                                    FiltrarPresupuestosPorComite(comite);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            FormGenerarDocumento formGenerarDocumento = new FormGenerarDocumento();
            formGenerarDocumento.Show();
        }
        private async void FiltroPorAño(string filtro)
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                presupuestosGeneral = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestosGeneral = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                var presupuestosFiltrados = presupuestosGeneral.Where(presupuesto => presupuesto.AñoPresupuesto == filtro).ToList();
                dataGridPresupuestos.DataSource = presupuestosFiltrados;
                Borrar.Visible = true;
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch(Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.FiltrarPresupuestosPorAño(filtro);
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
        private async void FiltroPorComite(string filtro)
        {
            try
            {
                var db = FirebaseService.Database;
                var presupuestosQuery = db.Collection("BudgetData");
                presupuestosGeneral = new List<BudgetData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await presupuestosQuery.GetSnapshotAsync();
                presupuestosGeneral = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<BudgetData>()).ToList();
                var presupuestosFiltrados= presupuestosGeneral.Where(presupuesto => presupuesto.Comite == filtro).ToList();
                dataGridPresupuestos.DataSource = presupuestosFiltrados;
                Borrar.Visible = true;
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnSuccesfulOperations(new SuccesfullEventArgs("Succesfull"));
                }
            }
            catch(Exception ex)
            {
                // Obtener referencia al formulario principal
                FormMenu formPrincipal = Application.OpenForms.OfType<FormMenu>().FirstOrDefault();
                // Verificar si el formulario principal está abierto
                if (formPrincipal != null)
                {
                    // Lanzar el evento para notificar al formulario principal sobre la excepción
                    formPrincipal.OnExcepcionOcurrida(new ExcepcionEventArgs(ex.Message));
                }
                ConsultaPresupuestoRespuesta respuesta = new ConsultaPresupuestoRespuesta();
                respuesta = presupuestoService.FiltrarPresupuestosPorComite(filtro);
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
        private void comboFiltroComite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboFiltroComite.Text;
            if (filtro == "Todos")
            {
                ConsultarPresupuesto();
            }
            else
            {
                comboFiltroAño.Text = DateTime.Now.Year.ToString();
                FiltroPorComite(filtro);
            }
        }

        private void comboFiltroAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboFiltroAño.Text;
            if (filtro == "Todos")
            {
                ConsultarPresupuesto();
            }
            else
            {
                comboFiltroComite.Text = "Todos";
                FiltroPorAño(filtro);
            }
        }
    }
}