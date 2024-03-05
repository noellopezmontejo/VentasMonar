using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VentasMonar.Common.Clases
{
    class cConceptos
    {
        public static cPageBase pb = new cPageBase();

        public class v_Parametros
        {
            private int intCveConcepto;
            private string strDescripcion;
            private string strClaveProdServ;
            private string strClaveUnidad;
            private double dblPrecio;
            private int intIva;
            private int intIvaRetencion;
            private int intIsrRetencion;
            private int intIsrRetencionResico;
            private int intOpcion;
            public int IntCveConcepto { get => intCveConcepto; set => intCveConcepto = value; }
            public string StrDescripcion { get => strDescripcion; set => strDescripcion = value; }
            public string StrClaveProdServ { get => strClaveProdServ; set => strClaveProdServ = value; }
            public string StrClaveUnidad { get => strClaveUnidad; set => strClaveUnidad = value; }
            public double DblPrecio { get => dblPrecio; set => dblPrecio = value; }
          
            
            public int IntIvaRetencion { get => intIvaRetencion; set => intIvaRetencion = value; }
            public int IntIsrRetencion { get => intIsrRetencion; set => intIsrRetencion = value; }
            public int IntIsrRetencionResico { get => intIsrRetencionResico; set => intIsrRetencionResico = value; }

            public int IntOpcion { get => intOpcion; set => intOpcion = value; }
            public int IntIva { get => intIva; set => intIva = value; }

            public string Abreviacion { get; set; }
            public string Porcentaje { get; set; }

            public int CveImpuesto { get; set; }

            public int CveLetra { get; set; }

            public int intCvePrefijoActual { get; set; }

            public string FolioActual { get; set; }

            public decimal dcImporte { get; set; }
            public decimal dcIva { get; set; }
            public decimal dcPrecio { get; set; }
            public decimal dcSubTotal { get; set; }

            public int ChkSerie { get; set; }

            public ArrayList ArListaImpuesto { get; set; }
            public int CveObjetoImpuesto { get; set; }
            public int CveEmisor { get; set; }

            public int ChkDesgloce { get; set; }

            public int ChkNotaAdicional { get; set; }
            public int ChkCompartido { get; set; }
        }

        public class v_ImpuestosConceptos
        {
            public int Id { get; set; }
            public int IntOpcion { get; set; }
            public int CveFactura { get; set; }
            public int CveConcepto { get; set; }
            public int CveImpuesto { get; set; }
            public string Descripcion { get; set; }
            public int CveTipoImpuesto { get; set; }
            public string TipoImpuesto { get; set; }
            public int CveTipoEntidad { get; set; }
            public string TipoEntidadImpuesto { get; set; }
            public decimal Porcentaje { get; set; }
            public decimal ImporteBase { get; set; }
            public decimal ValorImpuesto { get; set; }
            public decimal ValorPorcentaje { get; set; }
            public decimal ValorTabla { get; set; }
            public string Signo { get; set; }
            public string sGuidHijo { get; set; }
            public string c_Impuesto { get; set; }
            public string TipoFactor { get; set; }
            public decimal TasaCuota { get; set; }

            public decimal FI { get; set; }

            public decimal ImporteBaseP { get; set; }
            public decimal ValorImpuestoP { get; set; }

            public bool Chk { get; set; }

        }

        ArrayList ListaParametros = new ArrayList();

        public int Save(ArrayList ListaDetalle)
        {
            int CveConcepto = 0;

            string Resultado = "";
            string Query = "";
            foreach (v_Parametros item in ListaDetalle)
            {
                if (item.IntOpcion == 0)
                {
                    /*
                    DataTable _data = new DataTable();
                    _data = Clases.Helpers._dtContadorLetraConsecutivo(item.CveLetra, "Concepto");

                    string Folio = "";
                    int Consecutivo = 0;
                    foreach (DataRow itemF in _data.Rows)
                    {
                        Consecutivo = int.Parse(itemF["Concepto"].ToString());
                        Folio = itemF["Prefijo"].ToString();
                    }

                    if (Consecutivo > 0)
                    {
                        Folio = Folio + Consecutivo.ToString("D3");
                    }
                    */

                    Query = "Insert Into ConceptosCfdi(Descripcion,ClaveProdServ,ClaveUnidad,Precio,Iva,IvaRetenido," +
                        "IsrRetenido, IsrRetenidoResico, CveImpuesto, CvePrefijo, Folio, ChkSerie, CveObjetoImpuesto, CveEmisor," +
                        "ChkDesgloce, ChkNotaAdicional, ChkCompartido)";
                    Query += " Values('" + item.StrDescripcion + "','" + item.StrClaveProdServ + "','" + item.StrClaveUnidad + "'," + item.DblPrecio + "," +
                        item.IntIva + "," + item.IntIvaRetencion + "," + item.IntIsrRetencion + "," + item.IntIsrRetencionResico + "," + 
                        item.CveImpuesto + "," + item.CveLetra + ",'" + item.FolioActual + "'," + item.ChkSerie + "," + item.CveObjetoImpuesto + "," + item.CveEmisor + ","+
                        item.ChkDesgloce + "," + item.ChkNotaAdicional + "," + item.ChkCompartido + ")";

                    CveConcepto = pb.performinsertquery(Query);

                    if(CveConcepto>0)
                    {
                        string QueryDeleteConceptoImpuesto = "", QueryInsertConceptoImpuesto="";
                        QueryDeleteConceptoImpuesto = "Delete From ConceptosCfdiImpuestos Where CveConcepto=" + CveConcepto;
                        pb.performupdatequery(QueryDeleteConceptoImpuesto);

                        foreach  (Clases.cConceptos.v_ImpuestosConceptos im in item.ArListaImpuesto)
                        {

                            QueryInsertConceptoImpuesto = "Insert into ConceptosCfdiImpuestos(CveConcepto, CveImpuesto) Values(" +
                                CveConcepto + "," + im.CveImpuesto + ")";
                            pb.performinsertquery(QueryInsertConceptoImpuesto);

                        }

                    }

                }
                else
                {


                    string Folio = "";
                    int Consecutivo = 0;
                    int CvePrefijo = 0;
                    /*
                    if (item.intCvePrefijoActual != item.CveLetra)
                    {
                        DataTable _data = new DataTable();
                        _data = Clases.Helpers._dtContadorLetraConsecutivo(item.CveLetra, "Cliente");

                        foreach (DataRow itemL in _data.Rows)
                        {
                            Consecutivo = int.Parse(itemL["Cliente"].ToString());
                            Folio = itemL["Prefijo"].ToString();
                        }

                        if (Consecutivo > 0)
                        {
                            Folio = Folio + Consecutivo.ToString("D3");
                        }

                        CvePrefijo = item.CveLetra;
                    }
                    else
                    {
                        Folio = item.FolioActual;
                        CvePrefijo = item.intCvePrefijoActual;
                    }

                    */
                    Query = "UPDATE ConceptosCfdi SET  CvePrefijo=" + CvePrefijo + ", Folio='" + item.FolioActual + "', Descripcion = '" + item.StrDescripcion  + " ', ClaveProdServ = '" + item.StrClaveProdServ + "',";
                    Query += "ClaveUnidad = '" + item.StrClaveUnidad  +"', Precio = " + item.DblPrecio + ",Iva =" + item.IntIva +
                        ",IvaRetenido = " + item.IntIvaRetencion +",IsrRetenido =" + item.IntIsrRetencion + ",IsrRetenidoResico=" + item.IntIsrRetencionResico + 
                        ",CveImpuesto=" + item.CveImpuesto + ", ChkSerie=" + item.ChkSerie + ",CveObjetoImpuesto=" + item.CveObjetoImpuesto +
                        ",ChkDesgloce=" + item.ChkDesgloce + ",ChkNotaAdicional=" + item.ChkNotaAdicional + ", ChkCompartido= " + item.ChkCompartido + " WHERE CveConcepto =" + item.IntCveConcepto + ";";

                    pb.performupdatequery(Query);
                    CveConcepto = item.IntCveConcepto;


                    if (CveConcepto > 0)
                    {
                        string QueryDeleteConceptoImpuesto = "", QueryInsertConceptoImpuesto = "";
                        QueryDeleteConceptoImpuesto = "Delete From ConceptosCfdiImpuestos Where CveConcepto=" + CveConcepto;
                        pb.performupdatequery(QueryDeleteConceptoImpuesto);

                        foreach (Clases.cConceptos.v_ImpuestosConceptos im in item.ArListaImpuesto)
                        {

                            QueryInsertConceptoImpuesto = "Insert into ConceptosCfdiImpuestos(CveConcepto, CveImpuesto) Values(" +
                                CveConcepto + "," + im.CveImpuesto + ")";
                            pb.performinsertquery(QueryInsertConceptoImpuesto);

                        }

                    }


                }


            }
                        
            return CveConcepto;
        }

        public int SaveImpuestos(ArrayList ListaDetalle)
        {
            int CveImpuesto = 0;

            string Resultado = "";
            string Query = "";
            foreach (v_ImpuestosConceptos item in ListaDetalle)
            {
                if (item.IntOpcion == 0)
                {
                    /*
                    DataTable _data = new DataTable();
                    _data = Clases.Helpers._dtContadorLetraConsecutivo(item.CveLetra, "Concepto");

                    string Folio = "";
                    int Consecutivo = 0;
                    foreach (DataRow itemF in _data.Rows)
                    {
                        Consecutivo = int.Parse(itemF["Concepto"].ToString());
                        Folio = itemF["Prefijo"].ToString();
                    }

                    if (Consecutivo > 0)
                    {
                        Folio = Folio + Consecutivo.ToString("D3");
                    }
                    */

                    Query = "Insert Into CatImpuestos(Descripcion,Porcentaje,CveTipoImpuesto,CveTipoEntidad, c_Impuesto, Signo,TipoFactor, TasaCuota) ";

                    Query += " Values('" + item.Descripcion + "'," + item.Porcentaje + "," + item.CveTipoImpuesto + "," + item.CveTipoEntidad + ",'" +
                        item.c_Impuesto + "','" + item.Signo + "','" + item.TipoFactor + "'," + item.TasaCuota + ")";

                    CveImpuesto = pb.performinsertquery(Query);

                    if (CveImpuesto > 0)
                    {
                       

                    }

                }
                else
                {


                    string Folio = "";
                    int Consecutivo = 0;
                    int CvePrefijo = 0;
                    /*
                    if (item.intCvePrefijoActual != item.CveLetra)
                    {
                        DataTable _data = new DataTable();
                        _data = Clases.Helpers._dtContadorLetraConsecutivo(item.CveLetra, "Cliente");

                        foreach (DataRow itemL in _data.Rows)
                        {
                            Consecutivo = int.Parse(itemL["Cliente"].ToString());
                            Folio = itemL["Prefijo"].ToString();
                        }

                        if (Consecutivo > 0)
                        {
                            Folio = Folio + Consecutivo.ToString("D3");
                        }

                        CvePrefijo = item.CveLetra;
                    }
                    else
                    {
                        Folio = item.FolioActual;
                        CvePrefijo = item.intCvePrefijoActual;
                    }

                    */
                    Query = "UPDATE CatImpuestos SET  Descripcion='" + item.Descripcion + "', Porcentaje='" + item.Porcentaje + "', CveTipoImpuesto = " + item.CveTipoImpuesto + " , CveTipoEntidad = " + item.CveTipoEntidad + ",";
                    Query += "c_Impuesto = '" + item.c_Impuesto + "', Signo = '" + item.Signo + "',TipoFactor ='" + item.TipoFactor + 
                        "',TasaCuota = " + item.TasaCuota + " WHERE CveImpuesto =" + item.CveImpuesto + ";";

                    pb.performupdatequery(Query);
                    CveImpuesto = item.CveImpuesto;


                    if (CveImpuesto > 0)
                    {
                        

                    }


                }


            }

            return CveImpuesto;
        }

        public int SaveLocales(ArrayList ListaDetalle)
        {
            int CveConcepto = 0;

            string Resultado = "";
            string Query = "";
            foreach (v_Parametros item in ListaDetalle)
            {
                if (item.IntOpcion == 0)
                {
                    Query = "INSERT INTO CatRetenciones(Descripcion, Abreviacion, Porcentaje)" +
                        " VALUES ('";
                    Query += item.StrDescripcion + "','" + item.Abreviacion + "'," + item.Porcentaje + ")";

                    CveConcepto = pb.performinsertquery(Query);

                }
                else
                {
                    Query = "UPDATE CatRetenciones " +
                        "SET  Descripcion='" + item.StrDescripcion + "',Abreviacion='" + item.Abreviacion + "', Porcentaje=" + item.Porcentaje + " WHERE CveRetencion=" + CveConcepto;
                    pb.performupdatequery(Query);
                    CveConcepto = item.IntCveConcepto;
                }


            }

            return CveConcepto;
        }

        public ArrayList ListaDetalle(int CveConcepto)
        {
            ArrayList Lista=new ArrayList();

            string Query = "Select * From ConceptosCfdi Where CveConcepto=" + CveConcepto;

            DataTable _dt = new DataTable();
            _dt = pb.SP_DataReaderQuery(Query);


            foreach(DataRow rw in _dt.Rows)
            {
                v_Parametros item = new v_Parametros();
                item.IntCveConcepto = int.Parse(rw["CveConcepto"].ToString());
                item.StrDescripcion = rw["Descripcion"].ToString();
                item.StrClaveProdServ = rw["ClaveProdServ"].ToString();
                item.StrClaveUnidad = rw["ClaveUnidad"].ToString();
                item.DblPrecio = double.Parse(rw["Precio"].ToString());
                item.IntIva = int.Parse(rw["Iva"].ToString());
                item.IntIvaRetencion = int.Parse(rw["IvaRetencion"].ToString());
                item.IntIsrRetencion = int.Parse(rw["IsrRetencion"].ToString());
                Lista.Add(item);
            }
            
            return Lista;
        }

        public static DataTable ListaDetalle(int opcion = 0, string Busqueda = "", int CveEmisor=0)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            if (opcion == 0)
            {
                Lista.Add(cPage.addparametro("_CveEmisor", CveEmisor.ToString(), "int"));
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetDataConceptos");
            }
            else
            {
                Lista.Add(cPage.addparametro("_CveEmisor", CveEmisor.ToString(), "int"));
                Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));
                Lista.Add(cPage.addparametro("_Busqueda", Busqueda, "string"));

                _dt = pb.SP_Busca_Reader(Lista, "SP_GetDataConceptos_Busqueda");

            }

            return _dt;
        }
        public static DataTable ListaDetalleFactura(int opcion = 0, string Busqueda = "", int CveEmisor = 0)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            if (opcion == 0)
            {
                Lista.Add(cPage.addparametro("CveFactura", Busqueda.ToString(), "int"));
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetDataConceptos_Factura");
            }

            return _dt;
        }
        public static DataTable ListaImPuestos(int opcion = 0, string Busqueda = "")
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            if (opcion == 0)
            {
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetDataImpuestos");
            }
            else
            {
                Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));
                Lista.Add(cPage.addparametro("_Busqueda", Busqueda, "string"));

                _dt = pb.SP_Busca_Reader(Lista, "SP_GetDataImpuestos_Busqueda");

            }

            return _dt;
        }
        public static DataTable ListaDetalleLocales()
        {
            ArrayList Lista = new ArrayList();



            DataTable _dt = new DataTable();
            _dt = pb.SP_Busca_Reader(Lista, "SP_GetDataImpuestosLocales");


            return _dt;
        }

        public DataTable ListaDetalle_dt(int CveConcepto)
        {
            DataTable _dt = new DataTable();

            string Query = "Select * From ConceptosCfdi Where CveConcepto=" + CveConcepto;
            
            _dt = pb.SP_DataReaderQuery(Query);
            
            return _dt;
        }

        public static DataTable GetConceptoImpuesto(int CveImpuesto=0, int CveConcepto=0)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            //Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));
            if (CveConcepto == 0)
            {
                Lista.Add(cPage.addparametro("CveImpuesto", CveImpuesto.ToString(), "int"));
                Lista.Add(cPage.addparametro("CveConcepto", CveConcepto.ToString(), "int"));
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetImpuestoDetalle");
            }
            else
            {
                Lista.Add(cPage.addparametro("CveImpuesto", CveImpuesto.ToString(), "int"));
                Lista.Add(cPage.addparametro("CveConcepto", CveConcepto.ToString(), "int"));
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetImpuestoDetalle");
            }

            return _dt;
        }
        public static DataTable GetConceptoImpuestoRetencion(decimal _ImporteBase)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            //Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));
          
                Lista.Add(cPage.addparametro("ImporteBase", _ImporteBase.ToString(), "decimal"));
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetImpuestoDetalleRetencion");
           

            return _dt;
        }

        public static DataTable GetFacturaConceptoImpuesto(int CveConcepto = 0)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            //Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));

           

            if (CveConcepto != 0)
            {
               // Lista.Add(cPage.addparametro("CveImpuesto", CveImpuesto.ToString(), "int"));
                Lista.Add(cPage.addparametro("CveConcepto", CveConcepto.ToString(), "int"));
                _dt = pb.SP_Busca_Reader(Lista, "SP_GetFacturaConceptoImpuestos");
            }
            

            return _dt;
        }

        public static DataTable GetConceptoDetalleFactura(int _CveFactura)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            //Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));

            Lista.Add(cPage.addparametro("CveFactura", _CveFactura.ToString(), "int"));
            _dt = pb.SP_Busca_Reader(Lista, "SP_GetDetalleConceptoFactura");


            return _dt;
        }

        public static DataTable GetDetalleImpuestoFactura(int _CveFactura)
        {
            ArrayList Lista = new ArrayList();
            cPageBase cPage = new cPageBase();


            DataTable _dt = new DataTable();

            //Lista.Add(cPage.addparametro("_Opcion", opcion.ToString(), "int"));

            Lista.Add(cPage.addparametro("CveFactura", _CveFactura.ToString(), "int"));
            _dt = pb.SP_Busca_Reader(Lista, "SP_GetFacturaDetalleImpuesto");


            return _dt;
        }


    }
}
