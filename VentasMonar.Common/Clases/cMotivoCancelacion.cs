using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cMotivoCancelacion
    {
        public int CveMotivo { get; set; }
        public int CveFactura { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }

        public string UIDD { get; set; }

    }
}
