using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VentasMonar.Common.Clases
{
    public class cCorteCaja
    {

        public int CveCaja { get; set; }
        public int CveUser { get; set; }
        public int Cerrada { get; set; }
        public int CveAlmacen { get; set; }
        public decimal Contado { get; set; }
        public decimal Calculado { get; set; }
        public decimal Diferencia { get; set; }
        public decimal Retiro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
     



        private int intCveCierre;
        private int intCveCaja;
        private int intCveUser;
        private int intCveCorte;
        private int intCveEstatus;
        private DateTime dtFechaCorte;
        private int intCveMetodoPago;
        private string strDescripcion;
        private decimal dcContado;
        private decimal dcCalculado;
        private decimal dcDiferencia;
        private decimal dcRetiro;
        private decimal dcTotalContado;
        private decimal dcTotalCalculado;
        private decimal dcTotalDiferencia;
        private decimal dcTotalRetiro;
        private decimal dctotalEntredaCorte;
        private decimal dcTotalSalidaCorte;
        private XmlDocument xmlDoc;
        private XmlDocument xmlDocMetodoPago;


        public int IntCveCaja { get => intCveCaja; set => intCveCaja = value; }
        public int IntCveUser { get => intCveUser; set => intCveUser = value; }
        public int IntCveCorte { get => intCveCorte; set => intCveCorte = value; }
        public int IntCveEstatus { get => intCveEstatus; set => intCveEstatus = value; }
        public DateTime DtFechaCorte { get => dtFechaCorte; set => dtFechaCorte = value; }
        public int IntCveMetodoPago { get => intCveMetodoPago; set => intCveMetodoPago = value; }
        public string StrDescripcion { get => strDescripcion; set => strDescripcion = value; }
        public decimal DcContado { get => dcContado; set => dcContado = value; }
        public decimal DcCalculado { get => dcCalculado; set => dcCalculado = value; }
        public decimal DcDiferencia { get => dcDiferencia; set => dcDiferencia = value; }
        public decimal DcRetiro { get => dcRetiro; set => dcRetiro = value; }
        public decimal DcTotalContado { get => dcTotalContado; set => dcTotalContado = value; }
        public decimal DcTotalCalculado { get => dcTotalCalculado; set => dcTotalCalculado = value; }
        public decimal DcTotalDiferencia { get => dcTotalDiferencia; set => dcTotalDiferencia = value; }
        public decimal DcTotalRetiro { get => dcTotalRetiro; set => dcTotalRetiro = value; }
        /// <summary>
        /// Se refiere al monto que se agregará al siguiente corte...
        /// </summary>
        public decimal DctotalEntredaCorte { get => dctotalEntredaCorte; set => dctotalEntredaCorte = value; }
        /// <summary>
        /// Se refiere al monto que retira por cada corte...
        /// </summary>
        public decimal DcTotalSalidaCorte { get => dcTotalSalidaCorte; set => dcTotalSalidaCorte = value; }
        public int IntCveCierre { get => intCveCierre; set => intCveCierre = value; }

        public decimal VentasContado { get; set; }
        public decimal VentasCredito { get; set; }
        public decimal VentasContadoCanceladas { get; set; }
        public decimal VentasCreditoCanceladas { get; set; }
        public decimal ComprasContado { get; set; }
        public decimal ComprasCredito { get; set; }
        public decimal ComprasContadoCanceladas { get; set; }
        public decimal ComprasCreditoCanceladas { get; set; }
        public decimal NotasCredito { get; set; }
        public decimal NotasCreditoCanceladas { get; set; }
        public decimal EntradasVentas { get; set; }
        public decimal EntradasCreditoRecuperacion { get; set; }
        public decimal EntradasComprasCanceladas { get; set; }
        public decimal EntradasNotasCreditoCanceladas { get; set; }
        public decimal EntradasMovimientosCaja { get; set; }
        public decimal SalidasCompras { get; set; }
        public decimal SalidasPagosCredito { get; set; }
        public decimal SalidasVentasCanceladas { get; set; }
        public decimal SalidasNotasCredito { get; set; }
        public decimal SalidasMovimentosCaja { get; set; }
        // Variables para Resumen de Corte de Caja.

        /*
         *
         *   @CveCierre int,
           @VentasContado numeric(18,2),
           @VentasCredito numeric(18,2),
           @VentasContadoCanceladas numeric(18,2),
           @VentasCreditoCanceladas numeric(18,2),
           @ComprasContado numeric(18,2),
           @ComprasCredito numeric(18,2),
           @ComprasContadoCanceladas numeric(18,2),
           @ComprasCreditoCanceladas numeric(18,2),
           @NotasCredito numeric(18,2),
           @NotasCreditoCanceladas numeric(18,2),
           @EntradasVentas numeric(18,2),
           @EntradasCreditoRecuperacion numeric(18,2),
           @EntradasComprasCanceladas numeric(18,2),
           @EntradasNotasCreditoCanceladas numeric(18,2),
           @EntradasMovimientosCaja numeric(18,2),
           @SalidasCompras numeric(18,2),
           @SalidasPagosCredito numeric(18,2),
           @SalidasVentasCanceladas numeric(18,2),
           @SalidasNotasCredito numeric(18,2),
           @SalidasMovimentosCaja numeric(18,2)
         * 
         *
         * Variables Resument Tipo de Pago (Metodo de Pago)
         *
         *  @CveResumenCorteCaja int,
            @CveMetodoPago int,
            @EntradaVentas numeric(18,2),
            @EntradaCreditos numeric(18,2),
            @EntradasComprasCanceladas numeric(18,2),
            @EntradasNotasCredito numeric(18,2),
            @EntradasMovimiento numeric(18,2),
            @SalidaCompras numeric(18,2),
            @SalidaCredito numeric(18,2),
            @SalidaVentasCanceladas numeric(18,2),
            @SalidaNotaCredito numeric(18,2),
            @SalidaMovimiento numeric(18,2)
         * 
         * 
         * 
         * */

        public class cResumentoMetodoPago
        {
            public int CveResumenCorteCaja { get; set; }
            public int CveMetodoPago { get; set; }
            public decimal EntradaVentas { get; set; }
            public decimal EntradaCreditos { get; set; }
            public decimal EntradaComprasCanceladas { get; set; }
            public decimal EntradasNotasCredito { get; set; }
            public decimal EntradasMovimiento { get; set; }
            public decimal SalidaCompras { get; set; }
            public decimal SalidaCredito { get; set; }
            public decimal SalidaVentasCanceladas { get; set; }
            public decimal SalidaNotaCredito { get; set; }
            public decimal SalidaMovimiento { get; set; }
        }

        public XmlDocument XmlDoc { get => xmlDoc; set => xmlDoc = value; }


        public ArrayList _ListaResumenTipoPago { get; set; }
        public XmlDocument XmlDocMetodoPago { get => xmlDocMetodoPago; set => xmlDocMetodoPago = value; }

        cPageBase cPage = new cPageBase();


        public DataTable ReadXML()
        {
            DataTable _result = new DataTable();

            ArrayList ListaParam = new ArrayList();

            ListaParam.Add(cPage.addparametro("xmldoc", xmlDoc.OuterXml, "string"));
           

           

            _result = cPage.SP_Busca_Reader(ListaParam, "SP_XML_CorteCaja");


            return _result;
        }

        public int Save_Temp()
        {
            int _result = 0;
            try
            {
                string Query = "Update CierreCajas Set CveUser =" + IntCveUser + ", Cerrada = 1, Contado =" + DcTotalContado + ", Calculado =" + DcTotalCalculado + ", Diferencia =" + DcTotalDiferencia + ", Retiro =" + DcTotalRetiro + "  Where CveCierre =" + IntCveCorte;

                cPage.SP_DataReaderQuery(Query);
                _result = 1;
            }
            catch(Exception er)
            {
                _result = 0;
            }

            return _result;

        }

        public int Save()
        {
            int _result =0;


            /*
            cPageBase cp = new cPageBase();

            string QueryUpdate = "Update CierreCajas Set CveUser=" + IntCveUser + ", Cerrada=" + IntCveEstatus + ",Contado=" + DcContado + ",";
            QueryUpdate += "Calculado=" + DcCalculado + ", Diferencia=" + DcDiferencia + ",Retiro=" + DcRetiro + ",FechaInicio='" + cp.SwitchDate(DtFechaCorte.Date.ToShortDateString(),1) + "',";
            QueryUpdate += "FechaTermino='" + cp.SwitchDate(DtFechaCorte.Date.ToShortDateString(),1) + "' Where CveCierre=" + IntCveCorte;

            //DataTable _dtUpdate = new DataTable();
            
            int intResult= cp.SP_QueryExecute(QueryUpdate);
            //string QuerySave = "Insert Into ";

            */

            _result = ResumenCorteCaja();

                                                  

            if (_result > 0)
                _result = 1;

            return _result;
        }
        private int ResumenCorteCaja()
        {
            int _result = 0;

            ArrayList ListaParam = new ArrayList();

            ListaParam.Add(cPage.addparametro("CveCierre", intCveCorte.ToString(), "int"));
            ListaParam.Add(cPage.addparametro("CveUser", IntCveUser.ToString(), "int"));

            ListaParam.Add(cPage.addparametro("Contado", DcTotalContado.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("Calculado", DcTotalCalculado.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("Diferencia", DcTotalDiferencia.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("Retirado", DcTotalRetiro.ToString(), "decimal"));

            /*
                    @Calculado numeric(18,2),
		           @Diferencia numeric(18,2),
		           @Retirado numeric(18,2),
           */

            ListaParam.Add(cPage.addparametro("VentasContado", VentasContado.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("VentasCredito", VentasCredito.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("VentasContadoCanceladas", VentasContadoCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("VentasCreditoCanceladas", VentasCreditoCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("ComprasContado", ComprasContado.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("ComprasCredito", ComprasCredito.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("ComprasContadoCanceladas", ComprasContadoCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("ComprasCreditoCanceladas", ComprasCreditoCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("NotasCredito", NotasCredito.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("NotasCreditoCanceladas", NotasCreditoCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("EntradasVentas", EntradasVentas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("EntradasCreditoRecuperacion", EntradasCreditoRecuperacion.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("EntradasComprasCanceladas", EntradasComprasCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("EntradasNotasCreditoCanceladas", EntradasNotasCreditoCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("EntradasMovimientosCaja", EntradasMovimientosCaja.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("SalidasCompras", SalidasCompras.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("SalidasPagosCredito", SalidasPagosCredito.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("SalidasVentasCanceladas", SalidasVentasCanceladas.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("SalidasNotasCredito", SalidasNotasCredito.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("SalidasMovimentosCaja", SalidasMovimentosCaja.ToString(), "decimal"));
            ListaParam.Add(cPage.addparametro("xmlFormaPago", XmlDoc.InnerXml, "string"));



            ArrayList _listaMetodoPago = new ArrayList();

            _listaMetodoPago = ResumenCorteCajaMetodoPago();

            XmlDocMetodoPago = CreateXml_ResumenCorteCajaMetodoPago(_listaMetodoPago);

            ListaParam.Add(cPage.addparametro("xmlTipoPago", XmlDocMetodoPago.InnerXml, "string"));
                                                                                                                                                                                                                                                


            DataTable _dt = new DataTable();

            _dt = cPage.SP_Busca_Reader(ListaParam, "SP_ResumenCorteCaja");

            foreach (DataRow rw in _dt.Rows)
            {
                _result = (int)rw["CveResumenCorteCaja"];
            }





            return _result;

                
        }

        private XmlDocument CreateXml_ResumenCorteCajaMetodoPago(ArrayList ListaTipoMetodoPago)
        {
            XmlDocument _doc = new XmlDocument();

            XmlElement _raiz = _doc.CreateElement("ResumenTipoPagoCaja");
            _doc.AppendChild(_raiz);

            foreach (cResumentoMetodoPago item in ListaTipoMetodoPago)
            {
                _elementoFormaPago(_doc, _raiz, item.CveMetodoPago.ToString(), item.EntradaVentas.ToString(), 
                    item.EntradaCreditos.ToString(), item.EntradaComprasCanceladas.ToString(), item.EntradasNotasCredito.ToString(),
                    item.EntradasMovimiento.ToString(), item.SalidaCompras.ToString(), item.SalidaCredito.ToString(), 
                    item.SalidaVentasCanceladas.ToString(), item.SalidaNotaCredito.ToString(), item.SalidaMovimiento.ToString()); //Efectivo
            }


            
            return _doc;
        }

        private XmlElement _elementoFormaPago(XmlDocument _doc, XmlElement _raiz, 
            string CveMetodoPago, string EntradaVentas, string EntradaCreditos, 
            string EntradasComprasCanceladas, string EntradasNotasCredito,
            string EntradasMovimiento, string SalidaCompras, string SalidaCredito,
            string SalidaVentasCanceladas, string SalidaNotaCredito, string SalidaMovimiento
            )
        {
            XmlElement _CveFormaPago = _doc.CreateElement("CveMetodoPago");
            _raiz.AppendChild(_CveFormaPago);

            _CveFormaPago.SetAttribute("CveMetodoPago", CveMetodoPago);
            _CveFormaPago.SetAttribute("EntradaVentas", EntradaVentas);
            _CveFormaPago.SetAttribute("EntradaCreditos", EntradaCreditos);
            _CveFormaPago.SetAttribute("EntradasComprasCanceladas", EntradasComprasCanceladas);
            _CveFormaPago.SetAttribute("EntradasNotasCredito", EntradasNotasCredito);
            _CveFormaPago.SetAttribute("EntradasMovimiento", EntradasMovimiento);
            _CveFormaPago.SetAttribute("SalidaCompras", SalidaCompras);
            _CveFormaPago.SetAttribute("SalidaCredito", SalidaCredito);
            _CveFormaPago.SetAttribute("SalidaVentasCanceladas", SalidaVentasCanceladas);
            _CveFormaPago.SetAttribute("SalidaNotaCredito", SalidaNotaCredito);
            _CveFormaPago.SetAttribute("SalidaMovimiento", SalidaMovimiento);

            return _CveFormaPago;


        }




        private ArrayList ResumenCorteCajaMetodoPago()
        {
            //ArrayList _result = new ArrayList();
            ArrayList _Lista = new ArrayList();

            string QueryVtaMovimientos = "Select CveMetodoPago, MP.CveTipoPago, M.Tipo,  SUM(M.Importe) As Importe From MovimientoPagos MP Left Join Movimientos M on MP.CveMovimiento=M.CveMovimientoPagos Where M.CveCierre=" + IntCveCorte + " Group by M.CveMetodoPago, MP.CveTipoPago, M.Tipo;";

            DataTable _dtVtaMovimientos = cPage.SP_DataReaderQuery(QueryVtaMovimientos);

            string QueryMetodoPago = "Select CveFormaPago As CveMetodoPago, Descripcion From CatMetodoPago order by 1";

            DataTable _dtMetodo = cPage.SP_DataReaderQuery(QueryMetodoPago);


           

            foreach (DataRow item in _dtMetodo.Rows)
            {
                cResumentoMetodoPago cResumento = new cResumentoMetodoPago();

                switch(item["CveMetodoPago"])
                {

                    case 1:

                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];

                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if((Int32)item["CveMetodoPago"]==(Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento, int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                               
                            }
                            
                        }


                       break;
                    case 2:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                           
                        }
                        break;
                    case 3:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                            
                        }
                        break;
                    case 4:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                           
                        }
                        break;
                    case 5:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                            
                        }
                        break;
                    case 6:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                            
                        }
                        break;

                    case 7:
                         cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                            
                        }
                        break;
                    case 8:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                            
                        }
                        break;
                    case 9:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                            
                        }
                        break;
                    case 10:
                        cResumento.CveMetodoPago = (Int32)item["CveMetodoPago"];
                        foreach (DataRow _itemMov in _dtVtaMovimientos.Rows)
                        {
                            if ((Int32)item["CveMetodoPago"] == (Int32)_itemMov["CveMetodoPago"])
                            {
                                ListaTipoPago(cResumento,int.Parse(_itemMov["CveTipoPago"].ToString()), int.Parse(_itemMov["Tipo"].ToString()), decimal.Parse(_itemMov["Importe"].ToString()));
                            }
                           
                        }
                        break;
                }
                _Lista.Add(cResumento);
            }

            


            return _Lista;

        }

        private void ListaTipoPago(cResumentoMetodoPago cres, int CveTipoPago, int CveTipoES, decimal Importe)
        {
           

            switch(CveTipoPago)
            {
                case 1: //Venta

                    if (CveTipoES == 1) //Entrada
                    {
                        cres.EntradaVentas = Importe;
                    }
                    else //Salida
                    {
                        cres.SalidaVentasCanceladas = Importe;
                    }
                    
                    break;
                case 2: //Abono

                    if (CveTipoES == 1) //Entrada
                    {
                        cres.EntradaCreditos = Importe;
                    }
                    else //Salida
                    {
                        cres.SalidaCredito = Importe;
                    }

                    break;
                case 3: // Nota de Credito
                    if (CveTipoES == 1) //Entrada
                    {
                        cres.EntradasNotasCredito = Importe;
                    }
                    else //Salida
                    {
                        cres.SalidaNotaCredito = Importe;
                    }

                    break;
                case 4: //Pago a Factura
                    if (CveTipoES == 1) //Entrada
                    {
                        cres.EntradaComprasCanceladas = Importe;
                    }
                    else //Salida
                    {
                        cres.SalidaCompras = Importe;
                    }
                    break;
                case 5: //Devolución
                    
                    break;
                case 6: // Movimiento Caja

                    if (CveTipoES == 1) //Entrada
                    {
                        cres.EntradasMovimiento = Importe;
                    }
                    else //Salida
                    {
                        cres.SalidaMovimiento = Importe;
                    }

                    break;
            }


          
        }

        private decimal ImporteES(int CveTipo, decimal Importe)
        {
            decimal _result = 0m;

            switch(CveTipo)
            {
                case 1:

                    break;

                case 2:
                    break;
            }


            return _result;
        }

        private int CierreCorteCaja()
        {
            int result = 0;

           

            DataTable _dtCorteCaja = new DataTable();

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Add(cPage.addparametro("CveCaja", CveCaja.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("CveUser", CveUser.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("Cerrada", Cerrada.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("CveAlmacen", CveAlmacen.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("Contado", Contado.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("Calculado", Calculado.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("Diferenica", Diferencia.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("Retiro", Retiro.ToString(), "int"));
            ListaParametro.Add(cPage.addparametro("FechaInicio", FechaInicio.ToString(), "date"));
            ListaParametro.Add(cPage.addparametro("FechaTermino", FechaTermino.ToString(), "date"));



            DataTable _dt = new DataTable();

            _dt = cPage.SP_Busca_Reader(ListaParametro, "SP_SaveCorteCaja");

            foreach (DataRow rw in _dt.Rows)
            {
                result = (int)rw["CveCierre"];
            }



            return result;
        }

        private int CorteCajaTipoPago()
        {
            int result = 0;




            return result;
        }

        public DataTable ConsultaVentasCierre()
        {
            DataTable _dtVentas = new DataTable();

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Add(cPage.addparametro("CveCierre", IntCveCierre.ToString(), "int"));

            _dtVentas = cPage.SP_Busca_Reader(ListaParametro, "SP_Consulta_Ventas_CorteCaja");

            return _dtVentas;
        }
        public DataTable ConsultaVarias(string SP)
        {
            DataTable _dtConsultas = new DataTable();
             
            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Add(cPage.addparametro("CveCierre", IntCveCierre.ToString(), "int"));

            _dtConsultas = cPage.SP_Busca_Reader(ListaParametro, SP);
                        
            return _dtConsultas;
        }

        public DataTable ConsultaTotal_PreCierre()
        {
            DataTable _dtPreCierre = new DataTable(); ;

            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Add(cPage.addparametro("CveCierre", IntCveCierre.ToString(), "int"));

            _dtPreCierre = cPage.SP_Busca_Reader(ListaParametro, "SP_Consulta_Ventas_PreCierre");
            

            return _dtPreCierre;
        }

        public string BuscaUsuario()
        {
            string _result = "";

            string Query = "Select Nombre As NombreUsuario From Usuarios Where CveUser=" + IntCveUser;

            DataTable _dt = new DataTable();  
                
               _dt = cPage.SP_DataReaderQuery(Query);

            foreach (DataRow item in _dt.Rows)
            {
                _result = item["NombreUsuario"].ToString();
            }
            
            return _result;
        }
        public string BuscaCaja()
        {
            string _result = "";

            string Query = "Select Descripcion As NombreCaja From CatCajas Where CveCaja=" + IntCveCaja;

            DataTable _dt = new DataTable();

            _dt = cPage.SP_DataReaderQuery(Query);

            foreach (DataRow item in _dt.Rows)
            {
                _result = item["NombreCaja"].ToString();
            }

            return _result;
        }
    }
}
