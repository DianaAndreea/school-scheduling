using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Data;

namespace Orar
{
    public sealed class DatabaseConnection
    {
        private SqlConnection connection;
        private static DatabaseConnection instance = null;
        private static readonly object padlock = new object();

        public static DatabaseConnection Instance
        {
            get
            {
                lock (padlock)
                { 
                    if(instance == null)
                    {
                        instance = new DatabaseConnection();
                    }
                    return instance;
                }
            }
        }

        public  SqlConnection getDatabaseConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                try
                {
                    connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\FACULTATE\AN 4\PIE\ORAR\ORAR\ORARDATABASE.MDF;Integrated Security=True");
                    if(connection.State != ConnectionState.Open)
                     connection.Open();

                }catch(SqlException exeption)
                {
                    MessageBox.Show(exeption.Message);
                }
                
            }
            return connection;
        }
    }
}
