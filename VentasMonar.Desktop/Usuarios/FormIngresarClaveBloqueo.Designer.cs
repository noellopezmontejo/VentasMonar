namespace VentasMonar.Desktop.Usuarios
{
    partial class FormIngresarClaveBloqueo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIngresarClaveBloqueo));
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.cmdCancelar = new Telerik.WinControls.UI.RadButton();
            this.cmdAceptar = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(400, 36);
            this.lblTitulo.Text = "Autorización";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContrasenia);
            this.groupBox1.Controls.Add(this.lblContrasenia);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.lblNombreUsuario);
            this.groupBox1.Location = new System.Drawing.Point(11, 39);
            this.groupBox1.Size = new System.Drawing.Size(377, 123);
            this.groupBox1.TabIndex = 0;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia.Location = new System.Drawing.Point(174, 78);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(188, 28);
            this.txtContrasenia.TabIndex = 1;
            this.txtContrasenia.UseSystemPasswordChar = true;
            this.txtContrasenia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrasenia_KeyDown);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(22, 81);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(89, 21);
            this.lblContrasenia.TabIndex = 20;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsuario.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(174, 34);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(188, 28);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(22, 37);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(146, 21);
            this.lblNombreUsuario.TabIndex = 18;
            this.lblNombreUsuario.Text = "Nombre de Usuario";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancelar.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.Color.Black;
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.Location = new System.Drawing.Point(272, 168);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(106, 32);
            this.cmdCancelar.TabIndex = 2;
            this.cmdCancelar.Text = "Salir";
            this.cmdCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.Transparent;
            this.cmdAceptar.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.ForeColor = System.Drawing.Color.Black;
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.Location = new System.Drawing.Point(141, 168);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(106, 32);
            this.cmdAceptar.TabIndex = 1;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FormIngresarClaveBloqueo
            // 
            this.ClientSize = new System.Drawing.Size(400, 203);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIngresarClaveBloqueo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Solicitud de Autorizacion";
            this.Load += new System.EventHandler(this.FormIngresarClaveBloqueo_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.cmdAceptar, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label lblContrasenia;
        protected System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private Telerik.WinControls.UI.RadButton cmdCancelar;
        private Telerik.WinControls.UI.RadButton cmdAceptar;
    }
}
