using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Common.Clases
{
    class Embarques : Clases.cPageBase
    {

        public class Almacenes
        {
            private int intCveAlmacen;
            private string strAlmacen;

            public string StrAlmacen
            {
                get { return strAlmacen; }
                set { strAlmacen = value; }
            } 
            public int IntCveAlmacen
            {
                get { return intCveAlmacen; }
                set { intCveAlmacen = value; }
            }
        }

        public class VentasEmbarques
        {
            private int intCveNota;

            public int IntCveNota
            {
                get { return intCveNota; }
                set { intCveNota = value; }
            }
        }

        public bool Guardar(ArrayList Lista, int CveChofer, int CveUser = 1, int CveRuta = 1, int CveVehiculo = 1, ArrayList ListaProductosVta=null)
        {
            bool guarda = false;
            string Fecha = ObtenerFechaHora(1);
            string Hora=ObtenerFechaHora(2);
            string NoDocumento = ObtenerFolio(15); // 15 pertenece al Tipo de Documento Embarque

            string query="Insert Into Embarque(FechaEmbarque, NoDocumento, CveRuta, CveVehiculo, CveChofer, CveEstatus, CveUser) Values ('" + SwitchDate(Fecha,1) + "','" + NoDocumento + "',"  + CveRuta + "," + CveVehiculo + "," + CveChofer + ",1," + CveUser + ")";

            int CveEmbarque = performinsertquery(query);

            if (CveEmbarque > 0)
            {

                foreach (ProductoCompra item in Lista)
                
                {

                    string QueryDetalle = "Insert into EmbarqueDetalle(CveEmbarque, CveDocumento, CveChofer, CveEstatus, CveUser, FechaEmbarque, HoraEmbarque) Values (";
                        QueryDetalle += CveEmbarque + "," + item.CveDocumento + "," + CveChofer + ",2," + CveUser + ",'" + SwitchDate(Fecha,1) + "','" + Hora + "')";

                    int CveEmbarqueDetalle=performinsertquery(QueryDetalle);

                    item.CveEmbarqueDetalle = CveEmbarqueDetalle;

                }
                if(ListaProductosVta.Count>0)
               Guardar_Salida_Almacen_A(Lista, CveEmbarque,CveChofer, 1, CveUser);

                foreach (ProductoCompra item in Lista)
                {
                    string QueryUpdate = "Update Ventas Set CveEstatusEntrega=2 Where CveNota=" + item.CveNota;

                    performinsertquery(QueryUpdate, 1);
                }

                guarda = true;          

            }


            return guarda;

        }
        public bool GuardarUpdate(ArrayList Lista, int CveEmbarque, int CveChofer=1, int CveUser=1)
        {
            bool guarda = false;
            string Fecha = ObtenerFechaHora(1);
            string Hora = ObtenerFechaHora(2);
            /*
            string NoDocumento = ObtenerFolio(15); // 15 pertenece al Tipo de Documento Embarque

            string query = "Insert Into Embarque(FechaEmbarque, NoDocumento, CveRuta, CveVehiculo, CveChofer, CveEstatus, CveUser) Values ('" + SwitchDate(Fecha, 1) + "','" + NoDocumento + "'," + CveRuta + "," + CveVehiculo + "," + CveChofer + ",1," + CveUser + ")";

            int CveEmbarque = performinsertquery(query);
            */
            if (CveEmbarque > 0)
            {

               // string QueryDeteleDetalleEmbarque = "Delete From EmbarqueDetalle Where CveEmbarque=" + CveEmbarque;
                //performupdatequery(QueryDeteleDetalleEmbarque);

                foreach (ProductoCompra item in Lista)
                {

                    if (item.Actualizar)
                    {
                        string QueryDelete_EmbarqueDetalle = "Delete From EmbarqueDetalle Where CveEmbarqueDetalle=" + item.CveEmbarqueDetalle;
                        performupdatequery(QueryDelete_EmbarqueDetalle);

                        string QueryDetalle = "Insert into EmbarqueDetalle(CveEmbarque, CveDocumento, CveChofer, CveEstatus, CveUser, FechaEmbarque, HoraEmbarque) Values (";
                        QueryDetalle += CveEmbarque + "," + item.CveDocumento + "," + CveChofer + ",2," + CveUser + ",'" + SwitchDate(Fecha, 1) + "','" + Hora + "')";

                        int CveEmbarqueDetalle = performinsertquery(QueryDetalle);

                        item.CveEmbarqueDetalle = CveEmbarqueDetalle;
                    }
                }
                if (Lista.Count > 0)
                    Guardar_Salida_Almacen_A(Lista, CveEmbarque, CveChofer, 1, CveUser,1,1);

                foreach (ProductoCompra item in Lista)
                {
                    string QueryUpdate = "Update Ventas Set CveEstatusEntrega=2 Where CveNota=" + item.CveNota;

                    performinsertquery(QueryUpdate, 1);
                }

                guarda = true;

            }


            return guarda;

        }

        public double Guardar_Embarque_Parcial_A1(ArrayList Lista, int CveUser = 1, int CveDocumento = 1)
        {
            double CantidadAfectar = 0;

            string Fecha = ObtenerFechaHora(1);
            if (Lista.Count > 0)
            {
                string querydelete = "Delete From EmbarqueDetalle_Temp_A Where CveDocumento=" + CveDocumento;
                performupdatequery(querydelete);

                foreach (ProductoCompra item in Lista)
                {


                    string queryinsert = "Insert Into EmbarqueDetalle_Temp_A(CveEmbarqueDetalle, CveDocumento, CveVentaDetalle, CveProducto, CveAlmacen, Cantidad, CveUser, Fecha) Values(";
                    queryinsert += item.CveEmbarqueDetalle + "," + item.CveDocumento + "," + item.IntCveNotaDetalle + "," + item.CveProducto + "," + item.CveAlmacen + "," + item.DblAfectar + "," + CveUser + ",'" + SwitchDate(Fecha, 1) + "')";

                    performinsertquery(queryinsert);

                    CantidadAfectar += item.DblAfectar;

                }

            }



            return CantidadAfectar;

        }

        public double Guardar_Embarque_Parcial(ArrayList Lista, int CveUser=1, int CveDocumento=1, int CveAlmacen=1)
        {
            double CantidadAfectar = 0;

            string Fecha = ObtenerFechaHora(1);
            if (Lista.Count > 0)
            {
                string querydelete = "Delete From EmbarqueDetalle_Temp Where CveDocumento=" + CveDocumento + " And CveAlmacen=" + CveAlmacen;
                performupdatequery(querydelete);

                foreach (ProductoCompra item in Lista)
                {
                   

                    string queryinsert = "Insert Into EmbarqueDetalle_Temp(CveEmbarqueDetalle, CveDocumento, CveVentaDetalle, CveProducto, CveAlmacen, Cantidad, CveUser, Fecha) Values(";
                    queryinsert += item.CveEmbarqueDetalle + "," + item.CveDocumento + "," + item.IntCveNotaDetalle + "," + item.CveProducto + "," + item.CveAlmacen + "," + item.DblAfectar + "," + CveUser + ",'" + SwitchDate(Fecha, 1) + "')";

                    performinsertquery(queryinsert);

                    CantidadAfectar += item.DblAfectar;
                    
                }

            }



            return CantidadAfectar;

        }

        private ArrayList Lista_EmbarqueDetalleTemp(int CveEmbarqueDetalle, int CveAlmacen)
        {
            ArrayList Lista = new ArrayList();

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveEmbarqueDetalle", CveEmbarqueDetalle.ToString(), "int"));
            ListaParametro.Add(addparametro("CveAlmacen", CveAlmacen.ToString(), "int"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueDetalle_Temp");

            foreach (DataRow rw in _dt.Rows)
            {
                ProductoCompra item = new ProductoCompra();

                item.CveEmbarqueDetalle = int.Parse(rw["CveEmbarqueDetalle"].ToString());
                item.IntCveNotaDetalle = int.Parse(rw["CveVentaDetalle"].ToString());
                item.CveDocumento = int.Parse(rw["CveDocumento"].ToString());
                item.CveProducto = rw["CveProducto"].ToString();
                item.CveAlmacen = int.Parse(rw["CveAlmacen"].ToString());
                item.Cantidad = double.Parse(rw["Cantidad"].ToString());

                Lista.Add(item);


            }



            return Lista;
        }

        private ArrayList Lista_EmbarqueDetalleTemp_A(int CveDocumento)
        {
            ArrayList Lista = new ArrayList();

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveDocumento", CveDocumento.ToString(), "int"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueDetalle_Temp_A");

            foreach (DataRow rw in _dt.Rows)
            {
                ProductoCompra item = new ProductoCompra();

                item.CveEmbarqueDetalle = int.Parse(rw["CveEmbarqueDetalle"].ToString());
                item.IntCveNotaDetalle = int.Parse(rw["CveVentaDetalle"].ToString());
                item.CveDocumento = int.Parse(rw["CveDocumento"].ToString());
                item.CveProducto = rw["CveProducto"].ToString();
                item.CveAlmacen = int.Parse(rw["CveAlmacen"].ToString());
                item.Cantidad = double.Parse(rw["Cantidad"].ToString());

                Lista.Add(item);


            }



            return Lista;
        }
        private void Delete_EmbarqueDetalleTemp_A(int CveDocumento)
        {


            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveDocumento", CveDocumento.ToString(), "int"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueDetalle_Temp_Delete_A");
        }

        private void Delete_EmbarqueDetalleTemp(int CveEmbarqueDetalle, int CveAlmacen)
        {
          

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveEmbarqueDetalle", CveEmbarqueDetalle.ToString(), "int"));
            ListaParametro.Add(addparametro("CveAlmacen", CveAlmacen.ToString(), "int"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueDetalle_Temp_Delete");
        }


        public bool Guardar_Salida_Almacen_A(ArrayList Lista, int CveEmbarque, int CveChofer, int CveTipoMovimiento=1, int CveUser = 1, int CveAlmacen = 1,  int Update=0)
        {
            bool guarda = false;
            string Fecha = ObtenerFechaHora(1);
            string time = ObtenerFechaHora(2);
            string query = "";
            int CveEstatusEmbarqueAlmacen = 0;
            /*
            if (CveTipoMovimiento == 0) // Movimiento para Embarcar productos
            {
                query = "Update Embarque Set Fecha_Despachado_Embarque='" + SwitchDate(Fecha, 1) + "',  Hora_Despachado_Embarque='" + time + "', CveUser_Despachado_Embarque=" + CveUser + ", CveEstatus=2  Where CveEmbarque=" + CveEmbarque;
                //string query = "Insert Into Embarque(FechaEmbarque, CveRuta, CveVehiculo, CveChofer, CveEstatus, CveUser) Values ('" + SwitchDate(Fecha, 1) + "'," + CveRuta + "," + CveVehiculo + "," + CveChofer + ",1," + CveUser + ")";
            }
            else
            {
                query = "Update Embarque Set Fecha_Retorno_Embarque='" + SwitchDate(Fecha, 1) + "',  Hora_Retorno_Embarque='" + time + "', CveUser_Retorno_Embarque=" + CveUser + ", CveEstatus=3  Where CveEmbarque=" + CveEmbarque;
            }

            performinsertquery(query, 1);
            */


            if (CveEmbarque > 0)
            {

                foreach (ProductoCompra item in Lista)
                {
                    if (Update == 0)
                    {
                        ArrayList ListaVtasParciales = new ArrayList();

                        ListaVtasParciales = Lista_EmbarqueDetalleTemp_A(item.CveDocumento);

                        foreach (Clases.cPageBase.ProductoCompra itemPar in ListaVtasParciales)
                        {

                            string QueryDelete = "Delete From EmbarqueAlmacen Where CveEmbarqueDetalle=" + item.CveEmbarqueDetalle + " And CveVentaDetalle=" + item.IntCveNotaDetalle;
                            performupdatequery(QueryDelete);

                            string QueryInsert = "";

                            QueryInsert = "Insert into  EmbarqueAlmacen(CveEmbarqueDetalle,  CveVentaDetalle, CveAlmacen, CveProducto, Cantidad, PrecioUnitario, Fecha_Despacho_Embarque, Hora_Despacho_Embarque, CveUser_Despacho_Embarque, CveTipoEmbarque) Values(";
                            QueryInsert += item.CveEmbarqueDetalle + "," + itemPar.IntCveNotaDetalle + "," + itemPar.CveAlmacen + "," + itemPar.CveProducto + "," + itemPar.Cantidad + "," + itemPar.PrecioUnitario + ",'" + SwitchDate(Fecha, 1) + "','" + time + "'," + CveUser + "," + CveTipoMovimiento + ")";

                            performinsertquery(QueryInsert);

                        }

                        Delete_EmbarqueDetalleTemp_A(item.CveDocumento);
                    }
                    else
                    {
                        if (item.Actualizar)
                        {
                            ArrayList ListaVtasParciales = new ArrayList();

                            ListaVtasParciales = Lista_EmbarqueDetalleTemp_A(item.CveDocumento);

                            foreach (Clases.cPageBase.ProductoCompra itemPar in ListaVtasParciales)
                            {

                                string QueryDelete = "Delete From EmbarqueAlmacen Where CveEmbarqueDetalle=" + item.CveEmbarqueDetalle + " And CveVentaDetalle=" + item.IntCveNotaDetalle;
                                performupdatequery(QueryDelete);

                                string QueryInsert = "";

                                QueryInsert = "Insert into  EmbarqueAlmacen(CveEmbarqueDetalle,  CveVentaDetalle, CveAlmacen, CveProducto, Cantidad, PrecioUnitario, Fecha_Despacho_Embarque, Hora_Despacho_Embarque, CveUser_Despacho_Embarque, CveTipoEmbarque) Values(";
                                QueryInsert += item.CveEmbarqueDetalle + "," + itemPar.IntCveNotaDetalle + "," + itemPar.CveAlmacen + "," + itemPar.CveProducto + "," + itemPar.Cantidad + "," + itemPar.PrecioUnitario + ",'" + SwitchDate(Fecha, 1) + "','" + time + "'," + CveUser + "," + CveTipoMovimiento + ")";

                                performinsertquery(QueryInsert);

                            }

                            Delete_EmbarqueDetalleTemp_A(item.CveDocumento);
                        }
                    }
                }

                guarda = true;

            }


            return guarda;

        }

        public bool Guardar_Salida_Almacen(ArrayList Lista, int CveEmbarque, int CveChofer, int CveTipoMovimiento, int CveUser = 1, int CveAlmacen=1)
        {
            bool guarda = false;
            string Fecha = ObtenerFechaHora(1);
            string time = ObtenerFechaHora(2);
            string query = "";
            int CveEstatusEmbarqueAlmacen=0;
            if (CveTipoMovimiento == 1) // Movimiento para Embarcar productos
            {
                query = "Update Embarque Set Fecha_Despachado_Embarque='" + SwitchDate(Fecha, 1) + "',  Hora_Despachado_Embarque='" + time + "', CveUser_Despachado_Embarque=" + CveUser + ", CveEstatus=2  Where CveEmbarque=" + CveEmbarque;
                //string query = "Insert Into Embarque(FechaEmbarque, CveRuta, CveVehiculo, CveChofer, CveEstatus, CveUser) Values ('" + SwitchDate(Fecha, 1) + "'," + CveRuta + "," + CveVehiculo + "," + CveChofer + ",1," + CveUser + ")";
            }
            else
            {
                query = "Update Embarque Set Fecha_Retorno_Embarque='" + SwitchDate(Fecha, 1) + "',  Hora_Retorno_Embarque='" + time + "', CveUser_Retorno_Embarque=" + CveUser + ", CveEstatus=3  Where CveEmbarque=" + CveEmbarque;
            }

            performinsertquery(query,1);

            if (CveEmbarque > 0)
            {

                foreach (ProductoCompra item in Lista)
                {
                    if (CveTipoMovimiento == 1)
                    {

                        if (item.CveEstatusEntrega == 2)
                        {
                            item.CveEstatusEntrega = 3;
                        }
                        
                    }
                    else
                    {
                        if (item.CveEstatusEntrega == 3 && item.IvaPorCentaje >= 100)
                        {
                            item.CveEstatusEntrega = 4;
                            item.CveEstatusEmbarque = 4;

                        }
                        else
                        {
                           
                            item.CveEstatusEntrega = 8;
                            item.CveEstatusEmbarque = 8;
                        }

                        if (item.CveEstatusEntrega == 3 && item.IvaPorCentaje <100)
                        {
                            item.CveEstatusEntrega = 8;
                            item.CveEstatusEmbarque = 8;

                        }
                        
                    }

                    

                    if (item.IvaPorCentaje >= 100)
                    {
                        CveEstatusEmbarqueAlmacen = 3;
                    }
                    else
                        CveEstatusEmbarqueAlmacen=2;


                    string QueryDetalleEmbarque = "Update EmbarqueDetalle Set CveEstatus=" +item.CveEstatusEntrega + " Where CveEmbarqueDetalle=" + item.CveEmbarqueDetalle;
                    performinsertquery(QueryDetalleEmbarque, 1);
                  


                    ArrayList ListaVtasParciales = new ArrayList();

                    ListaVtasParciales= Lista_EmbarqueDetalleTemp(item.CveEmbarqueDetalle, CveAlmacen);

                    foreach (Clases.cPageBase.ProductoCompra itemPar in ListaVtasParciales)
                    {
                  

                        if (CveTipoMovimiento == 1)
                        {

                            string QueryInsert = "";
                            string QueryDelete = "Delete From EmbarqueAlmacen Where  CveEmbarqueDetalle=" + item.CveEmbarqueDetalle + " And  CveVentaDetalle=" + itemPar.IntCveNotaDetalle;
                            performupdatequery(QueryDelete);


                            QueryInsert = "Insert into  EmbarqueAlmacen(CveEmbarqueDetalle,  CveVentaDetalle, CveAlmacen, CveProducto, Cantidad, Fecha_Despacho_Embarque, Hora_Despacho_Embarque, CveUser_Despacho_Embarque, CveTipoEmbarque) Values(";
                            QueryInsert += itemPar.CveEmbarqueDetalle + "," + itemPar.IntCveNotaDetalle + "," + itemPar.CveAlmacen + "," + itemPar.CveProducto + "," + itemPar.Cantidad + ",'" + SwitchDate(Fecha, 1) + "','" + time + "'," + CveUser + "," + CveTipoMovimiento + ")";
                        }
                        else
                        {
                            /*
                            QueryInsert = "Insert into  EmbarqueAlmacen(CveEmbarqueDetalle,  CveVentaDetalle, CveAlmacen, CveProducto, Cantidad, Fecha_Desembarque, Hora_Desembarque, CveUser_Desembarque, CveTipoEmbarque) Values(";
                            QueryInsert += itemPar.CveEmbarqueDetalle + "," + itemPar.IntCveNotaDetalle + "," + itemPar.CveAlmacen + "," + itemPar.CveProducto + "," + itemPar.Cantidad + ",'" + SwitchDate(Fecha, 1) + "','" + time + "'," + CveUser + "," + CveTipoMovimiento + ")";
                             performinsertquery(QueryInsert);
                             */
                        }
                       

                    }


                    string QueryDetalleDocumento = "Update Ventas Set CveEstatusEntrega=" + item.CveEstatusEntrega + " Where CveNota=" + item.CveNota;
                    performinsertquery(QueryDetalleDocumento, 1);

                    Delete_EmbarqueDetalleTemp(item.CveEmbarqueDetalle, CveAlmacen);

                }

                guarda = true;

            }


            return guarda;

        }

        public void NoEmbarque(int CveChofer, int opcion, out int CveEmbarque, out int TotalNotas, out int TotalNotasDxC, out string FechaEmbarque, out string NoDocumentoEmbarque)
        {
            CveEmbarque = 0; TotalNotas = 0; TotalNotasDxC = 0; FechaEmbarque = "";  NoDocumentoEmbarque = "";

            ArrayList ListaParametro = new ArrayList();
            

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            SP_Parametros _sp = new SP_Parametros();
            _sp.StrNombreParametro = "CveChofer";
            _sp.StrTipoValor = "int";
            _sp.StrValueParametro = CveChofer.ToString();



            SP_Parametros _sp2 = new SP_Parametros();
            _sp2.StrNombreParametro = "opcion";
            _sp2.StrTipoValor = "int";
            _sp2.StrValueParametro = opcion.ToString();

            ListaParametro.Add(_sp);
            ListaParametro.Add(_sp2);


            _dt = SP_Busca_Reader(ListaParametro, "SP_BusquedaEmbarque_Chofer");


            //ListaProductosVta.Clear();
            int entro = 0;
            foreach (DataRow item in _dt.Rows)
            {
                if (int.Parse(item["CveEmbarque"].ToString()) > 0)
                {

                    CveEmbarque = int.Parse(item["CveEmbarque"].ToString());
                    TotalNotas = int.Parse(item["TotalNotas"].ToString());
                    TotalNotasDxC = int.Parse(item["TotalNotasDxC"].ToString());
                    FechaEmbarque = item["FechaEmbarque"].ToString();
                    NoDocumentoEmbarque = item["NoDocumentoEmbarque"].ToString();
                }
            }



            //return CveEmbarque;
        }
        /// <summary>
        /// Función que regresa una lista de las ventas embarcadas, ArrayList
        /// </summary>
        /// <param name="CveEmbarque">ID de Embarque</param>
        /// <param name="SPopcion">opcion de Procedimiento Almacendo 0 para SP_FiltroBusqueda_vta y 1 para SP_FiltroBusqueda_vta_Embarques</param>
        /// <param name="opcion"> opción de busqueda 6 default</param>
        /// <param name="CveAlmacen">Numero de Almacen</param>
        /// <returns></returns>
        public ArrayList BuscarDocumentoEmbarque(string CveEmbarque, int SPopcion=0, int opcion=6, int CveAlmacen=1)
        {
            ArrayList ListaParametro = new ArrayList();
            ArrayList ListaProductosVta = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();
            
                SP_Parametros _sp = new SP_Parametros();
                _sp.StrNombreParametro = "parametro";
                _sp.StrTipoValor = "string";
                _sp.StrValueParametro = CveEmbarque;

                ListaParametro.Add(_sp);

                SP_Parametros _sp1 = new SP_Parametros();
                _sp1.StrNombreParametro = "opcion";
                _sp1.StrTipoValor = "string";
                _sp1.StrValueParametro = opcion.ToString();

                ListaParametro.Add(_sp1);

                SP_Parametros _sp2 = new SP_Parametros();
                _sp2.StrNombreParametro = "CveAlmacen";
                _sp2.StrTipoValor = "int";
                _sp2.StrValueParametro = CveAlmacen.ToString();

                ListaParametro.Add(_sp2);

                if (SPopcion == 1)
                    _dt = SP_Busca_Reader(ListaParametro, "SP_FiltroBusqueda_Vta_Embarques");
                else
                    _dt = SP_Busca_Reader(ListaParametro, "SP_FiltroBusqueda_Vta");
           
            //ListaProductosVta.Clear();
            int entro = 0;

            string QueryClear_Temp = "Delete From EmbarqueDetalle_Temp_A";
            performupdatequery(QueryClear_Temp);

            foreach (DataRow item in _dt.Rows)
            {

                Clases.cPageBase.ProductoCompra Pitem = new Clases.cPageBase.ProductoCompra(Strconexion);

                //Select Fecha, CveNota, C.Nombre as Cliente, SubTotal, V.Descuento, IVA, Total, CET.Descripcion AS Estatus 
                Pitem.CveEmbarqueDetalle = int.Parse(item["CveEmbarqueDetalle"].ToString());
                Pitem.StrFechaVenta = item["Fecha"].ToString();
                Pitem.CveNota = int.Parse(item["CveNota"].ToString());
                Pitem.CveDocumento = int.Parse(item["CveNota"].ToString());
                Pitem.StrNoDocumento = item["NoDocumento"].ToString();
                Pitem.NombreCliente = item["Cliente"].ToString();
                Pitem.Subtotal = double.Parse(item["SubTotal"].ToString());
                Pitem.Descuento = double.Parse(item["Descuento"].ToString());
                Pitem.Iva = double.Parse(item["IVA"].ToString());
                Pitem.Total = double.Parse(item["Total"].ToString());
                Pitem.Estatus = item["Estatus"].ToString();
                Pitem.CveEstatusDocumento = int.Parse(item["CveEstatusDocumento"].ToString());
                Pitem.CveEstatusEntrega = int.Parse(item["CveEstatusEntrega"].ToString());
                Pitem.EstatusEntrega = item["EstatusEntrega"].ToString();
                Pitem.TipoDocumento = item["TipoDocumento"].ToString();
                Pitem.CveTipoDocumento = int.Parse(item["CveTipoDocumento"].ToString());
                Pitem.Poblacion = item["Direccion"].ToString() + ", " + item["Colonia"].ToString() + ", " + item["Poblacion"].ToString();
                Pitem.Observacion = item["ObservacionDesembarque"].ToString();
                //Pitem.Almacen = item["DescripcionAlmacen"].ToString();
                Pitem.Actualizar = false;
                Pitem.IvaPorCentaje = GetSumaDocumento(Pitem.CveDocumento, 0);
                ListaProductosVta.Add(Pitem);


                AgregaAlmacen_Temp_Edit(Pitem.CveEmbarqueDetalle);


            }

            return ListaProductosVta;

        }

        private void AgregaAlmacen_Temp_Edit(int CveEmbarqueDetalle)
        {

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Add(addparametro("CveEmbarqueDetalle", CveEmbarqueDetalle.ToString(), "int"));

            SP_Busca_Reader(ListaParametro, "SP_AgregaEmbarqueAlmacen_Temp_Edit");
            
        }

        public double GetSumaDocumento(int CveNota, double dblAfectar, int CveTipoEmbarque=1)
        {
          
            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveDocumento", CveNota.ToString(), "int"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_GetSumaDocumento");

            double Resultado = 0;
            foreach (DataRow item in _dt.Rows)
            {
                if(!item.IsNull("Resultado"))
                Resultado =double.Parse(item["Resultado"].ToString());
            }

            return Resultado;

        }

        public ArrayList BuscarDocumentoEmbarqueVta(int CveNota, int CveAlmacen=1, int CveTipoEmbarque=1, int CveRelacionOpcionEmbarque=0)
        {
            ArrayList ListaParametro = new ArrayList();
            ArrayList ListaProductosVta = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            SP_Parametros _sp = new SP_Parametros();
            _sp.StrNombreParametro = "parametro";
            _sp.StrTipoValor = "string";
            _sp.StrValueParametro = CveNota.ToString();

            ListaParametro.Add(_sp);

          
                SP_Parametros _sp1 = new SP_Parametros();
                _sp1.StrNombreParametro = "opcion";
                _sp1.StrTipoValor = "string";

                if (CveRelacionOpcionEmbarque == 0)
                {
                    _sp1.StrValueParametro = "7";
                }
                else
                {
                    if(CveRelacionOpcionEmbarque==2)
                        _sp1.StrValueParametro = "73"; // Lista de Productos para embarcar de forma parcial.
                    else
                    _sp1.StrValueParametro = "77"; // Lista de Productos para embarcar de forma parcial.
                }

                ListaParametro.Add(_sp1);

         

            SP_Parametros _sp2 = new SP_Parametros();
            _sp2.StrNombreParametro = "CveAlmacen";
            _sp2.StrTipoValor = "string";
            _sp2.StrValueParametro =CveAlmacen.ToString();

            ListaParametro.Add(_sp2);



            _dt = SP_Busca_Reader(ListaParametro, "SP_FiltroBusqueda_Vta_Embarques");


            //ListaProductosVta.Clear();
            int entro = 0;
            foreach (DataRow item in _dt.Rows)
            {

                Clases.cPageBase.ProductoCompra Pitem = new Clases.cPageBase.ProductoCompra(Strconexion);

                //Select Fecha, CveNota, C.Nombre as Cliente, SubTotal, V.Descuento, IVA, Total, CET.Descripcion AS Estatus 
                if (CveRelacionOpcionEmbarque == 0)
                    Pitem.CveEmbarqueDetalle = int.Parse(item["CveEmbarqueDetalle"].ToString());
                else
                    Pitem.CveEmbarqueDetalle = 0;
                Pitem.IntCveNotaDetalle = int.Parse(item["CveVentaDetalle"].ToString());
                           
                Pitem.CveNota = int.Parse(item["CveNota"].ToString());
                Pitem.CveDocumento = int.Parse(item["CveNota"].ToString());
                //Pitem.StrNoDocumento = item["NoDocumento"].ToString();
                Pitem.StrCodigoProducto = item["CodigoProducto"].ToString();
                Pitem.CveProducto = item["CveProducto"].ToString();
                Pitem.Nombre = item["Nombre"].ToString();
                Pitem.Clave = item["CodigoProducto"].ToString();
                Pitem.Cantidad = double.Parse(item["Cantidad"].ToString());
                Pitem.DblPendiente = double.Parse(item["Pendiente"].ToString());
                if (CveTipoEmbarque == 2)
                    Pitem.DblAfectar = double.Parse(item["Afectar"].ToString());
                else
                    Pitem.DblAfectar =0.00;

                Pitem.PrecioUnitario = double.Parse(item["Precio"].ToString());
                Pitem.Subtotal = double.Parse(item["SubTotal"].ToString());
                Pitem.Descuento = double.Parse(item["Descuento"].ToString());
                Pitem.Iva = double.Parse(item["IVA"].ToString());
                Pitem.Total = double.Parse(item["Total"].ToString());
                Pitem.PrecioTotal = double.Parse(item["Total"].ToString());
                Pitem.CveAlmacen = int.Parse(item["CveAlmacen"].ToString());
                Pitem.Almacen = item["DescripcionAlmacen"].ToString();

                ListaProductosVta.Add(Pitem);


            }

            return ListaProductosVta;

        }
        public ArrayList BuscarDocumentoEmbarqueVtaDetalle(int CveNota)
        {
            ArrayList ListaParametro = new ArrayList();
            ArrayList ListaProductosVta = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            SP_Parametros _sp = new SP_Parametros();
            _sp.StrNombreParametro = "parametro";
            _sp.StrTipoValor = "string";
            _sp.StrValueParametro = CveNota.ToString();

            ListaParametro.Add(_sp);

            SP_Parametros _sp1 = new SP_Parametros();
            _sp1.StrNombreParametro = "opcion";
            _sp1.StrTipoValor = "string";
            _sp1.StrValueParametro = "71";

            ListaParametro.Add(_sp1);

            
            _dt = SP_Busca_Reader(ListaParametro, "SP_FiltroBusqueda_Vta_Embarques");


            //ListaProductosVta.Clear();
            int entro = 0;
            foreach (DataRow item in _dt.Rows)
            {

                Clases.cPageBase.ProductoCompra Pitem = new Clases.cPageBase.ProductoCompra(Strconexion);

                //Select Fecha, CveNota, C.Nombre as Cliente, SubTotal, V.Descuento, IVA, Total, CET.Descripcion AS Estatus 
                //Pitem.CveEmbarqueDetalle = int.Parse(item["CveEmbarqueDetalle"].ToString());
                Pitem.IntCveNotaDetalle = int.Parse(item["CveVentaDetalle"].ToString());
                Pitem.CveNota = int.Parse(item["CveNota"].ToString());
                Pitem.CveDocumento = int.Parse(item["CveNota"].ToString());
                //Pitem.StrNoDocumento = item["NoDocumento"].ToString();
                Pitem.StrCodigoProducto = item["CodigoProducto"].ToString();
                Pitem.CveProducto = item["CveProducto"].ToString();
                Pitem.Nombre = item["Nombre"].ToString();
                Pitem.Clave = item["CodigoProducto"].ToString();
                Pitem.Cantidad = double.Parse(item["Cantidad"].ToString());
                Pitem.DblPendiente = double.Parse(item["Pendiente"].ToString());
                Pitem.DblAfectar = double.Parse(item["Afectar"].ToString());
                Pitem.PrecioUnitario = double.Parse(item["Precio"].ToString());
                Pitem.Subtotal = double.Parse(item["SubTotal"].ToString());
                Pitem.Descuento = double.Parse(item["Descuento"].ToString());
                Pitem.Iva = double.Parse(item["IVA"].ToString());
                Pitem.Total = double.Parse(item["Total"].ToString());
                Pitem.PrecioTotal = double.Parse(item["Total"].ToString());
                Pitem.CveAlmacen = int.Parse(item["CveAlmacen"].ToString());
                Pitem.Almacen = item["DescripcionAlmacen"].ToString();

                ListaProductosVta.Add(Pitem);


            }

            return ListaProductosVta;

        }

        public ArrayList BuscarDocumentoEmbarqueVtaAlmacen(int CveNota, int CveAlmacen, int opcion=0)
        {
            ArrayList ListaParametro = new ArrayList();
            ArrayList ListaProductosVta = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveNota", CveNota.ToString(), "int"));
            ListaParametro.Add(addparametro("CveAlmacen", CveNota.ToString(), "int"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueProductoAlmacen");


            //ListaProductosVta.Clear();
            int entro = 0;
            foreach (DataRow item in _dt.Rows)
            {

                Clases.cPageBase.ProductoCompra Pitem = new Clases.cPageBase.ProductoCompra(Strconexion);

                //Select Fecha, CveNota, C.Nombre as Cliente, SubTotal, V.Descuento, IVA, Total, CET.Descripcion AS Estatus 
                Pitem.IntCveNotaDetalle = int.Parse(item["CveVentaDetalle"].ToString());
                Pitem.CveNota = int.Parse(item["CveNota"].ToString());
                Pitem.CveDocumento = int.Parse(item["CveNota"].ToString());
                //Pitem.StrNoDocumento = item["NoDocumento"].ToString();
                Pitem.CveProducto = item["CveProducto"].ToString();
                Pitem.Nombre = item["Nombre"].ToString();
                Pitem.StrCodigoProducto = item["CodigoProducto"].ToString();
                Pitem.Cantidad = double.Parse(item["Cantidad"].ToString());
                Pitem.Total = double.Parse(item["Total"].ToString());
                Pitem.PrecioTotal = double.Parse(item["Total"].ToString());
                Pitem.CveAlmacen = int.Parse(item["CveAlmacen"].ToString());
                Pitem.Almacen = item["Almacen"].ToString();
                Pitem.DblPendiente=double.Parse(item["Pendiente"].ToString());
                Pitem.DblAfectar=double.Parse(item["Afectar"].ToString());



                ListaProductosVta.Add(Pitem);


            }

            return ListaProductosVta;

        }
        public ArrayList BuscarDocumentoEmbarqueVtaAlmacen(int CveNota, int CveEmbarqueDetalle)
        {
            ArrayList ListaParametro = new ArrayList();
            ArrayList ListaProductosVta = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveNota", CveNota.ToString(), "int"));
            ListaParametro.Add(addparametro("CveEmbarqueDetalle", CveEmbarqueDetalle.ToString(), "int"));


            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueDetalleAlmacen");


            //ListaProductosVta.Clear();
            int entro = 0;
            foreach (DataRow item in _dt.Rows)
            {

                Clases.cPageBase.ProductoCompra Pitem = new Clases.cPageBase.ProductoCompra(Strconexion);

                //Select Fecha, CveNota, C.Nombre as Cliente, SubTotal, V.Descuento, IVA, Total, CET.Descripcion AS Estatus 
                Pitem.CveEmbarque = int.Parse(item["CveEmbarque"].ToString());
                Pitem.CveProducto = item["CveProducto"].ToString();
                Pitem.Cantidad = double.Parse(item["Cantidad"].ToString());
                Pitem.Nombre = item["NombreProducto"].ToString();
                Pitem.FechaEntrega = item["Fecha"].ToString();
                Pitem.StrHoraEntrega = item["Hora"].ToString();
                Pitem.TipoDocumento = item["Tipo"].ToString();
                Pitem.Almacen = item["DescripcionAlmacen"].ToString();
                Pitem.NombreChofer = item["NombreChofer"].ToString();
                Pitem.NombreEmpleado = item["NombreUsuario"].ToString();

                ListaProductosVta.Add(Pitem);


            }

            return ListaProductosVta;

        }


        public ArrayList BuscarDocumentoEmbarque_Parent(string FechaInicio, string FechaTermino)
        {
            ArrayList ListaParametro = new ArrayList();
            ArrayList ListaProductosVta = new ArrayList();

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            SP_Parametros _sp = new SP_Parametros();
            _sp.StrNombreParametro = "FechaInicio";
            _sp.StrTipoValor = "string";
            _sp.StrValueParametro = FechaInicio;

            ListaParametro.Add(_sp);

            SP_Parametros _sp1 = new SP_Parametros();
            _sp1.StrNombreParametro = "FechaTermino";
            _sp1.StrTipoValor = "string";
            _sp1.StrValueParametro = FechaTermino;

            ListaParametro.Add(_sp1);


            _dt = SP_Busca_Reader(ListaParametro, "SP_BuscaEmbarque");


            //ListaProductosVta.Clear();
            int entro = 0;
            foreach (DataRow item in _dt.Rows)
            {

                Clases.cPageBase.ProductoCompra Pitem = new Clases.cPageBase.ProductoCompra(Strconexion);

                //Select Fecha, CveNota, C.Nombre as Cliente, SubTotal, V.Descuento, IVA, Total, CET.Descripcion AS Estatus 

                
                Pitem.CveEmbarque = int.Parse(item["CveEmbarque"].ToString());
                Pitem.StrNoDocumento = item["NoDocumento"].ToString();
                Pitem.CveChofer = int.Parse(item["CveChofer"].ToString());
                Pitem.StrFechaVenta = item["FechaEmbarque"].ToString();
                Pitem.Nombre = item["Nombre"].ToString();
                Pitem.CveEstatusEmbarque = int.Parse(item["CveEstatus"].ToString());
                Pitem.EstatusEntrega = item["EstatusEntrega"].ToString();
                Pitem.NombreEmpleado = item["NombreUsuario"].ToString();
                Pitem.CveChofer = int.Parse(item["CveChofer"].ToString());

                ListaProductosVta.Add(Pitem);


            }

            return ListaProductosVta;

        }

        public ArrayList EmbarqueDetalleAlmacen(string CveNota)
        {
            ArrayList ListaAlmacen = new ArrayList();
            ArrayList ListaParametro = new ArrayList();
         

            ListaParametro.Clear();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("CveNota", CveNota.ToString(), "int"));


            _dt = SP_Busca_Reader(ListaParametro, "SP_EmbarqueDetalleAlmacen");

            foreach (DataRow rw in _dt.Rows)
            {
                Almacenes item = new Almacenes();
                item.IntCveAlmacen = int.Parse(rw["CveAlmacen"].ToString());
                ListaAlmacen.Add(item);
            }


            return ListaAlmacen;
        }

        public bool UpdateEmbarque(ArrayList Lista, int CveEmbarque, int CveTipoMovmimiento)
        {
            bool Bandera = false;
            int CveEstatus=0;

            if(CveTipoMovmimiento==1)
                CveEstatus=6;
            else
                CveEstatus=7;

            string QueryUpdate = "Update CveEstatus=" + CveEstatus + ", Fecha";



            Bandera = true;

            return Bandera;

        }

        public int DesembarcarVta(int CveEmbarqueDetalle)
        {
            ArrayList ListaParametros = new ArrayList();
            int Resultado = 0;

            ListaParametros.Add(addparametro("CveEmbarqueDetalle", CveEmbarqueDetalle.ToString(), "int"));

            DataTable _dt = new DataTable();

            _dt = SP_Busca_Reader(ListaParametros, "SP_DesembarcarVta");

            foreach (DataRow rw in _dt.Rows)
            {
                Resultado = int.Parse(rw["Resultado"].ToString());
            }

            return Resultado;
        }


    }
}
