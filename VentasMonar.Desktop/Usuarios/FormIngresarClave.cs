using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using VentasMonar.Desktop.Shared.Layout;

namespace VentasMonar.Desktop.Usuarios
{
    public partial class FormIngresarClave : PageBase
    {
        private Form formulario;
        public Form Formulario
        {
            get
            {
                return formulario;
            }
            set
            {
                formulario = value;
            }
        }

        private int nivel;
        public int Nivel
        {
            get
            {
                return nivel;
            }
            set
            {
                nivel = value;
            }
        }
        private int intopcion;
        public int opcion
        {
            get
            {
                return intopcion;
            }
            set
            {
                intopcion = value;
            }
        }
        

        public FormIngresarClave()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != "" && txtContrasenia.Text.Trim() != "")
            {
                IngresaClave_MiEvento(txtUsuario.Text, txtContrasenia.Text, opcion);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Favor de escribir el usuario y contraseña para proceder con la autorizacion", "Validacion de Acceso");
            }
        }
        public delegate void DelegadoMensaje(string Usuario, string Contraseña, int opcion);
        public event DelegadoMensaje IngresaClave_MiEvento;

        private void FormIngresarClave_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasenia.Text="";
        }

        private void FormIngresarClave_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void FormIngresarClave_Activated(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
        }

    }
}

