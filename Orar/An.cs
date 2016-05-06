using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{
    class An
    {
        private int codAn;
        private int an;
        private int codGrupa;
        private SqlConnection connection = null;
        private SqlConnection connection1 = null;
        public int CodAn
        {
            get { return codAn; }
            set { codAn = value; }
        }
        public int Anul
        {
            get { return an; }
            set { an = value; }
        }
        public int CodGrupa
        {
            get { return codGrupa; }
            set { codGrupa = value; }
        }

        public  An()
        {
           

        }
        public void Insert(int an, String grupa,String subgrupa)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT into An(an, cod_gr) VALUES ("+an+",(SELECT distinct cod_gr from Grupa g, Subgrupa s WHERE g.cod_sg = s.cod_sg and g.grupa='"+grupa+"' and s.subgrupa='"+subgrupa+"'));";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

        }
        public void Update(int newAn,int oldAn)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE An SET an="+ newAn + " where an=" + oldAn + ";";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
        public void Delete(int an)
        {
            
            connection1 = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM An where cod_an='" +an + "';";
            cmd.Connection = connection1;
            cmd.ExecuteNonQuery();
        }
        public int getGrupaId(String an)
        {
            int id = 0; 
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("Select cod_an FROM An where an='" + an + "'", connection);
            SqlDataReader myreader;
            myreader = SelectCommand.ExecuteReader();
            while (myreader.Read())
            {
                id = Convert.ToInt16(myreader[0].ToString());
            }
          connection.Close();
            return id;
        }

    }
}
