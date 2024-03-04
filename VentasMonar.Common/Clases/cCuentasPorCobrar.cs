using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Desktop.Clases
{
    public class cCuentasPorCobrar
    {
        Clases.cPageBase pb = new cPageBase();

        private int intCveCliente;
        private int intCveCuenta;
        private int intCveMovimiento;
        private string strObservacionCancelacion;
        private string strFechaCancelacion;
        private int intCveUser;
        private int intCveDocumento;
        private int intCveDocumentoParent;

        public int IntCveCliente { get => intCveCliente; set => intCveCliente = value; }
        public int IntCveCuenta { get => intCveCuenta; set => intCveCuenta = value; }
        public int IntCveMovimiento { get => intCveMovimiento; set => intCveMovimiento = value; }
        public string StrObservacionCancelacion { get => strObservacionCancelacion; set => strObservacionCancelacion = value; }
        public string StrFechaCancelacion { get => strFechaCancelacion; set => strFechaCancelacion = value; }
        public int IntCveUser { get => intCveUser; set => intCveUser = value; }
       
        public int IntCveDocumentoParent { get => intCveDocumentoParent; set => intCveDocumentoParent = value; }
        public int IntCveDocumento { get => intCveDocumento; set => intCveDocumento = value; }

        ArrayList arrParam = new ArrayList();
        public decimal SaldoActualPorCuenta()
        {
            decimal _saldoActual = 0m;
            
            DataTable _dtSaldo = new DataTable();

            arrParam.Clear();
            arrParam.Add(pb.addparametro("CveCuenta", IntCveCuenta.ToString(), "int"));

            _dtSaldo = pb.SP_Busca_Reader(arrParam, "SP_SaldoCuentasPorCobrar");

            foreach (DataRow item in _dtSaldo.Rows)
            {
                _saldoActual = decimal.Parse(item["SaldoActual"].ToString());
            }
            _dtSaldo.Dispose();


            return _saldoActual;
        }
        public DataTable ActualizarSaldosCuentas()
        {
            
            DataTable _dtSaldo = new DataTable();
            arrParam.Clear();
            arrParam.Add(pb.addparametro("CveCliente", IntCveCliente.ToString(), "int"));

            _dtSaldo = pb.SP_Busca_Reader(arrParam, "SP_ActualizarCuentasPorCobrarCliente");


            return _dtSaldo;
        }
        public DataTable EliminarAbono()
        {


            DataTable _dtElimando = new DataTable();

            arrParam.Clear();
            arrParam.Add(pb.addparametro("CveMovimiento", IntCveMovimiento.ToString(), "int"));
            arrParam.Add(pb.addparametro("ObservacionCancelacion", StrObservacionCancelacion, "string"));
            arrParam.Add(pb.addparametro("FechaCancelacion", StrFechaCancelacion, "string"));
            arrParam.Add(pb.addparametro("CveUserCancelacion", IntCveUser.ToString(), "int"));

            _dtElimando = pb.SP_Busca_Reader(arrParam, "SP_CancelarAbonoACuenta");
           


            /*
             * 	@CveMovimiento int,
	@ObservacionCancelacion varchar(200),
	@FechaCancelacion varchar(50),
	@CveUserCancelacion int
             * */
             
            return _dtElimando;
        }

        public decimal SaldoActualPorCuentaNC()
        {
            decimal _SaldoActual = 0m;

            DataTable _dtSaldo = new DataTable();

            arrParam.Clear();
            arrParam.Add(pb.addparametro("CveDocumento", IntCveDocumento.ToString(), "int"));

            _dtSaldo = pb.SP_Busca_Reader(arrParam, "SP_CheckSaldoCuentaAbonoNC");

            foreach (DataRow item in _dtSaldo.Rows)
            {
                _SaldoActual = decimal.Parse(item["SaldoActual"].ToString());
                IntCveCuenta = int.Parse(item["CveCuenta"].ToString());
            }
            _dtSaldo.Dispose();



            return _SaldoActual;
        }
    }
}
