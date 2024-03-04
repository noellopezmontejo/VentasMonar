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
    public partial class FormIngresarClaveBloqueo : PageBase
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

        private bool blFirma;

        public bool Firma
        {
            get { return blFirma; }
            set { blFirma = value; }
        }

        private string strTexto;


        public string Texto
        {
            get { return strTexto; }
            set { strTexto = value; }
        }

        

        public FormIngresarClaveBloqueo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ejecuta();
        }
        private void ejecuta()
        {
            string NombreEmpresa = GetStringField("Nombre", "CatEmpresa", "CveEmpresa", "1");
            string queryLogin = "SELECT user_name, Password, CveTipoUsuario AS NivelAcceso, Nombre, CveUser FROM Usuarios WHERE user_name='" + this.txtUsuario.Text + "'";

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


                        Text = "   " + NombreEmpresa + "      Usuario Conectado:(  " + readerLogin["Nombre"].ToString() + "  )";
                        //FormMenuPrincipal.NivelAcceso1 = readerLogin.GetInt32(readerLogin.GetOrdinal("CveTipoUsuario"));
                        //FormMenuPrincipal.Conexion = strconexion;
                        UserName.user_name = this.txtUsuario.Text;
                        CveUser.Cve_User = int.Parse(readerLogin["CveUser"].ToString());
                        //FormMenuPrincipal.CveUser = int.Parse(readerLogin["CveUser"].ToString());
                        //NivelAcceso.nivelacceso = readerLogin.GetInt32(readerLogin.GetOrdinal("CveTipoUsuario"));
                        //FormMenuPrincipal.LoginInstanceRef = this;
                        DialogResult = DialogResult.OK;
                        this.Close();

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
        private void FormIngresarClaveBloqueo_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContrasenia.Focus();
            }
        }

        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ejecuta();
            }
        }
    }
}

