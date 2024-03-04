using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VentasMonar.Desktop.Clases;

namespace VentasMonar.Desktop.Clases
{
    class c_ListaPrecios
    {
        cPageBase _cM = new cPageBase();

        class ListaPrecios
        {
            private int intCvePrecio;
            private string strDescripcion;
            private double dblPrecio;
            private bool blDefault;
            private bool blEstatus;
            private double dblPorcentajeUtilidad;
            private int intChekcPrecio;

            public int ChekcPrecio
            {
                get { return intChekcPrecio; }
                set { intChekcPrecio = value; }
            }

            public double DblPorcentajeUtilidad
            {
                get { return dblPorcentajeUtilidad; }
                set { dblPorcentajeUtilidad = value; }
            }
            public bool BlEstatus
            {
                get { return blEstatus; }
                set { blEstatus = value; }
            }
            public bool BlDefault
            {
                get { return blDefault; }
                set { blDefault = value; }
            }

            public double DblPrecio
            {
                get { return dblPrecio; }
                set { dblPrecio = value; }
            }
            public string StrDescripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }
            public int IntCvePrecio
            {
                get { return intCvePrecio; }
                set { intCvePrecio = value; }
            }

        }

        public ArrayList ArrListaPrecios()
        {
            ArrayList Lista = new ArrayList();


            ArrayList ListaParametro = new ArrayList();

            DataTable dt_ = new DataTable();
            dt_ = _cM.SP_Busca_Reader(ListaParametro, "SP_ListaPrecios");

            foreach (DataRow rw in dt_.Rows)
            {
                ListaPrecios item = new ListaPrecios();

                item.IntCvePrecio = int.Parse(rw["CvePrecio"].ToString());
                item.StrDescripcion = rw["Descripcion"].ToString();
                item.DblPrecio=double.Parse(rw["Precio"].ToString());
                item.ChekcPrecio = int.Parse(rw["ChekcPrecio"].ToString());
                Lista.Add(item);

            }



            return Lista;

        }

        public void AddValor(ArrayList Lista, double xValor)
        {
            foreach (ListaPrecios item in Lista)
            {
                item.ChekcPrecio = 1;
                item.DblPrecio = xValor;
            }
        }


    }
}
