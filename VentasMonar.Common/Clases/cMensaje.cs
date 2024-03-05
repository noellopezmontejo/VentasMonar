using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
	public class cMensaje
	{
		public cMensaje() { }

		public cMensaje(int id) { }
		public int id { get; set; }
		public string name { get; set; }
		public string desc { get; set; }
		public string type { get; set; }	
		public string description { get; set; }
        public string resultado { get; set; }

    }
}
