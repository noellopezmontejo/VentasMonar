using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
   
    public class cProveedor
    {
        public int CveProveedor { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CP { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string SitioWeb { get; set; }
        public string Contacto { get; set; }
        public int Credito { get; set; }
        public Decimal LimiteCredito { get; set; }
        public int DiasCredito { get; set; }
        public Decimal SaldoCredito { get; set; }
        public string Observaciones { get; set; }
        


        public static cProveedor GetProveedorByIdProveedor(int CveProveedor)
        {
            cPageBase cPage = new cPageBase();
            cProveedor miProveedor = null;
            DataTable _dtResult = new DataTable();

            string queryProveedor = "SELECT * FROM Proveedores WHERE CveProveedor=" + CveProveedor;

            _dtResult = cPage.SP_DataReaderQuery(queryProveedor);

            if (_dtResult.Rows.Count == 0) return miProveedor;

            foreach (DataRow item in _dtResult.Rows)
            {
                miProveedor = new cProveedor();
                miProveedor.Colonia = item["Colonia"].ToString();
                miProveedor.Contacto = item["Contacto"].ToString();
                miProveedor.CorreoElectronico = item["CorreoElectronico"].ToString();
                miProveedor.CP = item["CP"].ToString();
                miProveedor.Credito = int.Parse(item["Credito"].ToString());
                miProveedor.CveProveedor = int.Parse(item["CveProveedor"].ToString());
                miProveedor.DiasCredito = int.Parse(item["DiasCredito"].ToString());
                miProveedor.Direccion = item["Direccion"].ToString();
                miProveedor.Estado = item["Estado"].ToString();
                miProveedor.Fax = item["Fax"].ToString();
                miProveedor.FechaAlta = DateTime.Parse(item["FechaAlta"].ToString());
                miProveedor.LimiteCredito = Decimal.Parse(item["LimiteCredito"].ToString());
                miProveedor.Municipio = item["Municipio"].ToString();
                miProveedor.Nombre = item["Nombre"].ToString();
                miProveedor.Observaciones = item["Observaciones"].ToString();
                miProveedor.RFC = item["RFC"].ToString();
                miProveedor.SaldoCredito = (Decimal)item["SaldoCredito"];
                miProveedor.SitioWeb = item["SitioWeb"].ToString();
                miProveedor.Telefono1 = item["Telefono1"].ToString();
                miProveedor.Telefono2 = item["Telefono2"].ToString();
                miProveedor.TelefonoMovil = item["TelefonoMovil"].ToString();
                

            }


            return miProveedor;
        }

        public static DataTable _dtGridResultado(string txtBusqueda, int Parametro)
        {
            cPageBase cPage = new cPageBase();

            DataTable _dtResult = new DataTable();

            string Busqueda = string.Empty;

            /*
             *  if (rbtContiene.Checked)
                Busqueda = "%" + txtBusqueda.Text + "%";

            if (rbtEmpieza.Checked)
                Busqueda =  txtBusqueda.Text + "%";

            if (rbtTermina.Checked)
                Busqueda = "%" + txtBusqueda.Text;

            if (rbtIgual.Checked)
                Busqueda = txtBusqueda.Text;
            */


            switch(Parametro)
            {
                case 1: //Contiene...
                    Busqueda = "%" + txtBusqueda + "%";
                    break;
                case 2: // Empieza...
                    Busqueda = txtBusqueda + "%";
                    break;
                case 3: // Termina...
                    Busqueda = "%" + txtBusqueda;
                    break;
                case 4: // Igual...
                    Busqueda = "%" + txtBusqueda;
                    break;

            }


            string Query = "SELECT CveProveedor, Nombre, RFC, Telefono1, Telefono2, Fax, 1 AS Checked FROM Proveedores Where Nombre Like '" + Busqueda + "' ORDER BY Nombre";

            _dtResult = cPage.SP_DataReaderQuery(Query);



            return _dtResult;
        }





    }
}
