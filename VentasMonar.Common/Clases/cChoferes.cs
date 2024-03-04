using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Desktop.Clases
{
    class cChoferes
    {
         Clases.cPageBase pb = new cPageBase();

        public class vParametros
        {
            private int intCveChofer;
            private string strNombre;
            private string strRFC;
            private string strDireccion;
            private string strColonia;
            private string strCP;
            private int intCveMunicipio;
            private int intCveEstado;
            private string strTelefono;
            private string strTelefonoMovil;
            private string strCorreoElectronico;
            private int intCveUser;
            private int intCveEstatus;
            private int intCveUserEdit;
            private string strFechaAlta;
            private string strFechaEdit;
            private int intActualiza;
            private string strEstatusChofer;

            public string StrEstatusChofer
            {
                get { return strEstatusChofer; }
                set { strEstatusChofer = value; }
            }


            public int IntActualiza
            {
                get { return intActualiza; }
                set { intActualiza = value; }
            }

            public string StrFechaEdit
            {
                get { return strFechaEdit; }
                set { strFechaEdit = value; }
            }

            public string StrFechaAlta
            {
                get { return strFechaAlta; }
                set { strFechaAlta = value; }
            }

            public int IntCveUserEdit
            {
                get { return intCveUserEdit; }
                set { intCveUserEdit = value; }
            }

            public int IntCveEstatus
            {
                get { return intCveEstatus; }
                set { intCveEstatus = value; }
            }

            public int IntCveUser
            {
                get { return intCveUser; }
                set { intCveUser = value; }
            }

            public string StrCorreoElectronico
            {
                get { return strCorreoElectronico; }
                set { strCorreoElectronico = value; }
            }
           
            public string StrTelefonoMovil
            {
                get { return strTelefonoMovil; }
                set { strTelefonoMovil = value; }
            }

            public string StrTelefono
            {
                get { return strTelefono; }
                set { strTelefono = value; }
            }

            public int IntCveEstado
            {
                get { return intCveEstado; }
                set { intCveEstado = value; }
            }

            public int IntCveMunicipio
            {
                get { return intCveMunicipio; }
                set { intCveMunicipio = value; }
            }
            public string StrCP
            {
                get { return strCP; }
                set { strCP = value; }
            }
            public string StrColonia
            {
                get { return strColonia; }
                set { strColonia = value; }
            }

            public string StrDireccion
            {
                get { return strDireccion; }
                set { strDireccion = value; }
            }

            public string StrRFC
            {
                get { return strRFC; }
                set { strRFC = value; }
            }

            public string StrNombre
            {
                get { return strNombre; }
                set { strNombre = value; }
            }
            public int IntCveChofer
            {
                get { return intCveChofer; }
                set { intCveChofer = value; }
            }

        }

        ArrayList ListaParametros = new ArrayList();

        public int SaveData(ArrayList ListaDetalleProducto)
        {
            int CveChofer = 0;

            string Resultado = "";

            foreach (vParametros item in ListaDetalleProducto)
            {
                ListaParametros.Add(pb.addparametro("Nombre", item.StrNombre, "string"));
                ListaParametros.Add(pb.addparametro("RFC", item.StrRFC, "string"));
                ListaParametros.Add(pb.addparametro("Direccion", item.StrDireccion, "string"));
                ListaParametros.Add(pb.addparametro("Colonia", item.StrColonia, "string"));
                ListaParametros.Add(pb.addparametro("CP", item.StrCP, "string"));
                ListaParametros.Add(pb.addparametro("CveMunicipio", item.IntCveMunicipio.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveEstado", item.IntCveEstado.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("Telefono", item.StrTelefono, "string"));
                ListaParametros.Add(pb.addparametro("TelefonoMovil", item.StrTelefonoMovil, "string"));
                ListaParametros.Add(pb.addparametro("CorreoElectronico", item.StrCorreoElectronico, "string"));
                ListaParametros.Add(pb.addparametro("CveEstatus", item.IntCveEstatus.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveUser", item.IntCveUser.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveUserEdit", item.IntCveUserEdit.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("FechaAlta", item.StrFechaAlta, "string"));
                ListaParametros.Add(pb.addparametro("FechaEdit", item.StrFechaEdit, "string"));

                ListaParametros.Add(pb.addparametro("Actualiza", item.IntActualiza.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveChofer", item.IntCveChofer.ToString(), "int"));

            }

            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveChoferes");

            foreach (DataRow rw in _dt.Rows)
            {
                Resultado =rw["Resultado"].ToString();
            }

            if (pb.IsNumeric(Resultado))
                CveChofer = int.Parse(Resultado);

            return CveChofer;
        }

        public ArrayList ListaEditar(int CveChofer)
        {
            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("CveChofer", CveChofer.ToString(), "int"));


            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaChoferesEdit");

            foreach (DataRow rw in _dt.Rows)
            {
                vParametros item = new vParametros();

                item.IntCveChofer = int.Parse(rw["CveChofer"].ToString());
                item.StrNombre = rw["Nombre"].ToString();
                item.StrRFC = rw["RFC"].ToString();
                item.StrDireccion = rw["Direccion"].ToString();
                item.StrColonia = rw["Colonia"].ToString();
                item.StrCP = rw["CP"].ToString();
                item.IntCveMunicipio = int.Parse(rw["CveMunicipio"].ToString());
                item.IntCveEstado = int.Parse(rw["CveEstado"].ToString());
                item.StrTelefono = rw["Telefono"].ToString();
                item.StrTelefonoMovil = rw["TelefonoMovil"].ToString();
                item.StrCorreoElectronico = rw["CorreoElectronico"].ToString();
                item.IntCveEstatus = int.Parse(rw["CveEstatus"].ToString());
               

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

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListadoChoferes");

            foreach (DataRow rw in _dt.Rows)
            {
                vParametros item = new vParametros();
                item.IntCveChofer = int.Parse(rw["CveChofer"].ToString());
                item.StrNombre = rw["Nombre"].ToString();
                item.StrRFC = rw["RFC"].ToString();
                item.StrDireccion = rw["Direccion"].ToString();
                item.StrColonia = rw["Colonia"].ToString();
                item.StrCP = rw["CP"].ToString();
                item.IntCveMunicipio = int.Parse(rw["CveMunicipio"].ToString());
                item.IntCveEstado = int.Parse(rw["CveEstado"].ToString());
                item.StrTelefono = rw["Telefono"].ToString();
                item.StrTelefonoMovil = rw["TelefonoMovil"].ToString();
                item.StrCorreoElectronico = rw["CorreoElectronico"].ToString();
                item.IntCveEstatus = int.Parse(rw["CveEstatus"].ToString());
                item.StrEstatusChofer = rw["EstatusChofer"].ToString();
                Lista.Add(item);

            }

            return Lista;
        }

        public int DeleteData(int CveChofer)
        {
            int borrado = 0;

            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("CveChofer", CveChofer.ToString(), "string"));


            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SPDeleteChoferes");

            foreach (DataRow rw in _dt.Rows)
            {
                borrado = int.Parse(rw["Cuenta"].ToString());

            }

            return borrado;
        }

    }
}
