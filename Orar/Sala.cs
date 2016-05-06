using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
    
namespace Orar
{
using System;
using System.Collections.Generic;
    
public  class Sala
{
    private int codSala;
    private string nume;
    private int capacitate;
    private string tip;
    private SqlConnection connection;

        public int CodSala
        {
            get { return codSala; }
            set { codSala = value; }
        }
        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public int Capacitate
        {
            get { return capacitate; }
            set { capacitate = value; }
        }

        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public void Insert(int codSala, string nume, int capacitate, string tip)
        {
           
                connection = DatabaseConnection.Instance.getDatabaseConnection();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Sala (nume, capacitate, tip) values ('" + nume + "','" + capacitate + "','" + tip + "');";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

         
        }
        public void Update(int codSala, string nume, int capacitate, string tip)
        {
            try
            {
                connection = DatabaseConnection.Instance.getDatabaseConnection();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Sala SET nume='" + nume + "', capacitate='" + capacitate + "', tip='" + tip + "' WHERE cod_s='" + codSala + "';";
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
        public void Delete(int codSala)
        {
            try
            {
                connection = DatabaseConnection.Instance.getDatabaseConnection();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM Sala WHERE cod_s='" + codSala + "';";
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
    }
}
