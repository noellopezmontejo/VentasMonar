using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cRecepcionPago
    {
        private int intCveFactura;




        public int IntCveFactura { get => intCveFactura; set => intCveFactura = value; }

        public DataTable GetDatosFacturaAnterior()
        {
            DataTable _dtResult = new DataTable();

            string Query = "Select NoDocumento, FolioInt, Fecha, FechaEmision, FechaCertificacion, CveEstatus, R.NUM_REG, R.NOMBRE, F.CondicionesPago, F.UUID, F.Total From Facturas F Left Join CLIE01 R on F.CveReceptor=R.NUM_REG Left Join CatMetodoPagoSat CMSat on F.CveMetodoPago=CMSat.CveMetodoPago Left Join CatFormaPagoSat CFSat on F.CveFormaPago=CFSat.CveFormaPago Where CveFactura=" + intCveFactura; 





            return _dtResult;
        }



    }
}
