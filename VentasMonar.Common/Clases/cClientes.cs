using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasMonar.Desktop.Clases
{
   
    class cClientes
    {

        Clases.cPageBase pb = new cPageBase();

        private int intCveCliente;
        private int intCveReceptor;
        private string strNombre;
        private string strRFC;
        private string strCalle;
        private string strNoExterior;
        private string strNoInterior;
        private string strColonia;
        private string strCiudad;
        private string strEstado;
        private int intCveCiudad;
        private int intCveEstado;
        private string strPais;
        private string strCP;
        private string strTelefono;
        private string strTelefonoMovil;
        private string strWeb;
        private int intDiasCredito;
        private decimal dLimiteCredito;
        private decimal dSaldoCredito;
        private int intCveVendedor;
        private decimal dDescuento;
        private int intCveListaPrecio;
        private string strObservaciones;
        private string strContacto;
        private int intCveUsoCfdi;
        private int intActualizar;

        public int IntCveCliente { get => intCveCliente; set => intCveCliente = value; }
        public string StrNombre { get => strNombre; set => strNombre = value; }
        public string StrRFC { get => strRFC; set => strRFC = value; }
        public string StrCalle { get => strCalle; set => strCalle = value; }
        public string StrNoExterior { get => strNoExterior; set => strNoExterior = value; }
        public string StrNoInterior { get => strNoInterior; set => strNoInterior = value; }
        public string StrColonia { get => strColonia; set => strColonia = value; }
        public string StrCiudad { get => strCiudad; set => strCiudad = value; }
        public string StrEstado { get => strEstado; set => strEstado = value; }
        public string StrPais { get => strPais; set => strPais = value; }
        public string StrCP { get => strCP; set => strCP = value; }
        public string StrTelefono { get => strTelefono; set => strTelefono = value; }
        public string StrTelefonoMovil { get => strTelefonoMovil; set => strTelefonoMovil = value; }
        public string StrWeb { get => strWeb; set => strWeb = value; }
        public int IntDiasCredito { get => intDiasCredito; set => intDiasCredito = value; }
        public decimal DLimiteCredito { get => dLimiteCredito; set => dLimiteCredito = value; }
        public decimal DSaldoCredito { get => dSaldoCredito; set => dSaldoCredito = value; }
        public int IntCveVendedor { get => intCveVendedor; set => intCveVendedor = value; }
        public decimal DDescuento { get => dDescuento; set => dDescuento = value; }
        public int IntCveListaPrecio { get => intCveListaPrecio; set => intCveListaPrecio = value; }
        public string StrObservaciones { get => strObservaciones; set => strObservaciones = value; }
        public string StrContacto { get => strContacto; set => strContacto = value; }
        public int IntCveUsoCfdi { get => intCveUsoCfdi; set => intCveUsoCfdi = value; }
        public int IntCveCiudad { get => intCveCiudad; set => intCveCiudad = value; }
        public int IntCveEstado { get => intCveEstado; set => intCveEstado = value; }
        public int IntCveReceptor { get => intCveReceptor; set => intCveReceptor = value; }
        public int IntActualizar { get => intActualizar; set => intActualizar = value; }

        private int SaveCliente()
        {

            int CveCliente=0;

            string Resultado = "";
            ArrayList ListaParametro = new ArrayList();

            ListaParametro.Add(pb.addparametro("CveCliente", IntCveCliente.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("Nombre", StrNombre, "string"));
            ListaParametro.Add(pb.addparametro("RFC", StrRFC, "string"));
            ListaParametro.Add(pb.addparametro("Calle", StrCalle, "string"));
            ListaParametro.Add(pb.addparametro("NoExterior", StrNoExterior, "string"));
            ListaParametro.Add(pb.addparametro("NoInterior", StrNoInterior, "string"));
            ListaParametro.Add(pb.addparametro("Colonia", StrColonia, "string"));
            ListaParametro.Add(pb.addparametro("Ciudad", StrCiudad, "string"));
            ListaParametro.Add(pb.addparametro("Estado", StrEstado, "string"));
            ListaParametro.Add(pb.addparametro("Pais", StrPais, "string"));
            ListaParametro.Add(pb.addparametro("CP", StrCP, "string"));
            ListaParametro.Add(pb.addparametro("Telefono", StrTelefono, "string"));
            ListaParametro.Add(pb.addparametro("TelefonoMovil", StrTelefonoMovil, "string"));
            ListaParametro.Add(pb.addparametro("Web", StrWeb, "string"));
            ListaParametro.Add(pb.addparametro("DiasCredito", IntDiasCredito.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("DLimiteCredito", DLimiteCredito.ToString(), "decimal"));
            ListaParametro.Add(pb.addparametro("DSaldoCredito", DSaldoCredito.ToString(), "decimal"));
            ListaParametro.Add(pb.addparametro("CveVendedor", IntCveVendedor.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("DDescuento",DDescuento.ToString(), "decimal"));
            ListaParametro.Add(pb.addparametro("CveListaPrecio", IntCveListaPrecio.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("Observaciones", StrObservaciones, "string"));
            ListaParametro.Add(pb.addparametro("Contacto", StrContacto, "string"));
            ListaParametro.Add(pb.addparametro("CveUsoCfdi", IntCveUsoCfdi.ToString(), "int"));

            ListaParametro.Add(pb.addparametro("CveCiudad", IntCveCiudad.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("CveEstado", IntCveEstado.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("CveReceptor", IntCveReceptor.ToString(), "int"));
            ListaParametro.Add(pb.addparametro("Actualizar", IntActualizar.ToString(), "int"));

            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametro, "SP_SaveClientes");

            foreach (DataRow rw in _dt.Rows)
            {
                Resultado = rw["Resultado"].ToString();
            }

            if (pb.IsNumeric(Resultado))
                CveCliente = int.Parse(Resultado);

            return CveCliente;
            
        }

    }
}
