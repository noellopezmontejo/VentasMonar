using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VentasMonar.Common.Clases
{
    public class cModelos
    {
        public int CveModelo { get; set; }
        public string  CveMarca { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public bool Disponible { get; set; }
        public int Actualiza { get; set; }

        ArrayList ListaParametros = new ArrayList();
        Clases.cPageBase pb = new cPageBase();

        public int Save()
        {
            int result = 0;

            ListaParametros.Add(pb.addparametro("CveModelo", CveModelo.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("CveMarca", CveMarca.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("Descripcion", Descripcion, "string"));
            ListaParametros.Add(pb.addparametro("Observaciones", Observaciones.ToString(), "string"));
            ListaParametros.Add(pb.addparametro("Disponible", Disponible.ToString(), "bool"));
            ListaParametros.Add(pb.addparametro("Actualiza", Actualiza.ToString(), "int"));




            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveModelo");

            foreach (DataRow rw in _dt.Rows)
            {
                result = (int)rw["Resultado"];
            }

            return result;





            return result;
        }



    }
}
