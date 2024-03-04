using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using VentasMonar.Desktop.Shared.Layout;

namespace VentasMonar.Desktop.Usuarios
{
    public partial class FormEditarUsuario : PageBase
    {
        public FormEditarUsuario()
        {
            InitializeComponent();
        }

        private string User_Name;
        public string user_name
        {
            get
            {
                return User_Name;
            }
            set
            {
                User_Name = value;
            }
        }

        private DataGridView gridusers_InstanceRef = null;
        public DataGridView GridUsersInstanceRef
        {
            get
            {
                return gridusers_InstanceRef;
            }
            set
            {
                gridusers_InstanceRef = value;
            }
        }
        private string strCveUsuario;
        public string CveUsuario
        {
            get
            {
                return strCveUsuario;
            }
            set
            {
                strCveUsuario = value;
            }
        }


        private void FormEditarUsuario_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                string queryusuario = "SELECT * FROM Usuarios where CveUser='" + CveUsuario + "'";
                SqlCommand cmdusuario = new SqlCommand(queryusuario, con);
                SqlDataReader reader = cmdusuario.ExecuteReader();

                reader.Read();
                this.txtNombre.Text = reader["user_name"].ToString();
                this.txtNombreCompleto.Text = reader["Nombre"].ToString();
                this.txtContrasenia.Text = reader["password"].ToString();
                this.txtConfirmarContrasenia.Text = reader["password"].ToString();
                string CveTipoUsuario = reader["CveTipoUsuario"].ToString();
                reader.Close();

                string QueryAcceso="Select * From UsuarioAlmacen Where CveUser='" + CveUsuario + "'";
                SqlCommand cmdAlmacenUsuario=new SqlCommand(QueryAcceso,con);
                SqlDataReader readerAlmacenUsuario=cmdAlmacenUsuario.ExecuteReader();

                
                
                while (readerAlmacenUsuario.Read())
                {

                }




                this.txtNombre.Enabled = false;
                ConnectDropDownListEdit(this.cboTipoUsuario,  "CatTipoUsuario", "CveTipoUsuario", "Descripcion", CveTipoUsuario);
                ConnectCheckListBox(this.chkListAlmacen, "Select CveAlmacen, Descripcion From CatAlmacen");
                 
                /*for (int i = 0; i < chkListAlmacen.Items.Count; i++)
                {
                    if(

                    chkListAlmacen.SetItemChecked(i, true);

                }*/

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool VNombreUsuario, VNombreCompleto, VContrasenia, VConfirmarContrasenia;

            VNombreUsuario = ValidarCajas(this.txtNombre, "Por favor escriba el Nombre de Usuario", this.errorUsuario);
            VNombreCompleto = ValidarCajas(this.txtNombreCompleto, "Por favor escriba el Nombre Completo del Usuario", this.errorUsuario);
            VContrasenia = ValidarCajas(this.txtContrasenia, "Por favor escriba la Contraseña del Usuario", this.errorUsuario);
            VConfirmarContrasenia = ValidarCajas(this.txtConfirmarContrasenia, "Por favor escriba la Confirmación de la Contraseña del Usuario", this.errorUsuario);

            if (VNombreUsuario && VNombreCompleto && VContrasenia && VContrasenia)
            {
                if (this.txtContrasenia.Text == this.txtConfirmarContrasenia.Text)
                {
                    string updateUsers = "UPDATE Usuarios SET Nombre='" + this.txtNombreCompleto.Text + "', Password='" + this.txtContrasenia.Text + "', CveTipoUsuario=" + this.cboTipoUsuario.SelectedValue.ToString() + " WHERE CveUser=" + CveUsuario ;
                    int updated = performupdatequery(updateUsers);
                    if (updated != 0)
                    {
                        MessageBox.Show("Los datos del usuario se han actualizado con éxito");
                        if (this.GridUsersInstanceRef != null)
                        {
                            string queryUsuarios = "Select CveUser, user_name, Nombre, CT.Descripcion As TipoUsuario From Usuarios U Left Join CatTipoUsuario CT on U.CveTipoUsuario=CT.CveTipoUsuario";
                            loadDataGrid(this.GridUsersInstanceRef, queryUsuarios);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al intentar actualizar los datos, comuniquese con el administrador del sistema");
                    }
                }
                else MessageBox.Show("Las contraseñas no coinciden, asegurese de que sean iguales");
            }
            else
                MessageBox.Show("Favor de verificar las casillas con puntos rojos y colocar la informacion correspondiente", "Error al Crear Usuario", MessageBoxButtons.OK);
        }
    }
}

