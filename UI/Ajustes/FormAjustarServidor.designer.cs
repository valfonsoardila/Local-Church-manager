
namespace UI
{
    partial class FormAjustarServidor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.panelAvanzado = new System.Windows.Forms.Panel();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.pictureCadenaConexion = new System.Windows.Forms.PictureBox();
            this.btnBuscarCadenaConexion = new System.Windows.Forms.Button();
            this.panelTituloAvanzado = new System.Windows.Forms.Panel();
            this.labelInstruccionAvanzado = new System.Windows.Forms.Label();
            this.labelTituloAvanzado = new System.Windows.Forms.Label();
            this.textCadenaConexion = new System.Windows.Forms.TextBox();
            this.labelCadenaConexion = new System.Windows.Forms.Label();
            this.btnModificarConexion = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panelAvanzado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCadenaConexion)).BeginInit();
            this.panelTituloAvanzado.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(477, 27);
            this.panel1.TabIndex = 1;
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
            this.btnCerrar.Location = new System.Drawing.Point(448, 4);
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
            this.btnMinimizar.Location = new System.Drawing.Point(424, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panelAvanzado
            // 
            this.panelAvanzado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAvanzado.Controls.Add(this.labelConnectionString);
            this.panelAvanzado.Controls.Add(this.pictureCadenaConexion);
            this.panelAvanzado.Controls.Add(this.btnBuscarCadenaConexion);
            this.panelAvanzado.Controls.Add(this.panelTituloAvanzado);
            this.panelAvanzado.Controls.Add(this.textCadenaConexion);
            this.panelAvanzado.Controls.Add(this.labelCadenaConexion);
            this.panelAvanzado.Location = new System.Drawing.Point(10, 33);
            this.panelAvanzado.Name = "panelAvanzado";
            this.panelAvanzado.Size = new System.Drawing.Size(457, 82);
            this.panelAvanzado.TabIndex = 95;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(167, 33);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(11, 13);
            this.labelConnectionString.TabIndex = 87;
            this.labelConnectionString.Text = "*";
            // 
            // pictureCadenaConexion
            // 
            this.pictureCadenaConexion.Image = global::UI.Properties.Resources.conexion;
            this.pictureCadenaConexion.Location = new System.Drawing.Point(17, 26);
            this.pictureCadenaConexion.Name = "pictureCadenaConexion";
            this.pictureCadenaConexion.Size = new System.Drawing.Size(23, 26);
            this.pictureCadenaConexion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCadenaConexion.TabIndex = 86;
            this.pictureCadenaConexion.TabStop = false;
            // 
            // btnBuscarCadenaConexion
            // 
            this.btnBuscarCadenaConexion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarCadenaConexion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarCadenaConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCadenaConexion.Location = new System.Drawing.Point(361, 51);
            this.btnBuscarCadenaConexion.Name = "btnBuscarCadenaConexion";
            this.btnBuscarCadenaConexion.Size = new System.Drawing.Size(37, 22);
            this.btnBuscarCadenaConexion.TabIndex = 82;
            this.btnBuscarCadenaConexion.Text = "...";
            this.btnBuscarCadenaConexion.UseVisualStyleBackColor = true;
            // 
            // panelTituloAvanzado
            // 
            this.panelTituloAvanzado.Controls.Add(this.labelInstruccionAvanzado);
            this.panelTituloAvanzado.Controls.Add(this.labelTituloAvanzado);
            this.panelTituloAvanzado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTituloAvanzado.Location = new System.Drawing.Point(0, 0);
            this.panelTituloAvanzado.Name = "panelTituloAvanzado";
            this.panelTituloAvanzado.Size = new System.Drawing.Size(457, 25);
            this.panelTituloAvanzado.TabIndex = 0;
            // 
            // labelInstruccionAvanzado
            // 
            this.labelInstruccionAvanzado.AutoSize = true;
            this.labelInstruccionAvanzado.Location = new System.Drawing.Point(83, 6);
            this.labelInstruccionAvanzado.Name = "labelInstruccionAvanzado";
            this.labelInstruccionAvanzado.Size = new System.Drawing.Size(131, 13);
            this.labelInstruccionAvanzado.TabIndex = 87;
            this.labelInstruccionAvanzado.Text = "(Solo para programadores)";
            // 
            // labelTituloAvanzado
            // 
            this.labelTituloAvanzado.AutoSize = true;
            this.labelTituloAvanzado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloAvanzado.Location = new System.Drawing.Point(5, 4);
            this.labelTituloAvanzado.Name = "labelTituloAvanzado";
            this.labelTituloAvanzado.Size = new System.Drawing.Size(77, 16);
            this.labelTituloAvanzado.TabIndex = 84;
            this.labelTituloAvanzado.Text = "Avanzado";
            // 
            // textCadenaConexion
            // 
            this.textCadenaConexion.Location = new System.Drawing.Point(12, 51);
            this.textCadenaConexion.Name = "textCadenaConexion";
            this.textCadenaConexion.Size = new System.Drawing.Size(344, 20);
            this.textCadenaConexion.TabIndex = 61;
            this.textCadenaConexion.TextChanged += new System.EventHandler(this.textCadenaConexion_TextChanged);
            // 
            // labelCadenaConexion
            // 
            this.labelCadenaConexion.AutoSize = true;
            this.labelCadenaConexion.Location = new System.Drawing.Point(43, 33);
            this.labelCadenaConexion.Name = "labelCadenaConexion";
            this.labelCadenaConexion.Size = new System.Drawing.Size(118, 13);
            this.labelCadenaConexion.TabIndex = 60;
            this.labelCadenaConexion.Text = "Modificar Conexion BD:";
            // 
            // btnModificarConexion
            // 
            this.btnModificarConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnModificarConexion.FlatAppearance.BorderSize = 0;
            this.btnModificarConexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnModificarConexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnModificarConexion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarConexion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificarConexion.IconChar = FontAwesome.Sharp.IconChar.PooBolt;
            this.btnModificarConexion.IconColor = System.Drawing.Color.White;
            this.btnModificarConexion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModificarConexion.IconSize = 30;
            this.btnModificarConexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarConexion.Location = new System.Drawing.Point(165, 131);
            this.btnModificarConexion.Name = "btnModificarConexion";
            this.btnModificarConexion.Size = new System.Drawing.Size(123, 35);
            this.btnModificarConexion.TabIndex = 96;
            this.btnModificarConexion.Text = "Modificar Conexion";
            this.btnModificarConexion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarConexion.UseVisualStyleBackColor = false;
            this.btnModificarConexion.Click += new System.EventHandler(this.btnModificarConexion_Click);
            // 
            // FormAjustarServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 178);
            this.Controls.Add(this.btnModificarConexion);
            this.Controls.Add(this.panelAvanzado);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAjustarServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAjustarServidor";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panelAvanzado.ResumeLayout(false);
            this.panelAvanzado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCadenaConexion)).EndInit();
            this.panelTituloAvanzado.ResumeLayout(false);
            this.panelTituloAvanzado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private System.Windows.Forms.Panel panelAvanzado;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.PictureBox pictureCadenaConexion;
        private System.Windows.Forms.Button btnBuscarCadenaConexion;
        private System.Windows.Forms.Panel panelTituloAvanzado;
        private System.Windows.Forms.Label labelInstruccionAvanzado;
        private System.Windows.Forms.Label labelTituloAvanzado;
        private System.Windows.Forms.TextBox textCadenaConexion;
        private System.Windows.Forms.Label labelCadenaConexion;
        private FontAwesome.Sharp.IconButton btnModificarConexion;
    }
}