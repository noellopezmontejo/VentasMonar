using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasMonar.Common.Clases;
using System.Data.SqlClient;
using System.Data;
namespace VentasMonar.Common.Clases
{
    public class c_Producto
    {
        Clases.cPageBase pb = new cPageBase();

      

        public class ProductoComplete
        {
            public int CveProducto { get; set; }
            public string CodigoProducto { get; set; }
            public string Descripcion { get; set; }
            public float Existencia { get; set; }
            public decimal PrecioVenta { get; set; }

        }

        public class ProductoDetalle
        {
            private string strCodigoProducto;
            private string strClaveAlterna;
            private string strDescripcion;
            private int intCveTipoProducto;
            private int intCveLinea;
            private int intCveUnidadEntrada;
            private int intCveUnidadSalida;
            private double dblFactorUnidad;
            private string strControlAlmacen;
            private double dblVolumen;
            private double dblPeso;
            private decimal dblCostoAplicar;
            private decimal dblPrecio1;
            private decimal dblPrecio2;
            private decimal dblPrecio3;
            private decimal dblPrecio4;
            private decimal dblPrecio5;
            private decimal dblPrecio6;
            private double dblCveEsquemaImpuesto;
            private double dblCveCosteo;
            private double dblProveedor;
            private double dblCantidadPorRecibir;
            private double dblCantidadPorSurtir;
            private double dblCantidadUltimaCompra;
            private decimal dblUltimoCostoCompra;
            private string strFechaUltimaCompra;
            private double dblExistencia;
            private double dblStockMinimo;
            private double dblStockMaximo;
            private int intCveCategoria;
            private int intCveFamilia;
            private int intCveMarca;
            private int intCveProveedor;
            private string strCodigoFabricante;
            private int intCveEstatus;
            private string strDuracion;
            private decimal intIva;
            private int intCveImpuesto;
            private int intCveUser;
            private int intCveUserEdit;
            private string strFechaUserEdit;
            private decimal dblCostoPromedio;
            private decimal dblPorcentajeUtilidad1;
            private decimal dblPorcentajeUtilidad2;
            private decimal dblPorcentajeUtilidad3;
            private decimal dblPorcentajeUtilidad4;
            private decimal dblPorcentajeUtilidad5;
            private decimal dblPorcentajeUtilidad6;
            private int intActualiza;
            private int intCveProductoActual;
            private string strClaveProductoSAT;
            private string strClaveUnidadSAT;
            private int intCSS;
            private string strObservaciones;

            public int CveAnaquel { get; set; }
            public int CveRepisa { get; set; }

            public string StrObservaciones
            {
                get { return strObservaciones; }
                set { strObservaciones = value; }
            }
            public int IntCSS
            {
                get { return intCSS; }
                set { intCSS = value; }
            }
            public string StrClaveUnidadSAT
            {
                get { return strClaveUnidadSAT; }
                set { strClaveUnidadSAT = value; }
            }

            public string StrClaveProductoSAT
            {
                get { return strClaveProductoSAT; }
                set { strClaveProductoSAT = value; }
            }

            public int CveProductoActual
            {
                get { return intCveProductoActual; }
                set { intCveProductoActual = value; }
            }

            public int Actualiza
            {
                get { return intActualiza; }
                set { intActualiza = value; }
            }
            public decimal PorcentajeUtilidad6
            {
                get { return dblPorcentajeUtilidad6; }
                set { dblPorcentajeUtilidad6 = value; }
            }
            public decimal PorcentajeUtilidad5
            {
                get { return dblPorcentajeUtilidad5; }
                set { dblPorcentajeUtilidad5 = value; }
            }

            public decimal PorcentajeUtilidad4
            {
                get { return dblPorcentajeUtilidad4; }
                set { dblPorcentajeUtilidad4 = value; }
            }
            public decimal PorcentajeUtilidad3
            {
                get { return dblPorcentajeUtilidad3; }
                set { dblPorcentajeUtilidad3 = value; }
            }

            public decimal PorcentajeUtilidad2
            {
                get { return dblPorcentajeUtilidad2; }
                set { dblPorcentajeUtilidad2 = value; }
            }

            public decimal PorcentajeUtilidad1
            {
                get { return dblPorcentajeUtilidad1; }
                set { dblPorcentajeUtilidad1 = value; }
            }
            public decimal CostoPromedio
            {
                get { return dblCostoPromedio; }
                set { dblCostoPromedio = value; }
            }
            public string FechaUserEdit
            {
                get { return strFechaUserEdit; }
                set { strFechaUserEdit = value; }
            }

