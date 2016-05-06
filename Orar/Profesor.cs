using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Orar
{ 
    public  class Profesor
    {
        private int codProf;
        private string nume;
        private string prenume;
        private SqlConnection connection;

        public int CodProf
        {
            get { return codProf; }
            set { codProf = value; }
        }
        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public string Prenume
        {
            get { return prenume; }
            set { prenume = value; }
        }


        public  void Insert(string nume, string prenume)
        {
            try
            {
                connection = DatabaseConnection.Instance.getDatabaseConnection();

               
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Profesor(nume, prenume) VALUES ('" + nume + "','" + prenume + "')";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public void Update(int codp, String nume, String prenume)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Profesor SET nume='" + nume + "', prenume='" + prenume + "' WHERE cod_p='" + codp + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Profesor WHERE cod_p='" + id + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
    }
}
