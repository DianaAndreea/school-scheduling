using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.Globalization;

namespace Orar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OrarWin : Window
    {
        private static OrarWin _instance;
        public static bool _isOpenW = false;
        private SqlConnection connection;
        private String oraOrar = "";
        private String disciplina = "";
        private String profesor = "";
        private String tip = "";
        private String modul = "";
        private String grupa = "";
        private static String subgrupa = "";
        private static String saptamana = "";
        private String sala = "";
        public static String ora = "";
        private String ziua = "";
        public static bool isLoad = false;
        public static bool isSters = false;
        private static List<ObiectOrar> list;
        public OrarUpdate orarUpdate;
        private static int AnComboBox;
        private static String GrupaComboBox;
        private static String SubgrupaComboBox;
        private static String SaptamanaComboBox;

        public OrarWin()
        {
            InitializeComponent();
           
           // _isOpenW = true;
            if (OrarUpdate.isAdd == true)
            {
                disciplina = OrarUpdate.disciplina;
                profesor = OrarUpdate.profesor;
                sala = OrarUpdate.sala;
                modul = OrarUpdate.modul;
                grupa = GrupaComboOrar.Text;
                subgrupa = OrarUpdate.subgrupa;
                saptamana = OrarUpdate.saptamana;
                
                Grupa gr = new Grupa();
               
                SetSelectedCellValue(OrarUpdate.selectedCell);
              
         
            }

            if (isLoad == true)
            { foreach (ObiectOrar obiect in list)
                {if (obiect.Ora == ora)
                {
                    if (ziua == "Luni")
                    { obiect.Luni = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:"+subgrupa+"\n sapt."+saptamana; }
                    else if (ziua == "Marti")
                    { obiect.Marti = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else if (ziua == "Miercuri")
                    { obiect.Miercuri = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else if (ziua == "Joi")
                    { obiect.Joi = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else
                    { obiect.Vineri = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                  }
                }
                updateList(list);
                OrarGrid.ItemsSource = getListOfObjects(); 
            }
            else
            {
                list = getListOfObjects();
                OrarGrid.ItemsSource = getListOfObjects();
                isLoad = true;
            }
            isSters = false;
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _isOpenW = false;
        }
        private void back_click(object sender, RoutedEventArgs e)
        {
            Princ princ = new Princ();
            princ.Show();
            this.Close();
        }

        private void clickForUpdate(object sender, MouseButtonEventArgs e) // event on Double Click
        {
            if (!OrarUpdate.IsOpen)
            {
                OrarUpdate UpdateInfo = new OrarUpdate();
                UpdateInfo.setSelectedCell(OrarGrid.SelectedCells[0]);
               
                UpdateInfo.Show();
                this.Close();
            }
            OrarUpdate.IsOpen = true;
        }

        public void SetSelectedCellValue(DataGridCellInfo cells)
        {
            //DataGridCellInfo cells = OrarGrid.SelectedCells[0];
            ObiectOrar item = cells.Item as ObiectOrar;
            string columnName = cells.Column.SortMemberPath;
            PropertyInfo propertyInfo = item.GetType().GetProperty(columnName);
            String s = profesor;
            ora = item.Ora;
            ziua = columnName;
            String[] p= ora.Split(':');
            if(OrarUpdate.modul=="2 h"){
                String newHour = Convert.ToInt16(p[0]) + 1 + ":00";
                modulMethod(newHour);
            }
            if (OrarUpdate.modul == "3 h")
            {
                String newHour = Convert.ToInt16(p[0]) + 2 + ":00";
                modulMethod(Convert.ToInt16(p[0]) + 1 + ":00");
                modulMethod(newHour);

            }
            if (OrarUpdate.modul == "4 h")
            {
                String newHour = Convert.ToInt16(p[0]) + 3 + ":00";
                modulMethod(Convert.ToInt16(p[0]) + 1 + ":00");
                modulMethod(Convert.ToInt16(p[0]) + 2 + ":00");
                modulMethod(newHour);
            }
            propertyInfo.SetValue(item, s, null);
        }

        

        public String GetSelectedCellValue()
        {
            DataGridCellInfo cells = OrarGrid.SelectedCells[0];
            ObiectOrar item = cells.Item as ObiectOrar;
            ora = item.Ora;
            string columnName = cells.Column.SortMemberPath;
            if (item == null || columnName == null) return null;
            object result = item.GetType().GetProperty(columnName).GetValue(item, null);
            if (result == null) return null;
            return result.ToString();
        }

        private void insertListOfObj(List<ObiectOrar> list1){
            
                connection = DatabaseConnection.Instance.getDatabaseConnection();
                foreach(ObiectOrar obj1 in list1){
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO TableOrar values ('" + obj1.Ora + "','" + obj1.Luni + "','"+obj1.Marti+"','"+ obj1.Miercuri + "','" + obj1.Joi + "','"+obj1.Vineri+"');";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                }
        }

        private void updateList(List<ObiectOrar> list1)
        {

            connection = DatabaseConnection.Instance.getDatabaseConnection();
            foreach (ObiectOrar obj1 in list1)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE TableOrar SET Luni='" + obj1.Luni.Trim() + "', Marti='" + obj1.Marti.Trim() + "', Miercuri='" + obj1.Miercuri.Trim() + "',Joi='" + obj1.Joi.Trim() + "', Vineri='" + obj1.Vineri.Trim() + "' WHERE Modul='" + obj1.Ora + "';";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }

        private List<ObiectOrar> getListOfObjects()
        {

            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT Modul,Luni,Marti,Miercuri,Joi,Vineri FROM TableOrar", connection);
            SqlDataReader myreader;
            myreader = SelectCommand.ExecuteReader();

            List<ObiectOrar> lst = new List<ObiectOrar>();
            while (myreader.Read())
            {
                ObiectOrar obiectOrar = new ObiectOrar();
                obiectOrar.Ora = myreader[0].ToString().Trim();
                obiectOrar.Luni = myreader[1].ToString().Trim();
                obiectOrar.Marti = myreader[2].ToString().Trim();
                obiectOrar.Miercuri = myreader[3].ToString().Trim();
                obiectOrar.Joi = myreader[4].ToString().Trim();
                obiectOrar.Vineri = myreader[5].ToString().Trim();
                lst.Add(obiectOrar);
            }
            connection.Close();
            return lst;
        }


        private void exportPdf_Click(object sender, RoutedEventArgs e)
        {
            PdfPTable table = new PdfPTable(OrarGrid.Columns.Count);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("ExcelOrar.pdf", System.IO.FileMode.Create));
            doc.Open();
            var FontColour = new BaseColor(0, 0, 255);
            var Calibri8 = FontFactory.GetFont("Andy", 25, FontColour);
            PdfPCell pcell = new PdfPCell(new Phrase(" Orar CTI-2016 Anul "+AnComboOrar.Text+"  Grupa "+GrupaComboOrar.Text,Calibri8));
            pcell.Colspan = 6;
            pcell.HorizontalAlignment = 1;
            table.AddCell(pcell);
            var FontColour1 = new BaseColor(0, 0, 0);
            var Calibri9 = FontFactory.GetFont("Comic Sans MS", 12, FontColour1);
            for (int j = 0; j < OrarGrid.Columns.Count; j++)
            {
              
                table.AddCell(new Phrase(OrarGrid.Columns[j].Header.ToString(), Calibri9));
            }
            table.HeaderRows = 1;
            IEnumerable itemsSource = OrarGrid.ItemsSource as IEnumerable;
            if (itemsSource != null)
            {
              //  iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("an,grupa,subgrupa");
                foreach (var item in itemsSource)
                {
                    DataGridRow row = OrarGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < OrarGrid.Columns.Count; ++i)
                        {
                            System.Windows.Controls.DataGridCell cell = (System.Windows.Controls.DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text, Calibri9));
                            }
                        }
                    }
                }
               // doc.Add(p);
                doc.Add(table);
                doc.Close();
            }
        }



        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
     where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }

            return null;
        }




        

        private void modulMethod(String str)
        {
            foreach (ObiectOrar obiect in list)
            {
                if (obiect.Ora == str)
                {
                    if (ziua == "Luni")
                    { obiect.Luni = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else if (ziua == "Marti")
                    { obiect.Marti = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else if (ziua == "Miercuri")
                    { obiect.Miercuri = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else if (ziua == "Joi")
                    { obiect.Joi = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                    else
                    { obiect.Vineri = disciplina + "-" + profesor.Trim(' ') + "(" + sala.Trim(' ') + ")-sg:" + subgrupa + "\n sapt." + saptamana; }
                }
            }
            updateList(list);
            OrarGrid.ItemsSource = getListOfObjects(); 

        }

        private void click1(object sender, EventArgs e)
        {
            try
            {
                GrupaComboBox = GrupaComboOrar.Text;
                Subgrupa gr = new Subgrupa();
                SubgrupaComboOrar.IsEnabled = true;
                SubgrupaComboOrar.ItemsSource = gr.Display(GrupaComboBox);
            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.ToString());
                SubgrupaComboOrar.IsEnabled = false;
            }
            
        }

        private void clik2(object sender, EventArgs e)
        {
            try
            {
                SubgrupaComboBox = SubgrupaComboOrar.Text;
                OrarGrid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                OrarGrid.IsEnabled = false;
            }
        }

        private void StergeRandul(object sender, RoutedEventArgs e)
        {
            disciplina ="";
            profesor = "";
            sala ="";
            modul = "";
            isSters = true;
            System.Windows.MessageBox.Show("Sters");
            DataGridCellInfo cells = OrarGrid.SelectedCells[0];             
            ObiectOrar item = cells.Item as ObiectOrar;
            string columnName = cells.Column.SortMemberPath;
            PropertyInfo propertyInfo = item.GetType().GetProperty(columnName);
            String s = profesor;
            ora = item.Ora;
            ziua = columnName;
              
            if (isLoad == true)
            { foreach (ObiectOrar obiect in list)
                {if (obiect.Ora == ora)
                {
                    if (ziua == "Luni")
                    { obiect.Luni = "       "; }
                    else if (ziua == "Marti")
                    { obiect.Marti = "        ";}
                    else if (ziua == "Miercuri")
                    {obiect.Miercuri ="        ";}
                    else if (ziua == "Joi")
                    {obiect.Joi = "          ";}
                    else if(ziua == "Vineri")
                    { obiect.Vineri = "       "; }
                  }
                }
                updateList(list);
                OrarGrid.ItemsSource = getListOfObjects(); 
            }
           
           
        }

        private void AnComboOrar_DropDownClosed(object sender, EventArgs e)
        {
            try {
                
                AnComboBox = Int32.Parse(AnComboOrar.Text);
                Grupa gr = new Grupa();
                GrupaComboOrar.IsEnabled = true;
                GrupaComboOrar.ItemsSource = gr.Display(AnComboOrar.Text);
                SubgrupaComboOrar.ItemsSource = null;
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Selectati un an");
                OrarGrid.IsEnabled = false;
                GrupaComboOrar.IsEnabled = false;
                SubgrupaComboOrar.IsEnabled = false;
            }
        }

        public static int GetAnComboBox()
        {
            return AnComboBox;
        }

        public static String GetGrupaComboBox()
        {
            return GrupaComboBox;
        }

        public static String GetSubgrupaComboBox()
        {
            
            return SubgrupaComboBox;
        }
        public static String GetSaptamanaComboBox()
        {
            
            return SaptamanaComboBox;
        }

        private void saptClick(object sender, EventArgs e)
        {
            SaptamanaComboBox = SaptComboOrar.Text;
        }
        }
}
       
    

