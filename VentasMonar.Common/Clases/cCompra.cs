using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasMonar.Desktop.Clases;

namespace VentasMonar.Desktop.Clases
{
    public class cCompra
    {
        public int CveCompra { get; set; }
        public int CveProveedor { get; set; }
        public int CvePedido { get; set; }
        public int CveFormaPago { get; set; }
        public string NumeroFactura { get; set; }
        public string FechaFactura { get; set; }
        public string FechaRecepcion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GasTosIndirectos { get; set; }
        public decimal DescuentoTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public int CveEstatus { get; set; }
        public int CveUser { get; set; }
        public int CveAlmacen { get; set; }
        public string NoDocumento { get; set; }
        public int CveDocumento { get; set; }
        public int CveTipoDocumento { get; set; }
        public string Strconexion { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
      
        public ArrayList ListaProductos { get; set; }
        cPageBase cPage = new cPageBase();


        public static DataTable _dtUltimoKardex(int CveAlmacen, int CveProducto, SqlConnection connection, SqlTransaction transaction)
        {
            cPageBase cPage = new cPageBase();

            DataTable _dtResult = new DataTable();

            string QueryResult = "Select * From Kardex Where CveAlmacen=" + CveAlmacen + " And CveProducto=" + CveProducto;
            QueryResult += " And CveKardex =(Select Max(CveKardex) From Kardex Where CveAlmacen=" + CveAlmacen + " And CveProducto=" + CveProducto + ")";

            _dtResult = cPage.SP_DataReaderQuery(QueryResult, connection, transaction);


            return _dtResult;

        }

        


        public bool SaveCompras()
        {
            bool _resulregresa = false;

            int inserted = 0;
            int Folio = 0;
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "Compras";

                    Folio = help.Result(connection, transaction);


                    string strGuid = Guid.NewGuid().ToString();

                    string InsertCompra = "INSERT INTO Compras (CveProveedor, CvePedido, Folio, CveFormaPago, NumeroFactura, FechaFactura, FechaRecepcion, SubTotal, GastosIndirectos, Descuento, Iva, Total, CveEstatus, CveUser, CveAlmacen, Sys_GUID, CveTipoDocumento) VALUES(";
                    InsertCompra += CveProveedor + "," + CvePedido + "," + Folio + "," + CveFormaPago + ",'" + NumeroFactura + "','" + FechaFactura + "','" + FechaRecepcion + "',";
                    InsertCompra += SubTotal + "," + GasTosIndirectos + "," + DescuentoTotal + "," + Iva + "," + Total + "," + CveEstatus + "," + CveUser + "," + CveAlmacen + ",'" + strGuid + "'," + CveTipoDocumento + ")";

                    command.CommandText = InsertCompra;

                    command.ExecuteNonQuery();

                    command.CommandText = "Select SCOPE_IDENTITY()";
                    inserted = Convert.ToInt32(command.ExecuteScalar());


                    if (inserted > 0)
                    {
                        // SI LA VENTA ES A CRÉDITO INSERTAMOS EL IMPORTE EN LA TABLA DE CUENTAS POR PAGAR
                        if (CveFormaPago == 2)
                        {

                            //int DiasCredito = GetIntField("DiasCredito", "ProveedoresCredito", "CveProveedor", this.cboxProveedor.SelectedValue.ToString());

                            string insertCuentaPorPagar = "INSERT INTO CuentasPorPagar (CveCuenta, CveDocumento, CveProveedor, Fecha, FechaRecepcion, CveConcepto, Importe, Saldo, CveUser) VALUES (";
                            insertCuentaPorPagar += "0," + inserted.ToString() + "," + CveProveedor + ",'" + FechaFactura + "','" + FechaRecepcion + "'," + CveEstatus + "," + Total + "," + Total + "," + CveUser + ")";

                            command.CommandText = insertCuentaPorPagar;
                            command.ExecuteNonQuery();

                        }


                        decimal SubTotalCredito = 0, CantidadInventario = 0; int Cuenta = 0;
                        foreach (PageBase.ProductoCompra Producto in ListaProductos)
                        {

                            //Guardar Detalles de Kardex.

                            DataTable _dtResultUltimoKardex = _dtUltimoKardex(Producto.CveAlmacen, int.Parse(Producto.CveProducto), connection, transaction);

                            string QueryKardex = "";
                            int CveKardex = 0;

                            decimal NuevoSaldo=0;
                            decimal NuevoCostoPromedio=0;
                            decimal NuevoUltimoCosto = 0;


                            if (_dtResultUltimoKardex.Rows.Count==0)
                            {

                                NuevoSaldo = Producto.Cantidad;
                                NuevoCostoPromedio = Producto.CostoPromedio;
                                NuevoUltimoCosto = NuevoCostoPromedio;
                            }
                            else
                            {

                                foreach (DataRow Kardex in _dtResultUltimoKardex.Rows)
                                {

                                    NuevoSaldo = decimal.Parse(Kardex["Saldo"].ToString()) + Producto.Cantidad;

                                    NuevoCostoPromedio = (decimal.Parse(Kardex["CostoPromedio"].ToString()) * decimal.Parse(Kardex["Saldo"].ToString()) +
                                                        Producto.CostoPromedio * Producto.Cantidad) / NuevoSaldo;

                                    NuevoUltimoCosto = Producto.PrecioUnitarioOriginal / Producto.Cantidad;

                                }
                            }

                            QueryKardex = "Insert Into Kardex(FechaCompra, FechaRecepcion, CveAlmacen, CveProducto, CveDocumento, NoDocumento, ";
                            QueryKardex += "CveTipoDocumento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio) Values('";
                            QueryKardex += FechaFactura + "','" + FechaRecepcion + "'," + CveAlmacen + "," + Producto.CveProducto + ",";
                            QueryKardex += inserted + ",'" + Folio + "'," + CveTipoDocumento + "," + Producto.Cantidad + ",0,";
                            QueryKardex += NuevoSaldo + "," + Producto.CostoPromedio + "," + NuevoCostoPromedio + ")";


                            command.CommandText = QueryKardex;
                            command.ExecuteNonQuery();


                            command.CommandText = "Select SCOPE_IDENTITY()";
                            CveKardex = Convert.ToInt32(command.ExecuteScalar());

                            string InsertDetalleCompra = "INSERT INTO ComprasDetalle (CveCompra, CveProducto, Cantidad, CostoUnitario, CveKardex, Iva, Total, DescuentoAplicado, CostoUnitarioOriginal, Descuento, CveColor, CveAlmacen, Sys_GUID) VALUES (";
                            InsertDetalleCompra += inserted.ToString() + "," + Producto.CveProducto + "," + Producto.Cantidad + "," + Producto.CostoPromedio +  "," + CveKardex + "," + Producto.Iva + "," + Producto.PrecioTotal + "," + Producto.DescuentoAplicado + "," + Producto.PrecioUnitarioOriginal + "," + Producto.Descuento + "," + Producto.CveColor + "," + Producto.CveAlmacen + ",'" + strGuid + "')";


                            command.CommandText = InsertDetalleCompra;

                            command.ExecuteNonQuery();

                            /*
                            command.CommandText = "Select SCOPE_IDENTITY()";1

                            int inserted2 = int.Parse(command.ExecuteScalar().ToString());
                            */

                            
                           string QueryUpdateProducto = "Update Productos Set UltimoCosto=" + Producto.PrecioUnitarioOriginal + ",CantidadUltimaCompra=" + Producto.Cantidad + ",FechaUltimaCompra='" + FechaFactura + "'  Where CveProducto=" + Producto.CveProducto;
                            command.CommandText = QueryUpdateProducto;
                            command.ExecuteNonQuery();

                            SubTotalCredito += decimal.Parse(Producto.Cantidad.ToString()) * decimal.Parse(Producto.PrecioUnitarioOriginal.ToString());



                            Cuenta = 0;
                            CantidadInventario = 0;

                            string QueryCuenta = "Select count(*) As Cuenta From ProductoColor Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;

                            Cuenta = int.Parse(cPage.GetStrFieldQuery("Cuenta", QueryCuenta, connection, transaction));


                            if (Cuenta > 0)
                            {
                                string QueryCantidadInventario = "Select Cantidad From ProductoColor Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;
                                CantidadInventario = decimal.Parse(cPage.GetStrFieldQuery("Cantidad", QueryCantidadInventario, connection, transaction));
                            }

                            string QueryInsertMov = "Insert Into MovimientosInventario(CveTipoMovimiento,CveProducto,Habia,Cantidad,CveUser,Hora,Fecha, CveAlmacen, CveOrigen) Values(1," + Producto.CveProducto + "," + CantidadInventario + "," + Producto.Cantidad + "," + CveUser + ",'" + Fecha + "','" + Hora + "'," + Producto.CveAlmacen + ",7)";

                            command.CommandText = QueryInsertMov;
                            command.ExecuteNonQuery();

                            //performinsertquery(QueryInsertMov);

                            if (Cuenta == 0)
                            {

                                string QueryProductoColor = "Insert Into ProductoColor( CveProducto, CveColor, Cantidad, CveAlmacen) Values(" + Producto.CveProducto + "," + Producto.CveColor + "," + Producto.Cantidad + "," + Producto.CveAlmacen + ")";

                                command.CommandText = QueryProductoColor;
                                command.ExecuteNonQuery();
                                //performupdatequery(QueryProductoColor);
                            }
                            else
                            {
                                string QueryUpdate = "Update ProductoColor Set Cantidad=Cantidad + " + Producto.Cantidad + " Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;
                                command.CommandText = QueryUpdate;
                                command.ExecuteNonQuery();
                                //performupdatequery(QueryUpdate);
                            }


                            //}


                        }

                        /*CalculoFinal_2(connection, transaction);
                        string QueryIva = "Select Iva From CatIva Where CveIva=1";
                        decimal IvaA = decimal.Parse(cPage.GetStrFieldQuery("Iva", QueryIva, connection, transaction));
                        Iva = SubTotalCredito * IvaA;
                        Total = SubTotalCredito + Iva;
                        */

                       

                        transaction.Commit();


                        _resulregresa = true;
                        
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Commit Exception Type: " + ex.GetType());
                    MessageBox.Show(" Message: " + ex.Message);

                    _resulregresa = false;
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();

                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        MessageBox.Show("Rollback Exception Type: " + ex2.GetType());
                        MessageBox.Show("Message: " + ex2.Message);

                    }
                }


            }


