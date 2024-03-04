using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasMonar.Desktop.Clases
{
    public class c_Usuarios
    {
        private int cveuser;
        private string user_name;
        private string nombre;
        private string password;
        private int cveTipoUsuario;
        private int cveEstatus;
        private int actualiza;
        private int cveUsuarioActual;

        public int Cveuser { get => cveuser; set => cveuser = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public int CveTipoUsuario { get => cveTipoUsuario; set => cveTipoUsuario = value; }
        public int CveEstatus { get => cveEstatus; set => cveEstatus = value; }
        public int Actualiza { get => actualiza; set => actualiza = value; }
        public int CveUsuarioActual { get => cveUsuarioActual; set => cveUsuarioActual = value; }

        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string IdSesion { get; set; }
        public string IPLocal { get; set; }
        public string IPPublica { get; set; }
        public string PublicIP { get; set; }
        public string PC { get; set; }
        public int CveTipoMovUser { get; set; }
        public int CveModulo { get; set; }

        public int Bloqueo { get; set; }
        public string strConexion { get; set; }
        public SqlConnection connection { get; set; }
        public SqlTransaction transaction { get; set; }

        public static string[] ReglasUsuario { get; set; }

        ArrayList ListaParametros = new ArrayList();
        Clases.cPageBase pb = new cPageBase();

        public class PerfilRegla
        {

        }


        public int SaveData()
        {
            int CveUsuario = 0;

            ListaParametros.Add(pb.addparametro("user_name", User_name, "string"));
            ListaParametros.Add(pb.addparametro("Nombre", Nombre, "string"));
            ListaParametros.Add(pb.addparametro("Password", Password, "string"));
            ListaParametros.Add(pb.addparametro("CveTipoUsuario", CveTipoUsuario.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("CveEstatus", CveEstatus.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("Actualiza", Actualiza.ToString(), "int"));
            ListaParametros.Add(pb.addparametro("CveUsuarioActual", CveUsuarioActual.ToString(), "int"));

            DataTable _dt = new DataTable();

            _dt = pb.SP_Busca_Reader(ListaParametros, "SP_SaveUsuarios");

            foreach (DataRow rw in _dt.Rows)
            {
                CveUsuario = (int)rw["CveUser"];
            }

            return CveUsuario;
        }

        public int SaveDetelleAccesos()
        {
            int intAcceso = 0;

            using (SqlConnection connection = new SqlConnection(strConexion))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    AccesoUsuario(Bloqueo, connection, transaction);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Commit Exception Type: {0}" + ex.GetType(), "Validación de Datos");
                    MessageBox.Show("  Message: {0}" + ex.Message, "Validación de Datos");

                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        MessageBox.Show("Rollback Exception Type: {0}" + ex2.GetType(), "Validación de Datos");
                        MessageBox.Show("  Message: {0}" + ex2.Message, "Validación de Datos");
                    }
                }

                return intAcceso;
            }
        }

        private int AccesoUsuario(int Bloqueo, SqlConnection connection, SqlTransaction transaction, int CveFormulario = 0)
        {
            Clases.cPageBase cPage = new Clases.cPageBase();



            string QueryUpdate = "Update Usuarios Set Bloqueo=" + Bloqueo + " Where CveUser=" + Cveuser;
            int _dtResultUsuario = cPage.SP_QueryExecute(QueryUpdate, connection, transaction);


            string QueryInsertAcceso = "Insert Into UsuariosDetalle(CveUser, Fecha, Hora, Idsesion, IPLocal,IPPublica, PC, CveTipoMovUser, CveModulo) Values(";
            QueryInsertAcceso += Cveuser + ",'" +  Fecha + "','" + Hora + "','" + IdSesion + "','" + IPLocal + "','" + IPPublica + "','" + PC + "'," + CveTipoMovUser + "," + CveModulo + ")";



            int _dtResulAcceso = cPage.SP_QueryExecute(QueryInsertAcceso, connection, transaction);

            return _dtResulAcceso;

        }
        public int DesbloqueUsuario()
        {
            int _result = 0;

            string Query = "Update Usuarios Set Bloqueo=0 where CveUser=" + Cveuser;

            return _result = pb.SP_QueryExecute(Query);
        }
        public DataTable dtUsuariosConectados()
        {
            DataTable _dtResult = new DataTable();

            string Query = "Select CveUser, user_name, Nombre, Bloqueo From Usuarios Where Bloqueo=1";

            return _dtResult = pb.SP_DataReaderQuery(Query);
        }


        public DataTable dtUsuariosBD()
        {
            DataTable _dtResult = new DataTable();

            string Query = "Select * From Usuarios ";

            return _dtResult = pb.SP_DataReaderQuery(Query);
        }

        public static bool TieneRegla(string reglas_a_verificar)
        {
            string[] aReglas_a_Verificar = reglas_a_verificar.Split(',');
            foreach (var s in aReglas_a_Verificar)
            {
                if (s != "" && ReglasUsuario.Contains(s))
                {
                    return true;
                }
            }
            return false;

        }

        public static DataTable ValidarPermisoPerfilMenu(int CvePerfil, int CveRegla)
        {
            Clases.cPageBase pb = new cPageBase();

            DataTable _dtResult = new DataTable();

            string Query = "Select PR.CveModulo From PerfilRegla PR Left Join CatPerfiles CP on PR.CvePerfil=CP.CvePerfil Left Join CatModulos CM on PR.CveModulo=CM.CveModulo Where  PR.CvePerfil=" + CvePerfil + " And PR.CveRegla=1;";

            _dtResult = pb.SP_DataReaderQuery(Query);

            return _dtResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CveUser"></param>
        /// <param name="NombreFormulario"></param>
        /// <param name="CveRegla"></param>
        /// <returns></returns>
        public static bool ValidarPermisoPerfil(int CvePerfil, int CveRegla, string NombreFormulario)
        {
            Clases.cPageBase pb = new cPageBase();

            string Query = "Select Count(*) As Cuenta From PerfilRegla PR Left Join CatPerfiles CP on PR.CvePerfil=CP.CvePerfil Left Join CatModulos CM on PR.CveModulo=CM.CveModulo Where PR.CvePerfil=" + CvePerfil + " And PR.CveRegla=" + CveRegla + " And CM.Nombre='" + NombreFormulario + "'";

            int Cuenta = pb.SP_QueryExecute(Query);

            if (Cuenta == 0)
                return false;

            return true;
        }

        public static bool SavePerfilRegla(int CvePerfil, int CveModulo, int CveRegla)
        {

            cPageBase pb = new cPageBase();

            string QueryInsert = "Insert Into PerfilRegla(CvePerfil, CveModulo, CveRegla) Values(" + CvePerfil + "," + CveModulo + "," + CveRegla + ")";

         

           pb.SP_QueryExecute(QueryInsert);


            return true;
        }
        public static DataTable ReadPerfilRegla(int CvePerfil, int CveModulo)
        {
            Clases.cPageBase pb = new cPageBase();
            DataTable _dtResult = new DataTable();

            string Query = "Select PR.CveRegla, PR.CvePerfil, CR.Descripcion From PerfilRegla PR Left Join CatPerfiles CP on PR.CvePerfil=CP.CvePerfil Left Join CatModulos CM on PR.CveModulo=CM.CveModulo Left Join CatReglas CR on PR.CveRegla=CR.CveRegla Where PR.CvePerfil=" + CvePerfil + " And PR.CveModulo=" + CveModulo;

            _dtResult = pb.SP_DataReaderQuery(Query);
                                                  
            return _dtResult;
        }

        public static DataTable ReadModuloPerfil(int CvePerfil)
        {
            Clases.cPageBase pb = new cPageBase();
            DataTable _dtResult = new DataTable();

            string Query = "Select distinct(PR.CveModulo) As CveModulo, CM.Descripcion From PerfilRegla PR Left Join CatPerfiles CP on PR.CvePerfil=CP.CvePerfil Left Join CatModulos CM on PR.CveModulo=CM.CveModulo Where PR.CvePerfil=" + CvePerfil;

            _dtResult = pb.SP_DataReaderQuery(Query);

            return _dtResult;
        }



    }
}
