using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMonar.Common.Clases;

namespace VentasMonar.Common.Clases
{
    public class cNotaCredito
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

        public int AgregarMovimiento()
        {
            int CveMovimiento = 0;

            Sys_GUID = Guid.NewGuid().ToString("N").ToUpper();

            IntCveCuenta = ObtenerNoCuenta();

            AgActualizaEstatus();

            switch(IntNumeroCaso)
            {
                case 1: // Notas de Credito de Contado
                    AgMovimientoPagos("Notas de Credito Devolucion o Descuento");
                    AgMovimientos("Notas de Credito Devolucion o Descuento");
                    AgNotaCreditoMetodoPago();
                    break;
                case 2: // Notas de Credito Abono a cuenta
                    AgCreditoClienteNotaCredito();
                    break;
                case 3: // Notas de Credito Abono y Contado
                    AgMovimientoPagos("Notas de Credito Devolucion o Descuento");
                    AgMovimientos("Notas de Credito Devolucion o Descuento");
                    AgNotaCreditoMetodoPago();

                    AgCreditoClienteNotaCredito();

                    break;

                case 4: // Notas de Credito opcion mantener para otra venta

                    AgNotaCreditoMantener();

                    break;

            }

            
            

            return CveMovimiento;
        }


        private void AgMovimientoPagos(string DescripcionMovimiento="No definido")
        {
           
            string DescripcionPaquete = DescripcionMovimiento; //GetStrFieldQuery("Descripcion", "Select Descripcion From PaqueteCliente Where CvePaqueteCliente=" + CveNotaReferencia);
            string FechaAbono = cp.SwitchDate(cp.ObtenerFechaHora(1), 1);

            //decimal PagoImporteTotal = DcImporteTotal; // double.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency);
            string QueryMovimiento = "Insert Into MovimientoPagos(CveCliente, Fecha, ImportePagado, CveUser, CveEstatus, CveTipoPago, Descripcion, NoDocumento, Sys_GUID) Values(";
            QueryMovimiento += IntCveCliente + ",'" + FechaAbono + "'," + DcImporteTotal + "," + IntCveUser + ",1,3,'" + DescripcionPaquete + "','" + StrNoDocumento + "','" + Sys_GUID + "')";
            // = cp.performinsertquery(QueryMovimiento);

            IntCveMovimiento = cp.performinsertquery(QueryMovimiento);

        }

        private void AgCreditoClienteNotaCredito()
        {



            string QueryCreditoClienteNotaCredito = "Insert Into CreditoClienteNotaCredito(CveDocumento, CveDocumentoParent, Importe, CveCuenta, CveEstatus) Values(" +
                                                    IntCveDocumento + "," + IntCveDocumentoParent + "," + DcImporteTotal + "," + IntCveCuenta + ",1)";

            cp.performinsertquery(QueryCreditoClienteNotaCredito);
        }

        private void AgMovimientos(string DescripcionMovimiento="No definido")
        {
            foreach (cPagoRemision.cFormaPago item in ArrListaPagos)
            {

                if (item.Importe > 0)
                {

                    string QueryMovimiento = "Insert Into Movimientos(Importe, CveMovimientoPagos, Descripcion, Tipo, CveEstatus, CveMetodoPago, CveCaja, CveCierre, CveUser, Aplicado) Values("
                                           + item.Importe + "," + IntCveMovimiento + ",'" + DescripcionMovimiento +"',2,1," + item.CveFormPago + "," + IntCveCaja + "," + IntCveCierre + "," + IntCveUser + ",0)";

                    cp.performinsertquery(QueryMovimiento);


                }

            }
        }
        private void AgNotaCreditoMetodoPago()
        {
            foreach (cPagoRemision.cFormaPago item in ArrListaPagos)
            {

                if (item.Importe > 0)
                {

                   
                    string QueryNotadeCreditoMetodoPago = "Insert Into NotadeCreditoMetodoPago(CveDocumento, CveMetodoPago, Importe, ImporteRealizado) Values(" +
                                                           IntCveDocumento + "," + item.CveFormPago + "," + item.Importe + "," + item.Importe + ")";

                    cp.performinsertquery(QueryNotadeCreditoMetodoPago);

                }

            }
        }
        private void AgNotaCreditoMantener()
        {
            string QueryUpdateMantener = "Update Ventas set CveMantener=1 Where CveNota=" + IntCveDocumento;

            cp.SP_QueryExecute(QueryUpdateMantener);

        }
        private void AgActualizaEstatus()
        {
            string QueryEstatus= "Update Ventas Set CveEstatusDocumento = " + IntCveEstatus + " Where CveNota = " + IntCveDocumento;
            cp.SP_QueryExecute(QueryEstatus);
        }
        public int ObtenerNoCuenta()
        {
            int CveCuenta=0, Cuenta=0;

            DataTable _dtCuenta = new DataTable();

            string Query = "select Count(*) As Cuenta From CuentasPorCobrar Where CveDocumento=" + IntCveDocumentoParent;

             _dtCuenta= cp.SP_DataReaderQuery(Query);

            foreach (DataRow item in _dtCuenta.Rows)
            {
                Cuenta = int.Parse(item["Cuenta"].ToString());

            }
            _dtCuenta.Dispose();

            if(Cuenta>0)
            {
                string QueryCuenta = "Select Cvecuenta From CuentasPorCobrar Where CveDocumento=" + IntCveDocumentoParent;

                _dtCuenta = cp.SP_DataReaderQuery(QueryCuenta);

                foreach (DataRow item in _dtCuenta.Rows)
                {
                    IntCveCuenta = int.Parse(item["CveCuenta"].ToString());
                }

                
            }


            return CveCuenta;
        }
    }
}
