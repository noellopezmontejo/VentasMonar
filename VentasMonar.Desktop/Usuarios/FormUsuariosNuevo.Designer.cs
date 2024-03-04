namespace VentasMonar.Desktop.Usuarios
{
    partial class FormUsuariosNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuariosNuevo));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.txtConfirmarContrasenia = new System.Windows.Forms.TextBox();
            this.lblConfirmarContrasenia = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.cboTipoUsuario = new System.Windows.Forms.ComboBox();
            this.lblPermisosUsuario = new System.Windows.Forms.Label();
            this.errorUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmdCancelar = new Telerik.WinControls.UI.RadButton();
            this.cmdAceptar = new Telerik.WinControls.UI.RadButton();
            this.chkListAlmacen = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAceptar)).BeginInit();
            
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListAlmacen);
            this.groupBox1.Controls.Add(this.cboTipoUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblPermisosUsuario);
            this.groupBox1.Controls.Add(this.txtNombreCompleto);
            this.groupBox1.Controls.Add(this.lblNombreCompleto);
            this.groupBox1.Controls.Add(this.txtConfirmarContrasenia);
            this.groupBox1.Controls.Add(this.lblConfirmarContrasenia);
            this.groupBox1.Controls.Add(this.txtContrasenia);
            this.groupBox1.Controls.Add(this.lblContrasenia);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombreUsuario);
            this.groupBox1.Size = new System.Drawing.Size(474, 314);
            this.groupBox1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(475, 27);
            this.lblTitulo.Text = "Nuevo Usuario";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtNombre.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(291, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(23, 29);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(111, 14);
            this.lblNombreUsuario.TabIndex = 10;
            this.lblNombreUsuario.Text = "Nombre de Usuario";
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia.Location = new System.Drawing.Point(161, 70);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(291, 22);
            this.txtContrasenia.TabIndex = 1;
            this.txtContrasenia.UseSystemPasswordChar = true;
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(23, 73);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(68, 14);
            this.lblContrasenia.TabIndex = 12;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // txtConfirmarContrasenia
            // 
            this.txtConfirmarContrasenia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContrasenia.Location = new System.Drawing.Point(161, 107);
            this.txtConfirmarContrasenia.Name = "txtConfirmarContrasenia";
            this.txtConfirmarContrasenia.Size = new System.Drawing.Size(291, 22);
            this.txtConfirmarContrasenia.TabIndex = 2;
            this.txtConfirmarContrasenia.UseSystemPasswordChar = true;
            // 
            // lblConfirmarContrasenia
            // 
            this.lblConfirmarContrasenia.AutoSize = true;
            this.lblConfirmarContrasenia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarContrasenia.Location = new System.Drawing.Point(23, 110);
            this.lblConfirmarContrasenia.Name = "lblConfirmarContrasenia";
            this.lblConfirmarContrasenia.Size = new System.Drawing.Size(123, 14);
            this.lblConfirmarContrasenia.TabIndex = 14;
            this.lblConfirmarContrasenia.Text = "Confirmar Contraseña";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompleto.Location = new System.Drawing.Point(161, 147);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(291, 22);
            this.txtNombreCompleto.TabIndex = 3;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.Location = new System.Drawing.Point(23, 150);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(106, 14);
            this.lblNombreCompleto.TabIndex = 16;
            this.lblNombreCompleto.Text = "Nombre Completo";
            // 
            // cboTipoUsuario
            // 
            this.cboTipoUsuario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoUsuario.FormattingEnabled = true;
            this.cboTipoUsuario.Location = new System.Drawing.Point(161, 184);
            this.cboTipoUsuario.Name = "cboTipoUsuario";
            this.cboTipoUsuario.Size = new System.Drawing.Size(215, 22);
            this.cboTipoUsuario.TabIndex = 4;
            // 
            // lblPermisosUsuario
            // 
            this.lblPermisosUsuario.AutoSize = true;
            this.lblPermisosUsuario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermisosUsuario.Location = new System.Drawing.Point(23, 187);
            this.lblPermisosUsuario.Name = "lblPermisosUsuario";
            this.lblPermisosUsuario.Size = new System.Drawing.Size(117, 14);
            this.lblPermisosUsuario.TabIndex = 20;
            this.lblPermisosUsuario.Text = "Permisos del Usuario";
            // 
            // errorUsuario
            // 
            this.errorUsuario.ContainerControl = this;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.AllowShowFocusCues = true;
            this.cmdCancelar.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.Color.Black;
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.Location = new System.Drawing.Point(380, 377);
            this.cmdCancelar.Name = "cmdCancelar";
            // 
            // 
            // 
            this.cmdCancelar.RootElement.ForeColor = System.Drawing.Color.Black;
            this.cmdCancelar.Size = new System.Drawing.Size(106, 32);
            this.cmdCancelar.TabIndex = 11;
            this.cmdCancelar.Text = "Salir";
            this.cmdCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.AllowShowFocusCues = true;
            this.cmdAceptar.BackColor = System.Drawing.Color.Transparent;
            this.cmdAceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.ForeColor = System.Drawing.Color.Black;
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.Location = new System.Drawing.Point(249, 377);
            this.cmdAceptar.Name = "cmdAceptar";
            // 
            // 
            // 
            this.cmdAceptar.RootElement.ForeColor = System.Drawing.Color.Black;
            this.cmdAceptar.Size = new System.Drawing.Size(106, 32);
            this.cmdAceptar.TabIndex = 10;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // chkListAlmacen
            // 
            this.chkListAlmacen.FormattingEnabled = true;
            this.chkListAlmacen.Location = new System.Drawing.Point(161, 212);
            this.chkListAlmacen.Name = "chkListAlmacen";
            this.chkListAlmacen.Size = new System.Drawing.Size(215, 94);
            this.chkListAlmacen.TabIndex = 22;
            this.chkListAlmacen.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Acceso a Datos";
            this.label1.Visible = false;
            // 
            // FormUsuariosNuevo
            // 
            this.ClientSize = new System.Drawing.Size(499, 421);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUsuariosNuevo";
            // 
            // 
            // 
            
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdAceptar, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAceptar)).EndInit();
            
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblNombreCompleto;
        protected System.Windows.Forms.TextBox txtConfirmarContrasenia;
        private System.Windows.Forms.Label lblConfirmarContrasenia;
        protected System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label lblContrasenia;
        protected System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombreUsuario;
        protected System.Windows.Forms.ComboBox cboTipoUsuario;
        private System.Windows.Forms.Label lblPermisosUsuario;
        private System.Windows.Forms.ErrorProvider errorUsuario;
        private Telerik.WinControls.UI.RadButton cmdCancelar;
        private Telerik.WinControls.UI.RadButton cmdAceptar;
        private System.Windows.Forms.CheckedListBox chkListAlmacen;
        private System.Windows.Forms.Label label1;
    }
}
