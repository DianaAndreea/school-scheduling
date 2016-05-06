using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{
    
    
    public  class Subgrupa
    {


        public int codSubgrupa;
        public string subgrupa;
        private SqlConnection connection = null;

        public int CodSubgrupa
        {
            get { return codSubgrupa; }
            set { codSubgrupa = value; }
        }
        public string Subgrp
        {
            get { return subgrupa; }
            set { subgrupa = value; }
        }

        public void Insert(String subgrupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT into Subgrupa VALUES ('" + subgrupa + "')";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

        }
        public void Update(String newSubgrupa,String oldSubgrupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Subgrupa SET subgrupa='" + newSubgrupa + "' where subgrupa='" + oldSubgrupa + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
        public void Delete(String subgrupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Subgrupa where subgrupa='" + subgrupa + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public List<String> Display(String grupa)
        {

            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("Select g.subgrupa FROM Subgrupa g, Grupa a where g.cod_sg=a.cod_sg and a.grupa='" + grupa.Trim()+"'", connection);
            SqlDataReader myreader;
            myreader = SelectCommand.ExecuteReader();

            List<String> lstEmails = new List<String>();
            while (myreader.Read())
            {
                lstEmails.Add(myreader[0].ToString());
            }
            connection.Close();
            return lstEmails;
        }
    }
}
