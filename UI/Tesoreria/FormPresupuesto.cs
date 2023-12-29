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
        TabPage tabPage;
        string id = "";
        public FormPresupuesto()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPresupuesto_Load(object sender, EventArgs e)
        {
            if (tabPresupuestos.TabCount > 0)
            {
                tabPage = tabPresupuestos.TabPages["tabDetalle"];
                tabPresupuestos.TabPages.RemoveAt(2);
            }
        }

        private void dataGridPresupuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPresupuestos.DataSource != null)
            {
                if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Borrar")
                {
                    id = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                    EliminarIngreso(id);
                    ConsultarEgresos();
                }
                else
                {
                    if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Detallar")
                    {
                        comite = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["Comite"].Value.ToString());
                        FiltrarEgresosPorComite(comite);
                        tabEgresos.TabPages.Add(tabPage);
                        tabEgresos.SelectedIndex = 2;
                        detallo = true;
                    }
                    else
                    {
                        if (dataGridPresupuestos.Columns[e.ColumnIndex].Name == "Editar")
                        {
                            id = Convert.ToString(dataGridPresupuestos.CurrentRow.Cells["CodigoComprobante"].Value.ToString());
                            FiltroPorId(id);
                            if (encontrado == true)
                            {
                                tabEgresos.SelectedIndex = 1;
                            }
                        }
                    }
                }
            }
        }
    }
}
