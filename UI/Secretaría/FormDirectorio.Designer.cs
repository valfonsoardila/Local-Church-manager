
namespace UI
{
    partial class FormDirectorio
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModificar = new FontAwesome.Sharp.IconButton();
            this.btnRegistrar = new FontAwesome.Sharp.IconButton();
            this.comboOficioRegistrar = new System.Windows.Forms.ComboBox();
            this.textNumeroWhatsapp = new System.Windows.Forms.TextBox();
            this.textCelular = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtras = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabDirectorio = new System.Windows.Forms.TabControl();
            this.tabLibreta = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnGestionarContactos = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridContactos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Whatsapp = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelContenedorDeDirectorio = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.comboOficioLibreta = new System.Windows.Forms.ComboBox();
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
            this.panel2.SuspendLayout();
            this.tabDirectorio.SuspendLayout();
            this.tabLibreta.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContactos)).BeginInit();
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
            tabRegistrar.Size = new System.Drawing.Size(792, 468);
            tabRegistrar.TabIndex = 1;
            tabRegistrar.Text = "Registrar";
            tabRegistrar.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Controls.Add(this.comboOficioRegistrar);
            this.panel4.Controls.Add(this.textNumeroWhatsapp);
            this.panel4.Controls.Add(this.textCelular);
            this.panel4.Controls.Add(this.textApellido);
            this.panel4.Controls.Add(this.textNombre);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(40, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(714, 392);
            this.panel4.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnModificar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegistrar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 337);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(714, 55);
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
            this.btnModificar.Location = new System.Drawing.Point(360, 3);
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
            this.btnRegistrar.Location = new System.Drawing.Point(240, 3);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(114, 41);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Guardar";
            this.btnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // comboOficioRegistrar
            // 
            this.comboOficioRegistrar.AutoCompleteCustomSource.AddRange(new string[] {
            "Ingeniero(a) de sistemas",
            "Ingeniero(a) de electronica",
            "Ingeniero(a) Industrial",
            "Enfermero(a)",
            "Electricista",
            "Albañil",
            "Abogado",
            "Acesor comercial",
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
            this.comboOficioRegistrar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboOficioRegistrar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboOficioRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOficioRegistrar.FormattingEnabled = true;
            this.comboOficioRegistrar.Items.AddRange(new object[] {
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
            this.comboOficioRegistrar.Location = new System.Drawing.Point(159, 197);
            this.comboOficioRegistrar.Name = "comboOficioRegistrar";
            this.comboOficioRegistrar.Size = new System.Drawing.Size(278, 24);
            this.comboOficioRegistrar.TabIndex = 11;
            this.comboOficioRegistrar.Text = "Oficio";
            this.comboOficioRegistrar.Enter += new System.EventHandler(this.comboOficio_Enter);
            this.comboOficioRegistrar.Leave += new System.EventHandler(this.comboOficio_Leave);
            // 
            // textNumeroWhatsapp
            // 
            this.textNumeroWhatsapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNumeroWhatsapp.Location = new System.Drawing.Point(197, 166);
            this.textNumeroWhatsapp.Multiline = true;
            this.textNumeroWhatsapp.Name = "textNumeroWhatsapp";
            this.textNumeroWhatsapp.Size = new System.Drawing.Size(240, 26);
            this.textNumeroWhatsapp.TabIndex = 10;
            this.textNumeroWhatsapp.Text = "Numero de whatsapp";
            this.textNumeroWhatsapp.TextChanged += new System.EventHandler(this.textNumeroWhatsapp_TextChanged);
            this.textNumeroWhatsapp.Enter += new System.EventHandler(this.textNumeroWhatsapp_Enter);
            this.textNumeroWhatsapp.Leave += new System.EventHandler(this.textNumeroWhatsapp_Leave);
            // 
            // textCelular
            // 
            this.textCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCelular.Location = new System.Drawing.Point(197, 134);
            this.textCelular.Multiline = true;
            this.textCelular.Name = "textCelular";
            this.textCelular.Size = new System.Drawing.Size(240, 26);
            this.textCelular.TabIndex = 9;
            this.textCelular.Text = "Celular";
            this.textCelular.TextChanged += new System.EventHandler(this.textCelular_TextChanged);
            this.textCelular.Enter += new System.EventHandler(this.textCelular_Enter);
            this.textCelular.Leave += new System.EventHandler(this.textCelular_Leave);
            // 
            // textApellido
            // 
            this.textApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellido.Location = new System.Drawing.Point(119, 102);
            this.textApellido.Multiline = true;
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(240, 26);
            this.textApellido.TabIndex = 8;
            this.textApellido.Text = "Apellido";
            this.textApellido.Enter += new System.EventHandler(this.textApellido_Enter);
            this.textApellido.Leave += new System.EventHandler(this.textApellido_Leave);
            // 
            // textNombre
            // 
            this.textNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(115, 70);
            this.textNombre.Multiline = true;
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(244, 26);
            this.textNombre.TabIndex = 7;
            this.textNombre.Text = "Nombre";
            this.textNombre.Enter += new System.EventHandler(this.textNombre_Enter);
            this.textNombre.Leave += new System.EventHandler(this.textNombre_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Trabajo u oficio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Contacto Whatsapp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Telefono de contacto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Apellidos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombres:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.iconPictureBox4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(714, 32);
            this.panel5.TabIndex = 1;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
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
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Agregar nuevo contacto";
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
            this.panel1.TabIndex = 1;
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
            this.label2.Location = new System.Drawing.Point(92, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Directorio Telefonico";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.telefono;
            this.pictureBox1.Location = new System.Drawing.Point(46, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabDirectorio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 494);
            this.panel2.TabIndex = 2;
            // 
            // tabDirectorio
            // 
            this.tabDirectorio.Controls.Add(this.tabLibreta);
            this.tabDirectorio.Controls.Add(tabRegistrar);
            this.tabDirectorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDirectorio.Location = new System.Drawing.Point(0, 0);
            this.tabDirectorio.Name = "tabDirectorio";
            this.tabDirectorio.SelectedIndex = 0;
            this.tabDirectorio.Size = new System.Drawing.Size(800, 494);
            this.tabDirectorio.TabIndex = 0;
            // 
            // tabLibreta
            // 
            this.tabLibreta.Controls.Add(this.panel7);
            this.tabLibreta.Controls.Add(this.panel6);
            this.tabLibreta.Location = new System.Drawing.Point(4, 22);
            this.tabLibreta.Name = "tabLibreta";
            this.tabLibreta.Padding = new System.Windows.Forms.Padding(3);
            this.tabLibreta.Size = new System.Drawing.Size(792, 468);
            this.tabLibreta.TabIndex = 0;
            this.tabLibreta.Text = "Libreta";
            this.tabLibreta.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnGestionarContactos);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 409);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(786, 56);
            this.panel7.TabIndex = 3;
            // 
            // btnGestionarContactos
            // 
            this.btnGestionarContactos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestionarContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnGestionarContactos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarContactos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGestionarContactos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGestionarContactos.IconColor = System.Drawing.Color.Black;
            this.btnGestionarContactos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGestionarContactos.Location = new System.Drawing.Point(328, 11);
            this.btnGestionarContactos.Name = "btnGestionarContactos";
            this.btnGestionarContactos.Size = new System.Drawing.Size(153, 35);
            this.btnGestionarContactos.TabIndex = 1;
            this.btnGestionarContactos.Text = "Gestionar contactos";
            this.btnGestionarContactos.UseVisualStyleBackColor = false;
            this.btnGestionarContactos.Click += new System.EventHandler(this.btnGestionarContactos_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(786, 462);
            this.panel6.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dataGridContactos);
            this.panel3.Controls.Add(this.panelContenedorDeDirectorio);
            this.panel3.Location = new System.Drawing.Point(27, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 392);
            this.panel3.TabIndex = 0;
            // 
            // dataGridContactos
            // 
            this.dataGridContactos.AllowUserToAddRows = false;
            this.dataGridContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridContactos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridContactos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dataGridContactos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.Editar,
            this.Borrar,
            this.Whatsapp});
            this.dataGridContactos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridContactos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridContactos.Location = new System.Drawing.Point(0, 32);
            this.dataGridContactos.Name = "dataGridContactos";
            this.dataGridContactos.ReadOnly = true;
            this.dataGridContactos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridContactos.RowHeadersVisible = false;
            this.dataGridContactos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridContactos.RowTemplate.DividerHeight = 2;
            this.dataGridContactos.RowTemplate.Height = 30;
            this.dataGridContactos.Size = new System.Drawing.Size(724, 360);
            this.dataGridContactos.TabIndex = 1;
            this.dataGridContactos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridContactos_CellClick);
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
            // Whatsapp
            // 
            this.Whatsapp.HeaderText = "Whatsapp";
            this.Whatsapp.Image = global::UI.Properties.Resources.WhatsApp;
            this.Whatsapp.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Whatsapp.Name = "Whatsapp";
            this.Whatsapp.ReadOnly = true;
            this.Whatsapp.Width = 62;
            // 
            // panelContenedorDeDirectorio
            // 
            this.panelContenedorDeDirectorio.BackColor = System.Drawing.Color.Black;
            this.panelContenedorDeDirectorio.Controls.Add(this.label9);
            this.panelContenedorDeDirectorio.Controls.Add(this.textTotal);
            this.panelContenedorDeDirectorio.Controls.Add(this.comboOficioLibreta);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(115, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Total";
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.Location = new System.Drawing.Point(161, 5);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(46, 22);
            this.textTotal.TabIndex = 11;
            this.textTotal.Text = "0";
            // 
            // comboOficioLibreta
            // 
            this.comboOficioLibreta.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.comboOficioLibreta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboOficioLibreta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboOficioLibreta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOficioLibreta.FormattingEnabled = true;
            this.comboOficioLibreta.Items.AddRange(new object[] {
            "Todos",
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
            this.comboOficioLibreta.Location = new System.Drawing.Point(374, 4);
            this.comboOficioLibreta.Name = "comboOficioLibreta";
            this.comboOficioLibreta.Size = new System.Drawing.Size(121, 24);
            this.comboOficioLibreta.TabIndex = 10;
            this.comboOficioLibreta.Text = "Oficio";
            this.comboOficioLibreta.SelectedIndexChanged += new System.EventHandler(this.comboOficioLibreta_SelectedIndexChanged);
            this.comboOficioLibreta.TextChanged += new System.EventHandler(this.comboOficioLibreta_TextChanged);
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
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
            this.textSerachLibreta.Text = "Buscar por nombre";
            this.textSerachLibreta.Visible = false;
            this.textSerachLibreta.TextChanged += new System.EventHandler(this.textSerachLibreta_TextChanged);
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
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Libreta";
            // 
            // FormDirectorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDirectorio";
            this.Text = "FormDirectorio";
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
            this.panel2.ResumeLayout(false);
            this.tabDirectorio.ResumeLayout(false);
            this.tabLibreta.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContactos)).EndInit();
            this.panelContenedorDeDirectorio.ResumeLayout(false);
            this.panelContenedorDeDirectorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSearchLibreta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseSearchLibreta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabDirectorio;
        private System.Windows.Forms.TabPage tabLibreta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelContenedorDeDirectorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconPictureBox btnCloseSearchLibreta;
        private FontAwesome.Sharp.IconPictureBox btSearchLibreta;
        private System.Windows.Forms.TextBox textSerachLibreta;
        private FontAwesome.Sharp.IconPictureBox btnAtras;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.DataGridView dataGridContactos;
        private FontAwesome.Sharp.IconButton btnGestionarContactos;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboOficioRegistrar;
        private System.Windows.Forms.TextBox textNumeroWhatsapp;
        private System.Windows.Forms.TextBox textCelular;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboOficioLibreta;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnRegistrar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Borrar;
        private System.Windows.Forms.DataGridViewImageColumn Whatsapp;
    }
}