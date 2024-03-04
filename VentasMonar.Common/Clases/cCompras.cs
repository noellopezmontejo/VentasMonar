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
    public class cCompras
    {
        public class cParamCompras
        {
            public int CveCompra { get; set; }
            public int CveProveedor { get; set; }
            public int CvePedido { get; set; }
            public int CveFormaPago { get; set; }
            public string NumeroFactura { get; set; }
            public DateTime FechaFactura { get; set; }
            public DateTime FechaRecepcion { get; set; }
            public decimal SalTotal { get; set; }
            public decimal GasTosIndirectos { get; set; }
            public decimal Iva { get; set; }
            public decimal Total { get; set; }
            public int CveEstatus { get; set; }
            public int CveUser { get; set; }
            public int CveAlmacen { get; set; }
          
        }


        Clases.cPageBase pb = new cPageBase();

        public int SaveCompra(ArrayList ListaParam)
        {
            int _result = 0;



            ArrayList _ListaParam = new ArrayList();
            foreach (cParamCompras item in ListaParam)
            {

                _ListaParam.Add(pb.addparametro("@CveProveedor", item.CveProveedor.ToString(), "int"));
                _ListaParam.Add(pb.addparametro("@CvePedido", item.CvePedido.ToString(), "int"));
                _ListaParam.Add(pb.addparametro("@CveFormaPago", item.CveFormaPago.ToString(), "int"));
                _ListaParam.Add(pb.addparametro("@NumeroFactura", item.NumeroFactura.ToString(), "string"));
                _ListaParam.Add(pb.addparametro("@FechaFactura", item.FechaFactura.ToString(), "datetime"));
                _ListaParam.Add(pb.addparametro("@FechaVence", item.FechaRecepcion.ToString(), "datetime"));
                _ListaParam.Add(pb.addparametro("@SalTotal", item.SalTotal.ToString(), "decimal"));
                _ListaParam.Add(pb.addparametro("@FleteTotal", item.GasTosIndirectos.ToString(), "decimal"));
                _ListaParam.Add(pb.addparametro("@Iva", item.Iva.ToString(), "decimal"));
                _ListaParam.Add(pb.addparametro("@Total", item.Total.ToString(), "decimal"));
                _ListaParam.Add(pb.addparametro("@CveEstatus", item.CveEstatus.ToString(), "int"));
                _ListaParam.Add(pb.addparametro("@CveUser", item.CveUser.ToString(), "int"));
                _ListaParam.Add(pb.addparametro("@CveAlmacen", item.CveAlmacen.ToString(), "int"));
                
               
            }

            



            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(_ListaParam, "SP_SaveCompras");

            foreach (DataRow rw in _dt.Rows)
            {
                _result = (int)rw["Resultado"];
            }

            return _result;
        }


        public decimal CantidadEntrada { get; set; }
        public int CveTipo { get; set; }
        public decimal Existencia { get; set; }
        public decimal CostoUnitarioEntrada { get; set; }
        public decimal TotalEntrada { get; set; }
        public decimal CantidadSalida { get; set; }
        public decimal CostoUnitarioSalida { get; set; }
        public decimal TotalSalida { get; set; }

        public decimal CostoPromedio { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoAnterior { get; set; }

      
        



    }
}
