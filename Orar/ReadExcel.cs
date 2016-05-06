using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace Orar
{
    class ReadExcel
    {
        public String nume;
        public String prenume;
        public String denumireDisciplina;
        public int nr_ore_c;
        public int nr_ore_l;
        public int nr_ore_p;
        public int nr_ore_s;
        public int an;
        public int sem;

      public void InSertProfesorExcel(String Path)
        {
            Excel.Workbook MyBook = null;
            Excel.Application MyApp = null;
            Excel.Worksheet MySheet = null;
            Excel.Range range = null;
            Excel.Workbooks MyBooks = null;
            try
            {

                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBooks = MyApp.Workbooks;
                MyBook = MyBooks.Open(@Path);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1];
                range = MySheet.UsedRange;
                int nr = range.Rows.Count;
                // Check dates
                int i = 0;
                while (i < nr)
                {
                    i++;
                    nume = (MySheet.Cells[i, 1]).Value2;
                    prenume = (MySheet.Cells[i, 2]).Value2;
                    Profesor profesor = new Profesor();
                    profesor.Insert(nume, prenume);              
               }
             }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                MyBook.Close();
            }
        }


        public void InSertDisciplinaExcel(String Path)
        {
            Excel.Workbook MyBook = null;
            Excel.Application MyApp = null;
            Excel.Worksheet MySheet = null;
            Excel.Range range = null;
            Excel.Workbooks MyBooks = null;
            SqlConnection connection = null;
            try
            {
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBooks = MyApp.Workbooks;
                MyBook = MyBooks.Open(@Path);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1];
                range = MySheet.UsedRange;
                int nr = range.Rows.Count;
                
                // Check dates
                int i = 0;
                while (i < nr)
                {
                    i++;
                    denumireDisciplina = (MySheet.Cells[i, 1]).Value2;
                    nr_ore_c = Convert.ToInt16((MySheet.Cells[i, 2]).Value2);
                    nr_ore_s = Convert.ToInt16((MySheet.Cells[i, 3]).Value2);
                    nr_ore_l = Convert.ToInt16((MySheet.Cells[i, 4]).Value2);
                    nr_ore_p = Convert.ToInt16((MySheet.Cells[i, 5]).Value2);
                    an = Convert.ToInt16((MySheet.Cells[i, 6]).Value2);
                    sem = Convert.ToInt16((MySheet.Cells[i, 7]).Value2);

                    Disciplina disciplina = new Disciplina();
                    disciplina.Insert(denumireDisciplina, nr_ore_c, nr_ore_s, nr_ore_l, nr_ore_p, an, sem);
                    
                    //connection = DatabaseConnection.Instance.getDatabaseConnection();
                    //SqlCommand comand = connection.CreateCommand();
                    //comand.CommandType = System.Data.CommandType.Text;
                    //comand.CommandText = "INSERT INTO Disciplina(denumire, nr_ore_c, nr_ore_s, nr_ore_l, nr_ore_p, an, sem) VALUES ('" + denumireDisciplina + "','" + nr_ore_c + "','" + nr_ore_l + "','" + nr_ore_s + "','" + nr_ore_p + "','" + an + "','" + sem + "');";
                    //comand.Connection = connection;
                    //comand.ExecuteNonQuery();

                }
             }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                //connection.Close();
                MyBook.Close();
              
            }
        }
    }
}
