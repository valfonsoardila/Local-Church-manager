
namespace UI
{
    partial class FormMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.panelHeaderbar = new System.Windows.Forms.Panel();
            this.btnWindowMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.btnWindowRestore = new FontAwesome.Sharp.IconPictureBox();
            this.btnWindowCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnWindowMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSelectionSalir = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.panelSelectionBD = new System.Windows.Forms.Panel();
            this.panelSelectionAjustes = new System.Windows.Forms.Panel();
            this.btnAjustes = new FontAwesome.Sharp.IconButton();
            this.btnGestionBD = new FontAwesome.Sharp.IconButton();
            this.panelSelectionTesoreria = new System.Windows.Forms.Panel();
            this.panelSelectionSecretaria = new System.Windows.Forms.Panel();
            this.subMenuTesoreria = new System.Windows.Forms.Panel();
            this.btnEnviables = new FontAwesome.Sharp.IconButton();
            this.btnLiquidaciones = new FontAwesome.Sharp.IconButton();
            this.btnEgresos = new FontAwesome.Sharp.IconButton();
            this.btnIngresos = new FontAwesome.Sharp.IconButton();
            this.btnPrsupuestos = new FontAwesome.Sharp.IconButton();
            this.btnGestionTesoreria = new FontAwesome.Sharp.IconButton();
            this.subMenuSecretaria = new System.Windows.Forms.Panel();
            this.btnApuntes = new FontAwesome.Sharp.IconButton();
            this.btnReuniones = new FontAwesome.Sharp.IconButton();
            this.btnDirectivas = new FontAwesome.Sharp.IconButton();
            this.btnMiembros = new FontAwesome.Sharp.IconButton();
            this.btnDirectorio = new FontAwesome.Sharp.IconButton();
            this.btnGestionSecretaria = new FontAwesome.Sharp.IconButton();
            this.panelLogoContainer = new System.Windows.Forms.Panel();
            this.panelSidebarClose = new System.Windows.Forms.Panel();
            this.labelMenu = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpenSidebar = new FontAwesome.Sharp.IconPictureBox();
            this.btnCloseSidebar = new FontAwesome.Sharp.IconPictureBox();
            this.labelLogoName = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelContenedorInterno = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.iconNube = new FontAwesome.Sharp.IconPictureBox();
            this.labelEstadoNube = new System.Windows.Forms.Label();
            this.textTiempoLicencia = new System.Windows.Forms.TextBox();
            this.labelTiempoLicencia = new System.Windows.Forms.Label();
            this.btnVerLicencia = new FontAwesome.Sharp.IconButton();
            this.labelHeaderRuta = new System.Windows.Forms.Label();
            this.iconThemeSun = new FontAwesome.Sharp.IconPictureBox();
            this.iconThemeMoon = new FontAwesome.Sharp.IconPictureBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.btnModeLight = new FontAwesome.Sharp.IconPictureBox();
            this.btnModeDark = new FontAwesome.Sharp.IconPictureBox();
            this.panelHeaderbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowMinimize)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.subMenuTesoreria.SuspendLayout();
            this.subMenuSecretaria.SuspendLayout();
            this.panelLogoContainer.SuspendLayout();
            this.panelSidebarClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenSidebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSidebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconThemeSun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconThemeMoon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModeLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModeDark)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeaderbar
            // 
            this.panelHeaderbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.panelHeaderbar.Controls.Add(this.btnWindowMaximize);
            this.panelHeaderbar.Controls.Add(this.btnWindowRestore);
            this.panelHeaderbar.Controls.Add(this.btnWindowCerrar);
            this.panelHeaderbar.Controls.Add(this.btnWindowMinimize);
            this.panelHeaderbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderbar.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderbar.Name = "panelHeaderbar";
            this.panelHeaderbar.Size = new System.Drawing.Size(1182, 27);
            this.panelHeaderbar.TabIndex = 2;
            this.panelHeaderbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeaderbar_MouseDown);
            // 
            // btnWindowMaximize
            // 
            this.btnWindowMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnWindowMaximize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnWindowMaximize.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWindowMaximize.IconSize = 20;
            this.btnWindowMaximize.Location = new System.Drawing.Point(1130, 4);
            this.btnWindowMaximize.Name = "btnWindowMaximize";
            this.btnWindowMaximize.Size = new System.Drawing.Size(20, 20);
            this.btnWindowMaximize.TabIndex = 4;
            this.btnWindowMaximize.TabStop = false;
            this.btnWindowMaximize.Click += new System.EventHandler(this.btnWindowMaximize_Click);
            // 
            // btnWindowRestore
            // 
            this.btnWindowRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnWindowRestore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowRestore.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.btnWindowRestore.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWindowRestore.IconSize = 20;
            this.btnWindowRestore.Location = new System.Drawing.Point(1130, 4);
            this.btnWindowRestore.Name = "btnWindowRestore";
            this.btnWindowRestore.Size = new System.Drawing.Size(20, 20);
            this.btnWindowRestore.TabIndex = 5;
            this.btnWindowRestore.TabStop = false;
            this.btnWindowRestore.Click += new System.EventHandler(this.btnWindowRestore_Click);
            // 
            // btnWindowCerrar
            // 
            this.btnWindowCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnWindowCerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowCerrar.IconChar = FontAwesome.Sharp.IconChar.TimesSquare;
            this.btnWindowCerrar.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWindowCerrar.IconSize = 20;
            this.btnWindowCerrar.Location = new System.Drawing.Point(1153, 4);
            this.btnWindowCerrar.Name = "btnWindowCerrar";
            this.btnWindowCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnWindowCerrar.TabIndex = 3;
            this.btnWindowCerrar.TabStop = false;
            this.btnWindowCerrar.Click += new System.EventHandler(this.btnWindowCerrar_Click);
            // 
            // btnWindowMinimize
            // 
            this.btnWindowMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnWindowMinimize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnWindowMinimize.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWindowMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWindowMinimize.IconSize = 20;
            this.btnWindowMinimize.Location = new System.Drawing.Point(1107, 4);
            this.btnWindowMinimize.Name = "btnWindowMinimize";
            this.btnWindowMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnWindowMinimize.TabIndex = 1;
            this.btnWindowMinimize.TabStop = false;
            this.btnWindowMinimize.Click += new System.EventHandler(this.btnWindowMinimize_Click);
            // 
            // panelSidebar
            // 
            this.panelSidebar.AutoScroll = true;
            this.panelSidebar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelSidebar.Controls.Add(this.panelSelectionSalir);
            this.panelSidebar.Controls.Add(this.btnCerrarSesion);
            this.panelSidebar.Controls.Add(this.panelSelectionBD);
            this.panelSidebar.Controls.Add(this.panelSelectionAjustes);
            this.panelSidebar.Controls.Add(this.btnAjustes);
            this.panelSidebar.Controls.Add(this.btnGestionBD);
            this.panelSidebar.Controls.Add(this.panelSelectionTesoreria);
            this.panelSidebar.Controls.Add(this.panelSelectionSecretaria);
            this.panelSidebar.Controls.Add(this.subMenuTesoreria);
            this.panelSidebar.Controls.Add(this.btnGestionTesoreria);
            this.panelSidebar.Controls.Add(this.subMenuSecretaria);
            this.panelSidebar.Controls.Add(this.btnGestionSecretaria);
            this.panelSidebar.Controls.Add(this.panelLogoContainer);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 27);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(186, 577);
            this.panelSidebar.TabIndex = 3;
            this.panelSidebar.MouseEnter += new System.EventHandler(this.panelSidebar_MouseEnter);
            // 
            // panelSelectionSalir
            // 
            this.panelSelectionSalir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSelectionSalir.Location = new System.Drawing.Point(0, 616);
            this.panelSelectionSalir.Name = "panelSelectionSalir";
            this.panelSelectionSalir.Size = new System.Drawing.Size(6, 37);
            this.panelSelectionSalir.TabIndex = 16;
            this.panelSelectionSalir.Visible = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(95)))), ((int)(((byte)(195)))));
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.White;
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarSesion.IconSize = 22;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 617);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Rotation = 180D;
            this.btnCerrarSesion.Size = new System.Drawing.Size(169, 37);
            this.btnCerrarSesion.TabIndex = 15;
            this.btnCerrarSesion.Text = "   Cerrar sesion";
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelSelectionBD
            // 
            this.panelSelectionBD.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSelectionBD.Location = new System.Drawing.Point(0, 543);
            this.panelSelectionBD.Name = "panelSelectionBD";
            this.panelSelectionBD.Size = new System.Drawing.Size(6, 37);
            this.panelSelectionBD.TabIndex = 11;
            this.panelSelectionBD.Visible = false;
            // 
            // panelSelectionAjustes
            // 
            this.panelSelectionAjustes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSelectionAjustes.Location = new System.Drawing.Point(0, 579);
            this.panelSelectionAjustes.Name = "panelSelectionAjustes";
            this.panelSelectionAjustes.Size = new System.Drawing.Size(6, 37);
            this.panelSelectionAjustes.TabIndex = 10;
            this.panelSelectionAjustes.Visible = false;
            // 
            // btnAjustes
            // 
            this.btnAjustes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnAjustes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAjustes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(95)))), ((int)(((byte)(195)))));
            this.btnAjustes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnAjustes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.btnAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAjustes.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnAjustes.IconColor = System.Drawing.Color.White;
            this.btnAjustes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAjustes.IconSize = 22;
            this.btnAjustes.Location = new System.Drawing.Point(0, 580);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(169, 37);
            this.btnAjustes.TabIndex = 14;
            this.btnAjustes.Text = "   Ajustes";
            this.btnAjustes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAjustes.UseVisualStyleBackColor = false;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            this.btnAjustes.MouseEnter += new System.EventHandler(this.btnAjustes_MouseEnter);
            // 
            // btnGestionBD
            // 
            this.btnGestionBD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnGestionBD.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionBD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(95)))), ((int)(((byte)(195)))));
            this.btnGestionBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGestionBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.btnGestionBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionBD.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGestionBD.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnGestionBD.IconColor = System.Drawing.Color.White;
            this.btnGestionBD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGestionBD.IconSize = 22;
            this.btnGestionBD.Location = new System.Drawing.Point(0, 543);
            this.btnGestionBD.Name = "btnGestionBD";
            this.btnGestionBD.Size = new System.Drawing.Size(169, 37);
            this.btnGestionBD.TabIndex = 16;
            this.btnGestionBD.Text = "   Gestion de BD";
            this.btnGestionBD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGestionBD.UseVisualStyleBackColor = false;
            this.btnGestionBD.Visible = false;
            this.btnGestionBD.Click += new System.EventHandler(this.btnGestionBD_Click);
            // 
            // panelSelectionTesoreria
            // 
            this.panelSelectionTesoreria.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSelectionTesoreria.Location = new System.Drawing.Point(0, 317);
            this.panelSelectionTesoreria.Name = "panelSelectionTesoreria";
            this.panelSelectionTesoreria.Size = new System.Drawing.Size(6, 37);
            this.panelSelectionTesoreria.TabIndex = 8;
            this.panelSelectionTesoreria.Visible = false;
            // 
            // panelSelectionSecretaria
            // 
            this.panelSelectionSecretaria.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSelectionSecretaria.Location = new System.Drawing.Point(0, 95);
            this.panelSelectionSecretaria.Name = "panelSelectionSecretaria";
            this.panelSelectionSecretaria.Size = new System.Drawing.Size(6, 37);
            this.panelSelectionSecretaria.TabIndex = 0;
            this.panelSelectionSecretaria.Visible = false;
            // 
            // subMenuTesoreria
            // 
            this.subMenuTesoreria.BackColor = System.Drawing.SystemColors.ControlLight;
            this.subMenuTesoreria.Controls.Add(this.btnEnviables);
            this.subMenuTesoreria.Controls.Add(this.btnLiquidaciones);
            this.subMenuTesoreria.Controls.Add(this.btnEgresos);
            this.subMenuTesoreria.Controls.Add(this.btnIngresos);
            this.subMenuTesoreria.Controls.Add(this.btnPrsupuestos);
            this.subMenuTesoreria.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuTesoreria.Location = new System.Drawing.Point(0, 353);
            this.subMenuTesoreria.Name = "subMenuTesoreria";
            this.subMenuTesoreria.Size = new System.Drawing.Size(169, 190);
            this.subMenuTesoreria.TabIndex = 10;
            // 
            // btnEnviables
            // 
            this.btnEnviables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnEnviables.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnviables.FlatAppearance.BorderSize = 0;
            this.btnEnviables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEnviables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnEnviables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviables.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnviables.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnEnviables.IconColor = System.Drawing.Color.White;
            this.btnEnviables.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviables.IconSize = 10;
            this.btnEnviables.Location = new System.Drawing.Point(0, 154);
            this.btnEnviables.Name = "btnEnviables";
            this.btnEnviables.Size = new System.Drawing.Size(169, 39);
            this.btnEnviables.TabIndex = 15;
            this.btnEnviables.Text = "Enviables";
            this.btnEnviables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviables.UseVisualStyleBackColor = false;
            this.btnEnviables.Click += new System.EventHandler(this.btnEnviables_Click);
            // 
            // btnLiquidaciones
            // 
            this.btnLiquidaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnLiquidaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLiquidaciones.FlatAppearance.BorderSize = 0;
            this.btnLiquidaciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnLiquidaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnLiquidaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiquidaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiquidaciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLiquidaciones.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnLiquidaciones.IconColor = System.Drawing.Color.White;
            this.btnLiquidaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLiquidaciones.IconSize = 10;
            this.btnLiquidaciones.Location = new System.Drawing.Point(0, 115);
            this.btnLiquidaciones.Name = "btnLiquidaciones";
            this.btnLiquidaciones.Size = new System.Drawing.Size(169, 39);
            this.btnLiquidaciones.TabIndex = 14;
            this.btnLiquidaciones.Text = "Liquidaciones";
            this.btnLiquidaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLiquidaciones.UseVisualStyleBackColor = false;
            this.btnLiquidaciones.Click += new System.EventHandler(this.btnLiquidaciones_Click);
            // 
            // btnEgresos
            // 
            this.btnEgresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnEgresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEgresos.FlatAppearance.BorderSize = 0;
            this.btnEgresos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEgresos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnEgresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgresos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEgresos.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnEgresos.IconColor = System.Drawing.Color.White;
            this.btnEgresos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEgresos.IconSize = 10;
            this.btnEgresos.Location = new System.Drawing.Point(0, 76);
            this.btnEgresos.Name = "btnEgresos";
            this.btnEgresos.Size = new System.Drawing.Size(169, 39);
            this.btnEgresos.TabIndex = 13;
            this.btnEgresos.Text = "Egresos";
            this.btnEgresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEgresos.UseVisualStyleBackColor = false;
            this.btnEgresos.Click += new System.EventHandler(this.btnEgresos_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresos.FlatAppearance.BorderSize = 0;
            this.btnIngresos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnIngresos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIngresos.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnIngresos.IconColor = System.Drawing.Color.White;
            this.btnIngresos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresos.IconSize = 10;
            this.btnIngresos.Location = new System.Drawing.Point(0, 39);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(169, 37);
            this.btnIngresos.TabIndex = 12;
            this.btnIngresos.Text = "Ingresos";
            this.btnIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresos.UseVisualStyleBackColor = false;
            this.btnIngresos.Click += new System.EventHandler(this.btnIngresos_Click);
            // 
            // btnPrsupuestos
            // 
            this.btnPrsupuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnPrsupuestos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrsupuestos.FlatAppearance.BorderSize = 0;
            this.btnPrsupuestos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnPrsupuestos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnPrsupuestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrsupuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrsupuestos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrsupuestos.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnPrsupuestos.IconColor = System.Drawing.Color.White;
            this.btnPrsupuestos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrsupuestos.IconSize = 10;
            this.btnPrsupuestos.Location = new System.Drawing.Point(0, 0);
            this.btnPrsupuestos.Name = "btnPrsupuestos";
            this.btnPrsupuestos.Size = new System.Drawing.Size(169, 39);
            this.btnPrsupuestos.TabIndex = 11;
            this.btnPrsupuestos.Text = "Presupuestos";
            this.btnPrsupuestos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrsupuestos.UseVisualStyleBackColor = false;
            this.btnPrsupuestos.Click += new System.EventHandler(this.btnPrsupuestos_Click);
            // 
            // btnGestionTesoreria
            // 
            this.btnGestionTesoreria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnGestionTesoreria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionTesoreria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(95)))), ((int)(((byte)(195)))));
            this.btnGestionTesoreria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGestionTesoreria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.btnGestionTesoreria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionTesoreria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionTesoreria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGestionTesoreria.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTrendUp;
            this.btnGestionTesoreria.IconColor = System.Drawing.Color.White;
            this.btnGestionTesoreria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGestionTesoreria.IconSize = 22;
            this.btnGestionTesoreria.Location = new System.Drawing.Point(0, 316);
            this.btnGestionTesoreria.Name = "btnGestionTesoreria";
            this.btnGestionTesoreria.Size = new System.Drawing.Size(169, 37);
            this.btnGestionTesoreria.TabIndex = 9;
            this.btnGestionTesoreria.Text = "   Gestion de tesoreria";
            this.btnGestionTesoreria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGestionTesoreria.UseVisualStyleBackColor = false;
            this.btnGestionTesoreria.Visible = false;
            this.btnGestionTesoreria.Click += new System.EventHandler(this.btnGestionTesoreria_Click);
            // 
            // subMenuSecretaria
            // 
            this.subMenuSecretaria.Controls.Add(this.btnApuntes);
            this.subMenuSecretaria.Controls.Add(this.btnReuniones);
            this.subMenuSecretaria.Controls.Add(this.btnDirectivas);
            this.subMenuSecretaria.Controls.Add(this.btnMiembros);
            this.subMenuSecretaria.Controls.Add(this.btnDirectorio);
            this.subMenuSecretaria.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuSecretaria.Location = new System.Drawing.Point(0, 131);
            this.subMenuSecretaria.Name = "subMenuSecretaria";
            this.subMenuSecretaria.Size = new System.Drawing.Size(169, 185);
            this.subMenuSecretaria.TabIndex = 3;
            // 
            // btnApuntes
            // 
            this.btnApuntes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnApuntes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApuntes.FlatAppearance.BorderSize = 0;
            this.btnApuntes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnApuntes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnApuntes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApuntes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApuntes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnApuntes.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnApuntes.IconColor = System.Drawing.Color.White;
            this.btnApuntes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnApuntes.IconSize = 10;
            this.btnApuntes.Location = new System.Drawing.Point(0, 148);
            this.btnApuntes.Name = "btnApuntes";
            this.btnApuntes.Size = new System.Drawing.Size(169, 37);
            this.btnApuntes.TabIndex = 8;
            this.btnApuntes.Text = "Apuntes";
            this.btnApuntes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApuntes.UseVisualStyleBackColor = false;
            this.btnApuntes.Click += new System.EventHandler(this.btnApuntes_Click);
            this.btnApuntes.MouseEnter += new System.EventHandler(this.btnApuntes_MouseEnter);
            // 
            // btnReuniones
            // 
            this.btnReuniones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnReuniones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReuniones.FlatAppearance.BorderSize = 0;
            this.btnReuniones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnReuniones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnReuniones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReuniones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReuniones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReuniones.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnReuniones.IconColor = System.Drawing.Color.White;
            this.btnReuniones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReuniones.IconSize = 10;
            this.btnReuniones.Location = new System.Drawing.Point(0, 111);
            this.btnReuniones.Name = "btnReuniones";
            this.btnReuniones.Size = new System.Drawing.Size(169, 37);
            this.btnReuniones.TabIndex = 7;
            this.btnReuniones.Text = "Reuniones";
            this.btnReuniones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReuniones.UseVisualStyleBackColor = false;
            this.btnReuniones.Click += new System.EventHandler(this.btnReuniones_Click);
            this.btnReuniones.MouseEnter += new System.EventHandler(this.btnReuniones_MouseEnter);
            // 
            // btnDirectivas
            // 
            this.btnDirectivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnDirectivas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDirectivas.FlatAppearance.BorderSize = 0;
            this.btnDirectivas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDirectivas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnDirectivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirectivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectivas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDirectivas.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnDirectivas.IconColor = System.Drawing.Color.White;
            this.btnDirectivas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDirectivas.IconSize = 10;
            this.btnDirectivas.Location = new System.Drawing.Point(0, 74);
            this.btnDirectivas.Name = "btnDirectivas";
            this.btnDirectivas.Size = new System.Drawing.Size(169, 37);
            this.btnDirectivas.TabIndex = 6;
            this.btnDirectivas.Text = "Directivas";
            this.btnDirectivas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDirectivas.UseVisualStyleBackColor = false;
            this.btnDirectivas.Click += new System.EventHandler(this.btnDirectivas_Click);
            this.btnDirectivas.MouseEnter += new System.EventHandler(this.btnDirectivas_MouseEnter);
            // 
            // btnMiembros
            // 
            this.btnMiembros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnMiembros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMiembros.FlatAppearance.BorderSize = 0;
            this.btnMiembros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnMiembros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnMiembros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiembros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMiembros.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnMiembros.IconColor = System.Drawing.Color.White;
            this.btnMiembros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMiembros.IconSize = 10;
            this.btnMiembros.Location = new System.Drawing.Point(0, 37);
            this.btnMiembros.Name = "btnMiembros";
            this.btnMiembros.Size = new System.Drawing.Size(169, 37);
            this.btnMiembros.TabIndex = 5;
            this.btnMiembros.Text = "Miembros";
            this.btnMiembros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMiembros.UseVisualStyleBackColor = false;
            this.btnMiembros.Click += new System.EventHandler(this.btnMiembros_Click);
            this.btnMiembros.MouseEnter += new System.EventHandler(this.btnMiembros_MouseEnter);
            // 
            // btnDirectorio
            // 
            this.btnDirectorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnDirectorio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDirectorio.FlatAppearance.BorderSize = 0;
            this.btnDirectorio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDirectorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnDirectorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirectorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectorio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDirectorio.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnDirectorio.IconColor = System.Drawing.Color.White;
            this.btnDirectorio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDirectorio.IconSize = 10;
            this.btnDirectorio.Location = new System.Drawing.Point(0, 0);
            this.btnDirectorio.Name = "btnDirectorio";
            this.btnDirectorio.Size = new System.Drawing.Size(169, 37);
            this.btnDirectorio.TabIndex = 4;
            this.btnDirectorio.Text = "Directorio";
            this.btnDirectorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDirectorio.UseVisualStyleBackColor = false;
            this.btnDirectorio.Click += new System.EventHandler(this.btnDirectorio_Click);
            this.btnDirectorio.MouseEnter += new System.EventHandler(this.btnDirectorio_MouseEnter);
            // 
            // btnGestionSecretaria
            // 
            this.btnGestionSecretaria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnGestionSecretaria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionSecretaria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(95)))), ((int)(((byte)(195)))));
            this.btnGestionSecretaria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGestionSecretaria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.btnGestionSecretaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionSecretaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionSecretaria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGestionSecretaria.IconChar = FontAwesome.Sharp.IconChar.Readme;
            this.btnGestionSecretaria.IconColor = System.Drawing.Color.White;
            this.btnGestionSecretaria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGestionSecretaria.IconSize = 22;
            this.btnGestionSecretaria.Location = new System.Drawing.Point(0, 94);
            this.btnGestionSecretaria.Name = "btnGestionSecretaria";
            this.btnGestionSecretaria.Size = new System.Drawing.Size(169, 37);
            this.btnGestionSecretaria.TabIndex = 2;
            this.btnGestionSecretaria.Text = "   Gestion de secretaría";
            this.btnGestionSecretaria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGestionSecretaria.UseVisualStyleBackColor = false;
            this.btnGestionSecretaria.Click += new System.EventHandler(this.btnGestionSecretaria_Click);
            this.btnGestionSecretaria.MouseEnter += new System.EventHandler(this.btnGestionSecretaria_MouseEnter);
            // 
            // panelLogoContainer
            // 
            this.panelLogoContainer.AutoSize = true;
            this.panelLogoContainer.Controls.Add(this.panelSidebarClose);
            this.panelLogoContainer.Controls.Add(this.btnOpenSidebar);
            this.panelLogoContainer.Controls.Add(this.btnCloseSidebar);
            this.panelLogoContainer.Controls.Add(this.labelLogoName);
            this.panelLogoContainer.Controls.Add(this.pictureLogo);
            this.panelLogoContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogoContainer.Location = new System.Drawing.Point(0, 0);
            this.panelLogoContainer.Name = "panelLogoContainer";
            this.panelLogoContainer.Size = new System.Drawing.Size(169, 94);
            this.panelLogoContainer.TabIndex = 0;
            this.panelLogoContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLogoContainer_MouseDown);
            this.panelLogoContainer.MouseEnter += new System.EventHandler(this.panelLogoContainer_MouseEnter);
            // 
            // panelSidebarClose
            // 
            this.panelSidebarClose.Controls.Add(this.labelMenu);
            this.panelSidebarClose.Controls.Add(this.pictureBox1);
            this.panelSidebarClose.Location = new System.Drawing.Point(0, 31);
            this.panelSidebarClose.Name = "panelSidebarClose";
            this.panelSidebarClose.Size = new System.Drawing.Size(52, 60);
            this.panelSidebarClose.TabIndex = 6;
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenu.Location = new System.Drawing.Point(3, 47);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(38, 13);
            this.labelMenu.TabIndex = 7;
            this.labelMenu.Text = "Menu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpenSidebar
            // 
            this.btnOpenSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSidebar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOpenSidebar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnOpenSidebar.IconChar = FontAwesome.Sharp.IconChar.CircleChevronRight;
            this.btnOpenSidebar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnOpenSidebar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOpenSidebar.IconSize = 30;
            this.btnOpenSidebar.Location = new System.Drawing.Point(135, 3);
            this.btnOpenSidebar.Name = "btnOpenSidebar";
            this.btnOpenSidebar.Size = new System.Drawing.Size(31, 30);
            this.btnOpenSidebar.TabIndex = 5;
            this.btnOpenSidebar.TabStop = false;
            this.btnOpenSidebar.Click += new System.EventHandler(this.btnOpenSidebar_Click);
            // 
            // btnCloseSidebar
            // 
            this.btnCloseSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseSidebar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCloseSidebar.ForeColor = System.Drawing.Color.Black;
            this.btnCloseSidebar.IconChar = FontAwesome.Sharp.IconChar.CircleChevronLeft;
            this.btnCloseSidebar.IconColor = System.Drawing.Color.Black;
            this.btnCloseSidebar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCloseSidebar.IconSize = 30;
            this.btnCloseSidebar.Location = new System.Drawing.Point(135, 3);
            this.btnCloseSidebar.Name = "btnCloseSidebar";
            this.btnCloseSidebar.Size = new System.Drawing.Size(31, 30);
            this.btnCloseSidebar.TabIndex = 4;
            this.btnCloseSidebar.TabStop = false;
            this.btnCloseSidebar.Click += new System.EventHandler(this.btnCloseSidebar_Click);
            // 
            // labelLogoName
            // 
            this.labelLogoName.AutoSize = true;
            this.labelLogoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogoName.Location = new System.Drawing.Point(12, 78);
            this.labelLogoName.Name = "labelLogoName";
            this.labelLogoName.Size = new System.Drawing.Size(164, 16);
            this.labelLogoName.TabIndex = 1;
            this.labelLogoName.Text = "Gestor de iglesia local";
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = global::UI.Properties.Resources.logo;
            this.pictureLogo.Location = new System.Drawing.Point(33, 6);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(95, 69);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // panelContenedorInterno
            // 
            this.panelContenedorInterno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedorInterno.Location = new System.Drawing.Point(186, 52);
            this.panelContenedorInterno.Name = "panelContenedorInterno";
            this.panelContenedorInterno.Size = new System.Drawing.Size(996, 552);
            this.panelContenedorInterno.TabIndex = 6;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.iconNube);
            this.panelHeader.Controls.Add(this.labelEstadoNube);
            this.panelHeader.Controls.Add(this.textTiempoLicencia);
            this.panelHeader.Controls.Add(this.labelTiempoLicencia);
            this.panelHeader.Controls.Add(this.btnVerLicencia);
            this.panelHeader.Controls.Add(this.labelHeaderRuta);
            this.panelHeader.Controls.Add(this.iconThemeSun);
            this.panelHeader.Controls.Add(this.iconThemeMoon);
            this.panelHeader.Controls.Add(this.labelTheme);
            this.panelHeader.Controls.Add(this.btnModeLight);
            this.panelHeader.Controls.Add(this.btnModeDark);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(186, 27);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(996, 25);
            this.panelHeader.TabIndex = 5;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            // 
            // iconNube
            // 
            this.iconNube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconNube.BackColor = System.Drawing.SystemColors.Control;
            this.iconNube.ForeColor = System.Drawing.Color.Green;
            this.iconNube.IconChar = FontAwesome.Sharp.IconChar.Skyatlas;
            this.iconNube.IconColor = System.Drawing.Color.Green;
            this.iconNube.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNube.IconSize = 24;
            this.iconNube.Location = new System.Drawing.Point(713, 0);
            this.iconNube.Name = "iconNube";
            this.iconNube.Size = new System.Drawing.Size(24, 25);
            this.iconNube.TabIndex = 56;
            this.iconNube.TabStop = false;
            // 
            // labelEstadoNube
            // 
            this.labelEstadoNube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstadoNube.AutoSize = true;
            this.labelEstadoNube.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelEstadoNube.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoNube.ForeColor = System.Drawing.Color.Green;
            this.labelEstadoNube.Location = new System.Drawing.Point(740, 3);
            this.labelEstadoNube.Name = "labelEstadoNube";
            this.labelEstadoNube.Size = new System.Drawing.Size(134, 20);
            this.labelEstadoNube.TabIndex = 55;
            this.labelEstadoNube.Text = "Nube habilitada";
            // 
            // textTiempoLicencia
            // 
            this.textTiempoLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTiempoLicencia.Location = new System.Drawing.Point(663, 3);
            this.textTiempoLicencia.Name = "textTiempoLicencia";
            this.textTiempoLicencia.Size = new System.Drawing.Size(35, 20);
            this.textTiempoLicencia.TabIndex = 54;
            this.textTiempoLicencia.Visible = false;
            // 
            // labelTiempoLicencia
            // 
            this.labelTiempoLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTiempoLicencia.AutoSize = true;
            this.labelTiempoLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempoLicencia.Location = new System.Drawing.Point(516, 4);
            this.labelTiempoLicencia.Name = "labelTiempoLicencia";
            this.labelTiempoLicencia.Size = new System.Drawing.Size(115, 16);
            this.labelTiempoLicencia.TabIndex = 13;
            this.labelTiempoLicencia.Text = "Tiempo de uso:";
            this.labelTiempoLicencia.Visible = false;
            // 
            // btnVerLicencia
            // 
            this.btnVerLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerLicencia.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.btnVerLicencia.IconColor = System.Drawing.Color.DarkGoldenrod;
            this.btnVerLicencia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerLicencia.IconSize = 20;
            this.btnVerLicencia.Location = new System.Drawing.Point(631, -1);
            this.btnVerLicencia.Name = "btnVerLicencia";
            this.btnVerLicencia.Size = new System.Drawing.Size(32, 26);
            this.btnVerLicencia.TabIndex = 12;
            this.btnVerLicencia.UseVisualStyleBackColor = true;
            this.btnVerLicencia.Visible = false;
            // 
            // labelHeaderRuta
            // 
            this.labelHeaderRuta.AutoSize = true;
            this.labelHeaderRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeaderRuta.Location = new System.Drawing.Point(6, 4);
            this.labelHeaderRuta.Name = "labelHeaderRuta";
            this.labelHeaderRuta.Size = new System.Drawing.Size(44, 16);
            this.labelHeaderRuta.TabIndex = 10;
            this.labelHeaderRuta.Text = "Inicio";
            // 
            // iconThemeSun
            // 
            this.iconThemeSun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconThemeSun.BackColor = System.Drawing.SystemColors.Control;
            this.iconThemeSun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.iconThemeSun.IconChar = FontAwesome.Sharp.IconChar.Sun;
            this.iconThemeSun.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.iconThemeSun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconThemeSun.IconSize = 24;
            this.iconThemeSun.Location = new System.Drawing.Point(968, 1);
            this.iconThemeSun.Name = "iconThemeSun";
            this.iconThemeSun.Size = new System.Drawing.Size(24, 25);
            this.iconThemeSun.TabIndex = 9;
            this.iconThemeSun.TabStop = false;
            this.iconThemeSun.Visible = false;
            // 
            // iconThemeMoon
            // 
            this.iconThemeMoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconThemeMoon.BackColor = System.Drawing.SystemColors.Control;
            this.iconThemeMoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(140)))), ((int)(((byte)(128)))));
            this.iconThemeMoon.IconChar = FontAwesome.Sharp.IconChar.Moon;
            this.iconThemeMoon.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(140)))), ((int)(((byte)(128)))));
            this.iconThemeMoon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconThemeMoon.IconSize = 24;
            this.iconThemeMoon.Location = new System.Drawing.Point(968, 0);
            this.iconThemeMoon.Name = "iconThemeMoon";
            this.iconThemeMoon.Size = new System.Drawing.Size(24, 25);
            this.iconThemeMoon.TabIndex = 8;
            this.iconThemeMoon.TabStop = false;
            // 
            // labelTheme
            // 
            this.labelTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTheme.AutoSize = true;
            this.labelTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTheme.Location = new System.Drawing.Point(880, 4);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(59, 16);
            this.labelTheme.TabIndex = 6;
            this.labelTheme.Text = "Theme:";
            this.labelTheme.Visible = false;
            // 
            // btnModeLight
            // 
            this.btnModeLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModeLight.BackColor = System.Drawing.SystemColors.Control;
            this.btnModeLight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnModeLight.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
            this.btnModeLight.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnModeLight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModeLight.IconSize = 24;
            this.btnModeLight.Location = new System.Drawing.Point(941, 1);
            this.btnModeLight.Name = "btnModeLight";
            this.btnModeLight.Size = new System.Drawing.Size(24, 25);
            this.btnModeLight.TabIndex = 6;
            this.btnModeLight.TabStop = false;
            this.btnModeLight.Visible = false;
            // 
            // btnModeDark
            // 
            this.btnModeDark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModeDark.BackColor = System.Drawing.SystemColors.Control;
            this.btnModeDark.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            this.btnModeDark.IconColor = System.Drawing.Color.White;
            this.btnModeDark.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModeDark.IconSize = 24;
            this.btnModeDark.Location = new System.Drawing.Point(941, 0);
            this.btnModeDark.Name = "btnModeDark";
            this.btnModeDark.Size = new System.Drawing.Size(24, 25);
            this.btnModeDark.TabIndex = 7;
            this.btnModeDark.TabStop = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 604);
            this.Controls.Add(this.panelContenedorInterno);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeaderbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelHeaderbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWindowMinimize)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.subMenuTesoreria.ResumeLayout(false);
            this.subMenuSecretaria.ResumeLayout(false);
            this.panelLogoContainer.ResumeLayout(false);
            this.panelLogoContainer.PerformLayout();
            this.panelSidebarClose.ResumeLayout(false);
            this.panelSidebarClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenSidebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSidebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconThemeSun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconThemeMoon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModeLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModeDark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderbar;
        private FontAwesome.Sharp.IconPictureBox btnWindowMaximize;
        private FontAwesome.Sharp.IconPictureBox btnWindowRestore;
        private FontAwesome.Sharp.IconPictureBox btnWindowCerrar;
        private FontAwesome.Sharp.IconPictureBox btnWindowMinimize;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelSelectionAjustes;
        private FontAwesome.Sharp.IconButton btnAjustes;
        private FontAwesome.Sharp.IconButton btnGestionBD;
        private System.Windows.Forms.Panel panelSelectionTesoreria;
        private System.Windows.Forms.Panel panelSelectionSecretaria;
        private System.Windows.Forms.Panel subMenuTesoreria;
        private FontAwesome.Sharp.IconButton btnEgresos;
        private FontAwesome.Sharp.IconButton btnIngresos;
        private FontAwesome.Sharp.IconButton btnGestionTesoreria;
        private System.Windows.Forms.Panel subMenuSecretaria;
        private FontAwesome.Sharp.IconButton btnApuntes;
        private FontAwesome.Sharp.IconButton btnReuniones;
        private FontAwesome.Sharp.IconButton btnDirectivas;
        private FontAwesome.Sharp.IconButton btnMiembros;
        private FontAwesome.Sharp.IconButton btnDirectorio;
        private FontAwesome.Sharp.IconButton btnGestionSecretaria;
        private System.Windows.Forms.Panel panelLogoContainer;
        private System.Windows.Forms.Panel panelSidebarClose;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconPictureBox btnOpenSidebar;
        private FontAwesome.Sharp.IconPictureBox btnCloseSidebar;
        private System.Windows.Forms.Label labelLogoName;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Panel panelContenedorInterno;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TextBox textTiempoLicencia;
        private System.Windows.Forms.Label labelTiempoLicencia;
        private FontAwesome.Sharp.IconButton btnVerLicencia;
        private System.Windows.Forms.Label labelHeaderRuta;
        private FontAwesome.Sharp.IconPictureBox iconThemeSun;
        private FontAwesome.Sharp.IconPictureBox iconThemeMoon;
        private System.Windows.Forms.Label labelTheme;
        private FontAwesome.Sharp.IconPictureBox btnModeLight;
        private FontAwesome.Sharp.IconPictureBox btnModeDark;
        private System.Windows.Forms.Panel panelSelectionBD;
        private FontAwesome.Sharp.IconButton btnEnviables;
        private FontAwesome.Sharp.IconButton btnLiquidaciones;
        private System.Windows.Forms.Panel panelSelectionSalir;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;
        private FontAwesome.Sharp.IconButton btnPrsupuestos;
        private System.Windows.Forms.Label labelEstadoNube;
        private FontAwesome.Sharp.IconPictureBox iconNube;
    }
}

