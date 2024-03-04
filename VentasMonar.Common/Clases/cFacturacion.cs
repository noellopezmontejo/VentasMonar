using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasMonar.Desktop.Clases;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Profact.TimbraCFDI33;
using VentasMonar.Desktop.Facturacion;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace VentasMonar.Desktop.Clases
{
    class cFacturacion
    {

        cPageBase cm = new cPageBase();
        ArrayList ListaParametro = new ArrayList();
        DataTable _dt = new DataTable();

        cPageBase cPage = new cPageBase();
        PageBase Page = new PageBase();
        /// <summary>
        /// Parametros de Generar Factura
        /// </summary>
        public class Parametros
        {
            
            private int intCveReceptor;
            private string noDocumento;
            private string serie;
            private string fechaEmision;
            private string fechaCerficacion;
            private int cveEstatus;
            private int cveTipoFactura;
            private int cveSucursal;
            private string lugarExpedicion;
            private string observacion;
            private int cveuser;
            private int cveEmisor;
            private int cveExpedidoEn;
            private string folioFiscal;
            private int cveMetodoPago;
            private int cveFormaPago;
            private double descuento;
            private double subTotal;
            private decimal ivaP;
            private double ivaTotal;
            private double total;
            private string totalLetra;
            private string numCuenta;
            private string condicionesPago;
            private string tipoComprobante;
            private string impuestoSat;
            private string monedaSat;
            private string paisSat;
            private string lugarExpedicionSat;
            private string tipoCambioSat;
            private string metodoPagoSat;
            private string formaPagoSat;
            private string usoCfdiSat;
            private string cadenaOriginal;
            private string sCDCFDI;
            private string sCDSAT;
            private string certificadoEmisor;
            private string certificadoSat;
            private string proveedorCFDI;
            private string rFCCFDI;
            private string iSRRetenido;
            private string iVaRetenido;
            private string xml;
            private string cveNotas;
            private int timbrado;
            private Image qR;
            private string pDF;
            private string pDFC;
            private string importeLetras;
            private int cveUsoCfdi;
            private string folioInt;

            public string StrCPExpedido { get; set; }

            public string FolioInt
            {
                get { return folioInt; }
                set { folioInt = value; }
            }

            public int CveUsoCfdi
            {
                get { return cveUsoCfdi; }
                set { cveUsoCfdi = value; }
            }
            /// <summary>
            /// Importe Total en Letras
            /// </summary>
            public string ImporteLetras
            {
                get { return importeLetras; }
                set { importeLetras = value; }
            }
            /// <summary>
            ///  url del achivo PDF Cancelado
            /// </summary>
            public string PDFC
            {
                get { return pDFC; }
                set { pDFC = value; }
            }
            /// <summary>
            /// ulr del archivo PDF
            /// </summary>
            public string PDF
            {
                get { return pDF; }
                set { pDF = value; }
            }

            /// <summary>
            /// url del archivo QR
            /// </summary>
            public Image QR
            {
                get { return qR; }
                set { qR = value; }
            }

            /// <summary>
            /// Timbrado de Archivo,  1=SI, 0=No;
            /// </summary>
            public int Timbrado
            {
                get { return timbrado; }
                set { timbrado = value; }
            }

            /// <summary>
            /// Folio int de las notas relacionadas con la factura
            /// </summary>
            public string CveNotas
            {
                get { return cveNotas; }
                set { cveNotas = value; }
            }

            /// <summary>
            /// url del XML
            /// </summary>
            public string Xml
            {
                get { return xml; }
                set { xml = value; }
            }

            /// <summary>
            /// IVA Total Retenido
            /// </summary>
            public string IVaRetenido
            {
                get { return iVaRetenido; }
                set { iVaRetenido = value; }
            }

            /// <summary>
            /// ISR Total Retenido
            /// </summary>
            public string ISRRetenido
            {
                get { return iSRRetenido; }
                set { iSRRetenido = value; }
            }

            /// <summary>
            /// RFC del Emisor
            /// </summary>
            public string RFCCFDI
            {
                get { return rFCCFDI; }
                set { rFCCFDI = value; }
            }

            /// <summary>
            /// Proveedor del Timbrado CFDI
            /// </summary>
            public string ProveedorCFDI
            {
                get { return proveedorCFDI; }
                set { proveedorCFDI = value; }
            }

            /// <summary>
            /// Certidicado de Timbrado SAT
            /// </summary>
            public string CertificadoSat
            {
                get { return certificadoSat; }
                set { certificadoSat = value; }
            }
            /// <summary>
            /// Certificado del Emisor SAT
            /// </summary>
            public string CertificadoEmisor
            {
                get { return certificadoEmisor; }
                set { certificadoEmisor = value; }
            }

            /// <summary>
            /// Certificado de Sello Digital SAT
            /// </summary>
            public string SCDSAT
            {
                get { return sCDSAT; }
                set { sCDSAT = value; }
            }

            /// <summary>
            /// Certificado el Sello digital CFDI
            /// </summary>
            public string SCDCFDI
            {
                get { return sCDCFDI; }
                set { sCDCFDI = value; }
            }

            /// <summary>
            /// Firma de Cadena Original SAT
            /// </summary>
            public string CadenaOriginal
            {
                get { return cadenaOriginal; }
                set { cadenaOriginal = value; }
            }

            /// <summary>
            /// Clave de Uso CFDI
            /// </summary>
            public string UsoCfdiSat
            {
                get { return usoCfdiSat; }
                set { usoCfdiSat = value; }
            }
            /// <summary>
            /// Clave de Forma de Pago Sat
            /// </summary>
            public string FormaPagoSat
            {
                get { return formaPagoSat; }
                set { formaPagoSat = value; }
            }
            /// <summary>
            /// Clave de Metodo de Pago Sat
            /// </summary>
            public string MetodoPagoSat
            {
                get { return metodoPagoSat; }
                set { metodoPagoSat = value; }
            }
            /// <summary>
            /// Clave de Tipo de Cambio SAT
            /// </summary>
            public string TipoCambioSat
            {
                get { return tipoCambioSat; }
                set { tipoCambioSat = value; }
            }
            /// <summary>
            /// Codigo Postal del Lugar de Expedición
            /// </summary>
            public string LugarExpedicionSat
            {
                get { return lugarExpedicionSat; }
                set { lugarExpedicionSat = value; }
            }
            /// <summary>
            /// Pais donde se expedi el documento SAT
            /// </summary>
            public string PaisSat
            {
                get { return paisSat; }
                set { paisSat = value; }
            }
            /// <summary>
            /// Clave Moneda SAT
            /// </summary>
            public string MonedaSat
            {
                get { return monedaSat; }
                set { monedaSat = value; }
            }
            /// <summary>
            /// Clave Impuesto SAT
            /// </summary>
            public string ImpuestoSat
            {
                get { return impuestoSat; }
                set { impuestoSat = value; }
            }
            /// <summary>
            /// Tipo de Comprobante SAT
            /// </summary>
            public string TipoComprobanteSat
            {
                get { return tipoComprobante; }
                set { tipoComprobante = value; }
            }
            /// <summary>
            /// Condiciones de Pago Sat
            /// </summary>
            public string CondicionesPago
            {
                get { return condicionesPago; }
                set { condicionesPago = value; }
            }
            /// <summary>
            /// Número de Cuenta del Pago
            /// </summary>
            public string NumCuenta
            {
                get { return numCuenta; }
                set { numCuenta = value; }
            }
            /// <summary>
            ///  string del Total en Letras
            /// </summary>
            public string TotalLetra
            {
                get { return totalLetra; }
                set { totalLetra = value; }
            }
            /// <summary>
            /// Total del Documento
            /// </summary>
            public double Total
            {
                get { return total; }
                set { total = value; }
            }
            /// <summary>
            /// IVA Total
            /// </summary>
            public double IvaTotal
            {
                get { return ivaTotal; }
                set { ivaTotal = value; }
            }
            /// <summary>
            /// Porcentaje de IVA
            /// </summary>
            public decimal IvaP
            {
                get { return ivaP; }
                set { ivaP = value; }
            }
            /// <summary>
            /// SubTotal del Documento
            /// </summary>
            public double SubTotal
            {
                get { return subTotal; }
                set { subTotal = value; }
            }
            /// <summary>
            /// Descuento Total del Documento
            /// </summary>
            public double Descuento
            {
                get { return descuento; }
                set { descuento = value; }
            }
            /// <summary>
            /// Clave de Forma de Pago
            /// </summary>
            public int CveFormaPago
            {
                get { return cveFormaPago; }
                set { cveFormaPago = value; }
            }
            /// <summary>
            /// Clave de Metod de Pago
            /// </summary>
            public int CveMetodoPago
            {
                get { return cveMetodoPago; }
                set { cveMetodoPago = value; }
            }
            /// <summary>
            /// UUID Del Documento
            /// </summary>
            public string UUID
            {
                get { return folioFiscal; }
                set { folioFiscal = value; }
            }
            /// <summary>
            /// Clave del Codigo Postal 
            /// </summary>
            public int CveExpedidoEn
            {
                get { return cveExpedidoEn; }
                set { cveExpedidoEn = value; }
            }
            /// <summary>
            /// Clave del Emisor del Documento
            /// </summary>
            public int CveEmisor
            {
                get { return cveEmisor; }
                set { cveEmisor = value; }
            }
            /// <summary>
            /// Clave de Usuario que Genera el documento
            /// </summary>
            public int CveUser
            {
                get { return cveuser; }
                set { cveuser = value; }
            }
            /// <summary>
            /// Observaciones del documento
            /// </summary>
            public string Observacion
            {
                get { return observacion; }
                set { observacion = value; }
            }
            /// <summary>
            /// Lugar de Expedicion del Documento (Obsoleto) en Version 3.3
            /// </summary>
            public string LugarExpedicion
            {
                get { return lugarExpedicion; }
                set { lugarExpedicion = value; }
            }
            /// <summary>
            /// Clave de Sucursal del Emisor
            /// </summary>
            public int CveSucursal
            {
                get { return cveSucursal; }
                set { cveSucursal = value; }
            }
            /// <summary>
            /// Tipo de Factura
            /// </summary>
            public int CveTipoFactura
            {
                get { return cveTipoFactura; }
                set { cveTipoFactura = value; }
            }
            /// <summary>
            /// Estatus de Factura
            /// </summary>
            public int CveEstatus
            {
                get { return cveEstatus; }
                set { cveEstatus = value; }
            }
            /// <summary>
            /// Fecha de Certificacion del Documento
            /// </summary>
            public string FechaCerficacion
            {
                get { return fechaCerficacion; }
                set { fechaCerficacion = value; }
            }
            /// <summary>
            /// Fecha de Emision del Documento
            /// </summary>
            public string FechaEmision
            {
                get { return fechaEmision; }
                set { fechaEmision = value; }
            }
            /// <summary>
            /// Serie del Documento
            /// </summary>
            public string Serie
            {
                get { return serie; }
                set { serie = value; }
            }
            /// <summary>
            /// Numero de Documento (Folio)
            /// </summary>
            public string NoDocumento
            {
                get { return noDocumento; }
                set { noDocumento = value; }
            }
            /// <summary>
            /// Clave de Receptor del Documento
            /// </summary>
            public int  CveReceptor
            {
                get { return intCveReceptor; }
                set { intCveReceptor = value; }
            }
            
        }
        public class CfdiRelacionado
        {
            private int intCveFactura;
            private int intCveTipoRelacion;
            private string strUUID;
            private string strDescripcionTipoRelacion;
            private string str_c_TipoRelacion;


            public int IntCveFactura { get => intCveFactura; set => intCveFactura = value; }
            public int IntCveTipoRelacion { get => intCveTipoRelacion; set => intCveTipoRelacion = value; }
            public string StrUUID { get => strUUID; set => strUUID = value; }
            public string StrDescripcionTipoRelacion { get => strDescripcionTipoRelacion; set => strDescripcionTipoRelacion = value; }
            public string Str_c_TipoRelacion { get => str_c_TipoRelacion; set => str_c_TipoRelacion = value; }
        }

        public class DetalleParametros
        {
            private decimal cantidad;
            private string unidadMedida;
            private string unidadMedidaSat;
            private string claveProductoServicioSat;
            private decimal precioUnitario;
            private decimal pDescuento;
            private decimal descuento;
            private decimal subTotal;
            private decimal totalIva;
            private decimal total;
            private string descripcion;
            private int cveFactura;

            private double dblIva;
            private int intChkIva;
            private int intChkIvaRetenido;
            private int intChkIsrRetenido;
            private double dblIvaRetenido;
            private double dblIsrRetenido;
            private string strClaveUnidadSat;
            private string ClaveProdServSat;



            public decimal Cantidad { get => cantidad; set => cantidad = value; }
            public string UnidadMedida { get => unidadMedida; set => unidadMedida = value; }
            public string UnidadMedidaSat { get => unidadMedidaSat; set => unidadMedidaSat = value; }
            public string ClaveProductoServicioSat { get => claveProductoServicioSat; set => claveProductoServicioSat = value; }
            public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
            public decimal PDescuento { get => pDescuento; set => pDescuento = value; }
            public decimal Descuento { get => descuento; set => descuento = value; }
            public decimal SubTotal { get => subTotal; set => subTotal = value; }
            public decimal Total { get => total; set => total = value; }
            public decimal TotalIva { get => totalIva; set => totalIva = value; }
            public string Descripcion { get => descripcion; set => descripcion = value; }
            public int CveFactura { get => cveFactura; set => cveFactura = value; }
            public double DblIva { get => dblIva; set => dblIva = value; }
            public int IntChkIva { get => intChkIva; set => intChkIva = value; }
            public int IntChkIvaRetenido { get => intChkIvaRetenido; set => intChkIvaRetenido = value; }
            public int IntChkIsrRetenido { get => intChkIsrRetenido; set => intChkIsrRetenido = value; }
            public double DblIvaRetenido { get => dblIvaRetenido; set => dblIvaRetenido = value; }
            public double DblIsrRetenido { get => dblIsrRetenido; set => dblIsrRetenido = value; }
            public string StrClaveUnidadSat { get => strClaveUnidadSat; set => strClaveUnidadSat = value; }
            public string ClaveProdServSat1 { get => ClaveProdServSat; set => ClaveProdServSat = value; }
        }

        public class DetalleParametrosFacturaComplemento
        {
            private int intCveDetalleComplemento;
            private int intCveFactura;
            private string srtFechaPago;
            private string strFormaPago;
            private string strMoneda;
            private string strTipoCambioP;
            private decimal dcMonto;
            private string strNumOperacion;
            private string strrfcEmisorCtaOrd;
            private string strnomBancoOrdExt;
            private string strctaOrdenante;
            private string strrfcEmisorCtaBen;
            private string strctaBeneficiario;
            private string strtipoCadPago;
            private string strcertPago;
            private string strcadPago;
            private string strselloPago;

            public int IntCveDetalleComplemento { get => intCveDetalleComplemento; set => intCveDetalleComplemento = value; }
            public int IntCveFactura { get => intCveFactura; set => intCveFactura = value; }
            public string SrtFechaPago { get => srtFechaPago; set => srtFechaPago = value; }
            public string StrFormaPago { get => strFormaPago; set => strFormaPago = value; }
            public string StrMoneda { get => strMoneda; set => strMoneda = value; }
            public string StrTipoCambioP { get => strTipoCambioP; set => strTipoCambioP = value; }
            public decimal DcMonto { get => dcMonto; set => dcMonto = value; }
            public string StrNumOperacion { get => strNumOperacion; set => strNumOperacion = value; }
            public string StrrfcEmisorCtaOrd { get => strrfcEmisorCtaOrd; set => strrfcEmisorCtaOrd = value; }
            public string StrnomBancoOrdExt { get => strnomBancoOrdExt; set => strnomBancoOrdExt = value; }
            public string StrctaOrdenante { get => strctaOrdenante; set => strctaOrdenante = value; }
            public string StrrfcEmisorCtaBen { get => strrfcEmisorCtaBen; set => strrfcEmisorCtaBen = value; }
            public string StrctaBeneficiario { get => strctaBeneficiario; set => strctaBeneficiario = value; }
            public string StrtipoCadPago { get => strtipoCadPago; set => strtipoCadPago = value; }
            public string StrcertPago { get => strcertPago; set => strcertPago = value; }
            public string StrcadPago { get => strcadPago; set => strcadPago = value; }
            public string StrselloPago { get => strselloPago; set => strselloPago = value; }


        }

        public class DoctoRelacionadoComplemento
        {
            private int intCveDetalleDoctoRelacionadoComplemento;
            private int intCveFactura;
            private int intCveFacturaDoctoRelacionado;
            private int intidPago;
            private string stridDocumento;
            private string strserie;
            private string strfolio;
            private string strmonedaDr;
            private string strtipoCambioDr;
            private string strmetodoPagoDr;
            private string strnumParcialidad;
            private decimal dcimpSaldoAnt;
            private decimal dcimpPagado;
            private decimal dcimpSaldoInsoluto;
            private int intCveReceptor;
            private string strFechaEmision;
            private string strLugarExpedicionSat;
            private decimal dcimpTotalFactura;



            public int IntCveDetalleDoctoRelacionadoComplemento { get => intCveDetalleDoctoRelacionadoComplemento; set => intCveDetalleDoctoRelacionadoComplemento = value; }
            public int IntidPago { get => intidPago; set => intidPago = value; }
            public string StridDocumento { get => stridDocumento; set => stridDocumento = value; }
            public string Strserie { get => strserie; set => strserie = value; }
            public string Strfolio { get => strfolio; set => strfolio = value; }
            public string StrmonedaDr { get => strmonedaDr; set => strmonedaDr = value; }
            public string StrtipoCambioDr { get => strtipoCambioDr; set => strtipoCambioDr = value; }
            public string StrmetodoPagoDr { get => strmetodoPagoDr; set => strmetodoPagoDr = value; }
            public string StrnumParcialidad { get => strnumParcialidad; set => strnumParcialidad = value; }
            public decimal DcimpSaldoAnt { get => dcimpSaldoAnt; set => dcimpSaldoAnt = value; }
            public decimal DcimpPagado { get => dcimpPagado; set => dcimpPagado = value; }
            public decimal DcimpSaldoInsoluto { get => dcimpSaldoInsoluto; set => dcimpSaldoInsoluto = value; }
            public int IntCveFactura { get => intCveFactura; set => intCveFactura = value; }
            public int IntCveFacturaDoctoRelacionado { get => intCveFacturaDoctoRelacionado; set => intCveFacturaDoctoRelacionado = value; }
            public int IntCveReceptor { get => intCveReceptor; set => intCveReceptor = value; }
            public string StrFechaEmision { get => strFechaEmision; set => strFechaEmision = value; }
            public string StrLugarExpedicionSat { get => strLugarExpedicionSat; set => strLugarExpedicionSat = value; }
            public decimal DcimpTotalFactura { get => dcimpTotalFactura; set => dcimpTotalFactura = value; }
        }



        public bool GenerarCFDI33(int intCveFactura)
        {
            bool _result = false;

                        
            if (intCveFactura>0)
            {



                int CveEstatusFactura = 1; //int.Parse(dataGrid.CurrentRow.Cells["CveEstatus"].Value.ToString());

                if (CveEstatusFactura == 1)
                {
                    DataTable _dtComprobante = new DataTable();

                    DialogResult result;
                    result = MessageBox.Show("¿Está seguro que desea sellar la Factura?", "Sellar Factura", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        
                        ListaParametro.Clear();
                        ListaParametro.Add(cPage.addparametro("CveFactura", intCveFactura.ToString(), "int"));

                        DataTable _dtDatosFactura = cPage.SP_Busca_Reader(ListaParametro, "SP_ConsultarDatosFactura");

                        USLib.FachadaCfdv33 usLib = new USLib.FachadaCfdv33();


                        //MessageBox.Show("Presione el botón de aceptar y espere que se certifique su documento...", "Validación de Datos");


                        //Este ejemplo está dirigido a aquellos integradores que aún no generan el xml (CFDI)

                        //Inicializamos el conector el parámetro indica el ambiente en el que se utilizará 
                        //Fasle = Ambiente de pruebas
                        //True = Ambiente de producción

                        foreach (DataRow rowfac in _dtDatosFactura.Rows)
                        {

                            int CveFactura = int.Parse(rowfac["CveFactura"].ToString());
                            int CveReceptor = int.Parse(rowfac["CveReceptor"].ToString());
                            int CveEmisor = int.Parse(rowfac["CveEmisor"].ToString());
                            string RfcEmisor = rowfac["RfcEmisor"].ToString();
                            string RfcReceptor = rowfac["RfcReceptor"].ToString();
                            int cvetipofactura = int.Parse(rowfac["CveTipoFactura"].ToString());
                            int CvePacTimbrado = 0;
                            string NombreCert = CveEmisor + "_" + RfcEmisor;
                            string CveClave = rowfac["ClaveEmisor"].ToString();// GetStrFieldQuery("CveClave", "Select CveClave From Emisores Where CveEmisor=" + CveEmisor);
                            string url = ConfigurationManager.AppSettings["RutaCertificados"]; // + @"\certificados\";

                            string certificado = url + NombreCert + ".cer";
                            string key = url + NombreCert + ".key";
                            string Password = CveClave;

                            //Configurar el núemero de decimales que se manejaran
                            //La libreria TRUNCA - NO REDONDEA
                            //Ejemplo: 1.123999 a 3 decimales resultado: 1.123
                            usLib.P00Setup(numeroDecimalesEnTotales: 2,
                                numeroDecimalesEnDetalle: 6, numeroDecimalesEnImpuestos: 2,
                                cerFile:
                                certificado,
                                keyFile:
                                key,
                                passwordKey: Password);

                            string Query = "SELECT * FROM Facturas  WHERE CveFactura=" + CveFactura;

                            string TipoComprobante = rowfac["TipoComprobante"].ToString(); //GetStrFieldQuery("TipoComprobante", "Select TipoComprobante From CatTipoFactura Where CveTipoFactura=" + cvetipofactura);
                        decimal Total = decimal.Parse(rowfac["Total"].ToString());
                        usLib.P01DatosGenerales(
                        serie: rowfac["Serie"].ToString(), //Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres.
                        folio: rowfac["FolioInt"].ToString(), //Atributo opcional para control interno del contribuyente que expresa el folio del comprobante, acepta una cadena de caracteres.
                        fecha: rowfac["FechaEmision"].ToString(), //FechaEmision.Date.ToString("s"), //Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante.
                        formaPago: rowfac["c_formapago"].ToString(),   // GetStrFieldQuery("c_formapago", "Select c_formapago From CatFormaPagoSat Where CveFormaPago=" + rw_gral["CveFormaPago"].ToString()), //Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
                        condicionesDePago: rowfac["CondicionesPago"].ToString(), //Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
                        subTotal: rowfac["SubTotal"].ToString(), //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos.
                        descuento: rowfac["Descuento"].ToString(), //Atributo condicional para representar el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe registrar cuando existan conceptos con descuento.
                        moneda: "MXN", //Atributo requerido para identificar la clave de la moneda utilizada para expresar los montos, cuando se usa moneda nacional se registra MXN. Conforme con la especificación ISO 4217.
                        tipoCambio: "1.00", //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion.
                        total: rowfac["Total"].ToString(), //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
                        tipoDeComprobante: TipoComprobante, //Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.
                        metodoPago: rowfac["c_metodopago"].ToString(),  //GetStrFieldQuery("c_metodopago", "Select c_metodopago From CatMetodoPagoSat Where CveMetodoPago=" + rw_gral["CveMetodoPago"].ToString()), //Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF.
                        lugarExpedicion: rowfac["CPExpedido"].ToString(), //Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal).
                        confirmacion: ""
                                );
                            
                            string QuerycfdiRelacionados = "Select DTRF.UUID, CTRS.c_TipoRelacion From DetalleTipoRelacionFactura  DTRF Left Join CatTipoRelacionSat CTRS on DTRF.CveTipoRelacion=CTRS.CveTipoRelacion  Where CveFactura=" + CveFactura;

                            DataTable _dtcfdirelacionados = new DataTable();
                            _dtcfdirelacionados = cPage.SP_DataReaderQuery(QuerycfdiRelacionados);

                            foreach (DataRow rw_relacionados in _dtcfdirelacionados.Rows)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                    relacion: rw_relacionados["c_TipoRelacion"].ToString(), //GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                    uuid: rw_relacionados["UUID"].ToString()
                                    );
                            }


                            CvePacTimbrado = 1;// int.Parse(rw_Emisor["CvePacTimbrado"].ToString());
                            usLib.P03Emisor(
                                rfc: rowfac["RfcEmisor"].ToString(),
                                nombre: rowfac["NombreEmisor"].ToString(),
                                regimenFiscal: rowfac["ClaveRegimen"].ToString() //GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + rw_Emisor["CveRegimen"].ToString())
                                );


                            usLib.P04Receptor(
                                rfc: rowfac["RfcReceptor"].ToString(),
                                nombre: rowfac["NombreReceptor"].ToString(),
                                residenciaFiscal: "",
                                numRegIdTrib: "",
                                usoCfdi: rowfac["c_UsoCFDI"].ToString() //GetStrFieldQuery("c_UsoCFDI", "Select c_UsoCFDI From CatUsoCfdiSat Where CveUso=" + rw_Receptor["CveUso"].ToString())
                                );
                            


                            string QueryConceptos = "SELECT CveDetalleFactura, CveNota, Cantidad, Unidad, Descripcion, Precio, SubTotal, Descuento, IVA, Total, ChkIva, ChkIvaRetenido, ChkIsrRetenido, IvaRetenido, IsrRetenido, ClaveUnidadSat, ClaveProdServSat FROM DetalleFacturas WHERE CveFactura=" + CveFactura;
                            DataTable _dtConceptos = new DataTable();

                            _dtConceptos = cPage.SP_DataReaderQuery(QueryConceptos);

                            foreach (DataRow rw_conceptos in _dtConceptos.Rows)
                            {

                                var c1 = usLib.P05ConceptosAgregar(
                                    claveProdServ: rw_conceptos["ClaveProdServSat"].ToString(), //Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
                                    noIdentificacion: "", //Atributo opcional para expresar el número de parte, identificador del producto o del servicio, la clave de producto o servicio, SKU o equivalente, propia de la operación del emisor, amparado por el presente concepto. Opcionalmente se puede utilizar claves del estándar GTIN.
                                    cantidad: rw_conceptos["Cantidad"].ToString(), //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                                    claveUnidad: rw_conceptos["ClaveUnidadSat"].ToString(), //Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                    unidad: "NA", //Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                    descripcion: rw_conceptos["Descripcion"].ToString(), //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
                                    valorUnitario: rw_conceptos["Precio"].ToString(), //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
                                    importe: rw_conceptos["SubTotal"].ToString(), //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.
                                    descuento: rw_conceptos["Descuento"].ToString()
                                );

                                decimal baseimporte = decimal.Parse(rw_conceptos["SubTotal"].ToString()) - decimal.Parse(rw_conceptos["Descuento"].ToString());

                                if (bool.Parse(rw_conceptos["ChkIva"].ToString()))
                                {
                                    usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                    baseCalculoImpuesto: baseimporte.ToString(),
                                                                    impuesto: "002",
                                                                    tipoFactor: "Tasa",
                                                                    tasaOCuota: "0.160000",
                                                                    importe: rw_conceptos["IVA"].ToString(), concepto: c1);
                                }
                                else
                                {
                                    usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                   baseCalculoImpuesto: baseimporte,
                                                                   impuesto: "002",
                                                                   tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                   tasaOCuota: 0,
                                                                   importe: 0, concepto: c1);

                                }


                                if (int.Parse(rw_conceptos["ChkIvaRetenido"].ToString())==1)
                                {
                                    usLib.P05ConceptoAgregarImpuestoRetencion(
                                    baseCalculoImpuesto: baseimporte.ToString(),
                                    impuesto: "002",
                                    tipoFactor: "Tasa",
                                    tasaOCuota: "0.106667",
                                    importe: rw_conceptos["IvaRetenido"].ToString(), concepto: c1);
                                }

                                if (int.Parse(rw_conceptos["ChkIsrRetenido"].ToString())==1)
                                {
                                    usLib.P05ConceptoAgregarImpuestoRetencion(
                                    baseCalculoImpuesto: baseimporte.ToString(),
                                    impuesto: "002",
                                    tipoFactor: "Tasa",
                                    tasaOCuota: "0.100000",
                                    importe: rw_conceptos["IsrRetenido"].ToString(), concepto: c1);
                                }
                            }

                            if (_dtConceptos.Rows.Count > 0)
                            {
                                usLib.P06ImpuestosCrearResumenPorConceptos();
                            }


                            //INICO
                            //En este punto, se pueden incluir los complementos oficiales del SAT

                            string QueryRetencionesLocales = "SELECT CR.Descripcion,FR.Importe,CR.Porcentaje FROM FacturaRetencion FR LEFT JOIN CatRetenciones CR ON FR.CveRetencion=CR.CveRetencion WHERE  FR.CveFactura=" + CveFactura;

                            DataTable _dtRetencionesLocales = new DataTable();
                            _dtRetencionesLocales = cPage.SP_DataReaderQuery(QueryRetencionesLocales);

                            if (_dtRetencionesLocales.Rows.Count > 0)
                            {
                                //Complemento al Comprobante Fiscal Digital para Impuestos Locales
                                var impLocal = new USLib.Complementos.Comprobante.ImpLocal.FachadaImpLocal();


                                foreach (DataRow rw_locales in _dtRetencionesLocales.Rows)
                                {
                                    //Nodo opcional para la expresión de los impuestos locales retenidos
                                    impLocal.AgregarComplementoImpuestoLocalRetenciones(impLocRetenido:
                                        rw_locales["Descripcion"].ToString(), //Nombre del impuesto local retenido
                                        tasadeRetencion: decimal.Parse(rw_locales["Porcentaje"].ToString()), //Porcentaje de retención del impuesto local
                                        importe: decimal.Parse(rw_locales["Importe"].ToString()) //Monto del impuesto local retenido
                                        );
                                }
                                //Nodo opcional para la expresión de los impuestos locales trasladados
                                /*
                            impLocal.AgregarComplementoImpuestoLocalTraslados(
                                impLocTrasladado: "Hospedaje", //Nombre del impuesto local trasladado
                                tasadeTraslado: 2, //"Porcentaje de traslado del impuesto local"
                                importe: 20 //Monto del impuesto local trasladado
                                );
                                */

                                impLocal.AgregarComplementoImpuestoLocalCerrar(cfd: usLib.Cfd);
                                //FIN
                            }

                            string CadenaOriginal = usLib.P07GenerarCadenaOriginal();

                            usLib.P08GenerarSelloDigital();

                            //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                            string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"] + @"\";
                            string NombreXml = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura + "_Org.xml";

                            usLib.Cfd.SaveToFile(Destinoxml + @"org\" + NombreXml, "UMBRALLSOFTWARESADECV");

                            //int CveProveedor=GetStrFieldQuery("CvePacTimbrado","Select CvePacTimbrado From CatPacTimbrado Where CvePactimbrado=" + )

                            string UsuarioPac = "mvpNUXmQfK8="; 
                            //string UsuarioPac=GetStrFieldQuery("UsuarioPac", "Select UsuarioPac From Emisores Where CveEmisor=" + CveEmisor);
                            string Contraseña = "mvpNUXmQfK8="; 
                            //string Contraseña=GetStrFieldQuery("Contrasenia", "Select Contrasenia From Emisores Where CveEmisor=" + CveEmisor);

                            TimbrarFactura(CveFactura, CveEmisor, CveReceptor, cvetipofactura, RfcEmisor, RfcReceptor, Destinoxml, NombreXml, CvePacTimbrado, UsuarioPac, Contraseña, usLib.Cfd.NoCertificado, Total);

                        }

                    }
                }
                else
                {
                    MessageBox.Show("El estatus de la factura no es valido, favor de verificar que no haya sido timbrada o cancelada con anterioridad", "Validacion de Datos");
                }
            }

            return _result;
        }

        void TimbrarFactura(int CveFactura, int CveEmisor, int CveReceptor, int cvetipofactura, string RfcEmisor, string RfcReceptor, string Destinoxml, string NombreXml, int CveProveedor, string usuarioPac = "", string contraseñapac = "", string NoCertificado = "", decimal Total = 0)
        {
            switch (CveProveedor)
            {
                case 1: //Profact
                    Conector conector;
                    if (usuarioPac != "mvpNUXmQfK8=")
                        conector = new Conector(true);
                    else
                        conector = new Conector(false);

                    //Establecemos las credenciales para el permiso de conexión
                    //Ambiente de pruebas = mvpNUXmQfK8=
                    //Ambiente de producción = Esta será asignado por el proveedor al salir a productivo

                    //conector.EstableceCredenciales("mvpNUXmQfK8=");



                    conector.EstableceCredenciales(usuarioPac);



                    //Timbramos el CFDI por medio del conector y guardamos resultado
                    Profact.TimbraCFDI.ResultadoTimbre resultadoTimbre;
                    resultadoTimbre = conector.TimbraCFDI(Destinoxml + @"org\" + NombreXml);

                    //Verificamos el resultado
                    if (resultadoTimbre.Exitoso)
                    {
                        //El comprobante fue timbrado exitosamente

                        //Guardamos xml cfdi
                        //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                        string NombreFactura = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura;
                        if (resultadoTimbre.GuardaXml(Destinoxml, NombreFactura))
                        {
                            //MessageBox.Show("El xml fue guardado correctamente");
                            GuardarXmlCodigo(CveFactura, NombreFactura + ".xml", "Xml");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar el comprobante");
                        }

                        //Los siguientes datos deberán ir en la respresentación impresa ó PDF

                        //1.- Código bidimensional QR
                        string Destinoqr = ConfigurationManager.AppSettings["RutaQR"];// + @"\QR\";
                        if (resultadoTimbre.GuardaCodigoBidimensional(Destinoqr, NombreFactura))
                        {
                            //MessageBox.Show("El código bidimensional fue guardado correctamente");
                            GuardarQR(CveFactura, Destinoqr + NombreFactura + ".jpg", "QR", "?QRCodigo");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar el código bidimensional");
                        }

                        //2.- Folio fiscal
                        string folioFiscal = resultadoTimbre.FolioUUID;

                        //3.- No. Certificado del Emisor
                        string noCertificado = resultadoTimbre.No_Certificado;

                        //4.- No. Certificado del SAT
                        string noCertificadoSAT = resultadoTimbre.No_Certificado_SAT;

                        //5.- Fecha y Hora de certificación
                        string fechaCert = resultadoTimbre.FechaCertificacion;

                        //6.- Sello del cfdi
                        string selloCFDI = resultadoTimbre.SelloCFDI;

                        //7.- Sello del SAT
                        string selloSAT = resultadoTimbre.SelloSAT;

                        //8.- Cadena original de complemento de certificación
                        string cadena = resultadoTimbre.CadenaTimbre;



                        string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                        cPage.SP_QueryExecute(QueryUpdateFactura);

                        MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GuardarXmlCodigo(CveFactura, NombreFactura + ".pdf", "PDF");

                        ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");

                        string NombreReceptor = cPage.GetStrFieldQuery("Nombre", "SELECT Nombre FROM Receptores WHERE CveReceptor=" + CveReceptor);
                        //EnviarCorreoAutomatico(2, CveReceptor, NombreReceptor, CveFactura);

                        //ActualizarDatos();

                    }
                    else
                    {
                        //No se pudo timbrar, mostramos respuesta
                        MessageBox.Show(resultadoTimbre.Descripcion + ", " + resultadoTimbre.Detalle);
                        if (resultadoTimbre.NumeroError == "25" || resultadoTimbre.NumeroError == "812")
                        {
                            string UUID = resultadoTimbre.Descripcion.Substring(resultadoTimbre.Descripcion.Length - 36, 36);
                            Profact.TimbraCFDI.ResultadoConsulta resultadoConsulta;
                            resultadoConsulta = conector.ObtieneCFDI(RfcEmisor, UUID);

                            if (resultadoConsulta.Exitoso)
                            {
                                //El comprobante fue timbrado exitosamente

                                //Guardamos xml cfdi
                                //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                                string NombreFactura = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura;
                                if (resultadoConsulta.GuardaXml(Destinoxml, NombreFactura))
                                {
                                    //MessageBox.Show("El xml fue guardado correctamente");
                                    GuardarXmlCodigo(CveFactura, NombreFactura + ".xml", "Xml");
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error al guardar el comprobante");
                                }

                                //Los siguientes datos deberán ir en la respresentación impresa ó PDF

                                //1.- Código bidimensional QR
                                string Destinoqr = Path.GetDirectoryName(Application.ExecutablePath) + @"\QR\";
                                if (resultadoConsulta.GuardaCodigoBidimensional(Destinoqr, NombreFactura))
                                {
                                    //MessageBox.Show("El código bidimensional fue guardado correctamente");
                                    GuardarQR(CveFactura, Destinoqr + NombreFactura + ".jpg", "QR", "?QRCodigo");
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error al guardar el código bidimensional");
                                }

                                //2.- Folio fiscal
                                string folioFiscal = resultadoConsulta.FolioUUID;

                                //3.- No. Certificado del Emisor
                                string noCertificado = resultadoConsulta.No_Certificado;

                                //4.- No. Certificado del SAT
                                string noCertificadoSAT = resultadoConsulta.No_Certificado_SAT;

                                //5.- Fecha y Hora de certificación
                                string fechaCert = resultadoConsulta.FechaCertificacion;

                                //6.- Sello del cfdi
                                string selloCFDI = resultadoConsulta.SelloCFDI;

                                //7.- Sello del SAT
                                string selloSAT = resultadoConsulta.SelloSAT;


                                //8.- Cadena original de complemento de certificación
                                string cadena = resultadoConsulta.CadenaTimbre;

                                string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                                cPage.performupdatequery(QueryUpdateFactura);

                                MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GuardarXmlCodigo(CveFactura, NombreFactura + ".pdf", "PDF");

                                ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");



                                MessageBox.Show("Proceso terminado, ahora ya puede imprimir su factura", "Validación de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                           

                            }


                        }
                    }
                    break;

            }
        }

        public void GuardarXmlCodigo(int CveFactura, string Ruta, string Campo)
        {
            if (Ruta != null)
            {
                string Query = "Update Facturas Set " + Campo + "='" + Ruta + "' Where CveFactura=" + CveFactura;
                cPage.SP_QueryExecute(Query);

                //performupdatequery(Query);

                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }
        public void GuardarQR(int CveFactura, string Ruta, string Campo, string Variable)
        {
            if (Ruta != null)
            {
                String strBLOBFilePath = Ruta;
                FileStream fsBLOBFile = new FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read);
                Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
                fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                fsBLOBFile.Close();
                string strconexion = ConfigurationManager.AppSettings["connectionString"];
                using (SqlConnection con = new SqlConnection(strconexion))
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "Update Facturas Set " + Campo + "=" + Variable + " Where CveFactura=" + CveFactura;
                    SqlParameter prm = new SqlParameter(Variable, SqlDbType.Image, bytBLOBData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBLOBData);
                    cmd2.Parameters.Add(prm);
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }


                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }

        void ExportarReport(int CveFactura, int CveEmisor, int CveReceptor, int CveTipoFactura, string Ruta)
        {
            switch (CveTipoFactura)
            {
                case 1:
                case 4:
                case 5:
                case 6:
                    /*RptFacturas rptFac = new RptFacturas();
                    rptFac.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), rptFac);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), rptFac);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), rptFac);


                    rptFac.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                    */
                    string NombreFac = cPage.GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=" + CveTipoFactura + " AND E.CveEmisor=" + CveEmisor);
                    string extesion = "rpt";
                    string DestinoFac = ConfigurationManager.AppSettings["RutaFactura"] + NombreFac + "." + extesion;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRpt.Load(DestinoFac);
                    cPage.SetDBLogonForReport(cryRpt);
                    
                    /*Los parametros los envias de la siguiente forma, el primer valor que pide la Funcion es el nombre del parametro del Reporte y el segundo el valor que le asignas.*/
                    cryRpt.SetParameterValue("CveEmisor", CveEmisor);
                    cryRpt.SetParameterValue("CveReceptor", CveReceptor);
                    cryRpt.SetParameterValue("CveFactura", CveFactura);

                    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);

                    break;
                case 2:

                    string NombreHO = cPage.GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=2 AND E.CveEmisor=" + CveEmisor);
                    string extesionHO = "rpt";
                    string DestinoHO = Path.GetDirectoryName(Application.ExecutablePath) + @"\Fac\" + NombreHO + "." + extesionHO;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRptHO = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRptHO.Load(DestinoHO);
                    cPage.SetDBLogonForReport(cryRptHO);
                    
                    /*Los parametros los envias de la siguiente forma, el primer valor que pide la Funcion es el nombre del parametro del Reporte y el segundo el valor que le asignas.*/
                    cryRptHO.SetParameterValue("CveEmisor", CveEmisor);
                    cryRptHO.SetParameterValue("CveReceptor", CveReceptor);
                    cryRptHO.SetParameterValue("CveFactura", CveFactura);

                    cryRptHO.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);

                    /*
                    RptHonorarios RptHo = new RptHonorarios();
                    RptHo.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), RptHo);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), RptHo);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), RptHo);


                    RptHo.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);*/

                    break;

                case 3:

                    string NombreArr = cPage.GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=3 AND E.CveEmisor=" + CveEmisor);
                    string extesionArr = "rpt";
                    string DestinoArr = Path.GetDirectoryName(Application.ExecutablePath) + @"\Fac\" + NombreArr + "." + extesionArr;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRptArr = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRptArr.Load(DestinoArr);
                    cPage.SetDBLogonForReport(cryRptArr);
                    
                    /*Los parametros los envias de la siguiente forma, el primer valor que pide la Funcion es el nombre del parametro del Reporte y el segundo el valor que le asignas.*/
                    cryRptArr.SetParameterValue("CveEmisor", CveEmisor);
                    cryRptArr.SetParameterValue("CveReceptor", CveReceptor);
                    cryRptArr.SetParameterValue("CveFactura", CveFactura);

                    cryRptArr.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);

                    /*
                    RptArrendamiento RptAre = new RptArrendamiento();
                    RptAre.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), RptAre);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), RptAre);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), RptAre);


                    RptAre.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);*/
                    break;
            }


        }

        private void SetParamValueReporte(string paramName, string paramValue, ReportDocument Reporte)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            for (int i = 0; i < Reporte.DataDefinition.ParameterFields.Count; i++)
            {
                if (Reporte.DataDefinition.ParameterFields[i].FormulaName == "{" + paramName + "}")
                {
                    paramDiscreteValue.Value = paramValue;
                    paramValues.Add(paramDiscreteValue);
                    Reporte.DataDefinition.ParameterFields[i].ApplyCurrentValues(paramValues);
                }
            }
        }

        public string BuscaDirecionSurcural(int CveSucursal)
        {
            ListaParametro.Clear();
          
            string Direccion = "";
            ListaParametro.Add(cm.addparametro("CveSucursal", CveSucursal.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_Reader(ListaParametro, "SP_BuscaSucursal");

            foreach (DataRow rw in _dt.Rows)
            {
                Direccion = rw["Direccion"].ToString();
            }
            return Direccion;
        }

        public int SaveFactura( int CveDocumento, int CveTipoDocumento, int CveUser, int CveEstatusDocumento)
        {
            int result=0;
             
            /*
             * 	@CveNota int,
	@CveTipoDocumento int,
	@CveUser int,
	@CveEstatusDocumento int
             * */

            ListaParametro.Clear();
            _dt.Clear();

            ListaParametro.Add(cm.addparametro("CveNota", CveDocumento.ToString(), "int"));
            ListaParametro.Add(cm.addparametro("CveTipoDocumento", CveTipoDocumento.ToString(), "int"));
            ListaParametro.Add(cm.addparametro("CveUser", CveUser.ToString(), "int"));
            ListaParametro.Add(cm.addparametro("CveEstatusDocumento", CveEstatusDocumento.ToString(), "int"));

                _dt = cm.SP_Busca_Reader(ListaParametro, "SP_Genera_Factura");

                foreach (DataRow rw in _dt.Rows)
                {
                    result = int.Parse(rw["CveNotaTemp"].ToString());
                }
            

         return result;
        }


        public int SaveFactura33Detalle(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (DetalleParametros item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("CveFactura",CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Cantidad", item.Cantidad.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Unidad", item.UnidadMedida, "string"));
                ListParameters.Add(cm.addparametro("Descripcion", item.Descripcion, "string"));
                ListParameters.Add(cm.addparametro("Precio", item.PrecioUnitario.ToString(), "string"));
                ListParameters.Add(cm.addparametro("SubTotal", item.SubTotal.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Descuento", item.Descuento.ToString(), "double"));
                ListParameters.Add(cm.addparametro("IVA", item.TotalIva.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Total", item.Total.ToString(), "double"));
                ListParameters.Add(cm.addparametro("UnidadSat", item.UnidadMedidaSat, "string"));
                ListParameters.Add(cm.addparametro("ClaveProductoServicioSat", item.ClaveProductoServicioSat, "string"));
              

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_ReaderMonar(ListParameters, "SP_InsertDetalleFactura");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFactura"].ToString());
                }

            }




            return CveDetalleFactura;
        }

        public int SaveFactura33(ArrayList ListaParametros )
        {
            int CveFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {

                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("NoDocumento", item.NoDocumento, "string"));
                ListParameters.Add(cm.addparametro("FolioInt", item.NoDocumento, "int"));
                ListParameters.Add(cm.addparametro("Serie", item.Serie, "string"));
                ListParameters.Add(cm.addparametro("FechaEmision", item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("Fecha", item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("FechaCertificacion", item.FechaCerficacion, "string"));
                ListParameters.Add(cm.addparametro("CveEstatus", item.CveEstatus.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveTipoFactura", item.CveTipoFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Observacion", item.Observacion, "string"));
                ListParameters.Add(cm.addparametro("CveUser", item.CveUser.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveEmisor", item.CveEmisor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFormaPago", item.CveFormaPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveMetodoPago", item.CveMetodoPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveUsoCfdi", item.CveUsoCfdi.ToString(), "int"));
                ListParameters.Add(cm.addparametro("SubTotal", item.SubTotal.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Descuento  ", item.Descuento.ToString(), "double"));
                ListParameters.Add(cm.addparametro("IvaP ", item.IvaP.ToString(), "int"));
                ListParameters.Add(cm.addparametro("IvaTotal", item.IvaTotal.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Total", item.Total.ToString(), "double"));
                ListParameters.Add(cm.addparametro("TotalLetra", item.ImporteLetras, "string"));
                ListParameters.Add(cm.addparametro("TipoComprobanteSat", item.TipoComprobanteSat, "string"));
                ListParameters.Add(cm.addparametro("ImpuestoSat", item.ImpuestoSat, "string"));
                ListParameters.Add(cm.addparametro("MonedaSat", item.MonedaSat, "string"));
                ListParameters.Add(cm.addparametro("PaisSat", item.PaisSat, "string"));
                ListParameters.Add(cm.addparametro("LugarExpedicionSat", item.LugarExpedicionSat, "string"));
                ListParameters.Add(cm.addparametro("TipoCambioSat", item.TipoCambioSat, "int"));
                ListParameters.Add(cm.addparametro("MetodoPagoSat", item.MetodoPagoSat, "string"));
                ListParameters.Add(cm.addparametro("FormaPagoSat", item.FormaPagoSat, "string"));
                ListParameters.Add(cm.addparametro("UsoCFDISat", item.UsoCfdiSat, "string"));
                ListParameters.Add(cm.addparametro("CondicionesPago", item.CondicionesPago, "string"));
                ListParameters.Add(cm.addparametro("CadenaOriginal", item.CadenaOriginal, "string"));
                ListParameters.Add(cm.addparametro("UUID", item.UUID, "string"));
                ListParameters.Add(cm.addparametro("SCDCFDI", item.SCDCFDI, "string"));
                ListParameters.Add(cm.addparametro("SCDSAT", item.SCDSAT, "string"));
                ListParameters.Add(cm.addparametro("CertificadoEmisor", item.CertificadoEmisor, "string"));
                ListParameters.Add(cm.addparametro("CertificadoSAT", item.CertificadoSat, "string"));
                ListParameters.Add(cm.addparametro("ProveedorCFDI ", item.ProveedorCFDI, "string"));
                ListParameters.Add(cm.addparametro("ISRRetenido", item.ISRRetenido, "double"));
                ListParameters.Add(cm.addparametro("IVARetenido", item.IVaRetenido, "double"));
                ListParameters.Add(cm.addparametro("Timbrado", item.Timbrado.ToString(), "int"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_ReaderMonar(ListParameters, "SP_TimbradoFactura");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFactura = int.Parse(rw["CveFactura"].ToString());
                }

            }

            return CveFactura;
        }

        public int SaveFactura33Detalle_Complemento(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (DetalleParametrosFacturaComplemento item in ListaParametros)
            {

                ListParameters.Clear();
                

                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("FechaPago", item.SrtFechaPago, "string"));
                ListParameters.Add(cm.addparametro("FormaPago", item.StrFormaPago, "string"));
                ListParameters.Add(cm.addparametro("Moneda", item.StrMoneda, "string"));
                ListParameters.Add(cm.addparametro("TipoCambioP", item.StrTipoCambioP, "string"));
                ListParameters.Add(cm.addparametro("Monto", item.DcMonto.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("NumOperacion", item.StrNumOperacion, "string"));
                ListParameters.Add(cm.addparametro("rfcEmisorCtaOrd", item.StrrfcEmisorCtaOrd, "string"));
                ListParameters.Add(cm.addparametro("nomBancoOrdExt", item.StrnomBancoOrdExt, "string"));
                ListParameters.Add(cm.addparametro("ctaOrdenante", item.StrctaOrdenante, "string"));
                ListParameters.Add(cm.addparametro("rfcEmisorCtaBen", item.StrrfcEmisorCtaBen, "string"));
                ListParameters.Add(cm.addparametro("ctaBeneficiario", item.StrctaBeneficiario, "string"));
                /*
                ListParameters.Add(cm.addparametro("tipoCadPago", null, "string"));
                ListParameters.Add(cm.addparametro("certPago", null, "string"));
                ListParameters.Add(cm.addparametro("cadPago", null, "string"));
                ListParameters.Add(cm.addparametro("selloPago", null, "string"));
                */


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_ReaderMonar(ListParameters, "SP_InsertDetalleFacturaComplemento");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFacturaComplemento"].ToString());
                }

            }




            return CveDetalleFactura;
        }

        public int SaveFactura33Detalle_Complemento_DocRelacionado(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (DoctoRelacionadoComplemento item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFacturaDoctoRelacionado", item.IntCveFacturaDoctoRelacionado.ToString(), "int"));
                ListParameters.Add(cm.addparametro("idDocumento", item.StridDocumento, "string"));
                ListParameters.Add(cm.addparametro("serie", item.Strserie, "string"));
                ListParameters.Add(cm.addparametro("folio", item.Strfolio, "string"));
                ListParameters.Add(cm.addparametro("monedaDr", item.StrmonedaDr.ToString(), "string"));
                ListParameters.Add(cm.addparametro("tipoCambioDr", item.StrtipoCambioDr, "string"));
                ListParameters.Add(cm.addparametro("metodoPagoDr", item.StrmetodoPagoDr.ToString(), "string"));
                ListParameters.Add(cm.addparametro("numParcialidad", item.StrnumParcialidad.ToString(), "double"));
                ListParameters.Add(cm.addparametro("impSaldoAnt", item.DcimpSaldoAnt.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("impPagado", item.DcimpPagado.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("impSaldoInsoluto", item.DcimpSaldoInsoluto.ToString(), "decimal"));


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_ReaderMonar(ListParameters, "SP_DoctoRelacionadoComplemento");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleDoctoRelacionadoComplemento"].ToString());
                }

            }




            return CveDetalleFactura;
        }

        public int SaveFactura33Detalle_DocRelacionado_Cfdi(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (CfdiRelacionado item in ListaParametros)
            {

                ListParameters.Clear();

                /*
                 * 
                  @CveFactura int,
           @CveTipoRelacion int,
           @UUID varchar(50),
           @DescripcionTipoRelacion varchar(50)

    */

                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveTipoRelacion", item.IntCveTipoRelacion.ToString(), "int"));
                ListParameters.Add(cm.addparametro("UUID", item.StrUUID, "string"));
                ListParameters.Add(cm.addparametro("DescripcionTipoRelacion", item.StrDescripcionTipoRelacion, "string"));
                

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_ReaderMonar(ListParameters, "SP_CfdiRelacionado");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveCfdiRelacionado"].ToString());
                }

            }




            return CveDetalleFactura;
        }

        public int SaveFactura33_Complemento(ArrayList ListaParametros)
        {
            int CveFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {

                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("NoDocumento", item.NoDocumento, "string"));
                ListParameters.Add(cm.addparametro("FolioInt", item.NoDocumento, "int"));
                ListParameters.Add(cm.addparametro("Serie", item.Serie, "string"));
                ListParameters.Add(cm.addparametro("FechaEmision", item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("Fecha", item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("FechaCertificacion", item.FechaCerficacion, "string"));
                ListParameters.Add(cm.addparametro("CveEstatus", item.CveEstatus.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveTipoFactura", item.CveTipoFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Observacion", item.Observacion, "string"));
                ListParameters.Add(cm.addparametro("CveUser", item.CveUser.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveEmisor", item.CveEmisor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFormaPago", item.CveFormaPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveMetodoPago", item.CveMetodoPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveUsoCfdi", item.CveUsoCfdi.ToString(), "int"));
                ListParameters.Add(cm.addparametro("SubTotal", item.SubTotal.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Descuento  ", item.Descuento.ToString(), "double"));
                ListParameters.Add(cm.addparametro("IvaP ", item.IvaP.ToString(), "int"));
                ListParameters.Add(cm.addparametro("IvaTotal", item.IvaTotal.ToString(), "double"));
                ListParameters.Add(cm.addparametro("Total", item.Total.ToString(), "double"));
                ListParameters.Add(cm.addparametro("TotalLetra", item.ImporteLetras, "string"));
                ListParameters.Add(cm.addparametro("TipoComprobanteSat", item.TipoComprobanteSat, "string"));
                ListParameters.Add(cm.addparametro("ImpuestoSat", item.ImpuestoSat, "string"));
                ListParameters.Add(cm.addparametro("MonedaSat", item.MonedaSat, "string"));
                ListParameters.Add(cm.addparametro("PaisSat", item.PaisSat, "string"));
                ListParameters.Add(cm.addparametro("LugarExpedicionSat", item.LugarExpedicionSat, "string"));
                ListParameters.Add(cm.addparametro("TipoCambioSat", item.TipoCambioSat, "int"));
                ListParameters.Add(cm.addparametro("MetodoPagoSat", item.MetodoPagoSat, "string"));
                ListParameters.Add(cm.addparametro("FormaPagoSat", item.FormaPagoSat, "string"));
                ListParameters.Add(cm.addparametro("UsoCFDISat", item.UsoCfdiSat, "string"));
                ListParameters.Add(cm.addparametro("CondicionesPago", item.CondicionesPago, "string"));
                ListParameters.Add(cm.addparametro("CadenaOriginal", item.CadenaOriginal, "string"));
                ListParameters.Add(cm.addparametro("UUID", item.UUID, "string"));
                ListParameters.Add(cm.addparametro("SCDCFDI", item.SCDCFDI, "string"));
                ListParameters.Add(cm.addparametro("SCDSAT", item.SCDSAT, "string"));
                ListParameters.Add(cm.addparametro("CertificadoEmisor", item.CertificadoEmisor, "string"));
                ListParameters.Add(cm.addparametro("CertificadoSAT", item.CertificadoSat, "string"));
                ListParameters.Add(cm.addparametro("ProveedorCFDI ", item.ProveedorCFDI, "string"));
                ListParameters.Add(cm.addparametro("ISRRetenido", item.ISRRetenido, "double"));
                ListParameters.Add(cm.addparametro("IVARetenido", item.IVaRetenido, "double"));
                ListParameters.Add(cm.addparametro("Timbrado", item.Timbrado.ToString(), "int"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_ReaderMonar(ListParameters, "SP_TimbradoFactura_Complemento");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFactura = int.Parse(rw["CveFactura_Complemento"].ToString());
                }

            }




            return CveFactura;
        }

        public string ObtenerNoDocumento()
        {
            string NoDocumento = "";

            return NoDocumento;
        }
        
        public int CveNotaParent(ArrayList ListaParametros)
        {
            int cveNotaParent=0;



            return cveNotaParent;
        }

        public DataTable GetDatosFactura(int CveFactura)
        {
            ListaParametro.Clear();

           
            ListaParametro.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_GetDatosFactura");
            

            return _dt;
        }
        public DataTable GetDatosFacturaReceptor(int CveReceptor)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("CveReceptor", CveReceptor.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_Facturas_Receptor");


            return _dt;
        }
        public DataTable GetDatosFacturaValidacion(int CveFactura)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_FacturasValidasParaComplemento");


            return _dt;
        }

        public DataTable GetDatosFacturaValidacion(int CveFactura, decimal ImportePagado, int opcion=0)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("_CveFactura", CveFactura.ToString(), "int"));
            ListaParametro.Add(cm.addparametro("_DcImportePagado", ImportePagado.ToString(), "decimal"));

            _dt.Clear();

            if (opcion == 0)
                _dt = cm.SP_Busca_Reader(ListaParametro, "SP_FacturasValidasParaComplemento");
            else
                _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_FacturasValidasParaComplemento");


            return _dt;
        }

        public DataTable GetDatosFacturaDetalleImporte(int CveFactura)
        {
            ListaParametro.Clear();
            ListaParametro.Clear();

            DataTable _dtResult = new DataTable();
            ListaParametro.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
            //ListaParametro.Add(cm.addparametro("_dcImportePagado", ImportePagado.ToString(), "decimal"));

            //_dt.Clear();

            _dtResult = cm.SP_Busca_Reader(ListaParametro, "SP_GetDatosFacturaDetalleImporte");


            return _dtResult;
        }
        public DataTable GetDatosFacturaImpuestosCs(int CveDetalleFactura)
        {
            ListaParametro.Clear();
            ListaParametro.Clear();

            DataTable _dtResult = new DataTable();
            ListaParametro.Add(cm.addparametro("CveDetalleFactura", CveDetalleFactura.ToString(), "int"));
            //ListaParametro.Add(cm.addparametro("_dcImportePagado", ImportePagado.ToString(), "decimal"));

            //_dt.Clear();

            _dtResult = cm.SP_Busca_Reader(ListaParametro, "SP_GetFacturaDetalleImpuestoCs");


            return _dtResult;
        }

        public DataTable GetDatosFacturaImpuestos(int CveFactura)
        {
            ListaParametro.Clear();
            ListaParametro.Clear();

            DataTable _dtResult = new DataTable();
            ListaParametro.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
            //ListaParametro.Add(cm.addparametro("_dcImportePagado", ImportePagado.ToString(), "decimal"));

            //_dt.Clear();

            _dtResult = cm.SP_Busca_Reader(ListaParametro, "SP_GetFacturaDetalleImpuesto");


            return _dtResult;
        }

        
        public DataTable GetDatosFacturaReceptor_Timbradas(int CveReceptor, int CveTipoFactura)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptor.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_Reader(ListaParametro, "SP_Facturas_Receptor_Timbradas");

            string CveFacturas = "";

            foreach (DataRow rw in _dt.Rows)
            {
                CveFacturas = rw["_CveFacturas"].ToString();
            }

            string Query = "SELECT CveFactura As Folio, R.Nombre As Receptor , FechaEmision, UUID, Total " +
                " FROM Facturas F Left Join Receptores R on  F.CveReceptor=R.CveReceptor  WHERE CveFactura IN(" + CveFacturas + ") ORDER BY CveFactura";

            DataTable _dtResult = cm.SP_DataReaderQuery(Query);


            return _dtResult;
        }
        public DataTable GetDatosFacturaReceptorPago(int CveReceptor, int opcion = 0)
        {
            ListaParametro.Clear();

            /*opcion=0  Timbrado 4.0
               opcion=1 timbrado 3.3
            */
          

            _dt.Clear();
            DataTable _dtResult = new DataTable();
            if (opcion == 0)
            {
                ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptor.ToString(), "int"));
                _dt = cm.SP_Busca_Reader(ListaParametro, "SP_Facturas_Receptor_Pago");

                string CveFacturas = "";

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFacturas = rw["_CveFacturas"].ToString();
                }

                string Query = "SELECT CveFactura As Folio, R.Nombre As Receptor , FechaEmision, UUID, Total,  SaldoActual " +
                    " FROM Facturas F Left Join Receptores R on  F.CveReceptor=R.CveReceptor  WHERE CveFactura IN(" + CveFacturas + ") ORDER BY CveFactura";

                _dtResult = cm.SP_DataReaderQuery(Query);
            }
            else
            {
                string QueryReceptor = "Select NUM_REG As CveReceptor From CLIE01 " +
                    "Where ltrim(rtrim(CCLIE))='" + CveReceptor + "';";
                string CveReceptorMonar = Page.GetStrFieldQueryMonar("CveReceptor", QueryReceptor);
                ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptorMonar, "int"));

                _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_Facturas_Receptor_Pago");

                string CveFacturas = "";

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFacturas = rw["_CveFacturas"].ToString();
                }
                string Query = "SELECT CveFactura As Folio, E.NOMBRE As Receptor , FechaEmision, UUID, Total " +
                    "FROM Facturas F ,  CLIE01 E WHERE CveFactura IN(" + CveFacturas + ") And RTRIM(LTRIM(E.CCLIE))='" + CveReceptor + "' ORDER BY CveFactura";
                _dtResult = cm.SP_DataReaderQueryMonar(Query);

            }
           


            return _dtResult;
        }
        public DataTable GetDatosFacturaReceptor_Timbradas(int CveReceptor)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptor.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_Reader(ListaParametro, "SP_Facturas_Receptor");

            string CveFacturas = "";

            foreach (DataRow rw in _dt.Rows)
            {
                CveFacturas = rw["_CveFacturas"].ToString();
            }

            string Query = "SELECT CveFactura As Folio, R.Nombre As Receptor , FechaEmision, UUID, Total " +
                " FROM Facturas F Left Join Receptores R on  F.CveReceptor=R.CveReceptor  WHERE CveFactura IN(" + CveFacturas + ") ORDER BY CveFactura";

            DataTable _dtResult = cm.SP_DataReaderQuery(Query);


            return _dtResult;
        }


        public ArrayList Agregar_DoctoRelacion_Complemento(string _NoDocumento, decimal ImportePagado = 0)
        {

            ArrayList ListaRelacionCfdi_Complemento = new ArrayList();
            int _IntCveFactura = 0;// int.Parse(item.IntCveFactura.ToString());

            string Query = "Select CveFactura From Facturas Where CveFactura=" + _NoDocumento.Trim();

            _IntCveFactura = int.Parse(Page.GetStrFieldQuery("CveFactura", Query));

            DataTable _dtGet = new DataTable();
            _dtGet = GetDatosFacturaValidacion(_IntCveFactura, ImportePagado);

            foreach (DataRow _val in _dtGet.Rows)
            {

                if (decimal.Parse(_val["ImporteDiferencia"].ToString()) != 0)
                {
                    Clases.cFacturacion.DoctoRelacionadoComplemento _dc = new Clases.cFacturacion.DoctoRelacionadoComplemento();

                    //_dc.IntCveFactura = int.Parse(_val["CveFactura"].ToString());
                    _dc.IntCveReceptor = int.Parse(_val["CveReceptor"].ToString());
                    _dc.Strfolio = _val["FolioInt"].ToString();
                    _dc.Strserie = "A";
                    _dc.StridDocumento = _val["UUID"].ToString();
                    _dc.DcimpSaldoAnt = decimal.Parse(_val["ImporteDiferencia"].ToString()); //decimal.Parse(_val["Total"].ToString()) - decimal.Parse(_val)
                    _dc.DcimpPagado = decimal.Parse(_val["_DcImportePagado"].ToString());
                    _dc.DcimpSaldoInsoluto = decimal.Parse(_val["_ImporteSaldoInsoluto"].ToString()); ;
                    _dc.IntCveFacturaDoctoRelacionado = int.Parse(_val["CveFactura"].ToString());
                    _dc.StrmetodoPagoDr = _val["MetodoPagoSat"].ToString();
                    _dc.StrmonedaDr = "MXN";
                    _dc.StrnumParcialidad = _val["_CuentaDocto"].ToString();
                    _dc.StrtipoCambioDr = "1";
                    _dc.StrFechaEmision = _val["FechaEmision"].ToString();

                    ListaRelacionCfdi_Complemento.Add(_dc);

                    /*
                    loadDataGrid(dataGridDetalle, ListaRelacionCfdi_Complemento);
                    txtTotalFactura_DR.Text = SumaTotales(dataGridDetalle, "Importe").ToString("c");
                    */

                }
                else
                {
                    MessageBox.Show("Favor de verificar el No. de Documento, El saldo de la factura a pagar es: " + _val["ImporteDiferencia"].ToString(), "Validacion de Datos");
                }

            }

            return ListaRelacionCfdi_Complemento;

        }


        public ArrayList Agregar_DoctoRelacion_Complemento(string _NoDocumento)
        {
            int _IntCveFactura = 0;// int.Parse(item.IntCveFactura.ToString());
            ArrayList ListaRelacionCfdi_Complemento = new ArrayList();

            string Query = "Select CveFactura From Facturas Where CveFactura=" + _NoDocumento.Trim();

            _IntCveFactura = int.Parse(cm.GetStrFieldQuery("CveFactura", Query));

            DataTable _dtGet = new DataTable();
            _dtGet = GetDatosFacturaValidacion(_IntCveFactura, 0);

            foreach (DataRow _val in _dtGet.Rows)
            {

                if (decimal.Parse(_val["ImporteDiferencia"].ToString()) != 0)
                {
                    Clases.cFacturacion.DoctoRelacionadoComplemento _dc = new Clases.cFacturacion.DoctoRelacionadoComplemento();

                    _dc.IntCveFactura = int.Parse(_val["CveFactura"].ToString());
                    _dc.IntCveReceptor = int.Parse(_val["CveReceptor"].ToString());
                    _dc.Strfolio = _val["FolioInt"].ToString();
                    _dc.Strserie = "A";
                    _dc.StridDocumento = _val["UUID"].ToString();
                    _dc.DcimpSaldoAnt = decimal.Parse(_val["ImporteDiferencia"].ToString()); //decimal.Parse(_val["Total"].ToString()) - decimal.Parse(_val)
                    _dc.DcimpPagado = decimal.Parse(_val["_DcImportePagado"].ToString());
                    _dc.DcimpSaldoInsoluto = decimal.Parse(_val["_ImporteSaldoInsoluto"].ToString()); ;
                    _dc.IntCveFacturaDoctoRelacionado = int.Parse(_val["CveFactura"].ToString());
                    _dc.StrmetodoPagoDr = _val["MetodoPagoSat"].ToString();
                    _dc.StrmonedaDr = "MXN";
                    _dc.StrnumParcialidad = _val["_CuentaDocto"].ToString();
                    _dc.StrtipoCambioDr = "1";
                    _dc.StrFechaEmision = _val["FechaEmision"].ToString();

                    ListaRelacionCfdi_Complemento.Add(_dc);


                    //loadDataGrid(dataGridDetalle, ListaRelacionCfdi_Complemento);
                    //txtTotalFactura_DR.Text = SumaTotales(dataGridDetalle, "Importe").ToString("c");



                }
                else
                {
                    MessageBox.Show("Favor de verificar el No. de Documento, El saldo de la factura a pagar es: " + _val["ImporteDiferencia"].ToString(), "Validacion de Datos");
                }

                //return ListaRelacionCfdi_Complemento;
            }

            return ListaRelacionCfdi_Complemento;
        }


    }
}
