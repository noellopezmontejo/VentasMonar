using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Desktop.Clases
{
    class cVehiculos 
    {
        Clases.cPageBase pb = new cPageBase();

        public class vParametros
        {
            private int intCveVehiculo;
            private string strDescripcion;
            private string strPlacas;
            private int intCveEstatus;
            private double intCVolumen;
            private double intCPeso;
            private double intRCombustible;
            private int intCveRuta;
            private int intCveChofer;
            private int intActualiza;
            private int intCveUser;
            private string strFechaAlta;
            private int intCveUser_Mod;
            private string strFechaMod;
            private int intCveTipoVehiculo;

            public int IntCveTipoVehiculo
            {
                get { return intCveTipoVehiculo; }
                set { intCveTipoVehiculo = value; }
            }

            private string strTipoVehiculo;

            public string StrTipoVehiculo
            {
                get { return strTipoVehiculo; }
                set { strTipoVehiculo = value; }
            }

            //Adicionales para listar vehiculos.

            private string strNombreRuta;
            private string strNombreChofer;
            private string strEstatusVehiculo;

            public string StrEstatusVehiculo
            {
                get { return strEstatusVehiculo; }
                set { strEstatusVehiculo = value; }
            }

            public string StrNombreChofer
            {
                get { return strNombreChofer; }
                set { strNombreChofer = value; }
            }

            public string StrNombreRuta
            {
                get { return strNombreRuta; }
                set { strNombreRuta = value; }
            }


            public int IntCveUser_Mod
            {
                get { return intCveUser_Mod; }
                set { intCveUser_Mod = value; }
            }


            public string StrFechaMod
            {
                get { return strFechaMod; }
                set { strFechaMod = value; }
            }

            public string StrFechaAlta
            {
                get { return strFechaAlta; }
                set { strFechaAlta = value; }
            }

            public int IntCveUser
            {
                get { return intCveUser; }
                set { intCveUser = value; }
            }
            public int IntActualiza
            {
                get { return intActualiza; }
                set { intActualiza = value; }
            }

            public int IntCveChofer
            {
                get { return intCveChofer; }
                set { intCveChofer = value; }
            }

            public int IntCveRuta
            {
                get { return intCveRuta; }
                set { intCveRuta = value; }
            }

            public double IntRCombustible
            {
                get { return intRCombustible; }
                set { intRCombustible = value; }
            }

            public double IntCPeso
            {
                get { return intCPeso; }
                set { intCPeso = value; }
            }


            public double IntCVolumen
            {
                get { return intCVolumen; }
                set { intCVolumen = value; }
            }
            public int IntCveEstatus
            {
                get { return intCveEstatus; }
                set { intCveEstatus = value; }
            }

            public string StrPlacas
            {
                get { return strPlacas; }
                set { strPlacas = value; }
            }

            public string StrDescripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }

            public int IntCveVehiculo
            {
                get { return intCveVehiculo; }
                set { intCveVehiculo = value; }
            }
        }
        ArrayList ListaParametros = new ArrayList();

        public int SaveData(ArrayList ListaDetalleProducto)
        {
            int CveVehiculo = 0;

            foreach (vParametros item in ListaDetalleProducto)
            {
                ListaParametros.Add(pb.addparametro("Descripcion", item.StrDescripcion, "string"));
                ListaParametros.Add(pb.addparametro("Placas", item.StrPlacas, "string"));
                ListaParametros.Add(pb.addparametro("CveEstatus", item.IntCveEstatus.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CVolumen", item.IntCVolumen.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CPeso", item.IntCPeso.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("RCombustible", item.IntRCombustible.ToString(), "double"));
                ListaParametros.Add(pb.addparametro("CveTipoVehiculo", item.IntCveTipoVehiculo.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveRuta", item.IntCveRuta.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveChofer", item.IntCveChofer.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveUser", item.IntCveUser.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("FechaAlta", item.StrFechaAlta, "string"));
                ListaParametros.Add(pb.addparametro("CveUser_Mod", item.IntCveUser_Mod.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("FechaMod", item.StrFechaMod, "string"));
    
                ListaParametros.Add(pb.addparametro("Actualiza", item.IntActualiza.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveVehiculo", item.IntCveVehiculo.ToString(), "int"));

            }

            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveVehiculo");

            foreach (DataRow rw in _dt.Rows)
            {
                CveVehiculo = (int)rw["CveVehiculo"];
            }

            return CveVehiculo;
        }

        public ArrayList ListaEditar(int CveVehiculo)
        {
            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("IntCveVehiculo", CveVehiculo.ToString(), "int"));
            
            
            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaVehiculosEdit");

            foreach (DataRow rw in _dt.Rows)
            {
                vParametros item = new vParametros();

                item.IntCveVehiculo = int.Parse(rw["CveVehiculo"].ToString());
                item.StrDescripcion = rw["Descripcion"].ToString();
                item.StrPlacas = rw["Placas"].ToString();
                item.IntCveEstatus = int.Parse(rw["CveEstatus"].ToString());
                item.IntCVolumen = double.Parse(rw["CVolumen"].ToString());
                item.IntCPeso = double.Parse(rw["CPeso"].ToString());
                item.IntRCombustible = double.Parse(rw["RCombustible"].ToString());
                item.IntCveRuta = int.Parse(rw["CveRuta"].ToString());
                item.IntCveChofer = int.Parse(rw["CveChofer"].ToString());
                item.IntCveTipoVehiculo = int.Parse(rw["CveTipoVehiculo"].ToString());
                Lista.Add(item);

            }


            return Lista;
 
        }

        public ArrayList ListarVehiculos(string Busqueda)
        {
            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("Busqueda", Busqueda, "string"));
            
            
            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaVehiculos");

            foreach (DataRow rw in _dt.Rows)
            {
                vParametros item = new vParametros();

                item.IntCveVehiculo = int.Parse(rw["CveVehiculo"].ToString());
                item.IntCveRuta = int.Parse(rw["CveRuta"].ToString());
                item.IntCveChofer = int.Parse(rw["CveChofer"].ToString());
                item.StrDescripcion = rw["DescripcionVehiculo"].ToString();
                item.StrNombreRuta = rw["Ruta"].ToString();
                item.StrNombreChofer = rw["Chofer"].ToString();
                item.StrEstatusVehiculo = rw["EstatusVehiculo"].ToString();
                Lista.Add(item);

            }
            


            return Lista;
        }

        public int DeleteData(int CveVehiculo)
        {
            int borrado = 0;

            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("CveChofer",CveVehiculo.ToString(), "string"));


            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SPDeleteVehiculos");

            foreach (DataRow rw in _dt.Rows)
            {
                borrado = int.Parse(rw["Cuenta"].ToString());

            }

            return borrado;
        }

    }
}
