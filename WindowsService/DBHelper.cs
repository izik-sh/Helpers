using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public class DBHelper
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static DataTable GetDataTable(string query, string[] sqlParameters, object[] sqlParametersValues, bool isStoredProcedure = true)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        if (sqlParameters != null)
                        {
                            for (int c = 0; c < sqlParameters.Length; c++)
                            {
                                command.Parameters.Add(new SqlParameter(sqlParameters[c], sqlParametersValues[c]));
                            }
                        }

                        if (!isStoredProcedure)
                        {
                            command.CommandType = CommandType.Text;
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return dt;
        }

    }
}
