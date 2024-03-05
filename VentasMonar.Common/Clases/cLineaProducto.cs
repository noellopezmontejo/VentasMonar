using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cLineaProducto
    {

        public int CveLinea { get; set; }
        public string CveCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public bool Disponible { get; set; }
        public string NombreImagen { get; set; }
        public int Actualiza { get; set; }

        ArrayList ListaParametros = new ArrayList();
        Clases.cPageBase pb = new cPageBase();

        public int Save()
        {
            int result = 0;

            ListaParametros.Add(pb.addparametro("CveLinea", CveLinea.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("CveCategoria", CveCategoria.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("Descripcion", Descripcion, "string"));

            ListaParametros.Add(pb.addparametro("Observaciones", Observaciones.ToString(), "string"));
            ListaParametros.Add(pb.addparametro("Disponible", Disponible.ToString(), "bool"));
            ListaParametros.Add(pb.addparametro("NombreImagen", NombreImagen.ToString(), "string"));
            ListaParametros.Add(pb.addparametro("Actualiza", Actualiza.ToString(), "int"));




            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveLinea");

            foreach (DataRow rw in _dt.Rows)
            {
                result = (int)rw["Resultado"];
            }

            return result;





            return result;
        }





    }
}
