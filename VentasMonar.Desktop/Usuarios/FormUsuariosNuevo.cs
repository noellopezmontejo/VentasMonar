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
    public partial class FormUsuariosNuevo : PageBase
    {
        public FormUsuariosNuevo()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            ConnectDropDownList(this.cboTipoUsuario,"Select CveTipoUsuario, Descripcion From CatTipoUsuario");
            ConnectCheckListBox(this.chkListAlmacen, "Select CveAlmacen, Descripcion From CatAlmacen");
            this.txtNombre.Focus();
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
                    Clases.c_Usuarios Us = new Clases.c_Usuarios();
                    Us.Nombre = txtNombreCompleto.Text;
                    Us.User_name = txtNombre.Text;
                    Us.Password = txtContrasenia.Text;
                    Us.CveTipoUsuario = int.Parse(cboTipoUsuario.SelectedValue.ToString());
                    Us.CveEstatus = 1;
                    Us.Actualiza = 0;
                    Us.CveUsuarioActual = 0;

                    if(Us.SaveData()>0)
                    {
                        MessageBox.Show("Datos guardados con exito...", "Validación de Datos");
                    }
                    else
                    {
                        MessageBox.Show("Favor de revisar el error", "Validación de Datos");
                    }
                }
            }
        }
        void Guardar()
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
                    using (SqlConnection con = new SqlConnection(Strconexion))
                    {

                        con.Open();
                        int UserExists = alreadyexists("user_name", "Usuarios", this.txtNombre.Text);

                        if (UserExists == 0)
                        {
                            string insertarUsuario = "Insert Into Usuarios(user_name, Password, Nombre, CveTipoUsuario) Values('" + this.txtNombre.Text + "','" + this.txtContrasenia.Text + "','" + this.txtNombreCompleto.Text + "'," + this.cboTipoUsuario.SelectedValue.ToString() + ")";
                            SqlCommand CmdInsert = new SqlCommand(insertarUsuario, con);
                            int insert;

                            insert = CmdInsert.ExecuteNonQuery();
                            con.Close();
                            if (insert != 0)
                            {
                                MessageBox.Show("El usuario ha sido añadido al sistema exitosamente", "Añadir Usuario");
                                string queryUsuarios = "Select CveUser, user_name, Nombre, CT.Descripcion As TipoUsuario From Usuarios U Left Join CatTipoUsuario CT on U.CveTipoUsuario=CT.CveTipoUsuario";
                                loadDataGrid(this.GridUsersInstanceRef, queryUsuarios);

                                this.txtNombre.Text = "";
                                this.txtNombreCompleto.Text = "";
                                this.txtContrasenia.Text = "";
                                this.txtConfirmarContrasenia.Text = "";
                                this.txtNombre.Focus();
                            }
                            else MessageBox.Show("Ha ocurrido un error al intentar Añadir el Usuario, comuniquese con el administrador del sistema", "Error al Añadir Usuario");
                        }
                        else
                        {
                            MessageBox.Show("El usuario que desea añadir ya existe en el sistema");
                        }
                        con.Close();
                    }
                }
                else MessageBox.Show("Las contraseñas no coinciden, asegurese de que sean iguales");
            }
            else
                MessageBox.Show("Favor de verificar las casillas con puntos rojos y colocar la informacion correspondiente", "Error al Crear Usuario", MessageBoxButtons.OK);

        }
    }
}