            public int CveUserEdit
            {
                get { return intCveUserEdit; }
                set { intCveUserEdit = value; }
            }

            public int CveUser
            {
                get { return intCveUser; }
                set { intCveUser = value; }
            }
            

            public int CveImpuesto
            {
                get { return intCveImpuesto; }
                set { intCveImpuesto = value; }
            }

            public decimal tIva
            {
                get { return intIva; }
                set { intIva = value; }
            }

            public string Duracion
            {
                get { return strDuracion; }
                set { strDuracion = value; }
            }


            public int CveEstatus
            {
                get { return intCveEstatus; }
                set { intCveEstatus = value; }
            }

            public string CodigoFabricante
            {
                get { return strCodigoFabricante; }
                set { strCodigoFabricante = value; }
            }


            public int CveProveedor
            {
                get { return intCveProveedor; }
                set { intCveProveedor = value; }
            }

            public int CveMarca
            {
                get { return intCveMarca; }
                set { intCveMarca = value; }
            }
            public int CveFamilia
            {
                get { return intCveFamilia; }
                set { intCveFamilia = value; }
            }

            public int CveCategoria
            {
                get { return intCveCategoria; }
                set { intCveCategoria = value; }
            }
            public double StockMaximo
            {
                get { return dblStockMaximo; }
                set { dblStockMaximo = value; }
            }
            public double StockMinimo
            {
                get { return dblStockMinimo; }
                set { dblStockMinimo = value; }
            }
            public double Existencia
            {
                get { return dblExistencia; }
                set { dblExistencia = value; }
            }

            public string FechaUltimaCompra
            {
                get { return strFechaUltimaCompra; }
                set { strFechaUltimaCompra = value; }
            }
            public decimal UltimoCostoCompra
            {
                get { return dblUltimoCostoCompra; }
                set { dblUltimoCostoCompra = value; }
            }
            public double CantidadUltimaCompra
            {
                get { return dblCantidadUltimaCompra; }
                set { dblCantidadUltimaCompra = value; }
            }
            public double CantidadPorSurtir
            {
                get { return dblCantidadPorSurtir; }
                set { dblCantidadPorSurtir = value; }
            }
            public double CantidadPorRecibir
            {
                get { return dblCantidadPorRecibir; }
                set { dblCantidadPorRecibir = value; }
            }
            public double Proveedor
            {
                get { return dblProveedor; }
                set { dblProveedor = value; }
            }
            public double CveCosteo
            {
                get { return dblCveCosteo; }
                set { dblCveCosteo = value; }
            }

            public double CveEsquemaImpuesto
            {
                get { return dblCveEsquemaImpuesto; }
                set { dblCveEsquemaImpuesto = value; }
            }

            public decimal Precio6
            {
                get { return dblPrecio6; }
                set { dblPrecio6 = value; }
            }
            public decimal Precio5
            {
                get { return dblPrecio5; }
                set { dblPrecio5 = value; }
            }
            public decimal Precio4
            {
                get { return dblPrecio4; }
                set { dblPrecio4 = value; }
            }
            
            public decimal Precio3
            {
                get { return dblPrecio3; }
                set { dblPrecio3 = value; }
            }
            public decimal Precio2
            {
                get { return dblPrecio2; }
                set { dblPrecio2 = value; }
            }
            public decimal Precio1
            {
                get { return dblPrecio1; }
                set { dblPrecio1 = value; }
            }
            public decimal CostoAplicar
            {
                get { return dblCostoAplicar; }
                set { dblCostoAplicar = value; }
            }
            public double Peso
            {
                get { return dblPeso; }
                set { dblPeso = value; }
            }
            public double Volumen
            {
                get { return dblVolumen; }
                set { dblVolumen = value; }
            }
            public string ControlAlmacen
            {
                get { return strControlAlmacen; }
                set { strControlAlmacen = value; }
            }
            public double FactorUnidad
            {
                get { return dblFactorUnidad; }
                set { dblFactorUnidad = value; }
            }
            public int CveUnidadSalida
            {
                get { return intCveUnidadSalida; }
                set { intCveUnidadSalida = value; }
            }

