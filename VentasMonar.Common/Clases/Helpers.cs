using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    class Helpers
    {
        public string Descripcion { get; set; }
        public int Folio { get; set; }

       

        cPageBase cPage = new cPageBase();

        public int Result(SqlConnection connection, SqlTransaction transaction)
        {
            int _Resultado = 0;

            DataTable _dtResult = new DataTable();

            ArrayList ListParametro = new ArrayList();

            ListParametro.Add(cPage.addparametro("Descripcion", Descripcion, "string"));
            //ListParametro.Add(cPage.addparametro("NoDocumento", "0", "string"));

            _dtResult = cPage.SP_Busca_Reader(ListParametro, "SP_GetFolio", connection, transaction);

            foreach (DataRow rw in _dtResult.Rows)
            {
                _Resultado = int.Parse(rw["Folio"].ToString());
            }
                                                  
            return _Resultado;
        }

        public static decimal calc_fatyd(decimal p1, decimal i1, decimal d1, decimal c1)
        {
            return calc_impo(c1, calc_civa(p1, i1)) - calc_fatyi(p1, i1, d1, c1);
        }
        public static decimal calc_fatyi(decimal p1, decimal i1, decimal d1, decimal c1)
        {
            return calc_impo(c1, calc_fatyf(p1, i1, d1));
        }

        public static decimal calc_fatyf(decimal p1, decimal i1, decimal d1)
        {
            return calc_civa(p1, i1) - calc_desc(calc_civa(p1, i1), d1);

        }

        public static decimal calc_desc(decimal p , decimal d)
        {
            return Math.Round(p * d, 0) / 100;
        }

        public static decimal calc_civa(decimal m, decimal i)
        {
            return Math.Round(m*(100+i), 0) / 100;
        }
        public static decimal calc_siva(decimal m, decimal i)
        {
            return Math.Round(m * 100 / (1 + i / 100), 0) / 100;
        }

        public static decimal calc_impo(decimal c, decimal p)
        {
            return Math.Round(c * p, 2);
        }

        public static bool CrearDirectorio(string ruta)
        {
            bool result = false;

            if (!Directory.Exists(ruta))
            {
                DirectoryInfo directory = Directory.CreateDirectory(ruta);
                result = true;
            }

            return result;
        }

    }
}
