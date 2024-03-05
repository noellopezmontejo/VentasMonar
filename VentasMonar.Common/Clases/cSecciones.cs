using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cSecciones
    {
        public int CveSeccion { get; set; }
        public int CveModelo { get; set; }
        public string Descripcion{ get; set; }
        public bool Disponible { get; set; }
        public int Actualiza { get; set; }
        public string NombreArchivo { get; set; }

        ArrayList ListaParametros = new ArrayList();
        Clases.cPageBase pb = new cPageBase();
        public int Save()
        {
            int result = 0;

            ListaParametros.Add(pb.addparametro("Actualiza", Actualiza.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("CveSeccion", CveSeccion.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("CveModelo", CveModelo.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("Descripcion",Descripcion, "string"));
            ListaParametros.Add(pb.addparametro("NombreArchivo", NombreArchivo, "string"));
            ListaParametros.Add(pb.addparametro("Disponible", Disponible.ToString(), "bool"));



            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveSecciones");

            foreach (DataRow rw in _dt.Rows)
            {
                result = (int)rw["Resultado"];
            }

            return result;


            return result;
        }


    }
}
