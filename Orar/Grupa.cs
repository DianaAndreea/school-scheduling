using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Orar
{


    public partial class Grupa
    {
        private int codGrupa;
        private String grupa;
        private int codSubgrupa;
        private SqlConnection connection = null;

        public int CodGrupa
        {
            get { return codGrupa; }
            set { codGrupa = value; }
        }
        public String Grp
        {
            get { return grupa; }
            set { grupa = value; }
        }
        public int CodSubGrupa
        {
            get { return codSubgrupa; }
            set { codSubgrupa = value; }
        }

        public void Insert(String grupa, String subgrupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT into Grupa VALUES ('" + grupa + "',(SELECT distinct cod_sg from Subgrupa WHERE subgrupa='"+subgrupa+"'));";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

        }
        public void Update(String newGrupa, String oldSubgrupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Grupa SET grupa='" + newGrupa + "' where grupa='" + oldSubgrupa + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
        public void Delete(String grupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Grupa where grupa='" + grupa + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public List<String> Display(String an)
        {

            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("Select DISTINCT g.grupa FROM Grupa g, An a where g.cod_gr=a.cod_gr and an=" + an, connection);
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
