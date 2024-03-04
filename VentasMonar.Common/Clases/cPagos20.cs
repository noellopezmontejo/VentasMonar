using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;
using VentasMonar.Desktop.Clases;
using Profact.TimbraCFDI40;
using static VentasMonar.Desktop.PageBase;

namespace VentasMonar.Desktop.Clases
{
    public class cPagos20
    {
        public ArrayList GetFacturaValidate(int CveFactura, decimal DcimpPagado, decimal DcimpPagadoP, int ChkFac,   decimal TipoCambio=1, int CveMoneda=101, string c_Moneda="MXN", 
            int CveTipoRelacion=0, string strDescripcionTipoRelacion="", string c_TipoRelacion="")
        {
            int _IntCveFactura = CveFactura;
            decimal _DcImprtePagado = DcimpPagado;
            DataTable _dtGet=new DataTable();
            Clases.cFacturacion _cFacturacion = new Clases.cFacturacion();
            ArrayList ListaProductosVta = new ArrayList();


            _dtGet = _cFacturacion.GetDatosFacturaValidacion(_IntCveFactura, _DcImprtePagado, ChkFac);
           
            foreach (DataRow _val in _dtGet.Rows)
            {
                if (decimal.Parse(_val["ImporteDiferencia"].ToString()) != 0)
                {
                    Clases.cFacturacion40.DoctoRelacionadoComplemento _dc = new Clases.cFacturacion40.DoctoRelacionadoComplemento();

                    _dc.IntCveFactura = int.Parse(_val["CveFactura"].ToString());
                    _dc.IntCveReceptor = int.Parse(_val["CveReceptor"].ToString());
                    _dc.Strfolio = _val["FolioInt"].ToString();
                    _dc.Strserie = "A";
                    _dc.StridDocumento = _val["UUID"].ToString();

                    _dc.DcimpSaldoAnt = Math.Round(decimal.Parse(_val["ImporteDiferencia"].ToString()),NoDecimalesTotales._NoDecimalesTotales); //decimal.Parse(_val["Total"].ToString()) - decimal.Parse(_val)
                    _dc.DcimpPagado = Math.Round(decimal.Parse(_val["_DcImportePagado"].ToString()),NoDecimalesTotales._NoDecimalesTotales);
                    _dc.DcimpSaldoInsoluto = Math.Round(decimal.Parse(_val["_ImporteSaldoInsoluto"].ToString()),NoDecimalesTotales._NoDecimalesTotales);
                    _dc.IntCveFacturaDoctoRelacionado = int.Parse(_val["CveFactura"].ToString());
                    _dc.StrmetodoPagoDr = _val["MetodoPagoSat"].ToString();
                    _dc.StrmonedaDr = "MXN";// _val["Moneda"].ToString();
                    _dc.StrnumParcialidad = _val["_CuentaDocto"].ToString();
                    _dc.StrtipoCambioDr = _val["TipoCambio"].ToString();
                    _dc.StrFechaEmision = _val["FechaEmision"].ToString();

                    _dc.DcimpTotalFactura = decimal.Parse(_val["_ImporteFactura"].ToString());
                    _dc.ImportePagadoP = DcimpPagadoP;
                    _dc._c_ObjetoImpDR = "02";// _val["c_ObjetoImp"].ToString();
                    _dc.sGuid=Guid.NewGuid().ToString();    
                    //_dc.str = TipoCambio;
                    //_dc.CveMoneda=CveMoneda;
                    //_dc.c_Moneda=c_Moneda;

                    //Entro = 1;

                    if (CveTipoRelacion != 0)
                    {
                        _dc.IntCveTipoRelacion = CveTipoRelacion;
                        _dc.StrDescripcionTipoRelacion = strDescripcionTipoRelacion;
                        _dc.Str_c_TipoRelacion = c_TipoRelacion;
                        _dc.sGuid=Guid.NewGuid().ToString();
                    }

                    // Nuevo

                    ArrayList ListaRelacionCfdi_ComplementoImpuesto = new ArrayList();
                    ArrayList _ListaImpuestoTotal = new ArrayList();
                    decimal BaseImporteP = DcimpPagadoP;

                    decimal BaseImporte = 0, FI = 1, FP = 0;

                    decimal TotalConcepto = _dc.DcimpTotalFactura; ///Math.Round((decimal)item["Total"], NoDecimalesTotales._NoDecimalesTotales);




                    FP = Math.Round(TotalConcepto / _dc.DcimpTotalFactura, 6);

                    FI += 0.160000m;

                    BaseImporte = Math.Round((_DcImprtePagado * FP) / FI, NoDecimalesImpuestos._NoDecimalesImpuestos);
                    BaseImporteP = Math.Round((DcimpPagadoP * FP) / FI, NoDecimalesImpuestos._NoDecimalesImpuestos);

                    //BaseImporte = Math.Round(_DcImprtePagado * TipoCambio,6);
                    BaseImporte = Math.Round((_DcImprtePagado * FP) / FI, NoDecimalesImpuestos._NoDecimalesImpuestos);
                    BaseImporteP = Math.Round((DcimpPagadoP * FP) / FI, NoDecimalesImpuestos._NoDecimalesImpuestos);

                    cConceptos.v_ImpuestosConceptos v_Impuestos = new cConceptos.v_ImpuestosConceptos();
                    v_Impuestos.CveFactura = _IntCveFactura;
                    v_Impuestos.CveConcepto = 0;// int.Parse(itemI["CveConcepto"].ToString());
                    v_Impuestos.CveImpuesto = 1; //int.Parse(itemI["CveImpuesto"].ToString());
                    v_Impuestos.Porcentaje = 16.00m; //decimal.Parse(itemI["Porcentaje"].ToString());
                    switch (v_Impuestos.CveImpuesto)
                    {
                        case 1: // IVA 16%
                        case 2:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                            v_Impuestos.ValorImpuesto = Math.Round(BaseImporte * (v_Impuestos.Porcentaje / 100), NoDecimalesTotales._NoDecimalesTotales);
                            v_Impuestos.ValorImpuestoP = Math.Round(BaseImporteP * (v_Impuestos.Porcentaje / 100), NoDecimalesTotales._NoDecimalesTotales);
                            break;
                        case 5:
                            /*
                                v_Impuestos.ValorImpuesto = (BaseImporte * (v_Impuestos.Porcentaje / 100) / 3);
                                v_Impuestos.ValorImpuesto = Math.Round(v_Impuestos.ValorImpuesto * 2, 6);

                                v_Impuestos.ValorImpuestoP = (BaseImporteP * (v_Impuestos.Porcentaje / 100) / 3);
                                v_Impuestos.ValorImpuestoP = Math.Round(v_Impuestos.ValorImpuestoP * 2, 6);
                            */
                            v_Impuestos.ValorImpuesto = Math.Round(BaseImporte * (v_Impuestos.Porcentaje / 100), NoDecimalesTotales._NoDecimalesTotales);
                            v_Impuestos.ValorImpuestoP = Math.Round(BaseImporteP * (v_Impuestos.Porcentaje / 100), NoDecimalesTotales._NoDecimalesTotales);

                            break;
                    }

                    v_Impuestos.TasaCuota = 0.160000m;
                    v_Impuestos.TipoFactor = "Tasa";
                    v_Impuestos.c_Impuesto = "002";
                    v_Impuestos.Signo = "+";

                    v_Impuestos.ImporteBase = Math.Round(BaseImporte, NoDecimalesTotales._NoDecimalesTotales);
                    v_Impuestos.ImporteBaseP = Math.Round(BaseImporteP, NoDecimalesTotales._NoDecimalesTotales);

                    ListaRelacionCfdi_ComplementoImpuesto.Add(v_Impuestos);

                    _dc.ListaImpuestos = ListaRelacionCfdi_ComplementoImpuesto;


                    ///

                    decimal ValorImpuestoTotal = 0, ValorImpuestoTotalP = 0, BaseImporteTotal = 0, BaseImporteTotalP = 0;

                    foreach (cConceptos.v_ImpuestosConceptos item in _dc.ListaImpuestos)
                    {

                        ValorImpuestoTotal += item.ValorImpuesto;
                        ValorImpuestoTotalP += item.ValorImpuestoP;
                        BaseImporteTotal += item.ImporteBase;
                        BaseImporteTotalP += item.ImporteBaseP;
                    }

                        cConceptos.v_ImpuestosConceptos v_ImpuestosT = new cConceptos.v_ImpuestosConceptos();
                    v_ImpuestosT.CveFactura = _IntCveFactura;
                    //v_Impuestos.CveConcepto = int.Parse(_iTotal["CveConcepto"].ToString());
                    v_ImpuestosT.CveImpuesto = 1; // int.Parse(_iTotal["CveImpuesto"].ToString());
                    v_ImpuestosT.Porcentaje = 16.00m;// decimal.Parse(_iTotal["Porcentaje"].ToString());

                    v_ImpuestosT.TasaCuota = 0.160000m;// decimal.Parse(_iTotal["TasaCuota"].ToString());
                    v_ImpuestosT.TipoFactor = "Tasa";// _iTotal["TipoFactor"].ToString();
                    v_ImpuestosT.c_Impuesto = "002";// _iTotal["c_Impuesto"].ToString();
                    v_ImpuestosT.Signo = "+"; //_iTotal["Signo"].ToString();

                    v_ImpuestosT.ValorImpuesto = ValorImpuestoTotal;
                    v_ImpuestosT.ValorImpuestoP = ValorImpuestoTotalP;
                    v_ImpuestosT.ImporteBase = BaseImporteTotal;
                    v_ImpuestosT.ImporteBaseP = BaseImporteTotalP;

                        _ListaImpuestoTotal.Add(v_ImpuestosT);

                        _dc.ListaImpuestosTotal = _ListaImpuestoTotal;

                        //

                    ListaProductosVta.Add(_dc);

                }

            }

            return ListaProductosVta;
        }
    }
}
