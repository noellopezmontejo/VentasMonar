using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Profact.TimbraCFDI33;
using System.Data.SqlClient;
using VentasMonar.Common.Helpers;
using System.Configuration;
using static VentasMonar.Common.PageBase;
using System.IO;
using System.Xml;
using CrystalDecisions.Shared;
using System.Diagnostics;
using VentasMonar.Common.Models;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Imaging;

namespace VentasMonar.Common.Clases
{
    class cFacturacion40
    {
        Clases.cPageBase pb = new cPageBase();
        cPageBase cm = new cPageBase();
        ArrayList ListaParametro = new ArrayList();
        DataTable _dt = new DataTable();
        PageBase Page = new PageBase();

        string strconexion = "";
        public cFacturacion40()
        {
            strconexion= ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString;
        }

        public class DetalleNoSerie
        {
            public int CveDetalleNoSerie { get; set; }
            public int CveDetalleFactura { get; set; }
            public int CveFactura { get; set; }
            public int CveConcepto { get; set; }
            public string NoSerie { get; set; }
            public string  sGuidPadre { get; set; }
            public string sGuidHijo { get; set; }

        }
        public class Parametros
        {


            private int intCveReceptor;
            /// <summary>
            /// No Documento
            /// </summary>
            private string noDocumento;
            /// <summary>
            /// Serie de Cfdi
            /// </summary>
            private string serie;
            /// <summary>
            /// Fecha de Emision en el formato correcto
            /// </summary>
            private string fechaEmision;
            /// <summary>
            /// Fecha de Certificacion en el formato correcto
            /// </summary>
            private string fechaCerficacion;
            /// <summary>
            /// Estatus del documento
            /// 1.- Activo
            /// 2.- Timbrado
            /// </summary>
            private int cveEstatus;
            /// <summary>
            /// Tipo de Documento
            /// 1.- Factura
            /// 2.- Recibo de Honorarios
            /// 3.- Complemento
            /// </summary>
            private int cveTipoFactura;
            private int cveSucursal;
            /// <summary>
            /// Lugar de Expedicion
            /// Agregar el nombre del lugar
            /// </summary>
            private string lugarExpedicion;
            private string observacion;
            /// <summary>
            /// Clave de Usuario
            /// </summary>
            private int cveuser;

            private int cveEmisor;

            private int cveExpedidoEn;
            private string folioFiscal;
            private int cveMetodoPago;
            private int cveFormaPago;
            private decimal descuento;
            private decimal subTotal;
            private decimal ivaP;
            private decimal ivaTotal;
            private decimal total;
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
            private decimal iSRRetenido;
            private decimal iSRRetenidoResico;
            private decimal iVaRetenido;
            private string xml;
            private string cveNotas;
            private int timbrado;
            private Image qR;
            private string pDF;
            private string pDFC;
            private string importeLetras;
            private int cveUsoCfdi;
            private string folioInt;
            private string strCPExpedido;
            private string strClaveCuenta;

            public int CvePacTimbrado { get; set; }

            /// <summary>
            /// Nombre Completo de Emisor,  Fisica o Moral
            /// </summary>
            public string NombreEmisor { get; set; }
            /// <summary>
            /// Regimen Fiscal de Emisor
            /// </summary>
            public string RegimenFiscal { get; set; }

           /// <summary>
           /// Uso de Cfdi del catalogo c_UsoCfdi
           /// </summary>
            public string c_UsoCfdi { get; set; }

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
            public decimal IVaRetenido
            {
                get { return iVaRetenido; }
                set { iVaRetenido = value; }
            }

            /// <summary>
            /// ISR Total Retenido
            /// </summary>
            public decimal ISRRetenido
            {
                get { return iSRRetenido; }
                set { iSRRetenido = value; }
            }

            /// <summary>
            /// ISR Total Retenido RESICO
            /// </summary>
            public decimal ISRRetenidoResico
            {
                get { return iSRRetenidoResico; }
                set { iSRRetenidoResico = value; }
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
            public decimal Total
            {
                get { return total; }
                set { total = value; }
            }
            /// <summary>
            /// IVA Total
            /// </summary>
            public decimal IvaTotal
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
            public decimal SubTotal
            {
                get { return subTotal; }
                set { subTotal = value; }
            }
            /// <summary>
            /// Descuento Total del Documento
            /// </summary>
            public decimal Descuento
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
            public int CveReceptor
            {
                get { return intCveReceptor; }
                set { intCveReceptor = value; }
            }

            /// <summary>
            /// Se debe registrar el código postal del lugar de expedición del comprobante
            /// catálogo c_CodigoPostal.
            /// LugarExpedicion= 01000
            /// </summary>
            public string StrCPExpedido { get => strCPExpedido; set => strCPExpedido = value; }
            public string StrClaveCuenta { get => strClaveCuenta; set => strClaveCuenta = value; }

            public string ImpLocalNombre { get; set; }

            public decimal ImpLocalPorcentaje { get; set; }
            public decimal ImpLocalImporte { get; set; }

            public string CuentaPredial { get; set; }
            public string strGuid { get; set; }

            public int CveFolio { get; set; }

            /// <summary>
            /// RFC de Emisor de Factura
            /// </summary>
            public string RfcEmisor { get; set; }

            /// <summary>
            /// RFC del Receptor o Cliente de Factura
            /// </summary>
            public string RfcReceptor { get; set; }
            /// <summary>
            /// Nombre Completo del Receptor o Cliente,  Fisica o Moral
            /// </summary>
            public string strNombreReceptor { get; set; }

            public string CveClave { get; set; }

            public decimal NuevoSaldo { get; set; }
            public decimal Abono { get; set; }
            public decimal Venta { get; set; }

            public int CveCuenta { get; set; }
            public int CveFactura { get; set; }
            public int CveAbono { get; set; }
            public int CveDocumento { get; set; }
            public int CveTipoDocumento { get; set; }

            public int CveMoneda { get; set; }

            /// <summary>
            /// Se debe registrar el código postal del domicilio fiscal del receptor del comprobante.
            /// </summary>
            public string DomicilioFiscalReceptor { get; set; }
            /// <summary>
            /// Regimen Fiscal Receptor del catalogo de regimenes fiscales
            /// </summary>
            public string RegimenFiscalReceptor { get; set; }

            /// <summary>
            /// Cuando el receptor del comprobante sea un residente en el
            ///extranjero, se debe registrar la clave del país de residencia para
            ///efectos fiscales del receptor del comprobante.
            ///Ejemplo: Si la residencia fiscal de la empresa extranjera
            ///receptora del comprobante fiscal se encuentra en Estados
            ///Unidos de América, se debe registrar lo siguiente:
            /// <example>ResidenciaFiscal= USA</example>
            /// </summary>

            public string  ResidenciaFiscalReceptor { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string NumRegIdTrib { get; set; }
            public string Exportacion { get; set; }
            public string c_Objetoimp { get; set; }
            public int OpcionValidar { get; set; }

            public int CveExportacion { get; set; }
            public int CveObjetoImp { get; set; }
        }

        public class CfdiRelacionado
        {
            private int intCveFactura;
            
            private int intCveTipoRelacion;
            private string strUUID;
            private string strDescripcionTipoRelacion;
            private string str_c_TipoRelacion;

            public int intCveFacturaRelacion { get; set; }
            public int IntCveFactura { get => intCveFactura; set => intCveFactura = value; }
            public int IntCveTipoRelacion { get => intCveTipoRelacion; set => intCveTipoRelacion = value; }
            /// <summary>
            /// UUID Relacionado
            /// </summary>
            public string StrUUID { get => strUUID; set => strUUID = value; }
            /// <summary>
            /// Descripcion del Tipo de Relación
            /// </summary>
            public string StrDescripcionTipoRelacion { get => strDescripcionTipoRelacion; set => strDescripcionTipoRelacion = value; }
            /// <summary>
            /// Tipo de Relacion c_TipoRelacion del catalogo
            /// </summary>
            public string Str_c_TipoRelacion { get => str_c_TipoRelacion; set => str_c_TipoRelacion = value; }
            /// <summary>
            /// Guid Random
            /// </summary>
            public string sGuid { get; set; }

            public int OpcionValidar { get; set; }
            public int ChkManual { get; set; }

        }

        public class DatosSucursalEmisor
        {
            private int intCveSucursal;
            private string strNombre;
            private string strCalle;
            private string strNoInterior;
            private string strNoExterior;
            private string strColonia;
            private string strMunicipio;
            private string strEstado;
            private string strPais;
            private string strCodigoPostal;


            public string StrCodigoPostal
            {
                get { return strCodigoPostal; }
                set { strCodigoPostal = value; }
            }

            public string StrPais
            {
                get { return strPais; }
                set { strPais = value; }
            }

            public string StrEstado
            {
                get { return strEstado; }
                set { strEstado = value; }
            }

            public string StrMunicipio
            {
                get { return strMunicipio; }
                set { strMunicipio = value; }
            }


            public string StrColonia
            {
                get { return strColonia; }
                set { strColonia = value; }
            }

            public string StrNoExterior
            {
                get { return strNoExterior; }
                set { strNoExterior = value; }
            }

            public string StrNoInterior
            {
                get { return strNoInterior; }
                set { strNoInterior = value; }
            }

            public string StrCalle
            {
                get { return strCalle; }
                set { strCalle = value; }
            }

            public string StrNombre
            {
                get { return strNombre; }
                set { strNombre = value; }
            }

            public int IntCveSucursal
            {
                get { return intCveSucursal; }
                set { intCveSucursal = value; }
            }

        }

        public class DatosEmisor
        {
            private int intCveEmisor;
            private string strDireccion;
            private string strRFC;
            private int intCveTipo;
            private string strExpedidoEn;
            private string strNombre;

            public int IntCveEmisor { get => intCveEmisor; set => intCveEmisor = value; }
            public string StrDireccion { get => strDireccion; set => strDireccion = value; }
            public string StrRFC { get => strRFC; set => strRFC = value; }
            public int IntCveTipo { get => intCveTipo; set => intCveTipo = value; }
            public string StrExpedidoEn { get => strExpedidoEn; set => strExpedidoEn = value; }
            public string StrNombre { get => strNombre; set => strNombre = value; }
        }
        public class DatosReceptores
        {
            private int intCveReceptor;
            private string strDireccion;
            private string strRFC;
            private int intCveTipo;
            private string strExpedidoEn;
            private string strNombre;

            public int IntCveReceptor { get => intCveReceptor; set => intCveReceptor= value; }
            public string StrDireccion { get => strDireccion; set => strDireccion = value; }
            public string StrRFC { get => strRFC; set => strRFC = value; }
            public int IntCveTipo { get => intCveTipo; set => intCveTipo = value; }
            public string StrExpedidoEn { get => strExpedidoEn; set => strExpedidoEn = value; }
            public string StrNombre { get => strNombre; set => strNombre = value; }
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

            private decimal dblIva;
            private int intChkIva;
            private int intChkIvaRetenido;
            private int intChkIsrRetenido;
            private int intChkIsrRetenidoResico;
            private decimal dblIvaRetenido;
            private decimal dblIsrRetenido;
            private decimal dblIsrRetenidoResico;
            private decimal porcentajeIva;
            private decimal porcentajeISRRetenido;
            private decimal porcentajeISRRetenidoResico;
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
            public decimal DblIva { get => dblIva; set => dblIva = value; }
            public int IntChkIva { get => intChkIva; set => intChkIva = value; }
            public int IntChkIvaRetenido { get => intChkIvaRetenido; set => intChkIvaRetenido = value; }
            public int IntChkIsrRetenido { get => intChkIsrRetenido; set => intChkIsrRetenido = value; }
            public int IntChkIsrRetenidoResico { get => intChkIsrRetenidoResico; set => intChkIsrRetenidoResico = value; }
            public decimal DblIvaRetenido { get => dblIvaRetenido; set => dblIvaRetenido = value; }
            public decimal DblIsrRetenido { get => dblIsrRetenido; set => dblIsrRetenido = value; }
            public decimal DblIsrRetenidoResico { get => dblIsrRetenidoResico; set => dblIsrRetenidoResico = value; }

            public decimal PorcentajeIva { get => porcentajeIva; set => porcentajeIva = value; }
            public decimal PorcentajeISRRetenido { get => porcentajeISRRetenido; set => porcentajeISRRetenido = value; }
            public decimal PorcentajeISRRetenidoResico { get => porcentajeISRRetenidoResico; set => porcentajeISRRetenidoResico = value; }

            public string StrClaveUnidadSat { get => strClaveUnidadSat; set => strClaveUnidadSat = value; }
            public string ClaveProdServSat1 { get => ClaveProdServSat; set => ClaveProdServSat = value; }

            public int CveIva { get; set; }
            public string  NombreOriginal { get; set; }

            public string Nota { get; set; }

            public string sGuid { get; set; }
            public int CveConcepto { get; set; }

            public ArrayList ListConceptoImpuesto { get; set; }
            public string ObjetoImp { get; internal set; }
            public int OpcionValidar { get; set; }
            public int CveObjetoImpuesto { get; set; }
            public int ChkSerie { get; set; }

            public byte[] NotaAdicional { get; set; }

            public int ChkDesgloce { get; set; }
            public int ChkNotaAConcepto { get; set; }

            public decimal PrecioOriginal { get; set; }

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

            public ArrayList ListaImpuestos { get; set; }
            public ArrayList ListaImpuestosTotal { get; set; }
            public decimal FI { get; set; }
            //public decimal TipoCambio { get; set; }
            public int CveMoneda { get; set; }
            //public string c_Moneda { get; set; }

            public string _c_ObjetoImpDR { get; set; }
            public decimal ImportePagadoP { get; set; }

            public int IntCveTipoRelacion { get; set; }
            public string StrDescripcionTipoRelacion { get; set; }
            public string Str_c_TipoRelacion { get; set; }

            public string sGuid { get; set; }

        }

        public class DetalleFacturaRetencion
        {
            public int CveFacturaRetencion { get; set; }
            public int CveFactura { get; set; }
            public int CveRetencion { get; set; }
            public int CveImpuesto { get; set; }
            public decimal Importe { get; set; }
            public decimal Porcentaje { get; set; }
            public string sGuid { get; set; }

            public string Descripcion { get; set; }
           
        }

        public class DatosComplemento
        {

            public int IntCveReceptor { get; set; }
            public int CveFacturaRelacion { get; set; }
            public string cFechaPago { get; set; }
            public string cFormaPago { get; set; }
            public string cMetodoPago { get; set; }
            public string cUsoCfdi { get; set; }
            public string CondicionesPago { get; set; }
            public int CveFormaPago { get; set; }
            public int CveMetodoPago { get; set; }
            public int CveUsoCfdi { get; set; }

            public string cMoneda { get; set; }
            public decimal dcTipoCambio { get; set; }
            public string Observaciones { get; set; }

            public string cNoOperacion { get; set; }
            public string cRFCOrdenante { get; set; }
            public string cBancoOrdenante { get; set; }
            public string cCuentaOrdenante { get; set; }


            public string cRfcBeneficiario { get; set; }
            public string cBancoBeneficiario { get; set; }
            public string cCuentaBeneficiario { get; set; }
            public decimal dcTotalPago { get; set; }

        }

        public class DatosParaTimbrar
        {
            public int CveFactura { get; set; }
            public int CveEmisor { get; set; }
            public int CveReceptor { get; set; }
            public int cvetipofactura { get; set; }
            public string RfcEmisor { get; set; }
            public string RfcReceptor { get; set; }
            public string Destinoxml { get; set; }
            public string NombreXml { get; set; }
            public int CvePacTimbrado { get; set; }

            public string UsuarioPac { get; set; }
            public string Contraseña { get; set; }
            public string NoCertificado { get; set; }
            public decimal Total { get; set; }

        }


        /*
         *   string QueryInsertDetalleRetenciones = "Insert Into FacturaRetencion(" +
                                "CveFactura, CveRetencion, Importe) Values(" + CveFactura + "," + ir.CveRetencion + "," + ir.Importe + ")";

         * */

        public ArrayList ArrDatosEmisor()
        {
            ArrayList list = new ArrayList();





            return list;

        }

        public DataTable Regimen(int CveRegimen)
        {
           
            string Query = "SELECT * FROM CatRegimenSat Where CveRegimen=" + CveRegimen;

            DataTable _dt = pb.SP_Busca_Reader_Table(Query);

            return _dt;

        }

        public int ValidarUIDD_Relacion(string RFCEmisor, string UUID, out string Resultado)
        {
            int Valida = 0;


            //En este ejemplo se muestra como recuperar un comprobante xml, previamente timbrado

            //Inicializamos el conector el parámetro indica el ambiente en el que se utilizará 
            //Fasle = Ambiente de pruebas
            //True = Ambiente de producción
            Conector conector = new Conector(false);

            //Establecemos las credenciales para el permiso de conexión
            //Ambiente de pruebas = mvpNUXmQfK8=
            //Ambiente de producción = Esta será asignado por el proveedor al salir a productivo
            conector.EstableceCredenciales("mvpNUXmQfK8=");

            //Rfc Emisor
            string rfcEmisor = RFCEmisor;

            //Folio Fiscal - UUID
            string folioFiscal = UUID;

            //Obtenemos el xml por medio del conector y guardamos resultado
            Profact.TimbraCFDI.ResultadoConsulta resultadoConsulta;

            resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal);

            //Verificamos el resultado
            if (resultadoConsulta.Exitoso)
            {
                //El comprobante fue timbrado exitosamente
                Resultado = resultadoConsulta.Descripcion;
                Valida = 1;
            }
            else
            {
                //No se pudo timbrar, mostramos respuesta
                Resultado= resultadoConsulta.Descripcion;
            }
            

            return Valida;
        }

        public void LlenarComboImpuesto(ComboBox box, string storeProcedure, int _parametro, string _DisplayMember, string _ValueMember)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("_CveTipoEntidad", _parametro.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_Reader(ListaParametro, "SP_CargarTipoImpuesto");

            box.DataSource = _dt;
            box.DisplayMember = _DisplayMember;
            box.ValueMember = _ValueMember;


        }

        public DataTable GetDatosFactura(int CveFactura)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));

            _dt.Clear();

            _dt = cm.SP_Busca_Reader(ListaParametro, "SP_GetDatosFactura");


