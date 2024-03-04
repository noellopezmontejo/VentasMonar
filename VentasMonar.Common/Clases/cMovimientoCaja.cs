using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Desktop.Clases
{
    public class cMovimientoCaja
    {
        cPageBase cp = new cPageBase();

        private decimal dcImporteTotal;
        private int intCveCliente;
        private int intCveUser;
        private string strNoDocumento;
        private int intCveCaja;
        private int intCveCierre;
        private int intCveDocumento;
        private int intCveCuenta;
        private int intNumeroCaso;
        private int intCveMovimiento;
        private int intCveEstatus;
        private int intCveDocumentoParent;
        private string sys_GUID;
        private int intCveConcepto;
        private int intCveTipoMovimiento;
        private int intCveMetodoPago;
       
        private ArrayList arrListaPagos;

        public decimal DcImporteTotal { get => dcImporteTotal; set => dcImporteTotal = value; }
        public int IntCveCliente { get => intCveCliente; set => intCveCliente = value; }
        public int IntCveUser { get => intCveUser; set => intCveUser = value; }
        public string StrNoDocumento { get => strNoDocumento; set => strNoDocumento = value; }
        public ArrayList ArrListaPagos { get => arrListaPagos; set => arrListaPagos = value; }
        public int IntCveCaja { get => intCveCaja; set => intCveCaja = value; }
        public int IntCveCierre { get => intCveCierre; set => intCveCierre = value; }
        public int IntCveDocumento { get => intCveDocumento; set => intCveDocumento = value; }
        public int IntCveCuenta { get => intCveCuenta; set => intCveCuenta = value; }
        public int IntNumeroCaso { get => intNumeroCaso; set => intNumeroCaso = value; }
        public int IntCveMovimiento { get => intCveMovimiento; set => intCveMovimiento = value; }
        public int IntCveEstatus { get => intCveEstatus; set => intCveEstatus = value; }
        public int IntCveDocumentoParent { get => intCveDocumentoParent; set => intCveDocumentoParent = value; }
        public string Sys_GUID { get => sys_GUID; set => sys_GUID = value; }
        public int IntCveConcepto { get => intCveConcepto; set => intCveConcepto = value; }
        public int IntCveTipoMovimiento { get => intCveTipoMovimiento; set => intCveTipoMovimiento = value; }
        public int IntCveMetodoPago { get => intCveMetodoPago; set => intCveMetodoPago = value; }

        public bool Save()
        {
            bool _result = false;

            string FechaAbono = cp.SwitchDate(cp.ObtenerFechaHora(1), 1);

            IntCveTipoMovimiento = int.Parse(cp.GetStrFieldQuery("CveTipo", "Select CveTipo From catconceptosnotacargo Where CveConcepto=" + IntCveConcepto));

            Sys_GUID = Guid.NewGuid().ToString("N").ToUpper();

            AgMovimientoPagos("Movimiento de Caja");

            string insertCuentaPorCobrar = "INSERT INTO NotasCargo ( Documento, Fecha, CveConcepto, Importe,  CveUser, CveMovimientosPago) VALUES (";
            insertCuentaPorCobrar += "'" + StrNoDocumento+ "','" + FechaAbono + "'," + IntCveConcepto + "," + DcImporteTotal + "," + IntCveUser + "," + IntCveMovimiento + ")";

            int inserted = cp.performinsertquery(insertCuentaPorCobrar);


            AgMovimientos();


            return _result;
        }
        private void AgMovimientoPagos(string DescripcionMovimiento="No definido")
        {

            string DescripcionPaquete = DescripcionMovimiento; //GetStrFieldQuery("Descripcion", "Select Descripcion From PaqueteCliente Where CvePaqueteCliente=" + CveNotaReferencia);
            string FechaAbono = cp.SwitchDate(cp.ObtenerFechaHora(1), 1);                                                                           

            //decimal PagoImporteTotal = DcImporteTotal; // double.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency);
            string QueryMovimiento = "Insert Into MovimientoPagos(CveCliente, Fecha, ImportePagado, CveUser, CveEstatus, CveTipoPago, Descripcion, NoDocumento, Sys_GUID) Values(";
            QueryMovimiento += IntCveCliente + ",'" + FechaAbono + "'," + DcImporteTotal + "," + IntCveUser + ",1,7,'" + DescripcionPaquete + "','" + StrNoDocumento + "','" + Sys_GUID + "')";
            // = cp.performinsertquery(QueryMovimiento);

            IntCveMovimiento = cp.performinsertquery(QueryMovimiento);

        }
        private void AgMovimientos(string DescripcionMovimiento="No definido")
        {
            
                if (DcImporteTotal > 0)
                {

                    string QueryMovimiento = "Insert Into Movimientos(Importe, CveMovimientoPagos, Descripcion, Tipo, CveEstatus, CveMetodoPago, CveCaja, CveCierre, CveUser, Aplicado) Values("
                                           + DcImporteTotal + "," + IntCveMovimiento + ",'" + DescripcionMovimiento + "'," + IntCveTipoMovimiento + ",1," + IntCveMetodoPago + "," + IntCveCaja + "," + IntCveCierre + "," + IntCveUser + ",0)";

                    cp.performinsertquery(QueryMovimiento);


                }

        }
    }

    


}
