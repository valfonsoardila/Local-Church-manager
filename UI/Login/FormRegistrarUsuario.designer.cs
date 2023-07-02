
namespace UI
{
    partial class FormRegistrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarUsuario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.textCorreo = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.panelBarraVolver = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textIdentificacion = new System.Windows.Forms.TextBox();
            this.labelIdentificacion = new System.Windows.Forms.Label();
            this.comboTipoDeId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimeFechaDeNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboSexo = new System.Windows.Forms.ComboBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAdvertencia = new System.Windows.Forms.Label();
            this.iconSeePasword = new FontAwesome.Sharp.IconPictureBox();
            this.iconNoSeePasword = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVolver = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeePasword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNoSeePasword)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 27);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.TimesSquare;
            this.btnCerrar.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 20;
            this.btnCerrar.Location = new System.Drawing.Point(430, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnMinimizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimizar.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimizar.IconSize = 20;
            this.btnMinimizar.Location = new System.Drawing.Point(406, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(14, 187);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(96, 13);
            this.labelCorreo.TabIndex = 3;
            this.labelCorreo.Text = "Correo electronico:";
            // 
            // textCorreo
            // 
            this.textCorreo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textCorreo.Location = new System.Drawing.Point(107, 184);
            this.textCorreo.Name = "textCorreo";
            this.textCorreo.Size = new System.Drawing.Size(162, 20);
            this.textCorreo.TabIndex = 4;
            this.textCorreo.Text = "@gmail.com";
            this.textCorreo.Enter += new System.EventHandler(this.textCorreo_Enter);
            this.textCorreo.Leave += new System.EventHandler(this.textCorreo_Leave);
            // 
            // textUsuario
            // 
            this.textUsuario.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textUsuario.Location = new System.Drawing.Point(66, 210);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(143, 20);
            this.textUsuario.TabIndex = 6;
            this.textUsuario.Text = "@Bryan10";
            this.textUsuario.Enter += new System.EventHandler(this.textUsuario_Enter);
            this.textUsuario.Leave += new System.EventHandler(this.textUsuario_Leave);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(14, 213);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(46, 13);
            this.labelUsuario.TabIndex = 5;
            this.labelUsuario.Text = "Usuario:";
            // 
            // textContraseña
            // 
            this.textContraseña.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textContraseña.Location = new System.Drawing.Point(274, 210);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(152, 20);
            this.textContraseña.TabIndex = 8;
            this.textContraseña.Text = "Mayor a 6 caracteres";
            this.textContraseña.Enter += new System.EventHandler(this.textContraseña_Enter);
            this.textContraseña.Leave += new System.EventHandler(this.textContraseña_Leave);
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(211, 214);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(64, 13);
            this.labelContraseña.TabIndex = 7;
            this.labelContraseña.Text = "Contraseña:";
            // 
            // panelBarraVolver
            // 
            this.panelBarraVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.panelBarraVolver.Location = new System.Drawing.Point(1, 30);
            this.panelBarraVolver.Name = "panelBarraVolver";
            this.panelBarraVolver.Size = new System.Drawing.Size(7, 25);
            this.panelBarraVolver.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.label1.Location = new System.Drawing.Point(39, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Registro de usuario";
            // 
            // textIdentificacion
            // 
            this.textIdentificacion.ForeColor = System.Drawing.Color.Black;
            this.textIdentificacion.Location = new System.Drawing.Point(83, 237);
            this.textIdentificacion.Name = "textIdentificacion";
            this.textIdentificacion.Size = new System.Drawing.Size(113, 20);
            this.textIdentificacion.TabIndex = 36;
            // 
            // labelIdentificacion
            // 
            this.labelIdentificacion.AutoSize = true;
            this.labelIdentificacion.Location = new System.Drawing.Point(14, 241);
            this.labelIdentificacion.Name = "labelIdentificacion";
            this.labelIdentificacion.Size = new System.Drawing.Size(73, 13);
            this.labelIdentificacion.TabIndex = 35;
            this.labelIdentificacion.Text = "Identificacion:";
            // 
            // comboTipoDeId
            // 
            this.comboTipoDeId.FormattingEnabled = true;
            this.comboTipoDeId.Items.AddRange(new object[] {
            "CC",
            "TI"});
            this.comboTipoDeId.Location = new System.Drawing.Point(254, 237);
            this.comboTipoDeId.Name = "comboTipoDeId";
            this.comboTipoDeId.Size = new System.Drawing.Size(62, 21);
            this.comboTipoDeId.TabIndex = 37;
            this.comboTipoDeId.Text = "CC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tipo de id:";
            // 
            // textNombre
            // 
            this.textNombre.ForeColor = System.Drawing.Color.Black;
            this.textNombre.Location = new System.Drawing.Point(63, 262);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(121, 20);
            this.textNombre.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Nombres:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Apellidos:";
            // 
            // textApellido
            // 
            this.textApellido.ForeColor = System.Drawing.Color.Black;
            this.textApellido.Location = new System.Drawing.Point(235, 263);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(121, 20);
            this.textApellido.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Fecha de nacimiento:";
            // 
            // dateTimeFechaDeNacimiento
            // 
            this.dateTimeFechaDeNacimiento.Location = new System.Drawing.Point(121, 287);
            this.dateTimeFechaDeNacimiento.Name = "dateTimeFechaDeNacimiento";
            this.dateTimeFechaDeNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFechaDeNacimiento.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Sexo:";
            // 
            // comboSexo
            // 
            this.comboSexo.FormattingEnabled = true;
            this.comboSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.comboSexo.Location = new System.Drawing.Point(355, 288);
            this.comboSexo.Name = "comboSexo";
            this.comboSexo.Size = new System.Drawing.Size(62, 21);
            this.comboSexo.TabIndex = 46;
            this.comboSexo.Text = "M";
            // 
            // textDireccion
            // 
            this.textDireccion.ForeColor = System.Drawing.Color.Black;
            this.textDireccion.Location = new System.Drawing.Point(70, 312);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(121, 20);
            this.textDireccion.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Direccion:";
            // 
            // textTelefono
            // 
            this.textTelefono.ForeColor = System.Drawing.Color.Black;
            this.textTelefono.Location = new System.Drawing.Point(249, 313);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(121, 20);
            this.textTelefono.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Telefono:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnRegistrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(178, 351);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(110, 28);
            this.btnRegistrar.TabIndex = 51;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // comboRol
            // 
            this.comboRol.ForeColor = System.Drawing.Color.Maroon;
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Items.AddRange(new object[] {
            "Administrador",
            "Empleado"});
            this.comboRol.Location = new System.Drawing.Point(353, 239);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(94, 21);
            this.comboRol.TabIndex = 53;
            this.comboRol.Text = "Administrador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Rol:";
            // 
            // labelAdvertencia
            // 
            this.labelAdvertencia.AutoSize = true;
            this.labelAdvertencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdvertencia.ForeColor = System.Drawing.Color.Maroon;
            this.labelAdvertencia.Location = new System.Drawing.Point(234, 39);
            this.labelAdvertencia.Name = "labelAdvertencia";
            this.labelAdvertencia.Size = new System.Drawing.Size(90, 16);
            this.labelAdvertencia.TabIndex = 57;
            this.labelAdvertencia.Text = "Advertencia";
            this.labelAdvertencia.Visible = false;
            // 
            // iconSeePasword
            // 
            this.iconSeePasword.BackColor = System.Drawing.SystemColors.Control;
            this.iconSeePasword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconSeePasword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconSeePasword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.iconSeePasword.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconSeePasword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSeePasword.IconSize = 21;
            this.iconSeePasword.Location = new System.Drawing.Point(427, 210);
            this.iconSeePasword.Name = "iconSeePasword";
            this.iconSeePasword.Size = new System.Drawing.Size(21, 22);
            this.iconSeePasword.TabIndex = 55;
            this.iconSeePasword.TabStop = false;
            this.iconSeePasword.Visible = false;
            this.iconSeePasword.Click += new System.EventHandler(this.iconSeePasword_Click);
            // 
            // iconNoSeePasword
            // 
            this.iconNoSeePasword.BackColor = System.Drawing.SystemColors.Control;
            this.iconNoSeePasword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconNoSeePasword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.iconNoSeePasword.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconNoSeePasword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNoSeePasword.IconSize = 21;
            this.iconNoSeePasword.Location = new System.Drawing.Point(427, 210);
            this.iconNoSeePasword.Name = "iconNoSeePasword";
            this.iconNoSeePasword.Size = new System.Drawing.Size(21, 22);
            this.iconNoSeePasword.TabIndex = 56;
            this.iconNoSeePasword.TabStop = false;
            this.iconNoSeePasword.Click += new System.EventHandler(this.iconNoSeePasword_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::UI.Properties.Resources.Fondo;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 120);
            this.panel2.TabIndex = 52;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI.Properties.Resources.Fondo;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::UI.Properties.Resources.Usuario;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVolver.IconChar = FontAwesome.Sharp.IconChar.CaretLeft;
            this.btnVolver.IconColor = System.Drawing.SystemColors.WindowText;
            this.btnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVolver.IconSize = 28;
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(10, 30);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(25, 25);
            this.btnVolver.TabIndex = 34;
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormRegistrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 400);
            this.Controls.Add(this.labelAdvertencia);
            this.Controls.Add(this.iconSeePasword);
            this.Controls.Add(this.iconNoSeePasword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboRol);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.textTelefono);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboSexo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimeFechaDeNacimiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTipoDeId);
            this.Controls.Add(this.textIdentificacion);
            this.Controls.Add(this.labelIdentificacion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelBarraVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textCorreo);
            this.Controls.Add(this.labelCorreo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegistrarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegistrarUsuario";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormRegistrarUsuario_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeePasword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNoSeePasword)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.TextBox textCorreo;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.Label labelContraseña;
        private FontAwesome.Sharp.IconButton btnVolver;
        private System.Windows.Forms.Panel panelBarraVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIdentificacion;
        private System.Windows.Forms.Label labelIdentificacion;
        private System.Windows.Forms.ComboBox comboTipoDeId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimeFechaDeNacimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboSexo;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboRol;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconSeePasword;
        private FontAwesome.Sharp.IconPictureBox iconNoSeePasword;
        private System.Windows.Forms.Label labelAdvertencia;
    }
}