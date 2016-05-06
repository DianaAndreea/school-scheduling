using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{
    class Utils
    {

           public static DataSet Display(String query)
        {
            SqlConnection connection = null;
            DataSet table = null; 
            try 
            {
                connection = DatabaseConnection.Instance.getDatabaseConnection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand comand = connection.CreateCommand();
                comand.CommandText = query;
                adapter.SelectCommand = comand;
                table = new DataSet();
                adapter.Fill(table);

            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //connection.Close();
                DatabaseConnection.Instance.getDatabaseConnection().Close();
            }

            return table;
        }
        
    }





    
}
