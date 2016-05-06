using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orar
{
    class Disciplina
    {
        private int codDisciplina;
        private String denumire;
        private int an;
        private int sem;
        private int nrOreCurs;
        private int nrOreLaborator;
        private int nrOreSeminar;
        private int nrOreProiect;
        private SqlConnection connection = null;

        public int CodDisciplina
        {
            get { return codDisciplina; }
            set { codDisciplina = value; }
        }
        public String Denumire
        {
            get { return denumire; }
            set { denumire = value; }
        }
        public int An
        {
            get { return an; }
            set { an = value; }
        }
        public int Sem
        {
            get { return sem; }
            set { sem = value; }
        }
        public int NrOreCurs
        {
            get { return nrOreCurs; }
            set { nrOreCurs = value; }
        }
        public int NrOreSeminar
        {
            get { return nrOreSeminar; }
            set { nrOreSeminar = value; }
        }
        public int NrOreLaborator
        {
            get { return nrOreLaborator; }
            set { nrOreLaborator = value; }
        }       
        public int NrOreProiect
        {
            get { return nrOreProiect; }
            set { nrOreProiect = value; }
        }

        public void Insert(String denumire, int nrOreCurs, int nrOreSeminar, int nrOreLaborator, int nrOreProiect, int an, int sem)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Disciplina(denumire, nr_ore_c, nr_ore_s, nr_ore_l, nr_ore_p, an, sem) VALUES ('" + denumire + "','" + nrOreCurs + "','" + nrOreSeminar + "','" + nrOreLaborator + "','" + nrOreProiect + "','" + an + "','" + sem + "');";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
         }

        public void Update(int id, String denumire, int nrOreCurs, int nrOreSeminar, int nrOreLaborator, int nrOreProiect, int an, int sem)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Disciplina SET denumire='" + denumire + "', nr_ore_c='" + nrOreCurs + "', nr_ore_s='" + nrOreSeminar + "', nr_ore_l='" + nrOreLaborator + "', nr_ore_p='" + nrOreProiect + "', an='" + an + "', sem='" + sem + "' WHERE cod_d='" + id + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Disciplina WHERE cod_d='" + id + "';";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
    }
}
