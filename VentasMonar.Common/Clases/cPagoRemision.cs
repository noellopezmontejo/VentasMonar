using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentasMonar.Desktop.Clases;

namespace VentasMonar.Desktop.Clases
{
    class cPagoRemision
    {
        
        Clases.cPageBase CP = new Clases.cPageBase();
        
        public class cFormaPago
        {
            private int intCveFormPago;
            private string strDescripcion;
            private string strNoDocumento;
            private decimal dblImporte;

            public decimal Importe
            {
                get { return dblImporte; }
                set { dblImporte = value; }
            }

            public string NoDocumento
            {
                get { return strNoDocumento; }
                set { strNoDocumento = value; }
            }

            public string Descripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }

            public int CveFormPago
            {
                get { return intCveFormPago; }
                set { intCveFormPago = value; }
            }
        }

        ArrayList ListaParametros = new ArrayList();
        ArrayList ListaConsultaDatos = new ArrayList();

        private ArrayList CargaListaFormaPago(string opcion, int CveFormaPago=0, decimal dblImportePago=0)
        {
            

            ListaParametros.Clear();
            ListaConsultaDatos.Clear();

            Clases.cPageBase.SP_Parametros sp_1 = new Clases.cPageBase.SP_Parametros();
            sp_1.StrNombreParametro = "opcion";
            sp_1.StrTipoValor = "int";
            sp_1.StrValueParametro = opcion;

            ListaParametros.Add(sp_1);

            DataTable dt_ =CP.SP_Busca_Reader(ListaParametros, "SP_ConsultaDatos");

            foreach (DataRow rw in dt_.Rows)
            {
                cFormaPago cr = new cFormaPago();

                

                cr.CveFormPago = int.Parse(rw["CveFormaPago"].ToString());
                cr.Descripcion=rw["Descripcion"].ToString();
                cr.NoDocumento = rw["NoDocumento"].ToString();

                if (CveFormaPago == cr.CveFormPago)
                    cr.Importe = dblImportePago;
                else
                cr.Importe = decimal.Parse(rw["Importe"].ToString());


                ListaConsultaDatos.Add(cr);

            }

            return ListaConsultaDatos;
           
        }

        public ArrayList loadgridFormaPago(string opcion, int CveFormaPago=0, decimal dblImporteAdevolver=0)
        {
            ArrayList Lista = new ArrayList();

            Lista=CargaListaFormaPago(opcion, CveFormaPago, dblImporteAdevolver);
            
            return Lista;

        }
        public decimal ImportaPagado(int CveFormaPago=0)
        {
            decimal ImporteTotal = 0;
            foreach (cFormaPago rw in ListaConsultaDatos)
            {
                if(rw.CveFormPago!=CveFormaPago)
                ImporteTotal += rw.Importe;
            }
            
            return ImporteTotal;
        }
        public bool SiDocumento(ArrayList ListaPagos)
        {
            bool Sidocumento = true;

            foreach (cFormaPago rw in ListaPagos)
            {
                if (rw.Importe > 0)
                {
                    switch (rw.CveFormPago)
                    {
                        case 3:
                        case 4:
                        case 5:
                        case 7:
                            if (rw.NoDocumento == "")
                            {
                                Sidocumento = false;
                                return Sidocumento;
                            }

                            break;
                    }
                }
            }
            
            return Sidocumento;
        }

    }
}
