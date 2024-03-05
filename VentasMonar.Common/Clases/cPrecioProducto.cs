using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Common.Clases
{
    class cPrecioProducto
    {
        ArrayList ListaParametros = new ArrayList();

        cPageBase cp = new cPageBase();

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
            dt_ = cp.SP_Busca_Reader(ListaParametro, "SP_ListaPrecios");

            foreach (DataRow rw in dt_.Rows)
            {
                ListaPrecios item = new ListaPrecios();

                item.IntCvePrecio = int.Parse(rw["CvePrecio"].ToString());
                item.StrDescripcion = rw["Descripcion"].ToString();
                item.DblPrecio = double.Parse(rw["Precio"].ToString());
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

        public DataTable UpdatePrice(int option, int CveProducto = 0, int ChkMonto = 0, int ChkPorcentaje = 0, int ChkPrecioCosto = 0, int ChkUltimoCosto = 0, int ChkCostoPromedio = 0, int ChkCategoria = 0, int ChkLinea = 0, int ChkFamilia = 0, int CveCategoria = 0, int CveLinea = 0, int CveFamilia = 0, ArrayList _ListaPrecios=null)
        {
            
            Clases.cPrecioProducto _cp = new Clases.cPrecioProducto();

            ListaParametros.Add(cp.addparametro("option", option.ToString(), "int"));
            ListaParametros.Add(cp.addparametro("CveProducto", CveProducto.ToString(), "int"));

            if (ChkMonto==1)
                ListaParametros.Add(cp.addparametro("ChkMonto", "1", "int"));

            if (ChkPorcentaje==1)
                ListaParametros.Add(cp.addparametro("ChkPorcentaje", "1", "int"));

            if (ChkPrecioCosto==1)
            {
                ListaParametros.Add(cp.addparametro("ChkCostoPromedio", "1", "int"));
                if (ChkUltimoCosto==1)
                    ListaParametros.Add(cp.addparametro("ChkUltimoCosto", "1", "int"));

                if (ChkCostoPromedio==1)
                    ListaParametros.Add(cp.addparametro("ChkCostoPromedio", "1", "int"));

                
            }

            if (ChkCategoria == 1)
            {
                ListaParametros.Add(cp.addparametro("ChkCategoria","1", "int"));
                ListaParametros.Add(cp.addparametro("CveCategoria", CveCategoria.ToString(), "int"));
            }

            if (ChkLinea == 1)
            {
                ListaParametros.Add(cp.addparametro("ChkLinea", "1", "int"));
                ListaParametros.Add(cp.addparametro("CveLinea", CveLinea.ToString(), "int"));
            }

            if (ChkFamilia == 1)
            {
                ListaParametros.Add(cp.addparametro("ChkFamilia", "1", "int"));
                ListaParametros.Add(cp.addparametro("CveFamilia", CveFamilia.ToString(), "int"));
            }


            foreach (ListaPrecios item in _ListaPrecios)
            {
                switch (item.IntCvePrecio)
                {
                    case 1:
                        ListaParametros.Add(cp.addparametro("xValor1",item.DblPrecio.ToString(), "decimal"));
                        break;
                    case 2:
                        ListaParametros.Add(cp.addparametro("xValor2", item.DblPrecio.ToString(), "decimal"));
                        break;
                    case 3:
                        ListaParametros.Add(cp.addparametro("xValor3", item.DblPrecio.ToString(), "decimal"));
                        break;
                    case 4:
                        ListaParametros.Add(cp.addparametro("xValor4", item.DblPrecio.ToString(), "decimal"));
                        break;
                    case 5:
                        ListaParametros.Add(cp.addparametro("xValor5", item.DblPrecio.ToString(), "decimal"));
                        break;
                    case 6:
                        ListaParametros.Add(cp.addparametro("xValor6", item.DblPrecio.ToString(), "decimal"));
                        break;
                }

            }


             DataTable _table = new DataTable();

            _table = cp.SP_Busca_Reader(ListaParametros, "SP_ActualizaPrecios");


            return _table;

          

        }



        public DataTable BuscaProductoC(string CodigoProductoA)
        {
            int intcvecliente = 0;

            FormAgregarProductoC FormA = new FormAgregarProductoC();
            FormA.TxtBusquedaProducto = CodigoProductoA;

            string CodigoProducto = "";
            if (FormA.ShowDialog() == DialogResult.OK)
            {
                intcvecliente = 1;
                CodigoProducto = FormA.StrCodigoProducto;
            }
            DataTable _tbCliente = new DataTable();
            if (intcvecliente == 1)
            {

                ListaParametros.Clear();

                ListaParametros.Add(cp.addparametro("CHK","1","int"));
                ListaParametros.Add(cp.addparametro("CodigoProducto", CodigoProducto, "string"));

                                
             

                _tbCliente = cp.SP_Busca_Reader(ListaParametros, "SP_CheckProducto");

                /*
                foreach (DataRow row in _tbCliente.Rows)
                {

                    FormA_MiEnvento(row["CveProducto"].ToString(), row["Producto"].ToString(), row["Precio"].ToString(), row["CodigoProducto"].ToString(), "0", 1, "");



                }
                */

            }

            return _tbCliente;

        }
    }
}
