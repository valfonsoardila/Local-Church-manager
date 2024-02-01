using BLL;
using Cloud;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormGenerarDocumento : Form
    {
        public string rolLogueado = "";
        Validaciones validaciones;
        IdUsuarioTxt usuarioTxt;
        List<IdUsuarioTxt> idUsuarioTxts;
        Reporte reporte;
        List<Miembro> miembros;
        public List<IngressData> ingress;
        public List<EgressData> egress;
        public List<MemberData> members;
        public List<DirectivesData> directives;
        public List<MeetingsData> meetings;
        public List<NotesData> notes;
        public List<SympathizerData> sympathizers;
        string opcionSeleccionada = "";
        string genero = "";
        public FormGenerarDocumento()
        {
            validaciones = new Validaciones();
            reporte = new Reporte();
            miembros = new List<Miembro>();
            InitializeComponent();
            ObtenerRol();
        }

        private void ObtenerRol()
        {
            IdUsuarioTxtService idUsuarioTxtService = new IdUsuarioTxtService();
            var idUsuarioTxts = idUsuarioTxtService.Consultar();
            rolLogueado = idUsuarioTxts.IdEmpleadoTxts[0].Rol;
            textRol.Text = rolLogueado;
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelHeaderGenerarInforme_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormGenerarDocumento_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormGenerarDocumento_Load(object sender, EventArgs e)
        {
            checkedListReportes.Items.Clear();
            if (textRol.Text == "Programador")
            {
                checkedListReportes.Items.AddRange(new string[]
                {
                    "Generar Informe de miembros",
                    "Generar actas de reunion",
                    "Generar Lista de directivas",
                    "Generar Lista de niños",
                    "Generar Lista de recientregados",
                    "Generar Lista de familias",
                    "Generar Lista de bautizados",
                    "Generar Lista de caballeros",
                    "Generar Lista de damas dorcas",
                    "Generar Informe General Tesoreria",
                    "Generar Informe Individual Tesoreria",
                    "Generar Informe Presupuestal Tesoreria"
                });
            }
            else
            {
                if(textRol.Text== "Secretario(a)")
                {
                    checkedListReportes.Items.AddRange(new string[]
                    {
                        "Generar Informe de miembros",
                        "Generar actas de reunion",
                        "Generar Lista de directivas",
                        "Generar Lista de niños",
                        "Generar Lista de recientregados",
                        "Generar Lista de familias",
                        "Generar Lista de bautizados",
                        "Generar Lista de caballeros",
                        "Generar Lista de damas dorcas",
                    });
                }
                else
                {
                    if (textRol.Text == "Tesorero(a)")
                    {
                        checkedListReportes.Items.AddRange(new string[]
                        {
                            "Generar Informe General Tesoreria",
                            "Generar Informe Individual Tesoreria",
                            "Generar Informe Presupuestal Tesoreria",
                        });
                    }
                }
            }
        }
        private void ValidarSeleccion()
        {
            if(opcionSeleccionada== "Generar Informe de miembros")
            {
                reporte.GenerarLibroDeMiembrosSecretaria(miembros);
            }
            else
            {
                if (opcionSeleccionada == "Generar actas de reunion")
                {
                    comboFiltroAño.Visible = true;
                    reporte.GenerarActasDeReunionesSecretaria();
                }
                else
                {
                    if (opcionSeleccionada == "Generar Lista de directivas")
                    {
                        comboFiltroAño.Visible = true;
                        reporte.GenerarListaServidoresActualesSecretaria();
                    }
                    else
                    {
                        if (opcionSeleccionada == "Generar Lista de niños")
                        {
                            reporte.GenerarListaDeNiñosSecretaria();
                        }
                        else
                        {
                            if(opcionSeleccionada=="Generar Lista de recientregados")
                            {
                                comboFiltroAño.Visible = true;
                                reporte.GenerarListasRecientregadosSecretaria();
                            }
                            else
                            {
                                if (opcionSeleccionada == "Generar Lista de familias")
                                {
                                    reporte.GenerarListaFamiliasSecretaria();
                                }
                                else
                                {
                                    if (opcionSeleccionada == "Generar Lista de bautizados")
                                    {
                                        reporte.GenerarListaDeBautizadosSecretaria();
                                    }
                                    else
                                    {
                                        if (opcionSeleccionada == "Generar Lista de caballeros")
                                        {
                                            comboFiltroAño.Visible = true;
                                            genero = "Masculino";
                                            reporte.GenerarListaPorGeneroSecretaria(genero);
                                        }
                                        else
                                        {
                                            if (opcionSeleccionada == "Generar Lista de damas dorcas")
                                            {
                                                comboFiltroAño.Visible = true;
                                                genero = "Femenino";
                                                reporte.GenerarListaPorGeneroSecretaria(genero);
                                            }
                                            else
                                            {
                                                if (opcionSeleccionada == "Generar Informe General Tesoreria")
                                                {
                                                    comboFiltroAño.Visible = true;
                                                    reporte.egress = egress;
                                                    reporte.ingress = ingress;
                                                    reporte.GenerarInformeGeneralTesoreria();
                                                }
                                                else
                                                {
                                                    if (opcionSeleccionada == "Generar Informe Individual Tesoreria")
                                                    {
                                                        comboFiltroAño.Visible = true;
                                                        reporte.egress = egress;
                                                        reporte.ingress = ingress;
                                                        reporte.GenerarInformeIndividualTesoreria();
                                                    }
                                                    else
                                                    {
                                                        if(opcionSeleccionada== "Generar Informe Presupuestal Tesoreria")
                                                        {
                                                            comboFiltroAño.Visible = true;
                                                            reporte.egress = egress;
                                                            reporte.ingress = ingress;
                                                            reporte.GenerarInformePresupuestalTesoreria();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnAbrirInforme_Click(object sender, EventArgs e)
        {
            ValidarSeleccion();
        }
        private void btnEliminarInforme_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirInforme_Click(object sender, EventArgs e)
        {

        }
        private void textBuscar_Enter(object sender, EventArgs e)
        {
            string placeHolder = textBuscar.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textBuscar.Text = validaciones.TextoPlaceHolderEnter(placeHolder, nombreDelComponente);
        }

        private void textBuscar_Leave(object sender, EventArgs e)
        {
            string placeHolder = textBuscar.Text;
            string nombreDelComponente = ((System.Windows.Forms.Control)sender).Name;
            textBuscar.Text = validaciones.TextoPlaceHolderLeave(placeHolder, nombreDelComponente);
        }
        private void checkedListReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay algún elemento seleccionado
            if (checkedListReportes.CheckedItems.Count > 0)
            {
                // Obtener el valor del elemento seleccionado (el último seleccionado)
                opcionSeleccionada = checkedListReportes.CheckedItems[0].ToString();
            }
            else
            {
                // No hay elementos seleccionados, puedes manejar esto según tus necesidades
                opcionSeleccionada = null;
                // Realizar acciones adicionales o mostrar mensajes, si es necesario
            }
        }


        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            if(textBuscar.Text!="Buscar" && textBuscar.Text != "")
            {
                FiltrarListaReportes(textBuscar.Text);
            }
        }
        private void FiltrarListaReportes(string filtro)
        {
            checkedListReportes.Items.Clear();

            if (string.IsNullOrEmpty(filtro) || filtro.ToLower() == "buscar")
            {
                // Restaurar la lista completa si el filtro está vacío o es "Buscar"
                if (textRol.Text == "Programador")
                {
                    checkedListReportes.Items.AddRange(new string[]
                    {
                        "Generar Informe de miembros",
                        "Generar actas de reunion",
                        "Generar Lista de directivas",
                        "Generar Lista de niños",
                        "Generar Lista de recientregados",
                        "Generar Lista de familias",
                        "Generar Lista de bautizados",
                        "Generar Lista de caballeros",
                        "Generar Lista de damas dorcas",
                        "Generar Informe General Tesoreria",
                        "Generar Informe Individual Tesoreria",
                        "Generar Informe Presupuestal Tesoreria"
                    });
                }
                else if (textRol.Text == "Secretario(a)")
                {
                    checkedListReportes.Items.AddRange(new string[]
                    {
                        "Generar Informe de miembros",
                        "Generar actas de reunion",
                        "Generar Lista de directivas",
                        "Generar Lista de niños",
                        "Generar Lista de recientregados",
                        "Generar Lista de familias",
                        "Generar Lista de bautizados",
                        "Generar Lista de caballeros",
                        "Generar Lista de damas dorcas",
                    });
                }
                else if (textRol.Text == "Tesorero(a)")
                {
                    checkedListReportes.Items.AddRange(new string[]
                    {
                "Generar Informe General Tesoreria",
                "Generar Informe Individual Tesoreria",
                "Generar Informe Presupuestal Tesoreria",
                    });
                }
            }
            else
            {
                // Filtrar la lista según el texto ingresado
                var itemsFiltrados = ObtenerItemsFiltrados(filtro);
                checkedListReportes.Items.AddRange(itemsFiltrados.ToArray());
            }
        }

        private List<string> ObtenerItemsFiltrados(string filtro)
        {
            var itemsFiltrados = new List<string>();

            if (textRol.Text == "Programador")
            {
                itemsFiltrados.AddRange(new string[]
                {
                    "Generar Informe de miembros",
                    "Generar actas de reunion",
                    "Generar Lista de directivas",
                    "Generar Lista de niños",
                    "Generar Lista de recientregados",
                    "Generar Lista de familias",
                    "Generar Lista de bautizados",
                    "Generar Lista de caballeros",
                    "Generar Lista de damas dorcas",
                    "Generar Informe General Tesoreria",
                    "Generar Informe Individual Tesoreria",
                    "Generar Informe Presupuestal Tesoreria"
                }.Where(item => item.ToLower().Contains(filtro.ToLower())));
            }
            else if (textRol.Text == "Secretario(a)")
            {
                itemsFiltrados.AddRange(new string[]
                {
                    "Generar Informe de miembros",
                    "Generar actas de reunion",
                    "Generar Lista de directivas",
                    "Generar Lista de niños",
                    "Generar Lista de recientregados",
                    "Generar Lista de familias",
                    "Generar Lista de bautizados",
                    "Generar Lista de caballeros",
                    "Generar Lista de damas dorcas",
                }.Where(item => item.ToLower().Contains(filtro.ToLower())));
            }
            else if (textRol.Text == "Tesorero(a)")
            {
                itemsFiltrados.AddRange(new string[]
                {
            "Generar Informe General Tesoreria",
            "Generar Informe Individual Tesoreria",
            "Generar Informe Presupuestal Tesoreria",
                }.Where(item => item.ToLower().Contains(filtro.ToLower())));
            }

            return itemsFiltrados;
        }
    }
}
