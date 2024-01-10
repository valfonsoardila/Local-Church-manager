namespace UI
{
    partial class FormGenerarDocumento
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
            this.panelHeaderGenerarInforme = new System.Windows.Forms.Panel();
            this.btnAtras = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRol = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textTotalPag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkedListReportes = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAbrirInforme = new FontAwesome.Sharp.IconButton();
            this.btnImprimirInforme = new FontAwesome.Sharp.IconButton();
            this.btnEliminarInforme = new FontAwesome.Sharp.IconButton();
            this.panelContenedorReportes = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBuscar = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panelHeaderGenerarInforme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelContenedorReportes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeaderGenerarInforme
            // 
            this.panelHeaderGenerarInforme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.panelHeaderGenerarInforme.Controls.Add(this.btnAtras);
            this.panelHeaderGenerarInforme.Controls.Add(this.label1);
            this.panelHeaderGenerarInforme.Controls.Add(this.textRol);
            this.panelHeaderGenerarInforme.Controls.Add(this.label16);
            this.panelHeaderGenerarInforme.Controls.Add(this.textTotalPag);
            this.panelHeaderGenerarInforme.Controls.Add(this.label2);
            this.panelHeaderGenerarInforme.Controls.Add(this.pictureBox1);
            this.panelHeaderGenerarInforme.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderGenerarInforme.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderGenerarInforme.Name = "panelHeaderGenerarInforme";
            this.panelHeaderGenerarInforme.Size = new System.Drawing.Size(661, 59);
            this.panelHeaderGenerarInforme.TabIndex = 5;
            this.panelHeaderGenerarInforme.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeaderGenerarInforme_MouseDown);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAtras.IconChar = FontAwesome.Sharp.IconChar.TimesSquare;
            this.btnAtras.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAtras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAtras.IconSize = 28;
            this.btnAtras.Location = new System.Drawing.Point(632, 0);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(28, 28);
            this.btnAtras.TabIndex = 8;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(491, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "#Pag:";
            // 
            // textRol
            // 
            this.textRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.textRol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRol.ForeColor = System.Drawing.SystemColors.Info;
            this.textRol.Location = new System.Drawing.Point(363, 16);
            this.textRol.Name = "textRol";
            this.textRol.Size = new System.Drawing.Size(124, 28);
            this.textRol.TabIndex = 18;
            this.textRol.Text = "Secretario";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Yellow;
            this.label16.Location = new System.Drawing.Point(312, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 24);
            this.label16.TabIndex = 17;
            this.label16.Text = "Rol:";
            // 
            // textTotalPag
            // 
            this.textTotalPag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotalPag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.textTotalPag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTotalPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalPag.ForeColor = System.Drawing.SystemColors.Info;
            this.textTotalPag.Location = new System.Drawing.Point(564, 16);
            this.textTotalPag.Name = "textTotalPag";
            this.textTotalPag.Size = new System.Drawing.Size(75, 28);
            this.textTotalPag.TabIndex = 14;
            this.textTotalPag.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(61, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Generar documento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.doc_ico;
            this.pictureBox1.Location = new System.Drawing.Point(10, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // checkedListReportes
            // 
            this.checkedListReportes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkedListReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListReportes.FormattingEnabled = true;
            this.checkedListReportes.Items.AddRange(new object[] {
            "Generar Informe General ",
            "Generar Informe Individual",
            "Generar Informe Presupuestal"});
            this.checkedListReportes.Location = new System.Drawing.Point(0, 35);
            this.checkedListReportes.Name = "checkedListReportes";
            this.checkedListReportes.ScrollAlwaysVisible = true;
            this.checkedListReportes.Size = new System.Drawing.Size(341, 52);
            this.checkedListReportes.Sorted = true;
            this.checkedListReportes.TabIndex = 6;
            this.checkedListReportes.SelectedIndexChanged += new System.EventHandler(this.checkedListReportes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(200, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Elegir tipo de informe";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel2.Controls.Add(this.btnAbrirInforme, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnImprimirInforme, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEliminarInforme, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 184);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(661, 44);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // btnAbrirInforme
            // 
            this.btnAbrirInforme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnAbrirInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbrirInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirInforme.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAbrirInforme.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.btnAbrirInforme.IconColor = System.Drawing.Color.White;
            this.btnAbrirInforme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAbrirInforme.IconSize = 30;
            this.btnAbrirInforme.Location = new System.Drawing.Point(3, 3);
            this.btnAbrirInforme.Name = "btnAbrirInforme";
            this.btnAbrirInforme.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAbrirInforme.Size = new System.Drawing.Size(221, 38);
            this.btnAbrirInforme.TabIndex = 1;
            this.btnAbrirInforme.Text = "Generar y abrir";
            this.btnAbrirInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrirInforme.UseVisualStyleBackColor = false;
            this.btnAbrirInforme.Click += new System.EventHandler(this.btnAbrirInforme_Click);
            // 
            // btnImprimirInforme
            // 
            this.btnImprimirInforme.BackColor = System.Drawing.Color.Orange;
            this.btnImprimirInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimirInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirInforme.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImprimirInforme.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimirInforme.IconColor = System.Drawing.Color.Black;
            this.btnImprimirInforme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimirInforme.IconSize = 30;
            this.btnImprimirInforme.Location = new System.Drawing.Point(457, 3);
            this.btnImprimirInforme.Name = "btnImprimirInforme";
            this.btnImprimirInforme.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnImprimirInforme.Size = new System.Drawing.Size(201, 38);
            this.btnImprimirInforme.TabIndex = 15;
            this.btnImprimirInforme.Text = "Imprimir informe";
            this.btnImprimirInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirInforme.UseVisualStyleBackColor = false;
            this.btnImprimirInforme.Click += new System.EventHandler(this.btnImprimirInforme_Click);
            // 
            // btnEliminarInforme
            // 
            this.btnEliminarInforme.BackColor = System.Drawing.Color.Maroon;
            this.btnEliminarInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminarInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarInforme.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminarInforme.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminarInforme.IconColor = System.Drawing.Color.White;
            this.btnEliminarInforme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarInforme.IconSize = 30;
            this.btnEliminarInforme.Location = new System.Drawing.Point(230, 3);
            this.btnEliminarInforme.Name = "btnEliminarInforme";
            this.btnEliminarInforme.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEliminarInforme.Size = new System.Drawing.Size(221, 38);
            this.btnEliminarInforme.TabIndex = 16;
            this.btnEliminarInforme.Text = "Eliminar informe";
            this.btnEliminarInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarInforme.UseVisualStyleBackColor = false;
            this.btnEliminarInforme.Click += new System.EventHandler(this.btnEliminarInforme_Click);
            // 
            // panelContenedorReportes
            // 
            this.panelContenedorReportes.Controls.Add(this.panel2);
            this.panelContenedorReportes.Controls.Add(this.checkedListReportes);
            this.panelContenedorReportes.Location = new System.Drawing.Point(161, 91);
            this.panelContenedorReportes.Name = "panelContenedorReportes";
            this.panelContenedorReportes.Size = new System.Drawing.Size(341, 87);
            this.panelContenedorReportes.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Controls.Add(this.textBuscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 35);
            this.panel2.TabIndex = 8;
            // 
            // textBuscar
            // 
            this.textBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscar.Location = new System.Drawing.Point(86, 2);
            this.textBuscar.Multiline = true;
            this.textBuscar.Name = "textBuscar";
            this.textBuscar.Size = new System.Drawing.Size(159, 29);
            this.textBuscar.TabIndex = 0;
            this.textBuscar.Text = "Buscar";
            this.textBuscar.TextChanged += new System.EventHandler(this.textBuscar_TextChanged);
            this.textBuscar.Enter += new System.EventHandler(this.textBuscar_Enter);
            this.textBuscar.Leave += new System.EventHandler(this.textBuscar_Leave);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 30;
            this.iconPictureBox1.Location = new System.Drawing.Point(3, 4);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox1.TabIndex = 9;
            this.iconPictureBox1.TabStop = false;
            // 
            // FormGenerarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 228);
            this.Controls.Add(this.panelContenedorReportes);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelHeaderGenerarInforme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGenerarDocumento";
            this.Text = "FormGenerarDocumento";
            this.Load += new System.EventHandler(this.FormGenerarDocumento_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGenerarDocumento_MouseDown);
            this.panelHeaderGenerarInforme.ResumeLayout(false);
            this.panelHeaderGenerarInforme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelContenedorReportes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderGenerarInforme;
        private System.Windows.Forms.TextBox textRol;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textTotalPag;
        private FontAwesome.Sharp.IconPictureBox btnAtras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListReportes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnEliminarInforme;
        private FontAwesome.Sharp.IconButton btnAbrirInforme;
        private FontAwesome.Sharp.IconButton btnImprimirInforme;
        private System.Windows.Forms.Panel panelContenedorReportes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBuscar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}