using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasMonar.Desktop.Clases
{
    /// <summary>
    /// Datos de Reporte de Operaciones PLD.
    /// 
    /// </summary>
    class ReporteCNBV
    {
        private string strTipoReporte;
        /// <summary>
        /// Relevantes:
        /// VRC1R1: El campo es alfanumérico.
        /// * VRC1R2: El campo debe medir 1 caracter
        /// * VRC1R3: El campo es obligatorio
        /// * VRC1R5: El dato debe ser igual a 1
        /// </summary>
        public string TipoReporte
        {
           
            get { return strTipoReporte; }
            set { strTipoReporte = value; }
        }

        private int intPeriodo_Reporte;
        /// <summary>
        /// * VRC2R1: El campo es numérico
        ///* VRC2R2: El campo debe medir 6 caracteres
        /// * VRC2R3: El campo es obligatorio
        /// * VRC2R4: Formato AAAAMM
        /// * VRC2R5: Unicamente podrá existir un período por archivo
        /// * VRC2R6: Sólo se recibe el período vigente y/o anterior. No
        ///posteriores
        /// </summary>
        public int Periodo_Reporte
        {
            get { return intPeriodo_Reporte; }
            set { intPeriodo_Reporte = value; }
        }

        private string strFolio;
        /// <summary>
        /// * VRC3R1: El campo es alfanumérico
        ///* VRC3R2: El campo debe medir 6 caracteres
        ///* VRC3R3: El campo es obligatorio
        ///* VRC3R4: El campo debe de ser de 6 números
        ///* VRC3R5: El consecutivo debe iniciar en 000001 y
        ///se incrementará en 1 por cada operación principal que se reporte dentro de un mismo archivo
        /// </summary>
        public string Folio
        {
            get { return strFolio; }
            set { strFolio = value; }
        }

        private string strOrgano_Supervisor;
        /// <summary>
        /// * VRC4R1: El campo es alfanumérico.
        ///* VRC4R2: El campo debe medir 6 caracteres.
        ///* VRC4R3: El campo es obligatorio.
        ///* VRC4R4: El campo debe de ser de 6 números.
        ///* VRC4R5: La clave del campo debe ser la de la Comisión Nacional Bancaria
        ///y de Valores de acuerdo al catálogo del Sistema Financiero Mexicano (CASFIM) para Autoridades y Organos Supervisores.
        ///Debe ir sin el guión (-) intermedio y anteponiendo un cero al inicio de la clave.
        ///* VRC4R6: Unicamente podrá existir una clave de Organo Supervisor por archivo
        /// </summary>
        public string Organo_Supervisor
        {
            get { return strOrgano_Supervisor; }
            set { strOrgano_Supervisor = value; }
        }

        private string strClave_Sujeto_Obligado;
        /// <summary>
        /// * VRC5R1: El campo es alfanumérico
        /// * VRC5R2: El campo debe medir máximo 7 caracteres
        /// * VRC5R3: El campo es obligatorio 
        /// * VRC5R4: La clave del campo debe ser de acuerdo al catálogo
        /// CASFIM para entidades financieras. Debe ir sin el guión (-) intermedio y anteponiendo un 0 (cero) al inicio de la clave.
        /// * VRC5R5: Unicamente podrá existir una clave de sujeto obligado por archivo 
        /// </summary>
        public string Clave_Sujeto_Obligado
        {
            get { return strClave_Sujeto_Obligado; }
            set { strClave_Sujeto_Obligado = value; }
        }

        private string strLocalidad;
        /// <summary>
        /// * VRC6R1: El campo es alfanumérico.
        /// * VRC6R2: El campo debe medir 8 caracteres.
        /// * VRC6R3: El campo es obligatorio.
        /// * VRC6R4: La Localidad se debe capturar de acuerdo al catálogo que de a conocer
        /// la Unidad de Inteligencia Financiera a través de la Comisión Nacional Bancaria y de Valores.
        ///</summary>
        public string Localidad_Sucursal
        {
            get { return strLocalidad; }
            set { strLocalidad = value; }
        }

        private string strCodigo_Postal;
        /// <summary>
        /// * VRC7R1: El campo es alfanumérico.
        /// * VRC7R2: El campo debe medir 5 caracteres.
        /// * VRC7R3: El campo es obligatorio 
        /// * VRC7R4: El campo debe de ser de 5 números.
        /// * VRC7R5: El código postal de la sucursal debe ser válido para la entidad federativa de la localidad reportada.
        /// Si la operación no se genera en sucursal, el código postal debe ser el de la casa matriz.
        ///</summary>
        public string Codigo_Postal_Surcursal
        {
            get { return strCodigo_Postal; }
            set { strCodigo_Postal = value; }
        }

        private string strTipo_Operacion;
        /// <summary>
        /// * VRC8R1: El campo es alfanumérico.
        /// * VRC8R2: El campo debe medir 2 caracteres.
        /// * VRC8R3: El campo es obligatorio.
        /// * VRC8R4: El Tipo de Operación se debe capturar de acuerdo al catálogo que de a conocer
        /// la Unidad de Inteligencia Financiera a través de la Comisión Nacional Bancaria y de Valores.
        /// </summary>
        
        public string Tipo_Operacion
        {
            get { return strTipo_Operacion; }
            set { strTipo_Operacion = value; }
        }

        private string strIntrumento_Monetario;
        /// <summary>
        /// * VRC9R1: El campo es alfanumérico.
        /// * VRC9R2: El campo debe medir 2 caracteres. 
        /// * VRC9R3: El campo es obligatorio.
        /// * VRC9R4: El Instrumento Monetario se debe capturar de acuerdo al catálogo que de a conocer la Unidad de Inteligencia Financiera a través de la Comisión Nacional Bancaria y de Valores.
        /// </summary>
        public string Intrumento_Monetario
        {
            get { return strIntrumento_Monetario; }
            set { strIntrumento_Monetario = value; }
        }

        private string strNoCuenta_Contrato;
        /// <summary>
        /// * VRC10R1: El campo es alfanumérico.
        /// * VRC10R2: El campo debe medir máximo 16 caracteres.
        /// * VRC10R3: El campo es obligatorio.
        /// </summary>
        public string NoCuenta_Contrato
        {
            get { return strNoCuenta_Contrato; }
            set { strNoCuenta_Contrato = value; }
        }
        private double dblMonto;
        /// <summary>
        /// * VRC11R1: El campo es numérico.
        /// * VRC11R2: El campo debe medir máximo 17 caracteres.
        /// * VRC11R3: El campo es obligatorio.
        /// * VRC11R4: Las primeras 14 posiciones se utilizarán para los enteros y las 2 últimas para los decimales, separando las fracciones con un punto.
        /// </summary>
        public double Monto
        {
            get { return dblMonto; }
            set { dblMonto = value; }
        }

        private string strMoneda;
        /// <summary>
        /// * VRC12R1: El campo es alfanumérico.
        /// * VRC12R2: El campo debe medir máximo 3 caracteres.
        /// * VRC12R3: El campo es obligatorio.
        /// * VRC12R4: La Moneda se debe capturar de acuerdo al catálogo que de a conocer la Unidad de Inteligencia Financiera a través de la Comisión Nacional Bancaria y de Valores.
        /// </summary>
        public string Moneda
        {
            get { return strMoneda; }
            set { strMoneda = value; }
        }

        private int intFecha_Operacion;
        /// <summary>
        /// * VRC13R1: El campo es numérico.
        /// * VRC13R2: El campo debe medir 8 caracteres.
        /// * VRC13R3: El campo es obligatorio.
        /// * VRC13R4: Formato AAAAMMDD.
        /// * VRC13R5: La fecha de operación debe ser menor o igual al período del reporte.
        /// * VRC13R6: Debe ser enviado dentro de los diez últimos días hábiles de los meses de enero, abril, julio y octubre de cada año.
        /// </summary>
        public int Fecha_Operacion
        {
            get { return intFecha_Operacion; }
            set { intFecha_Operacion = value; }
        }

        private int intFecha_Deteccion_Operacion;
        /// <summary>
        /// Relevantes : 
        /// * VRC14R1: El campo debe ser nulo.
        /// Inusuales:
        /// * VIC14R1: El campo es numérico.
        /// * VIC14R2: El campo debe medir 8 caracteres.
        /// * VIC14R3: El campo es obligatorio si es operación principal. 
        /// En caso de personas o cuentas relacionadas debe ser nulo.
        /// * VIC14R4: Formato AAAAMMDD.
        /// * VIC14R5: Debe ser enviado dentro de los sesenta días naturales contados a partir de la fecha de detección.
        /// </summary>
        public int Fecha_Deteccion_Operacion
        {
            get { return intFecha_Deteccion_Operacion; }
            set { intFecha_Deteccion_Operacion = value; }
        }

        private string strNacionalidad;
        /// <summary>
        /// * VRC15R1: El campo es alfanumérico.
        /// * VRC15R2: El campo debe medir 1 caracter.
        /// * VRC15R3: El campo es obligatorio.
        /// * VRC15R4: La clave debe coincidir con el siguiente catálogo:
        /// 1 --> Mexicana 2 --> Extranjero.
        /// </summary>
        public string Nacionalidad
        {
            get { return strNacionalidad; }
            set { strNacionalidad = value; }
        }

        private string strTipo_Persona;
        /// <summary>
        /// * VRC16R1: El campo es alfanumérico.
        /// * VRC16R2: El campo debe medir 1 caracter.
        /// * VRC16R3: El campo es obligatorio.
        /// * VRC16R4: La clave debe coincidir con el siguiente catálogo:
        /// 1 --> Persona Física 2 --> Persona Moral.
        /// </summary>
        public string Tipo_Persona
        {
            get { return strTipo_Persona; }
            set { strTipo_Persona = value; }
        }

        private string strRazon_Social;
        /// <summary>
        /// * VRC17R1: El campo es alfanumérico.
        /// * VRC17R2: El campo debe medir máximo 125 caracteres.
        /// * VRC17R3: El campo es obligatorio si el campo "tipo de persona" tiene valor 2.
        /// </summary>
        public string Razon_Social
        {
            get { return strRazon_Social; }
            set { strRazon_Social = value; }
        }

        private string strNombre;
        /// <summary>
        /// * VRC18R1: El campo es alfanumérico.
        /// * VRC18R2: El campo debe medir máximo 60 caracteres.
        /// * VRC18R3: El campo es obligatorio si el campo "tipo de persona" tiene valor 1.
        /// * VRC18R4: Debe ser distinto al campo "razón social o denominación".
        /// </summary>
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        private string strAp_Paterno;
        /// <summary>
        /// * VRC19R1: El campo es alfanumérico.
        /// * VRC19R2: El campo debe medir máximo 60 caracteres.
        /// * VRC19R3: El campo es obligatorio si el campo "tipo de persona" tiene valor 1.
        /// * VRC19R4: En caso que la persona reportada no tenga apellido paterno se deben capturar cuatro equis (XXXX) y el campo "apellido materno" debe ser obligatorio y distinto a (XXXX).
        /// </summary>
        public string Ap_Paterno
        {
            get { return strAp_Paterno; }
            set { strAp_Paterno = value; }
        }

        private string strAp_Materno;
        /// <summary>
        ///* VRC20R1: El campo es alfanumérico.
        ///* VRC20R2: El campo debe medir máximo 30 caracteres.
        ///* VRC20R3: El campo es obligatorio si el campo "tipo de persona" tiene valor 1. 
        ///* VRC20R4: En caso que la persona reportada no tenga apellido materno se deben capturar cuatro equis (XXXX).
        /// </summary>
        public string Ap_Materno
        {
            get { return strAp_Materno; }
            set { strAp_Materno = value; }
        }

        private string strRFC;
        /// <summary>
        /// * VRC21R1: El campo es alfanumérico.
        /// * VRC21R2: El campo debe medir máximo 13 caracteres.
        /// * VRC21R3: El campo es opcional siempre y cuando se cuente con CURP o fecha de nacimiento, pudiendo proporcionar los 3 si se cuenta con los mismos. Es obligatorio cuando no se cuente con fecha de nacimiento y CURP
        /// * VRC21R4: El campo debe seguir el patrón LLLLAAMMDDXXX que representa el formato donde:
        ///</summary>
        public string RFC
        {
            get { return strRFC; }
            set { strRFC = value; }
        }

        private string strCURP;
        /// <summary>
        /// * VRC22R1: El campo es alfanumérico.
        /// * VRC22R2: El campo debe medir 18 caracteres.
        /// * VRC22R3: El campo es opcional siempre y cuando se cuente con RFC o fecha de nacimiento, pudiendo proporcionar los 3 si se cuenta con los mismos. Es obligatorio cuando no se cuente con fecha de nacimiento y RFC
        /// </summary>
        public string CURP
        {
            get { return strCURP; }
            set { strCURP = value; }
        }

        private int intFechaNac_Constitucion;
        /// <summary>
        /// * VRC23R1: El campo es numérico.
        /// * VRC23R2: El campo debe medir 8 caracteres.
        /// * VRC23R3: El campo es obligatorio si los campos "RFC" y "CURP" se encuentran vacíos.
        /// * VRC23R4: Formato AAAAMMDD * VRC23R5: Debe ser menor al campo fecha de operación y mayor a 19000101.
        /// </summary>
        public int FechaNac_Constitucion
        {
            get { return intFechaNac_Constitucion; }
            set { intFechaNac_Constitucion = value; }
        }

        private string strDomicilio;
        /// <summary>
        /// * VRC24R1: El campo es alfanumérico.
        /// * VRC24R2: El campo debe medir máximo 60 caracteres.
        /// * VRC24R3: El campo es obligatorio.
        /// </summary>
        public string Domicilio
        {
            get { return strDomicilio; }
            set { strDomicilio = value; }
        }

        private string strColonia;
        /// <summary>
        /// * VRC25R1: El campo es alfanumérico.
        /// * VRC25R2: El campo debe medir máximo 30 caracteres.
        /// * VRC25R3: El campo es obligatorio.
        /// </summary>
        public string Colonia
        {
            get { return strColonia; }
            set { strColonia = value; }
        }

        private string strCiudad_Poblacion;
        /// <summary>
        /// * VRC26R1: El campo es alfanumérico.
        /// * VRC26R2: El campo debe medir 8 caracteres.
        /// * VRC26R3: El campo es obligatorio.
        /// * VRC26R4: La Ciudad o Población se debe capturar de acuerdo al catálogo que de a conocer la Unidad de Inteligencia Financiera a través de la Comisión Nacional Bancaria y de Valores.
        /// </summary>
        public string Ciudad_Poblacion
        {
            get { return strCiudad_Poblacion; }
            set { strCiudad_Poblacion = value; }
        }

        private string strTelefono;
        /// <summary>
        /// * VRC27R1: El campo es alfanumérico.
        /// * VRC27R2: El campo debe medir máximo 40 caracteres.
        /// </summary>
        public string Telefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }

        private string strActividad_Economica;
        /// <summary>
        /// * VRC28R1: El campo es alfanumérico.
        /// * VRC28R2: El campo debe medir 7 caracteres.
        /// * VRC28R3: El campo es obligatorio.
        /// * VRC28R4: La Actividad Económica se debe capturar de acuerdo al catálogo que de a conocer la Unidad de Inteligencia Financiera a través de la Comisión Nacional Bancaria y de Valores.
        /// </summary>
        public string Actividad_Economica
        {
            get { return strActividad_Economica; }
            set { strActividad_Economica = value; }
        }

        private string strConsecutivo_Cuenta_Relacionada;
        /// <summary>
        /// Relevante:
        /// * VRC29R1: El campo debe de ser nulo.
        /// Insuales:
        /// * VIC29R1: El campo es alfanumérico.
        /// * VIC29R2: El campo debe medir 2 caracteres.
        /// * VIC29R3: Si la operación es principal y no tiene personas o cuentas relacionadas el campo debe ser nulo. En caso de que la operación sea principal y sí tenga relacionados obligatoriamente deberá tener el valor "00".
        /// * VIC29R4: Si la operación es relacionada, el consecutivo deberá ir desde "01" hasta el "n" número de personas relacionadas.
        /// </summary>
        public string Consecutivo_Cuenta_Relacionada
        {
            get { return strConsecutivo_Cuenta_Relacionada; }
            set { strConsecutivo_Cuenta_Relacionada = value; }
        }

        private string strNoCuenta_Contrato_Operacion;
        /// <summary>
        /// Relevante:
        /// * VRC29R1: El campo debe de ser nulo.
        /// Inusales::
        /// * VIC30R1: El campo es alfanumérico.
        /// * VIC30R2: El campo debe medir máximo 16 caracteres.
        /// * VIC30R3: Si la operación es relacionada el campo es obligatorio. En caso de operación principal debe ser nulo
        /// 
        /// </summary>
        public string NoCuenta_Contrato_Operacion
        {
            get { return strNoCuenta_Contrato_Operacion; }
            set { strNoCuenta_Contrato_Operacion = value; }
        }

        private string strClave_Sujeto_Obligado_Relacionado;

        public string Clave_Sujeto_Obligado_Relacionado
        {
            get { return strClave_Sujeto_Obligado_Relacionado; }
            set { strClave_Sujeto_Obligado_Relacionado = value; }
        }

        private string strNombre_Titular_Cuenta_Relacionada;

        public string Nombre_Titular_Cuenta_Relacionada
        {
            get { return strNombre_Titular_Cuenta_Relacionada; }
            set { strNombre_Titular_Cuenta_Relacionada = value; }
        }

        private string strPaterno_Titular_Cuenta_Relacionada;

        public string Paterno_Titular_Cuenta_Relacionada
        {
            get { return strPaterno_Titular_Cuenta_Relacionada; }
            set { strPaterno_Titular_Cuenta_Relacionada = value; }
        }

        private string strMaterno_Titular_Cuenta_Relacionada;

        public string Materno_Titular_Cuenta_Relacionada
        {
            get { return strMaterno_Titular_Cuenta_Relacionada; }
            set { strMaterno_Titular_Cuenta_Relacionada = value; }
        }

        private string strDescripcion_Operacion;

        public string Descripcion_Operacion
        {
            get { return strDescripcion_Operacion; }
            set { strDescripcion_Operacion = value; }
        }

        private string strRazones_Acto_Operacion_Inusual_o_Preocupante;

        public string Razones_Acto_Operacion_Inusual_o_Preocupante
        {
            get { return strRazones_Acto_Operacion_Inusual_o_Preocupante; }
            set { strRazones_Acto_Operacion_Inusual_o_Preocupante = value; }
        }
    }
    /// <summary>
    /// Datos de Reporte Alertas.
    /// </summary>
    class ReporteAleras
    {
        private int intCveTransaccion;

        public int CveTransaccion
        {
            get { return intCveTransaccion; }
            set { intCveTransaccion = value; }
        }
        private int intCveCliente;

        public int CveCliente
        {
            get { return intCveCliente; }
            set { intCveCliente = value; }
        }
        private int intCveCredito;

        public int CveCredito
        {
            get { return intCveCredito; }
            set { intCveCredito = value; }
        }
        private int intCveMovimiento;

        public int CveMovimiento
        {
            get { return intCveMovimiento; }
            set { intCveMovimiento = value; }
        }

        private DateTime strFecha;

        public DateTime Fecha
        {
            get { return strFecha; }
            set { strFecha = value; }
        }

        private string strHora;

        public string Hora
        {
            get { return strHora; }
            set { strHora = value; }
        }
        private string strDescripcionAlerta;

        public string DescripcionAlerta
        {
            get { return strDescripcionAlerta; }
            set { strDescripcionAlerta = value; }
        }
        private int intCveTipoRiesgo;

        public int CveTipoRiesgo
        {
            get { return intCveTipoRiesgo; }
            set { intCveTipoRiesgo = value; }
        }

        private string strNotaFinal;

        public string NotaFinal
        {
            get { return strNotaFinal; }
            set { strNotaFinal = value; }
        }

        private string strTipoOperacion;

        public string TipoOperacion
        {
            get { return strTipoOperacion; }
            set { strTipoOperacion = value; }
        }

        private string strTipoInstrumento;

        public string TipoInstrumento
        {
            get { return strTipoInstrumento; }
            set { strTipoInstrumento = value; }
        }

        private string strMoneda;

        public string Moneda
        {
            get { return strMoneda; }
            set { strMoneda = value; }
        }
        private double dblMonto;

        public double Monto
        {
            get { return dblMonto; }
            set { dblMonto = value; }
        }

    }
}
