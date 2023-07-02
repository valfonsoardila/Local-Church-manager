
namespace UI
{
    partial class FormReuniones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TabPage tabRegistrar;
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtras = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabMiembros = new System.Windows.Forms.TabControl();
            this.tabLista = new System.Windows.Forms.TabPage();
            this.btnGestionarMiembros = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelContenedorDeDirectorio = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btSearchLibreta = new FontAwesome.Sharp.IconPictureBox();
            this.textSerachLibreta = new System.Windows.Forms.TextBox();
            this.btnCloseSearchLibreta = new FontAwesome.Sharp.IconPictureBox();
            this.labelListaDeReuniones = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnModificar = new FontAwesome.Sharp.IconButton();
            this.btnRegistrar = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelNumeroFolio = new System.Windows.Forms.Label();
            this.labelFolio = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.btnSearchRegistrar = new FontAwesome.Sharp.IconPictureBox();
            this.textSearchRegistrar = new System.Windows.Forms.TextBox();
            this.btnCloseSearchRegistrar = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            tabRegistrar = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabMiembros.SuspendLayout();
            this.tabLista.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelContenedorDeDirectorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSearchLibreta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchLibreta)).BeginInit();
            tabRegistrar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchRegistrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchRegistrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnAtras);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 59);
            this.panel1.TabIndex = 3;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAtras.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnAtras.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAtras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAtras.IconSize = 28;
            this.btnAtras.Location = new System.Drawing.Point(12, 18);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(28, 28);
            this.btnAtras.TabIndex = 8;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(92, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gestion De Reuniones";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.Reunion;
            this.pictureBox1.Location = new System.Drawing.Point(46, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabMiembros);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 474);
            this.panel2.TabIndex = 4;
            // 
            // tabMiembros
            // 
            this.tabMiembros.Controls.Add(this.tabLista);
            this.tabMiembros.Controls.Add(tabRegistrar);
            this.tabMiembros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMiembros.Location = new System.Drawing.Point(0, 0);
            this.tabMiembros.Name = "tabMiembros";
            this.tabMiembros.SelectedIndex = 0;
            this.tabMiembros.Size = new System.Drawing.Size(800, 474);
            this.tabMiembros.TabIndex = 0;
            // 
            // tabLista
            // 
            this.tabLista.Controls.Add(this.btnGestionarMiembros);
            this.tabLista.Controls.Add(this.panel3);
            this.tabLista.Location = new System.Drawing.Point(4, 22);
            this.tabLista.Name = "tabLista";
            this.tabLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabLista.Size = new System.Drawing.Size(792, 448);
            this.tabLista.TabIndex = 0;
            this.tabLista.Text = "Lista de reuniones";
            this.tabLista.UseVisualStyleBackColor = true;
            // 
            // btnGestionarMiembros
            // 
            this.btnGestionarMiembros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnGestionarMiembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarMiembros.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarMiembros.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGestionarMiembros.IconColor = System.Drawing.Color.Black;
            this.btnGestionarMiembros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGestionarMiembros.Location = new System.Drawing.Point(332, 412);
            this.btnGestionarMiembros.Name = "btnGestionarMiembros";
            this.btnGestionarMiembros.Size = new System.Drawing.Size(135, 35);
            this.btnGestionarMiembros.TabIndex = 1;
            this.btnGestionarMiembros.Text = "Gestionar reuniones";
            this.btnGestionarMiembros.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.panelContenedorDeDirectorio);
            this.panel3.Location = new System.Drawing.Point(37, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(714, 392);
            this.panel3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.Borrar});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(714, 360);
            this.dataGridView1.TabIndex = 1;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 70;
            // 
            // Borrar
            // 
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Borrar.Name = "Borrar";
            this.Borrar.ReadOnly = true;
            this.Borrar.Width = 60;
            // 
            // panelContenedorDeDirectorio
            // 
            this.panelContenedorDeDirectorio.BackColor = System.Drawing.Color.Black;
            this.panelContenedorDeDirectorio.Controls.Add(this.iconPictureBox3);
            this.panelContenedorDeDirectorio.Controls.Add(this.comboBox1);
            this.panelContenedorDeDirectorio.Controls.Add(this.btSearchLibreta);
            this.panelContenedorDeDirectorio.Controls.Add(this.textSerachLibreta);
            this.panelContenedorDeDirectorio.Controls.Add(this.btnCloseSearchLibreta);
            this.panelContenedorDeDirectorio.Controls.Add(this.labelListaDeReuniones);
            this.panelContenedorDeDirectorio.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContenedorDeDirectorio.Location = new System.Drawing.Point(0, 0);
            this.panelContenedorDeDirectorio.Name = "panelContenedorDeDirectorio";
            this.panelContenedorDeDirectorio.Size = new System.Drawing.Size(714, 32);
            this.panelContenedorDeDirectorio.TabIndex = 0;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.iconPictureBox3.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 28;
            this.iconPictureBox3.Location = new System.Drawing.Point(5, 3);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox3.TabIndex = 9;
            this.iconPictureBox3.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(374, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Genero";
            // 
            // btSearchLibreta
            // 
            this.btSearchLibreta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearchLibreta.BackColor = System.Drawing.Color.Transparent;
            this.btSearchLibreta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSearchLibreta.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btSearchLibreta.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSearchLibreta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btSearchLibreta.IconSize = 28;
            this.btSearchLibreta.Location = new System.Drawing.Point(683, 3);
            this.btSearchLibreta.Name = "btSearchLibreta";
            this.btSearchLibreta.Size = new System.Drawing.Size(28, 28);
            this.btSearchLibreta.TabIndex = 7;
            this.btSearchLibreta.TabStop = false;
            // 
            // textSerachLibreta
            // 
            this.textSerachLibreta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSerachLibreta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSerachLibreta.Location = new System.Drawing.Point(501, 1);
            this.textSerachLibreta.Multiline = true;
            this.textSerachLibreta.Name = "textSerachLibreta";
            this.textSerachLibreta.Size = new System.Drawing.Size(180, 30);
            this.textSerachLibreta.TabIndex = 6;
            this.textSerachLibreta.Text = "Buscar";
            this.textSerachLibreta.Visible = false;
            // 
            // btnCloseSearchLibreta
            // 
            this.btnCloseSearchLibreta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseSearchLibreta.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSearchLibreta.ForeColor = System.Drawing.Color.Red;
            this.btnCloseSearchLibreta.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCloseSearchLibreta.IconColor = System.Drawing.Color.Red;
            this.btnCloseSearchLibreta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCloseSearchLibreta.IconSize = 28;
            this.btnCloseSearchLibreta.Location = new System.Drawing.Point(683, 2);
            this.btnCloseSearchLibreta.Name = "btnCloseSearchLibreta";
            this.btnCloseSearchLibreta.Size = new System.Drawing.Size(28, 28);
            this.btnCloseSearchLibreta.TabIndex = 5;
            this.btnCloseSearchLibreta.TabStop = false;
            this.btnCloseSearchLibreta.Visible = false;
            // 
            // labelListaDeReuniones
            // 
            this.labelListaDeReuniones.AutoSize = true;
            this.labelListaDeReuniones.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaDeReuniones.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelListaDeReuniones.Location = new System.Drawing.Point(36, 9);
            this.labelListaDeReuniones.Name = "labelListaDeReuniones";
            this.labelListaDeReuniones.Size = new System.Drawing.Size(145, 16);
            this.labelListaDeReuniones.TabIndex = 0;
            this.labelListaDeReuniones.Text = "Lista de reuniones";
            // 
            // tabRegistrar
            // 
            tabRegistrar.Controls.Add(this.panel4);
            tabRegistrar.Location = new System.Drawing.Point(4, 22);
            tabRegistrar.Name = "tabRegistrar";
            tabRegistrar.Size = new System.Drawing.Size(792, 448);
            tabRegistrar.TabIndex = 1;
            tabRegistrar.Text = "Registrar nueva reunion";
            tabRegistrar.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 448);
            this.panel4.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnModificar);
            this.panel7.Controls.Add(this.btnRegistrar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 403);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(792, 45);
            this.panel7.TabIndex = 17;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkRed;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnModificar.IconColor = System.Drawing.Color.Black;
            this.btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModificar.Location = new System.Drawing.Point(366, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(123, 35);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar existente";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.Green;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRegistrar.IconColor = System.Drawing.Color.Black;
            this.btnRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrar.Location = new System.Drawing.Point(250, 5);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(110, 35);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar nuevo";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelNumeroFolio);
            this.panel6.Controls.Add(this.labelFolio);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(792, 26);
            this.panel6.TabIndex = 14;
            // 
            // labelNumeroFolio
            // 
            this.labelNumeroFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumeroFolio.AutoSize = true;
            this.labelNumeroFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroFolio.Location = new System.Drawing.Point(624, 5);
            this.labelNumeroFolio.Name = "labelNumeroFolio";
            this.labelNumeroFolio.Size = new System.Drawing.Size(77, 16);
            this.labelNumeroFolio.TabIndex = 1;
            this.labelNumeroFolio.Text = "*                ";
            // 
            // labelFolio
            // 
            this.labelFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFolio.AutoSize = true;
            this.labelFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolio.Location = new System.Drawing.Point(556, 5);
            this.labelFolio.Name = "labelFolio";
            this.labelFolio.Size = new System.Drawing.Size(62, 16);
            this.labelFolio.TabIndex = 0;
            this.labelFolio.Text = "FOLIO #";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.iconPictureBox4);
            this.panel5.Controls.Add(this.btnSearchRegistrar);
            this.panel5.Controls.Add(this.textSearchRegistrar);
            this.panel5.Controls.Add(this.btnCloseSearchRegistrar);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(792, 32);
            this.panel5.TabIndex = 1;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconPictureBox4.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 28;
            this.iconPictureBox4.Location = new System.Drawing.Point(5, 3);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox4.TabIndex = 9;
            this.iconPictureBox4.TabStop = false;
            // 
            // btnSearchRegistrar
            // 
            this.btnSearchRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchRegistrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearchRegistrar.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btnSearchRegistrar.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearchRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchRegistrar.IconSize = 28;
            this.btnSearchRegistrar.Location = new System.Drawing.Point(759, 2);
            this.btnSearchRegistrar.Name = "btnSearchRegistrar";
            this.btnSearchRegistrar.Size = new System.Drawing.Size(28, 28);
            this.btnSearchRegistrar.TabIndex = 7;
            this.btnSearchRegistrar.TabStop = false;
            // 
            // textSearchRegistrar
            // 
            this.textSearchRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearchRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearchRegistrar.Location = new System.Drawing.Point(577, 1);
            this.textSearchRegistrar.Multiline = true;
            this.textSearchRegistrar.Name = "textSearchRegistrar";
            this.textSearchRegistrar.Size = new System.Drawing.Size(180, 30);
            this.textSearchRegistrar.TabIndex = 6;
            this.textSearchRegistrar.Text = "Buscar";
            this.textSearchRegistrar.Visible = false;
            // 
            // btnCloseSearchRegistrar
            // 
            this.btnCloseSearchRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseSearchRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSearchRegistrar.ForeColor = System.Drawing.Color.Red;
            this.btnCloseSearchRegistrar.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCloseSearchRegistrar.IconColor = System.Drawing.Color.Red;
            this.btnCloseSearchRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCloseSearchRegistrar.IconSize = 28;
            this.btnCloseSearchRegistrar.Location = new System.Drawing.Point(759, 2);
            this.btnCloseSearchRegistrar.Name = "btnCloseSearchRegistrar";
            this.btnCloseSearchRegistrar.Size = new System.Drawing.Size(28, 28);
            this.btnCloseSearchRegistrar.TabIndex = 5;
            this.btnCloseSearchRegistrar.TabStop = false;
            this.btnCloseSearchRegistrar.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(36, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Agregar nuevo miembro";
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 58);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(792, 345);
            this.panel8.TabIndex = 18;
            // 
            // FormReuniones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReuniones";
            this.Text = "Reuniones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabMiembros.ResumeLayout(false);
            this.tabLista.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelContenedorDeDirectorio.ResumeLayout(false);
            this.panelContenedorDeDirectorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSearchLibreta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchLibreta)).EndInit();
            tabRegistrar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchRegistrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchRegistrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnAtras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabMiembros;
        private System.Windows.Forms.TabPage tabLista;
        private FontAwesome.Sharp.IconButton btnGestionarMiembros;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewImageColumn Borrar;
        private System.Windows.Forms.Panel panelContenedorDeDirectorio;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private FontAwesome.Sharp.IconPictureBox btSearchLibreta;
        private System.Windows.Forms.TextBox textSerachLibreta;
        private FontAwesome.Sharp.IconPictureBox btnCloseSearchLibreta;
        private System.Windows.Forms.Label labelListaDeReuniones;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnRegistrar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelNumeroFolio;
        private System.Windows.Forms.Label labelFolio;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox btnSearchRegistrar;
        private System.Windows.Forms.TextBox textSearchRegistrar;
        private FontAwesome.Sharp.IconPictureBox btnCloseSearchRegistrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
    }
}