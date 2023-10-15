
namespace UI
{
    partial class FormInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicioSesion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelInicioSesion = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPasword = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPasword = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.linkLabelRestaurarContraseña = new System.Windows.Forms.LinkLabel();
            this.linkLabelRegistrarUsuario = new System.Windows.Forms.LinkLabel();
            this.labelAdvertencia = new System.Windows.Forms.Label();
            this.iconAdvertencia = new FontAwesome.Sharp.IconPictureBox();
            this.iconSeePasword = new FontAwesome.Sharp.IconPictureBox();
            this.iconNoSeePasword = new FontAwesome.Sharp.IconPictureBox();
            this.iconPassword = new FontAwesome.Sharp.IconPictureBox();
            this.iconUser = new FontAwesome.Sharp.IconPictureBox();
            this.btnAjustarServidor = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAdvertencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeePasword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNoSeePasword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(375, 27);
            this.panel1.TabIndex = 0;
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
            this.btnCerrar.Location = new System.Drawing.Point(346, 4);
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
            this.btnMinimizar.Location = new System.Drawing.Point(322, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureLogo);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 133);
            this.panel2.TabIndex = 1;
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.BackgroundImage = global::UI.Properties.Resources.Fondo;
            this.pictureLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureLogo.Image = global::UI.Properties.Resources.logo;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(375, 133);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::UI.Properties.Resources.Fondo;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // labelInicioSesion
            // 
            this.labelInicioSesion.AutoSize = true;
            this.labelInicioSesion.BackColor = System.Drawing.Color.Transparent;
            this.labelInicioSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicioSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelInicioSesion.Image = global::UI.Properties.Resources.Fondo;
            this.labelInicioSesion.Location = new System.Drawing.Point(137, 5);
            this.labelInicioSesion.Name = "labelInicioSesion";
            this.labelInicioSesion.Size = new System.Drawing.Size(115, 20);
            this.labelInicioSesion.TabIndex = 1;
            this.labelInicioSesion.Text = "Iniciar sesion";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(58, 209);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(65, 16);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "Usuario:";
            // 
            // labelPasword
            // 
            this.labelPasword.AutoSize = true;
            this.labelPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasword.Location = new System.Drawing.Point(58, 237);
            this.labelPasword.Name = "labelPasword";
            this.labelPasword.Size = new System.Drawing.Size(90, 16);
            this.labelPasword.TabIndex = 3;
            this.labelPasword.Text = "Contraseña:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxUser.Location = new System.Drawing.Point(150, 202);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxUser.Size = new System.Drawing.Size(160, 24);
            this.textBoxUser.TabIndex = 4;
            this.textBoxUser.Text = "@Usuario";
            this.textBoxUser.TextChanged += new System.EventHandler(this.textBoxUser_TextChanged);
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxUser_Enter);
            this.textBoxUser.Leave += new System.EventHandler(this.textBoxUser_Leave);
            // 
            // textBoxPasword
            // 
            this.textBoxPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxPasword.Location = new System.Drawing.Point(150, 231);
            this.textBoxPasword.Name = "textBoxPasword";
            this.textBoxPasword.Size = new System.Drawing.Size(160, 24);
            this.textBoxPasword.TabIndex = 5;
            this.textBoxPasword.Text = "Contraseña";
            this.textBoxPasword.TextChanged += new System.EventHandler(this.textBoxPasword_TextChanged);
            this.textBoxPasword.Enter += new System.EventHandler(this.textBoxPasword_Enter);
            this.textBoxPasword.Leave += new System.EventHandler(this.textBoxPasword_Leave);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(131, 319);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(110, 28);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // linkLabelRestaurarContraseña
            // 
            this.linkLabelRestaurarContraseña.AutoSize = true;
            this.linkLabelRestaurarContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelRestaurarContraseña.Location = new System.Drawing.Point(147, 279);
            this.linkLabelRestaurarContraseña.Name = "linkLabelRestaurarContraseña";
            this.linkLabelRestaurarContraseña.Size = new System.Drawing.Size(131, 13);
            this.linkLabelRestaurarContraseña.TabIndex = 11;
            this.linkLabelRestaurarContraseña.TabStop = true;
            this.linkLabelRestaurarContraseña.Text = "¿Olvidaste tu contraseña?";
            this.linkLabelRestaurarContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRestaurarContraseña_LinkClicked);
            // 
            // linkLabelRegistrarUsuario
            // 
            this.linkLabelRegistrarUsuario.AutoSize = true;
            this.linkLabelRegistrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelRegistrarUsuario.Location = new System.Drawing.Point(116, 296);
            this.linkLabelRegistrarUsuario.Name = "linkLabelRegistrarUsuario";
            this.linkLabelRegistrarUsuario.Size = new System.Drawing.Size(151, 13);
            this.linkLabelRegistrarUsuario.TabIndex = 12;
            this.linkLabelRegistrarUsuario.TabStop = true;
            this.linkLabelRegistrarUsuario.Text = "¿No tienes cuenta? Registrate";
            this.linkLabelRegistrarUsuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegistrarUsuario_LinkClicked);
            // 
            // labelAdvertencia
            // 
            this.labelAdvertencia.AutoSize = true;
            this.labelAdvertencia.ForeColor = System.Drawing.Color.Maroon;
            this.labelAdvertencia.Location = new System.Drawing.Point(173, 261);
            this.labelAdvertencia.Name = "labelAdvertencia";
            this.labelAdvertencia.Size = new System.Drawing.Size(64, 13);
            this.labelAdvertencia.TabIndex = 14;
            this.labelAdvertencia.Text = "Advertencia";
            this.labelAdvertencia.Visible = false;
            // 
            // iconAdvertencia
            // 
            this.iconAdvertencia.BackColor = System.Drawing.SystemColors.Control;
            this.iconAdvertencia.ForeColor = System.Drawing.Color.Maroon;
            this.iconAdvertencia.IconChar = FontAwesome.Sharp.IconChar.Warning;
            this.iconAdvertencia.IconColor = System.Drawing.Color.Maroon;
            this.iconAdvertencia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconAdvertencia.IconSize = 20;
            this.iconAdvertencia.Location = new System.Drawing.Point(150, 257);
            this.iconAdvertencia.Name = "iconAdvertencia";
            this.iconAdvertencia.Size = new System.Drawing.Size(20, 20);
            this.iconAdvertencia.TabIndex = 13;
            this.iconAdvertencia.TabStop = false;
            this.iconAdvertencia.Visible = false;
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
            this.iconSeePasword.Location = new System.Drawing.Point(316, 233);
            this.iconSeePasword.Name = "iconSeePasword";
            this.iconSeePasword.Size = new System.Drawing.Size(21, 22);
            this.iconSeePasword.TabIndex = 10;
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
            this.iconNoSeePasword.Location = new System.Drawing.Point(316, 233);
            this.iconNoSeePasword.Name = "iconNoSeePasword";
            this.iconNoSeePasword.Size = new System.Drawing.Size(21, 22);
            this.iconNoSeePasword.TabIndex = 9;
            this.iconNoSeePasword.TabStop = false;
            this.iconNoSeePasword.Click += new System.EventHandler(this.iconNoSeePasword_Click);
            // 
            // iconPassword
            // 
            this.iconPassword.BackColor = System.Drawing.SystemColors.Control;
            this.iconPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPassword.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPassword.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPassword.IconSize = 21;
            this.iconPassword.Location = new System.Drawing.Point(36, 235);
            this.iconPassword.Name = "iconPassword";
            this.iconPassword.Size = new System.Drawing.Size(21, 22);
            this.iconPassword.TabIndex = 8;
            this.iconPassword.TabStop = false;
            // 
            // iconUser
            // 
            this.iconUser.BackColor = System.Drawing.SystemColors.Control;
            this.iconUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconUser.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconUser.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconUser.IconSize = 21;
            this.iconUser.Location = new System.Drawing.Point(36, 207);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(21, 22);
            this.iconUser.TabIndex = 7;
            this.iconUser.TabStop = false;
            // 
            // btnAjustarServidor
            // 
            this.btnAjustarServidor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnAjustarServidor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.btnAjustarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAjustarServidor.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnAjustarServidor.IconColor = System.Drawing.Color.White;
            this.btnAjustarServidor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAjustarServidor.IconSize = 20;
            this.btnAjustarServidor.Location = new System.Drawing.Point(331, 2);
            this.btnAjustarServidor.Name = "btnAjustarServidor";
            this.btnAjustarServidor.Size = new System.Drawing.Size(35, 25);
            this.btnAjustarServidor.TabIndex = 15;
            this.btnAjustarServidor.UseVisualStyleBackColor = true;
            this.btnAjustarServidor.Visible = false;
            this.btnAjustarServidor.Click += new System.EventHandler(this.btnAjustarServidor_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::UI.Properties.Resources.Fondo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.labelInicioSesion);
            this.panel3.Controls.Add(this.btnAjustarServidor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 29);
            this.panel3.TabIndex = 16;
            // 
            // FormInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 375);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelAdvertencia);
            this.Controls.Add(this.iconAdvertencia);
            this.Controls.Add(this.linkLabelRegistrarUsuario);
            this.Controls.Add(this.linkLabelRestaurarContraseña);
            this.Controls.Add(this.iconSeePasword);
            this.Controls.Add(this.iconNoSeePasword);
            this.Controls.Add(this.iconPassword);
            this.Controls.Add(this.iconUser);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.textBoxPasword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelPasword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInicioSesion";
            this.Opacity = 0.88D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInicioSesion_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAdvertencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeePasword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNoSeePasword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelInicioSesion;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPasword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPasword;
        private System.Windows.Forms.Button btnIngresar;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private FontAwesome.Sharp.IconPictureBox iconUser;
        private FontAwesome.Sharp.IconPictureBox iconPassword;
        private FontAwesome.Sharp.IconPictureBox iconNoSeePasword;
        private FontAwesome.Sharp.IconPictureBox iconSeePasword;
        private System.Windows.Forms.LinkLabel linkLabelRestaurarContraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabelRegistrarUsuario;
        private FontAwesome.Sharp.IconPictureBox iconAdvertencia;
        private System.Windows.Forms.Label labelAdvertencia;
        private FontAwesome.Sharp.IconButton btnAjustarServidor;
        private System.Windows.Forms.Panel panel3;
    }
}