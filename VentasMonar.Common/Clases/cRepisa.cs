using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Desktop.Clases
{
    class cRepisa
    {

        public int CveRepisa { get; set; }
        public string Descripcion { get; set; }
        public int opcion { get; set; }
        public string Parametro { get; set; }

        cPageBase pg = new cPageBase();

        public int Save()
        {
            int _result = 0;
            string UUID = Guid.NewGuid().ToString();
            string Query = "Insert Into CatRepisa(Descripcion, UUID) Values('" + Descripcion + "','" + UUID + "')";

            return _result = pg.SP_QueryExecute(Query);

        }

        public int Update()
        {
            int _result = 0;

            string Query = "Update CatRepisa Set Descripcion='" + Descripcion + "' Where CveRepisa=" + CveRepisa;

            return _result = pg.SP_QueryExecute(Query);

        }

        public DataTable dtRepisa()
        {
            DataTable _dtResult = new DataTable();

            string Query = string.Empty;

            switch (opcion)
            {
                case 1:
                    Query = "Select * From CatRepisa Where Descripcion LIKE '%" + Parametro + "%' ORDER BY 1";
                    break;
                case 2:
                    Query = "Select * From CatRepisa Where CveMarca LIKE '%" + Parametro + "' ORDER BY 1";
                    break;
                default:
                    Query = "Select * From CatRepisa Order by 1";
                    break;
            }



            return _dtResult = pg.SP_DataReaderQuery(Query);
        }

        public DataTable ResulQuery()
        {
            string Query = "Select * From CatRepisa Where CveRepisa=" + Parametro;
            DataTable _dtresult = pg.SP_DataReaderQuery(Query);

            return _dtresult;
        }

    }
}
