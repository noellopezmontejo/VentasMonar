using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cFacturacionMonar
    {

        

        public static DataTable dt_DetailResult(string CveDocumento)
        {
            cPageBase cPage = new cPageBase();

            ArrayList ListaParametros = new ArrayList();

            ListaParametros.Add(cPage.addparametro("CveDocumento", CveDocumento, "string"));
           
            ListaParametros.Add(cPage.addparametro("CveDocumento", CveDocumento, "string"));
           DataTable _dtDetalles = cPage.SP_Busca_ReaderMonar(ListaParametros, "SP_GetDetalleFactura");

            //decimal SubTotalGral = 0, TotalGral = 0, DescuentoGral = 0, IvaTotalGral = 0;

            return _dtDetalles;

        }

    }
}
