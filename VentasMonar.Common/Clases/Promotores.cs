using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasMonar.Common.Clases
{
    class Promotores: cPageBase
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

        public Promotores(int _cvecliente)
        {
            CveCliente = _cvecliente;
        }
        public Promotores(string _busqueda)
        {
            Busqueda = _busqueda;
        }
        public Promotores(string _CveSocia, string _CveUser)
        {
            CveCveSocia = _CveSocia; CveUser = _CveUser;
        }
        public Promotores(int _CveCredito, double _PInteres)
        {
            CveCredito = _CveCredito; PInteres = _PInteres;
        }
        public Promotores()
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


            return LeerTablaClienteA("BusquedaPromotorA");

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

            return LeerTablaClientePametro("BusquedaPromotorB", paramCli);
        }
        public bool LeerClienteC()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_CveCredito", Busqueda);

            return LeerTablaClientePametro("BusquedaPromotorC", paramCli);
        }
        public bool LeerAvalC()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);

            return LeerTablaClientePametro("BusquedaPromotorC", paramCli);
        }
        public bool LeerAvalD()
        {
            paramCli = new ParametroCliente[1];
            paramCli[0] = new ParametroCliente("_busqueda", Busqueda);

            return LeerTablaClientePametro("BusquedaPromotorC", paramCli);
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