            return _dt;
        }


        public int SaveFactura40Detalle(ArrayList ListaParametros, ArrayList ListaSerieCfdi,  int CveFactura, SqlConnection cn, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0;
            int CveDetalleFacturaConceptoImpuesto = 0;
            ArrayList ListParameters = new ArrayList();
            ArrayList ListaParametersSerial = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();

                    foreach (DetalleParametros item in ListaParametros)
            {

                ListParameters.Clear();
                
                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveConcepto", item.CveConcepto.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_Cantidad", item.Cantidad.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Unidad", item.StrClaveUnidadSat, "string"));
                ListParameters.Add(cm.addparametro("p_Descripcion", item.Descripcion, "string"));
                ListParameters.Add(cm.addparametro("p_Precio", item.PrecioUnitario.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Iva", item.TotalIva.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ChkIva", item.IntChkIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveIva", item.CveIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIvaRetenido", item.IntChkIvaRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenido", item.IntChkIsrRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenidoResico", item.IntChkIsrRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_IvaRetenido", item.DblIvaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IsrRetenido", item.DblIsrRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IsrRetenidoResico", item.DblIsrRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenido", item.PorcentajeISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenidoResico", item.PorcentajeISRRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ClaveUnidadSat", item.StrClaveUnidadSat, "string"));
                ListParameters.Add(cm.addparametro("p_ClaveProdServSat", item.ClaveProductoServicioSat, "string"));
                ListParameters.Add(cm.addparametro("p_NotaAdicional", item.Nota, "string"));
                ListParameters.Add(cm.addparametro("p_c_ObjetoImp", item.ObjetoImp, "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                ListParameters.Add(cm.addparametro("p_CveObjetoImpuesto", item.CveObjetoImpuesto.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_ChkSerie", item.ChkSerie.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_ChkDesgloce", item.ChkDesgloce.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkNotaAConcepto", item.ChkNotaAConcepto.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_PrecioOriginal", item.PrecioOriginal.ToString(), "decimal"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_InsertDetalleFactura", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFactura"].ToString());

                    foreach (DetalleNoSerie noSerie in ListaSerieCfdi)
                    {

                        if (item.sGuid == noSerie.sGuidPadre)
                        {

                            ListaParametersSerial.Clear();

                            DataTable _dtSerie = new DataTable();
                            
                            ListaParametersSerial.Add(cm.addparametro("p_CveDetalleFactura", CveDetalleFactura.ToString(), "int"));
                            ListaParametersSerial.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                            ListaParametersSerial.Add(cm.addparametro("p_CveConcepto", noSerie.CveConcepto.ToString(), "int"));
                            ListaParametersSerial.Add(cm.addparametro("p_NoSerie", noSerie.NoSerie, "string"));
                            ListaParametersSerial.Add(cm.addparametro("p_sGuidPadre", noSerie.sGuidPadre, "string"));
                            ListaParametersSerial.Add(cm.addparametro("p_sGuidHijo", noSerie.sGuidHijo, "string"));

                            _dtSerie = cm.SP_Busca_Reader(ListaParametersSerial, "SP_InsertDetalleNoSerie", cn, transaction);

                            foreach (DataRow rs in _dtSerie.Rows)
                            {
                               // CveDetalleFactura = int.Parse(rs["CveDetalleFactura"].ToString());


                            }

                        }
                    }

                    //cConceptos.v_ImpuestosConceptos v_Impuestos = new cConceptos.v_ImpuestosConceptos();
                    foreach (cConceptos.v_ImpuestosConceptos imp in item.ListConceptoImpuesto)
                    {
                        ListParameterImpuesto.Clear();

                         DataTable _dtImpuesto = new DataTable();


                        
                        ListParameterImpuesto.Add(cm.addparametro("p_CveDetalleFactura", CveDetalleFactura.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_CveConcepto", imp.CveConcepto.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_CveImpuesto",imp.CveImpuesto.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_Importe", imp.ValorImpuesto.ToString(), "decimal"));
                        ListParameterImpuesto.Add(cm.addparametro("p_Porcentaje", imp.Porcentaje.ToString(), "decimal"));
                        ListParameterImpuesto.Add(cm.addparametro("p_TasaCuota", imp.TasaCuota.ToString(), "decimal"));
                        ListParameterImpuesto.Add(cm.addparametro("p_TipoFactor", imp.TipoFactor.ToString(), "string"));
                        ListParameterImpuesto.Add(cm.addparametro("p_c_Impuesto", imp.c_Impuesto.ToString(), "string"));
                        ListParameterImpuesto.Add(cm.addparametro("p_Signo", imp.Signo.ToString(), "string"));
                        ListParameterImpuesto.Add(cm.addparametro("p_sGuidHijo", imp.sGuidHijo, "string"));

                        _dtImpuesto = cm.SP_Busca_Reader(ListParameterImpuesto, "SP_InsertDetalleFacturaConceptoImpuesto", cn, transaction);

                        foreach (DataRow ri in _dtImpuesto.Rows)
                        {
                            CveDetalleFacturaConceptoImpuesto = int.Parse(ri["CveDetalleConceptoImpuesto"].ToString());


                        }
                    }

                }
            }
            return CveDetalleFactura;
        }
        public int SaveFactura40Detalle_Previa(ArrayList ListaParametros, ArrayList ListaSerieCfdi, int CveFactura, SqlConnection cn, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0;
            int CveDetalleFacturaConceptoImpuesto = 0;
            ArrayList ListParameters = new ArrayList();
            ArrayList ListaParametersSerial = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();

            foreach (DetalleParametros item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveConcepto", item.CveConcepto.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_Cantidad", item.Cantidad.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Unidad", item.StrClaveUnidadSat, "string"));
                ListParameters.Add(cm.addparametro("p_Descripcion", item.Descripcion, "string"));
                ListParameters.Add(cm.addparametro("p_Precio", item.PrecioUnitario.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Iva", item.TotalIva.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ChkIva", item.IntChkIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveIva", item.CveIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIvaRetenido", item.IntChkIvaRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenido", item.IntChkIsrRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenidoResico", item.IntChkIsrRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_IvaRetenido", item.DblIvaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IsrRetenido", item.DblIsrRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IsrRetenidoResico", item.DblIsrRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenido", item.PorcentajeISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenidoResico", item.PorcentajeISRRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ClaveUnidadSat", item.StrClaveUnidadSat, "string"));
                ListParameters.Add(cm.addparametro("p_ClaveProdServSat", item.ClaveProductoServicioSat, "string"));
                ListParameters.Add(cm.addparametro("p_NotaAdicional", item.Nota, "string"));
                ListParameters.Add(cm.addparametro("p_c_ObjetoImp", item.ObjetoImp, "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                ListParameters.Add(cm.addparametro("p_CveObjetoImpuesto", item.CveObjetoImpuesto.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_ChkSerie", item.ChkSerie.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_ChkDesgloce", item.ChkDesgloce.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkNotaAConcepto", item.ChkNotaAConcepto.ToString(), "int"));


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_InsertDetalleFactura_temp", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFactura"].ToString());

                    foreach (DetalleNoSerie noSerie in ListaSerieCfdi)
                    {

                        if (item.sGuid == noSerie.sGuidPadre)
                        {

                            ListaParametersSerial.Clear();

                            DataTable _dtSerie = new DataTable();

                            ListaParametersSerial.Add(cm.addparametro("p_CveDetalleFactura", CveDetalleFactura.ToString(), "int"));
                            ListaParametersSerial.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                            ListaParametersSerial.Add(cm.addparametro("p_CveConcepto", noSerie.CveConcepto.ToString(), "int"));
                            ListaParametersSerial.Add(cm.addparametro("p_NoSerie", noSerie.NoSerie, "string"));
                            ListaParametersSerial.Add(cm.addparametro("p_sGuidPadre", noSerie.sGuidPadre, "string"));
                            ListaParametersSerial.Add(cm.addparametro("p_sGuidHijo", noSerie.sGuidHijo, "string"));

                            _dtSerie = cm.SP_Busca_Reader(ListaParametersSerial, "SP_InsertDetalleNoSerie_temp", cn, transaction);

                            foreach (DataRow rs in _dtSerie.Rows)
                            {
                                //CveDetalleFactura = int.Parse(rs["CveDetalleFactura"].ToString());


                            }

                        }
                    }

                    //cConceptos.v_ImpuestosConceptos v_Impuestos = new cConceptos.v_ImpuestosConceptos();
                    foreach (cConceptos.v_ImpuestosConceptos imp in item.ListConceptoImpuesto)
                    {
                        ListParameterImpuesto.Clear();

                        DataTable _dtImpuesto = new DataTable();



                        ListParameterImpuesto.Add(cm.addparametro("p_CveDetalleFactura", CveDetalleFactura.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_CveConcepto", imp.CveConcepto.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_CveImpuesto", imp.CveImpuesto.ToString(), "int"));
                        ListParameterImpuesto.Add(cm.addparametro("p_Importe", imp.ValorImpuesto.ToString(), "decimal"));
                        ListParameterImpuesto.Add(cm.addparametro("p_Porcentaje", imp.Porcentaje.ToString(), "decimal"));
                        ListParameterImpuesto.Add(cm.addparametro("p_TasaCuota", imp.TasaCuota.ToString(), "decimal"));
                        ListParameterImpuesto.Add(cm.addparametro("p_TipoFactor", imp.TipoFactor.ToString(), "string"));
                        ListParameterImpuesto.Add(cm.addparametro("p_c_Impuesto", imp.c_Impuesto.ToString(), "string"));
                        ListParameterImpuesto.Add(cm.addparametro("p_Signo", imp.Signo.ToString(), "string"));
                        ListParameterImpuesto.Add(cm.addparametro("p_sGuidHijo", imp.sGuidHijo, "string"));

                        _dtImpuesto = cm.SP_Busca_Reader(ListParameterImpuesto, "SP_InsertDetalleFacturaConceptoImpuesto_temp", cn, transaction);

                        foreach (DataRow ri in _dtImpuesto.Rows)
                        {
                            CveDetalleFacturaConceptoImpuesto = int.Parse(ri["CveDetalleConceptoImpuesto"].ToString());


                        }
                    }

                }
            }
            return CveDetalleFactura;
        }
        public int UpdateNotaAdicionalDetalleFactura(ArrayList ListaParametros)
        {
            int CveDetalleFactura = 0;
            int CveDetalleFacturaConceptoImpuesto = 0;
            ArrayList ListParameters = new ArrayList();

            foreach (DetalleParametros item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("_CveDetalleFactura", item.CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("_NotaAdicional", item.Nota, "string"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_UpdateDetalleConceptoNotaAdicionalFactura");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFactura"].ToString());

                }
            }
            return CveDetalleFactura;
        }

        public ArrayList SaveFactura40CS(ArrayList ListaFactura, ArrayList ListaSerieCfdi,  ArrayList _ListaFolioFactura, ArrayList ListaFacturaDetalle, ArrayList ListaRetencionesDelegado, ArrayList ListaDetalleCfdiRelacionado, string strconexion, int Timbrado=1)
        {
            bool _result = false;
            ArrayList _ListaResult = new ArrayList();

            using (SqlConnection connection = new SqlConnection(strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted,"SampleTransaction");

                
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "FACTURA";

                    int CveDocumento = help.Result(connection, transaction);

                    foreach (Parametros item in ListaFactura)
                    {
                        item.CveDocumento = CveDocumento;
                    }


                    int CveFactura = SaveFactura40(ListaFactura, command, connection, transaction);

                    if(CveFactura>0)
                    {
                        int CveFolio = SaveFactura40Detalle_Folios_Cfdi(_ListaFolioFactura, connection, transaction);


                        int CveDetalleFactura = SaveFactura40Detalle(ListaFacturaDetalle, ListaSerieCfdi ,  CveFactura, connection, transaction);

                        int CveRetencionFactura = SaveFactura40Detalle_Retenciones_Cfdi(ListaRetencionesDelegado, CveFactura,  connection, transaction);

                        int CveRelacionCfdi = SaveFactura40Detalle_DocRelacionado_Cfdi(ListaDetalleCfdiRelacionado, CveFactura,  connection, transaction);

                        foreach (Parametros CxC in ListaFactura)
                        {
                            if (CxC.CveMetodoPago == 1 && CxC.Timbrado==1)
                            {
                                SaveFacturaCxC_CS(CveFactura, ListaFactura, connection, command, transaction);
                            }
                        }

                        if(Timbrado==1)
                        {



                            //ArrayList _ListaParaTimbrar =  GenerarCFDI40_USLib(CveFactura, ListaFactura, ListaFacturaDetalle, ListaDetalleCfdiRelacionado, ListaRetencionesDelegado, command);
                            ArrayList _ListaParaTimbrar = GenerarCFDI40_USLib(CveFactura, ListaFactura, ListaFacturaDetalle, ListaDetalleCfdiRelacionado, ListaRetencionesDelegado, command);
                            bool Timbro = false;
                            foreach (DatosParaTimbrar pt in _ListaParaTimbrar)
                            {
                                Timbro = TimbrarFactura40(pt.CveFactura, pt.CveEmisor, pt.CveReceptor,
                                    pt.cvetipofactura, pt.RfcEmisor, pt.RfcReceptor, pt.Destinoxml,
                                    pt.NombreXml, pt.CvePacTimbrado, pt.UsuarioPac, pt.Contraseña,
                                    pt.NoCertificado, pt.Total, command);
                            }


                            if (Timbro)
                            {
                                transaction.Commit();
                                _result = true;

                                Models.Errors errors = new Models.Errors
                                {
                                    MensajeError = CveFactura.ToString(),
                                    Result = "Los datos se han guardado con exito",
                                    Status = true,
                                    List = _ListaParaTimbrar
                                };

                                _ListaResult.Add(errors);

                            }
                        }
                        else
                        {

                                transaction.Commit();
                                _result = true;

                                Models.Errors errors = new Models.Errors
                                {
                                    MensajeError = CveFactura.ToString(),
                                    Result = "Los datos se han guardado con exito",
                                    Status = true,
                                    //List = _ListaParaTimbrar
                                };

                                _ListaResult.Add(errors);

                        }

                    }
                    else
                    {
                        Models.Errors errors = new Models.Errors
                        {
                            MensajeError = "No se guardaron los datos",
                            Result = "Los datos de han guardado con exito",
                            Status = false
                        };
                        _ListaResult.Add(errors);
                    }

                }
                catch (Exception er)
                {
                  
                    Models.Errors errors = new Models.Errors
                    {
                        MensajeError =er.Message + " ," + er.Source + ", " + er.Data,
                        Result = "No se pudo guardar los datos",
                        Status = false
                    };
                    _ListaResult.Add(errors);
                    transaction.Rollback();
                    
                }

            }


            return _ListaResult;
        }

        public ArrayList SaveFactura40CS_Previa(ArrayList ListaFactura, ArrayList ListaSerieCfdi, ArrayList _ListaFolioFactura, ArrayList ListaFacturaDetalle, ArrayList ListaRetencionesDelegado, ArrayList ListaDetalleCfdiRelacionado, string strconexion, int Timbrado = 1)
        {
            bool _result = false;
            ArrayList _ListaResult = new ArrayList();

            using (SqlConnection connection = new SqlConnection(strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted, "SampleTransaction");


                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "FACTURA";

                    int CveDocumento = 1;// help.Result(connection, transaction);

                    foreach (Parametros item in ListaFactura)
                    {
                        item.CveDocumento = CveDocumento;
                    }


                    int CveFactura = SaveFactura40_Previa(ListaFactura, command, connection, transaction);

                    if (CveFactura > 0)
                    {
                        int CveFolio = 1;// SaveFactura40Detalle_Folios_Cfdi(_ListaFolioFactura, connection, transaction);


                        int CveDetalleFactura = SaveFactura40Detalle_Previa(ListaFacturaDetalle, ListaSerieCfdi, CveFactura, connection, transaction);

                        int CveRetencionFactura = SaveFactura40Detalle_Retenciones_Cfdi_Previa(ListaRetencionesDelegado, CveFactura, connection, transaction);

                        int CveRelacionCfdi = SaveFactura40Detalle_DocRelacionado_Cfdi_Previa(ListaDetalleCfdiRelacionado, CveFactura, connection, transaction);

                        /*
                        foreach (Parametros CxC in ListaFactura)
                        {
                            if (CxC.CveMetodoPago == 1 && CxC.Timbrado == 1)
                            {
                                SaveFacturaCxC_CS(CveFactura, ListaFactura, connection, command, transaction);
                            }
                        }
                        */

                        if (Timbrado == 1)
                        {



                            //ArrayList _ListaParaTimbrar =  GenerarCFDI40_USLib(CveFactura, ListaFactura, ListaFacturaDetalle, ListaDetalleCfdiRelacionado, ListaRetencionesDelegado, command);
                            ArrayList _ListaParaTimbrar = GenerarCFDI40_USLib(CveFactura, ListaFactura, ListaFacturaDetalle, ListaDetalleCfdiRelacionado, ListaRetencionesDelegado, command);
                            bool Timbro = true;
                            
                            /*foreach (DatosParaTimbrar pt in _ListaParaTimbrar)
                            {
                                Timbro = TimbrarFactura40(pt.CveFactura, pt.CveEmisor, pt.CveReceptor,
                                    pt.cvetipofactura, pt.RfcEmisor, pt.RfcReceptor, pt.Destinoxml,
                                    pt.NombreXml, pt.CvePacTimbrado, pt.UsuarioPac, pt.Contraseña,
                                    pt.NoCertificado, pt.Total, command);
                            }
                            */

                            if (Timbro)
                            {
                                transaction.Commit();
                                _result = true;

                                Models.Errors errors = new Models.Errors
                                {
                                    MensajeError = CveFactura.ToString(),
                                    Result = "Los datos se han guardado con exito",
                                    Status = true,
                                    List = _ListaParaTimbrar
                                };

                                _ListaResult.Add(errors);

                            }
                        }
                        else
                        {

                            transaction.Commit();
                            _result = true;

                            Models.Errors errors = new Models.Errors
                            {
                                MensajeError = CveFactura.ToString(),
                                Result = "Los datos se han guardado con exito",
                                Status = true,
                                //List = _ListaParaTimbrar
                            };

                            _ListaResult.Add(errors);

                        }

                    }
                    else
                    {
                        Models.Errors errors = new Models.Errors
                        {
                            MensajeError = "No se guardaron los datos",
                            Result = "Los datos de han guardado con exito",
                            Status = false
                        };
                        _ListaResult.Add(errors);
                    }

                }
                catch (Exception er)
                {

                    Models.Errors errors = new Models.Errors
                    {
                        MensajeError = er.Message + " ," + er.Source + ", " + er.Data,
                        Result = "No se pudo guardar los datos",
                        Status = false
                    };
                    _ListaResult.Add(errors);
                    transaction.Rollback();

                }

            }


            return _ListaResult;
        }

        public int SaveFactura40(ArrayList ListaParametros, SqlCommand command, SqlConnection cn, SqlTransaction transaction)
        {
            int CveFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            try
            {

                foreach (Parametros item in ListaParametros)
                {
                    ListParameters.Add(cm.addparametro("p_OpcionValidar", item.OpcionValidar.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveFactura", item.CveFactura.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveReceptor", item.CveReceptor.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveDocumento", item.CveDocumento.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_FolioInt", item.FolioInt, "int"));
                    ListParameters.Add(cm.addparametro("p_Serie", item.Serie, "string"));
                    ListParameters.Add(cm.addparametro("p_FechaEmision", item.FechaEmision, "string"));

                    //ListParameters.Add(cm.addparametro("p_FechaCertificacion", item.FechaCerficacion, "string"));
                    ListParameters.Add(cm.addparametro("p_CveEstatus", item.CveEstatus.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveTipoFactura", item.CveTipoFactura.ToString(), "int"));

                    ListParameters.Add(cm.addparametro("p_CveUser", item.CveUser.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveEmisor", item.CveEmisor.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveMetodoPago", item.CveMetodoPago.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveFormaPago", item.CveFormaPago.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_Condiciones", item.CondicionesPago, "string"));
                    ListParameters.Add(cm.addparametro("p_Observacion", item.Observacion, "string"));
                    ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_IvaP", item.IvaP.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_IvaTotal", item.IvaTotal.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_TotalLetra", item.TotalLetra, "string"));

                    ListParameters.Add(cm.addparametro("p_ISRRetenido", item.ISRRetenido.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_ISRRetenidoResico", item.ISRRetenidoResico.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_IvaRetenido", item.IVaRetenido.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_NumCuentaPago", item.NumCuenta, "string"));
                    ListParameters.Add(cm.addparametro("p_ImpLocalNombre", item.ImpLocalNombre, "string"));
                    ListParameters.Add(cm.addparametro("p_ImpLocalPorcentaje", item.ImpLocalPorcentaje.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_ImpLocalImporte", item.ImpLocalImporte.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_CveUsoCfdi", item.CveUsoCfdi.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CPExpedido", item.StrCPExpedido, "int"));
                    ListParameters.Add(cm.addparametro("p_LugarExpedicion", item.LugarExpedicion, "string"));
                    ListParameters.Add(cm.addparametro("p_CuentaPredial", item.CuentaPredial, "string"));
                    ListParameters.Add(cm.addparametro("p_sGuid", item.strGuid, "string"));
                    ListParameters.Add(cm.addparametro("p_Moneda", item.MonedaSat, "string"));
                    ListParameters.Add(cm.addparametro("p_TipoCambio", item.TipoCambioSat, "decimal"));
                    ListParameters.Add(cm.addparametro("p_c_Exportacion", item.Exportacion, "string"));
                    ListParameters.Add(cm.addparametro("p_c_ObjetoImp", item.c_Objetoimp, "string"));
                    ListParameters.Add(cm.addparametro("p_CveExportacion", item.CveExportacion.ToString(), "string"));
                    ListParameters.Add(cm.addparametro("p_CveObjetoImp", item.CveObjetoImp.ToString(), "string"));
                    /*
                    ListParameters.Add(cm.addparametro("p_CadenaOriginal", item.CadenaOriginal, "string"));
                    ListParameters.Add(cm.addparametro("p_UUID", item.UUID, "string"));
                    ListParameters.Add(cm.addparametro("p_SCDCFDI", item.SCDCFDI, "string"));
                    ListParameters.Add(cm.addparametro("p_SCDSAT", item.SCDSAT, "string"));
                    ListParameters.Add(cm.addparametro("p_CertificadoEmisor", item.CertificadoEmisor, "string"));
                    ListParameters.Add(cm.addparametro("p_CertificadoSAT", item.CertificadoSat, "string"));

                    ListParameters.Add(cm.addparametro("p_Timbrado", item.Timbrado.ToString(), "int"));
                   */

                    //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                    _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveFacturas", cn, transaction);

                    foreach (DataRow rw in _dt.Rows)
                    {
                        CveFactura = int.Parse(rw["CveFactura"].ToString());
                    }

                }

            }
            catch (Exception er)
            {

                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);

            }

            return CveFactura;
        }
        public int SaveFactura40_Previa(ArrayList ListaParametros, SqlCommand command, SqlConnection cn, SqlTransaction transaction)
        {
            int CveFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            try
            {

                foreach (Parametros item in ListaParametros)
                {
                    ListParameters.Add(cm.addparametro("p_OpcionValidar", item.OpcionValidar.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveFactura", item.CveFactura.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveReceptor", item.CveReceptor.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveDocumento", item.CveDocumento.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_FolioInt", item.FolioInt, "int"));
                    ListParameters.Add(cm.addparametro("p_Serie", item.Serie, "string"));
                    ListParameters.Add(cm.addparametro("p_FechaEmision", item.FechaEmision, "string"));

                    //ListParameters.Add(cm.addparametro("p_FechaCertificacion", item.FechaCerficacion, "string"));
                    ListParameters.Add(cm.addparametro("p_CveEstatus", item.CveEstatus.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveTipoFactura", item.CveTipoFactura.ToString(), "int"));

                    ListParameters.Add(cm.addparametro("p_CveUser", item.CveUser.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveEmisor", item.CveEmisor.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveMetodoPago", item.CveMetodoPago.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveFormaPago", item.CveFormaPago.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_Condiciones", item.CondicionesPago, "string"));
                    ListParameters.Add(cm.addparametro("p_Observacion", item.Observacion, "string"));
                    ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_IvaP", item.IvaP.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_IvaTotal", item.IvaTotal.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_TotalLetra", item.TotalLetra, "string"));

                    ListParameters.Add(cm.addparametro("p_ISRRetenido", item.ISRRetenido.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_ISRRetenidoResico", item.ISRRetenidoResico.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_IvaRetenido", item.IVaRetenido.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_NumCuentaPago", item.NumCuenta, "string"));
                    ListParameters.Add(cm.addparametro("p_ImpLocalNombre", item.ImpLocalNombre, "string"));
                    ListParameters.Add(cm.addparametro("p_ImpLocalPorcentaje", item.ImpLocalPorcentaje.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_ImpLocalImporte", item.ImpLocalImporte.ToString(), "decimal"));
                    ListParameters.Add(cm.addparametro("p_CveUsoCfdi", item.CveUsoCfdi.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CPExpedido", item.StrCPExpedido, "int"));
                    ListParameters.Add(cm.addparametro("p_LugarExpedicion", item.LugarExpedicion, "string"));
                    ListParameters.Add(cm.addparametro("p_CuentaPredial", item.CuentaPredial, "string"));
                    ListParameters.Add(cm.addparametro("p_sGuid", item.strGuid, "string"));
                    ListParameters.Add(cm.addparametro("p_Moneda", item.MonedaSat, "string"));
                    ListParameters.Add(cm.addparametro("p_TipoCambio", item.TipoCambioSat, "decimal"));
                    ListParameters.Add(cm.addparametro("p_c_Exportacion", item.Exportacion, "string"));
                    ListParameters.Add(cm.addparametro("p_c_ObjetoImp", item.c_Objetoimp, "string"));
                    ListParameters.Add(cm.addparametro("p_CveExportacion", item.CveExportacion.ToString(), "string"));
                    ListParameters.Add(cm.addparametro("p_CveObjetoImp", item.CveObjetoImp.ToString(), "string"));
                    /*
                    ListParameters.Add(cm.addparametro("p_CadenaOriginal", item.CadenaOriginal, "string"));
                    ListParameters.Add(cm.addparametro("p_UUID", item.UUID, "string"));
                    ListParameters.Add(cm.addparametro("p_SCDCFDI", item.SCDCFDI, "string"));
                    ListParameters.Add(cm.addparametro("p_SCDSAT", item.SCDSAT, "string"));
                    ListParameters.Add(cm.addparametro("p_CertificadoEmisor", item.CertificadoEmisor, "string"));
                    ListParameters.Add(cm.addparametro("p_CertificadoSAT", item.CertificadoSat, "string"));

                    ListParameters.Add(cm.addparametro("p_Timbrado", item.Timbrado.ToString(), "int"));
                   */

                    //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                    _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveFacturas_temp", cn, transaction);

                    foreach (DataRow rw in _dt.Rows)
                    {
                        CveFactura = int.Parse(rw["CveFactura"].ToString());
                    }

                }

            }
            catch (Exception er)
            {

                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);

            }

            return CveFactura;
        }

        

        public int SaveFactura40Detalle_DocRelacionado_Cfdi(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveCfdiRelacionado = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            try
            {

                foreach (CfdiRelacionado item in ListaParametros)
                {

                    ListParameters.Clear();

                    
                    ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveFacturaRelacion", item.intCveFacturaRelacion.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveTipoRelacion", item.IntCveTipoRelacion.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_UUID", item.StrUUID, "string"));
                    ListParameters.Add(cm.addparametro("p_DescripcionTipoRelacion", item.StrDescripcionTipoRelacion, "string"));
                    ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                    ListParameters.Add(cm.addparametro("p_ChkManual", item.ChkManual.ToString(), "int"));


                    //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                    _dt = cm.SP_Busca_Reader(ListParameters, "SP_CfdiRelacionado",connection,transaction);

                    foreach (DataRow rw in _dt.Rows)
                    {
                        CveCfdiRelacionado = int.Parse(rw["CveCfdiRelacionado"].ToString());
                    }

                }

            }
            catch (Exception er)
            {

                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);
            }

            return CveCfdiRelacionado;
        }
        public int SaveFactura40Detalle_DocRelacionado_Cfdi_Previa(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveCfdiRelacionado = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            try
            {

                foreach (CfdiRelacionado item in ListaParametros)
                {

                    ListParameters.Clear();


                    ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveFacturaRelacion", item.intCveFacturaRelacion.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_CveTipoRelacion", item.IntCveTipoRelacion.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("p_UUID", item.StrUUID, "string"));
                    ListParameters.Add(cm.addparametro("p_DescripcionTipoRelacion", item.StrDescripcionTipoRelacion, "string"));
                    ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                    ListParameters.Add(cm.addparametro("p_ChkManual", item.ChkManual.ToString(), "int"));

                    //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                    _dt = cm.SP_Busca_Reader(ListParameters, "SP_CfdiRelacionado_temp", connection, transaction);

                    foreach (DataRow rw in _dt.Rows)
                    {
                        CveCfdiRelacionado = int.Parse(rw["CveCfdiRelacionado"].ToString());
                    }

                }

            }
            catch (Exception er)
            {

                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);
            }

            return CveCfdiRelacionado;
        }
        public int SaveFactura40Detalle_Folios_Cfdi(ArrayList ListaParametros, SqlConnection cn, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            try
            {
                foreach (Parametros item in ListaParametros)
                {

                    ListParameters.Clear();

                    ListParameters.Add(cm.addparametro("CveTipoFactura", item.CveTipoFactura.ToString(), "int"));
                    ListParameters.Add(cm.addparametro("FolioInt", item.FolioInt.ToString(), "int"));
                    _dt = cm.SP_Busca_Reader(ListParameters, "SP_UpdateFolioFacturas", cn, transaction);

                    foreach (DataRow rw in _dt.Rows)
                    {
                        CveDetalleFactura = int.Parse(rw["FolioInt"].ToString());
                    }

                }
            }
            catch (Exception er)
            {

                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);

            }
            return CveDetalleFactura;
        }
        public int SaveFactura40Detalle_Retenciones_Cfdi(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveDetalleFacturaConceptoImpuesto = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();

            try
            {

                foreach (cConceptos.v_ImpuestosConceptos imp in ListaParametros)
                {
                    ListParameterImpuesto.Clear();

                    DataTable _dtImpuesto = new DataTable();

                    
                    ListParameterImpuesto.Add(cm.addparametro("p_CveDetalleFactura", "0", "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveConcepto", imp.CveConcepto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveImpuesto", imp.CveImpuesto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Importe", imp.ValorImpuesto.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Porcentaje", imp.Porcentaje.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TasaCuota", imp.TasaCuota.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TipoFactor", imp.TipoFactor.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_c_Impuesto", imp.c_Impuesto.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Signo", imp.Signo.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_sGuidHijo", imp.sGuidHijo, "string"));

                    _dtImpuesto = cm.SP_Busca_Reader(ListParameterImpuesto, "SP_InsertDetalleFacturaConceptoImpuesto", connection, transaction);

                    foreach (DataRow ri in _dtImpuesto.Rows)
                    {
                        CveDetalleFacturaConceptoImpuesto = int.Parse(ri["CveDetalleConceptoImpuesto"].ToString());


                    }
                }

                
            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);
                
            }

           

            return CveDetalleFacturaConceptoImpuesto;
        }

        public int SaveFactura40Detalle_Retenciones_Cfdi_Previa(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveDetalleFacturaConceptoImpuesto = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();

            try
            {

                foreach (cConceptos.v_ImpuestosConceptos imp in ListaParametros)
                {
                    ListParameterImpuesto.Clear();

                    DataTable _dtImpuesto = new DataTable();


                    ListParameterImpuesto.Add(cm.addparametro("p_CveDetalleFactura", "0", "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveConcepto", imp.CveConcepto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveImpuesto", imp.CveImpuesto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Importe", imp.ValorImpuesto.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Porcentaje", imp.Porcentaje.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TasaCuota", imp.TasaCuota.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TipoFactor", imp.TipoFactor.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_c_Impuesto", imp.c_Impuesto.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Signo", imp.Signo.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_sGuidHijo", imp.sGuidHijo, "string"));

                    _dtImpuesto = cm.SP_Busca_Reader(ListParameterImpuesto, "SP_InsertDetalleFacturaConceptoImpuesto_temp", connection, transaction);

                    foreach (DataRow ri in _dtImpuesto.Rows)
                    {
                        CveDetalleFacturaConceptoImpuesto = int.Parse(ri["CveDetalleConceptoImpuesto"].ToString());


                    }
                }


            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er.Message + ", No. " + er.Data);

            }



            return CveDetalleFacturaConceptoImpuesto;
        }


        public DataTable GetAdicionalesFactura(int CveMoneda, int CveEmisor,  int CveFormaPago, int CveTipoFactura,
            int CveMetodoPago,  int CveUso, int CveReceptor)
        {
            DataTable _result = new DataTable();

            ArrayList ListParameters = new ArrayList();

            ListParameters.Add(cm.addparametro("CveMoneda", CveMoneda.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveEmisor", CveEmisor.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveFormaPago", CveFormaPago.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveTipoFactura", CveTipoFactura.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveMetodoPago", CveMetodoPago.ToString(), "int"));
            //ListParameters.Add(cm.addparametro("CveRegimen", CveRegimen.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveUso", CveUso.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveReceptor", CveReceptor.ToString(), "int"));

            _result = cm.SP_Busca_Reader(ListParameters, "SP_AdicionalesFactura");

            return _result;
        }

        public DataTable GetAdicionalesFactura(int _CveFactura)
        {
            DataTable _result = new DataTable();

            ArrayList ListParameters = new ArrayList();

            ListParameters.Add(cm.addparametro("CveFactura", _CveFactura.ToString(), "int"));
          

            _result = cm.SP_Busca_Reader(ListParameters, "SP_GetDatosAdicionalesFactura_Timbrado");

            return _result;
        }


        public DataTable GetAdicionalesFactura_Pago(int CveMoneda, int CveEmisor, int CveFormaPago,
                   int CveReceptor, int CveTipoFactura)
        {
            DataTable _result = new DataTable();

            ArrayList ListParameters = new ArrayList();

            ListParameters.Add(cm.addparametro("CveMoneda", CveMoneda.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveEmisor", CveEmisor.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveFormaPago", CveFormaPago.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveTipoFactura", CveTipoFactura.ToString(), "int"));
            //ListParameters.Add(cm.addparametro("CveMetodoPago", CveMetodoPago.ToString(), "int"));
            //ListParameters.Add(cm.addparametro("CveRegimen", CveRegimen.ToString(), "int"));
            //ListParameters.Add(cm.addparametro("CveUso", CveUso.ToString(), "int"));
            ListParameters.Add(cm.addparametro("CveReceptor", CveReceptor.ToString(), "int"));

            _result = cm.SP_Busca_Reader(ListParameters, "SP_AdicionalesFacturaPago");

            return _result;
        }

       // Metodos para Pagos 2.0
        public DataTable GetAdicionalesFacturaPago(int CveFactura)
        {
            DataTable _result = new DataTable();

            ArrayList ListParameters = new ArrayList();

            ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));

            _result = cm.SP_Busca_Reader(ListParameters, "SP_GetDatosAdicionalesFactura");

            return _result;
        }

        public DataTable GetDoctosRelacianados_Consulta(int CveFactura)
        {
            DataTable _result = new DataTable();

            ArrayList ListParameters = new ArrayList();

            ListParameters.Add(cm.addparametro("_CveFactura", CveFactura.ToString(), "int"));

            _result = cm.SP_Busca_Reader(ListParameters, "SP_DoctosRelacianados_Consulta");

            return _result;
        }


        public int SaveFactura40Detalle(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;
            int CveDetalleFacturaConceptoImpuesto = 0;
            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();

            foreach (DetalleParametros item in ListaParametros)
            {

                ListParameters.Clear();
                ListParameters.Add(cm.addparametro("p_CveConcepto", item.CveConcepto.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_Cantidad", item.Cantidad.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Unidad", item.UnidadMedida, "string"));
                ListParameters.Add(cm.addparametro("p_Descripcion", item.Descripcion, "string"));
                ListParameters.Add(cm.addparametro("p_Precio", item.PrecioUnitario.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Iva", item.TotalIva.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ChkIva", item.IntChkIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveIva", item.CveIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIvaRetenido", item.IntChkIvaRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenido", item.IntChkIsrRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenidoResico", item.IntChkIsrRetenidoResico.ToString(), "int"));

                ListParameters.Add(cm.addparametro("p_IsrRetenidoResico", item.DblIsrRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenido", item.PorcentajeISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenidoResico", item.PorcentajeISRRetenidoResico.ToString(), "decimal"));

                ListParameters.Add(cm.addparametro("p_IvaRetenido", item.DblIvaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IsrRetenido", item.DblIsrRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ClaveUnidadSat", item.UnidadMedida, "string"));
                ListParameters.Add(cm.addparametro("p_ClaveProdServSat", item.ClaveProductoServicioSat, "string"));
                ListParameters.Add(cm.addparametro("p_NotaAdicional", item.Nota, "string"));
                ListParameters.Add(cm.addparametro("p_c_ObjetoImp", item.ObjetoImp, "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));


                /*
               * 
               * */

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_InsertDetalleFactura");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFactura"].ToString());
                }

            }

            return CveDetalleFactura;
        }
        public int SaveFactura40Detalle(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0;
            int CveDetalleFacturaConceptoImpuesto = 0;
            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();

            foreach (DetalleParametros item in ListaParametros)
            {

                ListParameters.Clear();
                ListParameters.Add(cm.addparametro("p_CveConcepto", item.CveConcepto.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_Cantidad", item.Cantidad.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Unidad", item.UnidadMedida, "string"));
                ListParameters.Add(cm.addparametro("p_Descripcion", item.Descripcion, "string"));
                ListParameters.Add(cm.addparametro("p_Precio", item.PrecioUnitario.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Iva", item.TotalIva.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ChkIva", item.IntChkIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveIva", item.CveIva.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIvaRetenido", item.IntChkIvaRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenido", item.IntChkIsrRetenido.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkIsrRetenidoResico", item.IntChkIsrRetenidoResico.ToString(), "int"));

                ListParameters.Add(cm.addparametro("p_IsrRetenidoResico", item.DblIsrRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenido", item.PorcentajeISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_PorcentajeISRRetenidoResico", item.PorcentajeISRRetenidoResico.ToString(), "decimal"));

                ListParameters.Add(cm.addparametro("p_IvaRetenido", item.DblIvaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IsrRetenido", item.DblIsrRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ClaveUnidadSat", item.UnidadMedida, "string"));
                ListParameters.Add(cm.addparametro("p_ClaveProdServSat", item.ClaveProductoServicioSat, "string"));
                ListParameters.Add(cm.addparametro("p_NotaAdicional", item.Nota, "string"));
                ListParameters.Add(cm.addparametro("p_c_ObjetoImp", item.ObjetoImp, "string"));
                ListParameters.Add(cm.addparametro("p_CveObjetoImpuesto", item.CveObjetoImpuesto.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                ListParameters.Add(cm.addparametro("p_ChkSerie", item.ChkSerie.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkDesgloce", item.ChkDesgloce.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_ChkNotaAConcepto", item.ChkNotaAConcepto.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_PrecioOriginal", item.PrecioOriginal.ToString(), "decimal"));


                /*
               * 
               * */

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_InsertDetalleFactura", connection,transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFactura"].ToString());
                }

            }

            return CveDetalleFactura;
        }

        public int SaveFactura40(ArrayList ListaParametros)
        {
            int CveFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {
                
                ListParameters.Add(cm.addparametro("p_CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveDocumento", item.CveDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_FolioInt", item.FolioInt, "int"));
                ListParameters.Add(cm.addparametro("p_Serie", item.Serie, "string"));
                ListParameters.Add(cm.addparametro("p_FechaEmision", item.FechaEmision, "string"));

                //ListParameters.Add(cm.addparametro("p_FechaCertificacion", item.FechaCerficacion, "string"));
                ListParameters.Add(cm.addparametro("p_CveEstatus", item.CveEstatus.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveTipoFactura", item.CveTipoFactura.ToString(), "int"));

                ListParameters.Add(cm.addparametro("p_CveUser", item.CveUser.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveEmisor", item.CveEmisor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveMetodoPago", item.CveMetodoPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFormaPago", item.CveFormaPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_Condiciones", item.CondicionesPago, "string"));
                ListParameters.Add(cm.addparametro("p_Observacion", item.Observacion, "string"));
                ListParameters.Add(cm.addparametro("p_SubTotal", item.SubTotal.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Descuento", item.Descuento.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IvaP", item.IvaP.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IvaTotal", item.IvaTotal.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Total", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_TotalLetra", item.ImporteLetras, "string"));

                ListParameters.Add(cm.addparametro("p_ISRRetenido", item.ISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ISRRetenidoResico", item.ISRRetenidoResico.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_IvaRetenido", item.IVaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_NumCuentaPago", item.NumCuenta, "string"));
                ListParameters.Add(cm.addparametro("p_ImpLocalNombre", item.ImpLocalNombre, "string"));
                ListParameters.Add(cm.addparametro("p_ImpLocalPorcentaje", item.ImpLocalPorcentaje.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_ImpLocalImporte", item.ImpLocalImporte.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_CveUsoCfdi", item.CveUsoCfdi.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CPExpedido", item.StrCPExpedido, "int"));
                ListParameters.Add(cm.addparametro("p_LugarExpedicion", item.LugarExpedicion, "string"));
                ListParameters.Add(cm.addparametro("p_CuentaPredial", item.CuentaPredial, "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.strGuid, "string"));
                ListParameters.Add(cm.addparametro("p_Moneda", item.MonedaSat, "string"));
                ListParameters.Add(cm.addparametro("p_TipoCambio", item.TipoCambioSat, "decimal"));
                ListParameters.Add(cm.addparametro("p_c_Exportacion", item.Exportacion, "string"));




                //ListParameters.Add(cm.addparametro("p_UsoCfdi", item.CveUsoCfdi.ToString(), "int"));

                ListParameters.Add(cm.addparametro("p_CadenaOriginal", item.CadenaOriginal, "string"));
                ListParameters.Add(cm.addparametro("p_UUID", item.UUID, "string"));
                ListParameters.Add(cm.addparametro("p_SCDCFDI", item.SCDCFDI, "string"));
                ListParameters.Add(cm.addparametro("p_SCDSAT", item.SCDSAT, "string"));
                ListParameters.Add(cm.addparametro("p_CertificadoEmisor", item.CertificadoEmisor, "string"));
                ListParameters.Add(cm.addparametro("p_CertificadoSAT", item.CertificadoSat, "string"));

                ListParameters.Add(cm.addparametro("p_Timbrado", item.Timbrado.ToString(), "int"));
                
                //ListParameters.Add(cm.addparametro("p_sGuid", item.strGuid, "string"));
                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveFacturasPagos");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFactura = int.Parse(rw["CveFactura"].ToString());
                }

            }




            return CveFactura;
        }


        public bool GenerarCFDI40(int CveFactura, ArrayList _ListaFactura, ArrayList _ListaDetalleFactura, ArrayList _ListaRelacionCfdi=null, ArrayList _ListaDetalleRetencion=null )
        {
            bool _result = false;
            if (_ListaFactura.Count > 0)
            {
                foreach (Parametros item in _ListaFactura)
                {
                    int CveEstatusFactura = item.CveEstatus;

                    if (CveEstatusFactura == 1)
                    {
                        DataTable _dtComprobante = new DataTable();

                        int result=1;
                        //result =  //MessageBox.Show("¿Está seguro que desea sellar la Factura?", "Sellar Factura", MessageBoxButtons.YesNo);
                        if (result == 1)
                        {

                            USLib.FachadaCfdv33 usLib = new USLib.FachadaCfdv33();

                            Form_DialogSuccess _DialogSuccess = new Form_DialogSuccess();
                            _DialogSuccess.Mensaje = "Espere...un momento";
                            _DialogSuccess.ShowDialog();

                            //int CveFactura = CveFactura; //int.Parse(dataGrid.CurrentRow.Cells["CveFactura"].Value.ToString());
                            int CveReceptor = item.CveReceptor;// int.Parse(dataGrid.CurrentRow.Cells["CveReceptor"].Value.ToString());
                            int CveEmisor = item.CveEmisor; // int.Parse(dataGrid.CurrentRow.Cells["CveEmisor"].Value.ToString());
                            string RfcEmisor = item.RfcEmisor;  //dataGrid.CurrentRow.Cells["RFCEmisor"].Value.ToString();
                            string RfcReceptor = item.RfcReceptor;// dataGrid.CurrentRow.Cells["RFC"].Value.ToString();
                            int cvetipofactura = item.CveTipoFactura;// int.Parse(dataGrid.CurrentRow.Cells["CveTipoFactura"].Value.ToString());
                            int CvePacTimbrado = 0;
                            string NombreCert = CveEmisor + "_" + RfcEmisor;
                            string CveClave = item.CveClave.ToString();// item GetStrFieldQuery("CveClave", "Select CveClave From Emisores Where CveEmisor=" + CveEmisor);
                            string url = ConfigurationManager.AppSettings["RutaCertificados"];

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

                            string Query = "SELECT * FROM Facturas F Left Join Emisores E on F.CveEmisor=E.CveEmisor  WHERE CveFactura=" + CveFactura;

                            int CveTipoFactura = 0;
                            string CuentaPredial = "";
                            DataTable _dtDatosFactura = new DataTable();
                            _dtDatosFactura =cm.SP_DataReaderQuery(Query);
                            decimal Total = 0;


                            foreach (DataRow rw_gral in _dtDatosFactura.Rows)
                            {
                                CveTipoFactura = int.Parse(rw_gral["CveTipoFactura"].ToString());
                                CuentaPredial = rw_gral["CuentaPredial"].ToString();

                                string TipoComprobante = cm.GetStrFieldQuery("TipoComprobante", "Select TipoComprobante From CatTipoFactura Where CveTipoFactura=" + cvetipofactura);
                                Total = decimal.Parse(rw_gral["Total"].ToString());
                                usLib.P01DatosGenerales(
                        serie: rw_gral["Serie"].ToString(), //Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres.
                        folio: rw_gral["FolioInt"].ToString(), //Atributo opcional para control interno del contribuyente que expresa el folio del comprobante, acepta una cadena de caracteres.
                        fecha: rw_gral["FechaEmision"].ToString(), //FechaEmision.Date.ToString("s"), //Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante.
                        formaPago: cm.GetStrFieldQuery("c_formapago", "Select c_formapago From CatFormaPagoSat Where CveFormaPago=" + rw_gral["CveFormaPago"].ToString()), //Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
                        condicionesDePago: rw_gral["CondicionesPago"].ToString(), //Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
                        subTotal: rw_gral["SubTotal"].ToString(), //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos.
                        descuento: rw_gral["Descuento"].ToString(), //Atributo condicional para representar el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe registrar cuando existan conceptos con descuento.
                        moneda: rw_gral["Moneda"].ToString(), //Atributo requerido para identificar la clave de la moneda utilizada para expresar los montos, cuando se usa moneda nacional se registra MXN. Conforme con la especificación ISO 4217.
                        tipoCambio: "1.00", //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion.
                        total: rw_gral["Total"].ToString(), //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
                        tipoDeComprobante: TipoComprobante, //Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.

                        metodoPago: cm.GetStrFieldQuery("c_metodopago", "Select c_metodopago From CatMetodoPagoSat Where CveMetodoPago=" + rw_gral["CveMetodoPago"].ToString()), //Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF.
                        lugarExpedicion: rw_gral["CP"].ToString(), //Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal).
                        confirmacion: ""
                                );
                            }



                            string QuerycfdiRelacionados = "Select * From DetalleTipoRelacionFactura Where CveFactura=" + CveFactura;

                            DataTable _dtcfdirelacionados = new DataTable();
                            _dtcfdirelacionados = cm.SP_DataReaderQuery(QuerycfdiRelacionados);

                            foreach (DataRow rw_relacionados in _dtcfdirelacionados.Rows)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                    relacion: cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                    uuid: rw_relacionados["UUID"].ToString()
                                    );
                            }

                            string QueryEmisor = "SELECT CveEmisor, Nombre, RFC, CveRegimen, CvePacTimbrado FROM Emisores WHERE CveEmisor=" + CveEmisor;

                            DataTable _dtEmisor = new DataTable();
                            _dtEmisor = cm.SP_DataReaderQuery(QueryEmisor);

                            foreach (DataRow rw_Emisor in _dtEmisor.Rows)
                            {
                                CvePacTimbrado = int.Parse(rw_Emisor["CvePacTimbrado"].ToString());
                                usLib.P03Emisor(
                                    rfc: rw_Emisor["RFC"].ToString(),
                                    nombre: rw_Emisor["Nombre"].ToString(),
                                    regimenFiscal: cm.GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + rw_Emisor["CveRegimen"].ToString())
                                    );
                            }

                            string QueryReceptor = "SELECT CveReceptor, Nombre, RFC, CveUso  FROM Receptores WHERE CveReceptor=" + CveReceptor;

                            DataTable _dtReceptor = new DataTable();
                            _dtReceptor = cm.SP_DataReaderQuery(QueryReceptor);

                            foreach (DataRow rw_Receptor in _dtReceptor.Rows)
                            {
                                usLib.P04Receptor(
                                    rfc: rw_Receptor["RFC"].ToString(),
                                    nombre: rw_Receptor["Nombre"].ToString(),
                                    residenciaFiscal: "",
                                    numRegIdTrib: "",
                                    usoCfdi: cm.GetStrFieldQuery("c_UsoCFDI", "Select c_UsoCFDI From CatUsoCfdiSat Where CveUso=" + rw_Receptor["CveUso"].ToString())
                                    );
                            }

                            string QueryConceptos = "SELECT CveDetalleFactura, CveNota, Cantidad, Unidad, Descripcion, Precio, SubTotal, Descuento, IVA, Total, ChkIva, ChkIvaRetenido, ChkIsrRetenido, IvaRetenido, IsrRetenido, ClaveUnidadSat, ClaveProdServSat, CveIva FROM DetalleFacturas WHERE CveFactura=" + CveFactura;
                            DataTable _dtConceptos = new DataTable();

                            _dtConceptos = cm.SP_DataReaderQuery(QueryConceptos);

                            int exento = 0;
                            int _iva = 0;
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

                                int CveIVa = int.Parse(rw_conceptos["CveIva"].ToString());

                                switch (CveIVa)
                                {
                                    case 1: // Iva 16%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.160000",
                                                                 importe: rw_conceptos["IVA"].ToString(), concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 2: // Tasa Iva 8%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.080000",
                                                                 importe: rw_conceptos["IVA"].ToString(), concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 3: // Tasa Iva 0%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.000000",
                                                                 importe: rw_conceptos["IVA"].ToString(), concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 4: // Tasa EXENTO
                                    case 0:
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte,
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Exento,
                                                                  null, null,
                                                                 concepto: c1);
                                        exento = 1;
                                        break;
                                }

                                /*
                                if (int.Parse(rw_conceptos["ChkIva"].ToString())==1)
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
                                                                   tasaOCuota: null,
                                                                   importe: null,concepto: c1);

                                }
                                */


                                if (int.Parse(rw_conceptos["ChkIvaRetenido"].ToString()) == 1)
                                {
                                    if (CveTipoFactura != 6)
                                    {
                                        usLib.P05ConceptoAgregarImpuestoRetencion(
                                        baseCalculoImpuesto: baseimporte.ToString(),
                                        impuesto: "002",
                                        tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                        tasaOCuota: "0.106666",
                                        importe: rw_conceptos["IvaRetenido"].ToString(), concepto: c1);
                                    }
                                    else
                                    {
                                        usLib.P05ConceptoAgregarImpuestoRetencion(
                                       baseCalculoImpuesto: baseimporte.ToString(),
                                       impuesto: "002",
                                       tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                       tasaOCuota: "0.040000",
                                       importe: rw_conceptos["IvaRetenido"].ToString(), concepto: c1);
                                    }
                                }

                                if (int.Parse(rw_conceptos["ChkIsrRetenido"].ToString()) == 1)
                                {
                                    usLib.P05ConceptoAgregarImpuestoRetencion(
                                    baseCalculoImpuesto: baseimporte.ToString(),
                                    impuesto: "001",
                                    tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                    tasaOCuota: "0.100000",
                                    importe: rw_conceptos["IsrRetenido"].ToString(), concepto: c1);
                                }

                                if (CuentaPredial != "")
                                {
                                    usLib.P05ConceptoAgregarCuentaPredial(CuentaPredial, c1);
                                }

                            }

                            usLib.P06ImpuestosCrearResumenPorConceptos();

                            //INICO
                            //En este punto, se pueden incluir los complementos oficiales del SAT

                            string QueryRetencionesLocales = "SELECT CR.Descripcion,FR.Importe,CR.Porcentaje FROM FacturaRetencion FR LEFT JOIN CatRetenciones CR ON FR.CveRetencion=CR.CveRetencion WHERE  FR.CveFactura=" + CveFactura;

                            DataTable _dtRetencionesLocales = new DataTable();
                            _dtRetencionesLocales = cm.SP_DataReaderQuery(QueryRetencionesLocales);

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

                            string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"];
                            string NombreXml = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura + "_Org.xml";

                            usLib.Cfd.SaveToFile(Destinoxml + @"org\" + NombreXml, "UMBRALLSOFTWARESADECV");

                            //int CveProveedor=GetStrFieldQuery("CvePacTimbrado","Select CvePacTimbrado From CatPacTimbrado Where CvePactimbrado=" + )

                            string UsuarioPac = cm.GetStrFieldQuery("UsuarioPac", "Select UsuarioPac From Emisores Where CveEmisor=" + CveEmisor);
                            string Contraseña = cm.GetStrFieldQuery("Contrasenia", "Select Contrasenia From Emisores Where CveEmisor=" + CveEmisor);

                           _result= TimbrarFactura40(CveFactura, CveEmisor, CveReceptor, cvetipofactura, RfcEmisor, RfcReceptor, Destinoxml, NombreXml, CvePacTimbrado, UsuarioPac, Contraseña, usLib.Cfd.NoCertificado, Total);

                        }
                    }
                    else
                    {
                        //MessageBox.Show("El estatus de la factura no es valido, favor de verificar que no haya sido timbrada o cancelada con anterioridad", "Validacion de Datos");
                    }
                }
               
            }

            return _result;
        }

        public ArrayList GenerarCFDI40_USLib(int CveFactura, ArrayList _ListaFactura, ArrayList _ListaDetalleFactura, ArrayList _ListaRelacionCfdi, ArrayList _ListaDetalleRetencion, SqlCommand command=null)
        {
                             
            ArrayList _ListaParaTimbrar = new ArrayList();
            if (_ListaFactura.Count > 0)
            {
                foreach (Parametros item in _ListaFactura)
                {
                    int CveEstatusFactura = item.CveEstatus;

                    if (CveEstatusFactura == 1)
                    {
                        DataTable _dtComprobante = new DataTable();

                        int result = 1;
                        //result =  //MessageBox.Show("¿Está seguro que desea sellar la Factura?", "Sellar Factura", MessageBoxButtons.YesNo);
                        if (result == 1)
                        {

                            USLib.FachadaCfdv40 usLib = new USLib.FachadaCfdv40();

                            Form_DialogSuccess _DialogSuccess = new Form_DialogSuccess();
                            _DialogSuccess.Mensaje = "Espere...un momento";
                            _DialogSuccess.ShowDialog();

                            //int CveFactura = CveFactura; //int.Parse(dataGrid.CurrentRow.Cells["CveFactura"].Value.ToString());
                            int CveReceptor = item.CveReceptor;// int.Parse(dataGrid.CurrentRow.Cells["CveReceptor"].Value.ToString());
                            int CveEmisor = item.CveEmisor; // int.Parse(dataGrid.CurrentRow.Cells["CveEmisor"].Value.ToString());
                            string RfcEmisor = item.RfcEmisor;  //dataGrid.CurrentRow.Cells["RFCEmisor"].Value.ToString();
                            string RfcReceptor = item.RfcReceptor;// dataGrid.CurrentRow.Cells["RFC"].Value.ToString();
                            int cvetipofactura = item.CveTipoFactura;// int.Parse(dataGrid.CurrentRow.Cells["CveTipoFactura"].Value.ToString());
                            int CvePacTimbrado = item.CvePacTimbrado;
                            string NombreCert = CveEmisor + "_" + RfcEmisor;
                            string CveClave = item.CveClave.ToString();// item GetStrFieldQuery("CveClave", "Select CveClave From Emisores Where CveEmisor=" + CveEmisor);
                            string url = ConfigurationManager.AppSettings["RutaCertificados"];

                            string certificado = url  + @"\" + NombreCert + ".cer";
                            string key = url + @"\" + NombreCert + ".key";
                            string Password = CveClave;

                            //Configurar el núemero de decimales que se manejaran
                            //La libreria TRUNCA - NO REDONDEA
                            //Ejemplo: 1.123999 a 3 decimales resultado: 1.123
                            usLib.P00Setup(numeroDecimalesEnTotales: NoDecimalesTotales._NoDecimalesTotales,
                                numeroDecimalesEnDetalle: NoDecimalesImpuestos._NoDecimalesImpuestos, numeroDecimalesEnImpuestos: NoDecimalesTotales._NoDecimalesTotales,
                                cerFile:
                                certificado,
                                keyFile:
                                key,
                                passwordKey: Password);


                            usLib.P01DatosGenerales(
                        serie: item.Serie,//["Serie"].ToString(), //Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres.
                        folio: item.FolioInt, //["FolioInt"].ToString(), //Atributo opcional para control interno del contribuyente que expresa el folio del comprobante, acepta una cadena de caracteres.
                        fecha: item.FechaEmision,//["FechaEmision"].ToString(), //FechaEmision.Date.ToString("s"), //Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante.
                        formaPago: item.FormaPagoSat,// cm.GetStrFieldQuery("c_formapago", "Select c_formapago From CatFormaPagoSat Where CveFormaPago=" + rw_gral["CveFormaPago"].ToString()), //Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
                        condicionesDePago: item.CondicionesPago, //["CondicionesPago"].ToString(), //Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
                        subTotal: Math.Round(item.SubTotal,NoDecimalesTotales._NoDecimalesTotales).ToString(), //["SubTotal"].ToString(), //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos.
                        descuento: Math.Round(item.Descuento,NoDecimalesTotales._NoDecimalesTotales).ToString(), //["Descuento"].ToString(), //Atributo condicional para representar el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe registrar cuando existan conceptos con descuento.
                        moneda: item.MonedaSat, //["Moneda"].ToString(), //Atributo requerido para identificar la clave de la moneda utilizada para expresar los montos, cuando se usa moneda nacional se registra MXN. Conforme con la especificación ISO 4217.
                        tipoCambio: item.TipoCambioSat , //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion.
                        total: Math.Round(item.Total,NoDecimalesTotales._NoDecimalesTotales).ToString(), //["Total"].ToString(), //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
                        tipoDeComprobante: item.TipoComprobanteSat,// TipoComprobante, //Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.
                         
                        metodoPago: item.MetodoPagoSat,// cm.GetStrFieldQuery("c_metodopago", "Select c_metodopago From CatMetodoPagoSat Where CveMetodoPago=" + rw_gral["CveMetodoPago"].ToString()), //Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF.
                        lugarExpedicion: item.StrCPExpedido, //["CP"].ToString(), //Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal).
                        confirmacion: "",
                        exportacion:item.Exportacion
                                );


                            /*
                            string Query = "SELECT * FROM Facturas F Left Join Emisores E on F.CveEmisor=E.CveEmisor  WHERE CveFactura=" + CveFactura;

                          
                            DataTable _dtDatosFactura = new DataTable();
                            _dtDatosFactura = cm.SP_DataReaderQuery(Query);
                            */
                            int CveTipoFactura = 0;
                            string CuentaPredial = "";
                            decimal Total = 0;

                           


                            foreach (CfdiRelacionado Rel in _ListaRelacionCfdi)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                   relacion: Rel.Str_c_TipoRelacion, // cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                   uuid: Rel.StrUUID//["UUID"].ToString()
                                   );

                            }

                            /*
                            string QuerycfdiRelacionados = "Select * From DetalleTipoRelacionFactura Where CveFactura=" + CveFactura;

                            DataTable _dtcfdirelacionados = new DataTable();
                            _dtcfdirelacionados = cm.SP_DataReaderQuery(QuerycfdiRelacionados);

                            foreach (DataRow rw_relacionados in _dtcfdirelacionados.Rows)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                    relacion: cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                    uuid: rw_relacionados["UUID"].ToString()
                                    );
                            }
                            */

                            usLib.P03Emisor(
                                   rfc: item.RfcEmisor, // rw_Emisor["RFC"].ToString(),
                                   nombre: item.NombreEmisor, // rw_Emisor["Nombre"].ToString(),
                                   regimenFiscal: item.RegimenFiscal, // cm.GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + rw_Emisor["CveRegimen"].ToString())
                                   facAtrAdquirente:""
                                   );


                            string QueryReceptor="Select R.CveReceptor, R.RFC,  R.Nombre As NombreReceptor," +
                                "CP as DomicilioFiscal, TipoReceptor, c_Pais," +
                               " CUC.c_UsoCFDI, CRS.Regimen " +
                               "From Receptores R Left Join CatUsoCfdiSat CUC on " +
                               "R.CveUso=CUC.CveUso " +
                               "Left Join CatRegimenSat CRS on R.CveRegimen=CRS.CveRegimen " +
                               "Where CveReceptor=" + item.CveReceptor;

                            DataTable _dtReceptor = new DataTable();
                            _dtReceptor = cm.SP_DataReaderQuery(QueryReceptor);

                            foreach (DataRow R in _dtReceptor.Rows)
                            {
                                usLib.P04Receptor(
                                   rfc: R["RFC"].ToString(), //rw_Receptor["RFC"].ToString(),
                                   nombre: R["NombreReceptor"].ToString(), // nOMBRE,BR rw_Receptor["Nombre"].ToString(),
                                   domicilioFiscalReceptor: R["DomicilioFiscal"].ToString(),
                                   residenciaFiscal: R["c_Pais"].ToString() == "MEX" ? null : R["c_Pais"].ToString(),  //item.ResidenciaFiscalReceptor,
                                    numRegIdTrib: "",
                                   usoCfdi: R["c_UsoCFDI"].ToString(), //  cm.GetStrFieldQuery("c_UsoCFDI", "Select c_UsoCFDI From CatUsoCfdiSat Where CveUso=" + rw_Receptor["CveUso"].ToString())
                                   regimenFiscalReceptor: R["Regimen"].ToString()
                                   );
                            }

                            int exento = 0;
                            int _iva = 0;
                            ArrayList _ListaImpuestosDetalle = new ArrayList();
                            foreach (DetalleParametros rw_conceptos in _ListaDetalleFactura)
                            {

                                var c1 = usLib.P05ConceptosAgregar(
                                claveProdServ: rw_conceptos.ClaveProductoServicioSat,// rw_conceptos["ClaveProdServSat"].ToString(), //Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
                                noIdentificacion: "", //Atributo opcional para expresar el número de parte, identificador del producto o del servicio, la clave de producto o servicio, SKU o equivalente, propia de la operación del emisor, amparado por el presente concepto. Opcionalmente se puede utilizar claves del estándar GTIN.
                                cantidad: rw_conceptos.Cantidad,// rw_conceptos["Cantidad"].ToString(), //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                                claveUnidad: rw_conceptos.StrClaveUnidadSat, //  rw_conceptos["ClaveUnidadSat"].ToString(), //Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                unidad: "NA", //Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                descripcion: rw_conceptos.Descripcion, // rw_conceptos["Descripcion"].ToString(), //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
                                valorUnitario: rw_conceptos.PrecioUnitario, // rw_conceptos["Precio"].ToString(), //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
                                importe:rw_conceptos.SubTotal,// rw_conceptos["SubTotal"].ToString(), //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.

                                descuento: rw_conceptos.Descuento, // rw_conceptos["Descuento"].ToString()
                                objetoImp:rw_conceptos.ObjetoImp

                            );

                                decimal baseimporte = rw_conceptos.SubTotal - rw_conceptos.Descuento;// decimal.Parse(rw_conceptos["SubTotal"].ToString()) - decimal.Parse(rw_conceptos["Descuento"].ToString());


                               // DataTable _dtImpuestoConcepto = new DataTable();

                                //_dtImpuestoConcepto = Clases.cConceptos.GetFacturaConceptoImpuesto(rw_conceptos.CveConcepto);


                                foreach (cConceptos.v_ImpuestosConceptos v_Impuestos in rw_conceptos.ListConceptoImpuesto)
                                {
                                    /*
                                    cConceptos.v_ImpuestosConceptos v_Impuestos = new cConceptos.v_ImpuestosConceptos();
                                    v_Impuestos.CveImpuesto = int.Parse(_ci["CveImpuesto"].ToString());
                                    v_Impuestos.CveTipoImpuesto = int.Parse(_ci["CveTipoImpuesto"].ToString());
                                    v_Impuestos.TipoImpuesto = _ci["TipoImpuesto"].ToString();
                                    v_Impuestos.CveTipoEntidad = int.Parse(_ci["CveTipoEntidad"].ToString());
                                    v_Impuestos.TipoEntidadImpuesto = _ci["TipoEntidadImpuesto"].ToString();
                                    v_Impuestos.Descripcion = _ci["Descripcion"].ToString();
                                    v_Impuestos.Porcentaje = decimal.Parse(_ci["Porcentaje"].ToString());
                                    v_Impuestos.Signo = _ci["Signo"].ToString();
                                    v_Impuestos.CveConcepto = rw_conceptos.CveConcepto;
                                    v_Impuestos.c_Impuesto = _ci["c_Impuesto"].ToString();
                                    v_Impuestos.TipoFactor = _ci["TipoFactor"].ToString();
                                    v_Impuestos.TasaCouta = decimal.Parse(_ci["TasaCuouta"].ToString());
                                    v_Impuestos.ValorImpuesto = decimal.Parse(_ci["Importe"].ToString());
                                    */

                                    //Producto.Iva = Math.Round(((Producto.PrecioUnitario * Producto.Cantidad) - Producto.Descuento) * (Producto.PorcentajeImpuesto / 100), 6);
                                    if (v_Impuestos.CveTipoEntidad == 1)
                                    {

                                        if (v_Impuestos.CveTipoImpuesto == 1)
                                        {

                                            usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                baseCalculoImpuesto: baseimporte.ToString(),
                                                                impuesto: v_Impuestos.c_Impuesto,
                                                                tipoFactor: v_Impuestos.TipoFactor,
                                                                tasaOCuota: v_Impuestos.TipoFactor!="Exento" ? v_Impuestos.TasaCuota.ToString() : null,
                                                                importe: v_Impuestos.TipoFactor !="Exento" ? v_Impuestos.ValorImpuesto.ToString() : null /*rw_conceptos["IVA"].ToString()*/, concepto: c1);

                                            
                                        }
                                        else
                                        {
                                            usLib.P05ConceptoAgregarImpuestoRetencion(
                                        baseCalculoImpuesto: baseimporte.ToString(),
                                        impuesto: v_Impuestos.c_Impuesto,
                                        tipoFactor:v_Impuestos.TipoFactor,
                                        tasaOCuota: v_Impuestos.TasaCuota.ToString(),
                                        importe: v_Impuestos.ValorImpuesto.ToString(), concepto: c1);

                                       
                                        }

                                    }

                                    v_Impuestos.sGuidHijo = Guid.NewGuid().ToString();
                                    _ListaImpuestosDetalle.Add(v_Impuestos);
                                }



                                if (CuentaPredial != "")
                                {
                                    usLib.P05ConceptoAgregarCuentaPredial(CuentaPredial, c1);
                                }

                            }

                            usLib.P06ImpuestosCrearResumenPorConceptos();

                            //INICO
                            //En este punto, se pueden incluir los complementos oficiales del SAT
                           /*
                            string QueryRetencionesLocales = "SELECT CR.Descripcion,FR.Importe,CR.Porcentaje FROM FacturaRetencion FR LEFT JOIN CatRetenciones CR ON FR.CveRetencion=CR.CveRetencion WHERE  FR.CveFactura=" + CveFactura;

                            DataTable _dtRetencionesLocales = new DataTable();
                            _dtRetencionesLocales = cm.SP_DataReaderQuery(QueryRetencionesLocales);
                           */


                            if (_ListaDetalleRetencion.Count > 0)
                            {
                                //Complemento al Comprobante Fiscal Digital para Impuestos Locales
                                var impLocal = new USLib.Complementos.Comprobante.ImpLocal.FachadaImpLocal40();


                                foreach (cConceptos.v_ImpuestosConceptos rw_locales in _ListaDetalleRetencion)
                                {
                                    //Nodo opcional para la expresión de los impuestos locales retenidos
                                    impLocal.AgregarComplementoImpuestoLocalRetenciones(impLocRetenido:
                                        rw_locales.Descripcion, //["Descripcion"].ToString(), //Nombre del impuesto local retenido
                                        tasadeRetencion:  rw_locales.Porcentaje,// decimal.Parse(rw_locales["Porcentaje"].ToString()), //Porcentaje de retención del impuesto local
                                        importe: Math.Round(rw_locales.ValorImpuesto,2) // decimal.Parse(rw_locales["Importe"].ToString()) //Monto del impuesto local retenido
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

                            string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"];
                            string NombreXml = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura + "_Org.xml";
                            Helpers.CrearDirectorio(Destinoxml + @"\" + RfcEmisor);
                            Helpers.CrearDirectorio(Destinoxml + @"\" + RfcEmisor + @"\org");
                            usLib.Cfd.SaveToFile(Destinoxml + @"\" + RfcEmisor  + @"\org\" + NombreXml, "UMBRALLSOFTWARESADECV");

                            //int CveProveedor=GetStrFieldQuery("CvePacTimbrado","Select CvePacTimbrado From CatPacTimbrado Where CvePactimbrado=" + )

                            string UsuarioPac = ""; // cm.GetStrFieldQuery("UsuarioPac", "Select UsuarioPac From Emisores Where CveEmisor=" + CveEmisor);
                            string Contraseña = ""; cm.GetStrFieldQuery("Contrasenia", "Select Contrasenia From Emisores Where CveEmisor=" + CveEmisor);

                           

                            DatosParaTimbrar paraTimbrar = new DatosParaTimbrar
                            {
                                CveFactura = CveFactura,
                                CveEmisor = CveEmisor,
                                CveReceptor = CveReceptor,
                                cvetipofactura = cvetipofactura,
                                RfcEmisor = RfcEmisor,
                                RfcReceptor = RfcReceptor,
                                Destinoxml = Destinoxml + @"\" + RfcEmisor,
                                NombreXml = NombreXml,
                                CvePacTimbrado = CvePacTimbrado,
                                UsuarioPac = UsuarioPac,
                                Contraseña = Contraseña,
                                NoCertificado = usLib.Cfd.NoCertificado,
                                Total = Total

                            };
                            _ListaParaTimbrar.Add(paraTimbrar);
                            // _result = TimbrarFactura40(CveFactura, CveEmisor, CveReceptor, cvetipofactura, RfcEmisor, RfcReceptor, Destinoxml, NombreXml, CvePacTimbrado, UsuarioPac, Contraseña, usLib.Cfd.NoCertificado, Total, command);

                            //_result = true;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("El estatus de la factura no es valido, favor de verificar que no haya sido timbrada o cancelada con anterioridad", "Validacion de Datos");
                    }
                }

            }

            return _ListaParaTimbrar;
        }
        public ArrayList GenerarCFDI40CS_1(int CveFactura, ArrayList _ListaFactura, ArrayList _ListaDetalleFactura, ArrayList _ListaRelacionCfdi, ArrayList _ListaDetalleRetencion, SqlCommand command = null)
        {
            bool _result = false;
            ArrayList _ListaParaTimbrar = new ArrayList();
            if (_ListaFactura.Count > 0)
            {
                foreach (Parametros item in _ListaFactura)
                {
                    int CveEstatusFactura = item.CveEstatus;

                    if (CveEstatusFactura == 1)
                    {
                        DataTable _dtComprobante = new DataTable();

                        int result = 1;
                        //result =  //MessageBox.Show("¿Está seguro que desea sellar la Factura?", "Sellar Factura", MessageBoxButtons.YesNo);
                        if (result == 1)
                        {


                            
                            //USLibV4.FachadaCfdiV4 cfdiV4 = new USLibV4.FachadaCfdiV4();
                                                        
                            USLib.FachadaCfdv33 usLib = new USLib.FachadaCfdv33();



                            Form_DialogSuccess _DialogSuccess = new Form_DialogSuccess();
                            _DialogSuccess.Mensaje = "Espere...un momento";
                            _DialogSuccess.ShowDialog();

                            //int CveFactura = CveFactura; //int.Parse(dataGrid.CurrentRow.Cells["CveFactura"].Value.ToString());
                            int CveReceptor = item.CveReceptor;// int.Parse(dataGrid.CurrentRow.Cells["CveReceptor"].Value.ToString());
                            int CveEmisor = item.CveEmisor; // int.Parse(dataGrid.CurrentRow.Cells["CveEmisor"].Value.ToString());
                            string RfcEmisor = item.RfcEmisor;  //dataGrid.CurrentRow.Cells["RFCEmisor"].Value.ToString();
                            string RfcReceptor = item.RfcReceptor;// dataGrid.CurrentRow.Cells["RFC"].Value.ToString();
                            int cvetipofactura = item.CveTipoFactura;// int.Parse(dataGrid.CurrentRow.Cells["CveTipoFactura"].Value.ToString());
                            int CvePacTimbrado = item.CvePacTimbrado;
                            string NombreCert = CveEmisor + "_" + RfcEmisor;
                            string CveClave = item.CveClave.ToString();// item GetStrFieldQuery("CveClave", "Select CveClave From Emisores Where CveEmisor=" + CveEmisor);
                            string url = ConfigurationManager.AppSettings["RutaCertificados"];

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


                            usLib.P01DatosGenerales(
                        serie: item.Serie,//["Serie"].ToString(), //Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres.
                        folio: item.FolioInt, //["FolioInt"].ToString(), //Atributo opcional para control interno del contribuyente que expresa el folio del comprobante, acepta una cadena de caracteres.
                        fecha: item.FechaEmision,//["FechaEmision"].ToString(), //FechaEmision.Date.ToString("s"), //Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante.
                        formaPago: item.FormaPagoSat,// cm.GetStrFieldQuery("c_formapago", "Select c_formapago From CatFormaPagoSat Where CveFormaPago=" + rw_gral["CveFormaPago"].ToString()), //Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
                        condicionesDePago: item.CondicionesPago, //["CondicionesPago"].ToString(), //Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
                        subTotal: item.SubTotal.ToString(), //["SubTotal"].ToString(), //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos.
                        descuento: item.Descuento.ToString(), //["Descuento"].ToString(), //Atributo condicional para representar el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe registrar cuando existan conceptos con descuento.
                        moneda: item.MonedaSat, //["Moneda"].ToString(), //Atributo requerido para identificar la clave de la moneda utilizada para expresar los montos, cuando se usa moneda nacional se registra MXN. Conforme con la especificación ISO 4217.
                        tipoCambio: item.TipoCambioSat, //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion.
                        total: item.Total.ToString(), //["Total"].ToString(), //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
                        tipoDeComprobante: item.TipoComprobanteSat,// TipoComprobante, //Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.

                        metodoPago: item.MetodoPagoSat,// cm.GetStrFieldQuery("c_metodopago", "Select c_metodopago From CatMetodoPagoSat Where CveMetodoPago=" + rw_gral["CveMetodoPago"].ToString()), //Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF.
                        lugarExpedicion: item.StrCPExpedido, //["CP"].ToString(), //Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal).
                        confirmacion: ""
                                );


                            /*
                            string Query = "SELECT * FROM Facturas F Left Join Emisores E on F.CveEmisor=E.CveEmisor  WHERE CveFactura=" + CveFactura;

                          
                            DataTable _dtDatosFactura = new DataTable();
                            _dtDatosFactura = cm.SP_DataReaderQuery(Query);
                            */
                            int CveTipoFactura = 0;
                            string CuentaPredial = "";
                            decimal Total = 0;




                            foreach (CfdiRelacionado Rel in _ListaRelacionCfdi)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                   relacion: Rel.Str_c_TipoRelacion, // cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                   uuid: Rel.StrUUID//["UUID"].ToString()
                                   );

                            }

                            /*
                            string QuerycfdiRelacionados = "Select * From DetalleTipoRelacionFactura Where CveFactura=" + CveFactura;

                            DataTable _dtcfdirelacionados = new DataTable();
                            _dtcfdirelacionados = cm.SP_DataReaderQuery(QuerycfdiRelacionados);

                            foreach (DataRow rw_relacionados in _dtcfdirelacionados.Rows)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                    relacion: cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                    uuid: rw_relacionados["UUID"].ToString()
                                    );
                            }
                            */

                            usLib.P03Emisor(
                                   rfc: item.RfcEmisor, // rw_Emisor["RFC"].ToString(),
                                   nombre: item.NombreEmisor, // rw_Emisor["Nombre"].ToString(),
                                   regimenFiscal: item.RegimenFiscal // cm.GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + rw_Emisor["CveRegimen"].ToString())
                                   );




                            usLib.P04Receptor(
                                   rfc: item.RfcReceptor, //rw_Receptor["RFC"].ToString(),
                                   nombre: item.strNombreReceptor, // nOMBRE,BR rw_Receptor["Nombre"].ToString(),
                                   residenciaFiscal: "",
                                   numRegIdTrib: "",
                                   usoCfdi: item.c_UsoCfdi //  cm.GetStrFieldQuery("c_UsoCFDI", "Select c_UsoCFDI From CatUsoCfdiSat Where CveUso=" + rw_Receptor["CveUso"].ToString())
                                   );

                            int exento = 0;
                            int _iva = 0;
                            foreach (DetalleParametros rw_conceptos in _ListaDetalleFactura)
                            {

                                var c1 = usLib.P05ConceptosAgregar(
                                claveProdServ: rw_conceptos.ClaveProductoServicioSat,// rw_conceptos["ClaveProdServSat"].ToString(), //Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
                                noIdentificacion: "", //Atributo opcional para expresar el número de parte, identificador del producto o del servicio, la clave de producto o servicio, SKU o equivalente, propia de la operación del emisor, amparado por el presente concepto. Opcionalmente se puede utilizar claves del estándar GTIN.
                                cantidad: rw_conceptos.Cantidad,// rw_conceptos["Cantidad"].ToString(), //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                                claveUnidad: rw_conceptos.StrClaveUnidadSat, //  rw_conceptos["ClaveUnidadSat"].ToString(), //Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                unidad: "NA", //Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                descripcion: rw_conceptos.Descripcion, // rw_conceptos["Descripcion"].ToString(), //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
                                valorUnitario: rw_conceptos.PrecioUnitario, // rw_conceptos["Precio"].ToString(), //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
                                importe: rw_conceptos.SubTotal,// rw_conceptos["SubTotal"].ToString(), //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.

                                descuento: rw_conceptos.Descuento // rw_conceptos["Descuento"].ToString()

                            );

                                decimal baseimporte = rw_conceptos.SubTotal;// decimal.Parse(rw_conceptos["SubTotal"].ToString()) - decimal.Parse(rw_conceptos["Descuento"].ToString());

                                int CveIVa = rw_conceptos.CveIva; // int.Parse(rw_conceptos["CveIva"].ToString());

                                switch (CveIVa)
                                {
                                    case 1: // Iva 16%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.160000",
                                                                 importe: rw_conceptos.TotalIva.ToString() /*rw_conceptos["IVA"].ToString()*/, concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 2: // Tasa Iva 8%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.080000",
                                                                 importe: rw_conceptos.TotalIva.ToString() /* rw_conceptos["IVA"].ToString()*/, concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 3: // Tasa Iva 0%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.000000",
                                                                 importe: rw_conceptos.TotalIva.ToString() /*rw_conceptos["IVA"].ToString()*/, concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 4: // Tasa EXENTO
                                    case 0:
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte,
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Exento,
                                                                  null, null,
                                                                 concepto: c1);
                                        exento = 1;
                                        break;
                                }

                                /*
                                if (int.Parse(rw_conceptos["ChkIva"].ToString())==1)
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
                                                                   tasaOCuota: null,
                                                                   importe: null,concepto: c1);

                                }
                                */


                                if (rw_conceptos.IntChkIvaRetenido == 1)
                                {
                                    if (CveTipoFactura != 6)
                                    {
                                        usLib.P05ConceptoAgregarImpuestoRetencion(
                                        baseCalculoImpuesto: baseimporte.ToString(),
                                        impuesto: "002",
                                        tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                        tasaOCuota: "0.106667",
                                        importe: rw_conceptos.DblIvaRetenido.ToString(), concepto: c1);
                                    }
                                    else
                                    {
                                        usLib.P05ConceptoAgregarImpuestoRetencion(
                                       baseCalculoImpuesto: baseimporte.ToString(),
                                       impuesto: "002",
                                       tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                       tasaOCuota: "0.040000",
                                       importe: rw_conceptos.DblIvaRetenido.ToString(), concepto: c1);
                                    }
                                }

                                if (rw_conceptos.IntChkIsrRetenido == 1)
                                {
                                    usLib.P05ConceptoAgregarImpuestoRetencion(
                                    baseCalculoImpuesto: baseimporte.ToString(),
                                    impuesto: "001",
                                    tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                    tasaOCuota: "0.100000",
                                    importe: rw_conceptos.DblIsrRetenido.ToString(), concepto: c1);
                                }

                                if (CuentaPredial != "")
                                {
                                    usLib.P05ConceptoAgregarCuentaPredial(CuentaPredial, c1);
                                }

                            }

                            usLib.P06ImpuestosCrearResumenPorConceptos();

                            //INICO
                            //En este punto, se pueden incluir los complementos oficiales del SAT
                            /*
                             string QueryRetencionesLocales = "SELECT CR.Descripcion,FR.Importe,CR.Porcentaje FROM FacturaRetencion FR LEFT JOIN CatRetenciones CR ON FR.CveRetencion=CR.CveRetencion WHERE  FR.CveFactura=" + CveFactura;

                             DataTable _dtRetencionesLocales = new DataTable();
                             _dtRetencionesLocales = cm.SP_DataReaderQuery(QueryRetencionesLocales);
                            */

                            if (_ListaDetalleRetencion.Count > 0)
                            {
                                //Complemento al Comprobante Fiscal Digital para Impuestos Locales
                                var impLocal = new USLib.Complementos.Comprobante.ImpLocal.FachadaImpLocal();


                                foreach (DetalleFacturaRetencion rw_locales in _ListaDetalleRetencion)
                                {
                                    //Nodo opcional para la expresión de los impuestos locales retenidos
                                    impLocal.AgregarComplementoImpuestoLocalRetenciones(impLocRetenido:
                                        rw_locales.Descripcion, //["Descripcion"].ToString(), //Nombre del impuesto local retenido
                                        tasadeRetencion: rw_locales.Porcentaje,// decimal.Parse(rw_locales["Porcentaje"].ToString()), //Porcentaje de retención del impuesto local
                                        importe: rw_locales.Importe // decimal.Parse(rw_locales["Importe"].ToString()) //Monto del impuesto local retenido
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

                            string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"];
                            string NombreXml = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura + "_Org.xml";

                            usLib.Cfd.SaveToFile(Destinoxml + @"org\" + NombreXml, "UMBRALLSOFTWARESADECV");

                            //int CveProveedor=GetStrFieldQuery("CvePacTimbrado","Select CvePacTimbrado From CatPacTimbrado Where CvePactimbrado=" + )

                            string UsuarioPac = ""; // cm.GetStrFieldQuery("UsuarioPac", "Select UsuarioPac From Emisores Where CveEmisor=" + CveEmisor);
                            string Contraseña = ""; cm.GetStrFieldQuery("Contrasenia", "Select Contrasenia From Emisores Where CveEmisor=" + CveEmisor);

                            DatosParaTimbrar paraTimbrar = new DatosParaTimbrar
                            {
                                CveFactura=CveFactura,
                                CveEmisor=CveEmisor,
                                CveReceptor=CveReceptor,
                                cvetipofactura=cvetipofactura,
                                RfcEmisor=RfcEmisor,
                                RfcReceptor=RfcReceptor,
                                Destinoxml=Destinoxml,
                                NombreXml=NombreXml,
                                CvePacTimbrado=CvePacTimbrado,
                                UsuarioPac=UsuarioPac,
                                Contraseña=Contraseña,
                                NoCertificado= usLib.Cfd.NoCertificado,
                                Total=Total

                            };
                            _ListaParaTimbrar.Add(paraTimbrar);

                            _result = true; 

                        }
                    }
                    else
                    {
                        //MessageBox.Show("El estatus de la factura no es valido, favor de verificar que no haya sido timbrada o cancelada con anterioridad", "Validacion de Datos");
                    }
                }

            }

            return _ListaParaTimbrar;
        }

        public ArrayList GenerarCFDI40CS_Profact(int CveFactura, ArrayList _ListaFactura, ArrayList _ListaDetalleFactura, ArrayList _ListaRelacionCfdi, ArrayList _ListaDetalleRetencion, SqlCommand command = null)
        {
            bool _result = false;
            ArrayList _ListaParaTimbrar = new ArrayList();
            if (_ListaFactura.Count > 0)
            {
                foreach (Parametros item in _ListaFactura)
                {
                    int CveEstatusFactura = item.CveEstatus;

                    if (CveEstatusFactura == 1)
                    {
                        DataTable _dtComprobante = new DataTable();

                        int result = 1;
                        //result =  //MessageBox.Show("¿Está seguro que desea sellar la Factura?", "Sellar Factura", MessageBoxButtons.YesNo);
                        if (result == 1)
                        {

                            USLib.FachadaCfdv33 usLib = new USLib.FachadaCfdv33();

                            Form_DialogSuccess _DialogSuccess = new Form_DialogSuccess();
                            _DialogSuccess.Mensaje = "Espere...un momento";
                            _DialogSuccess.ShowDialog();

                            //int CveFactura = CveFactura; //int.Parse(dataGrid.CurrentRow.Cells["CveFactura"].Value.ToString());
                            int CveReceptor = item.CveReceptor;// int.Parse(dataGrid.CurrentRow.Cells["CveReceptor"].Value.ToString());
                            int CveEmisor = item.CveEmisor; // int.Parse(dataGrid.CurrentRow.Cells["CveEmisor"].Value.ToString());
                            string RfcEmisor = item.RfcEmisor;  //dataGrid.CurrentRow.Cells["RFCEmisor"].Value.ToString();
                            string RfcReceptor = item.RfcReceptor;// dataGrid.CurrentRow.Cells["RFC"].Value.ToString();
                            int cvetipofactura = item.CveTipoFactura;// int.Parse(dataGrid.CurrentRow.Cells["CveTipoFactura"].Value.ToString());
                            int CvePacTimbrado = item.CvePacTimbrado;
                            string NombreCert = CveEmisor + "_" + RfcEmisor;
                            string CveClave = item.CveClave.ToString();// item GetStrFieldQuery("CveClave", "Select CveClave From Emisores Where CveEmisor=" + CveEmisor);
                            string url = ConfigurationManager.AppSettings["RutaCertificados"];

                            string certificado = url + NombreCert + ".cer";
                            string key = url + NombreCert + ".key";
                            string Password = CveClave;

                            //Configurar el núemero de decimales que se manejaran
                            //La libreria TRUNCA - NO REDONDEA
                            //Ejemplo: 1.123999 a 3 decimales resultado: 1.123

                            Profact.TimbraCFDI40.Comprobante comprobante = new Profact.TimbraCFDI40.Comprobante();
                            

                            usLib.P00Setup(numeroDecimalesEnTotales: 2,
                                numeroDecimalesEnDetalle: 6, numeroDecimalesEnImpuestos: 2,
                                cerFile:
                                certificado,
                                keyFile:
                                key,
                                passwordKey: Password);


                            usLib.P01DatosGenerales(
                        serie: item.Serie,//["Serie"].ToString(), //Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres.
                        folio: item.FolioInt, //["FolioInt"].ToString(), //Atributo opcional para control interno del contribuyente que expresa el folio del comprobante, acepta una cadena de caracteres.
                        fecha: item.FechaEmision,//["FechaEmision"].ToString(), //FechaEmision.Date.ToString("s"), //Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante.
                        formaPago: item.FormaPagoSat,// cm.GetStrFieldQuery("c_formapago", "Select c_formapago From CatFormaPagoSat Where CveFormaPago=" + rw_gral["CveFormaPago"].ToString()), //Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
                        condicionesDePago: item.CondicionesPago, //["CondicionesPago"].ToString(), //Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
                        subTotal: item.SubTotal.ToString(), //["SubTotal"].ToString(), //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos.
                        descuento: item.Descuento.ToString(), //["Descuento"].ToString(), //Atributo condicional para representar el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe registrar cuando existan conceptos con descuento.
                        moneda: item.MonedaSat, //["Moneda"].ToString(), //Atributo requerido para identificar la clave de la moneda utilizada para expresar los montos, cuando se usa moneda nacional se registra MXN. Conforme con la especificación ISO 4217.
                        tipoCambio: item.TipoCambioSat, //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion.
                        total: item.Total.ToString(), //["Total"].ToString(), //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
                        tipoDeComprobante: item.TipoComprobanteSat,// TipoComprobante, //Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.

                        metodoPago: item.MetodoPagoSat,// cm.GetStrFieldQuery("c_metodopago", "Select c_metodopago From CatMetodoPagoSat Where CveMetodoPago=" + rw_gral["CveMetodoPago"].ToString()), //Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF.
                        lugarExpedicion: item.StrCPExpedido, //["CP"].ToString(), //Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal).
                        confirmacion: ""
                                );


                            /*
                            string Query = "SELECT * FROM Facturas F Left Join Emisores E on F.CveEmisor=E.CveEmisor  WHERE CveFactura=" + CveFactura;

                          
                            DataTable _dtDatosFactura = new DataTable();
                            _dtDatosFactura = cm.SP_DataReaderQuery(Query);
                            */
                            int CveTipoFactura = 0;
                            string CuentaPredial = "";
                            decimal Total = 0;




                            foreach (CfdiRelacionado Rel in _ListaRelacionCfdi)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                   relacion: Rel.Str_c_TipoRelacion, // cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                   uuid: Rel.StrUUID//["UUID"].ToString()
                                   );

                            }

                            /*
                            string QuerycfdiRelacionados = "Select * From DetalleTipoRelacionFactura Where CveFactura=" + CveFactura;

                            DataTable _dtcfdirelacionados = new DataTable();
                            _dtcfdirelacionados = cm.SP_DataReaderQuery(QuerycfdiRelacionados);

                            foreach (DataRow rw_relacionados in _dtcfdirelacionados.Rows)
                            {
                                usLib.P02CfdiRelacionadosAgregarOpcional(
                                    relacion: cm.GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                                    uuid: rw_relacionados["UUID"].ToString()
                                    );
                            }
                            */

                            usLib.P03Emisor(
                                   rfc: item.RfcEmisor, // rw_Emisor["RFC"].ToString(),
                                   nombre: item.NombreEmisor, // rw_Emisor["Nombre"].ToString(),
                                   regimenFiscal: item.RegimenFiscal // cm.GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + rw_Emisor["CveRegimen"].ToString())
                                   );




                            usLib.P04Receptor(
                                   rfc: item.RfcReceptor, //rw_Receptor["RFC"].ToString(),
                                   nombre: item.strNombreReceptor, // nOMBRE,BR rw_Receptor["Nombre"].ToString(),
                                   residenciaFiscal: "",
                                   numRegIdTrib: "",
                                   usoCfdi: item.c_UsoCfdi //  cm.GetStrFieldQuery("c_UsoCFDI", "Select c_UsoCFDI From CatUsoCfdiSat Where CveUso=" + rw_Receptor["CveUso"].ToString())
                                   );

                            int exento = 0;
                            int _iva = 0;
                            foreach (DetalleParametros rw_conceptos in _ListaDetalleFactura)
                            {

                                var c1 = usLib.P05ConceptosAgregar(
                                claveProdServ: rw_conceptos.ClaveProductoServicioSat,// rw_conceptos["ClaveProdServSat"].ToString(), //Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
                                noIdentificacion: "", //Atributo opcional para expresar el número de parte, identificador del producto o del servicio, la clave de producto o servicio, SKU o equivalente, propia de la operación del emisor, amparado por el presente concepto. Opcionalmente se puede utilizar claves del estándar GTIN.
                                cantidad: rw_conceptos.Cantidad,// rw_conceptos["Cantidad"].ToString(), //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                                claveUnidad: rw_conceptos.StrClaveUnidadSat, //  rw_conceptos["ClaveUnidadSat"].ToString(), //Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                unidad: "NA", //Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                                descripcion: rw_conceptos.Descripcion, // rw_conceptos["Descripcion"].ToString(), //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
                                valorUnitario: rw_conceptos.PrecioUnitario, // rw_conceptos["Precio"].ToString(), //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
                                importe: rw_conceptos.SubTotal,// rw_conceptos["SubTotal"].ToString(), //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.

                                descuento: rw_conceptos.Descuento // rw_conceptos["Descuento"].ToString()

                            );

                                decimal baseimporte = rw_conceptos.SubTotal;// decimal.Parse(rw_conceptos["SubTotal"].ToString()) - decimal.Parse(rw_conceptos["Descuento"].ToString());

                                int CveIVa = rw_conceptos.CveIva; // int.Parse(rw_conceptos["CveIva"].ToString());

                                switch (CveIVa)
                                {
                                    case 1: // Iva 16%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.160000",
                                                                 importe: rw_conceptos.TotalIva.ToString() /*rw_conceptos["IVA"].ToString()*/, concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 2: // Tasa Iva 8%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.080000",
                                                                 importe: rw_conceptos.TotalIva.ToString() /* rw_conceptos["IVA"].ToString()*/, concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 3: // Tasa Iva 0%
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte.ToString(),
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                                                 tasaOCuota: "0.000000",
                                                                 importe: rw_conceptos.TotalIva.ToString() /*rw_conceptos["IVA"].ToString()*/, concepto: c1);
                                        _iva = 1;
                                        break;
                                    case 4: // Tasa EXENTO
                                    case 0:
                                        usLib.P05ConceptoAgregarImpuestoTraslado(
                                                                 baseCalculoImpuesto: baseimporte,
                                                                 impuesto: "002",
                                                                 tipoFactor: USLib.Cfdv33.c_TipoFactor.Exento,
                                                                  null, null,
                                                                 concepto: c1);
                                        exento = 1;
                                        break;
                                }

                                /*
                                if (int.Parse(rw_conceptos["ChkIva"].ToString())==1)
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
                                                                   tasaOCuota: null,
                                                                   importe: null,concepto: c1);

                                }
                                */


                                if (rw_conceptos.IntChkIvaRetenido == 1)
                                {
                                    if (CveTipoFactura != 6)
                                    {
                                        usLib.P05ConceptoAgregarImpuestoRetencion(
                                        baseCalculoImpuesto: baseimporte.ToString(),
                                        impuesto: "002",
                                        tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                        tasaOCuota: "0.106667",
                                        importe: rw_conceptos.DblIvaRetenido.ToString(), concepto: c1);
                                    }
                                    else
                                    {
                                        usLib.P05ConceptoAgregarImpuestoRetencion(
                                       baseCalculoImpuesto: baseimporte.ToString(),
                                       impuesto: "002",
                                       tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                       tasaOCuota: "0.040000",
                                       importe: rw_conceptos.DblIvaRetenido.ToString(), concepto: c1);
                                    }
                                }

                                if (rw_conceptos.IntChkIsrRetenido == 1)
                                {
                                    usLib.P05ConceptoAgregarImpuestoRetencion(
                                    baseCalculoImpuesto: baseimporte.ToString(),
                                    impuesto: "001",
                                    tipoFactor: USLib.Cfdv33.c_TipoFactor.Tasa,
                                    tasaOCuota: "0.100000",
                                    importe: rw_conceptos.DblIsrRetenido.ToString(), concepto: c1);
                                }

                                if (CuentaPredial != "")
                                {
                                    usLib.P05ConceptoAgregarCuentaPredial(CuentaPredial, c1);
                                }

                            }

                            usLib.P06ImpuestosCrearResumenPorConceptos();

                            //INICO
                            //En este punto, se pueden incluir los complementos oficiales del SAT
                            /*
                             string QueryRetencionesLocales = "SELECT CR.Descripcion,FR.Importe,CR.Porcentaje FROM FacturaRetencion FR LEFT JOIN CatRetenciones CR ON FR.CveRetencion=CR.CveRetencion WHERE  FR.CveFactura=" + CveFactura;

                             DataTable _dtRetencionesLocales = new DataTable();
                             _dtRetencionesLocales = cm.SP_DataReaderQuery(QueryRetencionesLocales);
                            */

                            if (_ListaDetalleRetencion.Count > 0)
                            {
                                //Complemento al Comprobante Fiscal Digital para Impuestos Locales
                                var impLocal = new USLib.Complementos.Comprobante.ImpLocal.FachadaImpLocal();


                                foreach (DetalleFacturaRetencion rw_locales in _ListaDetalleRetencion)
                                {
                                    //Nodo opcional para la expresión de los impuestos locales retenidos
                                    impLocal.AgregarComplementoImpuestoLocalRetenciones(impLocRetenido:
                                        rw_locales.Descripcion, //["Descripcion"].ToString(), //Nombre del impuesto local retenido
                                        tasadeRetencion: rw_locales.Porcentaje,// decimal.Parse(rw_locales["Porcentaje"].ToString()), //Porcentaje de retención del impuesto local
                                        importe: rw_locales.Importe // decimal.Parse(rw_locales["Importe"].ToString()) //Monto del impuesto local retenido
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

                            string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"];
                            string NombreXml = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura + "_Org.xml";
                            
                            usLib.Cfd.SaveToFile(Destinoxml + @"org\" + NombreXml, "UMBRALLSOFTWARESADECV");

                            //int CveProveedor=GetStrFieldQuery("CvePacTimbrado","Select CvePacTimbrado From CatPacTimbrado Where CvePactimbrado=" + )

                            string UsuarioPac = ""; // cm.GetStrFieldQuery("UsuarioPac", "Select UsuarioPac From Emisores Where CveEmisor=" + CveEmisor);
                            string Contraseña = ""; cm.GetStrFieldQuery("Contrasenia", "Select Contrasenia From Emisores Where CveEmisor=" + CveEmisor);

                            DatosParaTimbrar paraTimbrar = new DatosParaTimbrar
                            {
                                CveFactura = CveFactura,
                                CveEmisor = CveEmisor,
                                CveReceptor = CveReceptor,
                                cvetipofactura = cvetipofactura,
                                RfcEmisor = RfcEmisor,
                                RfcReceptor = RfcReceptor,
                                Destinoxml = Destinoxml,
                                NombreXml = NombreXml,
                                CvePacTimbrado = CvePacTimbrado,
                                UsuarioPac = UsuarioPac,
                                Contraseña = Contraseña,
                                NoCertificado = usLib.Cfd.NoCertificado,
                                Total = Total

                            };
                            _ListaParaTimbrar.Add(paraTimbrar);

                            _result = true;

                        }
                    }
                    else
                    {
                        //MessageBox.Show("El estatus de la factura no es valido, favor de verificar que no haya sido timbrada o cancelada con anterioridad", "Validacion de Datos");
                    }
                }

            }

            return _ListaParaTimbrar;
        }


        public bool TimbrarFactura40(int CveFactura, int CveEmisor, int CveReceptor, int cvetipofactura, string RfcEmisor, string RfcReceptor, string Destinoxml, string NombreXml, int CveProveedor, string usuarioPac = "", string contraseñapac = "", string NoCertificado = "", decimal Total = 0, SqlCommand command=null)
        {
            bool _result = false;

            switch (CveProveedor)
            {
                case 1: //Profact
                    Profact.TimbraCFDI40.Conector conector;

                    
                    if (int.Parse(CredencialPV.Id_CredencialPV1) == 1)
                    {
                        conector = new Profact.TimbraCFDI40.Conector(true);
                        conector.EstableceCredenciales(PasswordPV.Id_PasswordPV1);
                    }
                    else
                    {
                        conector = new Profact.TimbraCFDI40.Conector(false);
                        conector.EstableceCredenciales("mvpNUXmQfK8=");
                    }
                    


                    //Establecemos las credenciales para el permiso de conexión
                    //Ambiente de pruebas = mvpNUXmQfK8=
                    //Ambiente de producción = Esta será asignado por el proveedor al salir a productivo

                    //conector.EstableceCredenciales("mvpNUXmQfK8=");

                    //conector.EstableceCredenciales(PasswordPV.Id_PasswordPV1);

                    //Timbramos el CFDI por medio del conector y guardamos resultado
                    Profact.TimbraCFDI.ResultadoTimbre resultadoTimbre;
                    resultadoTimbre = conector.TimbraCFDI(Destinoxml + @"\org\" + NombreXml);

                    //Verificamos el resultado
                    if (resultadoTimbre.Exitoso)
                    {
                        //El comprobante fue timbrado exitosamente

                        //Guardamos xml cfdi
                        //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                        string NombreFactura = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura;
                        //Helpers.CrearDirectorio(Destinoxml + @"\" + RfcEmisor);
                        string DestinoXML_Nuevo = "";
                        if (cvetipofactura != 7)
                        {
                            Helpers.CrearDirectorio(Destinoxml + @"\Documentos");
                            DestinoXML_Nuevo = Destinoxml + @"\Documentos\";
                        }
                        else
                        {
                            Helpers.CrearDirectorio(Destinoxml + @"\Complementos");
                            DestinoXML_Nuevo = Destinoxml + @"\Complementos\";

                        }

                        if (resultadoTimbre.GuardaXml(DestinoXML_Nuevo, NombreFactura))
                        {
                            //MessageBox.Show("El xml fue guardado correctamente");
                            GuardarXmlCodigo(CveFactura, NombreFactura + ".xml", "Xml", command);
                        }
                        else
                        {
                            //MessageBox.Show("Ocurrió un error al guardar el comprobante");
                        }

                        //Los siguientes datos deberán ir en la respresentación impresa ó PDF

                        //1.- Código bidimensional QR
                        string Destinoqr = ConfigurationManager.AppSettings["RutaTimbrado"] + @"\" + RfcEmisor + @"\QR\";
                        Helpers.CrearDirectorio(Destinoxml );
                        Helpers.CrearDirectorio(Destinoxml + @"\QR");

                        if (resultadoTimbre.GuardaCodigoBidimensional(Destinoqr, NombreFactura))
                        {
                            //MessageBox.Show("El código bidimensional fue guardado correctamente");
                            GuardarQR(CveFactura, Destinoqr + NombreFactura + ".jpg", "QR", "@QRCodigo", command);
                            //GuardarXmlCodigo(CveFactura, NombreFactura + ".jpg", "QR");
                        }
                        else
                        {
                            //MessageBox.Show("Ocurrió un error al guardar el código bidimensional");
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


                        /*
                        string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                        cm.performupdatequery(QueryUpdateFactura);
                        */

                        GuardarXmlCodigo(CveFactura, NombreFactura + ".pdf", "PDF", command);

                        string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                        command.CommandText = QueryUpdateFactura;
                        command.ExecuteNonQuery();

                        //MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       

                        //ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");

                        //Process.Start(Destinoxml + NombreFactura + ".pdf");

                        _result = true;

                    }
                    else
                    {
                        //No se pudo timbrar, mostramos respuesta
                        //MessageBox.Show(resultadoTimbre.Descripcion + ", Detalle: " + resultadoTimbre.Detalle + "Num. Error " + resultadoTimbre.NumeroError);
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
                                    GuardarXmlCodigo(CveFactura, NombreFactura + ".xml", "Xml",command);
                                }
                                else
                                {
                                    //MessageBox.Show("Ocurrió un error al guardar el comprobante");
                                }

                                //Los siguientes datos deberán ir en la respresentación impresa ó PDF

                                //1.- Código bidimensional QR
                                string Destinoqr = ConfigurationManager.AppSettings["RutaQR"];
                                if (resultadoConsulta.GuardaCodigoBidimensional(Destinoqr, NombreFactura))
                                {
                                    //MessageBox.Show("El código bidimensional fue guardado correctamente");
                                    GuardarQR(CveFactura, Destinoqr + NombreFactura + ".jpg", "QR", "@QRCodigo", command);
                                }
                                else
                                {
                                    //MessageBox.Show("Ocurrió un error al guardar el código bidimensional");
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

                                /*
                                string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                                cm.performupdatequery(QueryUpdateFactura, command);
                                */

                                string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                                command.CommandText = QueryUpdateFactura;
                                //cm.performupdatequery(QueryUpdateFactura, command);
                                command.ExecuteNonQuery();

                                //MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GuardarXmlCodigo(CveFactura, NombreFactura + ".pdf", "PDF", command);

                                //ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");


                                _result = true;
                                //MessageBox.Show("Proceso terminado, ahora ya puede imprimir su factura", "Validación de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                //loadDataGrid(this.dataGrid, "SELECT F.CveFactura, UUID, F.CveReceptor, F.CveEmisor, F.CveTipoFactura, F.FechaEmision, R.Nombre AS Cliente, R.RFC, TF.Descripcion AS TipoFactura, F.CveEstatus, CE.Descripcion AS EstatusFactura, E.Nombre AS Emisor, E.RFC As RFCEmisor, F.Total AS ImporteTotal  FROM Facturas F LEFT JOIN Receptores R ON F.CveReceptor=R.CveReceptor LEFT JOIN TipoFactura TF ON F.CveTipoFactura=TF.CveTipoFactura LEFT JOIN CatEstatusFactura CE ON F.CveEstatus=CE.CveEstatus LEFT JOIN Emisores E ON F.CveEmisor=E.CveEmisor Where Tipo=0 ORDER BY 1;");
                                //colorDataGrid(this.dataGrid);

                            }


                        }
                        else
                        {
                            MessageBox.Show(resultadoTimbre.Descripcion + ", Detalle: " + resultadoTimbre.Detalle + "Num. Error " + resultadoTimbre.NumeroError);
                        }
                    }
                    break;
                case 2:  //FEL

                    TimbradoFEL.WSCFDI33Client ServicioTimbrado_FEL = new TimbradoFEL.WSCFDI33Client();

                    TimbradoFEL.RespuestaTFD33 RespuestaTimbrado_FEL = new TimbradoFEL.RespuestaTFD33();


                    //Se carga el XML desde archivo.
                    XmlDocument DocumentoXML = new XmlDocument();
                    //La direccion se sustituira dependiendo de donde se leera el XML.

                    DocumentoXML.Load(Destinoxml + @"org\" + NombreXml);

                    //Variable string que contiene el contenido del XML.
                    string stringXML = null;
                    stringXML = DocumentoXML.OuterXml;
                    RespuestaTimbrado_FEL = ServicioTimbrado_FEL.TimbrarCFDI(usuarioPac, contraseñapac, stringXML, CveFactura.ToString());

                    string RespuestaTimbrado = "";

                    if (RespuestaTimbrado_FEL.OperacionExitosa == true)
                    {
                        // Agregamos datos a la tabla de CFDI


                        //strOriginal = "||" + cVersion + "|" + cUUID + "|" + cFechaTiembre + "|" + cSelloCFD + "|" + cNoCertificado + "||"


                        string CadenaOriginal = "||1.1" + "|" + RespuestaTimbrado_FEL.Timbre.UUID + "|" + RespuestaTimbrado_FEL.Timbre.FechaTimbrado + "|" + RespuestaTimbrado_FEL.Timbre.SelloCFD + "|" + RespuestaTimbrado_FEL.Timbre.NumeroCertificadoSAT + "||"; //CadenaOriginal;
                        string CertificadoEmisor = NoCertificado;
                        string CertificadoSat = RespuestaTimbrado_FEL.Timbre.NumeroCertificadoSAT;
                        ;
                        string FechaEmision = RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString();
                        string FechaCerficacion = RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString();
                        string SCDCFDI = RespuestaTimbrado_FEL.Timbre.SelloCFD;
                        string SCDSAT = RespuestaTimbrado_FEL.Timbre.SelloSAT;
                        string UUID = RespuestaTimbrado_FEL.Timbre.UUID;
                        // pr.CadenaOriginal=RespuestaTimbrado_FEL.Timbre.c

                        if (CveFactura > 0)
                        {
                            string XmlTimbrado = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura;
                            DocumentoXML.LoadXml(RespuestaTimbrado_FEL.XMLResultado);
                            DocumentoXML.Save(Destinoxml + XmlTimbrado + ".xml");
                            GuardarXmlCodigo(CveFactura, XmlTimbrado + ".xml", "Xml",command);

                            //GuardarXmlCodigo_FEL(CveFactura, XmlTimbrado + ".xml", "Xml");

                            //System.Drawing.Image QR = USLib.Utilerias.CBB.GeneradorCbb.GenerarCbbImagen(Total, RfcEmisor, RfcReceptor, UUID);

                            

                            string DestinoQR = ConfigurationManager.AppSettings["RutaTimbrado40"];
                            string NombreQR = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura;

                            string CadenaCbb = USLib.Utilerias.CBB.GeneradorCbb.GenerarCadenaCbb(Total, RfcEmisor, RfcReceptor, UUID);
                            //string CadenaCbb = generadorCbb.GenerarCadenaCbb(Total, RfcEmisor, RfcReceptor, UUID);

                            USLib.Utilerias.CBB.GeneradorCbb.GuardarCbb(CadenaCbb, DestinoQR + @"\QR\" + NombreQR + ".Png", USLib.Utilerias.CBB.FormatoCbb.Png);

                            /*
                            System.Drawing.Image QR = USLib.Utilerias.CBB.GeneradorCbb.GenerarCbbImagen(Total, RfcEmisor, RfcReceptor, UUID);
                            SaveQR(QR, DestinoQR + @"\QR\", NombreQR);
                            */

                            //GuardarQR(CveFactura, DestinoQR + NombreQR + ".jpg", "QR", "@QRCodigo");

                            byte[] _QR= USLib.Utilerias.CBB.GeneradorCbb.GenerarCbbImagenBytes(Total, RfcEmisor, RfcReceptor, UUID);
                            //SaveQR(_QR, DestinoQR + @"\QR\", NombreQR);


                            GuardarQR(CveFactura, _QR,  "QR", "@QRCodigo",command);

                            //GuardarQR_FEL(CveFactura,

                            string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + DateTime.Parse(FechaCerficacion).ToString("s") + "',CadenaOriginal='" + CadenaOriginal + "',UUID='" + UUID + "',SCDCFDI='" + SCDCFDI + "',SCDSAT='" + SCDSAT + "', CertificadoSAT='" + CertificadoSat + "',CertificadoEmisor='" + NoCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                            command.CommandText = QueryUpdateFactura;
                            command.ExecuteNonQuery();
                            //cm.performupdatequery(QueryUpdateFactura);

                            //ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + XmlTimbrado + ".pdf");
                            GuardarXmlCodigo(CveFactura, XmlTimbrado + ".pdf", "PDF",command);
                            _result = true;
                            /*
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = Destinoxml + XmlTimbrado + ".pdf";
                            proc.Start();
                            proc.Close();
                            */
                        }
                        //loadDataGrid(this.dataGrid, "SELECT F.CveFactura, UUID, F.CveReceptor, F.CveEmisor, F.CveTipoFactura, F.FechaEmision, R.Nombre AS Cliente, R.RFC, TF.Descripcion AS TipoFactura, F.CveEstatus, CE.Descripcion AS EstatusFactura, E.Nombre AS Emisor, E.RFC As RFCEmisor, F.Total AS ImporteTotal  FROM Facturas F LEFT JOIN Receptores R ON F.CveReceptor=R.CveReceptor LEFT JOIN TipoFactura TF ON F.CveTipoFactura=TF.CveTipoFactura LEFT JOIN CatEstatusFactura CE ON F.CveEstatus=CE.CveEstatus LEFT JOIN Emisores E ON F.CveEmisor=E.CveEmisor Where Tipo=0 ORDER BY 1;");
                        //colorDataGrid(this.dataGrid);

                        //MessageBox.Show("Timbrado exitoso, Presione Aceptar para continuar", "Validación de Datos");

                    }
                    else
                    {
                        //Se limpia el TextBox
                        //TextBox_RespuestaWS.Clear();

                        //Si la petición fue erronea muestro el error.
                        RespuestaTimbrado = RespuestaTimbrado_FEL.CodigoRespuesta + System.Environment.NewLine;
                        RespuestaTimbrado += RespuestaTimbrado_FEL.MensajeError + System.Environment.NewLine;
                        RespuestaTimbrado += RespuestaTimbrado_FEL.MensajeErrorDetallado + System.Environment.NewLine;
                        //RespuestaTimbrado += RespuestaTimbrado_FEL.Timbre.UUID;
                        MessageBox.Show(RespuestaTimbrado);
                    }


                    break;
            }

            return _result;
        }

       

        public void ExportarReport(int CveFactura, int CveEmisor, int CveReceptor, int CveTipoFactura, string Ruta, SqlCommand command=null, int opcion=0)
        {
            switch (CveTipoFactura)
            {
                case 1:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    /*RptFacturas rptFac = new RptFacturas();
                    rptFac.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), rptFac);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), rptFac);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), rptFac);


                    rptFac.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                    */
                    string NombreFac = cm.GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=" + CveTipoFactura + " AND E.CveEmisor=" + CveEmisor);
                    string extesion = "rpt";
                    string DestinoFac = ConfigurationManager.AppSettings["RutaFactura"] + @"\" + NombreFac + "." + extesion;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRpt.Load(DestinoFac);

                    Page.SetDBLogonForReport(cryRpt);
                    //cryRpt.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord,ServerName.Id_ServerName, BaseDatos.Id_BaseDatos);
                    /*Los parametros los envias de la siguiente forma, el primer valor que pide la Funcion es el nombre del parametro del Reporte y el segundo el valor que le asignas.*/
                    cryRpt.SetParameterValue("@CveEmisor",CveEmisor);
                    cryRpt.SetParameterValue("@CveReceptor",CveReceptor);
                    cryRpt.SetParameterValue("@CveFactura", CveFactura);
                    cryRpt.SetParameterValue("@Opcion", opcion);
                    /*
                    Page.SetParamValueReporte("@CveEmisor", CveEmisor.ToString(), cryRpt);
                    Page.SetParamValueReporte("@CveReceptor", CveReceptor.ToString(), cryRpt);
                    Page.SetParamValueReporte("@CveFactura", CveFactura.ToString(), cryRpt);
                    */
                    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                    
                    break;
                case 2:

                    string NombreHO = pb.GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=2 AND E.CveEmisor=" + CveEmisor);
                    string extesionHO = "rpt";
                    string DestinoHO = ConfigurationManager.AppSettings["RutaFactura"] + NombreHO + "." + extesionHO;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRptHO = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRptHO.Load(DestinoHO);
                    Page.SetDBLogonForReport(cryRptHO);
                    //cryRptHO.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord, ServerName.Id_ServerName, BaseDatos.Id_BaseDatos);
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

                    string NombreArr = pb.GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=3 AND E.CveEmisor=" + CveEmisor);
                    string extesionArr = "rpt";
                    string DestinoArr = ConfigurationManager.AppSettings["RutaFactura"] + NombreArr + "." + extesionArr;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRptArr = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRptArr.Load(DestinoArr);
                    Page.SetDBLogonForReport(cryRptArr);
                    //cryRptArr.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord, ServerName.Id_ServerName, BaseDatos.Id_BaseDatos);
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


        public void GuardarXmlCodigo(int CveFactura, string Ruta, string Campo)
        {
            if (Ruta != null)
            {
                string Query = "Update Facturas Set " + Campo + "='" + Ruta + "' Where CveFactura=" + CveFactura;
                cm.performupdatequery(Query);

                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }
        public void GuardarXmlCodigo(int CveFactura, string Ruta, string Campo, SqlCommand command)
        {
            if (Ruta != null)
            {
                string Query = "Update Facturas Set " + Campo + "='" + Ruta + "' Where CveFactura=" + CveFactura;
                command.CommandText=Query;
                command.ExecuteNonQuery();
                //cm.performupdatequery(Query);

                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }
       
        public void GuardarQR(int CveFactura, string Ruta, string Campo, string Variable)
        {
            if (Ruta != null)
            {
               
                FileStream stream = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                byte[] photo = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();

                
                using (SqlConnection con = new SqlConnection(strconexion))
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "Update Facturas Set " + Campo + "=" + Variable + " Where CveFactura=" + CveFactura;
                    //SqlParameter prm = new SqlParameter(Variable, SqlDbType.Image, photo.Length).Value= photo;
                    cmd2.Parameters.Add(Variable, SqlDbType.Image, photo.Length).Value = photo;
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
                
                /*
                command.CommandText = "Update Facturas Set " + Campo + "=" + Variable + " Where CveFactura=" + CveFactura;
                command.Parameters.Add(Variable, SqlDbType.Image, photo.Length).Value = photo;
                command.ExecuteNonQuery();
                */
                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }
        public void GuardarQR(int CveFactura, string Ruta, string Campo, string Variable, SqlCommand command)
        {
            if (Ruta != null)
            {

                FileStream stream = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                byte[] photo = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();

                /*
                using (SqlConnection con = new SqlConnection(strconexion))
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "Update Facturas Set " + Campo + "=" + Variable + " Where CveFactura=" + CveFactura;
                    //SqlParameter prm = new SqlParameter(Variable, SqlDbType.Image, photo.Length).Value= photo;
                    cmd2.Parameters.Add(Variable, SqlDbType.Image, photo.Length).Value = photo;
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
                */

                
                command.CommandText = "Update Facturas Set " + Campo + "=" + Variable + " Where CveFactura=" + CveFactura;
                command.Parameters.Add(Variable, SqlDbType.Image, photo.Length).Value = photo;
                command.ExecuteNonQuery();
                
                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }
        public void GuardarQR(int CveFactura,  byte[] Qr, string Campo, string Variable, SqlCommand command)
        {
            if (CveFactura !=0)
            {
                /*
                FileStream stream = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                byte[] photo = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();
                */

               


                command.CommandText = "Update Facturas Set " + Campo + "=" + Variable + " Where CveFactura=" + CveFactura;
                command.Parameters.Add(Variable, SqlDbType.Image, Qr.Length).Value = Qr;
                command.ExecuteNonQuery();

                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }
        public static void SaveQR(Image img, string Ruta, string Filename)
        {
            string fileName = Filename;
            string saveDirectory = Ruta;
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
            string fileSavePath = Path.Combine(saveDirectory, fileName);
            Image copy = img;
            copy.Save(fileSavePath, System.Drawing.Imaging.ImageFormat.Png);

        }


        public int SaveFactura40Detalle_DocRelacionado_Cfdi_Pago(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
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

                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveTipoRelacion", item.IntCveTipoRelacion.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_UUID", item.StrUUID, "string"));
                ListParameters.Add(cm.addparametro("p_DescripcionTipoRelacion", item.StrDescripcionTipoRelacion, "string"));


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_CfdiRelacionado");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveCfdiRelacionado"].ToString());
                }

            }




            return CveDetalleFactura;
        }

        public int SaveFactura40Detalle_DocRelacionado_Cfdi(ArrayList ListaParametros, int CveFactura)
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
                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFacturaRelacion", item.intCveFacturaRelacion.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveTipoRelacion", item.IntCveTipoRelacion.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_UUID", item.StrUUID, "string"));
                ListParameters.Add(cm.addparametro("p_DescripcionTipoRelacion", item.StrDescripcionTipoRelacion, "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                ListParameters.Add(cm.addparametro("p_ChkManual", item.ChkManual.ToString(), "int"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_CfdiRelacionado");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveCfdiRelacionado"].ToString());
                }

            }




            return CveDetalleFactura;
        }
        public int SaveFactura40Detalle_DocRelacionado_Cfdi_NC(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Clases.cFacturacion40.DoctoRelacionadoComplemento item in ListaParametros)
            {

                ListParameters.Clear();

                /*
                 * 
                  @CveFactura int,
           @CveTipoRelacion int,
           @UUID varchar(50),
           @DescripcionTipoRelacion varchar(50)

    */
                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFacturaRelacion", item.IntCveFacturaDoctoRelacionado.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveTipoRelacion", item.IntCveTipoRelacion.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_UUID", item.StridDocumento, "string"));
                ListParameters.Add(cm.addparametro("p_DescripcionTipoRelacion", item.StrDescripcionTipoRelacion, "string"));
                ListParameters.Add(cm.addparametro("p_sGuid", item.sGuid, "string"));
                ListParameters.Add(cm.addparametro("p_ChkManual","1", "int"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_CfdiRelacionado");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveCfdiRelacionado"].ToString());
                }

            }




            return CveDetalleFactura;
        }


        public int SaveFactura33Detalle_Complemento(ArrayList ListaParametros, int CveFactura)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (DetalleParametrosFacturaComplemento item in ListaParametros)
            {

                ListParameters.Clear();


                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_FechaPago", item.SrtFechaPago, "string"));
                ListParameters.Add(cm.addparametro("p_FormaPago", item.StrFormaPago, "string"));
                ListParameters.Add(cm.addparametro("p_Moneda", item.StrMoneda, "string"));
                ListParameters.Add(cm.addparametro("p_TipoCambioP", item.StrTipoCambioP, "string"));
                ListParameters.Add(cm.addparametro("p_Monto", item.DcMonto.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_NumOperacion", item.StrNumOperacion, "string"));
                ListParameters.Add(cm.addparametro("p_rfcEmisorCtaOrd", item.StrrfcEmisorCtaOrd, "string"));
                ListParameters.Add(cm.addparametro("p_nomBancoOrdExt", item.StrnomBancoOrdExt, "string"));
                ListParameters.Add(cm.addparametro("p_ctaOrdenante", item.StrctaOrdenante, "string"));
                ListParameters.Add(cm.addparametro("p_rfcEmisorCtaBen", item.StrrfcEmisorCtaBen, "string"));
                ListParameters.Add(cm.addparametro("p_ctaBeneficiario", item.StrctaBeneficiario, "string"));
                /*
                ListParameters.Add(cm.addparametro("tipoCadPago", null, "string"));
                ListParameters.Add(cm.addparametro("certPago", null, "string"));
                ListParameters.Add(cm.addparametro("cadPago", null, "string"));
                ListParameters.Add(cm.addparametro("selloPago", null, "string"));
                */


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_InsertDetalleFacturaComplemento");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFacturaComplemento"].ToString());
                }

            }




            return CveDetalleFactura;
        }
        public int SaveFactura40Detalle_Complemento(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (DetalleParametrosFacturaComplemento item in ListaParametros)
            {

                ListParameters.Clear();


                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_FechaPago", item.SrtFechaPago, "string"));
                ListParameters.Add(cm.addparametro("p_FormaPago", item.StrFormaPago, "string"));
                ListParameters.Add(cm.addparametro("p_Moneda", item.StrMoneda, "string"));
                ListParameters.Add(cm.addparametro("p_TipoCambioP", item.StrTipoCambioP, "string"));
                ListParameters.Add(cm.addparametro("p_Monto", item.DcMonto.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_NumOperacion", item.StrNumOperacion, "string"));
                ListParameters.Add(cm.addparametro("p_rfcEmisorCtaOrd", item.StrrfcEmisorCtaOrd, "string"));
                ListParameters.Add(cm.addparametro("p_nomBancoOrdExt", item.StrnomBancoOrdExt, "string"));
                ListParameters.Add(cm.addparametro("p_ctaOrdenante", item.StrctaOrdenante, "string"));
                ListParameters.Add(cm.addparametro("p_rfcEmisorCtaBen", item.StrrfcEmisorCtaBen, "string"));
                ListParameters.Add(cm.addparametro("p_ctaBeneficiario", item.StrctaBeneficiario, "string"));
                /*
                ListParameters.Add(cm.addparametro("tipoCadPago", null, "string"));
                ListParameters.Add(cm.addparametro("certPago", null, "string"));
                ListParameters.Add(cm.addparametro("cadPago", null, "string"));
                ListParameters.Add(cm.addparametro("selloPago", null, "string"));
                */


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_InsertDetalleFacturaComplemento", connection,transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleFacturaComplemento"].ToString());
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
                ListParameters.Add(cm.addparametro("ISRRetenido", item.ISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("IVARetenido", item.IVaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Timbrado", item.Timbrado.ToString(), "int"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_TimbradoFactura_Complemento");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFactura = int.Parse(rw["CveFactura_Complemento"].ToString());
                }

            }




            return CveFactura;
        }

        public int SaveFactura40Detalle_Complemento_DocRelacionado(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0, CveDetalleFacturaConceptoImpuesto=0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();
            foreach (DoctoRelacionadoComplemento item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFacturaDoctoRelacionado", item.IntCveFacturaDoctoRelacionado.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_idDocumento", item.StridDocumento, "string"));
                ListParameters.Add(cm.addparametro("p_serie", item.Strserie, "string"));
                ListParameters.Add(cm.addparametro("p_folio", item.Strfolio, "string"));
                ListParameters.Add(cm.addparametro("p_monedaDr", item.StrmonedaDr.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_tipoCambioDr", item.StrtipoCambioDr, "string"));
                ListParameters.Add(cm.addparametro("p_metodoPagoDr", item.StrmetodoPagoDr.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_numParcialidad", item.StrnumParcialidad.ToString(), "double"));
                ListParameters.Add(cm.addparametro("p_impSaldoAnt", item.DcimpSaldoAnt.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_impPagado", item.DcimpPagado.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_impSaldoInsoluto", item.DcimpSaldoInsoluto.ToString(), "decimal"));


                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_DoctoRelacionadoComplemento",connection, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleDoctoRelacionadoComplemento"].ToString());
                }


                //cConceptos.v_ImpuestosConceptos v_Impuestos = new cConceptos.v_ImpuestosConceptos();
                foreach (cConceptos.v_ImpuestosConceptos imp in item.ListaImpuestos)
                {
                    ListParameterImpuesto.Clear();

                    DataTable _dtImpuesto = new DataTable();



                    ListParameterImpuesto.Add(cm.addparametro("p_CveDetalleFactura", CveDetalleFactura.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveConcepto", imp.CveConcepto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveImpuesto", imp.CveImpuesto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Importe", imp.ValorImpuesto.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Porcentaje", imp.Porcentaje.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TasaCuota", imp.TasaCuota.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TipoFactor", imp.TipoFactor.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_c_Impuesto", imp.c_Impuesto.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Signo", imp.Signo.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_sGuidHijo", imp.sGuidHijo, "string"));

                    _dtImpuesto = cm.SP_Busca_Reader(ListParameterImpuesto, "SP_InsertDetalleFacturaConceptoImpuesto");

                    foreach (DataRow ri in _dtImpuesto.Rows)
                    {
                        CveDetalleFacturaConceptoImpuesto = int.Parse(ri["CveDetalleConceptoImpuesto"].ToString());


                    }
                }



            }




            return CveDetalleFactura;
        }
        public int SaveFactura33Detalle_Complemento_DocRelacionado(ArrayList ListaParametros, int CveFactura, SqlConnection connection, SqlTransaction transaction)
        {
            int CveDetalleFactura = 0, CveDetalleFacturaConceptoImpuesto=0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            ArrayList ListParameterImpuesto = new ArrayList();
            foreach (DoctoRelacionadoComplemento item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_CveFacturaDoctoRelacionado", item.IntCveFacturaDoctoRelacionado.ToString(), "int"));
                ListParameters.Add(cm.addparametro("p_idDocumento", item.StridDocumento, "string"));
                ListParameters.Add(cm.addparametro("p_serie", item.Strserie, "string"));
                ListParameters.Add(cm.addparametro("p_folio", item.Strfolio, "string"));
                ListParameters.Add(cm.addparametro("p_monedaDr", item.StrmonedaDr.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_tipoCambioDr", item.StrtipoCambioDr, "string"));
                ListParameters.Add(cm.addparametro("p_metodoPagoDr", item.StrmetodoPagoDr.ToString(), "string"));
                ListParameters.Add(cm.addparametro("p_numParcialidad", item.StrnumParcialidad.ToString(), "double"));
                ListParameters.Add(cm.addparametro("p_impSaldoAnt", item.DcimpSaldoAnt.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_impPagado", item.DcimpPagado.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_impSaldoInsoluto", item.DcimpSaldoInsoluto.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("p_Guid", item.sGuid, "string"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_DoctoRelacionadoComplemento", connection,transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveDetalleFactura = int.Parse(rw["CveDetalleDoctoRelacionadoComplemento"].ToString());
                }


                //cConceptos.v_ImpuestosConceptos v_Impuestos = new cConceptos.v_ImpuestosConceptos();
                foreach (cConceptos.v_ImpuestosConceptos imp in item.ListaImpuestos)
                {
                    ListParameterImpuesto.Clear();

                    DataTable _dtImpuesto = new DataTable();



                    ListParameterImpuesto.Add(cm.addparametro("p_CveDetalleDoctoRelacionadoComplemento", CveDetalleFactura.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveFactura", CveFactura.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveConcepto", imp.CveConcepto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_CveImpuesto", imp.CveImpuesto.ToString(), "int"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Importe", imp.ValorImpuesto.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Porcentaje", imp.Porcentaje.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TasaCuota", imp.TasaCuota.ToString(), "decimal"));
                    ListParameterImpuesto.Add(cm.addparametro("p_TipoFactor", imp.TipoFactor.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_c_Impuesto", imp.c_Impuesto.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_Signo", imp.Signo.ToString(), "string"));
                    ListParameterImpuesto.Add(cm.addparametro("p_sGuidHijo", Guid.NewGuid().ToString(), "string"));

                    _dtImpuesto = cm.SP_Busca_Reader(ListParameterImpuesto, "SP_InsertDetalleFacturaConceptoImpuesto", connection, transaction);

                    foreach (DataRow ri in _dtImpuesto.Rows)
                    {
                        CveDetalleFacturaConceptoImpuesto = int.Parse(ri["CveDetalleConceptoImpuesto"].ToString());


                    }
                }



            }




            return CveDetalleFactura;
        }


        public int SaveFactura33_Query(ArrayList ListaParametros)
        {
            int CveFactura = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();
            string Query = "";
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
                ListParameters.Add(cm.addparametro("ISRRetenido", item.ISRRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("IVARetenido", item.IVaRetenido.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Timbrado", item.Timbrado.ToString(), "int"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_TimbradoFactura");

                foreach (DataRow rw in _dt.Rows)
                {
                    CveFactura = int.Parse(rw["CveFactura"].ToString());
                }

            }




            return CveFactura;
        }

        public DataTable GetDatosFacturaReceptor(int CveReceptor)
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

            string Query = "SELECT CveFactura, CveReceptor, FolioInt, FechaEmision, UUID, Total,  0 AS Checked FROM Facturas WHERE CveFactura IN(" + CveFacturas + ") ORDER BY CveFactura";

            DataTable _dtResult = cm.SP_DataReaderQuery(Query);



            return _dtResult;
        }
        public DataTable GetDatosFacturaReceptorPago(int CveReceptor, int option=0)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptor.ToString(), "int"));

            _dt.Clear();
            if (option == 0)
                _dt = cm.SP_Busca_Reader(ListaParametro, "SP_Facturas_Receptor_Pago");
            else
                _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_Facturas_Receptor_Pago");

            string CveFacturas = "";

            foreach (DataRow rw in _dt.Rows)
            {
                CveFacturas = rw["_CveFacturas"].ToString();
            }
            DataTable _dtResult = new DataTable();
            if (option == 0)
            {
                string Query = "SELECT CveFactura As Folio, E.Nombre As Receptor , FechaEmision, UUID, Total " +
                    "FROM Facturas F Left Join Receptores E on  F.CveReceptor=E.CveReceptor  WHERE CveFactura IN(" + CveFacturas + ") ORDER BY CveFactura";
                 _dtResult = cm.SP_DataReaderQuery(Query);
            }
            else
            {
                string Query = "SELECT CveFactura As Folio, E.NOMBRE As Receptor , FechaEmision, UUID, Total " +
                    "FROM Facturas F ,  CLIE01 E WHERE CveFactura IN(" + CveFacturas + ") And trim(E.CCLIE)='" + CveReceptor + "' ORDER BY CveFactura";
                _dtResult = cm.SP_DataReaderQueryMonar(Query);
            }


                



            return _dtResult;
        }
        public DataTable GetDatosFacturaReceptorRelacionado(int CveReceptor, int option = 0)
        {
            ListaParametro.Clear();


           

            _dt.Clear();
            if (option == 0)
            {
                ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptor.ToString(), "int"));
                _dt = cm.SP_Busca_Reader(ListaParametro, "SP_Facturas_Receptor_Relacionado");
            }
            else
            {
                string QueryReceptor = "Select NUM_REG As CveReceptor From CLIE01 " +
                    "Where ltrim(rtrim(CCLIE))='" + CveReceptor + "';";
                string CveReceptorMonar = Page.GetStrFieldQueryMonar("CveReceptor", QueryReceptor);
                ListaParametro.Add(cm.addparametro("_CveReceptor", CveReceptorMonar, "int"));
                _dt = cm.SP_Busca_ReaderMonar(ListaParametro, "SP_Facturas_Receptor_Relacionado");
            }
               

            string CveFacturas = "";

            foreach (DataRow rw in _dt.Rows)
            {
                CveFacturas = rw["_CveFacturas"].ToString();
            }

           
            DataTable _dtResult = new DataTable();

            if (option == 0)
            {
                string Query = "SELECT CveFactura As Folio, E.Nombre As Receptor , FechaEmision, UUID, Total " +
                    "FROM Facturas F Left Join Receptores E on  F.CveReceptor=E.CveReceptor  WHERE CveFactura IN(" + CveFacturas + ") ORDER BY CveFactura";
                _dtResult = cm.SP_DataReaderQuery(Query);
            }
            else
            {
                string Query = "SELECT CveFactura As Folio, E.NOMBRE As Receptor , FechaEmision, UUID, Total " +
                    "FROM Facturas F ,  CLIE01 E WHERE CveFactura IN(" + CveFacturas + ") And RTRIM(LTRIM(E.CCLIE))='" + CveReceptor + "' ORDER BY CveFactura";
                _dtResult = cm.SP_DataReaderQueryMonar(Query);
            }


            return _dtResult;
        }
        public DataTable GetDatosFacturaValidacion(int CveFactura, decimal ImportePagado)
        {
            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("_CveFactura", CveFactura.ToString(), "int"));
            ListaParametro.Add(cm.addparametro("_dcImportePagado", ImportePagado.ToString(), "decimal"));

            _dt.Clear();

            _dt = cm.SP_Busca_Reader(ListaParametro, "SP_FacturasValidasParaComplemento");


            return _dt;
        }

        public ArrayList SaveFacturaCxC(int CveFactura, ArrayList ListaFactura, string strconexion)
        {
            bool _result = false;
            ArrayList _ListaResult = new ArrayList();

            using (SqlConnection connection = new SqlConnection(strconexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted, "SampleTransaction");


                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "CARGO CLIENTES";

                    int CveDocumento = help.Result(connection, transaction);

                    foreach (Parametros item in ListaFactura)
                    {
                        item.CveDocumento = CveDocumento;
                        item.CveTipoDocumento = 2;
                    }

                    //int CveFactura = SaveFactura33(ListaFactura, command, connection, transaction);
                    int CveCuenta = SaveCxC(CveFactura, ListaFactura, command, connection, transaction);
                    if (CveCuenta > 0)
                    {
                        foreach  (cFacturacion.Parametros item in ListaFactura)
                        {
                            item.FechaEmision = Page.SwitchDate(DateTime.Parse(item.FechaEmision).ToShortDateString(), 1);
                            int CveKardexPago = cPorCobrar.GenerarKardexPorCobrarAbono(CveCuenta,CveFactura, ListaFactura,  command, connection, transaction);
                        }
                        

                        transaction.Commit();
                        _result = true;

                        Models.Errors errors = new Models.Errors
                        {
                            MensajeError = CveFactura.ToString(),
                            Result = "Los datos de han guardado con exito",
                            Status = true
                        };

                        _ListaResult.Add(errors);

                    }
                    else
                    {
                        Models.Errors errors = new Models.Errors
                        {
                            MensajeError = "No se guardaron los datos",
                            Result = "Los datos de han guardado con exito",
                            Status = false
                        };
                        _ListaResult.Add(errors);
                    }

                }
                catch (Exception er)
                {

                    Models.Errors errors = new Models.Errors
                    {
                        MensajeError = er.Message + " ," + er.Source + ", " + er.Data,
                        Result = "No se pudo guardar los datos",
                        Status = false
                    };
                    _ListaResult.Add(errors);
                    transaction.Rollback();

                }

            }


            return _ListaResult;
        }
        public ArrayList SaveFacturaCxC_CS(int CveFactura, ArrayList ListaFactura,
            SqlConnection connection , SqlCommand  command, SqlTransaction transaction)
        {
            bool _result = false;
            ArrayList _ListaResult = new ArrayList();

            

                try
                {

                    Helpers help = new Helpers();

                    help.Descripcion = "CARGO CLIENTES";

                    int CveDocumento = help.Result(connection, transaction);

                    foreach (Parametros item in ListaFactura)
                    {
                        item.CveDocumento = CveDocumento;
                        item.CveTipoDocumento = 2;
                    }

                    //int CveFactura = SaveFactura33(ListaFactura, command, connection, transaction);
                    int CveCuenta = SaveCxC(CveFactura, ListaFactura, command, connection, transaction);
                    if (CveCuenta > 0)
                    {
                        foreach (cFacturacion40.Parametros item in ListaFactura)
                        {
                            item.FechaEmision = Page.SwitchDate(DateTime.Parse(item.FechaEmision).ToShortDateString(), 1);
                            int CveKardexPago = cPorCobrar.GenerarKardexPorCobrarAbono(CveCuenta, CveFactura, ListaFactura, command, connection, transaction);
                        }

                        _result = true;

                        Models.Errors errors = new Models.Errors
                        {
                            MensajeError = CveFactura.ToString(),
                            Result = "Los datos de han guardado con exito",
                            Status = true
                        };

                        _ListaResult.Add(errors);

                    }
                    else
                    {
                        Models.Errors errors = new Models.Errors
                        {
                            MensajeError = "No se guardaron los datos",
                            Result = "Los datos de han guardado con exito",
                            Status = false
                        };
                        _ListaResult.Add(errors);
                    }

                }
                catch (Exception er)
                {

                    Models.Errors errors = new Models.Errors
                    {
                        MensajeError = er.Message + " ," + er.Source + ", " + er.Data,
                        Result = "No se pudo guardar los datos",
                        Status = false
                    };
                    _ListaResult.Add(errors);
                    transaction.Rollback();

                }


            return _ListaResult;
        }

        public int SaveCxC(int CveFactura, ArrayList ListaParametros, SqlCommand command, SqlConnection cn, SqlTransaction transaction)
        {
            int  CveCuenta = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {
                /*
                @CveFactura int,
    @CveReceptor int,
    @Fecha Date,
	@FechaVence Date,
    @Importe decimal(18, 2),
	@Saldo decimal(18, 2),
	@CveUser int,
    @CveEstatus int
                */
                ListParameters.Add(cm.addparametro("CveFactura",CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveDocumento", item.CveDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Fecha", Page.SwitchDate(DateTime.Parse(item.FechaEmision).ToShortDateString(),1), "string"));
                ListParameters.Add(cm.addparametro("FechaVence",Page.SwitchDate(DateTime.Parse(item.FechaEmision).AddDays(30).ToShortDateString(),1), "string"));

                ListParameters.Add(cm.addparametro("Importe", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Saldo", item.Total.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("CveUser", item.CveUser.ToString(), "int"));

                ListParameters.Add(cm.addparametro("CveEstatus","1", "int"));
                ListParameters.Add(cm.addparametro("sGuid", item.strGuid, "string"));
                // _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveFacturas", cn, transaction);
                _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveCuentasPorCobrar", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveCuenta = int.Parse(rw["CveCuenta"].ToString());
                }

            }

            return CveCuenta;
        }

        public int SaveCxCAbonos(ArrayList ListaParametros, SqlCommand command, SqlConnection cn, SqlTransaction transaction)
        {
            int CveAbono = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {
                /*
                @CveCuenta int,
	@CveFacturaRelacion int,
	@Fecha Date,
	@Importe decimal(18,2),
	@CveUser int,
	@CveMetodoPago int,
	@CveFormaPago int,
	@Folio int,
	@sGuid varchar(50)
                */
                ListParameters.Add(cm.addparametro("CveCuenta", item.CveCuenta.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveDocumento", item.CveDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFacturaRelacion", item.CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Fecha",item.FechaEmision, "string"));
              
                ListParameters.Add(cm.addparametro("Importe", item.Total.ToString(), "decimal"));
                //ListParameters.Add(cm.addparametro("Saldo", item.NuevoSaldo.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("CveUser", item.CveUser.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveMetodoPago", item.CveMetodoPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFormaPago",item.CveFormaPago.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Folio", item.FolioInt, "int"));
                ListParameters.Add(cm.addparametro("sGuid", item.strGuid, "string"));
                ListParameters.Add(cm.addparametro("NoDocumento", item.NoDocumento, "string"));
                ListParameters.Add(cm.addparametro("CveMoneda", item.CveMoneda.ToString(), "int"));
                ListParameters.Add(cm.addparametro("TipoCambio", item.TipoCambioSat, "decimal"));
                // _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveFacturas", cn, transaction);
                _dt = cm.SP_Busca_Reader(ListParameters, "SP_SaveCuentasPorCobrarAbonos", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveAbono = int.Parse(rw["CveAbono"].ToString());
                }

            }

            return CveAbono;
        }

        public int SaveCxC_Kardex(ArrayList ListaParametros, int CveFactura, int CveCuenta, SqlConnection cn, SqlTransaction transaction)
        {
            int CveKardex = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("CveCuenta", CveCuenta.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveAbono", "0", "int"));
                ListParameters.Add(cm.addparametro("CveDocumento", item.CveDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Folio", item.FolioInt, "int"));
                ListParameters.Add(cm.addparametro("CveTipoDocumento", item.CveTipoDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("FechaMovimiento",item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("Ventas", item.Venta.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Abonos", "0.00", "decimal"));
                ListParameters.Add(cm.addparametro("Saldo", item.NuevoSaldo.ToString(), "decimal"));
          
                ListParameters.Add(cm.addparametro("sGuid", item.strGuid, "string"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_Kardex_Receptor", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveKardex = int.Parse(rw["CveKardex"].ToString());
                }

            }

            return CveKardex;
        }
        public int SaveCxC_KardexCancelado(ArrayList ListaParametros, int CveFactura, int CveCuenta, SqlConnection cn, SqlTransaction transaction)
        {
            int CveKardex = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("CveCuenta", CveCuenta.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveAbono", "0", "int"));
                ListParameters.Add(cm.addparametro("CveDocumento", item.CveDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Folio", item.FolioInt, "int"));
                ListParameters.Add(cm.addparametro("CveTipoDocumento", item.CveTipoDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("FechaMovimiento", item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("Ventas", item.Venta.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Abonos", "0.00", "decimal"));
                ListParameters.Add(cm.addparametro("Saldo", item.NuevoSaldo.ToString(), "decimal"));

                ListParameters.Add(cm.addparametro("sGuid", item.strGuid, "string"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_Kardex_Receptor", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveKardex = int.Parse(rw["CveKardex"].ToString());
                }

            }

            return CveKardex;
        }
        public int SaveCxC_KardexAbonos(ArrayList ListaParametros, int CveFactura, int CveCuenta, SqlConnection cn, SqlTransaction transaction)
        {
            int CveKardex = 0;

            ArrayList ListParameters = new ArrayList();
            ArrayList ListParametersImage = new ArrayList();

            foreach (Parametros item in ListaParametros)
            {

                ListParameters.Clear();

                ListParameters.Add(cm.addparametro("CveCuenta", CveCuenta.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveDocumento", item.CveDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveAbono", item.CveAbono.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveReceptor", item.CveReceptor.ToString(), "int"));
                ListParameters.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
                ListParameters.Add(cm.addparametro("Folio", item.FolioInt, "int"));
                ListParameters.Add(cm.addparametro("CveTipoDocumento", item.CveTipoDocumento.ToString(), "int"));
                ListParameters.Add(cm.addparametro("FechaMovimiento", item.FechaEmision, "string"));
                ListParameters.Add(cm.addparametro("Ventas","0.00", "decimal"));
                ListParameters.Add(cm.addparametro("Abonos", item.Abono.ToString(), "decimal"));
                ListParameters.Add(cm.addparametro("Saldo", item.NuevoSaldo.ToString(), "decimal"));

                ListParameters.Add(cm.addparametro("sGuid", item.strGuid, "string"));

                //ListParametersImage.Add(cm.addparametroImage("QR", item.QR, "Image"));

                _dt = cm.SP_Busca_Reader(ListParameters, "SP_Kardex_Receptor", cn, transaction);

                foreach (DataRow rw in _dt.Rows)
                {
                    CveKardex = int.Parse(rw["CveKardex"].ToString());
                }

            }

            return CveKardex;
        }

        public void GenerarCFDI33_Complemento_Multiple(int IntCveEmisor, ArrayList ListaDatosComplemento, ArrayList ListaDoctoRelacionadoComplemento, int CveAbono=0)
        {

            DataTable _dtComprobante = new DataTable();

            DialogResult result;
            result = DialogResult.Yes; // MessageBox.Show("¿Está seguro que desea Generar y Sellar complemento a la factura actual?", "Sellar Factura - Complemento", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                USLib.FachadaCfdv33 usLib = new USLib.FachadaCfdv33();


                //MessageBox.Show("Presione el botón de aceptar y espere que se certifique su documento...", "Validación de Datos");


                //Este ejemplo está dirigido a aquellos integradores que aún no generan el xml (CFDI)

                //Inicializamos el conector el parámetro indica el ambiente en el que se utilizará 
                //Fasle = Ambiente de pruebas
                //True = Ambiente de producción

                ArrayList ListaParametros = new ArrayList();
                ArrayList ListaDoctosRelacionadosFactura = new ArrayList();
                ArrayList ListaDetalleComplemento = new ArrayList();
                //ArrayList ListaDoctoRelacionadoComplemento = new ArrayList();
                ArrayList ListaDocTipoRelacionFactura = new ArrayList();
                DataTable _dtEmpresa = new DataTable();
                DataTable _dtEmisor = new DataTable();
                DataTable _dtReceptor = new DataTable();
                DataTable _dtDetalles = new DataTable();
                DataTable _dtHeadFactura = new DataTable();
                Clases.cPageBase cp = new Clases.cPageBase();

                /*

                int CveFactura = int.Parse(dataGrid.CurrentRow.Cells["CveFactura"].Value.ToString());
                int CveReceptor = int.Parse(dataGrid.CurrentRow.Cells["CveReceptor"].Value.ToString());
                int CveEmisor = int.Parse(dataGrid.CurrentRow.Cells["CveEmisor"].Value.ToString());
                string RfcEmisor = dataGrid.CurrentRow.Cells["RFCEmisor"].Value.ToString();
                string RfcReceptor = dataGrid.CurrentRow.Cells["RFC"].Value.ToString();
                //string strClaveCta = dataGrid.CurrentRow.Cells["ClaveCta"].Value.ToString();

                */


                string QueryEmisor = "Select CveEmisor, Nombre, RFC, CveRegimen, CP, CveClave, CvePacTimbrado From Emisores Where CveEmisor=" + IntCveEmisor;

                _dtEmisor.Clear();

                _dtEmisor = Page.SP_Busca_Reader_Query(QueryEmisor);

                string LugarExpedicion = "";
                string RFCEmisor = "";
                string NombreEmisor = "";
                string CveClave = "";
                int cvetipofactura = 7; //int.Parse(dataGrid.CurrentRow.Cells["CveTipoFactura"].Value.ToString());
                int CvePacTimbrado = 0;
                string CPExpedido = "";
                string CveRegimen = "";
                foreach (DataRow rw in _dtEmisor.Rows)
                {
                    LugarExpedicion = rw["CP"].ToString();
                    RFCEmisor = rw["RFC"].ToString();
                    NombreEmisor = rw["Nombre"].ToString();
                    CveClave = rw["CveClave"].ToString();
                    CvePacTimbrado = int.Parse(rw["CvePacTimbrado"].ToString());
                    CPExpedido = rw["CP"].ToString();
                    CveRegimen = rw["CveRegimen"].ToString();
                }




                string NombreCert = IntCveEmisor + "_" + RFCEmisor;
                //string CveClave = GetStrFieldQuery("CveClave", "Select CveClave From Emisores Where CveEmisor=" + CveEmisor);
                string url = ConfigurationManager.AppSettings["RutaCertificados"];

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

                //string Query = "SELECT * FROM Facturas  WHERE CveFactura=" + CveFactura;


                // Datos del Complemeto de Pago

                string FolioFac = "", SerieDR = "", UUID = "", SubTotal = "", Total = "", Descuento = "", IvaTotal = "", FolioFacDR = "", MetodoPagoSatDR = ""; DateTime FechaEmision = new DateTime();



                
                DateTime FechaEmisionSat = new DateTime(FechaEmision.Year, FechaEmision.Month, FechaEmision.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);



                
                int IntCveReceptor = 0;
                string cFechaPago = "", cFormaPago = "", cMetodoPago = "", CondicionesPago = "", cUsoCfdi = "",
                    Observaciones = "", cMoneda="", dcTipoCambio="";
                string cNoOperacion = "", cRFCOrdenante = "", cBancoOrdenante = "", cCuentaOrdenante = "", cRfcBeneficiario = "", cBancoBeneficiario = "", cCuentaBeneficiario = "";
                decimal dcTotalPago = 0m;
                int CveFormaPago = 0, CveMetodoPago = 0, CveUsoCfdi = 0, CveFacturaRelacion=0;


                foreach (DatosComplemento item in ListaDatosComplemento)
                {
                    CveFacturaRelacion = item.CveFacturaRelacion;
                    IntCveReceptor = item.IntCveReceptor;
                    cFechaPago = item.cFechaPago;
                    cFormaPago = item.cFormaPago;
                    cMetodoPago = item.cMetodoPago;
                    cUsoCfdi = item.cUsoCfdi;
                    CondicionesPago = item.CondicionesPago;
                    CveFormaPago = item.CveFormaPago;
                    CveMetodoPago = item.CveMetodoPago;
                    CveUsoCfdi=item.CveUsoCfdi;
                    Observaciones = item.Observaciones;
                    cMoneda = item.cMoneda;
                    dcTipoCambio = item.dcTipoCambio.ToString();
                    cNoOperacion = item.cNoOperacion;
                    cRFCOrdenante = item.cRFCOrdenante;
                    cBancoOrdenante = item.cBancoOrdenante;
                    cCuentaOrdenante = item.cCuentaOrdenante;

                    cRfcBeneficiario = item.cRfcBeneficiario;
                    cBancoBeneficiario = item.cBancoBeneficiario;
                    cCuentaBeneficiario = item.cCuentaBeneficiario;

                    dcTotalPago = item.dcTotalPago;

                };


                /*
                FormRestanteFacturaComplementoMultiple Completar = new FormRestanteFacturaComplementoMultiple();
                //Completar.IntCveFactura = CveFactura;
                Completar.IntCveEmisor = int.Parse(radCboEmisor.SelectedValue.ToString());
                IntCveEmisor = int.Parse(radCboEmisor.SelectedValue.ToString());

                if (Completar.ShowDialog() == DialogResult.OK)
                {
                    IntCveReceptor = Completar.IntCveCliente;
                    cFechaPago = Completar.cFechaPago;
                    cFormaPago = Completar.cFormaPago;
                    cMetodoPago = Completar.cMetodoPago;
                    cUsoCfdi = Completar.cUsoCfdi;
                    CondicionesPago = Completar.CondicionesPago;
                    CveFormaPago = Completar.CveFormaPago;
                    CveMetodoPago = Completar.CveMetodoPago;
                    CveUsoCfdi = 22;
                    Observaciones = Completar.Observaciones;
                    cNoOperacion = Completar.cNoOperacion;
                    cRFCOrdenante = Completar.cRFCOrdenante;
                    cBancoOrdenante = Completar.cBancoOrdenante;
                    cCuentaOrdenante = Completar.cCuentaOrdenante;

                    cRfcBeneficiario = Completar.cRfcBeneficiario;
                    cBancoBeneficiario = Completar.cBancoBeneficiario;
                    cCuentaBeneficiario = Completar.cCuentaBeneficiario;

                    dcTotalPago = Completar.dcTotalPago;

                    //ListaDoctosRelacionadosFactura = Completar.ListaRelacionCfdi;


                    ListaDoctosRelacionadosFactura = Completar.ListaRelacionCfdi;
                    ListaDoctoRelacionadoComplemento = Completar.ListaRelacionCfdi_Complemento;

                }
                else
                {
                    MessageBox.Show("No se puedo completar la tarea...intentelo nuevamente", "Validación de Datos");
                    return;
                }





                // FIN
                */



                int Folio = int.Parse(Page.GetStrFieldQuery("FolioInt", "Select FolioInt From CatFolioFacturas Where CveTipoFactura=7 And CveEmisor=" + IntCveEmisor));
                Folio++;
                FolioFac = Folio.ToString();


                DataTable _dtFactura = new DataTable();
                string MonedaRelacion = "", TipoCambioRelacion = "";
                _dtFactura = ConsultaFacturas(CveFacturaRelacion);

                foreach (DataRow item in _dtFactura.Rows)
                {
                    MonedaRelacion = item["Moneda"].ToString();
                    TipoCambioRelacion = item["TipoCambio"].ToString();
                }



                //string TipoComprobante = GetStrFieldQuery("TipoComprobante", "Select TipoComprobante From CatTipoFactura Where CveTipoFactura=" + cvetipofactura);
                //Total = "0.00";// decimal.Parse(rw_gral["Total"].ToString());
                usLib.P01DatosGenerales(
                 serie: "P", //Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres.
            folio: FolioFac, //Atributo opcional para control interno del contribuyente que expresa el folio del comprobante, acepta una cadena de caracteres.
        fecha: DateTime.Now.ToString("s"), //FechaEmision.Date.ToString("s"), //Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante.
        formaPago: null, //GetStrFieldQuery("c_formapago", "Select c_formapago From CatFormaPagoSat Where CveFormaPago=" + rw_gral["CveFormaPago"].ToString()), //Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
        condicionesDePago: null,// rw_gral["CondicionesPago"].ToString(), //Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
        subTotal: "0.00", //rw_gral["SubTotal"].ToString(), //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos.
        descuento: "",// rw_gral["Descuento"].ToString(), //Atributo condicional para representar el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe registrar cuando existan conceptos con descuento.
        moneda: "XXX", //Atributo requerido para identificar la clave de la moneda utilizada para expresar los montos, cuando se usa moneda nacional se registra MXN. Conforme con la especificación ISO 4217.
        tipoCambio:TipoCambioRelacion, //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion.
        total: "0.00",// rw_gral["Total"].ToString(), //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
        tipoDeComprobante: "P", //Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor.
        metodoPago: null,// , //Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF.
        lugarExpedicion: LugarExpedicion, //Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal).
        confirmacion: ""
                );

                /*

                FolioFacDR = rw_gral["FolioInt"].ToString();
                UUID = rw_gral["UUID"].ToString();
                MetodoPagoSatDR = GetStrFieldQuery("c_metodopago", "Select c_metodopago From CatMetodoPagoSat Where CveMetodoPago=" + rw_gral["CveMetodoPago"].ToString());
                SerieDR = rw_gral["Serie"].ToString();
                CPExpedido = rw_gral["CPExpedido"].ToString();
                LugarExpedicion = rw_gral["LugarExpedicion"].ToString();
            */


                /*
                string QuerycfdiRelacionados = "Select * From DetalleTipoRelacionFactura Where CveFactura=" + CveFactura;

                DataTable _dtcfdirelacionados = new DataTable();
                _dtcfdirelacionados = SP_Busca_Reader_Query(QuerycfdiRelacionados);

                foreach (DataRow rw_relacionados in _dtcfdirelacionados.Rows)
                {
                    usLib.P02CfdiRelacionadosAgregarOpcional(
                        relacion: GetStrFieldQuery("c_TipoRelacion", "Select c_TipoRelacion From CatTipoRelacionSat Where CveTipoRelacion=" + rw_relacionados["CveTipoRelacion"].ToString()),
                        uuid: rw_relacionados["UUID"].ToString()
                        );
                }

                */


                foreach (Clases.cFacturacion.CfdiRelacionado _cfdiRelacionado in ListaDoctosRelacionadosFactura)
                {
                    usLib.P02CfdiRelacionadosAgregarOpcional(relacion: _cfdiRelacionado.Str_c_TipoRelacion,
                        uuid: _cfdiRelacionado.StrUUID
                        );


                }




                /*
                string QueryEmisor = "SELECT CveEmisor, Nombre, RFC, CveRegimen, CvePacTimbrado FROM Emisores WHERE CveEmisor=" + CveEmisor;


                _dtEmisor = SP_Busca_Reader_Query(QueryEmisor);

                foreach (DataRow rw_Emisor in _dtEmisor.Rows)
                {
                    CvePacTimbrado = int.Parse(rw_Emisor["CvePacTimbrado"].ToString());
                    usLib.P03Emisor(
                        rfc: rw_Emisor["RFC"].ToString(),
                        nombre: rw_Emisor["Nombre"].ToString(),
                        regimenFiscal: GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + rw_Emisor["CveRegimen"].ToString())
                        );
                }
                */


                //Nodo requerido para expresar la información del contribuyente emisor del comprobante.
                usLib.P03Emisor(
                    rfc: RFCEmisor, //Atributo requerido para registrar la Clave del Registro Federal de Contribuyentes correspondiente al contribuyente emisor del comprobante.
                    nombre: NombreEmisor, //Atributo opcional para registrar el nombre, denominación o razón social del contribuyente emisor del comprobante.
                    regimenFiscal: Page.GetStrFieldQuery("Regimen", "Select Regimen From CatRegimenSat Where CveRegimen=" + CveRegimen) // PERSONA FISICA // "601" // PERSONA FISICA //Atributo requerido para incorporar la clave del régimen del contribuyente emisor al que aplicará el efecto fiscal de este comprobante.
                );


                ListaParametros.Clear();

                ListaParametros.Add(cp.addparametro("_CveCliente", IntCveReceptor.ToString(), "string"));

                _dtReceptor = cp.SP_Busca_Reader(ListaParametros, "SP_GetClienteFacturacion_Complemento");

                string RFCReceptor = "";
                foreach (DataRow rwReceptor in _dtReceptor.Rows)
                {

                    RFCReceptor = rwReceptor["Rfc"].ToString().Replace("-", "");


                    //Nodo requerido para precisar la información del contribuyente receptor del comprobante.
                    usLib.P04Receptor(
                        rfc: rwReceptor["Rfc"].ToString().Replace("-", ""), //Atributo requerido para precisar la Clave del Registro Federal de Contribuyentes correspondiente al contribuyente receptor del comprobante.
                        nombre: rwReceptor["NOMBRE"].ToString(), //Atributo opcional para precisar el nombre, denominación o razón social del contribuyente receptor del comprobante.
                        residenciaFiscal: "", //Atributo condicional para registrar la clave del país de residencia para efectos fiscales del receptor del comprobante, cuando se trate de un extranjero, y que es conforme con la especificación ISO 3166-1 alpha-3. Es requerido cuando se incluya el complemento de comercio exterior o se registre el atributo NumRegIdTrib.
                        numRegIdTrib: "", //Atributo condicional para expresar el número de registro de identidad fiscal del receptor cuando sea residente en el extranjero. Es requerido cuando se incluya el complemento de comercio exterior.
                        usoCfdi: "P01" //Atributo requerido para expresar la clave del uso que dará a esta factura el receptor del CFDI.
                    ); 

                }


                var c1 = usLib.P05ConceptosAgregar(
                   claveProdServ: "84111506", //Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
                   noIdentificacion: "", //Atributo opcional para expresar el número de parte, identificador del producto o del servicio, la clave de producto o servicio, SKU o equivalente, propia de la operación del emisor, amparado por el presente concepto. Opcionalmente se puede utilizar claves del estándar GTIN.
                   cantidad: "1", //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                   claveUnidad: "ACT", //Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                   unidad: "", //Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                   descripcion: "Pago", //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
                   valorUnitario: "0.00", //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
                   importe: "0.00", //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.
                   descuento: ""
                );

                ArrayList ListaDetalleProducto = new ArrayList();
                Clases.cFacturacion40.DetalleParametros dtParametro = new Clases.cFacturacion40.DetalleParametros();
                dtParametro.CveConcepto = 0;
                dtParametro.Cantidad = 1;
                dtParametro.UnidadMedida = "ACT";
                dtParametro.UnidadMedidaSat = "ACT";
                dtParametro.StrClaveUnidadSat = "ACT";
                dtParametro.ClaveProductoServicioSat = "84111506";
                dtParametro.Descripcion = "Pago";
                dtParametro.Descuento = 0;
                dtParametro.PDescuento = 0;
                dtParametro.PrecioUnitario = 0m;
                dtParametro.SubTotal = 0m;
                dtParametro.TotalIva = 0m;
                dtParametro.Total = 0m;

                dtParametro.DblIva = 0;
                dtParametro.IntChkIva = 0;
                dtParametro.IntChkIvaRetenido = 0;
                dtParametro.IntChkIsrRetenido = 0;
                dtParametro.DblIvaRetenido = 0;
                dtParametro.DblIsrRetenido = 0;

                dtParametro.CveIva = 0;
                dtParametro.Nota = "";
                dtParametro.sGuid = Guid.NewGuid().ToString();

                ListaDetalleProducto.Add(dtParametro);


                DateTime _FechaPago = new DateTime();

                _FechaPago = new DateTime(DateTime.Parse(cFechaPago).Year, DateTime.Parse(cFechaPago).Month, DateTime.Parse(cFechaPago).Day, 12, 0, 0);


                var pagos10 = new USLib.Complementos.Comprobante.Pagos10.FachadaPagos10();
                var pago = pagos10.P01AgregarPago(
                    fechaPago: _FechaPago,
                    formaPago: cFormaPago,
                    moneda: cMoneda,
                    tipoCambioP: cMoneda != "MXN" ? decimal.Parse(dcTipoCambio) : 1m,

                    monto: dcTotalPago,
                    numOperacion: cNoOperacion,
                    rfcEmisorCtaOrd: cRFCOrdenante,
                    nomBancoOrdExt: cBancoOrdenante,
                    ctaOrdenante: cCuentaOrdenante,
                    rfcEmisorCtaBen: cRfcBeneficiario,
                    ctaBeneficiario: cCuentaBeneficiario,
                    tipoCadPago: "",
                    certPago: null,
                    cadPago: "",
                    selloPago: null,TipoCambioPSpecified: cMoneda !="MXN" ? true : false
                    );


                Clases.cFacturacion.DetalleParametrosFacturaComplemento cComplemento = new Clases.cFacturacion.DetalleParametrosFacturaComplemento();
                ArrayList arrcComplemento = new ArrayList();
                cComplemento.SrtFechaPago = _FechaPago.ToString("s");
                cComplemento.StrFormaPago = cFormaPago;
                cComplemento.StrMoneda = cMoneda;
                cComplemento.StrTipoCambioP = dcTipoCambio;
                cComplemento.DcMonto = dcTotalPago;
                cComplemento.StrNumOperacion = cNoOperacion;
                cComplemento.StrrfcEmisorCtaOrd = cRFCOrdenante;
                cComplemento.StrnomBancoOrdExt = cBancoOrdenante;
                cComplemento.StrctaOrdenante = cCuentaOrdenante;
                cComplemento.StrrfcEmisorCtaBen = cRfcBeneficiario;
                cComplemento.StrctaBeneficiario = cCuentaBeneficiario;
                cComplemento.StrtipoCadPago = "";
                cComplemento.StrcertPago = null;
                cComplemento.StrcadPago = "";
                cComplemento.StrselloPago = null;

                arrcComplemento.Add(cComplemento);

                string TipoCombioDR = "";
                bool TipoCambioDRS = false;


                foreach (Clases.cFacturacion.DoctoRelacionadoComplemento _doctoRel in ListaDoctoRelacionadoComplemento)
                {

                    
                    //Pago 1 de 1
                    pagos10.P02AgregarDoctoRelacionado(
                        idPago: pago,
                        idDocumento: _doctoRel.StridDocumento,
                        serie: _doctoRel.Strserie,
                        folio: _doctoRel.Strfolio,
                        monedaDr:cMoneda,
                        tipoCambioDr: MonedaRelacion==cMoneda ? "" : dcTipoCambio,
                        metodoPagoDr: _doctoRel.StrmetodoPagoDr,
                        numParcialidad: _doctoRel.StrnumParcialidad,
                        impSaldoAnt: _doctoRel.DcimpSaldoAnt.ToString(),
                        impPagado: _doctoRel.DcimpPagado.ToString(),
                        impSaldoInsoluto: _doctoRel.DcimpSaldoInsoluto.ToString());
                }

                /*

                Clases.cFacturacion.DoctoRelacionadoComplemento cDoctoRelacionado = new Clases.cFacturacion.DoctoRelacionadoComplemento();
                ArrayList arrcDoctoRelacionado = new ArrayList();
                cDoctoRelacionado.IntCveFacturaDoctoRelacionado = CveFactura;
                cDoctoRelacionado.StridDocumento = UUID;
                cDoctoRelacionado.Strserie = SerieDR;
                cDoctoRelacionado.Strfolio = FolioFacDR;
                cDoctoRelacionado.StrmonedaDr = "MXN";
                cDoctoRelacionado.StrtipoCambioDr = "1";
                cDoctoRelacionado.StrmetodoPagoDr = MetodoPagoSatDR;
                cDoctoRelacionado.StrnumParcialidad = "1";
                cDoctoRelacionado.DcimpSaldoAnt = dcTotalPago;
                cDoctoRelacionado.DcimpPagado = dcTotalPago;
                cDoctoRelacionado.DcimpSaldoInsoluto = 0.00m;

                arrcDoctoRelacionado.Add(cDoctoRelacionado);

                */


                pagos10.CerrarCfdv33(cfd: usLib.Cfd);


                string CadenaOriginal = usLib.P07GenerarCadenaOriginal();

                usLib.P08GenerarSelloDigital();

                //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                //string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"] + @"\";
                //string NombreXml = RfcEmisor + "_" + RfcReceptor + "_" + CveFactura + "_Org.xml";

                string Destinoxml = ConfigurationManager.AppSettings["RutaTimbrado"];
                string ER = ConfigurationManager.AppSettings["ERecepcionPago"];
                string NombreXml = RFCEmisor + "_" + RFCReceptor + "_" + ER + "_" + FolioFac + "_Org.xml";

                usLib.Cfd.SaveToFile(Destinoxml + @"org\" + NombreXml, "UMBRALLSOFTWARESADECV");

                //int CveProveedor=GetStrFieldQuery("CvePacTimbrado","Select CvePacTimbrado From CatPacTimbrado Where CvePactimbrado=" + )

                string UsuarioPac = Page.GetStrFieldQuery("UsuarioPac", "Select UsuarioPac From Emisores Where CveEmisor=" + IntCveEmisor);
                string Contraseña = Page.GetStrFieldQuery("Contrasenia", "Select Contrasenia From Emisores Where CveEmisor=" + IntCveEmisor);

                ListaParametros.Clear();

                foreach (DatosComplemento item in ListaDatosComplemento)
                {
                    Clases.cFacturacion40.Parametros pr = new Clases.cFacturacion40.Parametros();
                    //pr.StrClaveCuenta = strClaveCta;
                    pr.CadenaOriginal = ""; // resultadoTimbre.CadenaTimbre;//  "||1.1" + "|" + resultadoTimbre.FolioUUID + "|" + resultadoTimbre.FechaCertificacion + "|" + resultadoTimbre.SelloCFDI + "|" + resultadoTimbre.No_Certificado_SAT + "||"; //CadenaOriginal;
                    pr.CertificadoEmisor = usLib.Cfd.NoCertificado;
                    pr.CertificadoSat = "";//resultadoTimbre.No_Certificado_SAT;
                    pr.CondicionesPago = "";
                    pr.CveEmisor = IntCveEmisor;
                    pr.CveEstatus = 2;

                    pr.LugarExpedicion = LugarExpedicion;
                    pr.StrCPExpedido = CPExpedido;
                    pr.FormaPagoSat = cFormaPago;
                    pr.MetodoPagoSat = cMetodoPago;
                    pr.UsoCfdiSat = cUsoCfdi;
                    pr.CveFormaPago = CveFormaPago;
                    pr.CveMetodoPago = CveMetodoPago;
                    pr.CveUsoCfdi = CveUsoCfdi;
                    pr.CveReceptor = IntCveReceptor;

                    pr.FechaEmision = DateTime.Now.ToString("s");// RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s");
                    pr.FechaCerficacion = ""; //RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s");
                    pr.SCDCFDI = "";// RespuestaTimbrado_FEL.Timbre.SelloCFD;
                    pr.SCDSAT = "";// RespuestaTimbrado_FEL.Timbre.SelloSAT;
                    pr.UUID = "";// RespuestaTimbrado_FEL.Timbre.UUID;
                                 // pr.CadenaOriginal=RespuestaTimbrado_FEL.Timbre.c
                    pr.TipoCambioSat =dcTipoCambio;
                    pr.CveTipoFactura = cvetipofactura;
                    pr.LugarExpedicionSat = LugarExpedicion;
                    pr.FolioInt = FolioFac;
                    pr.NoDocumento = FolioFac;
                    pr.Serie = "P";
                    pr.CveUser = CveUser.Cve_User;
                    pr.Observacion = " ";
                    pr.SubTotal = decimal.Parse(dcTotalPago.ToString());
                    pr.Descuento = decimal.Parse("0");
                    pr.IvaP = 16;
                    pr.IvaTotal = decimal.Parse("0");
                    pr.Total = decimal.Parse(dcTotalPago.ToString());
                    pr.ImporteLetras = USLib.Utilerias.NumeroLetras.NumeroALetras(dcTotalPago, "PESOS", "M.N");
                    pr.TipoComprobanteSat = "I";
                    pr.ImpuestoSat = "002";
                    pr.MonedaSat =cMoneda;
                    pr.PaisSat = "MX";
                    pr.ProveedorCFDI = "0";
                    pr.ISRRetenido = 0;
                    pr.IVaRetenido = 0;

                    pr.Timbrado = 1;
                    pr.strGuid = Guid.NewGuid().ToString();

                    ListaParametros.Add(pr);
                }


                TimbrarFacturaComplemento(IntCveEmisor, IntCveReceptor, cvetipofactura, RFCEmisor, RFCReceptor, Destinoxml, NombreXml, CvePacTimbrado, ListaParametros, ListaDetalleProducto, arrcComplemento, ListaDoctoRelacionadoComplemento, ListaDoctosRelacionadosFactura, UsuarioPac, Contraseña, dcTotalPago.ToString(),0,0, CveAbono);

            }

        }

        void TimbrarFacturaComplemento(int CveEmisor, int CveReceptor, int cvetipofactura, string RfcEmisor, string RfcReceptor, string Destinoxml, string NombreXml, int CveProveedor, ArrayList ListaParametros, ArrayList ListaDetalleProducto, ArrayList arrcComplemento, ArrayList arrcDoctoRelacionado, ArrayList ListaDoctosRelacionadosFactura, string usuarioPac = "", string contraseñapac = "", string NoCertificado = "", decimal Total = 0, int CveFacturaRelacion=0, int CveAbono=0)
        {
            switch (CveProveedor)
            {
                case 1: //Profact
                    Conector conector;
                    if (int.Parse(CredencialPV.Id_CredencialPV1) == 1)
                    {
                        conector = new Conector(true);
                        conector.EstableceCredenciales(PasswordPV.Id_PasswordPV1);
                    }
                    else
                    {
                        conector = new Conector(false);
                        conector.EstableceCredenciales("mvpNUXmQfK8=");
                    }

                    //Establecemos las credenciales para el permiso de conexión
                    //Ambiente de pruebas = mvpNUXmQfK8=
                    //Ambiente de producción = Esta será asignado por el proveedor al salir a productivo

                    //conector.EstableceCredenciales("mvpNUXmQfK8=");


                    string FolioFac = "";
                    



                    //Timbramos el CFDI por medio del conector y guardamos resultado
                    Profact.TimbraCFDI.ResultadoTimbre resultadoTimbre;
                    resultadoTimbre = conector.TimbraCFDI(Destinoxml + @"org\" + NombreXml);

                    //Verificamos el resultado
                    if (resultadoTimbre.Exitoso)
                    {
                        //El comprobante fue timbrado exitosamente

                        foreach (Clases.cFacturacion.Parametros pr in ListaParametros)
                        {


                            pr.CadenaOriginal = resultadoTimbre.CadenaTimbre; // resultadoTimbre.CadenaTimbre;//  "||1.1" + "|" + resultadoTimbre.FolioUUID + "|" + resultadoTimbre.FechaCertificacion + "|" + resultadoTimbre.SelloCFDI + "|" + resultadoTimbre.No_Certificado_SAT + "||"; //CadenaOriginal;
                            //pr.CertificadoEmisor = usLib.Cfd.NoCertificado;
                            pr.CertificadoSat = resultadoTimbre.No_Certificado_SAT;
                            pr.CondicionesPago = "";
                            pr.CveEmisor = CveEmisor;
                            pr.CveEstatus = 2;

                            pr.CveReceptor = CveReceptor;

                            //pr.FechaEmision = ;// RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s");
                            pr.FechaCerficacion = resultadoTimbre.FechaCertificacion; //RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s");
                            pr.SCDCFDI = resultadoTimbre.SelloCFDI;// RespuestaTimbrado_FEL.Timbre.SelloCFD;
                            pr.SCDSAT = resultadoTimbre.SelloSAT;// RespuestaTimbrado_FEL.Timbre.SelloSAT;
                            pr.UUID = resultadoTimbre.FolioUUID;// RespuestaTimbrado_FEL.Timbre.UUID;
                                                                // pr.CadenaOriginal=RespuestaTimbrado_FEL.Timbre.c

                            pr.Timbrado = 1;
                            FolioFac = pr.FolioInt;
                        }


                        int CveFacturaComplemento = 0;

                        Clases.cFacturacion cf = new Clases.cFacturacion();

                        CveFacturaComplemento = cf.SaveFactura33(ListaParametros);

                        if (CveFacturaComplemento > 0)
                        {

                            string QueryCuentasPorCobrar = "Update CuentasPorCobrarAbonos  Set CveEstatus=2,CveEmisor=" + CveEmisor + "," +  
                                " CveFactura=" + CveFacturaComplemento + ", UUID='" + resultadoTimbre.FolioUUID  + "'  Where CveAbono=" + CveAbono;
                            Page.performupdatequery(QueryCuentasPorCobrar);

                            string QueryUpdateFolios = "Update CatFolioFacturas Set FolioInt=" + FolioFac + " Where CveEmisor=" + CveEmisor + " And CveTipoFactura=" + cvetipofactura;
                            Page.performupdatequery(QueryUpdateFolios);

                            int CveDetalleFactura = cf.SaveFactura33Detalle(ListaDetalleProducto, CveFacturaComplemento);
                            int CveDetalleFacturaComplemento = cf.SaveFactura33Detalle_Complemento(arrcComplemento, CveFacturaComplemento);
                            int CveDetalleDoctoRelacionadoComplemento = cf.SaveFactura33Detalle_Complemento_DocRelacionado(arrcDoctoRelacionado, CveFacturaComplemento);
                            int CveDoctoRelacionadoCfdi = cf.SaveFactura33Detalle_DocRelacionado_Cfdi(ListaDoctosRelacionadosFactura, CveFacturaComplemento);


                            //Guardamos xml cfdi
                            //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                            string ER = ConfigurationManager.AppSettings["ERecepcionPago"];
                            string NombreFactura = RfcEmisor + "_" + RfcReceptor + "_" + ER + "_" + CveFacturaComplemento;
                            if (resultadoTimbre.GuardaXml(Destinoxml, NombreFactura))
                            {
                                //MessageBox.Show("El xml fue guardado correctamente");
                                GuardarXmlCodigo(CveFacturaComplemento, NombreFactura + ".xml", "Xml");
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
                                GuardarQR(CveFacturaComplemento, Destinoqr + NombreFactura + ".jpg", "QR", "@QRCodigo");
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


                            /*
                            string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                            performupdatequery(QueryUpdateFactura);
                            */

                            //MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GuardarXmlCodigo(CveFacturaComplemento, NombreFactura + ".pdf", "PDF");

                            ExportarReport(CveFacturaComplemento, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");

                            Process.Start(Destinoxml + NombreFactura + ".pdf");

                            //MessageBox.Show("Proceso terminado, ahora ya puede imprimir su factura", "Validación de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            string NombreReceptor = Page.GetStrFieldQuery("Nombre", "SELECT Nombre FROM Receptores WHERE CveReceptor=" + CveReceptor);
                            //EnviarCorreoAutomatico(2, CveReceptor, NombreReceptor, CveFacturaComplemento);

                            //Page.ActualizarDatos();
                        }

                    }
                    else
                    {
                        //No se pudo timbrar, mostramos respuesta
                        MessageBox.Show(resultadoTimbre.Descripcion + ", " + resultadoTimbre.Detalle);

                        /*
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
                                string Destinoqr = ConfigurationManager.AppSettings["RutaQR"];
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
                                performupdatequery(QueryUpdateFactura);

                                MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GuardarXmlCodigo(CveFactura, NombreFactura + ".pdf", "PDF");

                                ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");



                                MessageBox.Show("Proceso terminado, ahora ya puede imprimir su factura", "Validación de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                ActualizarDatos();

                            }


                        }
                        */
                        ///
                    }
                    break;
                case 2:  //FEL

                    TimbradoFEL.WSCFDI33Client ServicioTimbrado_FEL = new TimbradoFEL.WSCFDI33Client();

                    TimbradoFEL.RespuestaTFD33 RespuestaTimbrado_FEL = new TimbradoFEL.RespuestaTFD33();


                    //Se carga el XML desde archivo.
                    XmlDocument DocumentoXML = new XmlDocument();
                    //La direccion se sustituira dependiendo de donde se leera el XML.

                    DocumentoXML.Load(Destinoxml + @"org\" + NombreXml);

                    //Variable string que contiene el contenido del XML.
                    string stringXML = null;
                    stringXML = DocumentoXML.OuterXml;

                    FolioFac = "";

                    RespuestaTimbrado_FEL = ServicioTimbrado_FEL.TimbrarCFDI(usuarioPac, contraseñapac, stringXML,CveFacturaRelacion.ToString());

                    string RespuestaTimbrado = "";

                    if (RespuestaTimbrado_FEL.OperacionExitosa == true)
                    {
                        // Agregamos datos a la tabla de CFDI

                        foreach (Clases.cFacturacion.Parametros pr in ListaParametros)
                        {


                            pr.CadenaOriginal = "||1.1" + "|" + RespuestaTimbrado_FEL.Timbre.UUID + "|" + RespuestaTimbrado_FEL.Timbre.FechaTimbrado + "|" + RespuestaTimbrado_FEL.Timbre.SelloCFD + "|" + RespuestaTimbrado_FEL.Timbre.NumeroCertificadoSAT + "||"; //CadenaOriginal;
                            pr.CertificadoEmisor = NoCertificado;
                            pr.CertificadoSat = RespuestaTimbrado_FEL.Timbre.NumeroCertificadoSAT;
                            pr.CondicionesPago = "";
                            pr.CveEmisor = CveEmisor;
                            pr.CveEstatus = 2;

                            pr.CveReceptor = CveReceptor;

                            pr.FechaEmision = RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s");
                            pr.FechaCerficacion = RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s"); //RespuestaTimbrado_FEL.Timbre.FechaTimbrado.ToString("s");
                            pr.SCDCFDI = RespuestaTimbrado_FEL.Timbre.SelloCFD;
                            pr.SCDSAT = RespuestaTimbrado_FEL.Timbre.SelloSAT;
                            pr.UUID = RespuestaTimbrado_FEL.Timbre.UUID;
                            // pr.CadenaOriginal=RespuestaTimbrado_FEL.Timbre.c

                            pr.Timbrado = 1;
                            FolioFac = pr.FolioInt;
                        }


                        int CveFacturaComplemento = 0;

                        Clases.cFacturacion cf = new Clases.cFacturacion();

                        CveFacturaComplemento = cf.SaveFactura33(ListaParametros);

                        if (CveFacturaComplemento > 0)
                        {
                            string QueryUpdateFolios = "Update CatFolioFacturas Set FolioInt=" + FolioFac + " Where CveEmisor=" + CveEmisor + " And CveTipoFactura=" + cvetipofactura;
                            Page.performupdatequery(QueryUpdateFolios);

                            int CveDetalleFactura = cf.SaveFactura33Detalle(ListaDetalleProducto, CveFacturaComplemento);
                            int CveDetalleFacturaComplemento = cf.SaveFactura33Detalle_Complemento(arrcComplemento, CveFacturaComplemento);
                            int CveDetalleDoctoRelacionadoComplemento = cf.SaveFactura33Detalle_Complemento_DocRelacionado(arrcDoctoRelacionado, CveFacturaComplemento);
                            int CveDoctoRelacionadoCfdi = cf.SaveFactura33Detalle_DocRelacionado_Cfdi(ListaDoctosRelacionadosFactura, CveFacturaComplemento);


                            //Guardamos xml cfdi
                            //string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                            string ER = ConfigurationManager.AppSettings["ERecepcionPago"];
                            string NombreFactura = RfcEmisor + "_" + RfcReceptor + "_" + ER + "_" + CveFacturaComplemento;

                            DocumentoXML.LoadXml(RespuestaTimbrado_FEL.XMLResultado);
                            DocumentoXML.Save(Destinoxml + NombreFactura + ".xml");

                            GuardarXmlCodigo(CveFacturaComplemento, NombreFactura + ".xml", "Xml");


                            //Los siguientes datos deberán ir en la respresentación impresa ó PDF

                            //1.- Código bidimensional QR

                            //USLib.Utilerias.CBB.GeneradorCbb generadorCbb = new USLib.Utilerias.CBB.GeneradorCbb();


                            string Destinoqr = ConfigurationManager.AppSettings["RutaQR"];// + @"\QR\";

                            string NombreQR = RfcEmisor + "_" + RfcReceptor + "_" + ER + "_" + FolioFac;
                            string CadenaCbb = USLib.Utilerias.CBB.GeneradorCbb.GenerarCadenaCbb(Total, RfcEmisor, RfcReceptor, RespuestaTimbrado_FEL.Timbre.UUID);

                            USLib.Utilerias.CBB.GeneradorCbb.GuardarCbb(CadenaCbb, Destinoqr + NombreQR + ".jpg", USLib.Utilerias.CBB.FormatoCbb.Jpeg);

                            //MessageBox.Show("El código bidimensional fue guardado correctamente");
                            GuardarQR(CveFacturaComplemento, Destinoqr + NombreFactura + ".jpg", "QR", "?QRCodigo");

                            MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GuardarXmlCodigo(CveFacturaComplemento, NombreFactura + ".pdf", "PDF");

                            ExportarReport(CveFacturaComplemento, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");



                            MessageBox.Show("Proceso terminado, ahora ya puede imprimir su factura", "Validación de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //BuscarFactura(0, 1);
                            //ActualizarDatos();
                        }


                    }
                    else
                    {
                        //Se limpia el TextBox
                        //TextBox_RespuestaWS.Clear();

                        //Si la petición fue erronea muestro el error.
                        RespuestaTimbrado = RespuestaTimbrado_FEL.CodigoRespuesta + System.Environment.NewLine;
                        RespuestaTimbrado += RespuestaTimbrado_FEL.MensajeError + System.Environment.NewLine;
                        RespuestaTimbrado += RespuestaTimbrado_FEL.MensajeErrorDetallado + System.Environment.NewLine;
                        //RespuestaTimbrado += RespuestaTimbrado_FEL.Timbre.UUID;
                        MessageBox.Show(RespuestaTimbrado);
                    }


                    break;
            }
        }

        public ArrayList Agregar_DoctoRelacion_Complemento(string _NoDocumento, decimal ImportePagado=0)
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

        public ArrayList Agregar_DatosComplemento(int CveAbono, ArrayList _ListaParametro)
        {
            ArrayList ListaDatosComplemento = new ArrayList();

            DataTable _dtResult = new DataTable();

            cPageBase cPage = new cPageBase();
            _dtResult = cPage.SP_Busca_Reader(_ListaParametro, "SP_DatosComplemento_Adicional");

            foreach (DataRow item in _dtResult.Rows)
            {
                DatosComplemento datos = new DatosComplemento
                {
                    cFormaPago = item["cFormaPago"].ToString(),
                    CondicionesPago = item["Folio"].ToString(),
                    CveFormaPago = int.Parse(item["CveFormaPago"].ToString()),
                    cFechaPago = item["FechaAbono"].ToString(),
                    dcTotalPago = decimal.Parse(item["dcTotalPagado"].ToString()),
                    IntCveReceptor = int.Parse(item["CveReceptor"].ToString()),
                    cUsoCfdi = item["cUsoCfdi"].ToString(),
                    CveUsoCfdi = item["CveUsoCFDI"].ToString()=="" ? 22 : int.Parse(item["CveUsoCFDI"].ToString()),
                    cMetodoPago = item["cMetodoPago"].ToString(),
                    CveMetodoPago = int.Parse(item["CveMetodoPago"].ToString()),
                    cNoOperacion = item["NoDocumento"].ToString(),
                    cMoneda = item["Moneda"].ToString(),
                    dcTipoCambio=decimal.Parse(item["TipoCambio"].ToString()),
                     CveFacturaRelacion=int.Parse(item["CveFacturaRelacion"].ToString()),
                            
                    cRFCOrdenante = " ",
                    cBancoOrdenante = " ",
                    cCuentaOrdenante = " ",

                    cRfcBeneficiario=" ",
                    cBancoBeneficiario=" ",
                    cCuentaBeneficiario=" "
                    
                    
                };
                ListaDatosComplemento.Add(datos);
            }

            return ListaDatosComplemento;
        }

        public DataTable ConsultaFacturas(int CveFactura)
        {
            DataTable _dtResult = new DataTable();

            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
            //ListaParametro.Add(cm.addparametro("_dcImportePagado", ImportePagado.ToString(), "decimal"));



            _dtResult = cm.SP_Busca_Reader(ListaParametro, "SP_ConsultaFacturas");


            return _dtResult;
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

        public DataTable CopyFactura(int CveFactura)
        {
           
           

            DataTable _dtResult = new DataTable();

            ListaParametro.Clear();


            ListaParametro.Add(cm.addparametro("CveFactura", CveFactura.ToString(), "int"));
            //ListaParametro.Add(cm.addparametro("_dcImportePagado", ImportePagado.ToString(), "decimal"));



            _dtResult = cm.SP_Busca_Reader(ListaParametro, "SP_CopyFactura");


            return _dtResult;

        }




    }
}
