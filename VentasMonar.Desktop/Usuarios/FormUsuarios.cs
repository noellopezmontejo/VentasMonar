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
    public partial class FormUsuarios : PageBase
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormTiposDeServicio_Load(object sender, EventArgs e)
        {
            this.dataGrid.AutoGenerateColumns = false;
            string query = "Select CveUser, user_name, Nombre, CT.Descripcion As TipoUsuario From Usuarios U Left Join CatTipoUsuario CT on U.CveTipoUsuario=CT.CveTipoUsuario";
            loadDataGrid(this.dataGrid, query);
            this.txtBusqueda.Focus();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            FormUsuariosNuevo NuevoUsuario = new FormUsuariosNuevo();
            //NuevoUsuario.MdiParent = FormMenuPrincipal.ActiveForm;
            NuevoUsuario.GridUsersInstanceRef = this.dataGrid;
            NuevoUsuario.ShowDialog(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.Rows.Count > 0)
            {
                
                DialogResult result;
                result = MessageBox.Show("¿Está seguro que desea eliminar el tipo de servicio?", "Eliminar Tipo de Servicio", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                   

                    string CveTipoServicio = this.dataGrid.CurrentRow.Cells[0].Value.ToString();
                    string querydelete = "DELETE FROM CatTipoServicio WHERE CveTipoServicio=" + CveTipoServicio;
                    performupdatequery(querydelete);

                    string query = "SELECT * FROM CatTipoServicio ORDER BY Descripcion";
                    loadDataGrid(this.dataGrid, query);

                    MessageBox.Show("Se ha  eliminado el Tipo de Servicio de la base de datos", "Eliminar Tipo de Servicio");
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.Rows.Count > 0)
            {
                FormEditarUsuario EditarUsuario = new FormEditarUsuario();
                string CveUsuario = this.dataGrid.CurrentRow.Cells[0].Value.ToString();
                //EditarUsuario.MdiParent = FormMenuPrincipal.ActiveForm;
                EditarUsuario.CveUsuario = CveUsuario;
                EditarUsuario.GridUsersInstanceRef = this.dataGrid;
                EditarUsuario.ShowDialog(this);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            Catalogos.Reportes.FormReportesListados ReportesListados = new Catalogos.Reportes.FormReportesListados();
            ReportesListados.TipoReporte = "ListaServicios";
            ReportesListados.Show();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string query = "Select CveUser, user_name, Nombre, CT.Descripcion As TipoUsuario From Usuarios U Left Join CatTipoUsuario CT on U.CveTipoUsuario=CT.CveTipoUsuario Where Nombre Like '%" + txtBusqueda.Text + "%' ORDER BY Nombre";
            loadDataGrid(this.dataGrid, query);
            this.txtBusqueda.Focus();
        }
    }
}

