namespace VentasMonar.Desktop
{
    partial class LoginCS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginCS));
            this.radProgressBarElement1 = new Telerik.WinControls.UI.RadProgressBarElement();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtContraseña = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtUsuario = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.None;
            this.lblTitulo.Location = new System.Drawing.Point(731, 474);
            this.lblTitulo.Size = new System.Drawing.Size(28, 27);
            this.lblTitulo.Text = "Inicio de Sesion";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(574, 366);
            this.groupBox1.Size = new System.Drawing.Size(10, 149);
            this.groupBox1.Visible = false;
            // 
            // radProgressBarElement1
            // 
            this.radProgressBarElement1.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.radProgressBarElement1.ClipDrawing = true;
            this.radProgressBarElement1.DefaultSize = new System.Drawing.Size(130, 16);
            this.radProgressBarElement1.Margin = new System.Windows.Forms.Padding(1);
            this.radProgressBarElement1.Name = "radProgressBarElement1";
            this.radProgressBarElement1.SeparatorColor1 = System.Drawing.Color.White;
            this.radProgressBarElement1.SeparatorColor2 = System.Drawing.Color.White;
            this.radProgressBarElement1.SeparatorColor3 = System.Drawing.Color.White;
            this.radProgressBarElement1.SeparatorColor4 = System.Drawing.Color.White;
            this.radProgressBarElement1.SeparatorGradientAngle = 0;
            this.radProgressBarElement1.SeparatorGradientPercentage1 = 0.4F;
            this.radProgressBarElement1.SeparatorGradientPercentage2 = 0.6F;
            this.radProgressBarElement1.SeparatorNumberOfColors = 2;
            this.radProgressBarElement1.StepWidth = 14;
            this.radProgressBarElement1.SweepAngle = 90;
            // 
            // radLabelElement1
            // 
            this.radLabelElement1.Margin = new System.Windows.Forms.Padding(1);
            this.radLabelElement1.Name = "radLabelElement1";
            this.radLabelElement1.Text = "Proceso";
            this.radLabelElement1.TextWrap = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(547, 133);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(77)))), ((int)(((byte)(128)))));
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Location = new System.Drawing.Point(0, 133);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(547, 75);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(77)))), ((int)(((byte)(128)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(66, 287);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(155, 42);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Entrar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(105, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Acceso";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(109, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtContraseña);
            this.panel3.Controls.Add(this.txtUsuario);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Location = new System.Drawing.Point(125, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 350);
            this.panel3.TabIndex = 0;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseña.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContraseña.HintForeColor = System.Drawing.Color.Empty;
            this.txtContraseña.HintText = "";
            this.txtContraseña.isPassword = true;
            this.txtContraseña.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtContraseña.LineIdleColor = System.Drawing.Color.Gray;
            this.txtContraseña.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtContraseña.LineThickness = 4;
            this.txtContraseña.Location = new System.Drawing.Point(29, 204);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(245, 33);
            this.txtContraseña.TabIndex = 1;
            this.txtContraseña.Text = "Contraseña";
            this.txtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsuario.HintForeColor = System.Drawing.Color.Empty;
            this.txtUsuario.HintText = "ID de Usuario";
            this.txtUsuario.isPassword = false;
            this.txtUsuario.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtUsuario.LineIdleColor = System.Drawing.Color.Gray;
            this.txtUsuario.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtUsuario.LineThickness = 4;
            this.txtUsuario.Location = new System.Drawing.Point(29, 143);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(245, 33);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // LoginCS
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = null;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(547, 547);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
            this.Name = "LoginCS";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = true;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadProgressBarElement radProgressBarElement1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Catalogos.Reportes.CachedVendedoresLista cachedVendedoresLista1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtContraseña;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUsuario;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
