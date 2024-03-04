using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Net;
using System.Net.Mail;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using RKLib.ExportData;
using Profact.TimbraCFDI;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Sockets;
using System.Web;

namespace VentasMonar.Desktop.Clases
{
    public class cPageBase
    {
        private bool disposed = false;
        private string instanceName;

        
        

        public class NivelAcceso
        {
            private NivelAcceso() { }
            public static int nivelacceso = 0;
        }
        public class MesCargado
        {
            private MesCargado() { }
            public static int mescargado = 0;
        }
        public class AnioCargado
        {
            private AnioCargado() { }
            public static int aniocargado = 0;
        }
        public class UserName
        {
            private UserName() { }
            public static string user_name = "rcalderon";
        }
        
        public class CveUser
        {
            private CveUser()
            {
            }
            public static int Cve_User = 0 ;
        }
        public bool ListHadBeenAdded = false;

        // Nuevo Procedimiento para conexion de usuarios


        public static Encriptar Enn = new Encriptar();
        public class IdUserName
        {
            private IdUserName() { }
            public static cIniArray mINI = new cIniArray();
            public static string Archivo = Application.StartupPath + @"\Conexion.ini";
            public static string UserName = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Usuario", ""));
            public static string IdUser_Name = UserName;

        }
        public class IdPassWord
        {
            private IdPassWord() { }
            public static cIniArray mINI = new cIniArray();

