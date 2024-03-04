using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMonar.Desktop.Clases;

namespace VentasMonar.Desktop.Clases
{
    class cTraspaso
    {

        public string Descripcion { get; set; }
        public int Folio { get; set; }

        ArrayList ListParametro = new ArrayList();

        cPageBase cPage = new cPageBase();

        public int Result(SqlConnection connection, SqlTransaction transaction)
        {
            int _Resultado = 0;

            DataTable _dtResult = new DataTable();

            ListParametro.Add(cPage.addparametro("Descripcion", Descripcion, "string"));
            //ListParametro.Add(cPage.addparametro("NoDocumento", "0", "string"));

            _dtResult = cPage.SP_Busca_Reader(ListParametro, "SP_GetFolio", connection,transaction);

            foreach (DataRow rw in _dtResult.Rows)
            {
                _Resultado = int.Parse(rw["Folio"].ToString());
            }


            return _Resultado;
        }



    }
}
