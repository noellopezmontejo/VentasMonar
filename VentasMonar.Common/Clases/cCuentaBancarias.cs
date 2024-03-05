using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cCuentaBancarias
    {
        private int intCveCuenta;
        private string strNoCuenta;
        private string strClabe;
        private int intCveBanco;
        private int intCveCuentaMaestra;
        private string strFechaAlta;
        
        private int intCveUser;
        private decimal dcSaldo;

        private string strFechaUltimoMovimiento;
        private int intCveUserUltimoMovimiento;
        private decimal dcImporteUltimoMovimiento;
        private int intCveEstatus;
        private int intInicialCheque;
        private string strNombreCuenta;

        public int IntCveCuenta { get => intCveCuenta; set => intCveCuenta = value; }
        public string StrNoCuenta { get => strNoCuenta; set => strNoCuenta = value; }
        public string StrClabe { get => strClabe; set => strClabe = value; }
        public int IntCveBanco { get => intCveBanco; set => intCveBanco = value; }
        public int IntCveCuentaMaestra { get => intCveCuentaMaestra; set => intCveCuentaMaestra = value; }
        public string StrFechaAlta { get => strFechaAlta; set => strFechaAlta = value; }
        public int IntCveUser { get => intCveUser; set => intCveUser = value; }
        public decimal DcSaldo { get => dcSaldo; set => dcSaldo = value; }
        public string StrFechaUltimoMovimiento { get => strFechaUltimoMovimiento; set => strFechaUltimoMovimiento = value; }
        public int IntCveUserUltimoMovimiento { get => intCveUserUltimoMovimiento; set => intCveUserUltimoMovimiento = value; }
        public decimal DcImporteUltimoMovimiento { get => dcImporteUltimoMovimiento; set => dcImporteUltimoMovimiento = value; }
        public int IntCveEstatus { get => intCveEstatus; set => intCveEstatus = value; }
        public int IntInicialCheque { get => intInicialCheque; set => intInicialCheque = value; }
        public string StrNombreCuenta { get => strNombreCuenta; set => strNombreCuenta = value; }

        Clases.cPageBase pb = new cPageBase();
        ArrayList arrParam = new ArrayList();
        public bool Save()
        {
            bool Result = false;

            DataTable _dtCuenta= new DataTable();

            string Resultado = "";

            arrParam.Add(pb.addparametro("NombreCuenta", StrNombreCuenta, "string"));
            arrParam.Add(pb.addparametro("NoCuenta", StrNoCuenta , "string"));
            arrParam.Add(pb.addparametro("CLABE", StrClabe, "string"));
            arrParam.Add(pb.addparametro("CveBanco", IntCveBanco.ToString(), "int"));
            arrParam.Add(pb.addparametro("CveCuentaMaestra", IntCveCuentaMaestra.ToString(), "int"));
            arrParam.Add(pb.addparametro("FechaAlta", StrFechaAlta, "string"));
            arrParam.Add(pb.addparametro("CveUser", IntCveUser.ToString(), "int"));
            arrParam.Add(pb.addparametro("Saldo", DcSaldo.ToString(), "decimal"));
            arrParam.Add(pb.addparametro("FechaUltimoMovimiento", StrFechaUltimoMovimiento, "string"));
            arrParam.Add(pb.addparametro("CveUserUltimoMovimiento", IntCveUserUltimoMovimiento.ToString(), "int"));
            arrParam.Add(pb.addparametro("ImporteUltimoMovimiento", DcImporteUltimoMovimiento.ToString(), "decimal"));
            arrParam.Add(pb.addparametro("CveEstatus", IntCveEstatus.ToString(), "int"));
            arrParam.Add(pb.addparametro("InicialCheque", IntInicialCheque.ToString(), "int"));

            _dtCuenta = pb.SP_Busca_Reader(arrParam, "SP_AgregarCuenta");

            foreach (DataRow rw in _dtCuenta.Rows)
            {
                Resultado = rw["Resultado"].ToString();
            }

            if (pb.IsNumeric(Resultado))
            {
                IntCveCuenta = int.Parse(Resultado);
                Result = true;
            }
           
            return Result;
        }

    }
}