            public int CveUnidadEntrada
            {
                get { return intCveUnidadEntrada; }
                set { intCveUnidadEntrada = value; }
            }
            public int CveLinea
            {
                get { return intCveLinea; }
                set { intCveLinea = value; }
            }
            public int CveTipoProducto
            {
                get { return intCveTipoProducto; }
                set { intCveTipoProducto = value; }
            }
            public string Descripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }
            public string ClaveAlterna
            {
                get { return strClaveAlterna; }
                set { strClaveAlterna = value; }
            }
            public string CodigoProducto
            {
                get { return strCodigoProducto; }
                set { strCodigoProducto = value; }
            }

            public int CveProducto { get; set; }

            public Decimal CostoUnitario { get; set; }
            public int CveAlmacen { get; set; }
            public Decimal UltimoCosto { get; set; }



        }
        public class ProductoPrecio
        {
            private int intClaveProducto;
            private int intCvePrecio;
            private double dblPrecio;
            private double dblPorcentajeUtilidad;
            private double dblCostoAplicado;

            public double CostoAplicado
            {
                get { return dblCostoAplicado; }
                set { dblCostoAplicado = value; }
            }
            public double PorcentajeUtilidad
            {
                get { return dblPorcentajeUtilidad; }
                set { dblPorcentajeUtilidad = value; }
            }
            public double Precio
            {
                get { return dblPrecio; }
                set { dblPrecio = value; }
            }
            public int CvePrecio
            {
                get { return intCvePrecio; }
                set { intCvePrecio = value; }
            }
            public int IntClaveProducto
            {
                get { return intClaveProducto; }
                set { intClaveProducto = value; }
            }
           
        }
        public class ProductoServicio
        {
            private string strClaveProductoServicio;
            private string strDescripcion;

            public string StrDescripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }

