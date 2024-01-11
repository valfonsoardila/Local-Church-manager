
namespace UI
{
    partial class FormRestaurarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRestaurarContraseña));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.panelBarraVolver = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new FontAwesome.Sharp.IconButton();
            this.textIdentificacion = new System.Windows.Forms.TextBox();
            this.labelIdentificacion = new System.Windows.Forms.Label();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.labelAdvertencia = new System.Windows.Forms.Label();
            this.iconNoSeePasword = new FontAwesome.Sharp.IconPictureBox();
            this.iconSeePasword = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNoSeePasword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeePasword)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(441, 27);
            this.panel1.TabIndex = 1;
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
            this.btnCerrar.Location = new System.Drawing.Point(412, 4);
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
            this.btnMinimizar.Location = new System.Drawing.Point(388, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panelBarraVolver
            // 
            this.panelBarraVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.panelBarraVolver.Location = new System.Drawing.Point(3, 29);
            this.panelBarraVolver.Name = "panelBarraVolver";
            this.panelBarraVolver.Size = new System.Drawing.Size(7, 25);
            this.panelBarraVolver.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Restaurar Contraseña";
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVolver.IconChar = FontAwesome.Sharp.IconChar.CaretLeft;
            this.btnVolver.IconColor = System.Drawing.SystemColors.WindowText;
            this.btnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVolver.IconSize = 28;
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(12, 29);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(25, 25);
            this.btnVolver.TabIndex = 37;
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // textIdentificacion
            // 
            this.textIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textIdentificacion.ForeColor = System.Drawing.Color.Black;
            this.textIdentificacion.Location = new System.Drawing.Point(179, 230);
            this.textIdentificacion.Multiline = true;
            this.textIdentificacion.Name = "textIdentificacion";
            this.textIdentificacion.Size = new System.Drawing.Size(148, 21);
            this.textIdentificacion.TabIndex = 55;
            // 
            // labelIdentificacion
            // 
            this.labelIdentificacion.AutoSize = true;
            this.labelIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdentificacion.Location = new System.Drawing.Point(70, 235);
            this.labelIdentificacion.Name = "labelIdentificacion";
            this.labelIdentificacion.Size = new System.Drawing.Size(103, 16);
            this.labelIdentificacion.TabIndex = 54;
            this.labelIdentificacion.Text = "Identificacion:";
            // 
            // textUsuario
            // 
            this.textUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUsuario.ForeColor = System.Drawing.Color.Black;
            this.textUsuario.Location = new System.Drawing.Point(144, 206);
            this.textUsuario.Multiline = true;
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(158, 20);
            this.textUsuario.TabIndex = 57;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(70, 210);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(65, 16);
            this.labelUsuario.TabIndex = 56;
            this.labelUsuario.Text = "Usuario:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(169, 328);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 28);
            this.btnBuscar.TabIndex = 58;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // textContraseña
            // 
            this.textContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textContraseña.Enabled = false;
            this.textContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.textContraseña.Location = new System.Drawing.Point(166, 292);
            this.textContraseña.Multiline = true;
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(136, 20);
            this.textContraseña.TabIndex = 60;
            this.textContraseña.Text = "Contraseña";
            this.textContraseña.Enter += new System.EventHandler(this.textContraseña_Enter);
            this.textContraseña.Leave += new System.EventHandler(this.textContraseña_Leave);
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Enabled = false;
            this.labelContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseña.Location = new System.Drawing.Point(70, 296);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(90, 16);
            this.labelContraseña.TabIndex = 59;
            this.labelContraseña.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.label5.Location = new System.Drawing.Point(66, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 18);
            this.label5.TabIndex = 61;
            this.label5.Text = "Nueva Contraseña";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.Location = new System.Drawing.Point(169, 328);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(110, 28);
            this.btnRestaurar.TabIndex = 62;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // labelAdvertencia
            // 
            this.labelAdvertencia.AutoSize = true;
            this.labelAdvertencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdvertencia.ForeColor = System.Drawing.Color.Maroon;
            this.labelAdvertencia.Location = new System.Drawing.Point(142, 185);
            this.labelAdvertencia.Name = "labelAdvertencia";
            this.labelAdvertencia.Size = new System.Drawing.Size(95, 18);
            this.labelAdvertencia.TabIndex = 63;
            this.labelAdvertencia.Text = "Advertencia";
            this.labelAdvertencia.Visible = false;
            // 
            // iconNoSeePasword
            // 
            this.iconNoSeePasword.BackColor = System.Drawing.SystemColors.Control;
            this.iconNoSeePasword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconNoSeePasword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.iconNoSeePasword.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconNoSeePasword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNoSeePasword.IconSize = 21;
            this.iconNoSeePasword.Location = new System.Drawing.Point(308, 292);
            this.iconNoSeePasword.Name = "iconNoSeePasword";
            this.iconNoSeePasword.Size = new System.Drawing.Size(21, 22);
            this.iconNoSeePasword.TabIndex = 64;
            this.iconNoSeePasword.TabStop = false;
            this.iconNoSeePasword.Click += new System.EventHandler(this.iconNoSeePasword_Click);
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
            this.iconSeePasword.Location = new System.Drawing.Point(308, 292);
            this.iconSeePasword.Name = "iconSeePasword";
            this.iconSeePasword.Size = new System.Drawing.Size(21, 22);
            this.iconSeePasword.TabIndex = 65;
            this.iconSeePasword.TabStop = false;
            this.iconSeePasword.Visible = false;
            this.iconSeePasword.Click += new System.EventHandler(this.iconSeePasword_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 114);
            this.panel2.TabIndex = 53;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI.Properties.Resources.Fondo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::UI.Properties.Resources.Contraseña;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormRestaurarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 421);
            this.Controls.Add(this.iconSeePasword);
            this.Controls.Add(this.iconNoSeePasword);
            this.Controls.Add(this.labelAdvertencia);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textIdentificacion);
            this.Controls.Add(this.labelIdentificacion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelBarraVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRestaurarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRestaurarContraseña";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormRestaurarContraseña_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNoSeePasword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeePasword)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private FontAwesome.Sharp.IconButton btnVolver;
        private System.Windows.Forms.Panel panelBarraVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIdentificacion;
        private System.Windows.Forms.Label labelIdentificacion;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Label labelAdvertencia;
        private FontAwesome.Sharp.IconPictureBox iconNoSeePasword;
        private FontAwesome.Sharp.IconPictureBox iconSeePasword;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}