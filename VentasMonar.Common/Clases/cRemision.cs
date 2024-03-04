using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMonar.Desktop.Clases;
using static VentasMonar.Desktop.PageBase;

namespace VentasMonar.Desktop.Clases
{
    class cRemision
    {
        public int CveNota { get; set; }
        public int CveTipoDocumento { get; set; }
        public int CveEstatusDocumento { get; set; }
        public string  Message { get; set; }

        public bool Cancelar()
        {
            bool _result = false;

            cPageBase cPage = new cPageBase();

            using (SqlConnection connection = new SqlConnection(Strconexion))
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

                    //string Query="Select CveTipoDocumento From Ventas Where CveNota"

                    switch(CveTipoDocumento)
                    {
                        case 1:
                            CveEstatusDocumento = 3;
                            break;
                        case 4:
                            CveEstatusDocumento = 14;
                            break;
                    }



                    string Query = "Update Ventas set CveEstatusDocumento=" + CveEstatusDocumento + " Where CveNota=" + CveNota;

                    command.CommandText = Query;
                    command.ExecuteNonQuery();


                    string QueryDetalle = "Select CveNota, CveProducto, CveAlmacen, Cantidad From VentasDetalle Where CveNota=" + CveNota;

                    DataTable _dtDetalles = cPage.SP_DataReaderQuery(QueryDetalle,connection,transaction);

                    double CantidadInventario = 0;

                    foreach (DataRow item in _dtDetalles.Rows)
                    {

                        string QueryCantidadInventario= "Select isnull(Cantidad, 0) As Cantidad From ProductoColor Where CveProducto = " + item["CveProducto"].ToString() + " And CveAlmacen = " + item["CveAlmacen"].ToString();


                        CantidadInventario = double.Parse(cPage.GetStrFieldQuery("Cantidad",QueryCantidadInventario,connection,transaction));

                        string QueryExistencia = "Update ProductoColor Set Cantidad=Cantidad + " + item["Cantidad"].ToString() + " Where CveProducto=" + item["CveProducto"].ToString() + " And CveAlmacen=" + item["CveAlmacen"].ToString();

                        string QueryInsertMov = "Insert Into MovimientosInventario(CveTipoMovimiento,CveProducto,Habia,Cantidad,CveUser,Hora,Fecha, CveAlmacen, CveOrigen) Values(4," + item["CveProducto"].ToString() + "," + CantidadInventario + "," + item["Cantidad"].ToString() + "," + CveUser.Cve_User + ",'" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortTimeString() + "'," + item["CveAlmacen"].ToString() + ",1)";


                        command.CommandText = QueryExistencia;
                        command.ExecuteNonQuery();

                        command.CommandText = QueryInsertMov;
                        command.ExecuteNonQuery();


                    }
                    transaction.Commit();
                    _result = true;
                }
                catch (Exception ex)
                {
                    Message +="Commit Exception Type: " + ex.GetType() + Environment.NewLine;
                    Message +="Message: " + ex.Message + Environment.NewLine;

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
                       Message += "Rollback Exception Type: " + ex2.GetType() + Environment.NewLine;
                       Message +="Message: " + ex2.Message + Environment.NewLine;
                    }
                }

            }

                return _result;
        }


    }
}
