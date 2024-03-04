using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasMonar.Desktop.Clases
{
    class Clientes : PageBase
    {

        private int cveCliente;
        Clases.ParametroCliente []paramCli;

      

        public int CveCliente
        {
            get { return cveCliente; }
            set { cveCliente = value; }
        }

        private int cveCredito;

        public int CveCredito
        {
            get { return cveCredito; }
            set { cveCredito = value; }
        }
        private string busqueda;

        public string Busqueda
        {
            get { return busqueda; }
            set { busqueda = value; }
        }

        private int intOption;

        public int Option
        {
            get { return intOption; }
            set { intOption = value; }
        }
        private string strAlmacen;

        public string Almacen
        {
            get { return strAlmacen; }
            set { strAlmacen = value; }
        }

        public Clientes(int _cvecliente)
        {
            CveCliente = _cvecliente;
        }
        public Clientes(string _busqueda)
        {
            Busqueda = _busqueda;
        }
        public Clientes(string _busqueda, int _option)
        {
            Busqueda = _busqueda;
            Option = _option;
        }
        public Clientes(string _busqueda, int _option, string _CveAlmacen)
        {
            Busqueda = _busqueda;
            Option = _option;
            Almacen = _CveAlmacen;
        }
        public Clientes(string _CveSocia, string _CveUser)
        {
            CveCveSocia = _CveSocia; CveUser = _CveUser;
        }
        public Clientes(int _CveCredito, double _PInteres)
        {
            CveCredito = _CveCredito; PInteres = _PInteres;
        }
        public Clientes()
        {

        }
        private double pInteres;

        public double PInteres
        {
            get { return pInteres; }
            set { pInteres = value; }
        }

        private string cveCveSocia;

        public string CveCveSocia
        {
            get { return cveCveSocia; }
            set { cveCveSocia = value; }
        }
        private string cveUser;

        public string CveUser
        {
            get { return cveUser; }
            set { cveUser = value; }
        }

        public bool LeerClienteA()
        {


            return LeerTablaClienteA("BusquedaClienteA");

        }
        public bool LeerAval()
        {
            return LeerTablaClienteA("BusquedaAvalA");
        }
        public bool LeerAvalB()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);

            return LeerTablaClientePametro("BusquedaAvalB", paramCli);
        }
        public bool LeerClienteB()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);

            return LeerTablaClientePametro("BusquedaClienteB", paramCli);
        }

        public bool LeerAlmacen()
        {


            return LeerTablaClienteA("BusquedaAlmacen");

        }

        public bool LeerProductoA()
        {
            paramCli = new ParametroCliente[3];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);
            paramCli[1] = new ParametroCliente("_option", Option.ToString());
            paramCli[2] = new ParametroCliente("_CveAlmacen", Almacen);
            return LeerTablaClientePametro("BusquedaProductoA", paramCli);
        }
        public bool LeerClienteC()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_CveCredito", Busqueda);

            return LeerTablaClientePametro("BusquedaClienteC", paramCli);
        }
        public bool LeerAvalC()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);

            return LeerTablaClientePametro("BusquedaClienteC", paramCli);
        }
        public bool LeerAvalD()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);

            return LeerTablaClientePametro("BusquedaClienteC", paramCli);
        }
        public bool ClientesCreditos()
        {
            paramCli = new ParametroCliente[2];
            paramCli[0] = new ParametroCliente("_CveSocia", CveCveSocia.ToString());
            paramCli[1] = new ParametroCliente("_CveUser", CveUser.ToString());
            return LeerTablaClientePametro("CreditosClientes2", paramCli);
        }
        public bool LeerAbonosCreditos()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_CveCredito", Busqueda);

            return LeerTablaClientePametro("ClienteAbonosCreditos", paramCli);
        }
        public bool LeerPagosCreditos()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_CveCredito", Busqueda);

            return LeerTablaClientePametro("ProcPagosCredito", paramCli);
        }
        public bool LeerPagosVencidos()
        {
            paramCli = new ParametroCliente[2];
            paramCli[0] = new ParametroCliente("_CveCredito", CveCredito.ToString());
            paramCli[1] = new ParametroCliente("_PInteres",PInteres.ToString());

            return LeerTablaClientePametro("Proc_Vencidos", paramCli);
        }
        public bool LeerAbonosCreditosGarantia()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_CveCredito", Busqueda);

            return LeerTablaClientePametro("procAbonosGarantia", paramCli);
        }
        public bool LeerPagosConMorosidad()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_CveCredito", Busqueda);

            return LeerTablaClientePametro("ProcPagosConMorosidad", paramCli);
        }
    }
}
