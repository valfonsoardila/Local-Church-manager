
namespace UI
{
    partial class FormActivador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActivador));
            this.labelTituloActivador = new System.Windows.Forms.Label();
            this.labelText1 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.textLicencia = new System.Windows.Forms.TextBox();
            this.btnActivarProducto = new System.Windows.Forms.Button();
            this.pictureLlaveLicencia = new System.Windows.Forms.PictureBox();
            this.pictureLicenciaExpirada = new System.Windows.Forms.PictureBox();
            this.pictureLicenciaActivada = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTextLicencia1 = new System.Windows.Forms.Label();
            this.labelCantidadDiasLicencia = new System.Windows.Forms.Label();
            this.labelTextLicencia2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLlaveLicencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLicenciaExpirada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLicenciaActivada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTituloActivador
            // 
            this.labelTituloActivador.AutoSize = true;
            this.labelTituloActivador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloActivador.Location = new System.Drawing.Point(140, 38);
            this.labelTituloActivador.Name = "labelTituloActivador";
            this.labelTituloActivador.Size = new System.Drawing.Size(225, 24);
            this.labelTituloActivador.TabIndex = 1;
            this.labelTituloActivador.Text = "Activacion de producto";
            // 
            // labelText1
            // 
            this.labelText1.AutoSize = true;
            this.labelText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText1.Location = new System.Drawing.Point(10, 90);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(489, 15);
            this.labelText1.TabIndex = 2;
            this.labelText1.Text = "El tiempo de uso de los componentes del software estan desactivados ponte en cont" +
    "acto";
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText2.Location = new System.Drawing.Point(11, 107);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(164, 15);
            this.labelText2.TabIndex = 3;
            this.labelText2.Text = "con tu proveedor de software";
            // 
            // textLicencia
            // 
            this.textLicencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLicencia.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textLicencia.Location = new System.Drawing.Point(119, 138);
            this.textLicencia.Multiline = true;
            this.textLicencia.Name = "textLicencia";
            this.textLicencia.Size = new System.Drawing.Size(305, 24);
            this.textLicencia.TabIndex = 7;
            this.textLicencia.Text = "XXXX-XXXX-XXXX-XXXX-2023";
            this.textLicencia.Enter += new System.EventHandler(this.textLicencia_Enter);
            this.textLicencia.Leave += new System.EventHandler(this.textLicencia_Leave);
            // 
            // btnActivarProducto
            // 
            this.btnActivarProducto.Location = new System.Drawing.Point(203, 176);
            this.btnActivarProducto.Name = "btnActivarProducto";
            this.btnActivarProducto.Size = new System.Drawing.Size(103, 34);
            this.btnActivarProducto.TabIndex = 8;
            this.btnActivarProducto.Text = "Activar Producto";
            this.btnActivarProducto.UseVisualStyleBackColor = true;
            this.btnActivarProducto.Click += new System.EventHandler(this.btnActivarProducto_Click);
            // 
            // pictureLlaveLicencia
            // 
            this.pictureLlaveLicencia.Image = ((System.Drawing.Image)(resources.GetObject("pictureLlaveLicencia.Image")));
            this.pictureLlaveLicencia.Location = new System.Drawing.Point(71, 136);
            this.pictureLlaveLicencia.Name = "pictureLlaveLicencia";
            this.pictureLlaveLicencia.Size = new System.Drawing.Size(44, 30);
            this.pictureLlaveLicencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLlaveLicencia.TabIndex = 6;
            this.pictureLlaveLicencia.TabStop = false;
            // 
            // pictureLicenciaExpirada
            // 
            this.pictureLicenciaExpirada.Image = global::UI.Properties.Resources.licencia_false;
            this.pictureLicenciaExpirada.Location = new System.Drawing.Point(392, 13);
            this.pictureLicenciaExpirada.Name = "pictureLicenciaExpirada";
            this.pictureLicenciaExpirada.Size = new System.Drawing.Size(79, 63);
            this.pictureLicenciaExpirada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLicenciaExpirada.TabIndex = 5;
            this.pictureLicenciaExpirada.TabStop = false;
            this.pictureLicenciaExpirada.Visible = false;
            // 
            // pictureLicenciaActivada
            // 
            this.pictureLicenciaActivada.Image = global::UI.Properties.Resources.licencia_true;
            this.pictureLicenciaActivada.Location = new System.Drawing.Point(392, 15);
            this.pictureLicenciaActivada.Name = "pictureLicenciaActivada";
            this.pictureLicenciaActivada.Size = new System.Drawing.Size(79, 61);
            this.pictureLicenciaActivada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLicenciaActivada.TabIndex = 4;
            this.pictureLicenciaActivada.TabStop = false;
            this.pictureLicenciaActivada.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelTextLicencia1
            // 
            this.labelTextLicencia1.AutoSize = true;
            this.labelTextLicencia1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextLicencia1.Location = new System.Drawing.Point(19, 125);
            this.labelTextLicencia1.Name = "labelTextLicencia1";
            this.labelTextLicencia1.Size = new System.Drawing.Size(115, 24);
            this.labelTextLicencia1.TabIndex = 9;
            this.labelTextLicencia1.Text = "Usted tiene";
            this.labelTextLicencia1.Visible = false;
            // 
            // labelCantidadDiasLicencia
            // 
            this.labelCantidadDiasLicencia.AutoSize = true;
            this.labelCantidadDiasLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidadDiasLicencia.Location = new System.Drawing.Point(128, 126);
            this.labelCantidadDiasLicencia.Name = "labelCantidadDiasLicencia";
            this.labelCantidadDiasLicencia.Size = new System.Drawing.Size(43, 24);
            this.labelCantidadDiasLicencia.TabIndex = 10;
            this.labelCantidadDiasLicencia.Text = "300";
            this.labelCantidadDiasLicencia.Visible = false;
            // 
            // labelTextLicencia2
            // 
            this.labelTextLicencia2.AutoSize = true;
            this.labelTextLicencia2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextLicencia2.Location = new System.Drawing.Point(165, 126);
            this.labelTextLicencia2.Name = "labelTextLicencia2";
            this.labelTextLicencia2.Size = new System.Drawing.Size(321, 24);
            this.labelTextLicencia2.TabIndex = 11;
            this.labelTextLicencia2.Text = "de licencia de producto restantes";
            this.labelTextLicencia2.Visible = false;
            // 
            // FormActivador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 224);
            this.Controls.Add(this.labelTextLicencia2);
            this.Controls.Add(this.labelCantidadDiasLicencia);
            this.Controls.Add(this.labelTextLicencia1);
            this.Controls.Add(this.btnActivarProducto);
            this.Controls.Add(this.textLicencia);
            this.Controls.Add(this.pictureLlaveLicencia);
            this.Controls.Add(this.pictureLicenciaExpirada);
            this.Controls.Add(this.pictureLicenciaActivada);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.labelText1);
            this.Controls.Add(this.labelTituloActivador);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormActivador";
            this.Opacity = 0.95D;
            ((System.ComponentModel.ISupportInitialize)(this.pictureLlaveLicencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLicenciaExpirada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLicenciaActivada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTituloActivador;
        private System.Windows.Forms.Label labelText1;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.PictureBox pictureLicenciaActivada;
        private System.Windows.Forms.PictureBox pictureLicenciaExpirada;
        private System.Windows.Forms.PictureBox pictureLlaveLicencia;
        private System.Windows.Forms.TextBox textLicencia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnActivarProducto;
        private System.Windows.Forms.Label labelTextLicencia1;
        private System.Windows.Forms.Label labelCantidadDiasLicencia;
        private System.Windows.Forms.Label labelTextLicencia2;
    }
}