namespace VentasMonar.Desktop.Servidor
{
    partial class FormServer
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
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblCondicionesPago = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.CmdCancelar = new System.Windows.Forms.Button();
            this.CmdGuardar = new System.Windows.Forms.Button();
            this.errorFactura = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBasedeDatos = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCredencial = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(326, 27);
            this.lblTitulo.Text = "Configuración de Servidor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCredencial);
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Controls.Add(this.CmdCancelar);
            this.groupBox1.Controls.Add(this.lblFolio);
            this.groupBox1.Controls.Add(this.CmdGuardar);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.lblCondicionesPago);
            this.groupBox1.Controls.Add(this.txtBasedeDatos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblImporte);
            this.groupBox1.Controls.Add(this.txtPV);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Size = new System.Drawing.Size(300, 210);
            this.groupBox1.TabIndex = 0;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(8, 19);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(132, 19);
            this.lblProveedor.TabIndex = 29;
            this.lblProveedor.Text = "Nombre Servidor";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(117, 72);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(154, 25);
            this.txtUsuario.TabIndex = 2;
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.Location = new System.Drawing.Point(8, 74);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(65, 19);
            this.lblFolio.TabIndex = 28;
            this.lblFolio.Text = "Usuario";
            // 
            // lblCondicionesPago
            // 
            this.lblCondicionesPago.AutoSize = true;
            this.lblCondicionesPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicionesPago.Location = new System.Drawing.Point(8, 47);
            this.lblCondicionesPago.Name = "lblCondicionesPago";
            this.lblCondicionesPago.Size = new System.Drawing.Size(116, 19);
            this.lblCondicionesPago.TabIndex = 37;
            this.lblCondicionesPago.Text = "Base de Datos";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(117, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(154, 25);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(8, 101);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(93, 19);
            this.lblImporte.TabIndex = 44;
            this.lblImporte.Text = "Contraseña";
            // 
            // CmdCancelar
            // 
            this.CmdCancelar.Location = new System.Drawing.Point(196, 181);
            this.CmdCancelar.Name = "CmdCancelar";
            this.CmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.CmdCancelar.TabIndex = 7;
            this.CmdCancelar.Text = "Cancelar";
            this.CmdCancelar.UseVisualStyleBackColor = true;
            this.CmdCancelar.Click += new System.EventHandler(this.CmdCancelar_Click);
            // 
            // CmdGuardar
            // 
            this.CmdGuardar.Location = new System.Drawing.Point(115, 181);
            this.CmdGuardar.Name = "CmdGuardar";
            this.CmdGuardar.Size = new System.Drawing.Size(75, 23);
            this.CmdGuardar.TabIndex = 6;
            this.CmdGuardar.Text = "Guardar";
            this.CmdGuardar.UseVisualStyleBackColor = true;
            this.CmdGuardar.Click += new System.EventHandler(this.CmdGuardar_Click);
            // 
            // errorFactura
            // 
            this.errorFactura.ContainerControl = this;
            // 
            // txtBasedeDatos
            // 
            this.txtBasedeDatos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasedeDatos.Location = new System.Drawing.Point(117, 45);
            this.txtBasedeDatos.Name = "txtBasedeDatos";
            this.txtBasedeDatos.Size = new System.Drawing.Size(154, 25);
            this.txtBasedeDatos.TabIndex = 1;
            // 
            // txtServidor
            // 
            this.txtServidor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidor.Location = new System.Drawing.Point(117, 19);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(154, 25);
            this.txtServidor.TabIndex = 0;
            // 
            // txtPV
            // 
            this.txtPV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPV.Location = new System.Drawing.Point(117, 126);
            this.txtPV.Name = "txtPV";
            this.txtPV.PasswordChar = '*';
            this.txtPV.Size = new System.Drawing.Size(154, 25);
            this.txtPV.TabIndex = 4;
            this.txtPV.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "Contraseña PV";
            // 
            // chkCredencial
            // 
            this.chkCredencial.AutoSize = true;
            this.chkCredencial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCredencial.Font = new System.Drawing.Font("Arial", 9.75F);
            this.chkCredencial.Location = new System.Drawing.Point(42, 153);
            this.chkCredencial.Name = "chkCredencial";
            this.chkCredencial.Size = new System.Drawing.Size(110, 23);
            this.chkCredencial.TabIndex = 5;
            this.chkCredencial.Text = "Credencial";
            this.chkCredencial.UseVisualStyleBackColor = true;
            // 
            // FormServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(326, 265);
            this.MaximizeBox = false;
            this.Name = "FormServer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.FormFacturas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblCondicionesPago;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Button CmdCancelar;
        private System.Windows.Forms.Button CmdGuardar;
        private System.Windows.Forms.ErrorProvider errorFactura;
        private System.Windows.Forms.TextBox txtBasedeDatos;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.CheckBox chkCredencial;
    }
}