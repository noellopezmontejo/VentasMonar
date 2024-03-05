using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Common.Clases
{
    public class cMensajes
    {
        private int intCveCuenta;
        private string strNombreCuenta;
        private decimal dcSaldoActual;
        private string strMensaje;

        public int IntCveCuenta { get => intCveCuenta; set => intCveCuenta = value; }
        public string StrNombreCuenta { get => strNombreCuenta; set => strNombreCuenta = value; }
        public decimal DcSaldoActual { get => dcSaldoActual; set => dcSaldoActual = value; }
        public string StrMensaje { get => strMensaje; set => strMensaje = value; }

        public class CuentaBancaria : cMensajes
        {
            
            public void Save()
            {
                MessageBox.Show("se han guardado los datos correctamente", "Validación de Datos");
            }

            public void NotSave()
            {
                MessageBox.Show("Se ha generado un error: " + StrMensaje , "Validación de Datos");
            }

            private void Varios()
            {

            }
        }
        
    }
}
