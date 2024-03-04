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
    public partial class FormIngresarClaveGlobal : PageBase
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

        public FormIngresarClaveGlobal()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string queryLogin = "SELECT user_name, password, CveTipoUsuario AS NivelAcceso FROM Usuarios WHERE user_name='" + this.txtUsuario.Text + "'";

            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdLogin = new SqlCommand(queryLogin, con);
                SqlDataReader readerLogin = cmdLogin.ExecuteReader();
                if (readerLogin.HasRows)
                {
                    readerLogin.Read();
                    if (readerLogin["password"].ToString() == this.txtContrasenia.Text)
                    {
                        if (int.Parse(readerLogin["NivelAcceso"].ToString()) <= int.Parse(this.Nivel.ToString()))
                        {
                            this.Formulario.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos pero el usuario ingresado tampoco tiene permisos para acceder a este modulo", "Error Seguridad");
                            this.txtUsuario.Text = "";
                            this.txtContrasenia.Text = "";
                            this.txtUsuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos pero la contraseña o el nombre de usuario ingresados son incorrectos", "Error Acceso");
                        this.txtUsuario.Text = "";
                        this.txtContrasenia.Text = "";
                        this.txtUsuario.Focus();
                    }
                }
            }
        }
    }
}