            public string StrClaveProductoServicio
            {
                get { return strClaveProductoServicio; }
                set { strClaveProductoServicio = value; }
            }
        }
        public class ProductoImagen
        {
            private int intCveProducto;
            private int intCveDetalleImagen;
            
            public int IntCveProducto { get => intCveProducto; set => intCveProducto = value; }
            public int IntCveDetalleImagen { get => intCveDetalleImagen; set => intCveDetalleImagen = value; }
        }

        public ArrayList ListaParametros = new ArrayList();

        public int CveProducto { get; set; }

        public class DetalleSeccion
        {
            public int CveDetalleSeccion { get; set; }
            public int CveSeccion { get; set; }
            public int CveModelo { get; set; }
            public int CveProducto { get; set; }
            public string DescripcionSeccion { get; set; }
            public string DescripcionModelo { get; set; }



           

        }

        public int SaveSecciones(ArrayList ListaDetalleSeccion)
        {
            int Result = 0;

            foreach (DetalleSeccion item in ListaDetalleSeccion)
            {

                ListaParametros.Add(pb.addparametro("CveSeccion", item.CveSeccion.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveProducto", item.CveProducto.ToString(), "int"));

                DataTable _dt = new DataTable();

                _dt = pb.SP_Busca_Reader(ListaParametros, "SP_DetalleSeccion");

                foreach (DataRow rw in _dt.Rows)
                {
                    Result = (int)rw["Resultado"];
                }

            }
                       
            return Result;
        }



        private Clientes Cte { get; set; }

        public static ProductoDetalle GetProductoDetalleByCodigoProducto(string CodigoProducto)
        {
            ArrayList ListaParametros = new ArrayList();

            ProductoDetalle producto = null;

            cPageBase cPage = new cPageBase();

            string Query = "Select CveProducto, CodigoProducto, Nombre, Precio0 As CostoUnitario, CostoPromedio, UltimoCosto From Productos Where CodigoProducto='" + CodigoProducto + "'";


            DataTable _tbResult = new DataTable();

            _tbResult = cPage.SP_DataReaderQuery(Query);

            if (_tbResult.Rows.Count == 0) return producto;

            foreach (DataRow item in _tbResult.Rows)
            {

                producto = new ProductoDetalle();
                producto.CveProducto = int.Parse(item["CveProducto"].ToString());
                producto.Descripcion = item["Nombre"].ToString();
                producto.CostoUnitario = Decimal.Parse(item["CostoUnitario"].ToString());
                producto.CodigoProducto = item["CodigoProducto"].ToString();

                if (item["CostoPromedio"].ToString()!=null || item["CostoPromedio"].ToString() !=string.Empty)
                producto.CostoPromedio= Decimal.Parse(item["CostoPromedio"].ToString());

                if(item["UltimoCosto"].ToString()!=null || item["UltimoCosto"].ToString()!=string.Empty)
                producto.UltimoCosto= Decimal.Parse(item["UltimoCosto"].ToString());
                               
            }

            return producto;
        }


        public static ProductoDetalle GetProductoDetalleByNombre(string Descripcion)
        {
            ArrayList ListaParametros = new ArrayList();

            ProductoDetalle producto = null;

            cPageBase cPage = new cPageBase();

            string Query = "Select CveProducto, CodigoProducto, Nombre, Precio0 As CostoUnitario, CostoPromedio, UltimoCosto From Productos Where Descripcion='" + Descripcion + "'";


            DataTable _tbResult = new DataTable();

            _tbResult = cPage.SP_DataReaderQuery(Query);

            if (_tbResult.Rows.Count == 0) return producto;

            foreach (DataRow item in _tbResult.Rows)
            {

                producto = new ProductoDetalle();
                producto.CveProducto = int.Parse(item["CveProducto"].ToString());
                producto.Descripcion = item["Nombre"].ToString();
                producto.CostoUnitario = Decimal.Parse(item["CostoUnitario"].ToString());
                producto.CodigoProducto = item["CodigoProducto"].ToString();

                if (item["CostoPromedio"].ToString() != null || item["CostoPromedio"].ToString() != string.Empty)
                    producto.CostoPromedio = Decimal.Parse(item["CostoPromedio"].ToString());

                if (item["UltimoCosto"].ToString() != null || item["UltimoCosto"].ToString() != string.Empty)
                    producto.UltimoCosto = Decimal.Parse(item["UltimoCosto"].ToString());

            }

            return producto;
        }

        public  DataTable GetProductoDetalleByDescripcion(string Descripcion)
        {
            ArrayList ListaParametros = new ArrayList();

            ProductoDetalle producto = null;

            cPageBase cPage = new cPageBase();

            // Query = "Select CveProducto, CodigoProducto, Nombre, Precio0 As CostoUnitario, CostoPromedio, UltimoCosto From Productos Where Nombre Like '%" + Descripcion + "%'";


            DataTable _tbResult = new DataTable();
            ListaParametros.Clear();
            ListaParametros.Add(pb.addparametro("Descripcion", Descripcion, "string"));



            _tbResult = cPage.SP_Busca_Reader(ListaParametros, "GetProductoDetalle");

            //if (_tbResult.Rows.Count == 0) return producto;
            /*
            foreach (DataRow item in _tbResult.Rows)
            {

                producto = new ProductoDetalle();
                producto.CveProducto = int.Parse(item["CveProducto"].ToString());
                producto.Descripcion = item["Nombre"].ToString();
                producto.CostoUnitario = Decimal.Parse(item["CostoUnitario"].ToString());
                producto.CodigoProducto = item["CodigoProducto"].ToString();

                if (item["CostoPromedio"].ToString() != null || item["CostoPromedio"].ToString() != string.Empty)
                    producto.CostoPromedio = Decimal.Parse(item["CostoPromedio"].ToString());

                if (item["UltimoCosto"].ToString() != null || item["UltimoCosto"].ToString() != string.Empty)
                    producto.UltimoCosto = Decimal.Parse(item["UltimoCosto"].ToString());

            }
            */
            return _tbResult;
        }





        public ArrayList ListaProductoServicioSAT(string parametro, string busqueda = "", int opcion=0)
        {
            ArrayList Lista = new ArrayList();
            ListaParametros.Clear();
            ListaParametros.Add(pb.addparametro("parametro", parametro, "string"));
            ListaParametros.Add(pb.addparametro("busqueda", busqueda, "string"));
            ListaParametros.Add(pb.addparametro("opcion", opcion.ToString(), "int"));
            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaProdServSAT");

            foreach (DataRow rw in _dt.Rows)
            {
                ProductoServicio item = new ProductoServicio();

                item.StrClaveProductoServicio = rw["ClaveProductoServicio"].ToString();
                item.StrDescripcion = rw["Descripcion"].ToString();
                Lista.Add(item);

            }


            return Lista;
        }

        public ArrayList ListaUnidadSAT(string parametro)
        {
            ArrayList Lista = new ArrayList();
            ListaParametros.Clear();
            ListaParametros.Add(pb.addparametro("parametro", parametro, "string"));
        
            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaUnidadSAT");

            foreach (DataRow rw in _dt.Rows)
            {
                ProductoServicio item = new ProductoServicio();

                item.StrClaveProductoServicio = rw["ClaveUnidad"].ToString();
                item.StrDescripcion = rw["Descripcion"].ToString();
                Lista.Add(item);

            }


            return Lista;
        }


        public int SaveData(ArrayList ListaDetalleProducto)
        {
            int CveProducto = 0;

            foreach (ProductoDetalle item in ListaDetalleProducto)
            {
                ListaParametros.Add(pb.addparametro("CodigoProducto",item.CodigoProducto,"string"));
                ListaParametros.Add(pb.addparametro("Descripcion", item.Descripcion, "string"));
                ListaParametros.Add(pb.addparametro("CveUnidadEntrada", item.CveUnidadEntrada.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveUnidad", item.CveUnidadSalida.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("FactorUnidades", item.FactorUnidad.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("ControlAlmacen", item.ControlAlmacen, "string"));
                ListaParametros.Add(pb.addparametro("Volumen", item.Volumen.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Peso", item.Peso.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CveCategoria", item.CveCategoria.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveLinea", item.CveLinea.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveFamilia", item.CveFamilia.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveMarca", item.CveMarca.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveProveedor", item.CveProveedor.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("Existencia", item.Existencia.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("StockMinimo", item.StockMinimo.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("StockMaximo", item.StockMaximo.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CostoPromedio", item.CostoAplicar.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("UltimoCosto", item.UltimoCostoCompra.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CantidadUltimaCompra", item.CantidadUltimaCompra.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("FechaUltimaCompra", item.FechaUltimaCompra, "string"));
                ListaParametros.Add(pb.addparametro("Precio0", item.CostoAplicar.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Precio1", item.Precio1.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Precio2", item.Precio2.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Precio3", item.Precio3.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Precio4", item.Precio4.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Precio5", item.Precio5.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("Precio6", item.Precio5.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("PorcentajeUtilidad1", item.PorcentajeUtilidad1.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("PorcentajeUtilidad2", item.PorcentajeUtilidad2.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("PorcentajeUtilidad3", item.PorcentajeUtilidad3.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("PorcentajeUtilidad4", item.PorcentajeUtilidad4.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("PorcentajeUtilidad5", item.PorcentajeUtilidad5.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("PorcentajeUtilidad6", item.PorcentajeUtilidad6.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CveTipoProducto", item.CveTipoProducto.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveUser", item.CveUser.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveuserEdit", item.CveUserEdit.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CodigoFabricante", item.CodigoFabricante, "string"));
                ListaParametros.Add(pb.addparametro("CveEstatus", item.CveEstatus.ToString(), "int"));
                
                ListaParametros.Add(pb.addparametro("Iva", item.tIva.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("Clave_Alterna", item.ClaveAlterna, "string"));
                ListaParametros.Add(pb.addparametro("CveImpuesto", item.CveImpuesto.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveCosteo", item.CveCosteo.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CantidadRecibir", item.CantidadPorRecibir.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CantidadSurtir", item.CantidadPorSurtir.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("claveProductoSAT", item.StrClaveProductoSAT, "string"));
                ListaParametros.Add(pb.addparametro("ClaveUnidadSAT", item.StrClaveUnidadSAT, "string"));
                ListaParametros.Add(pb.addparametro("Actualiza", item.Actualiza.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveProductoActual", item.CveProductoActual.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CSS", item.IntCSS.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("Observaciones", item.StrObservaciones, "string"));
                ListaParametros.Add(pb.addparametro("CveAnaquel", item.CveAnaquel.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveRepisa", item.CveRepisa.ToString(), "int"));

            }

            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveProductos");

            foreach (DataRow rw in _dt.Rows)
            {
                CveProducto = (int)rw["CveProducto"];
            }

            return CveProducto;
        }

        public int Delete_imagen(int CveDetalleImagen)
        {
            
           
            string QueryDetele = "Delete From DetalleImagenProducto Where CveDetalleImagen=" + CveDetalleImagen;

            int intdelete = pb.SP_QueryExecute(QueryDetele);

            return intdelete;          

        }

        public ArrayList ListaImagenes(string parametro)
        {
            ArrayList Lista = new ArrayList();
            ListaParametros.Clear();
            ListaParametros.Add(pb.addparametro("parametro", parametro, "string"));
         
            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaDetalleImagenProducto");

            foreach (DataRow rw in _dt.Rows)
            {

                ProductoImagen im = new ProductoImagen();
                im.IntCveDetalleImagen = int.Parse(rw["CveDetalleImagen"].ToString());
                im.IntCveProducto = int.Parse(rw["CveProducto"].ToString());
                Lista.Add(im);

            }
            
            return Lista;
        }

    }
}
