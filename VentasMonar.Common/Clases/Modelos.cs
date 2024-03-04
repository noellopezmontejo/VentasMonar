using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMonar.Desktop.Clases;

namespace VentasMonar.Desktop.Clases
{
    public class Modelos
    {
        public int CveModelo { get; set; }
        public int CveMarca { get; set; }
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        public string Observaciones { get; set; }
        public bool Estatus { get; set; }



        ArrayList ListaParametros = new ArrayList();
        Clases.cPageBase pb = new cPageBase();
        public int Save()
        {
            int cveModelo =0;

            ListaParametros.Add(pb.addparametro("CveMarca", CveMarca.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("Descripcion", Descripcion, "string"));
            ListaParametros.Add(pb.addparametro("ImagePath", ImagePath.ToString(), "string"));
            ListaParametros.Add(pb.addparametro("Observaciones", Observaciones.ToString(), "string"));
            ListaParametros.Add(pb.addparametro("Estatus", Estatus.ToString(), "int"));



            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveModelo");

            foreach (DataRow rw in _dt.Rows)
            {
                cveModelo = (int)rw["Resultado"];
            }

            return cveModelo;



            return cveModelo;
        }


    }
}
