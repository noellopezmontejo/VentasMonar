using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMonar.Common.Clases;

namespace VentasMonar.Common.Clases
{
    class cAnaquel
    {
        public int CveAnaquel { get; set; }
        public string Descripcion { get; set; }
        public int opcion { get; set; }
        public string Parametro { get; set; }

        cPageBase pg = new cPageBase();

        public int Save()
        {
            int _result = 0;
            string UUID = Guid.NewGuid().ToString();
            string Query = "Insert Into CatAnaquel(Descripcion, UUID) Values('" + Descripcion + "','" + UUID + "')";

            return _result=pg.SP_QueryExecute(Query);

        }

        public int Update()
        {
            int _result = 0;

            string Query = "Update CatAnaquel Set Descripcion='" + Descripcion + "' Where CveAnaquel=" + CveAnaquel;

            return _result= pg.SP_QueryExecute(Query);

        }
        public DataTable dtAnaquel()
        {
            DataTable _dtResult = new DataTable();

            string Query = string.Empty;

            switch(opcion)
            {
                case 1:
                    Query = "Select * From CatAnaquel Where Descripcion LIKE '%" + Parametro + "%' ORDER BY 1";
                    break;
                case 2:
                    Query = "Select * From CatAnaquel Where CveMarca LIKE '%" + Parametro + "' ORDER BY 1";
                    break;
                default:
                    Query = "Select * From CatAnaquel ";
                    break;
            }

          

            return _dtResult = pg.SP_DataReaderQuery(Query);
        }

        public DataTable ResulQuery ()
        {
            string Query = "Select * From CatAnaquel Where CveAnaquel=" + Parametro;
            DataTable _dtresult = pg.SP_DataReaderQuery(Query);

            return _dtresult;
        }
    }
}
