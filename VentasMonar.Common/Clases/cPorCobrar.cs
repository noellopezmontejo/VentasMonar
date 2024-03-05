using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static VentasMonar.Common.PageBase;
//using Syncfusion.DocIO.DLS;

namespace VentasMonar.Common.Clases
{
    public class cPorCobrar
    {
       
        public int CveCliente { get; set; }


        public static DataTable _dtUltimoKardexCta(int CveReceptor, SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {

            DataTable _dtResult = new DataTable();

            /*
            string QueryResult = "SELECT * FROM Kardex_CuentaCliente KCC WHERE CveCliente= " + CveCliente +
                " AND CveKardex=(SELECT MAX(CveKardex) AS CveKardex FROM Kardex_CuentaCliente " +
                "WHERE CveCliente=" + CveCliente + " AND CveEstatus=1);";
            */
            cPageBase cPage = new cPageBase();

            ArrayList _ListaParametros = new ArrayList();
            _ListaParametros.Add(cPage.addparametro("CveReceptor", CveReceptor.ToString(), "int"));

            _dtResult = cPage.SP_Busca_Reader(_ListaParametros, "SP_ConsultaKardex_CuentaReceptor", connection, transaction);


            return _dtResult;

        }

        public static int GenerarKardexPorCobrarAbono(int CveAbono, int CveReceptor, int CveCuenta_, int CveFactura,  int Folio,  int CveTipoDocumento_, decimal TotalFactura, string FechaMovimiento, SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            string QueryKardex = "";
            int CveKardex = 0;

            decimal NuevoSaldo = 0;
            decimal NuevaCompra = 0;


            DataTable _dtResultUltimoKardexPorPagar = _dtUltimoKardexCta(CveReceptor, command, connection, transaction);



            if (_dtResultUltimoKardexPorPagar.Rows.Count == 0)
            {

                NuevoSaldo = TotalFactura;
                NuevaCompra = TotalFactura;


                //Termina Valores de Kardex

            }
            else
            {

                foreach (DataRow Kardex in _dtResultUltimoKardexPorPagar.Rows)
                {

                    NuevoSaldo = decimal.Parse(Kardex["Saldo"].ToString()) - TotalFactura;
                    NuevaCompra = TotalFactura;

                }
            }

            ArrayList _ListaFactura = new ArrayList();

            /*
             * 
             *  ListParameters.Add(cm.addparametro("CveCuenta", CveCuenta.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Folio", item.FolioInt, "int"));
                ListParameters.Add(cm.addparametro("CveTipoDocumento", item.CveTipoFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("FechaMovimiento", DateTime.Parse(item.FechaEmision).ToShortDateString(), "string"));
                ListParameters.Add(cm.addparametro("Ventas", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Abonos", "0.00", "decimal"));
                ListParameters.Add(cm.addparametro("Saldo", item.Total.ToString(), "decimal"));
          
                ListParameters.Add(cm.addparametro("sGuid", item.strGuid, "string"));

             * */

            cFacturacion40.Parametros parametros = new cFacturacion40.Parametros
            {
                CveReceptor = CveReceptor,
                CveDocumento=Folio,
                CveCuenta=CveCuenta_,
                CveAbono=CveAbono,
                FolioInt = Folio.ToString(),
                CveTipoFactura = CveTipoDocumento_,
                CveTipoDocumento=CveTipoDocumento_,
                FechaEmision = FechaMovimiento,
                //Total=TotalFactura,
                Abono = NuevaCompra,
                NuevoSaldo = NuevoSaldo,
                strGuid = Guid.NewGuid().ToString()
            };
            _ListaFactura.Add(parametros);
            

            cFacturacion40 facturacion = new cFacturacion40();
            CveKardex = facturacion.SaveCxC_KardexAbonos(_ListaFactura, CveFactura, CveCuenta_, connection, transaction);



            return CveKardex;
        }

        public static int GenerarKardexPorCobrarAbono(int CveCuenta, int CveFactura, ArrayList _ListaFactura, SqlCommand command, SqlConnection cn, SqlTransaction transaction)
        {
            string QueryKardex = "";
            int CveKardex = 0;

            decimal NuevoSaldo = 0;
            decimal NuevaCompra = 0;

            foreach (cFacturacion40.Parametros item in _ListaFactura)
            {
                DataTable _dtResultUltimoKardexPorPagar = _dtUltimoKardexCta(item.CveReceptor, command, cn,transaction);


                if (_dtResultUltimoKardexPorPagar.Rows.Count == 0)
                {

                    NuevoSaldo =item.Total;
                    NuevaCompra = item.Total;

                    item.NuevoSaldo = NuevoSaldo;
                    item.Venta = NuevaCompra;

                    //Termina Valores de Kardex

                }
                else
                {

                    foreach (DataRow Kardex in _dtResultUltimoKardexPorPagar.Rows)
                    {

                        NuevoSaldo = decimal.Parse(Kardex["Saldo"].ToString()) + item.Total;
                        NuevaCompra = item.Total;

                        item.NuevoSaldo = NuevoSaldo;
                        item.Venta = NuevaCompra;


                    }
                }

                cFacturacion40 facturacion = new cFacturacion40();
                CveKardex = facturacion.SaveCxC_Kardex(_ListaFactura, CveFactura, CveCuenta, cn, transaction);



            }


            /*

            QueryKardex = "Insert Into Kardex_CuentaCliente(FechaMovimiento, CveCliente, CveCuenta,CveDocumento, Folio, NoDocumento, ";
            QueryKardex += "CveTipoDocumento, Compras, Abonos, Saldo) Values('";
            QueryKardex += FechaMovimiento + "'," + CveCliente_ + "," + CveCuenta_ + ",";
            QueryKardex += CveCompra_ + "," + Folio + ",'" + NoDocumento + "'," + CveTipoDocumento_ + "," + NuevaCompra + ",0,";
            QueryKardex += NuevoSaldo + ")";


            command.CommandText = QueryKardex;
            command.ExecuteNonQuery();


            command.CommandText = "Select LAST_INSERT_ID();";
            CveKardex = Convert.ToInt32(command.ExecuteScalar());

            */



            return CveKardex;
        }

        public static int GenerarKardexPorCobrarCancelaAbono(int CveCuenta, int CveFactura, ArrayList ListaFactura , SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            string QueryKardex = "";
            int CveKardex = 0;

            decimal NuevoSaldo = 0;
            decimal NuevaCompra = 0;

            DataTable _dtResultUltimoKardexPorPagar = new DataTable();

            foreach (cFacturacion40.Parametros item in ListaFactura)
            {
                _dtResultUltimoKardexPorPagar = _dtUltimoKardexCta(item.CveReceptor, command,connection,transaction);




                if (_dtResultUltimoKardexPorPagar.Rows.Count == 0)
                {

                    NuevoSaldo = item.Total;
                    NuevaCompra = item.Total;


                    //Termina Valores de Kardex

                }
                else
                {

                    foreach (DataRow Kardex in _dtResultUltimoKardexPorPagar.Rows)
                    {

                        NuevoSaldo = decimal.Parse(Kardex["Saldo"].ToString()) + item.Total;
                        NuevaCompra = item.Total;

                    }
                }

                item.Venta = NuevaCompra;
                item.NuevoSaldo = NuevoSaldo;

            }

            cFacturacion40 facturacion = new cFacturacion40();
            CveKardex = facturacion.SaveCxC_KardexCancelado(ListaFactura, CveFactura, CveCuenta, connection, transaction);

            return CveKardex;
        }


        public static DataTable BusquedaReceptorSaldo(string Busqueda, string strconexion)
        {
            DataTable _dtResult = new DataTable();

            /*
            string QueryResult = "SELECT * FROM Kardex_CuentaCliente KCC WHERE CveCliente= " + CveCliente +
                " AND CveKardex=(SELECT MAX(CveKardex) AS CveKardex FROM Kardex_CuentaCliente " +
                "WHERE CveCliente=" + CveCliente + " AND CveEstatus=1);";
            */
            cPageBase cPage = new cPageBase();

            ArrayList _ListaParametros = new ArrayList();
            _ListaParametros.Add(cPage.addparametro("Busqueda", Busqueda, "string"));

            _dtResult = cPage.SP_Busca_Reader(_ListaParametros, "SP_SaldoClientes_Busqueda");


            return _dtResult;
        }

        public static DataTable BusquedaReceptorId(int CveReceptor)
        {
            DataTable _dtResult = new DataTable();

            cPageBase cPage = new cPageBase();

            ArrayList _ListaParametros = new ArrayList();
            _ListaParametros.Add(cPage.addparametro("CveReceptor", CveReceptor.ToString(), "int"));

            _dtResult = cPage.SP_Busca_Reader(_ListaParametros, "SP_GetCuentasIdReceptor");


            return _dtResult;
        }
        public static DataTable BusquedaAbonoReceptorId(int Cvecuenta)
        {
            DataTable _dtResult = new DataTable();

            cPageBase cPage = new cPageBase();

            ArrayList _ListaParametros = new ArrayList();
            _ListaParametros.Add(cPage.addparametro("CveCuenta", Cvecuenta.ToString(), "int"));

            _dtResult = cPage.SP_Busca_Reader(_ListaParametros, "SP_GetAbonosReceptorId");


            return _dtResult;
        }



    }
}
