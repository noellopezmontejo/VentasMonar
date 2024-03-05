using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cVentas
    {
        private decimal cantidad;
        private string cveproducto;
        private string nombre;
        private string clave;
        private string noserie;
        private decimal preciounitario;
        private decimal subtotal;
        private decimal preciototal;
        private decimal flete;
        private decimal descuento;
        private decimal descuentoaplicado;
        private decimal iva;
        private string strconexionC;
        private bool actualizar;
        private int intcvenota;
        private string caracteristicas;
        private decimal preciounitariooriginal;
        private int intCveColor;
        private string strColor;
        private decimal intCantidadDevolucion;
        private decimal pdescuento;
        private string strNoSerie;
        private string strNoMotor;
        private string strNoPedimento;
        private string strNoCajaVel;
        private string strImportadoPor;
        private int intCveAlmacen;
        private int intCveFormaPago;
        private int intCveNotaReferencia2;
        private int intCvePrecio;
        private string strAlmacen;
        private int intPage;
        private int intCveEmpleado;
        private string strNombreEmpleado;
        private decimal adicional;
        private string strNombre2;
        private int intCveTipoP;
        private decimal dblPendiente;
        private decimal dblAfectar;
        private string strFechaVenta;
        private string strNombreCliente;
        private decimal DblTotal;
        private string strEstatus;
        private int intCveEstatusDocumento;
        private int intCveEstatusEntrega;
        private string strEstatusEntrega;
        private int intCveTipoDocumento;
        private string strTipoDocumento;
        private int intSIIVA;
        private decimal dblPIva;
        private string strNoDocumento;
        private string strPoblacion;

        // FechaEntrega, CveChofer, CveUser_Recibe_Pago, Fecha_Recibe_Pago, CveEstatus

        private int intCveDocumento;
        private int intCveEmbarque;
        private string strFechaEntrega;
        private int intCveChofer;
        private int intCveUser_Recibe_Pago;
        private string strFecha_Recibe_Pago;
        private int intCveEstatusEmbarque;
        private string strNombreChofer;
        private string strEstatusEmbarque;
        private int intCveFormaEntrega;
        private string strObservaciones;

        // Doctos Generados despues de la Venta.

        private int intCveNotaGenera;
        private string strNoDocumentoGenerado;

        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public string Cveproducto { get => cveproducto; set => cveproducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Noserie { get => noserie; set => noserie = value; }
        public decimal Preciounitario { get => preciounitario; set => preciounitario = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Preciototal { get => preciototal; set => preciototal = value; }
        public decimal Flete { get => flete; set => flete = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal Descuentoaplicado { get => descuentoaplicado; set => descuentoaplicado = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public string StrconexionC { get => strconexionC; set => strconexionC = value; }
        public bool Actualizar { get => actualizar; set => actualizar = value; }
        public int Intcvenota { get => intcvenota; set => intcvenota = value; }
        public string Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public decimal Preciounitariooriginal { get => preciounitariooriginal; set => preciounitariooriginal = value; }
        public int IntCveColor { get => intCveColor; set => intCveColor = value; }
        public string StrColor { get => strColor; set => strColor = value; }
        public decimal IntCantidadDevolucion { get => intCantidadDevolucion; set => intCantidadDevolucion = value; }
        public decimal Pdescuento { get => pdescuento; set => pdescuento = value; }
        public string StrNoSerie { get => strNoSerie; set => strNoSerie = value; }
        public string StrNoMotor { get => strNoMotor; set => strNoMotor = value; }
        public string StrNoPedimento { get => strNoPedimento; set => strNoPedimento = value; }
        public string StrNoCajaVel { get => strNoCajaVel; set => strNoCajaVel = value; }
        public string StrImportadoPor { get => strImportadoPor; set => strImportadoPor = value; }
        public int IntCveAlmacen { get => intCveAlmacen; set => intCveAlmacen = value; }
        public int IntCveFormaPago { get => intCveFormaPago; set => intCveFormaPago = value; }
        public int IntCveNotaReferencia2 { get => intCveNotaReferencia2; set => intCveNotaReferencia2 = value; }
        public int IntCvePrecio { get => intCvePrecio; set => intCvePrecio = value; }
        public string StrAlmacen { get => strAlmacen; set => strAlmacen = value; }
        public int IntPage { get => intPage; set => intPage = value; }
        public int IntCveEmpleado { get => intCveEmpleado; set => intCveEmpleado = value; }
        public string StrNombreEmpleado { get => strNombreEmpleado; set => strNombreEmpleado = value; }
        public decimal Adicional { get => adicional; set => adicional = value; }
        public string StrNombre2 { get => strNombre2; set => strNombre2 = value; }
        public int IntCveTipoP { get => intCveTipoP; set => intCveTipoP = value; }
        public decimal DblPendiente { get => dblPendiente; set => dblPendiente = value; }
        public decimal DblAfectar { get => dblAfectar; set => dblAfectar = value; }
        public string StrFechaVenta { get => strFechaVenta; set => strFechaVenta = value; }
        public string StrNombreCliente { get => strNombreCliente; set => strNombreCliente = value; }
        public decimal DblTotal1 { get => DblTotal; set => DblTotal = value; }
        public string StrEstatus { get => strEstatus; set => strEstatus = value; }
        public int IntCveEstatusDocumento { get => intCveEstatusDocumento; set => intCveEstatusDocumento = value; }
        public int IntCveEstatusEntrega { get => intCveEstatusEntrega; set => intCveEstatusEntrega = value; }
        public string StrEstatusEntrega { get => strEstatusEntrega; set => strEstatusEntrega = value; }
        public int IntCveTipoDocumento { get => intCveTipoDocumento; set => intCveTipoDocumento = value; }
        public string StrTipoDocumento { get => strTipoDocumento; set => strTipoDocumento = value; }
        public int IntSIIVA { get => intSIIVA; set => intSIIVA = value; }
        public decimal DblPIva { get => dblPIva; set => dblPIva = value; }
        public string StrNoDocumento { get => strNoDocumento; set => strNoDocumento = value; }
        public string StrPoblacion { get => strPoblacion; set => strPoblacion = value; }
        public int IntCveDocumento { get => intCveDocumento; set => intCveDocumento = value; }
        public int IntCveEmbarque { get => intCveEmbarque; set => intCveEmbarque = value; }
        public string StrFechaEntrega { get => strFechaEntrega; set => strFechaEntrega = value; }
        public int IntCveChofer { get => intCveChofer; set => intCveChofer = value; }
        public int IntCveUser_Recibe_Pago { get => intCveUser_Recibe_Pago; set => intCveUser_Recibe_Pago = value; }
        public string StrFecha_Recibe_Pago { get => strFecha_Recibe_Pago; set => strFecha_Recibe_Pago = value; }
        public int IntCveEstatusEmbarque { get => intCveEstatusEmbarque; set => intCveEstatusEmbarque = value; }
        public string StrNombreChofer { get => strNombreChofer; set => strNombreChofer = value; }
        public string StrEstatusEmbarque { get => strEstatusEmbarque; set => strEstatusEmbarque = value; }
        public int IntCveFormaEntrega { get => intCveFormaEntrega; set => intCveFormaEntrega = value; }
        public string StrObservaciones { get => strObservaciones; set => strObservaciones = value; }
        public int IntCveNotaGenera { get => intCveNotaGenera; set => intCveNotaGenera = value; }
        public string StrNoDocumentoGenerado { get => strNoDocumentoGenerado; set => strNoDocumentoGenerado = value; }


        public DataTable GeneraNoVenta()
        {
            DataTable _dtResult=new DataTable();














            return _dtResult;
        }

        public static DataTable ConverToEvento(ArrayList _ListaVentas)
        {

            DataTable events = new DataTable();

            events.Columns.Add(new DataColumn("CveVentas", typeof(int)));
           

            foreach (Models.cVentas itemevent in _ListaVentas)
            {
                events.Rows.Add(itemevent.CveVentas
                    );
            }
            return events;
        }

    }
}
