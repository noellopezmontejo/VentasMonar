using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cKardex
    {

        public int CveKardex { get; set; }
        public int CveAlmacen { get; set; }
        public int CveProducto { get; set; }
        public int CveDocumento { get; set; }
        public int CveTipoDocumento { get; set; }
        public Decimal Entrada { get; set; }
        public Decimal Salida { get; set; }
        public Decimal Saldo { get; set; }
        public Decimal UltimoCosto { get; set; }
        public Decimal CostoPromedio { get; set; }
        public DateTime Fecha { get; set; }


        public static cKardex UltimoKardex(int CveAlmacen, int CveProducto)
        {
            cKardex kardex = null;
            cPageBase cPage = new cPageBase();

            string QueryUltimoKardex = "Select * From Kardex Where CveAlmacen=1 And CveProducto=1 And CveKardex=(Select Max(CveKardex) From Kardex Where CveAlmacen=1 And CveProducto=1)";
            DataTable _dtResult = cPage.SP_DataReaderQuery(QueryUltimoKardex);

            if(_dtResult.Rows.Count==0)
            {
                return kardex;
            }

            DataRow miRegistro = (DataRow) _dtResult.Rows[0];

            kardex = new cKardex();

            kardex.CostoPromedio = (Decimal) miRegistro["CostoPromedio"];
            kardex.CveAlmacen=(int)miRegistro["CveAlmacen"];
            kardex.CveDocumento = (int)miRegistro["CveDocumento"];
            kardex.CveKardex = (int)miRegistro["CveKardex"];
            kardex.CveProducto = (int)miRegistro["CveProducto"];
            kardex.CveTipoDocumento = (int)miRegistro["CveTipoDocumento"];
            kardex.Saldo = (Decimal)miRegistro["Saldo"];
            kardex.Salida = (Decimal)miRegistro["Salida"];
            kardex.UltimoCosto = (Decimal)miRegistro["UltimoCosto"];
            kardex.Fecha = (DateTime)miRegistro["Fecha"];

            return kardex;
        }
            


    }
}
