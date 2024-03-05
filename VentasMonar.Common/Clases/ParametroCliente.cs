using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasMonar.Common.Clases
{
    public class ParametroCliente
    {
        private string cve;

        public string Cve
        {
            get { return cve; }
            set { cve = value; }
        }
        private string cveValor;

        public string CveValor
        {
            get { return cveValor; }
            set { cveValor = value; }
        }

        public ParametroCliente(string Ccve, string Cva)
        {
            Cve = Ccve; CveValor = Cva;
        }
    }
}
