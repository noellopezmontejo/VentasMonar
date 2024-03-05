using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Common.Clases
{
    class cAutorizaRemisionCS
    {
        cPageBase pb=new cPageBase();

        private int intCveDocumento;
        private int intCveAlmacen;
        private double dblCantidad;
        private int intOpcion;
        private double intPrecioUnitario;
        private double intSubTotal;
        private double intDescuento;
        private double intPenalizacion;
        private double intIVA;
        private double intTotal;

        public double Total
        {
            get { return intTotal; }
            set { intTotal = value; }
        }

        public double IVA
        {
            get { return intIVA; }
            set { intIVA = value; }
        }

        public double Penalizacion
        {
            get { return intPenalizacion; }
            set { intPenalizacion = value; }
        }

        public double Descuento
        {
            get { return intDescuento; }
            set { intDescuento = value; }
        }

        public double SubTotal
        {
            get { return intSubTotal; }
            set { intSubTotal = value; }
        }

        public double PrecioUnitario
        {
            get { return intPrecioUnitario; }
            set { intPrecioUnitario = value; }
        }

        public int IntOpcion
        {
            get { return intOpcion; }
            set { intOpcion = value; }
        }

        public double DblCantidad
        {
            get { return dblCantidad; }
            set { dblCantidad = value; }
        }

        public int IntCveAlmacen
        {
            get { return intCveAlmacen; }
            set { intCveAlmacen = value; }
        }

        public int IntCveDocumento
        {
            get { return intCveDocumento; }
            set { intCveDocumento = value; }
        }

        public class parametros
        {
            private int intCveDocumento;
            private int intCveAlmacen;
            private double dblCantidad;
            private int intOpcion;
            private double intPrecioUnitario;
            private double intSubTotal;
            private double intDescuento;
            private double intPenalizacion;
            private double intIVA;
            private double intTotal;

            public double Total
            {
                get { return intTotal; }
                set { intTotal = value; }
            }

            public double IVA
            {
                get { return intIVA; }
                set { intIVA = value; }
            }

            public double Penalizacion
            {
                get { return intPenalizacion; }
                set { intPenalizacion = value; }
            }

            public double Descuento
            {
                get { return intDescuento; }
                set { intDescuento = value; }
            }

            public double SubTotal
            {
                get { return intSubTotal; }
                set { intSubTotal = value; }
            }

            public double PrecioUnitario
            {
                get { return intPrecioUnitario; }
                set { intPrecioUnitario = value; }
            }


            public int IntOpcion
            {
                get { return intOpcion; }
                set { intOpcion = value; }
            }

            public double DblCantidad
            {
                get { return dblCantidad; }
                set { dblCantidad = value; }
            }

            public int IntCveAlmacen
            {
                get { return intCveAlmacen; }
                set { intCveAlmacen = value; }
            }

            public int IntCveDocumento
            {
                get { return intCveDocumento; }
                set { intCveDocumento = value; }
            }



        }

        public int Save()
        {
            int result = 0;

            ArrayList ListaParametro = new ArrayList();

                ListaParametro.Add(pb.addparametro("CveDocumento",IntCveDocumento.ToString(), "int"));
                ListaParametro.Add(pb.addparametro("CveAlmacen",IntCveAlmacen.ToString(), "int"));
                ListaParametro.Add(pb.addparametro("Cantidad", DblCantidad.ToString(), "double"));

                DataTable _dt = new DataTable();

                _dt = pb.SP_Busca_Reader(ListaParametro, "SP_ActualizaInventario");

                foreach (DataRow rw in _dt.Rows)
                {
                    result = (int)rw["Cuenta"];
                }
            
            return result;
        }
        public ArrayList ListaDetalle(int CveDocumento)
        {
            ArrayList Lista = new ArrayList();
               ArrayList ListaParametro = new ArrayList();

                   ListaParametro.Add(pb.addparametro("CveDocumento", CveDocumento.ToString(), "int"));

          
            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametro, "SP_DetalleDocumento");

            foreach (DataRow rw in _dt.Rows)
            {
                parametros item = new parametros();
                item.IntCveDocumento = (int)rw["CveDocumento"];
                item.IntCveAlmacen = (int)rw["CveAlmacen"];
                item.DblCantidad = (double)rw["Cantidad"];
                item.PrecioUnitario = (double)rw["PrecioUnitario"];
                item.SubTotal = (double)rw["SubTotal"];
                item.Descuento = (double)rw["Descuento"];
                item.Penalizacion = (double)rw["Penalizacion"];
                item.IVA = (double)rw["IVA"];
                item.Total = (double)rw["Total"];

            }

            return Lista;
        }


    }
}