            public static string Archivo = Application.StartupPath + @"\Conexion.ini";
            public static string Password = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Password", ""));
            public static string Id_PassWord = Password;
            //public static string Id_PassWord = "dsi"; 
        }
        public class ServerName
        {
            private ServerName() { }
            public static cIniArray mINI = new cIniArray();
            public static string Archivo = Application.StartupPath + @"\Conexion.ini";
            public static string ServerName1 = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "ServerName", ""));
            public static string Id_ServerName = ServerName1;
            //public static string Id_PassWord = "dsi"; 
        }
        public class BaseDatos
        {
            private BaseDatos() { }
            public static cIniArray mINI = new cIniArray();
            public static string Archivo = Application.StartupPath + @"\Conexion.ini";
            public static string BaseDatos1 = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "BaseDatos", ""));
            public static string Id_BaseDatos = BaseDatos1;
            //public static string Id_PassWord = "dsi"; 
        }
        public class PasswordPV
        {
            private PasswordPV() { }
            public static cIniArray mINI = new cIniArray();
            public static string Archivo = Application.StartupPath + @"\Conexion.ini";
            public static string PasswordPV1 = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "PasswordPV", ""));
            public static string Id_PasswordPV1 = PasswordPV1;
            //public static string Id_PassWord = "dsi"; 
        }
        public class CredencialPV
        {
            private CredencialPV() { }
            public static cIniArray mINI = new cIniArray();
            public static string Archivo = Application.StartupPath + @"\Conexion.ini";
            public static string CredencialPV1 = Enn.DesEncriptarCadena(mINI.IniGet(Archivo, "Configuracion", "Credencial", ""));
            public static string Id_CredencialPV1 = CredencialPV1;
            //public static string Id_PassWord = "dsi"; 
        }
        //public string strconexion = "Database=" + BaseDatos.Id_BaseDatos + "; Data Source=" + ServerName.Id_ServerName + ";User Id=" + IdUserName.IdUser_Name + ";Password=" + IdPassWord.Password;
        //public String strconexion = "Database=Devoluciones; Data Source=conta4;User Id=" + IdUserName.IdUser_Name + ";Password=" + IdPassWord.Id_PassWord;
        //public String strconexion = "Database=DevolucionesResp; Data Source=localhost;User Id=root;Password=fianzas";
        //public String strconexion = "Database=Devoluciones; Data Source=localhost;User Id=" + IdUserName.IdUser_Name + ";Password=" + IdPassWord.Id_PassWord;
        public String NombreIni = "Conexion.ini";
        //public string strconexionLocalGlobal ="Database=" + BaseDatos.Id_BaseDatos + "; Data Source=" + ServerName.Id_ServerName + ";User Id=" + IdUserName.IdUser_Name + ";Password=" + IdPassWord.Password;//Sistema_de_Inventarios.Properties.Settings.Default.Db_LocalNetMonarConnectionString;
        //public string strconexionGlobalMonar = "Database=sae4; Data Source=" + ServerName.Id_ServerName + ";User Id=" + IdUserName.IdUser_Name + ";Password=" + IdPassWord.Password;//Sistema_de_Inventarios.Properties.Settings.Default.Db_LocalNetMonarConnectionString;


        public static string Strconexion = ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString;
        public static string StrconexionLocalGlobal = ConfigurationManager.ConnectionStrings["SqlMonar"].ConnectionString;
        public static string StrconexionGlobalMonar = ConfigurationManager.ConnectionStrings["SqlMonar_Anterior"].ConnectionString;


        //

        //public string strconexionLocalGlobal = Sistema_de_Inventarios.Properties.Settings.Default.Db_LocalNetMonarConnectionString;
        //public string strconexionLocalGlobal = strcone//Sistema_de_Inventarios.Properties.Settings.Default.Db_LocalNetMonarConnectionString;

        //public string strconexion = "Database=Inventarios; Data Source=localhost;User Id=" + IdUserName.IdUser_Name + " ;Password=" + IdPassWord.Id_PassWord;
        //public string strconexion = "Database=Inventarios; Data Source=192.168.2.11;User Id=" + IdUserName.IdUser_Name + " ;Password=" + IdPassWord.Id_PassWord;
        //public string strconexion = "Database=Inventarios; Data Source=172.20.7.53;User Id=" + IdUserName.IdUser_Name + " ;Password=" + IdPassWord.Id_PassWord;
        //public string strconexion = "Database=Inventarios; Data Source=servidor-asscom;User Id=" + IdUserName.IdUser_Name + " ;Password=" + IdPassWord.Id_PassWord;

        public const int OrdenAbierta = 1;
        public const int OrdenCerrada = 2;
        public const int Credito = 2;
        public const int Contado = 1;
        public const string NotaDeCargo = "1";
        public const string CveIvaRef = "1"; // Dato Iva para Facturacion Electronica...
        public class UsuarioAlmacen
        {
            private int intCveUsuario;
            private int intCveAlmacen;
            private string strDescripcion;

            public int CveUsuario
            {
                get
                {
                    return intCveUsuario;
                }
                set
                {
                    intCveUsuario = value;
                }
            }

            public int CveAlmacen
            {
                get
                {
                    return intCveAlmacen;
                }
                set
                {
                    intCveAlmacen = value;
                }
            }
            public string Descripcion
            {
                get
                {
                    return strDescripcion;
                }
                set
                {
                    strDescripcion = value;
                }
            }
            
        }

        public class TipoDocumento
        {
            private int cveFactura;

            public int CveFactura
            {
                get { return cveFactura; }
                set { cveFactura = value; }
            }
            private string nombreFactura;

            public string NombreFactura
            {
                get { return nombreFactura; }
                set { nombreFactura = value; }
            }
            private string noSerie;

            public string NoSerie
            {
                get { return noSerie; }
                set { noSerie = value; }
            }
            private string lugarExpedicion;

            public string LugarExpedicion
            {
                get { return lugarExpedicion; }
                set { lugarExpedicion = value; }
            }
            private int folioInt;

            public int FolioInt
            {
                get { return folioInt; }
                set { folioInt = value; }
            }

            private string rpt;
            public string Rpt
            {
                get
                {
                    return rpt;
                }
                set
                {
                    rpt = value;
                }
            }
        }


        public enum FormularioOrigen
        {
            FormOrdenDeServicioSeguimiento = 1,
            FormOrdenesDeServicio = 2
        }

        public class AddValue
        {
            private string m_Display;
            private long m_Value;
            public AddValue(string Display, long Value)
            {
                m_Display = Display;
                m_Value = Value;
                    }
            public string Display
            {
                get { return m_Display; }
            }
            public long Value
            {
                get { return m_Value; }
            }
        }
        public class FormasPago
        {
            private int intCveFormaPago;
            private string strFormaPago;
            private string strNoDocumento;
            private double dblMonedaNacional;
            private double dblTipoCambio;
            private string strNoTarjeta;
            private string strFechaVencimiento;
            private string strFechaEmision;
            private string strCodigoSeguridad;
            private double dblTotalPagado;
            private double dblImportePagado;
            private double dblTotalCambio;
            private int intCveBanco;
            private int intCveCliente;

            public int CveFormaPago
            {
                get
                {
                    return intCveFormaPago;
                }
                set
                {
                    intCveFormaPago = value;
                }
            }
            public string FormaPago
            {
                get
                {
                    return strFormaPago;
                }
                set
                {
                    strFormaPago = value;
                }
            }
            public string NoDocumento
            {
                get
                {
                    return strNoDocumento;
                }
                set
                {
                    strNoDocumento = value;
                }
            }
            public double MonedaNacional
            {
                get
                {
                    return dblMonedaNacional;
                }
                set
                {
                    dblMonedaNacional = value;
                }
            }
            public double TipoCambio
            {
                get
                {
                    return dblTipoCambio;
                }
                set
                {
                    dblTipoCambio = value;
                }
            }
            public string NoTarjeta
            {
                get
                {
                    return strNoTarjeta;
                }
                set
                {
                    strNoTarjeta = value;
                }
            }
            public string FechaVencimiento
            {
                get
                {
                    return strFechaVencimiento;
                }
                set
                {
                    strFechaVencimiento = value;
                }
            }
            public string FechaEmision
            {
                get
                {
                    return strFechaEmision;
                }
                set
                {
                    strFechaEmision = value;
                }
            }
            public string CodigoSeguridad
            {
                get
                {
                    return strCodigoSeguridad;
                }
                set
                {
                    strCodigoSeguridad = value;
                }
            }

            public double TotalPagado
            {
                get
                {
                    return dblTotalPagado;
                }
                set
                {
                    dblTotalPagado = value;
                }
            }
            public double ImportePagado
            {
                get
                {
                    return dblImportePagado;
                }
                set
                {
                    dblImportePagado = value;
                }
            }
            public double TotalCambio
            {
                get
                {
                    return dblTotalCambio;
                }
                set
                {
                    dblTotalCambio = value;
                }
            }
            public int CveBanco
            {
                get
                {
                    return intCveBanco;
                }
                set
                {
                    intCveBanco = value;
                }
            }
            public int CveClienteCredito
            {
                get
                {
                    return intCveCliente;
                }
                set
                {
                    intCveCliente = value;
                }
            }
        }
        public class AddValueString
        {
            private string m_Display;
            private string m_Value;
            public AddValueString(string Display, string Value)
            {
                m_Display = Display;
                m_Value = Value;
            }
            public string Display
            {
                get { return m_Display; }
            }
            public string Value
            {
                get { return m_Value; }
            }
        }

        public class AddValueSS
        {
            private string m_Display;
            private string m_Value;
            public AddValueSS(string Display, string Value)
            {
                m_Display = Display;
                m_Value = Value;
            }
            public string Display
            {
                get { return m_Display; }
            }
            public string Value
            {
                get { return m_Value; }
            }
        }
        public class Tratamiento
        {
            private int intCveCliente;
            private int intCvePaqueteCliente;
            private string strDescripcion;

            public int CveCliente
            {
                get
                {
                    return intCveCliente;
                }
                set
                {
                    intCveCliente = value;
                }
            }
            public int CvePaqueteCliente
            {
                get
                {
                    return intCvePaqueteCliente;
                }
                set
                {
                    intCvePaqueteCliente = value;
                }
            }
            public string Descripcion
            {
                get
                {
                    return strDescripcion;
                }
                set
                {
                    strDescripcion = value;
                }
            }


        }
        public class SesionTratar
        {
            private int intCveSesion;
            private int intCveTratamiento;
            private string strDescripcion;
            private double dblPrecioBase;
            private double intPorcentaje1;
            private double intPorcentaje2;
            private double dblComision;
            public int CveSesion
            {
                get
                {
                    return intCveSesion;
                }
                set
                {
                    intCveSesion = value;
                }
            }
            public int CveTratamiento
            {
                get
                {
                    return intCveTratamiento;
                }
                set
                {
                    intCveTratamiento = value;
                }
            }
            public string Descripcion
            {
                get
                {
                    return strDescripcion;
                }
                set
                {
                    strDescripcion = value;
                }
            }
            public double PrecioBase
            {
                get
                {
                    return dblPrecioBase;
                }
                set
                {
                    dblPrecioBase = value;
                }
            }
            public double Porcentaje1
            {
                get
                {
                    return intPorcentaje1;
                }
                set
                {
                    intPorcentaje1 = value;
                }
            }
            public double Porcentaje2
            {
                get
                {
                    return intPorcentaje2;
                }
                set
                {
                    intPorcentaje2 = value;
                }
            }
            public double Comision
            {
                get
                {
                    return dblComision;
                }
                set
                {
                    dblComision = value;
                }
            }
        }

        public class ZonaTratar
        {
            private int intCveCliente;
            private int intCveZona;
            private int intCveTratamiento;
            private string strDescripcion;
            private double dblPrecioBase;
            private double intPorcentaje1;
            private double intPorcentaje2;
            private int intCveTipoPrecio;
            private double dblPrecio1;
            private double dblPrecio2;
            private double dblPrecio3;
            private double dblDescuento;
            private double dblMedicion;
            private int intSesion;
            private int intTipoPago;
            private string strAbreviatura;
            private double dblComision;
            private double dblComisionI;
            private double dblComisionG;
            private double dblComisionTe;
            public int CveCliente
            {
                get { return intCveCliente; }
                set { intCveCliente = value; }
            }
            public int CveZona
            {
                get { return intCveZona; }
                set { intCveZona = value; }
            }
            public int CveTratamiento
            {
                get { return intCveTratamiento; }
                set { intCveTratamiento = value; }
            }
            public string Descripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }
            public double PrecioBase
            {
                get
                {
                    return dblPrecioBase;
                }
                set
                {
                    dblPrecioBase = value;
                }
            }
            public double Porcentaje1
            {
                get
                {
                    return intPorcentaje1;
                }
                set
                {
                    intPorcentaje1 = value;
                }
            }
            public double Porcentaje2
            {
                get
                {
                    return intPorcentaje2;
                }
                set
                {
                    intPorcentaje2 = value;
                }
            }
            public int CveTipoPrecio
            {
                get
                {
                    return intCveTipoPrecio;
                }
                set
                {
                    intCveTipoPrecio = value;
                }
            }
            public double Precio1
            {
                get
                {
                    return dblPrecio1;
                }
                set
                {
                    dblPrecio1 = value;
                }
            }
            public double Precio2
            {
                get
                {
                    return dblPrecio2;
                }
                set
                {
                    dblPrecio2 = value;
                }
            }
            public double Precio3
            {
                get
                {
                    return dblPrecio3;
                }
                set
                {
                    dblPrecio3 = value;
                }
            }
            public double Descuento
            {
                get
                {
                    return dblDescuento;
                }
                set
                {
                    dblDescuento = value;
                }
            }
            public double Medicion
            {
                get
                {
                    return dblMedicion;
                }
                set
                {
                    dblMedicion = value;
                }
            }
            public int NumeroSesion
            {
                get
                {
                    return intSesion;
                }
                set
                {
                    intSesion = value;
                }
            }
            public int TipoPago
            {
                get
                {
                    return intTipoPago;
                }
                set
                {
                    intTipoPago = value;
                }
            }
            public string Abreviatura
            {
                get
                {
                    return strAbreviatura;
                }
                set
                {
                    strAbreviatura = value;
                }
            }
            public double Comision
            {
                get
                {
                    return dblComision;
                }
                set
                {
                    dblComision = value;
                }
            }
            public double ComisionI
            {
                get
                {
                    return dblComisionI;
                }
                set
                {
                    dblComisionI=value;
                }
            }
            public double ComisionG
            {
                get
                {
                    return dblComisionG;
                }
                set
                {
                    dblComisionG = value;
                }
            }
            public double ComisionTerapia
            {
                get
                {
                    return dblComisionTe;
                }
                set
                {
                    dblComisionTe = value;
                }
            }
        }
        public class Notificaciones
        {
            private int intCvePaqueteCliente;    
            private string strNotificacion;
            private double dlbSaldo;
            private int intCveTipoPago;
            private int intCuentaSesion;
            private int intCveTratamiento;
            private int intCveSesion;
            public string Notificacion
            {
                get
                {
                    return strNotificacion;
                }
                set
                {
                    strNotificacion = value;
                }
            }
            public int CvePaqueteCliente
            {
                get
                {
                    return intCvePaqueteCliente;
                }
                set
                {
                    intCvePaqueteCliente = value;
                }
            }
            public double Saldo
            {
                get
                {
                    return dlbSaldo;
                }
                set
                {
                    dlbSaldo = value;
                }
            }
            public int CveTipoPago
            {
                get
                {
                    return intCveTipoPago;
                }
                set
                {
                    intCveTipoPago = value;
                }
            }
            public int CuentSesion
            {
                get
                {
                    return intCuentaSesion;
                }
                set
                {
                    intCuentaSesion = value;
                }
            }
            public int CveTratamiento
            {
                get
                {
                    return intCveTratamiento;
                }
                set
                {
                    intCveTratamiento = value;
                }
            }
            public int CveSesion
            {
                get
                {
                    return intCveSesion;
                }
                set
                {
                    intCveSesion = value;
                }
            }
        }
        public class Movimientos
        {
            private int intCveMovmiento;
            public int CveMovimiento
            {
                get
                {
                    return intCveMovmiento;
                }
                set
                {
                    intCveMovmiento = value;
                }
            }

        }
        public class ClassVentas
        {
            private int intCveVenta;
            public int CveVenta
            {
                get
                {
                    return intCveVenta;
                }
                set
                {
                    intCveVenta = value;
                }
            }
        }
        public class PagosPendientes
        {
            private int intCveCuenta;
            private double dblPago;
            private double dblImporte;
            private int intCvePaqueteCliente;
            public int CveCuenta
            {
                get
                {
                    return intCveCuenta;
                }
                set
                {
                    intCveCuenta = value;
                }
            }
            public double Pago
            {
                get
                {
                    return dblPago;
                }
                set
                {
                    dblPago = value;
                }
            }
            public double Importe
            {
                get
                {
                    return dblImporte;
                }
                set
                {
                    dblImporte = value;
                }
            }
            public int CvePaqueteCliente
            {
                get
                {
                    return intCvePaqueteCliente;
                }
                set
                {
                    intCvePaqueteCliente = value;
                }
            }
        
        }

        public class SP_ParametrosTable
        {

            private string strNombreParametro;
            private DataTable strValueParametro;
            private string strTipoValor;

            /// <summary>
            /// 1: El campo es un string
            /// 2: Recibe el Nombre del Parametro
            /// </summary>
            public string StrNombreParametro
            {
                get
                {
                    return strNombreParametro;
                }

                set
                {
                    strNombreParametro = value;
                }
            }

            /// <summary>
            /// Valor del parametro, deber ser string
            /// </summary>
            public DataTable StrValueParametro
            {
                get
                {
                    return strValueParametro;
                }

                set
                {
                    strValueParametro = value;
                }
            }

            /// <summary>
            /// Identifica el tipo de dato que recibe ejemplo, string, int, etc.
            /// </summary>
            public string StrTipoValor
            {
                get
                {
                    return strTipoValor;
                }

                set
                {
                    strTipoValor = value;
                }
            }
        }
        public class SP_Parametros
        {
            
            private string strNombreParametro;
            private string strValueParametro;
            private string strTipoValor;
            
            /// <summary>
            /// 1: El campo es un string
            /// 2: Recibe el Nombre del Parametro
            /// </summary>
            public string StrNombreParametro
            {
                get
                {
                    return strNombreParametro;
                }

                set
                {
                    strNombreParametro = value;
                }
            }

            /// <summary>
            /// Valor del parametro, deber ser string
            /// </summary>
            public string StrValueParametro
            {
                get
                {
                    return strValueParametro;
                }

                set
                {
                    strValueParametro = value;
                }
            }

            /// <summary>
            /// Identifica el tipo de dato que recibe ejemplo, string, int, etc.
            /// </summary>
            public string StrTipoValor
            {
                get
                {
                    return strTipoValor;
                }

                set
                {
                    strTipoValor = value;
                }
            }


            


        }
        public class SP_ParametrosImage
        {

            private string strNombreParametro;
            private Image strValueParametro;
            private string strTipoValor;

            /// <summary>
            /// 1: El campo es un string
            /// 2: Recibe el Nombre del Parametro
            /// </summary>
            public string StrNombreParametro
            {
                get
                {
                    return strNombreParametro;
                }

                set
                {
                    strNombreParametro = value;
                }
            }

            /// <summary>
            /// Valor del parametro, deber ser Image
            /// </summary>
            public Image StrValueParametro
            {
                get
                {
                    return strValueParametro;
                }

                set
                {
                    strValueParametro = value;
                }
            }

            /// <summary>
            /// Identifica el tipo de dato que recibe ejemplo, string, int, etc.
            /// </summary>
            public string StrTipoValor
            {
                get
                {
                    return strTipoValor;
                }

                set
                {
                    strTipoValor = value;
                }
            }





        }


        public class DBDataField
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public DbType DBType { get; set; }
            public SqlDbType SQLSBType { get; set; }
            public int Length { get; set; }
            public int Precision { get; set; }
            public ParameterDirection Direction { get; set; }
            public string ParameterName { get; set; }
        }

        public class DBDataFieldCollection
        {
            public Dictionary<string, DBDataField> Parameters = new Dictionary<string, DBDataField>();

            public void Add(DBDataField Parameter)
            {
                Parameters.Add(Parameter.Name, Parameter);
            }
            public void Add(string ParameterName, object ParameterValue)
            {
                DBDataField dbp = new DBDataField();
                dbp.Name = ParameterName;
                dbp.Value = ParameterValue;
                dbp.ParameterName = ParameterName;
                Parameters.Add(ParameterName, dbp);
            }
        }

        public SP_ParametrosTable addparametroTable(string ParameterName, DataTable Value, string TypeValue)
        {
            SP_ParametrosTable _sp = new SP_ParametrosTable();

            _sp.StrNombreParametro = ParameterName;
            _sp.StrTipoValor = TypeValue;
            _sp.StrValueParametro = Value;

            return _sp;

        }
        public SP_Parametros addparametro(string ParameterName, string Value, string TypeValue)
        {
            SP_Parametros _sp = new SP_Parametros();

            _sp.StrNombreParametro = ParameterName;
            _sp.StrTipoValor = TypeValue;
            _sp.StrValueParametro = Value;

            return _sp;

        }
        public SP_ParametrosImage addparametroImage(string ParameterName, Image Value, string TypeValue)
        {
            SP_ParametrosImage _sp = new SP_ParametrosImage();

            _sp.StrNombreParametro = ParameterName;
            _sp.StrTipoValor = TypeValue;
            _sp.StrValueParametro = Value;

            return _sp;

        }
        public DataTable SP_Busca_Reader(ArrayList ListParametro, string Nombre_SP, int option=0)
        {
            DataTable Table = new DataTable();
            using (SqlConnection cn = new SqlConnection(Strconexion))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(Nombre_SP, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                

                if (option == 0)
                {
                    foreach (SP_Parametros sp in ListParametro)
                    {


                        switch (sp.StrTipoValor)
                        {
                            case "string":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToString(sp.StrValueParametro));
                                break;
                            case "int":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToInt32(sp.StrValueParametro));
                                break;
                            case "double":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDouble(sp.StrValueParametro));
                                break;
                            case "decimal":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDecimal(sp.StrValueParametro));
                                break;

                            case "bool":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToBoolean(sp.StrValueParametro));
                                break;
                            case "date":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDateTime(sp.StrValueParametro));
                                break;
                            



                        }

                    }
                }
                else
                {
                    foreach (SP_Parametros sp in ListParametro)
                    {

                      

                    }
                }



                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    Table.Load(dr);
                }
            }
            return Table;
        }
        public DataTable SP_Busca_Reader(ArrayList ListParametro, string Nombre_SP, SqlConnection connection, SqlTransaction transaction)
        {
            DataTable Table = new DataTable();


            SqlCommand cmd = new SqlCommand(Nombre_SP, connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;



            foreach (SP_Parametros sp in ListParametro)
            {


                switch (sp.StrTipoValor)
                {
                    case "string":
                        cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToString(sp.StrValueParametro));
                        break;
                    case "int":
                        cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToInt32(sp.StrValueParametro));
                        break;
                    case "double":
                        cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDouble(sp.StrValueParametro));
                        break;
                    case "decimal":
                        cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDecimal(sp.StrValueParametro));
                        break;

                    case "bool":
                        cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToBoolean(sp.StrValueParametro));
                        break;
                    case "date":
                        cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDateTime(sp.StrValueParametro));
                        break;




                }

            }

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    Table.Load(dr);
                }
            }

            return Table;
        }

        public DataTable SP_Busca_ReaderMonar(ArrayList ListParametro, string Nombre_SP, int option = 0, ArrayList ListaParametroImage=null)
        {
            DataTable Table = new DataTable();
            using (SqlConnection cn = new SqlConnection(StrconexionGlobalMonar))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(Nombre_SP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;


                if (option == 0)
                {
                    foreach (SP_Parametros sp in ListParametro)
                    {


                        switch (sp.StrTipoValor)
                        {
                            case "string":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToString(sp.StrValueParametro));
                                break;
                            case "int":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToInt32(sp.StrValueParametro));
                                break;
                            case "double":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDouble(sp.StrValueParametro));
                                break;
                            case "decimal":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDecimal(sp.StrValueParametro));
                                break;
                            case "Image":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, sp.StrValueParametro);
                                break;
                        }

                    }
                    if (ListaParametroImage!=null)
                    {
                        foreach (SP_ParametrosImage sp_I in ListaParametroImage)
                        {
                            switch (sp_I.StrTipoValor)
                            {
                                case "Image":
                                    cmd.Parameters.AddWithValue(sp_I.StrNombreParametro, sp_I.StrValueParametro);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (SP_Parametros sp in ListParametro)
                    {



                    }
                }



                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    Table.Load(dr);
                }
            }
            return Table;
        }

        public DataTable SP_Busca_ReaderMonarTable(ArrayList ListParametro, string Nombre_SP, int option = 0, ArrayList ListaParametroImage = null)
        {
            DataTable Table = new DataTable();
            using (SqlConnection cn = new SqlConnection(StrconexionGlobalMonar))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(Nombre_SP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;


                if (option == 0)
                {
                    foreach (SP_ParametrosTable sp in ListParametro)
                    {


                        switch (sp.StrTipoValor)
                        {
                            case "structured":
                                cmd.Parameters.Add(sp.StrNombreParametro, SqlDbType.Structured).Value = sp.StrValueParametro;
                                //cmd.Parameters.AddWithValue(sp.StrNombreParametro,(sp.StrValueParametro));

                                break;
                            case "string":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToString(sp.StrValueParametro));
                                break;
                            case "int":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToInt32(sp.StrValueParametro));
                                break;
                            case "double":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDouble(sp.StrValueParametro));
                                break;
                            case "decimal":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, Convert.ToDecimal(sp.StrValueParametro));
                                break;
                            case "Image":
                                cmd.Parameters.AddWithValue(sp.StrNombreParametro, sp.StrValueParametro);
                                break;
                        }

                    }
                    if (ListaParametroImage != null)
                    {
                        foreach (SP_ParametrosImage sp_I in ListaParametroImage)
                        {
                            switch (sp_I.StrTipoValor)
                            {
                                case "Image":
                                    cmd.Parameters.AddWithValue(sp_I.StrNombreParametro, sp_I.StrValueParametro);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (SP_Parametros sp in ListParametro)
                    {



                    }
                }



                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    Table.Load(dr);
                }
            }
            return Table;
        }


        protected double ChekExistencia(int CveProducto, ArrayList ArrayListProductosVenta)
        {
            double ExistenciaA = double.Parse(GetStrFieldQuery("Cantidad", "Select Cantidad From ProductoColor Where CveProducto=" + CveProducto));

            foreach (ProductoCompra item in ArrayListProductosVenta)
            {
                if (item.CveProducto == CveProducto.ToString())
                {
                    ExistenciaA -= item.Cantidad;
                }
            }

            return ExistenciaA;

        }
        protected bool ValidarCajas(TextBox x, string Mensaje, ErrorProvider Error)
        {
            bool Var = true;
            if (x.Text == "")
            {
                Error.SetError(x, Mensaje);
                Var = false;
            }
            else
                Error.SetError(x, "");
            return Var;
        }
        protected bool radValidarCajas(RadTextBox x, string Mensaje, ErrorProvider Error)
        {
            bool Var = true;
            if (x.Text == "")
            {
                Error.SetError(x, Mensaje);
                Var = false;
            }
            else
                Error.SetError(x, "");
            return Var;
        }

        public int performinsertquery(string query)
        {
            string queryScalar = "; Select SCOPE_IDENTITY();";
            int Clave = 0;
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                SqlCommand cmd = new SqlCommand(query + queryScalar, con);
                con.Open();
                //int inserted = cmd.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand("Select SCOPE_IDENTITY()", con);
                Clave = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
            }
            return Clave;
        }

        protected int performinsertquery(string query, int simple)
        {

            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                return inserted;
                con.Close();
            }
        }
        protected int performinsertquery(string query, int simple, string strconexionLocal)
        {

            using (SqlConnection con = new SqlConnection(strconexionLocal))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                return inserted;
                con.Close();
            }
        }

        protected int performinsertqueryCE(string query, int simple, string strconexionLocal)
        {

            using (SqlConnection con = new SqlConnection(strconexionLocal))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                return inserted;
                con.Close();
            }
        }

        public int performupdatequery(string query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int updated = cmd.ExecuteNonQuery();
                con.Close();

                return updated;
            }
        }
        public int performupdatequery(string query, string strconexionLocal)
        {
            using (SqlConnection con = new SqlConnection(strconexionLocal))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int updated = cmd.ExecuteNonQuery();
                con.Close();

                return updated;
            }
        }

        protected void loadDataGrid(DataGridView DataGrid, string query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Table");
                DataGrid.DataSource = ds.Tables["Table"].DefaultView;
                con.Close();
            }
            colorDataGrid(DataGrid);
        }
        protected void RadloadDataGrid(RadGridView DataGrid, string query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Table");
                DataGrid.DataSource = ds.Tables["Table"].DefaultView;
                con.Close();
            }
            
        }
        protected void ConnectDropDownList(ToolStripComboBox list, string query, int opciontodos)
        {
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                int flag = 0;
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();
                //string valueall = "";
                while (rsLista.Read())
                {
                    Lista.Add(new AddValueString(rsLista.GetString(1), rsLista.GetInt32(0).ToString()));
                    //valueall += rsLista.GetString(0) + ",";
                    flag++;
                }

                rsLista.Close();
                //valueall += "0";
                if (opciontodos == 1)
                {
                    Lista.Add(new AddValueString("TODOS", "0"));
                }

                if (flag > 0)
                {
                    ListHadBeenAdded = false;
                   
                    list.ComboBox.DataSource = Lista;
                    list.ComboBox.DisplayMember = "Display";
                    list.ComboBox.ValueMember = "Value";
                    ListHadBeenAdded = true;
                }
            }
        }
        protected void ConnectDropDownList(ComboBox list, string query, int opciontodos)
        {
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                int flag = 0;
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();
                //string valueall = "";
                while (rsLista.Read())
                {
                    Lista.Add(new AddValueString(rsLista.GetString(1), rsLista.GetInt32(0).ToString()));
                    //valueall += rsLista.GetString(0) + ",";
                    flag++;
                }

                rsLista.Close();


                if (opciontodos == 1)
                {
                    Lista.Add(new AddValueString("TODOS", "0"));
                }

                if (flag > 0)
                {
                    ListHadBeenAdded = false;
                    list.DataSource = Lista;
                    list.DisplayMember = "Display";
                    list.ValueMember = "Value";
                    ListHadBeenAdded = true;
                }
            }
        }
        /// <summary>
        /// <para name="option">
        /// Parametro que depende del filtro a usar, ejemplo ID de Parametro de filtro
        /// </para>
        /// LLenar la lista con los campos del filtro deseado.
        /// </summary>
        private void LlenaFiltro(ComboBox list,int option)
        {
            string query = "";
            switch (option)
            {
                case 1:

                    break;
            }

            ConnectDropDownList(list, query);
        }

        protected void ConnectDropDownList(ComboBox list, string query)
        {
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                int flag = 0;
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                    flag++;
                }

                rsLista.Close();
                if (flag > 0)
                {
                    ListHadBeenAdded = false;
                    list.DataSource = Lista;
                    list.DisplayMember = "Display";
                    list.ValueMember = "Value";
                    ListHadBeenAdded = true;
                }
            }
        }

        protected void ConnectCheckListBox(CheckedListBox list, string query)
        {
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                int flag = 0;
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                    flag++;
                }

                rsLista.Close();
                if (flag > 0)
                {
                    ListHadBeenAdded = false;
                    list.DataSource = Lista;
                    list.DisplayMember = "Display";
                    list.ValueMember = "Value";
                    ListHadBeenAdded = true;
                }
            }
        }

        protected void radConnectDropDownList(RadDropDownList list, string query)
        {
            using (SqlConnection connection = new SqlConnection(Strconexion))
            {
                int flag = 0;
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                    flag++;
                }

                rsLista.Close();
                if (flag > 0)
                {
                    ListHadBeenAdded = false;
                    list.DataSource = Lista;
                    list.DisplayMember = "Display";
                    list.ValueMember = "Value";
                    ListHadBeenAdded = true;
                }
                else
                {
                    list.DataSource = Lista;
                    list.DisplayMember = "Display";
                    //list.ValueMember = "Value";
                }
                connection.Close();
            }
        }
        protected void ConnectDropDownList(ComboBox list, string table, string datavaluefield, string datatextfield)
        {
            int flag = 0;
            string query = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " ORDER BY 1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                    flag++;
                }

                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected bool ConnectDropDownList(ComboBox list, string table, string datavaluefield, string datatextfield, int orderby)
        {
            bool HasElements = false;
            int flag = 0;
            string query = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " ORDER BY " + orderby.ToString();
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                if (rsLista.HasRows)
                {
                    while (rsLista.Read())
                    {
                        Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                        flag++;
                    }
                }
                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                HasElements = true;

                ListHadBeenAdded = true;

                return HasElements;
            }
        }


        protected void ConnectDropDownListDoubleTextField(ComboBox list,  string table, string datavaluefield, string datatextfield, string datatextfield2, int orderby)
        {
            int flag = 0;
            string query = "SELECT " + datavaluefield + "," + datatextfield + "," + datatextfield2 + " FROM " + table + " ORDER BY " + orderby.ToString();
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1) + " " + rsLista.GetString(2), rsLista.GetInt32(0)));
                    flag++;
                }

                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void ConnectDropDownListSS(ComboBox list,  string table, string datavaluefield, string datatextfield, int orderby)
        {
            int flag = 0;
            string query = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " ORDER BY " + orderby.ToString();
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValueSS(rsLista.GetString(1), rsLista.GetInt32(0).ToString()));
                    flag++;
                }

                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void ConnectDropDownList(ComboBox list,  string table, string datavaluefield, string datatextfield, string Orderby, string datacompare, string CveEqual)
        {
            string query = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datacompare + " IN (" + CveEqual + ") ORDER BY " + Orderby;
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                }

                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void ConnectDropDownList(ComboBox list,  string table, string datavaluefield, string datatextfield, string Orderby, string datacompare, string CveEqual, int NotIn)
        {
            string query = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datacompare + " NOT IN (" + CveEqual + ") ORDER BY " + Orderby;
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                }

                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void ConnectDropDownList(ComboBox list, string table, string datavaluefield, string datatextfield, string Orderby, string datacompare, string CveEqual, string datacompare2, string CveEqual2)
        {
            string query = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datacompare + " IN (" + CveEqual + ") AND " + datacompare2 + " IN(" + CveEqual2 + ") ORDER BY " + Orderby;
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rsLista = cmd.ExecuteReader();
                ArrayList Lista = new ArrayList();

                while (rsLista.Read())
                {
                    Lista.Add(new AddValue(rsLista.GetString(1), rsLista.GetInt32(0)));
                }

                rsLista.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void radConnectDropDownListEdit(RadDropDownList list, string table, string datavaluefield, string datatextfield, string dataclavefield)
        {
            int flag = 0;
            string queryone = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "=" + dataclavefield + " ORDER BY 1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdone = new SqlCommand(queryone, con);

                SqlDataReader rsListaone = cmdone.ExecuteReader();
                ArrayList Lista = new ArrayList();
                rsListaone.Read();
                Lista.Add(new AddValue(rsListaone.GetString(1), rsListaone.GetInt32(0)));
                rsListaone.Close();

                string querytwo = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "!=" + dataclavefield + " ORDER BY 2";
                SqlCommand cmdtwo = new SqlCommand(querytwo, con);

                SqlDataReader rsListatwo = cmdtwo.ExecuteReader();
                while (rsListatwo.Read())
                {
                    Lista.Add(new AddValue(rsListatwo.GetString(1), rsListatwo.GetInt32(0)));
                    flag++;
                }

                rsListatwo.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }
        protected void ConnectDropDownListEdit(ComboBox list,  string table, string datavaluefield, string datatextfield, string dataclavefield)
        {
            int flag = 0;
            string queryone = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "=" + dataclavefield + " ORDER BY 1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdone = new SqlCommand(queryone, con);

                SqlDataReader rsListaone = cmdone.ExecuteReader();
                ArrayList Lista = new ArrayList();
                rsListaone.Read();
                Lista.Add(new AddValue(rsListaone.GetString(1), rsListaone.GetInt32(0)));
                rsListaone.Close();

                string querytwo = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "!=" + dataclavefield + " ORDER BY 2";
                SqlCommand cmdtwo = new SqlCommand(querytwo, con);

                SqlDataReader rsListatwo = cmdtwo.ExecuteReader();
                while (rsListatwo.Read())
                {
                    Lista.Add(new AddValue(rsListatwo.GetString(1), rsListatwo.GetInt32(0)));
                    flag++;
                }

                rsListatwo.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void ConnectDropDownListEditSS(ComboBox list, string table, string datavaluefield, string datatextfield, string dataclavefield)
        {
            int flag = 0;
            string queryone = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "=" + dataclavefield + " ORDER BY 1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdone = new SqlCommand(queryone, con);

                SqlDataReader rsListaone = cmdone.ExecuteReader();
                ArrayList Lista = new ArrayList();
                rsListaone.Read();
                Lista.Add(new AddValue(rsListaone.GetString(1), rsListaone.GetInt32(0)));
                rsListaone.Close();

                string querytwo = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "!=" + dataclavefield + " ORDER BY 2";
                SqlCommand cmdtwo = new SqlCommand(querytwo, con);

                SqlDataReader rsListatwo = cmdtwo.ExecuteReader();
                while (rsListatwo.Read())
                {
                    Lista.Add(new AddValue(rsListatwo.GetString(1), rsListatwo.GetInt32(0)));
                    flag++;
                }

                rsListatwo.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }
        }

        protected void radConnectDropDownListEdit(RadDropDownList list, string table, string datavaluefield, string datatextfield, string dataclavefield, string datavaluefield2, string dataclavefield2)
        {
            int flag = 0;
            string queryone = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "=" + dataclavefield + " ORDER BY 1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdone = new SqlCommand(queryone, con);

                SqlDataReader rsListaone = cmdone.ExecuteReader();
                ArrayList Lista = new ArrayList();
                rsListaone.Read();
                Lista.Add(new AddValue(rsListaone.GetString(1), rsListaone.GetInt32(0)));
                rsListaone.Close();

                string querytwo = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "!=" + dataclavefield + " AND " + datavaluefield2 + "=" + dataclavefield2 + " ORDER BY 2";
                SqlCommand cmdtwo = new SqlCommand(querytwo, con);

                SqlDataReader rsListatwo = cmdtwo.ExecuteReader();
                while (rsListatwo.Read())
                {
                    Lista.Add(new AddValue(rsListatwo.GetString(1), rsListatwo.GetInt32(0)));
                    flag++;
                }

                rsListatwo.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }

        }
        protected void ConnectDropDownListEdit(ComboBox list,  string table, string datavaluefield, string datatextfield, string dataclavefield, string datavaluefield2, string dataclavefield2)
        {
            int flag = 0;
            string queryone = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "=" + dataclavefield + " ORDER BY 1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdone = new SqlCommand(queryone, con);

                SqlDataReader rsListaone = cmdone.ExecuteReader();
                ArrayList Lista = new ArrayList();
                rsListaone.Read();
                Lista.Add(new AddValue(rsListaone.GetString(1), rsListaone.GetInt32(0)));
                rsListaone.Close();

                string querytwo = "SELECT " + datavaluefield + "," + datatextfield + " FROM " + table + " WHERE " + datavaluefield + "!=" + dataclavefield + " AND " + datavaluefield2 + "=" + dataclavefield2 + " ORDER BY 2";
                SqlCommand cmdtwo = new SqlCommand(querytwo, con);

                SqlDataReader rsListatwo = cmdtwo.ExecuteReader();
                while (rsListatwo.Read())
                {
                    Lista.Add(new AddValue(rsListatwo.GetString(1), rsListatwo.GetInt32(0)));
                    flag++;
                }

                rsListatwo.Close();
                con.Close();

                ListHadBeenAdded = false;
                list.DataSource = Lista;
                list.DisplayMember = "Display";
                list.ValueMember = "Value";
                ListHadBeenAdded = true;
            }

        }

        public string SwitchDate(string date, int option)
        {
            switch (option)
            {
                case 1:
                    string[] tempdate = new string[3];
                    tempdate = date.Split('/');
                    string day = tempdate[0]; string month = tempdate[1]; string year = tempdate[2];
                    date = year + "/" + month + "/" + day;
                    break;

                case 2:
                    string[] tempdate0 = new string[2];
                    tempdate0 = date.Split(' ');
                    date = tempdate0[0];
                    string[] tempdate2 = new string[3];
                    tempdate2 = date.Split('/');
                    string year2 = tempdate2[0]; string month2 = tempdate2[1]; string day2 = tempdate2[2];
                    date = day2 + "/" + month2 + "/" + year2;
                    break;

                default:
                    date = "00/00/0000";
                    break;
            }

            return date;
        }

        public int alreadyexists(string field, string table,  string fieldvalor)
        {
            string querybusqueda = "SELECT " + field + " FROM " + table + " WHERE " + field + "='" + fieldvalor + "'";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlCommand cmdbusqueda = new SqlCommand(querybusqueda, con);
                SqlDataReader reader = cmdbusqueda.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    reader.Close();
                    return 1;
                }
                else
                {
                    reader.Close();
                    return 0;
                }
                con.Close();
            }
        }

        protected bool alreadyexists(string field, string table, string fieldvalor, string field2, string fieldvalor2)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                string querybusqueda = "SELECT " + field + " FROM " + table + " WHERE " + field + "=" + fieldvalor + " AND " + field2 + "=" + fieldvalor2;
                SqlCommand cmdbusqueda = new SqlCommand(querybusqueda, con);
                SqlDataReader reader = cmdbusqueda.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    con.Close();
                    return false;
                }
                con.Close();
            }
        }
        protected bool alreadyexists(string Query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                string querybusqueda = Query;
                SqlCommand cmdbusqueda = new SqlCommand(querybusqueda, con);
                SqlDataReader reader = cmdbusqueda.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    con.Close();
                    return false;
                }
                con.Close();
            }
        }

        public bool IsNumeric(object ValueToCheck)
        {
            double Dummy = new double();
            string InputValue = Convert.ToString(ValueToCheck);
            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Currency, null, out Dummy);
            return Numeric;
        }

        public bool IsNumeric(object ValueToCheck, bool simple)
        {
            double Dummy = new double();
            string InputValue = Convert.ToString(ValueToCheck);
            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Float, null, out Dummy);
            return Numeric;
        }

        public float GetFloatField(string CveField, string Table, string CveFieldEqual, string CveFieldCompare)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "SELECT " + CveField + " FROM " + Table + " WHERE " + CveFieldEqual + "=" + CveFieldCompare;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                float Field = 0;
                if (readerField.HasRows)
                {
                    readerField.Read();
                    if (readerField[CveField].ToString() != "")
                    {
                        Field = float.Parse(readerField[CveField].ToString());
                    }
                }

                readerField.Close();
                con.Close();

                return Field;
            }
        }

        public int GetIntField(string CveField, string Table, string CveFieldEqual, string CveFieldCompare)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "SELECT " + CveField + " FROM " + Table + " WHERE " + CveFieldEqual + "=" + CveFieldCompare;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                int Field = 0;
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = int.Parse(readerField[CveField].ToString());
                }

                readerField.Close();
                con.Close();

                return Field;
            }
        }
        public double GetIntField(string CveField, string Query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = Query;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                double Field = 0;
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = double.Parse(readerField[CveField].ToString());
                }

                readerField.Close();
                con.Close();

                return Field;
            }
        }
        public int GetIntFieldint(string CveField, string Query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = Query;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                int Field = 0;
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = int.Parse(readerField[CveField].ToString());
                }

                readerField.Close();
                con.Close();

                return Field;
            }
        }

        public string GetStrFieldQuery(string CveField, string Query, SqlConnection connection, SqlTransaction transaction)
        {

                string queryField = Query;
            string Field = "";
            SqlCommand cmdField = new SqlCommand(queryField, connection,transaction);
            using (SqlDataReader readerField = cmdField.ExecuteReader())
            {
              
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = readerField[CveField].ToString();
                }

            }
           return Field;
           
        }
        public string GetStrFieldQuery(string CveField, string Query)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = Query;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                string Field = "";
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = readerField[CveField].ToString();
                }

                readerField.Close();
                con.Close();

                return Field;
            }
        }

       
        public bool TimbraSat(int CveFactura, int CveReceptor, int CveEmisor, int cvetipofactura, int CveEstatusFactura, RadWaitingBar rwb)
        {
            //int CveEstatusFactura = int.Parse(dataGrid.CurrentRow.Cells["CveEstatus"].Value.ToString());

            bool Timbra = false;
            if (CveEstatusFactura == 1)
            {
                DialogResult result;
                result = MessageBox.Show("¿Está seguro que desea sellar la Factura?", "Sellar Factura", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    rwb.Visible = true;
                    rwb.StartWaiting();

                    MessageBox.Show("Presione el botón de aceptar y espere que se certifique su documento...", "Validación de Datos");

                    //Este ejemplo está dirigido a aquellos integradores que aún no generan el xml (CFDI)

                    //Inicializamos el conector el parámetro indica el ambiente en el que se utilizará 
                    //Fasle = Ambiente de pruebas
                    //True = Ambiente de producción
                    Conector conector;
                    if (int.Parse(CredencialPV.Id_CredencialPV1) == 1)
                        conector = new Conector(true);
                    else
                        conector = new Conector(false);

                    //Establecemos las credenciales para el permiso de conexión
                    //Ambiente de pruebas = mvpNUXmQfK8=
                    //Ambiente de producción = Esta será asignado por el proveedor al salir a productivo

                    //conector.EstableceCredenciales("mvpNUXmQfK8=");
                    conector.EstableceCredenciales(PasswordPV.Id_PasswordPV1);

                    //Creamos un comprobante por medio de la entidad Comprobante

                    Comprobante comprobante = new Comprobante();

                  
                    int CveCliente = 0, CveExpedicion = 0;
                    using (SqlConnection con = new SqlConnection(Strconexion))
                    {
                        con.Open();
                        string Query = "SELECT CveFactura, CveMetodoPago, FolioInt, Serie, FechaEmision, CveEmisor, CveSucursal,LugarExpedicion,  CveReceptor, CveTipoFactura, SubTotal, Descuento, IvaP, IvaTotal, Total, TotalLetra, MetodoPago, FormaPago, ISRRetenido, IVARetenido, Observacion FROM Facturas  WHERE CveFactura=" + CveFactura;

                        using (SqlCommand cmdF = new SqlCommand(Query, con))
                        using (SqlDataReader readerF = cmdF.ExecuteReader())
                        {
                            if (readerF.HasRows)
                            {
                                readerF.Read();


                                CveExpedicion = int.Parse(readerF["CveSucursal"].ToString());
                                //Llenamos datos del comprobante
                                if (readerF["Serie"].ToString() != "")
                                    comprobante.serie = readerF["Serie"].ToString();

                                comprobante.folio = readerF["Folioint"].ToString();
                                comprobante.fecha = DateTime.Parse(readerF["FechaEmision"].ToString());
                                comprobante.formaDePago = readerF["FormaPago"].ToString();

                                string ClaveMetodoPago = GetStrFieldQuery("Clave", "Select Clave From CatMetodoPagoFactura Where CveMetodoPago=" + readerF["CveMetodoPago"].ToString());


                                comprobante.metodoDePago = ClaveMetodoPago; //readerF["MetodoPago"].ToString();

                                comprobante.metodoDePago = readerF["MetodoPago"].ToString();
                                comprobante.descuento = decimal.Parse(readerF["Descuento"].ToString());
                                comprobante.subTotal = decimal.Parse(readerF["SubTotal"].ToString());
                                comprobante.total = decimal.Parse(readerF["Total"].ToString());



                                //TIPO DE COMPROBANTE 
                                //Ingreso: Factura 1, Rec honorarios 4, rec de arrendamiento 5, Rec donativos 7, Nota de cargo 3
                                //Egreso: Nota de credito 2
                                //Traslado: Carta porte  6
                                comprobante.tipoDeComprobante = ComprobanteTipoDeComprobante.ingreso;




                                switch (int.Parse(readerF["CveTipoFactura"].ToString()))
                                {
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                    case 3:
                                        break;
                                }



                                comprobante.LugarExpedicion = readerF["LugarExpedicion"].ToString();


                                //Llenamos impuestos
                                comprobante.Impuestos = new ComprobanteImpuestos();
                                comprobante.Impuestos.Traslados = new ComprobanteImpuestosTraslado[1];
                                comprobante.Impuestos.Traslados[0] = new ComprobanteImpuestosTraslado();
                                comprobante.Impuestos.Traslados[0].importe = decimal.Parse(readerF["IVATotal"].ToString());
                                comprobante.Impuestos.Traslados[0].impuesto = ComprobanteImpuestosTrasladoImpuesto.IVA;
                                comprobante.Impuestos.Traslados[0].tasa = 16;

                                if (cvetipofactura != 1)
                                {
                                    comprobante.Impuestos.Retenciones = new ComprobanteImpuestosRetencion[2];
                                    comprobante.Impuestos.Retenciones[0] = new ComprobanteImpuestosRetencion();
                                    comprobante.Impuestos.Retenciones[0].importe = decimal.Parse(readerF["IVARetenido"].ToString());
                                    comprobante.Impuestos.Retenciones[0].impuesto = ComprobanteImpuestosRetencionImpuesto.IVA;
                                    comprobante.Impuestos.Retenciones[1] = new ComprobanteImpuestosRetencion();
                                    comprobante.Impuestos.Retenciones[1].importe = decimal.Parse(readerF["ISRRetenido"].ToString());
                                    comprobante.Impuestos.Retenciones[1].impuesto = ComprobanteImpuestosRetencionImpuesto.ISR;

                                }
                            }

                        }

                        string QueryEmisor = "SELECT CveEmisor, E.Nombre, RFC, Regimen,  TipoEmisor, Calle, NoInterior, NoExterior, Colonia, Mp.Nombre AS Municipio, CE.Nombre AS Estado, Pais, CP  FROM Emisores E LEFT JOIN CatMunicipios MP ON E.CveMunicipio=MP.CveMunicipio LEFT JOIN CatEstados CE ON E.CveEstado=CE.CveEstado WHERE CveEmisor=" + CveEmisor;
                        using (SqlCommand cmdEmisor = new SqlCommand(QueryEmisor, con))
                        using (SqlDataReader readerEmisor = cmdEmisor.ExecuteReader())
                        {
                            if (readerEmisor.HasRows)
                            {
                                readerEmisor.Read();

                                //Llenamos datos del emisor
                                comprobante.Emisor = new ComprobanteEmisor();
                                comprobante.Emisor.rfc = readerEmisor["RFC"].ToString();
                                comprobante.Emisor.nombre = readerEmisor["Nombre"].ToString(); //"Empresa de pruebas S.A. de C.V."; 

                                //Llenamos domicilio fiscal del emisor
                                comprobante.Emisor.DomicilioFiscal = new t_UbicacionFiscal();
                                comprobante.Emisor.DomicilioFiscal.calle = readerEmisor["Calle"].ToString(); //"Calle pruebas"; //readerEmisor["Direccion"].ToString();
                                comprobante.Emisor.DomicilioFiscal.noExterior = readerEmisor["NoExterior"].ToString();// "1"; //

                                if (readerEmisor["NoInterior"].ToString() != "")
                                    comprobante.Emisor.DomicilioFiscal.noInterior = readerEmisor["NoInterior"].ToString(); //"A"; //
                                else
                                    comprobante.Emisor.DomicilioFiscal.noInterior = "S/N";


                                if (readerEmisor["Colonia"].ToString() != "")
                                    comprobante.Emisor.DomicilioFiscal.colonia = readerEmisor["Colonia"].ToString();// "Colonia pruebas"; //
                                else
                                    comprobante.Emisor.DomicilioFiscal.colonia = "No especificado";


                                comprobante.Emisor.DomicilioFiscal.municipio = readerEmisor["Municipio"].ToString(); //"Municipio pruebas"; //
                                comprobante.Emisor.DomicilioFiscal.estado = readerEmisor["Estado"].ToString();// "Estado pruebas"; //
                                comprobante.Emisor.DomicilioFiscal.pais = "Mexico";
                                comprobante.Emisor.DomicilioFiscal.codigoPostal = readerEmisor["CP"].ToString();// "53125"; 

                                //Llenamos regimen fiscal del emisor
                                comprobante.Emisor.RegimenFiscal = new ComprobanteEmisorRegimenFiscal[1];
                                comprobante.Emisor.RegimenFiscal[0] = new ComprobanteEmisorRegimenFiscal();
                                comprobante.Emisor.RegimenFiscal[0].Regimen = readerEmisor["Regimen"].ToString();// "Regimen general de ley personas morales"; 


                            }
                        }

                        string QuerySucursal = "Select * From SucursalEmisor Where CveSucursal=" + CveExpedicion;
                        using (SqlCommand cmdSucursal = new SqlCommand(QuerySucursal, con))
                        using (SqlDataReader readersucursal = cmdSucursal.ExecuteReader())
                        {
                            if (readersucursal.HasRows)
                            {

                                readersucursal.Read();


                                //Llena datos de expedido en (Solo en caso de que el comprobante haya sido expedido en una sucursal y no en la matriz
                                comprobante.Emisor.ExpedidoEn = new t_Ubicacion();
                                comprobante.Emisor.ExpedidoEn.calle = readersucursal["Calle"].ToString(); //"Calle expedido en"; //
                                comprobante.Emisor.ExpedidoEn.noExterior = readersucursal["NoExterior"].ToString(); //"2"; //

                                if (readersucursal["NoInterior"].ToString() != "")
                                    comprobante.Emisor.ExpedidoEn.noInterior = readersucursal["NoInterior"].ToString(); //"B"; //
                                else
                                    comprobante.Emisor.ExpedidoEn.noInterior = "S/N";

                                if (readersucursal["Colonia"].ToString() != "")
                                    comprobante.Emisor.ExpedidoEn.colonia = readersucursal["Colonia"].ToString(); //"Colonia expedido en"; //
                                else
                                    comprobante.Emisor.ExpedidoEn.colonia = "No especificado";

                                comprobante.Emisor.ExpedidoEn.municipio = readersucursal["Municipio"].ToString(); //"Municipio expedido en"; //
                                comprobante.Emisor.ExpedidoEn.estado = readersucursal["Estado"].ToString(); //"Estado expedido en"; //
                                comprobante.Emisor.ExpedidoEn.pais = readersucursal["Pais"].ToString(); //"Mexico"; //
                                comprobante.Emisor.ExpedidoEn.codigoPostal = readersucursal["CP"].ToString(); //"53120"; 

                            }
                        }

                        string QueryReceptor = "SELECT CveReceptor, E.Nombre, RFC, TipoReceptor, Calle, NoInterior, NoExterior, Colonia, Mp.Nombre AS Municipio, CE.Nombre AS Estado, Pais, CP  FROM Receptores E LEFT JOIN CatMunicipios MP ON E.CveMunicipio=MP.CveMunicipio LEFT JOIN CatEstados CE ON E.CveEstado=CE.CveEstado WHERE CveReceptor=" + CveReceptor;

                        using (SqlCommand cmdReceptor = new SqlCommand(QueryReceptor, con))
                        using (SqlDataReader readerReceptor = cmdReceptor.ExecuteReader())
                        {
                            if (readerReceptor.HasRows)
                            {
                                readerReceptor.Read();

                                //Llena datos del receptor
                                comprobante.Receptor = new ComprobanteReceptor();
                                comprobante.Receptor.rfc = readerReceptor["RFC"].ToString();
                                comprobante.Receptor.nombre = readerReceptor["Nombre"].ToString(); //"Cliente de prueba S.A. de C.V."; 

                                //Llena domicilio del receptor
                                comprobante.Receptor.Domicilio = new t_Ubicacion();
                                comprobante.Receptor.Domicilio.calle = readerReceptor["Calle"].ToString(); //"Calle cliente";
                                comprobante.Receptor.Domicilio.noExterior = readerReceptor["NoExterior"].ToString(); //"3";

                                if (readerReceptor["NoInterior"].ToString() != "")
                                    comprobante.Receptor.Domicilio.noInterior = readerReceptor["NoInterior"].ToString(); //"C";
                                else
                                    comprobante.Receptor.Domicilio.noInterior = "S/N";
                                if (readerReceptor["Colonia"].ToString() != "")
                                    comprobante.Receptor.Domicilio.colonia = readerReceptor["Colonia"].ToString(); //"Colonia cliente";
                                else
                                    comprobante.Receptor.Domicilio.colonia = "No especificado";


                                comprobante.Receptor.Domicilio.municipio = readerReceptor["Municipio"].ToString(); //"Municipio cliente";
                                comprobante.Receptor.Domicilio.estado = readerReceptor["Estado"].ToString();// "Estado cliente";
                                comprobante.Receptor.Domicilio.pais = readerReceptor["Pais"].ToString(); //"Mexico";
                                comprobante.Receptor.Domicilio.codigoPostal = readerReceptor["CP"].ToString(); //"5";

                            }

                        }
                        string QueryConceptos = "SELECT CveDetalleFactura, CveNota, Cantidad, Unidad, Descripcion, Precio, SubTotal, Descuento, IVA, Total FROM DetalleFacturas WHERE CveFactura=" + CveFactura;
                        //Llenamos los conceptos
                        int i = 0;
                        int Cuenta = int.Parse(GetStrFieldQuery("Cuenta", "Select Count(*) As Cuenta From DetalleFacturas Where CveFactura=" + CveFactura));
                        comprobante.Conceptos = new ComprobanteConcepto[Cuenta];
                        using (SqlCommand cmdConceptos = new SqlCommand(QueryConceptos, con))
                        using (SqlDataReader readerConceptos = cmdConceptos.ExecuteReader())
                        {

                            while (readerConceptos.Read())
                            {
                                //Concepto 1
                                comprobante.Conceptos[i] = new ComprobanteConcepto();
                                comprobante.Conceptos[i].cantidad = decimal.Parse(readerConceptos["Cantidad"].ToString());
                                comprobante.Conceptos[i].unidad = readerConceptos["Unidad"].ToString(); //"PZA";
                                comprobante.Conceptos[i].noIdentificacion = "1";
                                comprobante.Conceptos[i].descripcion = readerConceptos["Descripcion"].ToString(); //"Prueba concepto 1";
                                comprobante.Conceptos[i].valorUnitario = decimal.Parse(readerConceptos["Precio"].ToString());
                                comprobante.Conceptos[i].importe = decimal.Parse(readerConceptos["SubTotal"].ToString());


                                i++;
                            }
                        }

                    }

                    //Timbramos el CFDI por medio del conector y guardamos resultado
                    ResultadoTimbre resultadoTimbre;
                    resultadoTimbre = conector.TimbraCFDI(comprobante);

                    //Verificamos el resultado
                    if (resultadoTimbre.Exitoso)
                    {
                        //El comprobante fue timbrado exitosamente

                        //Guardamos xml cfdi
                        string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";
                        string NombreFactura = comprobante.Emisor.rfc + "_" + comprobante.Receptor.rfc + "_" + CveFactura;
                        if (resultadoTimbre.GuardaXml(Destinoxml, NombreFactura))
                        {
                            //MessageBox.Show("El xml fue guardado correctamente");
                            GuardarXmlCodigo(CveFactura, NombreFactura + ".xml", "Xml");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar el comprobante");
                        }

                        //Los siguientes datos deberán ir en la respresentación impresa ó PDF

                        //1.- Código bidimensional QR
                        string Destinoqr = Path.GetDirectoryName(Application.ExecutablePath) + @"\QR\";
                        if (resultadoTimbre.GuardaCodigoBidimensional(Destinoqr, NombreFactura))
                        {
                            //MessageBox.Show("El código bidimensional fue guardado correctamente");
                            GuardarQR(CveFactura, Destinoqr + NombreFactura + ".jpg", "QR", "?QRCodigo");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar el código bidimensional");
                        }

                        //2.- Folio fiscal
                        string folioFiscal = resultadoTimbre.FolioUUID;

                        //3.- No. Certificado del Emisor
                        string noCertificado = resultadoTimbre.No_Certificado;

                        //4.- No. Certificado del SAT
                        string noCertificadoSAT = resultadoTimbre.No_Certificado_SAT;

                        //5.- Fecha y Hora de certificación
                        string fechaCert = resultadoTimbre.FechaCertificacion;

                        //6.- Sello del cfdi
                        string selloCFDI = resultadoTimbre.SelloCFDI;

                        //7.- Sello del SAT
                        string selloSAT = resultadoTimbre.SelloSAT;

                        //8.- Cadena original de complemento de certificación
                        string cadena = resultadoTimbre.CadenaTimbre;

                        string QueryUpdateFactura = "Update Facturas Set FechaCertificacion='" + fechaCert + "',CadenaOriginal='" + cadena + "',UUID='" + folioFiscal + "',SCDCFDI='" + selloCFDI + "',SCDSAT='" + selloSAT + "', CertificadoSAT='" + noCertificadoSAT + "',CertificadoEmisor='" + noCertificado + "', CveEstatus=2 Where CveFactura=" + CveFactura;
                        performupdatequery(QueryUpdateFactura);


                        MessageBox.Show("Timbrado Exitoso, por favor espere un momento mientras se generan los archivos....", "Validacion de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ExportarReport(CveFactura, CveEmisor, CveReceptor, cvetipofactura, Destinoxml + NombreFactura + ".pdf");
                        GuardarXmlCodigo(CveFactura, NombreFactura + ".pdf", "PDF");

                        MessageBox.Show("Proceso terminado, ahora ya puede imprimir su factura", "Validación de Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        Process.Start(Destinoxml + NombreFactura + ".pdf");

                        Timbra = true;

                    }
                    else
                    {
                        //No se pudo timbrar, mostramos respuesta
                        MessageBox.Show(resultadoTimbre.Descripcion);
                    }

                    rwb.StopWaiting();
                    rwb.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("El estatus de la factura no es valido, favor de verificar que no haya sido timbrada o cancelada con anterioridad", "Validacion de Datos");
            }

            return Timbra;

        }

        public void GuardarXmlCodigo(int CveFactura, string Ruta, string Campo)
        {
            if (Ruta != null)
            {
                string Query = "Update Facturas Set " + Campo + "='" + Ruta + "' Where CveFactura=" + CveFactura;
                performupdatequery(Query);

                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");
              
            }
        }
        public void GuardarQR(int CveFactura, string Ruta, string Campo, string Variable)
        {
            if (Ruta != null)
            {
                String strBLOBFilePath =Ruta;
                FileStream fsBLOBFile = new FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read);
                Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
                fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                fsBLOBFile.Close();
                using (SqlConnection con = new SqlConnection(Strconexion))
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "Update Facturas Set "+ Campo +"="+ Variable + " Where CveFactura=" + CveFactura;
                    SqlParameter prm = new SqlParameter(Variable, SqlDbType.Image, bytBLOBData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBLOBData);
                    cmd2.Parameters.Add(prm);
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
               

                //MessageBox.Show("Xml y Codigo Guardado en la Base de Datos");

            }
        }

        void ExportarReport(int CveFactura, int CveEmisor, int CveReceptor, int CveTipoFactura, string Ruta)
        {
            switch (CveTipoFactura)
            {
                case 1:
                    /*RptFacturas rptFac = new RptFacturas();
                    rptFac.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), rptFac);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), rptFac);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), rptFac);


                    rptFac.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                    */
                    string NombreFac = GetStrFieldQuery("Rpt", "SELECT FF.Rpt FROM Emisores E LEFT JOIN CatFolioFacturas FF ON E.CveEmisor=FF.CveEmisor WHERE FF.CveTipoFactura=1 AND E.CveEmisor=" + CveEmisor);
                    string extesion = "rpt";
                    string DestinoFac = Path.GetDirectoryName(Application.ExecutablePath) + @"\Fac\" + NombreFac + "." + extesion;


                    //creas el reportDocument

                    CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    /*Luego cargas la ruta donde se ubica el reporte y los datos de la conexion a la DB.*/

                    cryRpt.Load(DestinoFac);
                    cryRpt.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord, ServerName.Id_ServerName, BaseDatos.Id_BaseDatos);
                    /*Los parametros los envias de la siguiente forma, el primer valor que pide la Funcion es el nombre del parametro del Reporte y el segundo el valor que le asignas.*/
                    cryRpt.SetParameterValue("CveEmisor", CveEmisor);
                    cryRpt.SetParameterValue("CveReceptor", CveReceptor);
                    cryRpt.SetParameterValue("CveFactura", CveFactura);

                    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);

                    break;
                case 2:
                    /*
                    RptHonorarios RptHo = new RptHonorarios();
                    RptHo.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), RptHo);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), RptHo);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), RptHo);


                    RptHo.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                    */

                    break;
                    
                case 3:
                    /*
                    RptArrendamiento RptAre = new RptArrendamiento();
                    RptAre.SetDatabaseLogon(IdUserName.IdUser_Name, IdPassWord.Id_PassWord);
                    SetParamValueReporte("?CveFactura", CveFactura.ToString(), RptAre);
                    SetParamValueReporte("?CveEmisor", CveEmisor.ToString(), RptAre);
                    SetParamValueReporte("?CveReceptor", CveReceptor.ToString(), RptAre);


                    RptAre.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                    */
                    break;
                    
            }


        }
        private void SetParamValueReporte(string paramName, string paramValue, ReportDocument Reporte)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            for (int i = 0; i < Reporte.DataDefinition.ParameterFields.Count; i++)
            {
                if (Reporte.DataDefinition.ParameterFields[i].FormulaName == "{" + paramName + "}")
                {
                    paramDiscreteValue.Value = paramValue;
                    paramValues.Add(paramDiscreteValue);
                    Reporte.DataDefinition.ParameterFields[i].ApplyCurrentValues(paramValues);
                }
            }
        }
        public string GetStringField(string CveField, string Table, string CveFieldEqual, string CveFieldCompare)
        {
            string Field = "0";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {

                string queryField = "SELECT " + CveField + " FROM " + Table + " WHERE " + CveFieldEqual + "=" + CveFieldCompare;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = readerField[CveField].ToString();
                }

                readerField.Close();
                con.Close();


                return Field;
            }

        }
        public float GetFloatSumField(string CveField, string Table, string CveFieldEqual, string CveFieldCompare)
        {
            string Field = "0";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {

                string queryField = "SELECT Sum(Saldo) As " + CveField + " FROM " + Table + " WHERE " + CveFieldEqual + "=" + CveFieldCompare;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = readerField[CveField].ToString();
                }

                readerField.Close();
                con.Close();

                if (Field == "")
                    Field = "0";

                return float.Parse(Field);
            }
        }

        public string GetStringFields(string CveField, string Table)
        {
            string Field = "";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "SELECT " + CveField + " FROM " + Table;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                while (readerField.Read())
                {
                    Field += readerField[CveField].ToString() + ",";
                }

                readerField.Close();
                con.Close();


                int ultimaComa = Field.LastIndexOf(",");
                Field = Field.Remove(ultimaComa);

                return Field;
            }
        }

        public string GetStringFields(string CveField, string Table, string Separador)
        {
            string Field = "";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "SELECT " + CveField + " FROM " + Table;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                while (readerField.Read())
                {
                    Field += Separador + readerField[CveField].ToString() + Separador + ",";
                }

                readerField.Close();
                con.Close();


                int ultimaComa = Field.LastIndexOf(",");
                Field = Field.Remove(ultimaComa);

                return Field;
            }
        }
        public int GetintCita(string Fecha, int HoraInicial, int HoraFinal)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "Select hour(FechaCitaInicial) As Hora1, hour(FechaCitaFinal) As Hora2 From CitaCliente Where CveEstatusCita!=2 And date(FechaCitaInicial)='" + Fecha + "'";
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                int Field = 0; int Hora1 = 0, Hora2 = 0, entro=0, Cuenta=0;
                if (readerField.HasRows)
                {
                    while (readerField.Read())
                    {
                        Hora1 = int.Parse(readerField["Hora1"].ToString());
                        Hora2 = int.Parse(readerField["Hora2"].ToString());

                        if ((HoraInicial >=Hora1 && HoraInicial<Hora2))
                        {
                            Field += 1;
                        }
                    }

                }

                readerField.Close();
                con.Close();

                
                             

                return Field;
            }
        }
        public string GetStringDate(string CveField, string Table, string CveFieldEqual, string CveFieldCompare)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "SELECT DATE_FORMAT(" + CveField + ", '%d/%m/%Y') AS " + CveField + " FROM " + Table + " WHERE " + CveFieldEqual + "=" + CveFieldCompare;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                string Field = "0";
                if (readerField.HasRows)
                {
                    readerField.Read();
                    Field = readerField[CveField].ToString();
                }

                readerField.Close();
                con.Close();

                return Field;
            }
        }

        public bool GetBoolField(string CveField, string Table, string CveFieldEqual, string CveFieldCompare)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                string queryField = "SELECT " + CveField + " FROM " + Table + " WHERE " + CveFieldEqual + "=" + CveFieldCompare;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                bool Field = false; int dato = 0;
                if (readerField.HasRows)
                {
                    readerField.Read();
                    dato = readerField.GetInt16(0);
                }

                readerField.Close();
                con.Close();

                if (dato == 1)
                    Field = true;



                return Field;
            }
        }

        public int GetMatchingIndexOfDropDown(ComboBox d, string MatchValue)
        {
            int i = 0;

            foreach (AddValue MyItem in d.Items)
            {
                if (MyItem.Value.ToString() == MatchValue)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }

        public class Percepcion
        {
            private string pCveConcepto;
            private string pConcepto;
            private double pImporte;

            public string CveConcepto
            {
                get { return pCveConcepto; }
                set { pCveConcepto = value; }
            }

            public string Concepto
            {
                get { return pConcepto; }
                set { pConcepto = value; }
            }

            public double Importe
            {
                get { return pImporte; }
                set { pImporte = value; }
            }
        }

        public class Deduccion
        {
            private string pCveConcepto;
            private string pConcepto;
            private double pImporte;

            public string CveConcepto
            {
                get { return pCveConcepto; }
                set { pCveConcepto = value; }
            }

            public string Concepto  
            {
                get { return pConcepto; }
                set { pConcepto = value; }
            }

            public double Importe
            {
                get { return pImporte; }
                set { pImporte = value; }
            }
        }

        public class ListaReferencia
        {
            private int intCveProducto;
            private string strNombre;
            private string strCodigo;
            private int intActivo;
            private bool blActivo;

            public int CveProducto
            {
                get
                {
                    return intCveProducto;
                }
                set
                {
                    intCveProducto = value;
                }
            }
            public string Nombre
            {
                get
                {
                    return strNombre;
                }
                set
                {
                    strNombre = value;
                }
            }
            public string CodigoProducto
            {
                get
                {
                    return strCodigo;
                }
                set
                {
                    strCodigo = value;
                }
            }
            public int Activo
            {
                get
                {
                    return intActivo;
                }
                set
                {
                    intActivo = value;
                }
            }
            public bool BActivo
            {
                get
                {
                    return blActivo;
                }
                set
                {
                    blActivo = value;
                }
            }

        }

        //Clase Estatica de Producto
        public class Producto
        {
            public static double CostoUltimaCompra(string cveproducto, string strconexion)
            {
                double costoultimacompra = 0;
                using (SqlConnection con = new SqlConnection(strconexion))
                {
                    con.Open();
                    string queryCostoUltimaCompra = "SELECT IF (MAX(CostoUnitario) IS NULL,0,MAX(CostoUnitario))  AS CostoUnitario FROM Compras C, ComprasDetalle CD WHERE C.CveCompra=CD.CveCompra AND CveProducto=" + cveproducto + " ORDER BY FechaFactura DESC";
                    SqlCommand cmd = new SqlCommand(queryCostoUltimaCompra, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        costoultimacompra = reader.GetDouble(reader.GetOrdinal("CostoUnitario"));

                    }
                    reader.Close();
                    con.Close();
                }
                return costoultimacompra;
            }
        }

        // Clase usada para el Grid de kit de productos
        public class ProductoKit
        {
            private string cveproducto;
            private double cantidad;
            private string nombre;
            private string clave;
            private double preciounitario;
            private double preciototal;
            private string cveprecio;
            private int orden;
            private string strconexionC;

            public string CveProducto
            {
                get { return cveproducto; }
                set { cveproducto = value; }
            }

            public double Cantidad
            {
                get { return cantidad;}
                set { cantidad = value;}
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string Clave
            {
                get { return clave; }
                set { clave = value; }
            }

            public double PrecioUnitario
            {
                get { return preciounitario; }
                set { preciounitario = value; }
            }

            public double PrecioTotal
            {
                get { return preciototal; }
                set { preciototal = value; }
            }

            public string CvePrecio
            {
                get { return cveprecio; }
                set { cveprecio = value; }
            }

            public int Orden
            {
                get { return orden; }
                set { orden = value; }
            }

            public ProductoKit(int cantidad, string nombre, string clave, double preciounitario, double preciototal, string cveprecio, int orden)
            {
                this.cantidad = cantidad;
                this.nombre = nombre;
                this.clave = clave;
                this.preciounitario = preciounitario;
                this.preciototal = preciototal;
            }

            public ProductoKit()
            {
            }
            
            public ProductoKit(string strconexionO)
            {
                strconexionC = strconexionO;
            }

            public DataSet ObtenerHistoricoCompras()
            {
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    //Obtenemos la existencia actual del producto
                    string queryCompras = "SELECT C.CveCompra, FechaFactura, P.Nombre AS Proveedor, Cantidad, CostoUnitario, Cantidad*CostoUnitario AS Subtotal, CD.Iva, CD.Total FROM Compras C, ComprasDetalle CD, Proveedores P WHERE C.CveCompra=CD.CveCompra AND C.CveProveedor=P.CveProveedor AND CveProducto=" + cveproducto;
                    SqlCommand cmd = new SqlCommand(queryCompras, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(queryCompras, con);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "Compras");
                    con.Close();

                    return dataset;
                }
            }

            public double CostoPromedio()
            {
                double costopromedio = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    string queryCostoPromedio = "SELECT AVG(CostoUnitario) AS CostoPromedio FROM ComprasDetalle where CveProducto=" + cveproducto;
                    SqlCommand cmd = new SqlCommand(queryCostoPromedio, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (reader["CostoPromedio"].ToString() != "")
                            costopromedio = reader.GetDouble(reader.GetOrdinal("CostoPromedio"));

                    }
                    reader.Close();
                    con.Close();
                }
                return costopromedio;
            }

            public double FletePromedio()
            {
                double costopromedio = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    string queryCostoPromedio = "SELECT AVG(CostoUnitario) AS CostoPromedio FROM ComprasDetalle where CveProducto=" + cveproducto;
                    SqlCommand cmd = new SqlCommand(queryCostoPromedio, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        costopromedio = reader.GetDouble(reader.GetOrdinal("CostoPromedio"));

                    }
                    reader.Close();
                    con.Close();
                }
                return costopromedio;
            }

            public double CostoUltimaCompra()
            {
                double costoultimacompra = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    string queryCostoUltimaCompra = "SELECT IF (MAX(CostoUnitario) IS NULL,0,MAX(CostoUnitario))  AS CostoUnitario FROM Compras C, ComprasDetalle CD WHERE C.CveCompra=CD.CveCompra AND CveProducto=" + cveproducto + " ORDER BY FechaFactura DESC";
                    SqlCommand cmd = new SqlCommand(queryCostoUltimaCompra, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        costoultimacompra = reader.GetDouble(reader.GetOrdinal("CostoUnitario"));

                    }
                    reader.Close();
                    con.Close();
                }
                return costoultimacompra;
            }
        }

        public class ProductoRefaccion
        {
            private string cveproducto;
            private string nombre;
            private string clave;
            private int cantidad;
            private string numerodeserie;
            private float preciounitario;
            private float subtotal;
            private float descuento;
            private double iva;
            private float preciototal;
            private string strconexionC;
            private float pdescuento;
            private int intCveColor;
            private int intCveAlmacen;

            public string CveProducto
            {
                get { return cveproducto; }
                set { cveproducto = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string Clave
            {
                get { return clave; }
                set { clave = value; }
            }

            public int Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }

            public string NumeroDeSerie
            {
                get { return numerodeserie; }
                set { numerodeserie = value; }
            }

            public float PrecioUnitario
            {
                get { return preciounitario; }
                set { preciounitario = value; }
            }

            public float SubTotal
            {
                get { return subtotal; }
                set { subtotal = value; }
            }

            public float Descuento
            {
                get { return descuento; }
                set { descuento = value; }
            }

            public double Iva
            {
                get { return iva; }
                set { iva = value; }
            }

            public float PrecioTotal
            {
                get { return preciototal; }
                set { preciototal = value; }
            }
            public float PDescuento
            {
                get
                {
                    return pdescuento;
                }
                set
                {
                    pdescuento = value;
                }
            }
            public int CveColor
            {
                get
                {
                    return intCveColor;
                }
                set
                {
                    intCveColor = value;
                }
            }
            public int CveAlmacen
            {
                get
                {
                    return intCveAlmacen;
                }
                set
                {
                    intCveAlmacen = value;
                }
            }

            public ProductoRefaccion(string strconexionO)
            {
                strconexionC = strconexionO;
            }

        }

        // Clase usada para el Grid de Compra de productos
        public class ProductoCompra
        {
            private double cantidad;
            private string cveproducto;
            private string nombre;
            private string clave;
            private string noserie;
            private double preciounitario;
            private double subtotal;
            private double preciototal;
            private double flete;
            private double descuento;
            private double descuentoaplicado;
            private double iva;
            private string strconexionC;
            private bool actualizar;
            private int intcvenota;
            private string caracteristicas;
            private double preciounitariooriginal;
            private int intCveColor;
            private string strColor;
            private double intCantidadDevolucion;
            private double pdescuento;
            private string strNoSerie;
            private string strNoMotor;
            private string strNoPedimento;
            private string strNoCajaVel;
            private string strImportadoPor;
            private int intCveAlmacen;
            private int intCveFormaPago;
            private int intCveNotaReferencia2;
            private int intCvePrecio;
            private string strAlmacen;
            private int intPage;
            private int intCveEmpleado;
            private string strNombreEmpleado;
            private double adicional;
            private string strNombre2;
            private int intCveTipoP;
            private double dblPendiente;
            private double dblAfectar;
            private string strFechaVenta;
            private string strNombreCliente;
            private double DblTotal;
            private string strEstatus;
            private int intCveEstatusDocumento;
            private int intCveEstatusEntrega;
            private string strEstatusEntrega;
            private int intCveTipoDocumento;
            private string strTipoDocumento;
            private int intSIIVA;
            private double dblPIva;
            private string strNoDocumento;
            private string strPoblacion;

            private int intCveNotaDetalle;
            private string strCodigoProducto;

            public decimal UltimoCosto { get; set; }
            public decimal CostoPromedio { get; set; }

            public string StrCodigoProducto
            {
                get { return strCodigoProducto; }
                set { strCodigoProducto = value; }
            }
            public int IntCveNotaDetalle
            {
                get { return intCveNotaDetalle; }
                set { intCveNotaDetalle = value; }
            }

            // FechaEntrega, CveChofer, CveUser_Recibe_Pago, Fecha_Recibe_Pago, CveEstatus

            private int intCveDocumento;
            private int intCveEmbarque;
            private string strFechaEntrega;
            private int intCveChofer;
            private int intCveUser_Recibe_Pago;
            private string strFecha_Recibe_Pago;
            private int intCveEstatusEmbarque;
            private string strNombreChofer;
            private string strEstatusEmbarque;
            private int intCveEmbarqueDetalle;
            private string strObservacion;

            private string strHoraEntrega;
            private string strNombreUsuario;

            public string StrNombreUsuario
            {
                get { return strNombreUsuario; }
                set { strNombreUsuario = value; }
            }

            public string StrHoraEntrega
            {
                get { return strHoraEntrega; }
                set { strHoraEntrega = value; }
            }


            public string Observacion
            {
                get { return strObservacion; }
                set { strObservacion = value; }
            }
            public int CveEmbarqueDetalle
            {
                get { return intCveEmbarqueDetalle; }
                set { intCveEmbarqueDetalle = value; }
            }

            public string EstatusEmbarque
            {
                get { return strEstatusEmbarque; }
                set { strEstatusEmbarque = value; }
            }

            public string NombreChofer
            {
                get { return strNombreChofer; }
                set { strNombreChofer = value; }
            }
            public int CveEstatusEmbarque
            {
                get { return intCveEstatusEmbarque; }
                set { intCveEstatusEmbarque = value; }
            }
            public string Fecha_Recibe_Pago
            {
                get { return strFecha_Recibe_Pago; }
                set { strFecha_Recibe_Pago = value; }
            }

            public int CveUser_Recibe_Pago
            {
                get { return intCveUser_Recibe_Pago; }
                set { intCveUser_Recibe_Pago = value; }
            }
            public int CveChofer
            {
                get { return intCveChofer; }
                set { intCveChofer = value; }
            }
            public string FechaEntrega
            {
                get { return strFechaEntrega; }
                set { strFechaEntrega = value; }
            }
            public int CveEmbarque
            {
                get { return intCveEmbarque; }
                set { intCveEmbarque = value; }
            }

            public int CveDocumento
            {
                get { return intCveDocumento; }
                set { intCveDocumento = value; }
            }




            public string Poblacion
            {
                get { return strPoblacion; }
                set { strPoblacion = value; }
            }
            public string StrNoDocumento
            {
                get { return strNoDocumento; }
                set { strNoDocumento = value; }
            }
            public double PIva
            {
                get { return dblPIva; }
                set { dblPIva = value; }
            }
            public int SIIVA
            {
                get { return intSIIVA; }
                set { intSIIVA = value; }
            }


            public string TipoDocumento
            {
                get { return strTipoDocumento; }
                set { strTipoDocumento = value; }
            }

            public int CveTipoDocumento
            {
                get { return intCveTipoDocumento; }
                set { intCveTipoDocumento = value; }
            }

            public string EstatusEntrega
            {
                get { return strEstatusEntrega; }
                set { strEstatusEntrega = value; }
            }

            public int CveEstatusEntrega
            {
                get { return intCveEstatusEntrega; }
                set { intCveEstatusEntrega = value; }
            }

            public int CveEstatusDocumento
            {
                get { return intCveEstatusDocumento; }
                set { intCveEstatusDocumento = value; }
            }

            public string Estatus
            {
                get { return strEstatus; }
                set { strEstatus = value; }
            }

            public double Total
            {
                get { return DblTotal; }
                set { DblTotal = value; }
            }

            public string NombreCliente
            {
                get { return strNombreCliente; }
                set { strNombreCliente = value; }
            }
            public string StrFechaVenta
            {
                get { return strFechaVenta; }
                set { strFechaVenta = value; }
            }

            public double DblAfectar
            {
                get { return dblAfectar; }
                set { dblAfectar = value; }
            }

            public double DblPendiente
            {
                get { return dblPendiente; }
                set { dblPendiente = value; }
            }

            public int IntCveTipoP
            {
                get { return intCveTipoP; }
                set { intCveTipoP = value; }
            }
            public string Nombre2
            {
                get { return strNombre2; }
                set { strNombre2 = value; }
            }

            public int CveEmpleado
            {
                get
                {
                    return intCveEmpleado;
                }
                set
                {
                    intCveEmpleado = value;
                }
            }
            public string NombreEmpleado
            {
                get
                {
                    return strNombreEmpleado;
                }
                set
                {
                    strNombreEmpleado = value;
                }
            }
            public double Adicional
            {
                get
                {
                    return adicional;
                }
                set
                {
                    adicional = value;
                }
            }


            public int IntPage
            {
                get { return intPage; }
                set { intPage = value; }
            }

            private double dblIvaPorCentaje;

            public double IvaPorCentaje
            {
                get { return dblIvaPorCentaje; }
                set { dblIvaPorCentaje = value; }
            }

            public string Almacen
            {
                get { return strAlmacen; }
                set { strAlmacen = value; }
            }
            private string unidadMedida;

            public string UnidadMedida
            {
                get { return unidadMedida; }
                set { unidadMedida = value; }
            }


            public int CveAlmacen
            {
                get
                {
                    return intCveAlmacen;
                }
                set
                {
                    intCveAlmacen = value;
                }
            }
            public double Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }

            public string CveProducto
            {
                get { return cveproducto; }
                set { cveproducto = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string Clave
            {
                get { return clave; }
                set { clave = value; }
            }

            public string NoSerie
            {
                get { return noserie; }
                set { noserie = value; }
            }

            public double PrecioUnitario
            {
                get { return preciounitario; }
                set { preciounitario = value; }
            }

            public double Flete
            {
                get { return flete; }
                set { flete = value; }
            }

            public double Iva
            {
                get { return iva; }
                set { iva = value; }
            }

            public double Subtotal
            {
                get { return subtotal; }
                set { subtotal = value; }
            }

            public double Descuento
            {
                get { return descuento; }
                set { descuento = value; }
            }

            public double PrecioTotal
            {
                get { return preciototal; }
                set { preciototal = value; }
            }

            public bool Actualizar
            {
                get { return actualizar; }
                set { actualizar = value; }
            }
            public int CveNota
            {
                get { return intcvenota; }
                set { intcvenota = value; }
            }

            public string Caracteristicas
            {
                get { return caracteristicas; }
                set { caracteristicas = value; }
            }
            public double DescuentoAplicado
            {
                get
                {
                    return descuentoaplicado;
                }
                set
                {
                    descuentoaplicado = value;
                }
            }
            public double PrecioUnitarioOriginal
            {
                get
                {
                    return preciounitariooriginal;
                }
                set
                {
                    preciounitariooriginal = value;
                }
            }
            public int CveColor
            {
                get
                {
                    return intCveColor;
                }
                set
                {
                    intCveColor = value;
                }
            }
            public string ColorMoto
            {
                get
                {
                    return strColor;
                }
                set
                {
                    strColor = value;
                }
            }
            public double CantidadDevolucion
            {
                get
                {
                    return intCantidadDevolucion;
                }
                set
                {
                    intCantidadDevolucion = value;
                }
            }
            public double PDescuento
            {
                get
                {
                    return pdescuento;
                }
                set
                {
                    pdescuento = value;
                }
            }

            public string NoMotor
            {
                get
                {
                    return strNoMotor;
                }
                set
                {
                    strNoMotor = value;
                }
            }
            public string NoPedimento
            {
                get
                {
                    return strNoPedimento;
                }
                set
                {
                    strNoPedimento = value;
                }
            }
            public string NoCajaVel
            {
                get
                {
                    return strNoCajaVel;
                }
                set
                {
                    strNoCajaVel = value;
                }
            }
            public string ImportadoPor
            {
                get
                {
                    return strImportadoPor;
                }
                set
                {
                    strImportadoPor = value;
                }
            }
            public int CveFormaPago
            {
                get
                {
                    return intCveFormaPago;
                }
                set
                {
                    intCveFormaPago = value;
                }
            }
            public int CveNotaReferencia2
            {
                get
                {
                    return intCveNotaReferencia2;
                }
                set
                {
                    intCveNotaReferencia2 = value;
                }
            }
            public int CvePrecio
            {
                get
                {
                    return intCvePrecio;
                }
                set
                {
                    intCvePrecio = value;
                }
            }

            public ProductoCompra()
            {

            }

            public ProductoCompra(string strconexionO)
            {
                strconexionC = strconexionO;

            }

            public int ActualizarExistencia(int option)
            {
                int actualizo = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    switch (option)
                    {
                        case 1:
                            //Aumentamos la cantidad del producto
                            string queryExistenciaActual = "SELECT Existencia FROM Productos WHERE CveProducto=" + cveproducto;
                            SqlCommand cmd = new SqlCommand(queryExistenciaActual, con);
                            SqlDataReader reader = cmd.ExecuteReader();
                            try
                            {
                                reader.Read();
                                double Existencia = reader.GetInt16(reader.GetOrdinal("Existencia"));
                                reader.Close();

                                Existencia += Cantidad;

                                //Actualizamos la existencia del producto en el inventario
                                string updateExistencia = "UPDATE Productos SET Existencia=" + Existencia.ToString() + " WHERE CveProducto=" + CveProducto;
                                SqlCommand cmdU = new SqlCommand(updateExistencia, con);
                                actualizo = cmdU.ExecuteNonQuery();

                            }
                            catch
                            {
                                actualizo = 0;
                            }
                            break;

                        case 2:
                            //Disminuimos la cantidad del producto
                            string queryExistenciaActual2 = "SELECT Existencia FROM Productos WHERE CveProducto=" + cveproducto;
                            SqlCommand cmd2 = new SqlCommand(queryExistenciaActual2, con);
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            try
                            {
                                reader2.Read();
                                double Existencia = reader2.GetInt16(reader2.GetOrdinal("Existencia"));
                                reader2.Close();

                                Existencia -= Cantidad;

                                //Actualizamos la existencia del producto en el inventario
                                string updateExistencia2 = "UPDATE Productos SET Existencia=" + Existencia.ToString() + " WHERE CveProducto=" + cveproducto;
                                SqlCommand cmdU2 = new SqlCommand(updateExistencia2, con);
                                actualizo = cmdU2.ExecuteNonQuery();

                            }
                            catch
                            {
                                actualizo = 0;
                            }
                            break;
                    }

                    con.Close();
                }

                return actualizo;
            }

            public int ActualizarPrecio()
            {
                int actualizo = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    //Obtenemos la existencia actual del producto
                    string queryPrecios = "SELECT PorcentajeUtilidad1, PorcentajeUtilidad2, PorcentajeUtilidad3, PorcentajeUtilidad4, PorcentajeUtilidad5, PorcentajeUtilidad6 FROM Productos WHERE CveProducto=" + cveproducto;
                    SqlCommand cmd = new SqlCommand(queryPrecios, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        reader.Read();
                        double PorcentajeUtilidad1 = reader.GetDouble(reader.GetOrdinal("PorcentajeUtilidad1"));
                        double PorcentajeUtilidad2 = reader.GetDouble(reader.GetOrdinal("PorcentajeUtilidad2"));
                        double PorcentajeUtilidad3 = reader.GetDouble(reader.GetOrdinal("PorcentajeUtilidad3"));
                        double PorcentajeUtilidad4 = reader.GetDouble(reader.GetOrdinal("PorcentajeUtilidad4"));
                        double PorcentajeUtilidad5 = reader.GetDouble(reader.GetOrdinal("PorcentajeUtilidad5"));
                        double PorcentajeUtilidad6 = reader.GetDouble(reader.GetOrdinal("PorcentajeUtilidad6"));
                        reader.Close();



                        //this.txtPrecio1.Text = ObtenerPrecio_Venta(this.txtPrecioUltimaCompra.Text, IVA, this.txtUtilidadPrecio1.Text);

                        string Precio1 = ObtenerPrecio_Venta(PrecioUnitario.ToString(), Iva, PorcentajeUtilidad1.ToString()); //preciounitario + PorcentajeUtilidad1;
                        string Precio2 = ObtenerPrecio_Venta(PrecioUnitario.ToString(), Iva, PorcentajeUtilidad2.ToString());//preciounitario + PorcentajeUtilidad2;
                        string Precio3 = ObtenerPrecio_Venta(PrecioUnitario.ToString(), Iva, PorcentajeUtilidad3.ToString());//preciounitario + PorcentajeUtilidad3;
                        string Precio4 = ObtenerPrecio_Venta(PrecioUnitario.ToString(), Iva, PorcentajeUtilidad4.ToString());//preciounitario + PorcentajeUtilidad4;
                        string Precio5 = ObtenerPrecio_Venta(PrecioUnitario.ToString(), Iva, PorcentajeUtilidad5.ToString()); //preciounitario + PorcentajeUtilidad5;
                        string Precio6 = ObtenerPrecio_Venta(PrecioUnitario.ToString(), Iva, PorcentajeUtilidad6.ToString());//preciounitario + PorcentajeUtilidad6;


                        //Actualizamos los precios del producto en el inventario
                        string updatePrecios = "UPDATE Productos SET Precio0=" + preciounitario.ToString() + ", Precio1=" + Precio1 + ", Precio2=" + Precio2 + ", Precio3=" + Precio3 + ", Precio4=" + Precio4 + ", Precio5=" + Precio5 + ", Precio6=" + Precio6 + "  WHERE CveProducto=" + cveproducto;
                        SqlCommand cmdU = new SqlCommand(updatePrecios, con);
                        actualizo = cmdU.ExecuteNonQuery();

                    }
                    catch
                    {
                        actualizo = 0;
                    }
                    con.Close();
                }
                return actualizo;
            }

            public double CostoUltimaCompra()
            {
                double costoultimacompra = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    string queryCostoUltimaCompra = "SELECT IF (MAX(CostoUnitario) IS NULL,0,MAX(CostoUnitario))  AS CostoUnitario FROM Compras C, ComprasDetalle CD WHERE C.CveCompra=CD.CveCompra AND CveProducto=" + cveproducto + " ORDER BY FechaFactura DESC";
                    SqlCommand cmd = new SqlCommand(queryCostoUltimaCompra, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        costoultimacompra = reader.GetDouble(reader.GetOrdinal("CostoUnitario"));

                    }
                    reader.Close();
                    con.Close();
                }
                return costoultimacompra;
            }

            public string ObtenerPrecio_Venta(string PrecioUltimoCosto, double IVA, string UtilidadPrecio)
            {
                double PrecioCosto = double.Parse(PrecioUltimoCosto, System.Globalization.NumberStyles.Currency);
                string StrPUtilidad = UtilidadPrecio.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double PUtilidad = double.Parse(StrPUtilidad) / 100;
                double PrecioFlete = 0;

                double PrecioVenta = 0;

                //PrecioFlete = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
                PrecioVenta = (PrecioCosto * (1 + PUtilidad)) * (1 + IVA);

                //PrecioUltimaCompra += PrecioFlete;

                return String.Format("{0:C}", Math.Ceiling(PrecioVenta));
            }
        }
        public class ProductoDevolucion
        {
            private string cveequipo;
            private int cantidad;
            private string cveproducto;
            private string nombre;
            private string clave;
            private float preciounitario;
            private string numerodeserie;
            private float subtotal;
            private float preciototal;
            private float flete;
            private float descuento;
            private double iva;
            private string strconexionC;
            private bool actualizar;
            private int intcvenota;

            public string CveEquipo
            {
                get { return cveequipo; }
                set { cveequipo = value; }
            }

            public int Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }

            public string CveProducto
            {
                get { return cveproducto; }
                set { cveproducto = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string Clave
            {
                get { return clave; }
                set { clave = value; }
            }

            public float PrecioUnitario
            {
                get { return preciounitario; }
                set { preciounitario = value; }
            }

            public string NumeroDeSerie
            {
                get { return numerodeserie; }
                set { numerodeserie = value; }
            }

            public float Flete
            {
                get { return flete; }
                set { flete = value; }
            }

            public double Iva
            {
                get { return iva; }
                set { iva = value; }
            }

            public float Subtotal
            {
                get { return subtotal; }
                set { subtotal = value; }
            }

            public float Descuento
            {
                get { return descuento; }
                set { descuento = value; }
            }

            public float PrecioTotal
            {
                get { return preciototal; }
                set { preciototal = value; }
            }

            public bool Actualizar
            {
                get { return actualizar; }
                set { actualizar = value; }
            }
            public int CveNota
            {
                get { return intcvenota; }
                set { intcvenota = value; }
            }
            public ProductoDevolucion()
            {
            }

            public ProductoDevolucion(string strconexionO)
            {
                strconexionC = strconexionO;
            }

            public int ActualizarExistencia(int option)
            {
                int actualizo = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    switch (option)
                    {
                        case 1:
                            //Aumentamos la cantidad del producto
                            string queryExistenciaActual = "SELECT Existencia FROM Productos WHERE CveProducto=" + cveproducto;
                            SqlCommand cmd = new SqlCommand(queryExistenciaActual, con);
                            SqlDataReader reader = cmd.ExecuteReader();
                            try
                            {
                                reader.Read();
                                double Existencia = reader.GetInt16(reader.GetOrdinal("Existencia"));
                                reader.Close();

                                Existencia += cantidad;

                                //Actualizamos la existencia del producto en el inventario
                                string updateExistencia = "UPDATE Productos SET Existencia=" + Existencia.ToString() + " WHERE CveProducto=" + cveproducto;
                                SqlCommand cmdU = new SqlCommand(updateExistencia, con);
                                actualizo = cmdU.ExecuteNonQuery();

                            }
                            catch
                            {
                                actualizo = 0;
                            }
                            break;

                        case 2:
                            //Disminuimos la cantidad del producto
                            string queryExistenciaActual2 = "SELECT Existencia FROM Productos WHERE CveProducto=" + cveproducto;
                            SqlCommand cmd2 = new SqlCommand(queryExistenciaActual2, con);
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            try
                            {
                                reader2.Read();
                                double Existencia = reader2.GetInt16(reader2.GetOrdinal("Existencia"));
                                reader2.Close();

                                Existencia -= cantidad;

                                //Actualizamos la existencia del producto en el inventario
                                string updateExistencia2 = "UPDATE Productos SET Existencia=" + Existencia.ToString() + " WHERE CveProducto=" + cveproducto;
                                SqlCommand cmdU2 = new SqlCommand(updateExistencia2, con);
                                actualizo = cmdU2.ExecuteNonQuery();

                            }
                            catch
                            {
                                actualizo = 0;
                            }
                            break;
                    }

                    con.Close();
                }
                return actualizo;
            }
        }

        public class ProductoAjuste
        {
            private double cantidad;
            private string cveproducto;
            private string nombre;
            private string clave;
            private double preciounitario;
            private string numerodeserie;
            private double preciototal;
            private string strconexionC;

            public double Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }

            public string CveProducto
            {
                get { return cveproducto; }
                set { cveproducto = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string Clave
            {
                get { return clave; }
                set { clave = value; }
            }

            private string strCveColor;
            public string CveColor
            {
                get
                {
                    return strCveColor;
                }
                set
                {
                    strCveColor = value;
                }
            }

            private string strCveAlmacenOrigen;
            public string CveAlmacenOrigen
            {
                get
                {
                    return strCveAlmacenOrigen;
                }
                set
                {
                    strCveAlmacenOrigen = value;
                }
            }
            private string strCveAlmacenDestino;
            public string CveAlmacenDestino
            {
                get
                {
                    return strCveAlmacenDestino;
                }
                set
                {
                    strCveAlmacenDestino = value;
                }
            }
            private string strAlmacenOrigen;

            public string AlmacenOrigen
            {
                get { return strAlmacenOrigen; }
                set { strAlmacenOrigen = value; }
            }
            private string strAlmacenDestino;

            public string AlmacenDestino
            {
                get { return strAlmacenDestino; }
                set { strAlmacenDestino = value; }
            }


            public double PrecioUnitario
            {
                get { return preciounitario; }
                set { preciounitario = value; }
            }

            public string NumeroDeSerie
            {
                get { return numerodeserie; }
                set { numerodeserie = value; }
            }

            public double PrecioTotal
            {
                get { return preciototal; }
                set { preciototal = value; }
            }

            public ProductoAjuste()
            {
            }

            public ProductoAjuste(string strconexionO)
            {
                strconexionC = strconexionO;
            }

            public int ActualizarExistencia(int option)
            {
                int actualizo = 0;
                using (SqlConnection con = new SqlConnection(strconexionC))
                {
                    con.Open();
                    switch (option)
                    {
                        case 1:
                            //Aumentamos la cantidad del producto
                            string queryExistenciaActual = "SELECT Existencia FROM Productos WHERE CveProducto=" + cveproducto;
                            SqlCommand cmd = new SqlCommand(queryExistenciaActual, con);
                            SqlDataReader reader = cmd.ExecuteReader();
                            try
                            {
                                reader.Read();
                                double Existencia = reader.GetInt16(reader.GetOrdinal("Existencia"));
                                reader.Close();

                                Existencia += cantidad;

                                //Actualizamos la existencia del producto en el inventario
                                string updateExistencia = "UPDATE Productos SET Existencia=" + Existencia.ToString() + " WHERE CveProducto=" + cveproducto;
                                SqlCommand cmdU = new SqlCommand(updateExistencia, con);
                                actualizo = cmdU.ExecuteNonQuery();

                            }
                            catch
                            {
                                actualizo = 0;
                            }
                            break;

                        case 2:
                            //Disminuimos la cantidad del producto
                            string queryExistenciaActual2 = "SELECT Existencia FROM Productos WHERE CveProducto=" + cveproducto;
                            SqlCommand cmd2 = new SqlCommand(queryExistenciaActual2, con);
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            try
                            {
                                reader2.Read();
                                double Existencia = reader2.GetInt16(reader2.GetOrdinal("Existencia"));
                                reader2.Close();

                                Existencia -= cantidad;

                                //Actualizamos la existencia del producto en el inventario
                                string updateExistencia2 = "UPDATE Productos SET Existencia=" + Existencia.ToString() + " WHERE CveProducto=" + cveproducto;
                                SqlCommand cmdU2 = new SqlCommand(updateExistencia2, con);
                                actualizo = cmdU2.ExecuteNonQuery();

                            }
                            catch
                            {
                                actualizo = 0;
                            }
                            break;
                    }

                    con.Close();
                }
                return actualizo;
            }
        }

        public class Equipo
        {
            private string cveequipo;
            private string descripcion;
            private string marca;
            private string abreviacionmarca;
            private string numeroserie;
            private string problema;
            private string observaciones;

            public string CveEquipo
            {
                get { return cveequipo; }
                set { cveequipo = value; }
            }

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            public string AbreviacionMarca
            {
                get { return abreviacionmarca; }
                set { abreviacionmarca = value; }
            }

            public string Marca
            {
                get { return marca; }
                set { marca = value; }
            }

            public string NumeroSerie
            {
                get { return numeroserie; }
                set { numeroserie = value; }
            }

            public string Problema
            {
                get { return problema; }
                set { problema = value; }
            }

            public string Observaciones
            {
                get { return observaciones; }
                set { observaciones = value; }
            }
        }

        public class Seguimiento
        {
            private string cveseguimiento;
            private string cveequipo;
            private string descripcion;
            private string numeroserie;
            private string fecha;
            private string seguimientotexto;
            private string actualizo;

            public string CveSeguimiento
            {
                get { return cveseguimiento; }
                set { cveseguimiento = value; }
            }

            public string CveEquipo
            {
                get { return cveequipo; }
                set { cveequipo = value; }
            }

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            public string NumeroSerie
            {
                get { return numeroserie; }
                set { numeroserie = value; }
            }

            public string Fecha
            {
                get { return fecha; }
                set { fecha = value; }
            }

            public string SeguimientoTexto
            {
                get { return seguimientotexto; }
                set { seguimientotexto = value; }
            }

            public string Actualizo
            {
                get { return actualizo; }
                set { actualizo = value; }
            }
        }

        public int GetMaxValue(string CveField, string Table)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {

                string queryField = "SELECT MAX(" + CveField + ") AS Maximo FROM " + Table;
                con.Open();
                SqlCommand cmdField = new SqlCommand(queryField, con);
                SqlDataReader readerField = cmdField.ExecuteReader();
                int Field = 0;
                string field = "0";
                if (readerField.HasRows)
                {
                    readerField.Read();
                    field = readerField["Maximo"].ToString();
                }

                readerField.Close();
                con.Close();

                if (field != "")
                    Field = Int16.Parse(field);

                return Field;
            }
        }

        public double TotalPrecioKit(ArrayList listProductos)
        {
            double TotalCostoKit = 0;
            foreach (ProductoKit Producto in listProductos)
            {
                TotalCostoKit += (Producto.Cantidad * Producto.PrecioUnitario);
            }

            return TotalCostoKit;
        }

        public string CheckTextBoxNull(string TextValue, string TextNull, int option)
        {
            string Campo = TextNull;
            switch(option)
            {
                case 1:
                    if(IsNumeric(TextValue))
                        Campo = double.Parse(TextValue, System.Globalization.NumberStyles.Currency).ToString();
                    break;
                case 2:
                    if (TextValue != "")
                        Campo = "'" + TextValue + "'";
                    break;
                case 3:
                    if (TextValue != "(   )   -")
                        Campo = "'" + TextValue + "'";
                    break;
            }

            return Campo;
        }


        public string ObtenerPrecio_Venta(string PrecioUltimoCosto, double IVA , string UtilidadPrecio)
        {
            double PrecioCosto = double.Parse(PrecioUltimoCosto, System.Globalization.NumberStyles.Currency);
            string StrPUtilidad = UtilidadPrecio.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol,"");
            double PUtilidad = double.Parse(StrPUtilidad) / 100;
            double PrecioFlete = 0;

            double PrecioVenta = 0;
            if (IsNumeric(PrecioCosto))
            {
                //PrecioFlete = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
                PrecioVenta = (PrecioCosto * (1 + PUtilidad)) * (1 + IVA);
            }
            //PrecioUltimaCompra += PrecioFlete;

            return String.Format("{0:C}", Math.Ceiling(PrecioVenta));
        }
        public string ObtenerUtilidad_Neta(string PrecioVentaSugerido, double IVA, string PrecioUltimoCoso)
        {
            double PrecioCosto = double.Parse(PrecioUltimoCoso, System.Globalization.NumberStyles.Currency);
            double PrecioVenta = double.Parse(PrecioVentaSugerido, System.Globalization.NumberStyles.Currency);
            double PrecioFlete = 0, UtilidadNeta=0;

            if (IsNumeric(PrecioVenta) && IsNumeric(PrecioCosto))
            {
                //PrecioFlete = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
                UtilidadNeta=((PrecioVenta / (1+ IVA)) - PrecioCosto)/ PrecioCosto;
            }
            //PrecioUltimaCompra += PrecioFlete;

            return String.Format("{0:P}", Math.Round(UtilidadNeta,4));
        }
        public double ValorIva(int ClaveValor)
        {
            string Valor = GetStrFieldQuery("Iva", "Select Iva From CatIva Where CveIva= " + ClaveValor);

            return double.Parse(Valor);

        }
        public string ObtenerPrecioUtilidad(string UltimaCompra, string Flete, string UtilidadPrecio)
        {
            double PrecioUltimaCompra = double.Parse(UltimaCompra, System.Globalization.NumberStyles.Currency);
            double PrecioFlete = 0;
            if (IsNumeric(Flete))
            {
                PrecioFlete = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
            }
            PrecioUltimaCompra += PrecioFlete;

            return String.Format("{0:C}", (PrecioUltimaCompra + (double.Parse(CheckTextBoxNull(UtilidadPrecio, "0", 1)))));
        }
        public string ObtenerUtilidad(string UltimaCompra, string Precio)
        {
            double PrecioUltimaCompra = double.Parse(UltimaCompra, System.Globalization.NumberStyles.Currency);
            double Precio1 = double.Parse(Precio, System.Globalization.NumberStyles.Currency);

            return String.Format("{0:C}", (Precio1 - PrecioUltimaCompra));// (double.Parse(CheckTextBoxNull(Precio1, "0", 1)))));
        }
        public string ObtenerPrecioUnitario(string CantidadCompra, string SubTotalCompra, string Flete, string TotalCompra)
        {
            double SubTotal = double.Parse(SubTotalCompra, System.Globalization.NumberStyles.Currency);
            double Cantidad = double.Parse(CantidadCompra, System.Globalization.NumberStyles.Currency);
            double Total = double.Parse(TotalCompra, System.Globalization.NumberStyles.Currency);
            double Flete2 = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
            double PrecioFlete = 0;

            double PrecioUnitario=0;

            if (IsNumeric(Flete))
            {
                PrecioFlete = (SubTotal * Flete2) / Total;
                PrecioUnitario = (SubTotal + PrecioFlete) / Cantidad;
                //PrecioFlete = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
            }
            
            return String.Format("{0:C}", PrecioUnitario);
        }
        public string ObtenerFlete(string SubTotalCompra, string Flete, string TotalCompra)
        {
            double SubTotal = double.Parse(SubTotalCompra, System.Globalization.NumberStyles.Currency);
            
            double Total = double.Parse(TotalCompra, System.Globalization.NumberStyles.Currency);
            double Flete2 = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
            double PrecioFlete = 0;

            double PrecioUnitario = 0;

            if (IsNumeric(Flete))
            {
                PrecioFlete = (SubTotal * Flete2) / Total;
                //PrecioUnitario = (SubTotal + PrecioFlete) / Cantidad;
                //PrecioFlete = double.Parse(Flete, System.Globalization.NumberStyles.Currency);
            }

            return String.Format("{0:C}", PrecioFlete);
        }

        public void ComboBoxProductos(ComboBox cboxProducto)
        {
            // Cargamos el combo box de productos
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                string query = "SELECT CveProducto, Concat(P.Nombre,' ', CM.Nombre,' ',P.Modelo) AS Producto FROM Productos P, CatMarcas CM WHERE P.AbreviacionMarca=CM.Abreviacion ORDER BY Producto";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet productos = new DataSet();
                adapter.Fill(productos, "Productos");

                cboxProducto.DataSource = productos.Tables["Productos"];
                cboxProducto.ValueMember = "CveProducto";
                cboxProducto.DisplayMember = "Producto";
                ListHadBeenAdded = true;
                con.Close();
            }
        }

        public string GetNextFolio(string CveField, string Table)
        {
            string Folio = "1";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                string queryfolioactual = "SELECT MAX(" + CveField + ")+1 AS FolioActual FROM " + Table;
                SqlCommand cmdfolio = new SqlCommand(queryfolioactual, con);
                SqlDataReader readerfolio = cmdfolio.ExecuteReader();
                if (readerfolio.HasRows)
                {
                    readerfolio.Read();
                    Folio = readerfolio["FolioActual"].ToString();
                }

                readerfolio.Close();
                con.Close();
            }
            if (Folio == "") Folio = "1";
            return Folio;
        }

        public string FormatCurrency(string Currency)
        {
            string FormatCurrency = "";

            if (IsNumeric(Currency))
            {
                FormatCurrency = String.Format("{0:C}", double.Parse(Currency, System.Globalization.NumberStyles.Currency));
            }
            return FormatCurrency;
        }
        
       

        public void colorDataGrid(DataGridView dataGrid)
        {
            if (dataGrid.RowCount > 0)
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        //dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(113, 201, 206);
                        dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(251, 220, 184);
                    }
                }
                dataGrid.Refresh();
            }
        }

        public void colorDataGrid(DataGridView dataGrid, Color color)
        {
            if (dataGrid.RowCount > 0)
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        dataGrid.Rows[i].DefaultCellStyle.BackColor = color;
                    }
                }
                dataGrid.Refresh();
            }
        }

        public int PrecioPredeterminado()
        {
            int indice = GetIntField("CvePrecio", "CatPrecios", "Predeterminado", "1");
            //indice;
            return indice;
        }

        public int AceptarCredito(string CveCliente)
        {
            int Credito = 0;
            float LimiteCredito = GetFloatField("LimiteCredito", "ClientesCredito", "CveCliente", CveCliente);

            if (LimiteCredito > 0)
            {
                Credito = 1;
            }

            return Credito;
        }
        public double LimiteCredito(string CveCliente)
        {
            double Credito = 0;
            float LimiteCredito = GetFloatField("LimiteCredito", "ClientesCredito", "CveCliente", CveCliente);


            return Credito=double.Parse(LimiteCredito.ToString());
        }
        public double SaldoCliente(string CveCliente)
        {
            double SaldoCliente = 0;
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                string query = "SELECT CxC.CveCliente, SUM(Saldo) AS Saldo FROM CuentasPorCobrar CxC WHERE CxC.CveCliente=" + CveCliente + " GROUP BY 1";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    SaldoCliente = reader.GetDouble(reader.GetOrdinal("Saldo"));
                }
                reader.Close();
                con.Close();
            }
            return SaldoCliente;
        }

        public bool SendMail(string emailFrom, string emailTo, string subjet, string body, string smtpServer, string Password)
        {
            bool ret = false;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(emailFrom);
            msg.To.Add(new MailAddress(emailTo));
            msg.IsBodyHtml = true;
            msg.Subject = subjet;
            msg.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpServer;
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential(emailFrom, Password);

            try
            {
                smtp.Send(msg);
                ret = true;
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }
                
        public void checkAccess(Form Formulario)
        {
            DialogResult result;
            result = MessageBox.Show("Usted no está autorizado para acceder a este modulo, ¿Desea ingresar una clave de acceso?", "Error Ingreso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                /*FormIngresarClave IngresarClave = new FormIngresarClave();
                IngresarClave.Formulario = Formulario;
                IngresarClave.Show();*/
            }
        }
        public double ImportePagado(ArrayList Lista)
        {
            double Importe = 0, ImportePagado=0;
            foreach (FormasPago item in Lista)
            {
                if (item.CveFormaPago == 3)
                {
                    Importe += item.MonedaNacional;
                    ImportePagado += item.ImportePagado;
                }
                else
                {
                    Importe += item.TotalPagado;
                    ImportePagado += item.ImportePagado;
                }
            }
            return ImportePagado;
        }
        public double ImportePagadoNegocio(ArrayList Lista)
        {
            double Importe = 0, ImportePagado = 0;
            foreach (FormasPago item in Lista)
            {
                if (item.CveFormaPago == 3)
                {
                    Importe += item.MonedaNacional;
                    ImportePagado += item.ImportePagado;
                }
                else
                {
                    Importe += item.TotalPagado;
                    ImportePagado += item.ImportePagado;
                }
            }
            return ImportePagado;
        }
        public double ImporteRealizado(ArrayList Lista)
        {
            double Importe = 0, ImportePagado = 0;
            foreach (FormasPago item in Lista)
            {
                if (item.CveFormaPago == 3)
                {
                    Importe += item.MonedaNacional;
                   
                }
                else
                {
                    Importe += item.TotalPagado;
                   
                }
            }
            return Importe;
        }
        private void PageBase_Load(object sender, EventArgs e)
        {

        }
        public void GenerarExcel(string Query, string tabla)
        {
            //string Query = "SELECT CONCAT(S.Nombre, ' ', S.Paterno,' ', S.Materno) AS NombreCompleto, CM.NoContratoCredito, LEFT(S.RFC,10) AS RFC, S.CveSocia AS NoCliente, S.Nombre, S.Paterno, S.Materno, S.CURP, 'FISICA' AS TipoPersona, 'PD1' AS TipoProducto, 'PERSONA FISICA' AS FiguraJuridica, IF(S.CveSexo=1,'HOMBRE','MUJER') AS Sexo, CE.Nombre AS EstadoNacimiento, DATE_FORMAT(S.FechaNac,'%d/%m/%Y') As FechaNacimiento, CE.Nombre AS Estado, CMU.Nombre AS Municipio, CC.Nombre AS Colonia, S.TelefonoCasa, S.TelefonoMovil, ' 'AS CorreoElectronico, S.Direccion, CD.Disposicion, S.RFC, CM.CveCredito, 'SIMPLE' AS TipoCredito, 'SERVICIOS' AS SubRama, 'TRANSPORTE' AS Producto, 'DIVERSOS' AS Destino, 'UNIDADES' AS TipoUnidad, 1 AS UnidadesHabilitar, 'No Aplica' AS CicloAgricola, 'No Aplica' AS RiegoAgricola, Date_Format(CM.FechaInicio,'%d/%m/%Y') as FechaInicio, date_format(CM.FechaTermino,'%d/%m/%Y') As FechaTermino, CM.Importe, CM.Importe + (CM.Importe * .25) AS MontoProyectado, CM.Importe AS MontoOtorgado, 1 AS NumeroPagare, CM.Importe AS MontoPagare, CPZ.Descripcion AS Perioricidad, 'PESOS' AS TipoMoneda, 'VIGENTE' AS EstatusCredito, 0 AS DiasAtraso, CM.Importe AS CapitalVigente, CM.Interes AS InteresesVigentes, 0 AS CapitalVencido, 0 AS InteresesVencidos, CM.Importe AS SaldoTotal, '" + dtFechaInicio.Value.ToShortDateString() + "' AS FechaSaldo, 'FIJA' AS TipoTasa  FROM CreditosMujeres CM  JOIN Grupos G ON CM.CveGrupo=G.CveGrupo JOIN SociasGrupo SG ON G.CveGrupo=SG.CveGrupo JOIN Socias S ON SG.CveSocia=S.CveSocia JOIN CatEstados CE ON S.CveEstado=CE.CveEstados JOIN CatMunicipios CMU ON S.CveMunicipio=CMU.CveMunicipios JOIN CatColonia CC ON S.CveColonia=CC.CveColonia JOIN CreditoDisposicion CD ON CM.CveDisposicion=CD.CveDisposicion JOIN CatPlazos CPZ ON  CM.CvePlazos=CPZ.CvePlazo  WHERE CM.CveEstatus=3 AND CM.FechaInicio>='" + SwitchDate(dtFechaInicio.Value.ToShortDateString(), 1) + "' ORDER BY S.Nombre, S.Paterno, S.Materno;";
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter(Query, con);
                DataSet ODsEsquema = new DataSet();

                Adapter.Fill(ODsEsquema, tabla);

                //LblMensaje.Text = "";

                try
                {
                    SaveFileDialog Archivo = new SaveFileDialog();
                    Archivo.FileName = tabla;
                    Archivo.DefaultExt = "xls";
                    Archivo.Filter = "Archivo Excel (*.xls)|*.xls";

                    DialogResult Result = Archivo.ShowDialog();

                    if (Result == DialogResult.OK)
                    {
                        string Ruta = Archivo.FileName;
                        DataTable dtTablaEsquema = ODsEsquema.Tables[tabla].Copy();
                        RKLib.ExportData.Export Exporta = new RKLib.ExportData.Export("Win");
                        Exporta.ExportDetails(dtTablaEsquema, Export.ExportFormat.Excel, Ruta);

                        MessageBox.Show("Se ha exportado los datos con exito a " + Ruta);
                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                con.Close();
            }
        }

      
        public string MD5_cod(string Value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        public class TotalesFac
        {
            private int intConsecutivo;

            public int Consecutivo
            {
                get { return intConsecutivo; }
                set { intConsecutivo = value; }
            }

            private int intCveRetencion;

            public int CveRetencion
            {
                get { return intCveRetencion; }
                set { intCveRetencion = value; }
            }

            private int intCveTipo;

            public int CveTipo
            {
                get { return intCveTipo; }
                set { intCveTipo = value; }
            }
            private string strEtiqueta;

            public string Etiqueta
            {
                get { return strEtiqueta; }
                set { strEtiqueta = value; }
            }
            private double dblImporte;

            public double Importe
            {
                get { return dblImporte; }
                set { dblImporte = value; }
            }

        }

        public class ImpuestoRetencion
        {
            private int intCveRetencion;

            public int CveRetencion
            {
                get { return intCveRetencion; }
                set { intCveRetencion = value; }
            }

            private string strDescripcion;

            public string Descripcion
            {
                get { return strDescripcion; }
                set { strDescripcion = value; }
            }

            private double dblImporte;

            public double Importe
            {
                get { return dblImporte; }
                set { dblImporte = value; }
            }
            private double blPorcentaje;

            public double Porcentaje
            {
                get { return blPorcentaje; }
                set { blPorcentaje = value; }
            }
        }


        public bool ActualizarExistencia(int CveProducto, double Existencias, double Costo, string strDescripcionAjuste, int CveAlmacen, int CveOrigen)
        {
            bool actualizar = false;

            string InsertAjuste = "INSERT INTO AjustesInventario (CveAjuste, Fecha, CveTipoAjuste, Importe, Observaciones, CveUser) VALUES(";
            InsertAjuste += "0,'" + SwitchDate(DateTime.Now.ToShortDateString(), 1) + "',1," + double.Parse("0.00", System.Globalization.NumberStyles.Currency).ToString() + ",'"  + strDescripcionAjuste + "'," + CveUser.Cve_User + ")";

            int inserted = performinsertquery(InsertAjuste);

            if (inserted > 0)
            {

                if (CveProducto > 0)
                {


                    if (Existencias > 0)
                    {

                        double Total = Existencias * Costo;

                        string InsertDetalleAjuste = "INSERT INTO AjustesInventarioDetalle (CveAjuste, CveProducto, CveColor, CveAlmacen, Cantidad, CostoUnitario, Total) VALUES (";
                        InsertDetalleAjuste += inserted.ToString() + "," + CveProducto + ",0," + CveAlmacen + "," + Existencias + "," + Costo + "," + Total + ")";
                        int inserted2 = performinsertquery(InsertDetalleAjuste, 1);

                        string QueryUpdteColor = "";




                        string CantidadInventario = GetStrFieldQuery("Cantidad", "Select Cantidad From ProductoColor Where CveProducto=" + CveProducto + " And CveAlmacen=" + CveAlmacen);

                        string QueryInsertMov = "Insert Into MovimientosInventario(CveMovimiento,CveTipoMovimiento,CveProducto,Habia,Cantidad,CveUser,Hora,Fecha, CveAlmacen, CveOrigen) Values(0,4," + CveProducto + "," + CantidadInventario + "," + Existencias + "," + CveUser.Cve_User + ",'" + DateTime.Now.ToShortTimeString() + "','" + SwitchDate(DateTime.Now.ToShortDateString(), 1) + "'," + CveAlmacen + "," + CveOrigen + ")";
                        performinsertquery(QueryInsertMov);

                        QueryUpdteColor = "Update ProductoColor Set Cantidad=Cantidad + " + Existencias + " Where CveProducto=" + CveProducto + " And CveAlmacen=" + CveAlmacen;

                        performupdatequery(QueryUpdteColor);

                        actualizar = true;

                    }

                }

                
            }

            return actualizar;

        }


        public void EnviarCorreo(int cvefactura,  int Cveestatus, int cvereceptor, string NombreReceptor)
        {
            if (cvefactura > 0)
            {
               
                if (Cveestatus != 1)
                {
                    try
                    {

                        DialogResult result;
                        result = MessageBox.Show("¿Desea enviar la Factura Electronica en este momento?, Pesione [SI] y espere un instante mientras se envia el correo, Presione [NO] para cancelar el envio", "Envio de Factura Electronica CFDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {


                            string PDF = GetStrFieldQuery("PDF", "Select PDF From Facturas Where CveFactura=" + cvefactura);
                            string XML = GetStrFieldQuery("xml", "Select xml From Facturas Where CveFactura=" + cvefactura);
                            string CorreoTo = GetStrFieldQuery("CorreoElectronico", "Select CorreoElectronico From Receptores Where CveReceptor=" + cvereceptor);
                            string CorreoFrom = GetStrFieldQuery("CuentaCorreo", "Select CuentaCorreo From CatEmpresa Where CveEmpresa=1");

                            string Destinoxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\timbrados\";

                            Correos Cr = new Correos();
                            MailMessage mnsj = new MailMessage();

                            mnsj.Subject = "Factura Electronica CFDI";

                            mnsj.To.Add(new MailAddress(CorreoTo));

                            mnsj.From = new MailAddress(CorreoFrom, NombreReceptor);

                            /* Si deseamos Adjuntar algún archivo*/
                            mnsj.Attachments.Add(new Attachment(Destinoxml + PDF));

                            mnsj.Attachments.Add(new Attachment(Destinoxml + XML));

                            mnsj.Body = "  Envio automatico de factura electronica a buzon de correo proporcionado \n\n *VER ARCHIVOS ADJUNTOS EN FORMATO PDF Y XML*";

                            /* Enviar */
                            Cr.MandarCorreo(mnsj);


                            MessageBox.Show("La factura electronica se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("La Factura aun no ha sido Timbrado por el SAT, favor de Timbrar antes de enviarla por correo electronico", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private DataTable tablaCliente;

        public DataTable TablaCliente
        {
            get { return tablaCliente; }
            set { tablaCliente = value; }
        }

        private string errCliente;

        public string ErrCliente
        {
            get { return errCliente; }
            set { errCliente = value; }
        }

       

        public bool LeerTablaClienteA(string NombreStoreProcedure)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Strconexion))
                {
                    con.Open();

                    using (SqlCommand cmdCliente = new SqlCommand())
                    {
                        cmdCliente.Connection = con;
                        cmdCliente.CommandText = NombreStoreProcedure;
                        cmdCliente.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter daCliente = new SqlDataAdapter(cmdCliente))
                        {
                            tablaCliente = new DataTable();
                            daCliente.Fill(tablaCliente);
                        }
                    }

                    return true;
                }
            }
            catch (SqlException ex)
            {
                errCliente = ex.Message;

                return false;
            }
        }
        public bool LeerTablaClientePametro(string NombreStoreProcedure, Clases.ParametroCliente[] Datos)
        {
            try
            {
              
                using (SqlConnection con = new SqlConnection(Strconexion))
                {
                    con.Open();

                    using (SqlCommand cmdCliente = new SqlCommand())
                    {
                        cmdCliente.Connection = con;
                        cmdCliente.CommandText = NombreStoreProcedure;
                        cmdCliente.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < Datos.Length; i++)
                        {
                            cmdCliente.Parameters.AddWithValue(Datos[i].Cve, Datos[i].CveValor);
                        }


                        using (SqlDataAdapter daCliente = new SqlDataAdapter(cmdCliente))
                        {
                            tablaCliente = new DataTable();
                            daCliente.Fill(tablaCliente);
                        }
                    }

                    return true;

                }
            }
            catch (SqlException ex)
            {
                errCliente = ex.Message;

                return false;
            }
        }


        public DataTable LlenarTablaSinParametro(int option)
        {
            DataTable Tabla =new DataTable();

            Clases.Clientes C = new Clases.Clientes();

            if (C.LeerAlmacen())
            {
                Tabla=C.TablaCliente;
            }
            else
            {
                MessageBox.Show(C.ErrCliente);
            }
            return Tabla;

        }

        public DataGridView LlenarGridA(string Busqueda, int OpcionBusqueda, DataGridView datagrid, int option, string CveAlmacen)
        {

            Clases.Clientes C;

            switch(option)
            {
                case 1:
                    C = new Clases.Clientes(Busqueda, OpcionBusqueda,CveAlmacen);
                    if (C.LeerProductoA())
                    {
                        datagrid.DataSource = C.TablaCliente;
                    }
                    else
                    {
                        MessageBox.Show(C.ErrCliente);
                    }
                    break;
                case 2:
                    C= new Clases.Clientes();
                    if (C.LeerAlmacen())
                    {
                        datagrid.DataSource = C.TablaCliente;
                    }
                    else
                    {
                        MessageBox.Show(C.ErrCliente);
                    }
                    break;
                case 3:

                    break;
                case 4:

                    break;
            }


            

            return datagrid;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        public void InsertaVentaAbierta(ArrayList ListaVenta, int CveVentaTempB, int opcion)
        {
            if (ListaVenta.Count > 0 || opcion == 1)
            {
                string QueryDelete = "Delete From VentaAbiertaDetalle Where CveVentaTemp=" + CveVentaTempB;
                performupdatequery(QueryDelete);
                foreach (ProductoCompra item in ListaVenta)
                {

                    string QueryInsert = "Insert Into VentaAbiertaDetalle(CveVentaDetalle,CveVentaTemp,CveProducto,Cantidad,Nombre, Clave,";
                    QueryInsert += "CvePrecio, PrecioUnitarioOriginal, PrecioUnitario,SubTotal, Descuento, Adicional, PrecioTotal, PDescuento, CveColor,CveAlmacen,CveNotaReferencia2, CveVendedor,NombreVendedor)";
                    QueryInsert += " Values(0," + CveVentaTempB + "," + item.CveProducto + "," + item.Cantidad + ",'" + item.Nombre + "','" + item.Clave + "',";
                    QueryInsert += item.CvePrecio + "," + item.PrecioUnitarioOriginal + "," + item.PrecioUnitario + "," + item.Subtotal + "," + item.Descuento + "," + item.Adicional + "," + item.PrecioTotal + "," + item.PDescuento + ",";
                    QueryInsert += item.CveColor + "," + item.CveAlmacen + "," + item.CveNotaReferencia2 + "," + item.CveEmpleado + ",'" + item.NombreEmpleado + "')";

                    performinsertquery(QueryInsert);

                }

            }
            else
            {
                string QueryLista = "SELECT VAD.CveVentaDetalle,Va.CveVentaTemp, CveCliente, FechaVenta, CveProducto, Cantidad, Nombre, Clave, CvePrecio, PrecioUnitarioOriginal, PrecioUnitario, SubTotal, VAD.Descuento, Adicional,  PrecioTotal, PDescuento, CveColor, CveAlmacen, CveNotaReferencia2, VAD.CveVendedor, NombreVendedor FROM VentaAbierta VA JOIN VentaAbiertaDetalle VAD ON VA.CveVentaTemp=VAD.CveVentaTemp WHERE VA.CveVentaTemp=" + CveVentaTempB;
                using (SqlConnection con = new SqlConnection(Strconexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QueryLista, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductoCompra Producto = new ProductoCompra(Strconexion);
                        Producto.Cantidad = double.Parse(reader["Cantidad"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.CveProducto = reader["CveProducto"].ToString();
                        Producto.Nombre = reader["Nombre"].ToString();
                        Producto.Clave = reader["Clave"].ToString();
                        Producto.CvePrecio = int.Parse(reader["CvePrecio"].ToString());
                        Producto.PrecioUnitarioOriginal = double.Parse(reader["PrecioUnitarioOriginal"].ToString());
                        Producto.PrecioUnitario = double.Parse(reader["PrecioUnitario"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.Adicional = double.Parse(reader["Adicional"].ToString());
                        Producto.Subtotal = Producto.PrecioUnitario * Producto.Cantidad;
                        Producto.Descuento = float.Parse(CheckTextBoxNull(reader["Descuento"].ToString(), "0", 1));
                        // Producto.Iva = (Producto.Subtotal - Producto.Descuento) - ((Producto.Subtotal - Producto.Descuento) / (1 + double.Parse(IvaF.ToString())));
                        //Producto.Subtotal = ((Producto.Subtotal - Producto.Descuento) / (1 + float.Parse(IvaF.ToString())));
                        Producto.PrecioTotal = Producto.Subtotal - Producto.Descuento; //+(float)Producto.Iva;
                        Producto.PDescuento = float.Parse(reader["PDescuento"].ToString());
                        Producto.CveColor = int.Parse(reader["CveColor"].ToString());
                        Producto.CveAlmacen = int.Parse(reader["CveAlmacen"].ToString());
                        Producto.CveNotaReferencia2 = int.Parse(reader["CveNotaReferencia2"].ToString());
                        Producto.CveEmpleado = int.Parse(reader["CveVendedor"].ToString());
                        Producto.NombreEmpleado = reader["NombreVendedor"].ToString();
                        ListaVenta.Add(Producto);

                    }
                    reader.Close();
                    reader.Dispose();
                    con.Close();
                    con.Dispose();

                }

            }


        }

        public void UpdateVentaTemp(int CveCliente, int CveVentaAbierta, int CveNoVentaTemp, string CveFormaPago, string CveVendedor, string CveFormaEntrega, string Observaciones, string strconexionLocal, int CveCaja, string NombreCliente, string Direccion, string Colonia, string Poblacion)
        {
            int CveSucursal = 1;// int.Parse(GetStrFieldQuery("CveSucursal", "Select CveSucursal From CatCajas Where CveCaja=" + CveCaja));

            /*string QueryInsertVenta = "Insert into VentaAbierta(CveVentaTemp, CveCliente, FechaVenta,CveVendedor, CveSucursal) Values(0," + CveCliente + ",'";
            QueryInsertVenta += SwitchDate(DateTime.Now.ToShortDateString(), 2) + "',1," + CveSucursal + ")";

            */

            string QueryInsertVenta = "Update VentaAbierta Set CveCliente=" + CveCliente + ", CveVendedor=" + CveVendedor + ", CveFormaPago=" + CveFormaPago + ", CveFormaEntrega=" + CveFormaEntrega + ", CveSucursal=" + CveSucursal + ",Observaciones='" + Observaciones + "',NombreCliente='" + NombreCliente + "',Direccion='" + Direccion + "',Colonia='"+ Colonia + "',Poblacion='" + Poblacion + "'  Where CveVentaTemp=" + CveVentaAbierta;
            //QueryInsertVenta += SwitchDate(DateTime.Now.ToShortDateString(), 2) + "',1," + CveSucursal + ")";


            performinsertqueryCE(QueryInsertVenta, 1, strconexionLocal);

        }
        public void UpdateVentaTempRe(int CveVentaAbierta, int CveNoVentaTemp,  string strconexionLocal)
        {
            
            string QueryInsertVenta = "Update VentaAbierta Set CveNoVentaTemp=" + CveNoVentaTemp + " Where CveVentaTemp=" + CveVentaAbierta;
            
            performinsertqueryCE(QueryInsertVenta, 1, strconexionLocal);

        }
        public int NuevaVenta(int CveCliente,  int CveNoVentaTemp, string CveFormaPago, string CveFormaEntrega, string CveVendedor, string Observaciones, string strconexionLocal, int CveCaja, string NombreCliente, string Direccion, string Colonia, string Poblacion)
        {
            int CveSucursal = 1; //int.Parse(GetStrFieldQuery("CveSucursal", "Select CveSucursal From CatCajas Where CveCaja=" + CveCaja));

            string QueryInsertVenta = "Insert into VentaAbierta(CveCliente, CveNoVentaTemp, CveFormaPago, CveFormaEntrega, FechaVenta,CveVendedor, CveSucursal, Observaciones, NombreCliente, Direccion, Colonia, Poblacion) Values(" + CveCliente + ",";
            QueryInsertVenta += CveNoVentaTemp + "," + CveFormaPago + "," + CveFormaEntrega + ",'";
            QueryInsertVenta += SwitchDate(DateTime.Now.ToShortDateString(), 2) + "'," + CveVendedor + ","  + CveSucursal + ",'" + Observaciones + "','" + NombreCliente + "','" + Direccion + "','" + Colonia + "','" + Poblacion + "')";

            int valor = performinsertquery(QueryInsertVenta);

            return valor;
        }
        public void InsertaVentaAbierta(ArrayList ListaVenta, int CveVentaTempB, int opcion, string strconexion2)
        {
            if (ListaVenta.Count > 0 || opcion == 1)
            {
                string QueryDelete = "Delete From VentaAbiertaDetalle Where CveVentaTemp=" + CveVentaTempB;
                performupdatequery(QueryDelete,StrconexionLocalGlobal);
                foreach (ProductoCompra item in ListaVenta)
                {

                    if (item.Cantidad > 0)
                    {
                        string QueryInsert = "Insert Into VentaAbiertaDetalle(CveVentaTemp,CveProducto,Cantidad,Nombre, Clave,";
                        QueryInsert += "CvePrecio, PrecioUnitarioOriginal, PrecioUnitario,SubTotal, Descuento, Iva, SiIVa, PIva,  PrecioTotal, PDescuento,CveAlmacen, CveTipoP, Pendiente, Afectar)";
                        QueryInsert += " Values(" + CveVentaTempB + "," + item.CveProducto + "," + item.Cantidad + ",'" + item.Nombre + "','" + item.Clave + "',";
                        QueryInsert += item.CvePrecio + "," + item.PrecioUnitarioOriginal + "," + item.PrecioUnitario + "," + item.Subtotal + "," + item.Descuento + "," + item.Iva + "," + item.SIIVA + "," +  item.PIva + "," +  item.PrecioTotal + "," + item.PDescuento + ",";
                        QueryInsert += item.CveAlmacen + "," + item.IntCveTipoP + "," + item.DblPendiente + "," + item.DblAfectar + ")";

                        performinsertqueryCE(QueryInsert, 1, strconexion2);
                    }
                }

            }
            else
            {
                string QueryLista = "SELECT VAD.CveVentaDetalle,Va.CveVentaTemp, CveCliente, FechaVenta, CveProducto, Cantidad, Nombre, Clave, CvePrecio, PrecioUnitarioOriginal, PrecioUnitario, SubTotal, VAD.Descuento, Adicional, Iva, SiIva, PIva, PrecioTotal, PDescuento, CveColor, CveAlmacen, CveNotaReferencia2, VAD.CveVendedor, NombreVendedor, VAD.CveTipoP, VAD.Pendiente, VAD.Afectar FROM VentaAbierta VA JOIN VentaAbiertaDetalle VAD ON VA.CveVentaTemp=VAD.CveVentaTemp WHERE VA.CveVentaTemp=" + CveVentaTempB;
                using (SqlConnection con = new SqlConnection(strconexion2))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QueryLista, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductoCompra Producto = new ProductoCompra(Strconexion);
                        Producto.Cantidad = double.Parse(reader["Cantidad"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.CveProducto = reader["CveProducto"].ToString();
                        Producto.Nombre = reader["Nombre"].ToString();
                        Producto.Nombre2 = reader["Nombre"].ToString();
                        Producto.Clave = reader["Clave"].ToString();
                        Producto.CvePrecio = int.Parse(reader["CvePrecio"].ToString());
                        Producto.PrecioUnitarioOriginal = double.Parse(reader["PrecioUnitarioOriginal"].ToString());
                        Producto.PrecioUnitario = double.Parse(reader["PrecioUnitario"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.Adicional = double.Parse(reader["Adicional"].ToString());

                        Producto.PDescuento = float.Parse(reader["PDescuento"].ToString());
                        Producto.Descuento = ((Producto.PrecioUnitario * Producto.Cantidad)) * (Producto.PDescuento / 100);  //float.Parse(CheckTextBoxNull(reader["Descuento"].ToString(), "0", 1));
                        Producto.Subtotal = (Producto.PrecioUnitario * Producto.Cantidad) - Producto.Descuento ; 
                        
                        // Producto.Iva = (Producto.Subtotal - Producto.Descuento) - ((Producto.Subtotal - Producto.Descuento) / (1 + double.Parse(IvaF.ToString())));
                        //Producto.Subtotal = ((Producto.Subtotal - Producto.Descuento) / (1 + float.Parse(IvaF.ToString())));
                        
                        
                        Producto.SIIVA=int.Parse(reader["SiIva"].ToString());

                        if (Producto.SIIVA == 1)
                        {
                            Producto.PIva = double.Parse(reader["PIva"].ToString());
                            Producto.Iva = Producto.Subtotal * Producto.PIva;

                        }
                        else
                        {
                            Producto.Iva = 0;
                        }



                        Producto.PrecioTotal = Producto.Subtotal + Producto.Iva; //+(float)Producto.Iva;
                       
                        Producto.CveColor = int.Parse(reader["CveColor"].ToString());
                        Producto.CveAlmacen = int.Parse(reader["CveAlmacen"].ToString());
                        Producto.CveNotaReferencia2 = int.Parse(reader["CveNotaReferencia2"].ToString());
                        Producto.CveEmpleado = int.Parse(reader["CveVendedor"].ToString());
                        Producto.NombreEmpleado = reader["NombreVendedor"].ToString();
                        Producto.IntCveTipoP = int.Parse(reader["CveTipoP"].ToString());
                        Producto.DblPendiente = double.Parse(reader["Pendiente"].ToString());
                        Producto.DblAfectar = double.Parse(reader["Afectar"].ToString());
                        ListaVenta.Add(Producto);

                    }
                    reader.Close();
                    reader.Dispose();
                    con.Close();
                    con.Dispose();

                }

            }


        }
        public void InsertaVentaAbierta_Grid(ArrayList ListaVenta, int CveVentaTempB, int opcion, string strconexion2)
        {
            if (ListaVenta.Count > 0 || opcion == 1)
            {
               
                foreach (ProductoCompra item in ListaVenta)
                {

                    if (item.Cantidad > 0)
                    {
                        string QueryInsert = "Insert Into VentaAbiertaDetalle(CveVentaTemp,CveProducto,Cantidad,Nombre, Clave,";
                        QueryInsert += "CvePrecio, PrecioUnitarioOriginal, PrecioUnitario,SubTotal, Descuento, Iva, SiIva, PIva, PrecioTotal, PDescuento,CveAlmacen, CveTipoP, Pendiente, Afectar)";
                        QueryInsert += " Values(" + CveVentaTempB + "," + item.CveProducto + "," + item.Cantidad + ",'" + item.Nombre + "','" + item.Clave + "',";
                        QueryInsert += item.CvePrecio + "," + item.PrecioUnitarioOriginal + "," + item.PrecioUnitario + "," + item.Subtotal + "," + item.Descuento + "," + item.Iva + "," + item.SIIVA + "," + item.PIva + "," + item.PrecioTotal + "," + item.PDescuento + ",";
                        QueryInsert += item.CveAlmacen + "," + item.IntCveTipoP + "," + item.DblPendiente + "," + item.DblAfectar + ")";

                        performinsertqueryCE(QueryInsert, 1, strconexion2);
                    }
                }

            }
            else
            {
                string QueryLista = "SELECT VAD.CveVentaDetalle,Va.CveVentaTemp, CveCliente, FechaVenta, CveProducto, Cantidad, Nombre, Clave, CvePrecio, PrecioUnitarioOriginal, PrecioUnitario, SubTotal, VAD.Descuento, Adicional, Iva, SiIVA, PIva, PrecioTotal, PDescuento, CveColor, CveAlmacen, CveNotaReferencia2, VAD.CveVendedor, NombreVendedor, CveTipoP,VAD.Pendiente, VAD.Afectar FROM VentaAbierta VA JOIN VentaAbiertaDetalle VAD ON VA.CveVentaTemp=VAD.CveVentaTemp WHERE VA.CveVentaTemp=" + CveVentaTempB;
                using (SqlConnection con = new SqlConnection(strconexion2))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QueryLista, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductoCompra Producto = new ProductoCompra(Strconexion);
                        Producto.Cantidad = double.Parse(reader["Cantidad"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.CveProducto = reader["CveProducto"].ToString();
                        Producto.Nombre = reader["Nombre"].ToString();
                        Producto.Nombre2 = reader["Nombre"].ToString();
                        Producto.Clave = reader["Clave"].ToString();
                        Producto.CvePrecio = int.Parse(reader["CvePrecio"].ToString());
                        Producto.PrecioUnitarioOriginal = double.Parse(reader["PrecioUnitarioOriginal"].ToString());
                        Producto.PrecioUnitario = double.Parse(reader["PrecioUnitario"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.Adicional = double.Parse(reader["Adicional"].ToString());


                        Producto.PDescuento = float.Parse(reader["PDescuento"].ToString());
                        Producto.Descuento = ((Producto.PrecioUnitario * Producto.Cantidad)) * (Producto.PDescuento / 100);  //float.Parse(CheckTextBoxNull(reader["Descuento"].ToString(), "0", 1));
                        Producto.Subtotal = (Producto.PrecioUnitario * Producto.Cantidad) - Producto.Descuento;

                        // Producto.Iva = (Producto.Subtotal - Producto.Descuento) - ((Producto.Subtotal - Producto.Descuento) / (1 + double.Parse(IvaF.ToString())));
                        //Producto.Subtotal = ((Producto.Subtotal - Producto.Descuento) / (1 + float.Parse(IvaF.ToString())));


                        Producto.SIIVA = int.Parse(reader["SiIva"].ToString());

                        if (Producto.SIIVA == 1)
                        {
                            Producto.PIva = double.Parse(reader["PIva"].ToString());
                            Producto.Iva = Producto.Subtotal * Producto.PIva;

                        }
                        else
                        {
                            Producto.Iva = 0;
                        }

                        //Producto.Subtotal = ((Producto.Subtotal - Producto.Descuento) / (1 + float.Parse(IvaF.ToString())));
                        Producto.PrecioTotal = Producto.Subtotal + Producto.Iva;

                       // Producto.PDescuento = float.Parse(reader["PDescuento"].ToString());
                        Producto.CveColor = int.Parse(reader["CveColor"].ToString());
                        Producto.CveAlmacen = int.Parse(reader["CveAlmacen"].ToString());
                        Producto.CveNotaReferencia2 = int.Parse(reader["CveNotaReferencia2"].ToString());
                        Producto.IntCveTipoP = int.Parse(reader["CveTipoP"].ToString());
                        Producto.CveEmpleado = int.Parse(reader["CveVendedor"].ToString());
                        Producto.NombreEmpleado = reader["NombreVendedor"].ToString();
                        Producto.DblPendiente = double.Parse(reader["Pendiente"].ToString());
                        Producto.DblAfectar = double.Parse(reader["Afectar"].ToString());
                        ListaVenta.Add(Producto);

                    }
                    reader.Close();
                    reader.Dispose();
                    con.Close();
                    con.Dispose();

                }

            }


        }
        public ArrayList InsertaVentaAbierta(int CveVentaTempB, string strconexion2)
        {
            ArrayList ListaVenta = new ArrayList();
            
                string QueryLista = "SELECT VAD.CveVentaDetalle,Va.CveVentaTemp, CveCliente, FechaVenta, CveProducto, Cantidad, Nombre, Clave, CvePrecio, PrecioUnitarioOriginal, PrecioUnitario, SubTotal, VAD.Descuento, Adicional, Iva, SiIva, PIva, PrecioTotal, PDescuento, CveColor, CveAlmacen, CveNotaReferencia2, VAD.CveVendedor, NombreVendedor, CveTipoP, VAD.Pendiente, VAD.Afectar FROM VentaAbierta VA JOIN VentaAbiertaDetalle VAD ON VA.CveVentaTemp=VAD.CveVentaTemp WHERE VA.CveVentaTemp=" + CveVentaTempB;
                using (SqlConnection con = new SqlConnection(strconexion2))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QueryLista, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductoCompra Producto = new ProductoCompra(Strconexion);
                        Producto.Cantidad = double.Parse(reader["Cantidad"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.CveProducto = reader["CveProducto"].ToString();
                        Producto.Nombre = reader["Nombre"].ToString();
                        Producto.Nombre2 = reader["Nombre"].ToString();
                        Producto.Clave = reader["Clave"].ToString();
                        Producto.CvePrecio = int.Parse(reader["CvePrecio"].ToString());
                        Producto.PrecioUnitarioOriginal = double.Parse(reader["PrecioUnitarioOriginal"].ToString());
                        Producto.PrecioUnitario = double.Parse(reader["PrecioUnitario"].ToString(), System.Globalization.NumberStyles.Currency);
                        Producto.Adicional = double.Parse(reader["Adicional"].ToString());

                        Producto.PDescuento = float.Parse(reader["PDescuento"].ToString());
                        Producto.Descuento = ((Producto.PrecioUnitario * Producto.Cantidad)) * (Producto.PDescuento / 100);  //float.Parse(CheckTextBoxNull(reader["Descuento"].ToString(), "0", 1));
                        Producto.Subtotal = (Producto.PrecioUnitario * Producto.Cantidad) - Producto.Descuento;

                        // Producto.Iva = (Producto.Subtotal - Producto.Descuento) - ((Producto.Subtotal - Producto.Descuento) / (1 + double.Parse(IvaF.ToString())));
                        //Producto.Subtotal = ((Producto.Subtotal - Producto.Descuento) / (1 + float.Parse(IvaF.ToString())));


                        Producto.SIIVA = int.Parse(reader["SiIva"].ToString());

                        if (Producto.SIIVA == 1)
                        {
                            Producto.PIva = double.Parse(reader["PIva"].ToString());
                            Producto.Iva = Producto.Subtotal * Producto.PIva;

                        }
                        else
                        {
                            Producto.Iva = 0;
                        }

                        Producto.PrecioTotal = Producto.Subtotal + Producto.Iva;
                       // Producto.PDescuento = float.Parse(reader["PDescuento"].ToString());
                        Producto.CveColor = int.Parse(reader["CveColor"].ToString());
                        Producto.CveAlmacen = int.Parse(reader["CveAlmacen"].ToString());
                        Producto.CveNotaReferencia2 = int.Parse(reader["CveNotaReferencia2"].ToString());
                        Producto.CveEmpleado = int.Parse(reader["CveVendedor"].ToString());
                        Producto.NombreEmpleado = reader["NombreVendedor"].ToString();
                        Producto.IntCveTipoP=int.Parse(reader["CveTipoP"].ToString());
                        Producto.DblPendiente = double.Parse(reader["Pendiente"].ToString());
                        Producto.DblAfectar = double.Parse(reader["Afectar"].ToString());
                        ListaVenta.Add(Producto);

                    }
                    reader.Close();
                    reader.Dispose();
                    con.Close();
                    con.Dispose();

                }

                return ListaVenta;
        }
        public void EliminarVentaAbierta( int CveVentaTempB, string strconexion2)
        {
            
                string QueryDelete1 = "Delete From VentaAbierta Where CveVentaTemp=" + CveVentaTempB;
                string QueryDelete2 = "Delete From VentaAbiertaDetalle Where CveVentaTemp=" + CveVentaTempB;
                performupdatequery(QueryDelete1, StrconexionLocalGlobal);
                performupdatequery(QueryDelete2, StrconexionLocalGlobal);

            
        }


        public class ListaVentaAbiertas
        {
            private int intCveVentaTemp;

            public int CveVentaTemp
            {
                get { return intCveVentaTemp; }
                set { intCveVentaTemp = value; }
            }
            private int intCveNoVentaTemp;

            public int CveNoVentaTemp
            {
                get { return intCveNoVentaTemp; }
                set { intCveNoVentaTemp = value; }
            }

            private int intCveCliente;

            public int CveCliente
            {
                get { return intCveCliente; }
                set { intCveCliente = value; }
            }

            private string strNombreCliente;

            public string NombreCliente
            {
                get { return strNombreCliente; }
                set { strNombreCliente = value; }
            }

            private string strDireccion;

            public string Direccion
            {
                get { return strDireccion; }
                set { strDireccion = value; }
            }

            private string strColonia;

            public string Colonia
            {
                get { return strColonia; }
                set { strColonia = value; }
            }

            private string strPoblacion;

            public string Poblacion
            {
                get { return strPoblacion; }
                set { strPoblacion = value; }
            }

            private int intCveFormaPago;

            public int CveFormaPago
            {
                get { return intCveFormaPago; }
                set { intCveFormaPago = value; }
            }

            private int intCveFormaEntrega;

            public int CveFormaEntrega
            {
                get { return intCveFormaEntrega; }
                set { intCveFormaEntrega = value; }
            }

            private int intCveVendedor;

            public int CveVendedor
            {
                get { return intCveVendedor; }
                set { intCveVendedor = value; }
            }

            private string strObservaciones;

            public string Observaciones
            {
                get { return strObservaciones; }
                set { strObservaciones = value; }
            }

            private int intCveTipoDocumento;

            public int IntCveTipoDocumento
            {
                get { return intCveTipoDocumento; }
                set { intCveTipoDocumento = value; }
            }

            private int intCveTipoDocumentoParent;

            public int IntCveTipoDocumentoParent
            {
                get { return intCveTipoDocumentoParent; }
                set { intCveTipoDocumentoParent = value; }
            }

            private int intCveNotaReferencia;

            public int IntCveNotaReferencia
            {
                get { return intCveNotaReferencia; }
                set { intCveNotaReferencia = value; }
            }

        }

        public ArrayList ListaVentasActivas()
        {
            ArrayList lista = new ArrayList();
            using (SqlConnection con = new SqlConnection(StrconexionLocalGlobal))
            {
                con.Open();

                string query = "Select * From VentaAbierta Where CveVendedor=" + CveUser.Cve_User + " order by CveVentaTemp";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListaVentaAbiertas item = new ListaVentaAbiertas();
                        item.CveVentaTemp = int.Parse(reader["CveVentaTemp"].ToString());
                        item.CveNoVentaTemp = int.Parse(reader["CveNoVentaTemp"].ToString());
                        item.CveCliente = int.Parse(reader["CveCliente"].ToString());
                        item.CveFormaEntrega = int.Parse(reader["CveFormaEntrega"].ToString());
                        item.CveFormaPago = int.Parse(reader["CveFormaPago"].ToString());
                        item.CveVendedor = int.Parse(reader["CveVendedor"].ToString());
                        item.Observaciones = reader["Observaciones"].ToString();
                        item.NombreCliente = reader["NombreCliente"].ToString();
                        item.Direccion = reader["Direccion"].ToString();
                        item.Colonia = reader["Colonia"].ToString();
                        item.Poblacion = reader["Poblacion"].ToString();
                        item.IntCveTipoDocumento=int.Parse(reader["CveTipoDocumento"].ToString());
                        item.IntCveTipoDocumentoParent = int.Parse(reader["CveTipoDocumentoParent"].ToString());
                        lista.Add(item);

                    }

                }
            }

            return lista;
        }
        
        public int VerificaFormaPago(int CveFormaPago, int CveCliente, double ImporteTotal)
        {
            int ValorRetorno=0;

            switch (CveFormaPago)
            {
                case 1:
                    break;
                case 2:
                    int CveEstatusCredito = FormaCreditoEstatus(CveCliente);

                    if (CveEstatusCredito == 0)
                    {
                        ValorRetorno = 21;
                    }

                    break;
                case 3:
                    FormaPorPagar();
                    break;
            }

            return ValorRetorno;
        }
        private ArrayList ListaParametros = new ArrayList();
        private int FormaCreditoEstatus(int CveCliente)
        {

            ListaParametros.Clear();

            SP_Parametros _sp1 = new SP_Parametros();
            _sp1.StrNombreParametro = "CveCliente";
            _sp1.StrTipoValor = "int";
            _sp1.StrValueParametro = CveCliente.ToString();

            SP_Parametros _sp2 = new SP_Parametros();
            _sp2.StrNombreParametro = "CveEstatus";
            _sp2.StrTipoValor = "int";
            _sp2.StrValueParametro = "0";

            ListaParametros.Add(_sp1);
            ListaParametros.Add(_sp2);

            DataTable _tbClienteCredito = new DataTable();

            _tbClienteCredito = SP_Busca_Reader(ListaParametros, "SP_CheckCreditoEstatus");


            int CveEstatusCredito = 0;

            foreach (DataRow row in _tbClienteCredito.Rows)
            {
                CveEstatusCredito=int.Parse(row["CveEstatus"].ToString());
            }

            if (CveEstatusCredito == 0)
            {
                MessageBox.Show("El Cliente no cuenta con línea de credito..., Favor de verificar los datos", "Validación de Datos");
            }

            return CveEstatusCredito;
        }
        private void FormaPorPagar()
        {

        }

        protected string GenerarFolio(string TipoDocumento)
        {
            string Folio = "";


                       

            ListaParametros.Clear();

            SP_Parametros _sp1 = new SP_Parametros();
            _sp1.StrNombreParametro = "pTable_Name";
            _sp1.StrTipoValor = "string";
            _sp1.StrValueParametro = TipoDocumento;

            SP_Parametros _sp2 = new SP_Parametros();
            _sp2.StrNombreParametro = "pNewId";
            _sp2.StrTipoValor = "int";
            _sp2.StrValueParametro = "0";

            ListaParametros.Add(_sp1);
            ListaParametros.Add(_sp2);

            DataTable _tbClienteCredito = new DataTable();

            _tbClienteCredito = SP_Busca_Reader(ListaParametros, "p_GetId");
            
            
            int FolioInt = 0;

            foreach (DataRow row in _tbClienteCredito.Rows)
            {
                FolioInt = int.Parse(row["Folio"].ToString());
            }


            Folio = string.Format("{0:00000000}", FolioInt);
            
            return Folio;
        }

        protected bool IsDecimal(double num)
        {
            int n_entero = (int)num;

            if (num != n_entero)
                return true;
            else
                return false;
        }
        protected void GuardarImagen(System.IO.MemoryStream img)
        {
            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update CatEmpresa Set logoticket=@imagen Where CveEmpresa=1";

                cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image);

                cmd.Parameters["@imagen"].Value = img.GetBuffer();

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        protected int intCheck(bool valor)
        {
            int valorretorno = 0;

            if (valor)
                valorretorno = 1;
            else
                valorretorno = 0;

            return valorretorno;
        }

        public string ObtenerFechaHora(int opcion)
        {
            string Fecha = "";

            DataTable _dt = new DataTable();

          

            ListaParametros.Clear();

            SP_Parametros _sp1 = new SP_Parametros();
            _sp1.StrNombreParametro = "opcion";
            _sp1.StrTipoValor = "int";
            _sp1.StrValueParametro = opcion.ToString();

            ListaParametros.Add(_sp1);

            _dt = SP_Busca_Reader(ListaParametros, "SP_ObtenerFecha");
            Clases.cPageBase cp = new cPageBase();
            

            foreach (DataRow drw in _dt.Rows)
            {
                Fecha = drw["Dato"].ToString();

            }

            return Fecha;

        }
      
        public string ObtenerFolio(int CveTipoDocumento)
        {
            string Prefijo = GetStrFieldQuery("Prefijo", "Select Prefijo From Contadores Where CveTipoDocumento=" + CveTipoDocumento);

            //CveTipoDocumento = item.IntCveTipoDocumento;

            string TipoDocumento2 = GetStrFieldQuery("DES_TABLA", "Select DES_TABLA From Contadores Where CveTipoDocumento=" + CveTipoDocumento);

            string NoDocumento = Prefijo + GenerarFolio(TipoDocumento2);

            return NoDocumento;

        }
        public int SP_QueryExecute(string Sql)
        {
            int Dato=0;

            ArrayList ListaParametro = new ArrayList();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("sql", Sql, "string"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_QueryExecute");

            foreach (DataRow rw in _dt.Rows)
            {
                Dato = int.Parse(rw["Dato"].ToString());
            }

            return Dato;
        }
        public int SP_QueryExecute(string Sql, SqlConnection connection, SqlTransaction transaction)
        {
            int Dato = 0;

            ArrayList ListaParametro = new ArrayList();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("sql", Sql, "string"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_QueryExecute");

            foreach (DataRow rw in _dt.Rows)
            {
                Dato = int.Parse(rw["Dato"].ToString());
            }

            return Dato;
        }

        public string SP_QueryExecute(string Sql, string Campo)
        {
            string Dato ="";

            ArrayList ListaParametro = new ArrayList();
            DataTable _dt = new DataTable();

            ListaParametro.Add(addparametro("SqlDato", Sql, "string"));

            _dt = SP_Busca_Reader(ListaParametro, "SP_ExecuteQuery_DC");

            foreach (DataRow rw in _dt.Rows)
            {
                Dato = rw[Campo].ToString();
            }

            return Dato;
        }

        public DataTable SP_DataReaderQueryMonar(string Query)
        {
            DataTable _dt = new DataTable();

            using (SqlConnection con = new SqlConnection(StrconexionGlobalMonar))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            _dt.Load(reader);
                        }
                        reader.Close();

                    }
                    cmd.Dispose();
                }

                con.Close();

            }

            return _dt;
        }
        public DataTable SP_DataReaderQuery(string Query)
        {
            DataTable _dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Strconexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            _dt.Load(reader);
                        }
                        reader.Close();

                    }
                    cmd.Dispose();
                }

                con.Close();

            }

            return _dt;
        }
        public DataTable SP_DataReaderQuery(string Query, SqlConnection connection, SqlTransaction transaction)
        {
            DataTable _dt = new DataTable();


            using (SqlCommand cmd = new SqlCommand(Query, connection,transaction))

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    _dt.Load(reader);
                }
                reader.Close();

            }
             

            return _dt;
        }

        protected string ObtenerTipoDocumento(int opcion)
        {
            string CveTipoDocumento = "";

            DataTable _dt = new DataTable();



            ListaParametros.Clear();



            _dt = SP_Busca_Reader(ListaParametros, "SP_ObtenerDocumento");


            foreach (DataRow drw in _dt.Rows)
            {
                CveTipoDocumento = drw["CveTipoDocumento"].ToString();

            }

            return CveTipoDocumento;

        }
        public void checkAccess(Form Formulario, int Nivel)
        {
            DialogResult result;
            result = MessageBox.Show("Usted no está autorizado para acceder a este modulo, ¿Desea ingresar una clave de acceso?", "Error Ingreso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Usuarios.FormIngresarClaveGlobal IngresarClave = new Usuarios.FormIngresarClaveGlobal();
                IngresarClave.Formulario = Formulario;
                IngresarClave.Nivel = Nivel;
                IngresarClave.Show();
            }
        }

        public void SetDBLogonForReport(ReportDocument mRD)
        {


            ConnectionInfo crystalcon = new ConnectionInfo();
            crystalcon.ServerName = ConfigurationManager.AppSettings["ServerReport"]; //ServerName.Id_ServerName; //"172.16.1.235";
            crystalcon.DatabaseName = ConfigurationManager.AppSettings["DataBaseReport"]; //BaseDatos.Id_BaseDatos; //"SEEAtiende";
            crystalcon.UserID = ConfigurationManager.AppSettings["UserDBReport"]; //IdUserName.IdUser_Name; //"STAtiende";
            crystalcon.Password = ConfigurationManager.AppSettings["PasswordDBReport"]; //IdPassWord.Id_PassWord;  //"$A%43NA";


            Tables myTables = mRD.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables)
            {
                TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo = crystalcon;
                myTable.ApplyLogOnInfo(myTableLogonInfo);
            }
        }


        public DataTable SP_Busca_Reader_Table(string Query)
        {
            DataTable Table = new DataTable();
            using (SqlConnection cn = new SqlConnection(Strconexion))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(Query, cn);

                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    Table.Load(dr);
                }
                cmd.Dispose();
                dr.Close();

            }
            return Table;
        }


    }

}
