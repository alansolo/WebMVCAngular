
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class BD
    {
        private SqlConnection sqlConnection;
        private SqlCommand command;
        protected string connectionString;

        public BD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BD_FORMULARIO"].ToString();
        }
        public BD(string dataBaseConnection)
        {
            connectionString = ConfigurationManager.ConnectionStrings[dataBaseConnection].ToString();
        }
        protected object ExecuteScalar(string spName, List<SqlParameter> parameters)
        {
            object result = new object();
            //object uno = new object();
            StringBuilder str = new StringBuilder();

            //SqlDatabase db = new SqlDatabase(connectionString);
            //DbCommand command1; 

            DataSet dataSet = null;
            DataTable dataTable = new DataTable();

            using (sqlConnection = new SqlConnection(connectionString))
            //using (DbConnection con = db.CreateConnection())
            {
                try
                {
                    //command1 = con.CreateCommand();


                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (SqlParameter item in parameters)
                        command.Parameters.Add(item);

                    command.Connection = sqlConnection;
                    sqlConnection.Open();
                    //result = (string)db.ExecuteScalar(command1);
                    //uno = command.ExecuteReader();

                    //str.Append(db.ExecuteScalar(command1));

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataSet = new DataSet("dsResult");
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        dataTable = dataSet.Tables[0];
                    }

                    result = dataTable;
                }
                catch (Exception ex)
                {
                    //Write log error
                    //ArchivoLog.EscribirLog(null, DateTime.Now.ToString("dd/MM/yyyy mm:ss") + ": Method: " + ex.Source + " Error: " + ex.Message);
                    throw ex;
                }
            }

            return result;
        }
        

    }
}
