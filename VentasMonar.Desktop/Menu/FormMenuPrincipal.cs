using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using Telerik.WinControls.UI;
using System.Configuration;
using VentasMonar.Desktop.Clases;
using VentasMonar.Desktop;
using VentasMonar.Desktop.Usuarios;
using VentasMonar.Desktop.Shared.Layout;

namespace VentasMonar.Desktop.Menu
{
    public partial class FormMenuPrincipal : RadForm
    {
        private int childFormNumber = 0;
        PageBase pg = new PageBase();
        public FormMenuPrincipal()
        {
            InitializeComponent();

        }
        private Form login_InstanceRef = null;
        public Form LoginInstanceRef
        {
            get
            {
                return login_InstanceRef;
            }
            set
            {
                login_InstanceRef = value;
            }
        }

        private string strConexion;
        public string Conexion
        {
            get
            {
                return strConexion;
            }
            set
            {
                strConexion = value;
            }
        }
        private int nivelacceso1;
        public int NivelAcceso1
        {
            get
            {
                return nivelacceso1;
            }
            set
            {
                nivelacceso1 = value;
            }
        }
        private int intCveUser;
        public int CveUser
        {
            get
            {
                return intCveUser;
            }
            set
            {
                intCveUser = value;
            }
        }

        public int CvePerfil { get; set; }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Clientes.FormClientes Clientes = new Catalogos.Clientes.FormClientes();
            //Clientes.MdiParent = this;
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2 || NivelAcceso1 == 3)
            {
                Clientes.ShowDialog(this);
            }
            else
            {
                checkAccess(Clientes, NivelAcceso1);
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
        


        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.FormProveedores Proveedores = new Catalogos.FormProveedores();
            Proveedores.MdiParent = this;
            Proveedores.Show();
        }

       

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            Inventario.FormProductos Productos = new Inventario.FormProductos();
            Productos.MdiParent = this;
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Productos.Show();
            }
            else
            {
                checkAccess(Productos, NivelAcceso1);
            }
            //Productos.MdiParent = FormMenuPrincipal.ActiveForm;

        }



        private void ValidarPermisoPerfilMenu()
        {

            if (CvePerfil != 1)
            {
                DeshabilitarCampos();

                DataTable _dtResult = c_Usuarios.ValidarPermisoPerfilMenu(CvePerfil, 1);

                foreach (DataRow item in _dtResult.Rows)
                {

                    switch (int.Parse(item["CveModulo"].ToString()))
                    {
                        case 1:
                            toolStripMenuItem7.Visible = true;
                            break;
                        case 2:
                            toolStripMenuItem16.Visible = true;
                            break;
                        case 3:
                            categoriasToolStripMenuItem.Visible = true;
                            break;
                        case 4:
                            toolStripMenuItem18.Visible = true;
                            break;
                        case 5:
                            toolStripMenuItem17.Visible = true;
                            break;
                        case 6:
                            anaquelToolStripMenuItem.Visible = true;
                            break;
                        case 7:
                            repisaToolStripMenuItem.Visible = true;
                            break;
                        case 8:
                            toolStripMenuItem20.Visible = true;
                            break;
                        case 9:
                            tablaDeDescuentoToolStripMenuItem.Visible = true;
                            break;
                        case 10:
                            cambioDePrecioMasivoToolStripMenuItem.Visible = true;
                            break;
                        case 11:
                            ComprasTool.Visible = true;
                            break;
                        case 12:
                            ajustesToolStripMenuItem.Visible = true;
                            mermasToolStripMenuItem1.Visible = true;
                            break;

                    }

                   



                }
            }
          
        }

        private void DeshabilitarCampos()
        {
            toolStripMenuItem7.Visible = false;
            productosToolStripMenuItem.Visible = false; // 1 Productos
            toolStripMenuItem16.Visible = false; //2 Marcas
            categoriasToolStripMenuItem.Visible = false; // 3 Categorias
            toolStripMenuItem18.Visible = false; // 4 Lineas
            toolStripMenuItem17.Visible = false; // 5 Familias
            anaquelToolStripMenuItem.Visible = false; // 6 Anaquel
            repisaToolStripMenuItem.Visible = false; // 7 Repisa
            toolStripMenuItem20.Visible = false; // 8 Almacenes

            tablaDeDescuentoToolStripMenuItem.Visible = false; //9 Tabla de descuento
            cambioDePrecioMasivoToolStripMenuItem.Visible = false; // 10 Precios Masivo
            ComprasTool.Visible = false; //11 Compras

            ajustesToolStripMenuItem.Visible = false; //12 Ajustes
            mermasToolStripMenuItem1.Visible = false; //12 Mermas
            kitDeActivaciónToolStripMenuItem1.Visible = false;
            traspasosToolStripMenuItem1.Visible = false;
            otrosToolStripMenuItem.Visible = false;



        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.FormVendedores Vendedores = new Catalogos.FormVendedores();
            //Vendedores.MdiParent = FormMenuPrincipal.ActiveForm;

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Vendedores.ShowDialog(this);
            }
            else
            {
                checkAccess(Vendedores, 2);
            }



        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            /*Applications.ERP.Base.cCompras Compras = new Applications.ERP.Base.cCompras(Application.StartupPath + @"\Dictionaries\Queries.xml", strConexion);
            Compras.ShowCompras(this);*/
                        
            Compras.FormCompras Compras = new Compras.FormCompras();
            Compras.MdiParent = this;
            Compras.Show();
        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Punto_de_Venta.FormPuntoDeVentaInicio PuntoDeVenta = new Punto_de_Venta.FormPuntoDeVentaInicio();
            //PuntoDeVenta.MdiParent = FormMenuPrincipal.ActiveForm;
            PuntoDeVenta.Permiso = NivelAcceso1;
            PuntoDeVenta.ShowDialog(this);

        }
        public void checkAccess(Form Formulario, int Nivel)
        {
            DialogResult result;
            result = MessageBox.Show("Usted no está autorizado para acceder a este modulo, ¿Desea ingresar una clave de acceso?", "Error Ingreso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Usuarios.FormIngresarClaveGlobal IngresarClave = new Usuarios.FormIngresarClaveGlobal();
                IngresarClave.Formulario = Formulario;
                IngresarClave.Nivel = Nivel;
                IngresarClave.Show();
            }
        }
        public bool BloqueoRemision()
        {
            bool SiFirmo = false;
            string Texto = "";
            Usuarios.FormIngresarClaveBloqueo IngresarClave = new Usuarios.FormIngresarClaveBloqueo();
               
                if (IngresarClave.ShowDialog() == DialogResult.OK)
                {
                    Texto = IngresarClave.Texto;
                    SiFirmo = true;
                }
                if (Texto != "")
                {
                    this.Text = Texto;
                }
                return SiFirmo;
        }
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageBase c = new PageBase();
            //PageBase.CveUser u=new PageBase.CveUser();
            string CveCaja = "", DescripcionCaja = "";
            double ProvisionInicial = 0;
            bool Esta = false;
            int CveAlmacen = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString))
            {
                con.Open();
                string QueryApertura = "Select * From CierreCajas Where Fecha='" + c.SwitchDate(DateTime.Now.ToShortDateString(), 1) + "' And CveUser=" + CveUser + " And Cerrada=0";
                SqlCommand CmdCierre = new SqlCommand(QueryApertura, con);
                SqlDataReader ReaderCierre = CmdCierre.ExecuteReader();

                if (ReaderCierre.HasRows)
                {
                    ReaderCierre.Read();
                    CveCaja = ReaderCierre["CveCaja"].ToString();
                    ProvisionInicial = double.Parse(ReaderCierre["ProvisionInicial"].ToString());
                    CveAlmacen = int.Parse(ReaderCierre["CveAlmacen"].ToString());
                    Esta = true;
                }
                ReaderCierre.Close();

                con.Close();
            }

            if (Esta)
            {
                Punto_de_Venta.FormTickesDeVenta TicketsDeVenta = new Punto_de_Venta.FormTickesDeVenta();
                //TicketsDeVenta.MdiParent = FormMenuPrincipal.ActiveForm;
                TicketsDeVenta.CveCaja = int.Parse(CveCaja);
                TicketsDeVenta.CveAlmacen = CveAlmacen;
                if (NivelAcceso1 == 1 || NivelAcceso1 == 2 || NivelAcceso1 == 3)
                {
                    TicketsDeVenta.ShowDialog(this);
                }
                else
                {
                    checkAccess(TicketsDeVenta, 3);
                }
            }
            else
            {
                MessageBox.Show("Le sugerimos aperturar la caja para empezar a realizar las ventas", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto_de_Venta.FormCierreCajaInicio CierreCajaInicio = new Punto_de_Venta.FormCierreCajaInicio();
            //CierreCajaInicio.MdiParent = FormMenuPrincipal.ActiveForm;
            CierreCajaInicio.ShowDialog(this);

        }

        private void ordenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Servicio.FormOrdenesDeServicio OrdenesDeServicio = new Servicio.FormOrdenesDeServicio();
            //OrdenesDeServicio.MdiParent = FormMenuPrincipal.ActiveForm;
            OrdenesDeServicio.ShowDialog(this);*/
        }



        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ajustesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*
            Inventario.Ajustes.FormAjustesInventario AjustesInventario = new Inventario.Ajustes.FormAjustesInventario();
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                AjustesInventario.ShowDialog(this);
            }
            else
            {
                checkAccess(AjustesInventario, 2);
            }
            */



        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            Catalogos.FormLineaProducto Linea = new Catalogos.FormLineaProducto();
            //Categorias.MdiParent = FormMenuPrincipal.ActiveForm;
            Linea.ShowDialog(this);

        }

        private void preciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Inventario.FormPrecios Precios = new Inventario.FormPrecios();
            //Precios.MdiParent = FormMenuPrincipal.ActiveForm;
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Precios.ShowDialog(this);
            }
            else
            {
                checkAccess(Precios, NivelAcceso1);
            }
        }

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.FormMarcas Marcas = new Catalogos.FormMarcas();
            //Marcas.MdiParent = FormMenuPrincipal.ActiveForm;
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Marcas.ShowDialog(this);
            }
            else
            {
                checkAccess(Marcas, NivelAcceso1);
            }
        }

        private void consumoInternoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void operaciónDeLaCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Firma = BloqueoRemision();
            if (Firma)
            {
                Punto_de_Venta.RadFormModuloComercial comercial = new Punto_de_Venta.RadFormModuloComercial();

                comercial.Show();
            }

        }
       
     
        private void OperacionCobranzaDXC()
        {
            PageBase c = new PageBase();
            //PageBase.CveUser u=new PageBase.CveUser();
            string CveCaja = "", DescripcionCaja = "";
            double ProvisionInicial = 0;
            int CveAlmacen = 0;
            bool Esta = false;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString))
            {
                con.Open();
                string QueryApertura = "Select * From CierreCajas Where Fecha='" + c.SwitchDate(DateTime.Now.ToShortDateString(), 1) + "' And CveUser=" + CveUser + " And Cerrada=0";
                SqlCommand CmdCierre = new SqlCommand(QueryApertura, con);
                SqlDataReader ReaderCierre = CmdCierre.ExecuteReader();

                if (ReaderCierre.HasRows)
                {
                    ReaderCierre.Read();
                    CveCaja = ReaderCierre["CveCaja"].ToString();
                    ProvisionInicial = double.Parse(ReaderCierre["ProvisionInicial"].ToString());
                    CveAlmacen = int.Parse(ReaderCierre["CveAlmacen"].ToString());

                    Esta = true;
                }
                ReaderCierre.Close();

                con.Close();
            }

            if (Esta)
            {


                DescripcionCaja = c.GetStrFieldQuery("Descripcion", "Select Descripcion From CatCajas Where CveCaja=" + CveCaja);

                Embarques.Cobranza.FormControlRemisiones Cobranza = new Embarques.Cobranza.FormControlRemisiones();
                //FrmControlRemisiones

                Cobranza.CveCaja = CveCaja;
                Cobranza.Caja = DescripcionCaja;
                Cobranza.FechaVta = DateTime.Now.ToShortDateString();
                Cobranza.ProvisionInicial = c.CheckTextBoxNull(ProvisionInicial.ToString(), "0", 1);
                //FrmControlRemisiones.CveAlmacenDefault = CveAlmacen;
                Cobranza.MdiParent = FormMenuPrincipal.ActiveForm;

                Cobranza.Show();

                /*
                Punto_de_Venta.FormPuntoDeVenta PuntoDeVenta = new Sistema_de_Inventarios.Punto_de_Venta.FormPuntoDeVenta();
                //PuntoDeVenta.CveVendedor = this.cboxVendedor.SelectedValue.ToString();
                //PuntoDeVenta.Vendedor = this.cboxVendedor.Text;
                PuntoDeVenta.CveCaja = CveCaja;
                PuntoDeVenta.Caja = DescripcionCaja;
                PuntoDeVenta.Fecha = DateTime.Now.ToShortDateString();
                PuntoDeVenta.ProvisionInicial = c.CheckTextBoxNull(ProvisionInicial.ToString(), "0", 1);
                PuntoDeVenta.CveAlmacenDefault = CveAlmacen;
                PuntoDeVenta.MdiParent = FormMenuPrincipal.ActiveForm;
                //PuntoDeVenta.FormInstanceRef = this;

                PuntoDeVenta.Show();
                 * 
                 * */


            }
            else
            {
                  //MessageBox.Show("Le sugerimos aperturar la caja para empezar a realizar las ventas", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Punto_de_Venta.FormPuntoDeVentaInicio PuntoDeVenta = new Punto_de_Venta.FormPuntoDeVentaInicio();
                //PuntoDeVenta.MdiParent = FormMenuPrincipal.ActiveForm;

                PuntoDeVenta.Permiso = NivelAcceso1;

                if (PuntoDeVenta.ShowDialog(this) == DialogResult.OK)
                {
                    if (PuntoDeVenta.Abierto == 1)
                    {

                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString))
                        {
                            con.Open();
                            string QueryApertura = "Select * From CierreCajas Where Fecha='" + c.SwitchDate(DateTime.Now.ToShortDateString(), 1) + "' And CveUser=" + CveUser + " And Cerrada=0";
                            SqlCommand CmdCierre = new SqlCommand(QueryApertura, con);
                            SqlDataReader ReaderCierre = CmdCierre.ExecuteReader();

                            if (ReaderCierre.HasRows)
                            {
                                ReaderCierre.Read();
                                CveCaja = ReaderCierre["CveCaja"].ToString();
                                ProvisionInicial = double.Parse(ReaderCierre["ProvisionInicial"].ToString());
                                CveAlmacen = int.Parse(ReaderCierre["CveAlmacen"].ToString());

                                Esta = true;
                            }
                            ReaderCierre.Close();

                            con.Close();
                        }

                        if (Esta)
                        {
                            DescripcionCaja = c.GetStrFieldQuery("Descripcion", "Select Descripcion From CatCajas Where CveCaja=" + CveCaja);

                            Embarques.Cobranza.FormControlRemisiones Cobranza = new Embarques.Cobranza.FormControlRemisiones();
                            //FrmControlRemisiones

                            Cobranza.CveCaja = CveCaja;
                            Cobranza.Caja = DescripcionCaja;
                            Cobranza.FechaVta = DateTime.Now.ToShortDateString();
                            Cobranza.ProvisionInicial = c.CheckTextBoxNull(ProvisionInicial.ToString(), "0", 1);
                            //FrmControlRemisiones.CveAlmacenDefault = CveAlmacen;
                            Cobranza.MdiParent = FormMenuPrincipal.ActiveForm;

                            Cobranza.Show();
                        }
                    }
                }

            }
        }
        private void OperacionCaja2()
        {
            PageBase c = new PageBase();
            //PageBase.CveUser u=new PageBase.CveUser();
            string CveCaja = "", DescripcionCaja = "";
            double ProvisionInicial = 0;
            int CveAlmacen = 0;
            bool Esta = false;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString))
            {
                con.Open();
                string QueryApertura = "Select * From CierreCajas Where Fecha='" + c.SwitchDate(DateTime.Now.ToShortDateString(), 1) + "' And CveUser=" + CveUser + " And Cerrada=0";
                SqlCommand CmdCierre = new SqlCommand(QueryApertura, con);
                SqlDataReader ReaderCierre = CmdCierre.ExecuteReader();

                if (ReaderCierre.HasRows)
                {
                    ReaderCierre.Read();
                    CveCaja = ReaderCierre["CveCaja"].ToString();
                    ProvisionInicial = double.Parse(ReaderCierre["ProvisionInicial"].ToString());
                    CveAlmacen = int.Parse(ReaderCierre["CveAlmacen"].ToString());

                    Esta = true;
                }
                ReaderCierre.Close();

                con.Close();
            }

            if (Esta)
            {
                DescripcionCaja = c.GetStrFieldQuery("Descripcion", "Select Descripcion From CatCajas Where CveCaja=" + CveCaja);
                Punto_de_Venta.FrmPVenta PuntoDeVenta = new Punto_de_Venta.FrmPVenta();
                //PuntoDeVenta.CveVendedor = this.cboxVendedor.SelectedValue.ToString();
                //PuntoDeVenta.Vendedor = this.cboxVendedor.Text;
                PuntoDeVenta.CveCaja = CveCaja;
                PuntoDeVenta.Caja = DescripcionCaja;
                PuntoDeVenta.Fecha = DateTime.Now.ToShortDateString();
                PuntoDeVenta.ProvisionInicial = c.CheckTextBoxNull(ProvisionInicial.ToString(), "0", 1);
                PuntoDeVenta.CveAlmacenDefault = CveAlmacen;
                PuntoDeVenta.MdiParent = FormMenuPrincipal.ActiveForm;
                //PuntoDeVenta.FormInstanceRef = this;

                PuntoDeVenta.Show();
            }
            else
            {
                MessageBox.Show("Le sugerimos aperturar la caja para empezar a realizar las ventas", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OperacionCaja3()
        {
            PageBase c = new PageBase();
            //PageBase.CveUser u=new PageBase.CveUser();
            string CveCaja = "0", DescripcionCaja = "";
            double ProvisionInicial = 0;
            int CveAlmacen = c.GetIntFieldint("CveAlmacen","Select CveAlmacen From CatAlmacen Where Predeterminado=1");
            bool Esta = true;
            /*
            using (SqlConnection con = new SqlConnection(c.strconexion))
            {
                con.Open();
                string QueryApertura = "Select * From CierreCajas Where Fecha='" + c.SwitchDate(DateTime.Now.ToShortDateString(), 1) + "' And CveUser=" + CveUser + " And Cerrada=0";
                SqlCommand CmdCierre = new SqlCommand(QueryApertura, con);
                SqlDataReader ReaderCierre = CmdCierre.ExecuteReader();

                if (ReaderCierre.HasRows)
                {
                    ReaderCierre.Read();
                    CveCaja = ReaderCierre["CveCaja"].ToString();
                    ProvisionInicial = double.Parse(ReaderCierre["ProvisionInicial"].ToString());
                    CveAlmacen = int.Parse(ReaderCierre["CveAlmacen"].ToString());

                    Esta = true;
                }
                ReaderCierre.Close();

                con.Close();
            }
            */
            if (Esta)
            {
                DescripcionCaja = c.GetStrFieldQuery("Descripcion", "Select Descripcion From CatCajas Where CveCaja=" + CveCaja);
                Punto_de_Venta.FrmRemisiones PuntoDeVenta = new Punto_de_Venta.FrmRemisiones();
                //PuntoDeVenta.CveVendedor = this.cboxVendedor.SelectedValue.ToString();
                //PuntoDeVenta.Vendedor = this.cboxVendedor.Text;
                PuntoDeVenta.CveCaja = CveCaja;
                PuntoDeVenta.Caja = DescripcionCaja;
                PuntoDeVenta.Fecha = DateTime.Now.ToShortDateString();
                PuntoDeVenta.ProvisionInicial = c.CheckTextBoxNull(ProvisionInicial.ToString(), "0", 1);
                PuntoDeVenta.CveAlmacenDefault = CveAlmacen;
                PuntoDeVenta.MdiParent = FormMenuPrincipal.ActiveForm;
                //PuntoDeVenta.FormInstanceRef = this;

                PuntoDeVenta.Show();
            }
            else
            {
                MessageBox.Show("Le sugerimos aperturar la caja para empezar a realizar las ventas", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void garantíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Inventario.Garantias.FormGarantias Garantias = new Inventario.Garantias.FormGarantias();
            Garantias.MdiParent = FormMenuPrincipal.ActiveForm;
            Garantias.Show();*/
        }

        private void devoluciónesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario.DevolucionesClientes.FormDevolucionesClientes DevolucionesClientes = new Inventario.DevolucionesClientes.FormDevolucionesClientes();
            //DevolucionesClientes.MdiParent = this;

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2 || NivelAcceso1 == 3)
            {
                DevolucionesClientes.ShowDialog(this);
            }
            else
            {
                checkAccess(DevolucionesClientes, 3);
            }
        }

        private void aProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Inventario.Devoluciones.FormDevoluciones Devoluciones = new Inventario.Devoluciones.FormDevoluciones();
            Devoluciones.MdiParent = FormMenuPrincipal.ActiveForm;
            Devoluciones.Show();*/
        }

        private void deClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cuentasXCobrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            pg.OperacionCaja(2);
        }
        
        private void notasDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.FormFacturasOtras FacturaLibre = new Facturacion.FormFacturasOtras();
            FacturaLibre.MdiParent = FormMenuPrincipal.ActiveForm;
            FacturaLibre.Show();

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras.Pedidos.FormPedidos Pedidos = new Compras.Pedidos.FormPedidos();
           
            Pedidos.Show();
        }

        private void cobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuentasxPagar.FormCuentasxPagar CxPagar = new CuentasxPagar.FormCuentasxPagar();
            //CxPagar.MdiParent = this;
            CxPagar.ShowDialog(this);
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotasCargo.FormNotasCargo NotasCargoCliente = new NotasCargo.FormNotasCargo();

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                NotasCargoCliente.ShowDialog(this);
            }
            else
            {
                checkAccess(NotasCargoCliente, NivelAcceso1);
            }


        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NotasCargoProveedor.FormNotasCargo NotasCargoProveedor = new NotasCargoProveedor.FormNotasCargo();
            //NotasCargoProveedor.MdiParent = this;
            NotasCargoProveedor.ShowDialog(this);
        }

        private void generalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.FormReporteVarios Varios = new Reportes.FormReporteVarios();

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Varios.ShowDialog(this);
            }
            else
            {
                checkAccess(Varios, 2);
            }


        }

        private void conceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConceptoNotaCargo.FormConceptos ConceptosNotaCargo = new ConceptoNotaCargo.FormConceptos();
            //ConceptosNotaCargo.MdiParent = this;

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2 || NivelAcceso1 == 4)
            {
                ConceptosNotaCargo.ShowDialog(this);
            }
            else
            {
                checkAccess(ConceptosNotaCargo, NivelAcceso1);
            }


        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            ValidarPermisoPerfilMenu();
        }
        void Permisos(int OpcionPermiso)
        {
            switch (OpcionPermiso)
            {
                case 1: // Administrador

                    break;

                case 2: // Gerente


                    break;

                case 3: // Cajero
                    PuntoVentaTool.Enabled = true;
                    InventarioTool.Enabled = false;
                    EntradasTool.Enabled = false;
                    CuentasxPagarTool.Enabled = false;
                    CuentasxCobrarTool.Enabled = true;
                    NotasCargoTool.Enabled = true;
                    ProveedoresTool.Enabled = true;
                    VendedoresTool.Enabled = false;
                    ReportesTool.Enabled = false;
                    UsuariosTool.Enabled = false;

                    tratamientosTool.Enabled = false;
                    CatalogosTool2.Enabled = false;

                    CitasTool.Enabled = false;
                    monederoElectronicoToolStripMenuItem.Enabled = false;
                    utileriasToolStripMenuItem.Enabled = false;
                    respaldoDeDatosToolStripMenuItem.Enabled = false;
                    recuperacionDeDatosToolStripMenuItem.Enabled = false;
                    ClientesTool.Enabled = true;
                    break;

                case 4:

                    InventarioTool.Enabled = true;
                    EntradasTool.Enabled = true;
                    CuentasxPagarTool.Enabled = true;
                    CuentasxCobrarTool.Enabled = true;
                    NotasCargoTool.Enabled = true;
                    ProveedoresTool.Enabled = true;
                    VendedoresTool.Enabled = false;
                    ReportesTool.Enabled = false;
                    UsuariosTool.Enabled = false;
                    sesiónTool.Enabled = false;
                    tratamientosTool.Enabled = true;
                    CatalogosTool.Enabled = true;
                    CatalogosTool2.Enabled = true;
                    monederoElectronicoToolStripMenuItem.Enabled = true;
                    utileriasToolStripMenuItem.Enabled = false;
                    respaldoDeDatosToolStripMenuItem.Enabled = false;
                    recuperacionDeDatosToolStripMenuItem.Enabled = false;

                    break;
            }
        }

        private void traspasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario.Traspaso.FormTraspasoInventario TraspasoInventario = new Inventario.Traspaso.FormTraspasoInventario();
           
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                TraspasoInventario.ShowDialog(this);
            }
            else
            {
                checkAccess(TraspasoInventario, 2);
            }


        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void checkListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void citasAssiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void citasToolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }

        private void citasAsignadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void valoraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void segmentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pulsosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {


            /*PageBase c = new PageBase();
            //PageBase.CveUser u=new PageBase.CveUser();
            string CveCierre = "";
            
            bool Esta=false;

            using (SqlConnection con = new SqlConnection(c.strconexion))
            {
                con.Open();
                string QueryApertura = "Select * From CierreCajas Where Fecha='" + c.SwitchDate(DateTime.Now.ToShortDateString(), 1) + "' And CveVendedor=" + CveUser + " And Cerrada=0";
                SqlCommand CmdCierre = new SqlCommand(QueryApertura, con);
                SqlDataReader ReaderCierre = CmdCierre.ExecuteReader();

                if (ReaderCierre.HasRows)
                {
                    ReaderCierre.Read();
                    CveCierre = ReaderCierre["CveCierre"].ToString();
                    
                    Esta = true;
                }
                ReaderCierre.Close();

                con.Close();
            }

            if (Esta)
            {
                string QueryUpdate = "Update CierreCajas Set Cerrada=1 Where CveCierre=" + CveCierre;
                c.performupdatequery(QueryUpdate);
            }*/

            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason==CloseReason.ApplicationExitCall)
            {
                

              
                string Fecha = pg.ObtenerFechaHora(1);
                string Hora = pg.ObtenerFechaHora(2);

                c_Usuarios _Usuarios = new c_Usuarios();

                _Usuarios.Bloqueo = 0;
                _Usuarios.Cveuser = CveUser;
                _Usuarios.Fecha = Fecha;
                _Usuarios.Hora = Hora;
                _Usuarios.IdSesion = Guid.NewGuid().ToString();
                _Usuarios.IPLocal = pg.ObtenerIPHost();
                //_Usuarios.IPPublica = pg.GetPublicIP();
                //_Usuarios.PublicIP = pg.GetPublicIP();
                _Usuarios.PC = System.Net.Dns.GetHostEntry(_Usuarios.IPLocal).HostName;
                _Usuarios.CveTipoMovUser = 2;
                _Usuarios.CveModulo = 2;
                _Usuarios.strConexion = strConexion;
                _Usuarios.SaveDetelleAccesos();

                Application.Exit();

            }
        }

        private void monederoElectronicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MonederoElectronico.FormCargaSaldoMonedero Monedero = new Sistema_de_Inventarios.MonederoElectronico.FormCargaSaldoMonedero();
            //Monedero.ShowDialog(this);
        }

        private void respaldoDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result;
            result = MessageBox.Show("¿Esta seguro de respaldar los datos en este momento?", "Respaldo de base de datos", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cIniArray mINI = new cIniArray();
                Encriptar Enn = new Encriptar();
                string Fecha = DateTime.Now.ToShortDateString();
                string Fecha2 = Fecha.Replace("/", "_");
                string ruta = "C:\\Respaldo" + "\\backup_" + Fecha2 + ".sql";
                string Archivo = Application.StartupPath + @"\Conexion.ini";
                string Servidor = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "ServerName", ""));
                string BaseDatos = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "BaseDatos", ""));
                string Usuario = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Usuario", ""));
                string Password = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Password", ""));

                string comando = "mysqldump.exe --host=" + Servidor + " --user=" + Usuario + " --password=" + Password + " " + BaseDatos + " > " + ruta;

                string path = @"C:\Respaldo";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }



                bool resp = creararchivobat(comando, "C:\\Respaldo" + @"\respaldo.bat");

                if (resp)
                {
                    Process.Start("C:\\Respaldo" + @"\respaldo.bat");
                    MessageBox.Show("El Respaldo se ha generado con exito en la siguiente ruta: " + ruta, "Respaldo de Información");
                    File.Delete("C:\\Respaldo" + @"\respaldo.bat");
                }
                else
                {
                    MessageBox.Show("Error al intentar respaldar la base de datos, favor de avisar al administrador", "Validación de Datos");
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

        private void recuperacionDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void datosEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.FormEmpresa Empresa = new Catalogos.FormEmpresa();

            if (NivelAcceso1 == 1)
            {
                Empresa.ShowDialog(this);
            }
            else
            {
                checkAccess(Empresa, 1);
            }

        }

        private void sesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CotizacionesTool_Click(object sender, EventArgs e)
        {
            Reportes.Rpt.FormReporteVarios ReporteVarios = new Reportes.Rpt.FormReporteVarios();
            ReporteVarios.Show();
        }

        private void EntradasTool_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //MonederoElectronico.FormCargaSaldoMonedero Monedero = new Sistema_de_Inventarios.MonederoElectronico.FormCargaSaldoMonedero();
            //Monedero.ShowDialog(this);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int Corte = pg.OperacionCaja(3);

            if (Corte == 1)
            {
                Punto_de_Venta.CorteCaja.FormCorteCaja Global = new Punto_de_Venta.CorteCaja.FormCorteCaja();

                if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
                {

                    Global.ShowDialog(this);
                }
                else
                {
                    checkAccess(Global, 2);
                }
            }
        }

        private void cortePorCajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto_de_Venta.FormCierreCajaUsuario GlobalUsuario = new Punto_de_Venta.FormCierreCajaUsuario();

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {

                GlobalUsuario.ShowDialog(this);
            }
            else
            {
                checkAccess(GlobalUsuario, 2);
            }
        }

        private void emisoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void receptoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void cajasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Punto_de_Venta.FormCajas FrmCajas = new Punto_de_Venta.FormCajas();
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {

                FrmCajas.ShowDialog(this);
            }
            else
            {
                checkAccess(FrmCajas, 2);
            }
        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.FormUnidades FrmUnidades = new Catalogos.FormUnidades();
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {

                FrmUnidades.ShowDialog(this);
            }
            else
            {
                checkAccess(FrmUnidades, 2);
            }
        }

        private void indexarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Catalogos.FormRespaldos Respaldos = new Catalogos.FormRespaldos();
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {

                Respaldos.ShowDialog(this);
            }
            else
            {
                checkAccess(Respaldos, 2);
            }
        }

        private void ajusteExpressToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Inventario.Ajustes.FormMovimientosInventario AjustesInventario = new Inventario.Ajustes.FormMovimientosInventario();
            AjustesInventario.CveTipoMovimiento = "3,4,9,10";
            AjustesInventario.Text += " (Ajustes al Inventario)";
            
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                AjustesInventario.ShowDialog(this);
            }
            else
            {
                checkAccess(AjustesInventario, 2);
            }

            /*
            Inventario.AjusteExpress.FormAjustesInventario AjustesInventario = new Inventario.AjusteExpress.FormAjustesInventario();
            AjustesInventario.ShowDialog(this);

            */



        }

        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario.Almacen.FormAlmacen Almacen = new Inventario.Almacen.FormAlmacen();
            Almacen.ShowDialog(this);
        }

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void radRibbonBarGroup2_Click(object sender, EventArgs e)
        {

        }

        private void radImageButtonElement1_Click(object sender, EventArgs e)
        {
            Catalogos.FormClientes Clientes = new Catalogos.FormClientes();
            //Clientes.MdiParent = this;
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2 || NivelAcceso1 == 3)
            {
                Clientes.ShowDialog(this);
            }
            else
            {
                checkAccess(Clientes, NivelAcceso1);
            }
        }

        private void radImageButtonElement2_Click(object sender, EventArgs e)
        {
            CuentasxCobrar.FormCuentasxCobrar CxCobrar = new CuentasxCobrar.FormCuentasxCobrar();
            //CxPagar.MdiParent = this;
            CxCobrar.ShowDialog(this);
        }

        private void tPVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pg.OperacionCaja(4);
        }

        private void remisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool Firma = BloqueoRemision();
            if (Firma)
            {
                OperacionCaja3();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            Inventario.Almacen.FormAlmacen Almacen = new Inventario.Almacen.FormAlmacen();
         

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Almacen.ShowDialog(this);
            }
            else
            {
                checkAccess(Almacen, 2);
            }

        }

        private void zonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embarques.Rutas.FormRutas Rutas = new Embarques.Rutas.FormRutas();
            Rutas.MdiParent = this;
            Rutas.Show();
        }

        private void ventasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pg.OperacionCaja();

        }

        private void embarquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embarques.FormEmbarques Embarques = new Embarques.FormEmbarques();
            //Embarques.MdiParent = this;
            Embarques.Show();

        }

        private void cobranzaDXCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionCobranzaDXC();
            

        }

        private void CuentasxCobrarTool_Click(object sender, EventArgs e)
        {

        }

        private void embarqueAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embarques.Almacen.FormEmbarques EmbarquesAlmacen = new Embarques.Almacen.FormEmbarques();
            EmbarquesAlmacen.MdiParent = this;
            EmbarquesAlmacen.Show();
           
        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto_de_Venta.NotaCredito.FormControlAutorizaDevoluciones DevAutorizacion = new Punto_de_Venta.NotaCredito.FormControlAutorizaDevoluciones();
                
            DevAutorizacion.Show();

        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embarques.Vehiculos.FormVehiculos Vehiculos = new Embarques.Vehiculos.FormVehiculos();
            Vehiculos.MdiParent = this;
            Vehiculos.Show();
        }

        private void choferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embarques.Choferes.FormChoferes Choferes = new Embarques.Choferes.FormChoferes();
            Choferes.MdiParent = this;
            Choferes.Show();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Facturacion.FormFacturasVentas Factura = new Facturacion.FormFacturasVentas();
            //Factura.MdiParent = FormMenuPrincipal.ActiveForm;
            Factura.Show();
        }

        private void facturasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Facturacion.Factura.FormFacturasVentas formFacturas = new Facturacion.Factura.FormFacturasVentas();
            formFacturas.ShowDialog(this);

            /*
            Facturacion.FormFacturasVentasMonar FacturaMonar = new Facturacion.FormFacturasVentasMonar();
            FacturaMonar.ShowDialog(this);
            */
        }

        private void MovimientosTool_Click(object sender, EventArgs e)
        {
           
        }

        private void ProveedoresTool_Click(object sender, EventArgs e)
        {
            Catalogos.FormProveedores Proveedores = new Catalogos.FormProveedores();
            //Proveedores.MdiParent = FormMenuPrincipal.ActiveForm;
            Proveedores.ShowDialog(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Punto_de_Venta.FormControlAutorizaRCS RCS = new Punto_de_Venta.FormControlAutorizaRCS();
            RCS.ShowDialog(this);

        }

        private void PuntoVentaTool_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pg.OperacionCaja(1);
        }

        private void cuentasBancariasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autorizacionDeDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto_de_Venta.Descuento.FormControlAutorizarDescuento autorizarDescuento = new Punto_de_Venta.Descuento.FormControlAutorizarDescuento();

            autorizarDescuento.Show();

        }

        private void notasDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InventarioTool_Click(object sender, EventArgs e)
        {

        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios Usuarios = new FormUsuarios();
            //Usuarios.MdiParent = this;
            if (NivelAcceso1 == 1)
            {
                Usuarios.ShowDialog(this);
            }
            else
            {
                checkAccess(Usuarios, 1);
            }
        }

        private void usuariosActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios.FormUsuariosBloqueo _usuariosBloqueo = new Usuarios.FormUsuariosBloqueo();
            _usuariosBloqueo.Show();
            
        }

        private void tablaDeDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario.FormPrecios Precios = new Inventario.FormPrecios();
            //Precios.MdiParent = FormMenuPrincipal.ActiveForm;
            Precios.Show();
        }

        private void cambioDePrecioMasivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario.FormPrecioProducto PCambios = new Inventario.FormPrecioProducto();

            if (NivelAcceso1== 1 || NivelAcceso1 == 2)
            {

                PCambios.Show();
            }
            else
            {
                checkAccess(PCambios, 2);
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {

        }

        private void anaquelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Catalogos.Adicionales.FormAnaquelDS anaquelDS = new Catalogos.Adicionales.FormAnaquelDS();
            anaquelDS.MdiParent = this;
            anaquelDS.Show();
            */
            
            Catalogos.Adicionales.FormAnaquel formAnaquel = new Catalogos.Adicionales.FormAnaquel();
            formAnaquel.MdiParent = this;
            formAnaquel.Show();
            
        }

        private void repisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.Adicionales.FormRepisa formRepisa = new Catalogos.Adicionales.FormRepisa();
            formRepisa.MdiParent = this;
            formRepisa.Show();
        }

        private void emisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.FormEmisores emisores = new Catalogos.FormEmisores();
            emisores.MdiParent = this;
            emisores.Show();
        }

        private void receptoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.FormReceptores receptores = new Catalogos.FormReceptores();
            receptores.MdiParent = this;
            receptores.Show();
        }

        private void mermasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Inventario.Ajustes.FormMovimientosInventario AjustesInventario = new Inventario.Ajustes.FormMovimientosInventario();
            AjustesInventario.Text += " (Mermas)";
            AjustesInventario.CveTipoMovimiento = "2";

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                AjustesInventario.ShowDialog(this);
            }
            else
            {
                checkAccess(AjustesInventario, 2);
            }
        }

        private void kitDeActivaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //Inventario.ConsumoInterno.FormConsumoInterno ConsumoInterno = new Inventario.ConsumoInterno.FormConsumoInterno();
            //ConsumoInterno.MdiParent = FormMenuPrincipal.ActiveForm;

            Inventario.Ajustes.FormMovimientosInventario ConsumoInterno = new Inventario.Ajustes.FormMovimientosInventario();
            ConsumoInterno.CveTipoMovimiento = "5";
            ConsumoInterno.Text += " (Kit de Activación)";

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                ConsumoInterno.ShowDialog(this);
            }
            else
            {
                checkAccess(ConsumoInterno, 2);
            }
        }

        private void traspasosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Inventario.Traspaso.FormTraspasoInventario TraspasoInventario = new Inventario.Traspaso.FormTraspasoInventario();

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                TraspasoInventario.ShowDialog(this);
            }
            else
            {
                checkAccess(TraspasoInventario, 2);
            }

        }

        private void otrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Inventario.Ajustes.FormMovimientosInventario AjustesInventario = new Inventario.Ajustes.FormMovimientosInventario();
            AjustesInventario.CveTipoMovimiento = "3,4,9,10";
            AjustesInventario.Text += " (Ajustes al Inventario)";

            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                AjustesInventario.ShowDialog(this);
            }
            else
            {
                checkAccess(AjustesInventario, 2);
            }
        }

        private void mermasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            /*
            Catalogos.Proveedores.FormProveedores proveedores = new Catalogos.Proveedores.FormProveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
            */
            
            Catalogos.FormProveedores proveedores = new Catalogos.FormProveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
            
        }

        private void CuentasxPagarTool_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Inventario.FormProductos productos = new Inventario.FormProductos();
            productos.MdiParent = this;
            productos.Show();

        }

        private void categoriasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Catalogos.FormCategorias Categorias = new Catalogos.FormCategorias();
            //Categorias.MdiParent = FormMenuPrincipal.ActiveForm;
            if (NivelAcceso1 == 1 || NivelAcceso1 == 2)
            {
                Categorias.ShowDialog(this);
            }
            else
            {
                checkAccess(Categorias, NivelAcceso1);
            }
        }

        private void FormMenuPrincipal_Shown(object sender, EventArgs e)
        {
          //
        }

        private void ventasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Facturacion.FormFacturasVentas Factura = new Facturacion.FormFacturasVentas();
            //Factura.MdiParent = FormMenuPrincipal.ActiveForm;
            Factura.Show();
        }

        private void facturasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            
            /*
            Facturacion.FormFacturasVentasMonar FacturaMonar = new Facturacion.FormFacturasVentasMonar();
            FacturaMonar.ShowDialog(this);
            */
        }

        private void notasDeCreditoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void complementoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notasCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notasDeCreditoToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.Factura.FormFacturasVentas formFacturas = new Facturacion.Factura.FormFacturasVentas();
            formFacturas.ShowDialog(this);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Facturacion.FormFacturasVentasMonar FacturaMonar = new Facturacion.FormFacturasVentasMonar();
            FacturaMonar.ShowDialog(this);
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Facturacion.Factura.Vales.FormFacturasVentas facturasVentasVales = new Facturacion.Factura.Vales.FormFacturasVentas();
            facturasVentasVales.ShowDialog(this);
        }
    }
}
