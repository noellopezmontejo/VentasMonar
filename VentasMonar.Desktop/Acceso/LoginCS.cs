using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using VentasMonar.Desktop.Shared.Layout;

namespace VentasMonar.Desktop
{
    public partial class LoginCS : PageBase
    {
        public LoginCS()
        {
            InitializeComponent();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool waiting = true;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            proceso();
        }
       
        private void Login_Load(object sender, EventArgs e)
        {
            Conexion();
            txtUsuario.Focus();
        }
        private void proceso()
        {
           


            string NombreEmpresa = GetStringField("Nombre", "CatEmpresa", "CveEmpresa", "1");
            string queryLogin = "SELECT CveUser, user_name, Password, CveTipoUsuario, Nombre FROM Usuarios WHERE user_name='" + this.txtUsuario.Text + "'";

            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdLogin = new SqlCommand(queryLogin, con);
                SqlDataReader readerLogin = cmdLogin.ExecuteReader();
                if (readerLogin.HasRows)
                {
                    readerLogin.Read();
                    if (readerLogin["password"].ToString() == this.txtContraseña.Text)
                    {
                        Menu.FormMenuPrincipal FormMenuPrincipal = new Menu.FormMenuPrincipal();
                        FormMenuPrincipal.Text += "   " + NombreEmpresa + "      Usuario Conectado:(  " + readerLogin["Nombre"].ToString() + "  )";
                        FormMenuPrincipal.NivelAcceso1 = readerLogin.GetInt32(readerLogin.GetOrdinal("CveTipoUsuario"));
                        FormMenuPrincipal.Conexion = Strconexion;
                        UserName.user_name = this.txtUsuario.Text;
                        CveUser.Cve_User = int.Parse(readerLogin["CveUser"].ToString());
                        FormMenuPrincipal.CveUser = int.Parse(readerLogin["CveUser"].ToString());
                        NivelAcceso.nivelacceso = readerLogin.GetInt32(readerLogin.GetOrdinal("CveTipoUsuario"));
                        FormMenuPrincipal.LoginInstanceRef = this;



                        this.Hide();

                        var width = Screen.PrimaryScreen.Bounds.Width;
                        var height = Screen.PrimaryScreen.Bounds.Height;

                        FormMenuPrincipal.Location = new Point(height, 0);
                        FormMenuPrincipal.Show();

                    }
                    else
                    {
                        MessageBox.Show("Su nombre de usuario o contraseña son incorrectos, intentelo de nuevo por favor");
                        this.txtUsuario.Text = "";
                        this.txtContraseña.Text = "";
                        this.txtUsuario.Focus();

                    }
                }
                else
                {

                    MessageBox.Show("Su nombre de usuario o contraseña son incorrectos, intentelo de nuevo por favor");
                    this.txtUsuario.Text = "";
                    this.txtContraseña.Text = "";
                    this.txtUsuario.Focus();
                }
                con.Close();
            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            
        }




        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                proceso();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos Sql (*.sql)|*.sql|sql (*.sql)|*.sql";
            openFileDialog.InitialDirectory = "C:\\Respaldo";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;

                DialogResult result;
                result = MessageBox.Show("¿Esta seguro de Restaurar los datos en este momento?", "Restauración de base de datos", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cIniArray mINI = new cIniArray();
                    Encriptar Enn = new Encriptar();
                    string Fecha = DateTime.Now.ToShortDateString();
                    string Fecha2 = Fecha.Replace("/", "_");
                    string ruta = FileName;
                    string Archivo = Application.StartupPath + @"\Conexion.ini";
                    string Servidor = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "ServerName", ""));
                    string BaseDatos = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "BaseDatos", ""));
                    string Usuario = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Usuario", ""));
                    string Password = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Password", ""));

                    string comando = "mysql.exe --host=" + Servidor + " --user=" + Usuario + " --password=" + Password + " " + BaseDatos + " < " + ruta;

                    bool resp = creararchivobat(comando, "C:\\Respaldo" + @"\restaura.bat");

                    if (resp)
                    {
                        Process.Start("C:\\Respaldo" + @"\restaura.bat");
                        MessageBox.Show("se ha generado la restauracion de los datos con exito..", "Respaldo de Información");
                        File.Delete("C:\\Respaldo" + @"\restaura.bat");
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar restaurar la base de datos, favor de avisar al administrador", "Validación de Datos");
                    }
                }

            }
        }
        public bool creararchivobat(string comando, string ruta)
        {
            bool entro = false;
            try
            {
                StreamWriter reader = new StreamWriter(ruta);
                reader.Write(comando);
                reader.Close();
                reader.Dispose();
                entro = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                entro = false;
            }
            return entro;
        }
        
    }
}

