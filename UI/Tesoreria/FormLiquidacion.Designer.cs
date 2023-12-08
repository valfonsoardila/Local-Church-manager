namespace UI
{
    partial class FormLiquidacion
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.textDineroIngreso = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateFechaLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModificar = new FontAwesome.Sharp.IconButton();
            this.btnRegistrar = new FontAwesome.Sharp.IconButton();
            this.textDetalle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.textSaldo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textTotalLiquidacion = new System.Windows.Forms.TextBox();
            this.btnAtras = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabLiquidaciones = new System.Windows.Forms.TabControl();
            this.tabListaLiquidaciones = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnGestionarDirectivas = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridLiquidacion = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Egresar = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelContenedorDeDirectorio = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.textTotalNube = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textTotalLocal = new System.Windows.Forms.TextBox();
            this.comboFecha = new System.Windows.Forms.ComboBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.btSearchLibreta = new FontAwesome.Sharp.IconPictureBox();
            this.textSerachLibreta = new System.Windows.Forms.TextBox();
            this.btnCloseSearchLibreta = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            tabRegistrar = new System.Windows.Forms.TabPage();
            tabRegistrar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabLiquidaciones.SuspendLayout();
            this.tabListaLiquidaciones.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLiquidacion)).BeginInit();
            this.panelContenedorDeDirectorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSearchLibreta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchLibreta)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRegistrar
            // 
            tabRegistrar.Controls.Add(this.panel4);
            tabRegistrar.Location = new System.Drawing.Point(4, 22);
            tabRegistrar.Name = "tabRegistrar";
            tabRegistrar.Size = new System.Drawing.Size(792, 450);
            tabRegistrar.TabIndex = 1;
            tabRegistrar.Text = "Registrar";
            tabRegistrar.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.textDineroIngreso);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.dateFechaLiquidacion);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Controls.Add(this.textDetalle);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(40, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 349);
            this.panel4.TabIndex = 0;
            // 
            // textDineroIngreso
            // 
            this.textDineroIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDineroIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDineroIngreso.Location = new System.Drawing.Point(115, 77);
            this.textDineroIngreso.Name = "textDineroIngreso";
            this.textDineroIngreso.Size = new System.Drawing.Size(181, 26);
            this.textDineroIngreso.TabIndex = 29;
            this.textDineroIngreso.Text = "$ 000.00";
            this.textDineroIngreso.Enter += new System.EventHandler(this.textDineroIngreso_Enter);
            this.textDineroIngreso.Leave += new System.EventHandler(this.textDineroIngreso_Leave);
            this.textDineroIngreso.Validated += new System.EventHandler(this.textDineroIngreso_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(36, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Valor:";
            // 
            // dateFechaLiquidacion
            // 
            this.dateFechaLiquidacion.Location = new System.Drawing.Point(115, 47);
            this.dateFechaLiquidacion.Name = "dateFechaLiquidacion";
            this.dateFechaLiquidacion.Size = new System.Drawing.Size(200, 20);
            this.dateFechaLiquidacion.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fecha:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnModificar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegistrar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 294);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 55);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkRed;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.IconChar = FontAwesome.Sharp.IconChar.FileEdit;
            this.btnModificar.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModificar.IconSize = 30;
            this.btnModificar.Location = new System.Drawing.Point(338, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(123, 41);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.BackColor = System.Drawing.Color.Green;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistrar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnRegistrar.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.btnRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrar.IconSize = 30;
            this.btnRegistrar.Location = new System.Drawing.Point(218, 3);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(114, 41);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Guardar";
            this.btnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // textDetalle
            // 
            this.textDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDetalle.Location = new System.Drawing.Point(115, 112);
            this.textDetalle.Multiline = true;
            this.textDetalle.Name = "textDetalle";
            this.textDetalle.Size = new System.Drawing.Size(368, 80);
            this.textDetalle.TabIndex = 7;
            this.textDetalle.Text = "Detalle";
            this.textDetalle.Enter += new System.EventHandler(this.textDetalle_Enter);
            this.textDetalle.Leave += new System.EventHandler(this.textDetalle_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Detalle:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.iconPictureBox4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(670, 32);
            this.panel5.TabIndex = 1;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.MobileRetro;
            this.iconPictureBox4.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 28;
            this.iconPictureBox4.Location = new System.Drawing.Point(5, 3);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox4.TabIndex = 9;
            this.iconPictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(36, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nuevo registro";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.textSaldo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textTotalLiquidacion);
            this.panel1.Controls.Add(this.btnAtras);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 59);
            this.panel1.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Yellow;
            this.label16.Location = new System.Drawing.Point(253, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 24);
            this.label16.TabIndex = 23;
            this.label16.Text = "Saldo";
            // 
            // textSaldo
            // 
            this.textSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSaldo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSaldo.ForeColor = System.Drawing.Color.Yellow;
            this.textSaldo.Location = new System.Drawing.Point(323, 14);
            this.textSaldo.Name = "textSaldo";
            this.textSaldo.Size = new System.Drawing.Size(139, 35);
            this.textSaldo.TabIndex = 22;
            this.textSaldo.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(465, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 24);
            this.label11.TabIndex = 21;
            this.label11.Text = "Total Liquidacion";
            // 
            // textTotalLiquidacion
            // 
            this.textTotalLiquidacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalLiquidacion.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textTotalLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTotalLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalLiquidacion.ForeColor = System.Drawing.SystemColors.Info;
            this.textTotalLiquidacion.Location = new System.Drawing.Point(658, 16);
            this.textTotalLiquidacion.Name = "textTotalLiquidacion";
            this.textTotalLiquidacion.Size = new System.Drawing.Size(139, 28);
            this.textTotalLiquidacion.TabIndex = 20;
            this.textTotalLiquidacion.Text = "0";
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
            this.label2.Location = new System.Drawing.Point(100, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Liquidacion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.Liquidacion;
            this.pictureBox1.Location = new System.Drawing.Point(42, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabLiquidaciones
            // 
            this.tabLiquidaciones.Controls.Add(this.tabListaLiquidaciones);
            this.tabLiquidaciones.Controls.Add(tabRegistrar);
            this.tabLiquidaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLiquidaciones.Location = new System.Drawing.Point(0, 59);
            this.tabLiquidaciones.Name = "tabLiquidaciones";
            this.tabLiquidaciones.SelectedIndex = 0;
            this.tabLiquidaciones.Size = new System.Drawing.Size(800, 476);
            this.tabLiquidaciones.TabIndex = 4;
            // 
            // tabListaLiquidaciones
            // 
            this.tabListaLiquidaciones.Controls.Add(this.panel7);
            this.tabListaLiquidaciones.Controls.Add(this.panel6);
            this.tabListaLiquidaciones.Location = new System.Drawing.Point(4, 22);
            this.tabListaLiquidaciones.Name = "tabListaLiquidaciones";
            this.tabListaLiquidaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabListaLiquidaciones.Size = new System.Drawing.Size(792, 450);
            this.tabListaLiquidaciones.TabIndex = 0;
            this.tabListaLiquidaciones.Text = "Lista de liquidaciones";
            this.tabListaLiquidaciones.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tableLayoutPanel2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 391);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(786, 56);
            this.panel7.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnImprimir, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGestionarDirectivas, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 44);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Orange;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 30;
            this.btnImprimir.Location = new System.Drawing.Point(396, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnImprimir.Size = new System.Drawing.Size(142, 35);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "Imprimir Lista";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnGestionarDirectivas
            // 
            this.btnGestionarDirectivas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestionarDirectivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnGestionarDirectivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarDirectivas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarDirectivas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGestionarDirectivas.IconColor = System.Drawing.Color.Black;
            this.btnGestionarDirectivas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGestionarDirectivas.Location = new System.Drawing.Point(232, 3);
            this.btnGestionarDirectivas.Name = "btnGestionarDirectivas";
            this.btnGestionarDirectivas.Size = new System.Drawing.Size(158, 35);
            this.btnGestionarDirectivas.TabIndex = 1;
            this.btnGestionarDirectivas.Text = "Gestionar Liquidaciones";
            this.btnGestionarDirectivas.UseVisualStyleBackColor = false;
            this.btnGestionarDirectivas.Click += new System.EventHandler(this.btnGestionarDirectivas_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(786, 444);
            this.panel6.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dataGridLiquidacion);
            this.panel3.Controls.Add(this.panelContenedorDeDirectorio);
            this.panel3.Location = new System.Drawing.Point(27, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 374);
            this.panel3.TabIndex = 0;
            // 
            // dataGridLiquidacion
            // 
            this.dataGridLiquidacion.AllowUserToAddRows = false;
            this.dataGridLiquidacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridLiquidacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dataGridLiquidacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLiquidacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.Editar,
            this.Borrar,
            this.Egresar});
            this.dataGridLiquidacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridLiquidacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLiquidacion.Location = new System.Drawing.Point(0, 32);
            this.dataGridLiquidacion.Name = "dataGridLiquidacion";
            this.dataGridLiquidacion.ReadOnly = true;
            this.dataGridLiquidacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridLiquidacion.RowHeadersVisible = false;
            this.dataGridLiquidacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridLiquidacion.RowTemplate.DividerHeight = 2;
            this.dataGridLiquidacion.RowTemplate.Height = 30;
            this.dataGridLiquidacion.Size = new System.Drawing.Size(724, 342);
            this.dataGridLiquidacion.TabIndex = 1;
            this.dataGridLiquidacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLiquidacion_CellClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 69;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::UI.Properties.Resources.edit_user;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Width = 40;
            // 
            // Borrar
            // 
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Image = global::UI.Properties.Resources.borrar;
            this.Borrar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Borrar.Name = "Borrar";
            this.Borrar.ReadOnly = true;
            this.Borrar.Width = 41;
            // 
            // Egresar
            // 
            this.Egresar.HeaderText = "Egresar";
            this.Egresar.Image = global::UI.Properties.Resources.Egresos2;
            this.Egresar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Egresar.Name = "Egresar";
            this.Egresar.ReadOnly = true;
            this.Egresar.Width = 49;
            // 
            // panelContenedorDeDirectorio
            // 
            this.panelContenedorDeDirectorio.BackColor = System.Drawing.Color.Black;
            this.panelContenedorDeDirectorio.Controls.Add(this.label15);
            this.panelContenedorDeDirectorio.Controls.Add(this.textTotalNube);
            this.panelContenedorDeDirectorio.Controls.Add(this.label9);
            this.panelContenedorDeDirectorio.Controls.Add(this.textTotalLocal);
            this.panelContenedorDeDirectorio.Controls.Add(this.comboFecha);
            this.panelContenedorDeDirectorio.Controls.Add(this.iconPictureBox3);
            this.panelContenedorDeDirectorio.Controls.Add(this.btSearchLibreta);
            this.panelContenedorDeDirectorio.Controls.Add(this.textSerachLibreta);
            this.panelContenedorDeDirectorio.Controls.Add(this.btnCloseSearchLibreta);
            this.panelContenedorDeDirectorio.Controls.Add(this.label1);
            this.panelContenedorDeDirectorio.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContenedorDeDirectorio.Location = new System.Drawing.Point(0, 0);
            this.panelContenedorDeDirectorio.Name = "panelContenedorDeDirectorio";
            this.panelContenedorDeDirectorio.Size = new System.Drawing.Size(724, 32);
            this.panelContenedorDeDirectorio.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(250, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "Total en Nube";
            // 
            // textTotalNube
            // 
            this.textTotalNube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalNube.Location = new System.Drawing.Point(351, 5);
            this.textTotalNube.Name = "textTotalNube";
            this.textTotalNube.Size = new System.Drawing.Size(46, 22);
            this.textTotalNube.TabIndex = 28;
            this.textTotalNube.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(122, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Total Local";
            // 
            // textTotalLocal
            // 
            this.textTotalLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalLocal.Location = new System.Drawing.Point(203, 5);
            this.textTotalLocal.Name = "textTotalLocal";
            this.textTotalLocal.Size = new System.Drawing.Size(46, 22);
            this.textTotalLocal.TabIndex = 26;
            this.textTotalLocal.Text = "0";
            // 
            // comboFecha
            // 
            this.comboFecha.AutoCompleteCustomSource.AddRange(new string[] {
            "Ingeniero(a) de sistemas",
            "Ingeniero(a) de electronica",
            "Ingeniero(a) Industrial",
            "Enfermero(a)",
            "Electricista",
            "Albañil",
            "Abogado",
            "Acesor comercial",
            "Estudiante",
            "Medico(a)",
            "Farmaceutico(a)",
            "Odontologo(a)",
            "Fontaneros(a)",
            "Docente",
            "Contadores",
            "Psicologos",
            "Chef",
            "Repostero(a)",
            "Vigilante",
            "Escolta",
            "Ebanista",
            "Peluquero",
            "Domiciliario",
            "Soldador",
            "Diseñador Grafico",
            "Maestro de obra",
            "Mecanico",
            "Chofer",
            "Impulsador",
            "Optometra",
            "Naturista",
            "Vendedor",
            "Modista",
            "Electronico",
            "Tecnico"});
            this.comboFecha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboFecha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFecha.FormattingEnabled = true;
            this.comboFecha.Items.AddRange(new object[] {
            "Todos",
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.comboFecha.Location = new System.Drawing.Point(402, 4);
            this.comboFecha.Name = "comboFecha";
            this.comboFecha.Size = new System.Drawing.Size(93, 24);
            this.comboFecha.TabIndex = 10;
            this.comboFecha.Text = "Mes";
            this.comboFecha.SelectedIndexChanged += new System.EventHandler(this.comboFecha_SelectedIndexChanged);
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.BlackTie;
            this.iconPictureBox3.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 28;
            this.iconPictureBox3.Location = new System.Drawing.Point(5, 3);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox3.TabIndex = 9;
            this.iconPictureBox3.TabStop = false;
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
            this.btSearchLibreta.Location = new System.Drawing.Point(684, 3);
            this.btSearchLibreta.Name = "btSearchLibreta";
            this.btSearchLibreta.Size = new System.Drawing.Size(28, 28);
            this.btSearchLibreta.TabIndex = 7;
            this.btSearchLibreta.TabStop = false;
            this.btSearchLibreta.Click += new System.EventHandler(this.btSearchLibreta_Click);
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
            this.textSerachLibreta.Text = "Buscar por fecha";
            this.textSerachLibreta.Visible = false;
            this.textSerachLibreta.Enter += new System.EventHandler(this.textSerachLibreta_Enter);
            this.textSerachLibreta.Leave += new System.EventHandler(this.textSerachLibreta_Leave);
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
            this.btnCloseSearchLibreta.Click += new System.EventHandler(this.btnCloseSearchLibreta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(36, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registros";
            // 
            // FormLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.tabLiquidaciones);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLiquidacion";
            this.Text = "FormLiquidacion";
            tabRegistrar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabLiquidaciones.ResumeLayout(false);
            this.tabListaLiquidaciones.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLiquidacion)).EndInit();
            this.panelContenedorDeDirectorio.ResumeLayout(false);
            this.panelContenedorDeDirectorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSearchLibreta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchLibreta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnAtras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabLiquidaciones;
        private System.Windows.Forms.TabPage tabListaLiquidaciones;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridLiquidacion;
        private System.Windows.Forms.Panel panelContenedorDeDirectorio;
        private System.Windows.Forms.ComboBox comboFecha;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox btSearchLibreta;
        private System.Windows.Forms.TextBox textSerachLibreta;
        private FontAwesome.Sharp.IconPictureBox btnCloseSearchLibreta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateFechaLiquidacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnRegistrar;
        private System.Windows.Forms.TextBox textDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDineroIngreso;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textSaldo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textTotalLiquidacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnGestionarDirectivas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Borrar;
        private System.Windows.Forms.DataGridViewImageColumn Egresar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textTotalNube;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textTotalLocal;
    }
}