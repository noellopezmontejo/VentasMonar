using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Desktop.Clases
{
    class cAlmacenes
    {

        cPageBase pb = new cPageBase();

        public class vParametros
        {
            private int intCve;
            private string strDescripcion;
            private int intCveUser;
            private int intCveEstatus;
            private int intCveUserEdit;
            private string strFechaAlta;
            private string strFechaEdit;
            private int intActualiza;
            private string strEstatusAlmacen;
            private string strUbicacion;
            private string strReponsable;
            private int intPredeterminado;
            private string strPrefijo;

            public string StrPrefijo
            {
                get { return strPrefijo; }
                set { strPrefijo = value; }
            }

            public int IntPredeterminado
            {
                get { return intPredeterminado; }
                set { intPredeterminado = value; }
            }

            public string StrReponsable
            {
                get { return strReponsable; }
                set { strReponsable = value; }
            }

            public string StrUbicacion
            {
                get { return strUbicacion; }
                set { strUbicacion = value; }
            }

            public string StrEstatusAlmacen
            {
                get { return strEstatusAlmacen; }
                set { strEstatusAlmacen = value; }
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
            public string StrDescripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }
            public int IntCve
            {
                get { return intCve; }
                set { intCve = value; }
            }

        }

        ArrayList ListaParametros = new ArrayList();

        public int SaveData(ArrayList ListaDetalle)
        {
            int CveChofer = 0;

            string Resultado = "";

            foreach (vParametros item in ListaDetalle)
            {
                ListaParametros.Add(pb.addparametro("Descripcion", item.StrDescripcion, "string"));
                ListaParametros.Add(pb.addparametro("CveEstatus", item.IntCveEstatus.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("Ubicacion",item.StrUbicacion,"string"));
                ListaParametros.Add(pb.addparametro("Responsable", item.StrReponsable, "string"));
                ListaParametros.Add(pb.addparametro("Prefijo", item.StrPrefijo, "string"));
                ListaParametros.Add(pb.addparametro("CveUser", item.IntCveUser.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveUserEdit", item.IntCveUserEdit.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("FechaAlta", item.StrFechaAlta, "string"));
                ListaParametros.Add(pb.addparametro("FechaEdit", item.StrFechaEdit, "string"));
                ListaParametros.Add(pb.addparametro("Actualiza", item.IntActualiza.ToString(), "int"));
                ListaParametros.Add(pb.addparametro("CveAlmacen", item.IntCve.ToString(), "int"));

            }

            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveAlmacen");

            foreach (DataRow rw in _dt.Rows)
            {
                Resultado = rw["CveAlmacen"].ToString();
            }

            if (pb.IsNumeric(Resultado))
                CveChofer = int.Parse(Resultado);

            return CveChofer;
        }

        public ArrayList ListaEditar(int CveAlmacen)
        {
            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("CveAlmacen", CveAlmacen.ToString(), "int"));


            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaAlmacenEdit");

            foreach (DataRow rw in _dt.Rows)
            {
                vParametros item = new vParametros();

                item.IntCve = int.Parse(rw["CveAlmacen"].ToString());
                item.StrDescripcion = rw["Descripcion"].ToString();
                item.StrUbicacion = rw["Ubicacion"].ToString();
                item.StrReponsable = rw["Responsable"].ToString();
                item.StrPrefijo = rw["Prefijo"].ToString();
                item.IntCveEstatus = int.Parse(rw["CveEstatus"].ToString());
                item.StrUbicacion = rw["Ubicacion"].ToString();
                item.StrReponsable = rw["Responsable"].ToString();
               
                Lista.Add(item);

            }


            return Lista;

        }

        public ArrayList ListarVer(string Busqueda)
        {
            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("Busqueda", Busqueda, "string"));


            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_ListaAlmacen");

            foreach (DataRow rw in _dt.Rows)
            {
                vParametros item = new vParametros();
                item.IntCve = int.Parse(rw["CveAlmacen"].ToString());
                item.StrDescripcion = rw["Descripcion"].ToString();
                item.IntCveEstatus = int.Parse(rw["CveEstatus"].ToString());
                item.StrEstatusAlmacen = rw["EstatusAlmacen"].ToString();
                item.StrUbicacion = rw["Ubicacion"].ToString();
                item.StrReponsable = rw["Responsable"].ToString();
                Lista.Add(item);

            }

            return Lista;
        }

        public int DeleteData(int Cve)
        {
            int borrado = 0;

            ArrayList Lista = new ArrayList();

            ListaParametros.Clear();

            ListaParametros.Add(pb.addparametro("CveRuta", Cve.ToString(), "string"));


            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SPDeleteRutas");

            foreach (DataRow rw in _dt.Rows)
            {
                borrado = int.Parse(rw["Cuenta"].ToString());

            }

            return borrado;
        }

    }
}
