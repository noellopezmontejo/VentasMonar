using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using VentasMonar.Desktop.Shared.Layout;

namespace VentasMonar.Desktop.Servidor
{
    public partial class FormServer : PageBase 
    {
        public FormServer()
        {
            InitializeComponent();
        }
        private cIniArray mINI = new cIniArray();
        private string Archivo = Application.StartupPath + @"\Conexion.ini";
        private void FormFacturas_Load(object sender, EventArgs e)
        {
            
            
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            bool Servidor = ValidarCajas(txtServidor, "Favor de escribir el Nombre de Servidor", errorFactura);
            bool BaseDatos = ValidarCajas(txtBasedeDatos, "Favor de escribir el Nombre de la Base de Datos", errorFactura);
            bool Usuario = ValidarCajas(txtUsuario, "Favor de escribir el usuario", errorFactura);
            bool Password = ValidarCajas(txtPassword, "Favor de escribir la contraseña", errorFactura);
            bool PV = ValidarCajas(txtPassword, "Favor de escribir la Contraseña PV", errorFactura);

            if (Servidor && BaseDatos && Usuario && Password)
            {
                string strconexion2 = "Database=" + txtBasedeDatos.Text + "; Data Source=" + txtServidor.Text + ";User Id=" + txtUsuario.Text + ";Password=" + txtPassword.Text;

                try
                {
                    using (SqlConnection con = new SqlConnection(strconexion2))
                    {
                        con.Open();
                        if (con.State.ToString() == "Open")
                        {
                            MessageBox.Show("Conexión establecida con el servidor : " + txtServidor.Text + "   Version " + con.ServerVersion);
                            int credencial = 0;
                            if (chkCredencial.Checked)
                            {
                                credencial = 1;
                            }

                            Encriptar En = new Encriptar();
                            mINI.IniWrite(Archivo, "Configuracion", "ServerName", En.EncriptarCadena(txtServidor.Text));
                            mINI.IniWrite(Archivo, "Configuracion", "BaseDatos", En.EncriptarCadena(txtBasedeDatos.Text));
                            mINI.IniWrite(Archivo, "Configuracion", "Usuario", En.EncriptarCadena(txtUsuario.Text));
                            mINI.IniWrite(Archivo, "Configuracion", "Password", En.EncriptarCadena(txtPassword.Text));
                            mINI.IniWrite(Archivo, "Configuracion", "PasswordPV", En.EncriptarCadena(txtPV.Text));
                            mINI.IniWrite(Archivo, "Configuracion", "Credencial", En.EncriptarCadena(credencial.ToString()));

                            MessageBox.Show("Los datos se han almacenado con exito... Favor de ingresar nuevamente al sistema");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo establecer la conexion con el servidor");
                        }
                        con.Close();
                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
                
                

            }
            else
            {
                MessageBox.Show("Favor de verificar las casillas con puntos rojos", "Validar Casillas");
            }


        }

        private void cboxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}