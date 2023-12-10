using BLL;
using Cloud;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2013.WebExtension;
using Entity;
using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormLiquidacion : Form
    {
        Egreso egreso;
        EgresoService egresoService;
        EgressMaps egressMaps;
        LiquidacionService liquidacionService;
        SettlementMaps settlementMaps;
        List<Liquidacion> liquidaciones;
        Liquidacion liquidacion;
        string originalText;
        string id = "";
        bool encontrado = false;
        int sumEgreso = 0;
        int sumLiquidaciones = 0;
        public FormLiquidacion()
        {
            liquidacionService = new LiquidacionService(ConfigConnection.ConnectionString);
            settlementMaps = new SettlementMaps();
            egresoService = new EgresoService(ConfigConnection.ConnectionString);
            egressMaps = new EgressMaps();
            InitializeComponent();
            ConsultarLiquidaciones();
        }
        private async void TotalizarRegistros()
        {
            try
            {
                var db = FirebaseService.Database;
                var liquidacionesQuery = db.Collection("SettlementData");
                var snapshot = await liquidacionesQuery.GetSnapshotAsync();
                textTotalNube.Text = snapshot.Documents.Count().ToString();
                textTotalLocal.Text = liquidacionService.Totalizar().Cuenta.ToString();
            }
            catch (Exception ex)
            {
                ConsultaLiquidacionRespuesta respuesta = new ConsultaLiquidacionRespuesta();
                respuesta = liquidacionService.ConsultarTodos();
                if (respuesta.Liquidaciones.Count != 0 && respuesta.Liquidaciones != null)
                {
                    dataGridLiquidacion.DataSource = null;
                    liquidaciones = respuesta.Liquidaciones.ToList();
                    if (respuesta.Liquidaciones.Count != 0 && respuesta.Liquidaciones != null)
                    {
                        textTotalLocal.Text = liquidacionService.Totalizar().Cuenta.ToString();
                        textTotalNube.Text = "0";
                    }
                    else
                    {
                        textTotalLocal.Text = "0";
                        textTotalNube.Text = "0";
                    }
                }
            }
        }

        private async void ConsultarLiquidaciones()
        {
            TotalizarRegistros();
            int sumTotal = 0;
            try
            {
                var db = FirebaseService.Database;
                var egresosQuery = db.Collection("EgressData");
                var shippableQuery = db.Collection("SettlementData");
                var enviables = new List<SettlementData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await shippableQuery.GetSnapshotAsync();
                var snapshotEgress = await egresosQuery.GetSnapshotAsync();
                enviables = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<SettlementData>()).ToList();
                sumTotal = snapshot.Documents.Sum(doc => doc.ConvertTo<SettlementData>().Valor);
                sumEgreso = snapshotEgress.Documents.Sum(doc => doc.ConvertTo<EgressData>().Valor);
                if (enviables.Count > 0)
                {
                    dataGridLiquidacion.DataSource = null;
                    dataGridLiquidacion.DataSource = enviables;
                    comboFecha.Text = "Mes";
                    textTotalLiquidacion.Text = LecturaCifra(sumTotal);
                    textSaldo.Text = LecturaCifra(sumEgreso);
                }
                else
                {
                    dataGridLiquidacion.DataSource = null;
                    textTotalLocal.Text = "0";
                    comboFecha.Text = "Mes";
                }
            }
            catch (Exception e)
            {
                ConsultaLiquidacionRespuesta respuesta = new ConsultaLiquidacionRespuesta();
                respuesta = liquidacionService.ConsultarTodos();
                if (respuesta.Liquidaciones.Count != 0 && respuesta.Liquidaciones != null)
                {
                    dataGridLiquidacion.DataSource = null;
                    liquidaciones = respuesta.Liquidaciones.ToList();
                    dataGridLiquidacion.DataSource = respuesta.Liquidaciones;
                    Borrar.Visible = true;
                    textTotalLocal.Text = liquidacionService.Totalizar().Cuenta.ToString();
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionarDirectivas_Click(object sender, EventArgs e)
        {
            tabLiquidaciones.SelectedIndex = 1;
        }

        private void textDetalle_Enter(object sender, EventArgs e)
        {
            if (textDetalle.Text == "Detalle")
            {
                textDetalle.Text = "";
            }
        }

        private void textDetalle_Leave(object sender, EventArgs e)
        {
            if (textDetalle.Text == "")
            {
                textDetalle.Text = "Detalle";
            }
        }

        private void textDineroIngreso_Enter(object sender, EventArgs e)
        {
            originalText = textDineroIngreso.Text;
            if (textDineroIngreso.Text == "$ 000.00")
            {
                textDineroIngreso.Text = "";
            }
            else
            {

                if (textDineroIngreso.Text.StartsWith("$ "))
                {
                    // Borra el contenido del TextBox si comienza con "$ "
                    textDineroIngreso.Text = "";
                }
            }
        }

        private void textDineroIngreso_Leave(object sender, EventArgs e)
        {
            if (textDineroIngreso.Text == "")
            {
                textDineroIngreso.Text = "$ 000.00";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textDineroIngreso.Text))
                {
                    // Restaura el contenido original al salir del TextBox
                    textDineroIngreso.Text = originalText;
                }
            }
        }

        private void textDineroIngreso_Validated(object sender, EventArgs e)
        {
            if (textDineroIngreso.Text != "" && textDineroIngreso.Text != "$ 000.00")
            {
                textDineroIngreso.Text = "$ " + textDineroIngreso.Text;
            }
        }

        private void dataGridLiquidacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridLiquidacion.DataSource != null)
            {
                if (dataGridLiquidacion.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToString(dataGridLiquidacion.CurrentRow.Cells["Id"].Value.ToString());
                    EliminarLiquidacion(id);
                    ConsultarLiquidaciones();
                }
                else
                {
                    if (dataGridLiquidacion.Columns[e.ColumnIndex].Name == "Editar")
                    {
                        id = Convert.ToString(dataGridLiquidacion.CurrentRow.Cells["Id"].Value.ToString());
                        FiltroPorId(id);
                        if (encontrado == true)
                        {
                            tabLiquidaciones.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        if (dataGridLiquidacion.Columns[e.ColumnIndex].Name == "Egresar")
                        {
                            id = Convert.ToString(dataGridLiquidacion.CurrentRow.Cells["Id"].Value.ToString());
                            GestionarNuevoEgreso(id);
                        }
                    }
                }
            }
        }
        private async void GestionarNuevoEgreso(string id)
        {
            try
            {
                //Instancio la conexio y la lista de datos a consultar
                var db = FirebaseService.Database;
                var liquidaciones = new List<SettlementData>();
                //defino las colecciones que interactuaran
                var egresosQuery = db.Collection("EgressData");
                var settlementsQuery = db.Collection("SettlementData");
                //Hago las respectivas consultas
                var snapshotEgress = await egresosQuery.GetSnapshotAsync();
                var snapshotSettlements = await settlementsQuery.GetSnapshotAsync();
                //Obtengo todas las liquidaciones y las guardo en la lista de datos
                liquidaciones = snapshotSettlements.Documents.Select(docsnap => docsnap.ConvertTo<SettlementData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var liquidacionesFiltradas = liquidaciones.Where(liquidacion => liquidacion.Id == id).ToList();
                if (liquidacionesFiltradas.Any())
                {
                    var liquidacionFiltrada = liquidacionesFiltradas.First(); // Obtener el primer elemento de la lista
                    Google.Cloud.Firestore.DocumentReference docRefSettlement = db.Collection("SettlementData").Document(liquidacionFiltrada.Id);
                    liquidacionFiltrada.Estado = "Egresado";
                    await docRefSettlement.SetAsync(liquidacionFiltrada);
                    // Se registra el egreso
                    string formatoFecha = "d/M/yyyy h:mm:ss:tt";
                    //codigo
                    string primeraLetra = liquidacionFiltrada.Id.Substring(1, 1);
                    string segundaLetra = liquidacionFiltrada.Id.Substring(3, 1);
                    string primerNumero = liquidacionFiltrada.Id.Substring(5, 1);
                    string segundoNumero = liquidacionFiltrada.Id.Substring(8, 1);
                    string tercerNumero = liquidacionFiltrada.Id.Substring(9, 1);
                    Egreso egreso = MapearEgreso(
                        primeraLetra + segundaLetra + primerNumero + segundoNumero + tercerNumero, 
                        DateTime.ParseExact(liquidacionFiltrada.FechaDeLiquidacion, formatoFecha, CultureInfo.InvariantCulture), 
                        "Junta Local", 
                        "Liquidacion", 
                        liquidacionFiltrada.Valor.ToString(), 
                        liquidacionFiltrada.Detalle
                    );
                    var msg = egresoService.Guardar(egreso);
                    var egress = egressMaps.EgressMap(egreso);
                    Google.Cloud.Firestore.DocumentReference docRefEgress = db.Collection("EgressData").Document(liquidacionFiltrada.Id);
                    await docRefEgress.SetAsync(egress);
                    MessageBox.Show(msg, "Mensaje de egreso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    // Suma el valor de la liquidacion al egreso
                    sumEgreso = snapshotEgress.Documents.Sum(doc => doc.ConvertTo<EgressData>().Valor);
                    textSaldo.Text = sumEgreso.ToString();
                }
            }
            catch
            {

            }
        }
        private Egreso MapearEgreso(string code, DateTime date, string comite, string concept, string valor, string detalle)
        {
            egreso = new Egreso();
            egreso.CodigoComprobante = code;
            egreso.FechaDeEgreso = date;
            egreso.Comite = comite;
            egreso.Concepto = concept;
            string cantidadConSigno = valor; // Esto contiene "$ 30000"
            string cantidadSinSigno = cantidadConSigno.Replace("$", "").Trim(); // Esto quita el signo "$"
            string cantidadSinPuntos = cantidadSinSigno.Replace(".", "").Trim();
            int cantidadEntera = int.Parse(cantidadSinPuntos); // Convierte el valor a un entero
            egreso.Valor = cantidadEntera;
            egreso.Detalle = detalle;
            return egreso;
        }
        private string LecturaCifra(int totalDeIngresos)
        {
            // Convierte el total de ingresos a una cadena con separadores de miles
            string cifraFormateada = totalDeIngresos.ToString("N0");

            // Muestra la cifra formateada en el TextBox o donde desees
            string valorFormateado = $"${cifraFormateada}";
            return valorFormateado;
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

        private async void FiltroPorId(string id)
        {
            try
            {
                var db = FirebaseService.Database;
                var liquidacioensQuery = db.Collection("SettlementData");
                var liquidaciones = new List<SettlementData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await liquidacioensQuery.GetSnapshotAsync();
                liquidaciones = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<SettlementData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var liquidacionesFiltradas = liquidaciones.Where(liquidacion => liquidacion.Id == id).ToList();
                if (liquidacionesFiltradas.Any())
                {
                    var ingresoFiltrado = liquidacionesFiltradas.First(); // Obtener el primer elemento de la lista
                    //encontrado = true;
                    dateFechaLiquidacion.Value = DateTime.Parse(FormatearFecha(ingresoFiltrado.Id));
                    textDineroIngreso.Text = ingresoFiltrado.Valor.ToString();
                    textDetalle.Text = ingresoFiltrado.Detalle;
                    tabLiquidaciones.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                BusquedaLiquidacionRespuesta respuesta = new BusquedaLiquidacionRespuesta();
                respuesta = liquidacionService.BuscarPorIdentificacion(id);
                var registro = respuesta.Liquidacion;
                if (registro != null)
                {
                    encontrado = true;
                    var liquidaciones = new List<Liquidacion> { registro };
                    dateFechaLiquidacion.Value = liquidaciones[0].FechaDeLiquidacion;
                    textDineroIngreso.Text = liquidaciones[0].Valor.ToString();
                    textDetalle.Text = liquidaciones[0].Detalle;
                }
            }
        }

        private void EliminarLiquidacion(string id)
        {
            try
            {
                //Elimina primero de firebase o la nube
                var db = FirebaseService.Database;
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("SettlementData").Document(id);
                docRef.DeleteAsync();
                string mensaje = liquidacionService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarLiquidaciones();
            }
            catch (Exception e)
            {
                string mensaje = liquidacionService.Eliminar(id);
                MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarLiquidaciones();
            }
        }
        private Liquidacion MapearLiquidacion(string estado)
        {
            liquidacion = new Liquidacion();
            liquidacion.GenerarCodigoLiquidacion();
            liquidacion.FechaDeLiquidacion = dateFechaLiquidacion.Value;
            string cantidadConSigno = textDineroIngreso.Text; // Esto contiene "$ 30000"
            string cantidadSinSigno = cantidadConSigno.Replace("$", "").Trim(); // Esto quita el signo "$"
            string cantidadSinPuntos = cantidadSinSigno.Replace(".", "").Trim();
            int cantidadEntera = int.Parse(cantidadSinPuntos); // Convierte el valor a un entero
            liquidacion.Valor = cantidadEntera;
            liquidacion.Detalle = textDetalle.Text;
            liquidacion.Estado = estado;
            return liquidacion;
        }
        private void Limpiar()
        {
            dateFechaLiquidacion.Value = DateTime.Now;
            textDineroIngreso.Text = "$ 000.00";
            textDetalle.Text = "Detalle";
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos del usuario y construimos el dato de la nube
            Liquidacion liquidacion = MapearLiquidacion("Pendiente por egreso");
            try
            {
                var msg = liquidacionService.Guardar(liquidacion);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var shippable = settlementMaps.ShippableMap(liquidacion);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("SettlementData").Document(shippable.Id);
                docRef.SetAsync(shippable);
                MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarLiquidaciones();
                Limpiar();
                tabLiquidaciones.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                int count = ex.Message.Length;
                if (count > 0)
                {
                    // Guardamos localmente
                    var msg = liquidacionService.Guardar(liquidacion);
                    MessageBox.Show(msg, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConsultarLiquidaciones();
                    Limpiar();
                    tabLiquidaciones.SelectedIndex = 0;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Liquidacion liquidacion = MapearLiquidacion("Pendiente por egreso");
            try
            {
                var msg = liquidacionService.Modificar(liquidacion);
                //Guardamos en la nube
                var db = FirebaseService.Database;
                var shippable = settlementMaps.ShippableMap(liquidacion);
                Google.Cloud.Firestore.DocumentReference docRef = db.Collection("SettlementData").Document(shippable.Id);
                docRef.SetAsync(shippable);
                MessageBox.Show(msg, "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultarLiquidaciones();
                Limpiar();
                tabLiquidaciones.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string mensaje = liquidacionService.Modificar(liquidacion);
                MessageBox.Show(mensaje, "Mensaje de registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ConsultarLiquidaciones();
                Limpiar();
                tabLiquidaciones.SelectedIndex = 0;
            }
        }
        private string ObtenerMes(string mes)
        {
            string mesEncontrado = "";
            // Diccionario que mapea nombres de meses a números
            Dictionary<string, int> meses = new Dictionary<string, int>
            {
                {"Enero", 1},
                {"Febrero", 2},
                {"Marzo", 3},
                {"Abril", 4},
                {"Mayo", 5},
                {"Junio", 6},
                {"Julio", 7},
                {"Agosto", 8},
                {"Septiembre", 9},
                {"Octubre", 10},
                {"Noviembre", 11},
                {"Diciembre", 12}
            };

            // Intentar obtener el número del mes del diccionario
            if (meses.TryGetValue(mes, out int numeroMes))
            {
                // Devolver el número del mes como cadena
                mesEncontrado = numeroMes.ToString("D2");
            }
            return mesEncontrado;
        }

        private async void FiltroPorFecha(string filtro)
        {
            int sumTotal = 0;
            string mes = ObtenerMes(filtro);
            try
            {
                var db = FirebaseService.Database;
                var settlementQuery = db.Collection("SettlementData");
                var settlements = new List<SettlementData>();
                // Realizar la suma directamente en la consulta Firestore
                var snapshot = await settlementQuery.GetSnapshotAsync();
                settlements = snapshot.Documents.Select(docsnap => docsnap.ConvertTo<SettlementData>()).ToList();
                // Filtrar elementos según el campo Valor y la variable id
                var settlementsFecha = settlements.Where(liquidacion =>
                   liquidacion.FechaDeLiquidacion.Contains("/" + mes + "/")
                ).ToList();
                sumTotal = settlementsFecha.Sum(liquidacion => liquidacion.Valor);
                textValorTotalMes.Text = LecturaCifra(sumTotal);
                dataGridLiquidacion.DataSource = settlementsFecha;
                Borrar.Visible = true;
            }
            catch (Exception ex)
            {
                ConsultaLiquidacionRespuesta respuesta = new ConsultaLiquidacionRespuesta();
                respuesta = liquidacionService.FiltrarLiquidacionPorFecha(filtro);
                if (respuesta.Liquidaciones.Count != 0 && respuesta.Liquidaciones != null)
                {
                    dataGridLiquidacion.DataSource = null;
                    liquidaciones = respuesta.Liquidaciones.ToList();
                    if (respuesta.Liquidaciones.Count != 0 && respuesta.Liquidaciones != null)
                    {
                        dataGridLiquidacion.DataSource = respuesta.Liquidaciones;
                        Borrar.Visible = true;
                    }
                }
                else
                {
                    dataGridLiquidacion.DataSource = null;
                    liquidaciones = respuesta.Liquidaciones.ToList();
                }
            }
        }

        private void comboFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboFecha.Text;
            if (filtro == "Todos" || filtro == "Año")
            {
                ConsultarLiquidaciones();
            }
            else
            {
                FiltroPorFecha(filtro);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