            return _resulregresa;
        }

        public bool SaveOrdeCompra()
        {
            bool _resulregresa = false;

            int inserted = 0;
            int Folio = 0;
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "Compras";

                    Folio = help.Result(connection, transaction);


                    string strGuid = Guid.NewGuid().ToString();

                    string InsertCompra = "INSERT INTO OrdenCompras (CveProveedor, CvePedido, Folio, CveFormaPago, NumeroFactura, FechaFactura, FechaRecepcion, SubTotal, GastosIndirectos, Descuento, Iva, Total, CveEstatus, CveUser, CveAlmacen, Sys_GUID, CveTipoDocumento) VALUES(";
                    InsertCompra += CveProveedor + "," + CvePedido + "," + Folio + "," + CveFormaPago + ",'" + NumeroFactura + "','" + FechaFactura + "','" + FechaRecepcion + "',";
                    InsertCompra += SubTotal + "," + GasTosIndirectos + "," + DescuentoTotal + "," + Iva + "," + Total + "," + CveEstatus + "," + CveUser + "," + CveAlmacen + ",'" + strGuid + "'," + CveTipoDocumento + ")";

                    command.CommandText = InsertCompra;

                    command.ExecuteNonQuery();

                    command.CommandText = "Select SCOPE_IDENTITY()";
                    inserted = Convert.ToInt32(command.ExecuteScalar());


                    if (inserted > 0)
                    {
                        // SI LA VENTA ES A CRÉDITO INSERTAMOS EL IMPORTE EN LA TABLA DE CUENTAS POR PAGAR
                        

                        decimal SubTotalCredito = 0, CantidadInventario = 0; int Cuenta = 0;
                        foreach (PageBase.ProductoCompra Producto in ListaProductos)
                        {


                            string InsertDetalleCompra = "INSERT INTO OrdenComprasDetalle (CveCompra, CveProducto, Cantidad, CostoUnitario,  Iva, Total, DescuentoAplicado, CostoUnitarioOriginal, Descuento, CveColor, CveAlmacen, Sys_GUID) VALUES (";
                            InsertDetalleCompra += inserted.ToString() + "," + Producto.CveProducto + "," + Producto.Cantidad + "," + Producto.CostoPromedio + "," + Producto.Iva + "," + Producto.PrecioTotal + "," + Producto.DescuentoAplicado + "," + Producto.PrecioUnitarioOriginal + "," + Producto.Descuento + "," + Producto.CveColor + "," + Producto.CveAlmacen + ",'" + strGuid + "')";


                            command.CommandText = InsertDetalleCompra;

                            command.ExecuteNonQuery();

                 
                        }

                        transaction.Commit();


                        _resulregresa = true;

                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Commit Exception Type: " + ex.GetType());
                    MessageBox.Show(" Message: " + ex.Message);

                    _resulregresa = false;
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();

                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        MessageBox.Show("Rollback Exception Type: " + ex2.GetType());
                        MessageBox.Show("Message: " + ex2.Message);

                    }
                }


            }


            return _resulregresa;
        }

        public bool SaveRecepcion()
        {
            bool _resulregresa = false;

            int inserted = 0;
            int Folio = 0;
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "Compras";

                    Folio = help.Result(connection, transaction);


                    string strGuid = Guid.NewGuid().ToString();

                    string InsertCompra = "INSERT INTO RecepcionCompras (CveProveedor, CvePedido, Folio, CveFormaPago, NumeroFactura, FechaFactura, FechaRecepcion, SubTotal, GastosIndirectos, Descuento, Iva, Total, CveEstatus, CveUser, CveAlmacen, Sys_GUID, CveTipoDocumento) VALUES(";
                    InsertCompra += CveProveedor + "," + CvePedido + "," + Folio + "," + CveFormaPago + ",'" + NumeroFactura + "','" + FechaFactura + "','" + FechaRecepcion + "',";
                    InsertCompra += SubTotal + "," + GasTosIndirectos + "," + DescuentoTotal + "," + Iva + "," + Total + "," + CveEstatus + "," + CveUser + "," + CveAlmacen + ",'" + strGuid + "'," + CveTipoDocumento + ")";

                    command.CommandText = InsertCompra;

                    command.ExecuteNonQuery();

                    command.CommandText = "Select SCOPE_IDENTITY()";
                    inserted = Convert.ToInt32(command.ExecuteScalar());


                    if (inserted > 0)
                    {
                        // SI LA VENTA ES A CRÉDITO INSERTAMOS EL IMPORTE EN LA TABLA DE CUENTAS POR PAGAR
                        if (CveFormaPago == 2)
                        {

                            //int DiasCredito = GetIntField("DiasCredito", "ProveedoresCredito", "CveProveedor", this.cboxProveedor.SelectedValue.ToString());

                            string insertCuentaPorPagar = "INSERT INTO CuentasPorPagar (CveCuenta, CveDocumento, CveProveedor, Fecha, FechaRecepcion, CveConcepto, Importe, Saldo, CveUser) VALUES (";
                            insertCuentaPorPagar += "0," + inserted.ToString() + "," + CveProveedor + ",'" + FechaFactura + "','" + FechaRecepcion + "'," + CveEstatus + "," + Total + "," + Total + "," + CveUser + ")";

                            command.CommandText = insertCuentaPorPagar;
                            command.ExecuteNonQuery();

                        }


                        decimal SubTotalCredito = 0, CantidadInventario = 0; int Cuenta = 0;
                        foreach (PageBase.ProductoCompra Producto in ListaProductos)
                        {

                            //Guardar Detalles de Kardex.

                            DataTable _dtResultUltimoKardex = _dtUltimoKardex(Producto.CveAlmacen, int.Parse(Producto.CveProducto), connection, transaction);

                            string QueryKardex = "";
                            int CveKardex = 0;

                            decimal NuevoSaldo = 0;
                            decimal NuevoCostoPromedio = 0;
                            decimal NuevoUltimoCosto = 0;


                            if (_dtResultUltimoKardex.Rows.Count == 0)
                            {

                                NuevoSaldo = Producto.Cantidad;
                                NuevoCostoPromedio = Producto.CostoPromedio;
                                NuevoUltimoCosto = NuevoCostoPromedio;
                            }
                            else
                            {

                                foreach (DataRow Kardex in _dtResultUltimoKardex.Rows)
                                {

                                    NuevoSaldo = decimal.Parse(Kardex["Saldo"].ToString()) + Producto.Cantidad;

                                    NuevoCostoPromedio = (decimal.Parse(Kardex["CostoPromedio"].ToString()) * decimal.Parse(Kardex["Saldo"].ToString()) +
                                                        Producto.CostoPromedio * Producto.Cantidad) / NuevoSaldo;

                                    NuevoUltimoCosto = Producto.PrecioUnitarioOriginal / Producto.Cantidad;

                                }
                            }

                            QueryKardex = "Insert Into Kardex(FechaCompra, FechaRecepcion, CveAlmacen, CveProducto, CveDocumento, NoDocumento, ";
                            QueryKardex += "CveTipoDocumento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio) Values('";
                            QueryKardex += FechaFactura + "','" + FechaRecepcion + "'," + CveAlmacen + "," + Producto.CveProducto + ",";
                            QueryKardex += inserted + ",'" + Folio + "'," + CveTipoDocumento + "," + Producto.Cantidad + ",0,";
                            QueryKardex += NuevoSaldo + "," + Producto.CostoPromedio + "," + NuevoCostoPromedio + ")";


                            command.CommandText = QueryKardex;
                            command.ExecuteNonQuery();


                            command.CommandText = "Select SCOPE_IDENTITY()";
                            CveKardex = Convert.ToInt32(command.ExecuteScalar());

                            string InsertDetalleCompra = "INSERT INTO ComprasDetalle (CveCompra, CveProducto, Cantidad, CostoUnitario, CveKardex, Iva, Total, DescuentoAplicado, CostoUnitarioOriginal, Descuento, CveColor, CveAlmacen, Sys_GUID) VALUES (";
                            InsertDetalleCompra += inserted.ToString() + "," + Producto.CveProducto + "," + Producto.Cantidad + "," + Producto.CostoPromedio + "," + CveKardex + "," + Producto.Iva + "," + Producto.PrecioTotal + "," + Producto.DescuentoAplicado + "," + Producto.PrecioUnitarioOriginal + "," + Producto.Descuento + "," + Producto.CveColor + "," + Producto.CveAlmacen + ",'" + strGuid + "')";


                            command.CommandText = InsertDetalleCompra;

                            command.ExecuteNonQuery();

                            /*
                            command.CommandText = "Select SCOPE_IDENTITY()";1

                            int inserted2 = int.Parse(command.ExecuteScalar().ToString());
                            */


                            string QueryUpdateProducto = "Update Productos Set UltimoCosto=" + Producto.PrecioUnitarioOriginal + ",CantidadUltimaCompra=" + Producto.Cantidad + ",FechaUltimaCompra='" + FechaFactura + "'  Where CveProducto=" + Producto.CveProducto;
                            command.CommandText = QueryUpdateProducto;
                            command.ExecuteNonQuery();

                            SubTotalCredito += decimal.Parse(Producto.Cantidad.ToString()) * decimal.Parse(Producto.PrecioUnitarioOriginal.ToString());



                            Cuenta = 0;
                            CantidadInventario = 0;

                            string QueryCuenta = "Select count(*) As Cuenta From ProductoColor Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;

                            Cuenta = int.Parse(cPage.GetStrFieldQuery("Cuenta", QueryCuenta, connection, transaction));


                            if (Cuenta > 0)
                            {
                                string QueryCantidadInventario = "Select Cantidad From ProductoColor Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;
                                CantidadInventario = decimal.Parse(cPage.GetStrFieldQuery("Cantidad", QueryCantidadInventario, connection, transaction));
                            }

                            string QueryInsertMov = "Insert Into MovimientosInventario(CveTipoMovimiento,CveProducto,Habia,Cantidad,CveUser,Hora,Fecha, CveAlmacen, CveOrigen) Values(1," + Producto.CveProducto + "," + CantidadInventario + "," + Producto.Cantidad + "," + CveUser + ",'" + Fecha + "','" + Hora + "'," + Producto.CveAlmacen + ",7)";

                            command.CommandText = QueryInsertMov;
                            command.ExecuteNonQuery();

                            //performinsertquery(QueryInsertMov);

                            if (Cuenta == 0)
                            {

                                string QueryProductoColor = "Insert Into ProductoColor( CveProducto, CveColor, Cantidad, CveAlmacen) Values(" + Producto.CveProducto + "," + Producto.CveColor + "," + Producto.Cantidad + "," + Producto.CveAlmacen + ")";

                                command.CommandText = QueryProductoColor;
                                command.ExecuteNonQuery();
                                //performupdatequery(QueryProductoColor);
                            }
                            else
                            {
                                string QueryUpdate = "Update ProductoColor Set Cantidad=Cantidad + " + Producto.Cantidad + " Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;
                                command.CommandText = QueryUpdate;
                                command.ExecuteNonQuery();
                                //performupdatequery(QueryUpdate);
                            }


                            //}


                        }

                        /*CalculoFinal_2(connection, transaction);
                        string QueryIva = "Select Iva From CatIva Where CveIva=1";
                        decimal IvaA = decimal.Parse(cPage.GetStrFieldQuery("Iva", QueryIva, connection, transaction));
                        Iva = SubTotalCredito * IvaA;
                        Total = SubTotalCredito + Iva;
                        */



                        transaction.Commit();


                        _resulregresa = true;

                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Commit Exception Type: " + ex.GetType());
                    MessageBox.Show(" Message: " + ex.Message);

                    _resulregresa = false;
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();

                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        MessageBox.Show("Rollback Exception Type: " + ex2.GetType());
                        MessageBox.Show("Message: " + ex2.Message);

                    }
                }


            }


            return _resulregresa;
        }

        public bool SaveRequisicion()
        {
            bool _resulregresa = false;

            int inserted = 0;
            int Folio = 0;
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "Compras";

                    Folio = help.Result(connection, transaction);


                    string strGuid = Guid.NewGuid().ToString();

                    string InsertCompra = "INSERT INTO Compras (CveProveedor, CvePedido, Folio, CveFormaPago, NumeroFactura, FechaFactura, FechaRecepcion, SubTotal, GastosIndirectos, Descuento, Iva, Total, CveEstatus, CveUser, CveAlmacen, Sys_GUID, CveTipoDocumento) VALUES(";
                    InsertCompra += CveProveedor + "," + CvePedido + "," + Folio + "," + CveFormaPago + ",'" + NumeroFactura + "','" + FechaFactura + "','" + FechaRecepcion + "',";
                    InsertCompra += SubTotal + "," + GasTosIndirectos + "," + DescuentoTotal + "," + Iva + "," + Total + "," + CveEstatus + "," + CveUser + "," + CveAlmacen + ",'" + strGuid + "'," + CveTipoDocumento + ")";

                    command.CommandText = InsertCompra;

                    command.ExecuteNonQuery();

                    command.CommandText = "Select SCOPE_IDENTITY()";
                    inserted = Convert.ToInt32(command.ExecuteScalar());


                    if (inserted > 0)
                    {
                        // SI LA VENTA ES A CRÉDITO INSERTAMOS EL IMPORTE EN LA TABLA DE CUENTAS POR PAGAR
                        if (CveFormaPago == 2)
                        {

                            //int DiasCredito = GetIntField("DiasCredito", "ProveedoresCredito", "CveProveedor", this.cboxProveedor.SelectedValue.ToString());

                            string insertCuentaPorPagar = "INSERT INTO CuentasPorPagar (CveCuenta, CveDocumento, CveProveedor, Fecha, FechaRecepcion, CveConcepto, Importe, Saldo, CveUser) VALUES (";
                            insertCuentaPorPagar += "0," + inserted.ToString() + "," + CveProveedor + ",'" + FechaFactura + "','" + FechaRecepcion + "'," + CveEstatus + "," + Total + "," + Total + "," + CveUser + ")";

                            command.CommandText = insertCuentaPorPagar;
                            command.ExecuteNonQuery();

                        }


                        decimal SubTotalCredito = 0, CantidadInventario = 0; int Cuenta = 0;
                        foreach (PageBase.ProductoCompra Producto in ListaProductos)
                        {

                            //Guardar Detalles de Kardex.

                            DataTable _dtResultUltimoKardex = _dtUltimoKardex(Producto.CveAlmacen, int.Parse(Producto.CveProducto), connection, transaction);

                            string QueryKardex = "";
                            int CveKardex = 0;

                            decimal NuevoSaldo = 0;
                            decimal NuevoCostoPromedio = 0;
                            decimal NuevoUltimoCosto = 0;


                            if (_dtResultUltimoKardex.Rows.Count == 0)
                            {

                                NuevoSaldo = Producto.Cantidad;
                                NuevoCostoPromedio = Producto.CostoPromedio;
                                NuevoUltimoCosto = NuevoCostoPromedio;
                            }
                            else
                            {

                                foreach (DataRow Kardex in _dtResultUltimoKardex.Rows)
                                {

                                    NuevoSaldo = decimal.Parse(Kardex["Saldo"].ToString()) + Producto.Cantidad;

                                    NuevoCostoPromedio = (decimal.Parse(Kardex["CostoPromedio"].ToString()) * decimal.Parse(Kardex["Saldo"].ToString()) +
                                                        Producto.CostoPromedio * Producto.Cantidad) / NuevoSaldo;

                                    NuevoUltimoCosto = Producto.PrecioUnitarioOriginal / Producto.Cantidad;

                                }
                            }

                            QueryKardex = "Insert Into Kardex(FechaCompra, FechaRecepcion, CveAlmacen, CveProducto, CveDocumento, NoDocumento, ";
                            QueryKardex += "CveTipoDocumento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio) Values('";
                            QueryKardex += FechaFactura + "','" + FechaRecepcion + "'," + CveAlmacen + "," + Producto.CveProducto + ",";
                            QueryKardex += inserted + ",'" + Folio + "'," + CveTipoDocumento + "," + Producto.Cantidad + ",0,";
                            QueryKardex += NuevoSaldo + "," + Producto.CostoPromedio + "," + NuevoCostoPromedio + ")";


                            command.CommandText = QueryKardex;
                            command.ExecuteNonQuery();


                            command.CommandText = "Select SCOPE_IDENTITY()";
                            CveKardex = Convert.ToInt32(command.ExecuteScalar());

                            string InsertDetalleCompra = "INSERT INTO ComprasDetalle (CveCompra, CveProducto, Cantidad, CostoUnitario, CveKardex, Iva, Total, DescuentoAplicado, CostoUnitarioOriginal, Descuento, CveColor, CveAlmacen, Sys_GUID) VALUES (";
                            InsertDetalleCompra += inserted.ToString() + "," + Producto.CveProducto + "," + Producto.Cantidad + "," + Producto.CostoPromedio + "," + CveKardex + "," + Producto.Iva + "," + Producto.PrecioTotal + "," + Producto.DescuentoAplicado + "," + Producto.PrecioUnitarioOriginal + "," + Producto.Descuento + "," + Producto.CveColor + "," + Producto.CveAlmacen + ",'" + strGuid + "')";


                            command.CommandText = InsertDetalleCompra;

                            command.ExecuteNonQuery();

                            /*
                            command.CommandText = "Select SCOPE_IDENTITY()";1

                            int inserted2 = int.Parse(command.ExecuteScalar().ToString());
                            */


                            string QueryUpdateProducto = "Update Productos Set UltimoCosto=" + Producto.PrecioUnitarioOriginal + ",CantidadUltimaCompra=" + Producto.Cantidad + ",FechaUltimaCompra='" + FechaFactura + "'  Where CveProducto=" + Producto.CveProducto;
                            command.CommandText = QueryUpdateProducto;
                            command.ExecuteNonQuery();

                            SubTotalCredito += decimal.Parse(Producto.Cantidad.ToString()) * decimal.Parse(Producto.PrecioUnitarioOriginal.ToString());



                            Cuenta = 0;
                            CantidadInventario = 0;

                            string QueryCuenta = "Select count(*) As Cuenta From ProductoColor Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;

                            Cuenta = int.Parse(cPage.GetStrFieldQuery("Cuenta", QueryCuenta, connection, transaction));


                            if (Cuenta > 0)
                            {
                                string QueryCantidadInventario = "Select Cantidad From ProductoColor Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;
                                CantidadInventario = decimal.Parse(cPage.GetStrFieldQuery("Cantidad", QueryCantidadInventario, connection, transaction));
                            }

                            string QueryInsertMov = "Insert Into MovimientosInventario(CveTipoMovimiento,CveProducto,Habia,Cantidad,CveUser,Hora,Fecha, CveAlmacen, CveOrigen) Values(1," + Producto.CveProducto + "," + CantidadInventario + "," + Producto.Cantidad + "," + CveUser + ",'" + Fecha + "','" + Hora + "'," + Producto.CveAlmacen + ",7)";

                            command.CommandText = QueryInsertMov;
                            command.ExecuteNonQuery();

                            //performinsertquery(QueryInsertMov);

                            if (Cuenta == 0)
                            {

                                string QueryProductoColor = "Insert Into ProductoColor( CveProducto, CveColor, Cantidad, CveAlmacen) Values(" + Producto.CveProducto + "," + Producto.CveColor + "," + Producto.Cantidad + "," + Producto.CveAlmacen + ")";

                                command.CommandText = QueryProductoColor;
                                command.ExecuteNonQuery();
                                //performupdatequery(QueryProductoColor);
                            }
                            else
                            {
                                string QueryUpdate = "Update ProductoColor Set Cantidad=Cantidad + " + Producto.Cantidad + " Where CveProducto=" + Producto.CveProducto + " And CveAlmacen=" + Producto.CveAlmacen;
                                command.CommandText = QueryUpdate;
                                command.ExecuteNonQuery();
                                //performupdatequery(QueryUpdate);
                            }


                            //}


                        }

                        /*CalculoFinal_2(connection, transaction);
                        string QueryIva = "Select Iva From CatIva Where CveIva=1";
                        decimal IvaA = decimal.Parse(cPage.GetStrFieldQuery("Iva", QueryIva, connection, transaction));
                        Iva = SubTotalCredito * IvaA;
                        Total = SubTotalCredito + Iva;
                        */



                        transaction.Commit();


                        _resulregresa = true;

                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Commit Exception Type: " + ex.GetType());
                    MessageBox.Show(" Message: " + ex.Message);

                    _resulregresa = false;
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();

                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        MessageBox.Show("Rollback Exception Type: " + ex2.GetType());
                        MessageBox.Show("Message: " + ex2.Message);

                    }
                }


            }


            return _resulregresa;
        }
    }
}
