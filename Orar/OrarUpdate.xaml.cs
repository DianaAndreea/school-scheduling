using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Orar
{
/// <summary>
/// Interaction logic for OrarUpdate.xaml
/// </summary>
public partial class OrarUpdate : Window
{
    private static bool _isOpen;
    private SqlConnection connection = null;
    public static String oraOrar;
    public static String disciplina;
    public static String profesor;
    public static String tip;
    public static String modul;
    public static String sala;
    public static String ziua;
    public static String subgrupa;
    public static String saptamana;
    public static DataGridCellInfo selectedCell;
    public static bool isAdd;
    private List<String> listaProfesori = new List<String>();
    private List<String> listaDiscipline = new List<String>();
    private List<String> listaSali = new List<String>();

        public OrarUpdate()
        {
            InitializeComponent();

            DiscipinaCombo.ItemsSource = adaugaDisciplina();
            ProfesorCombo.ItemsSource = adaugaProfesor();
            AnText.Text = OrarWin.GetAnComboBox().ToString();
            GrupaText.Text = OrarWin.GetGrupaComboBox();
            SubgrupaText.Text = OrarWin.GetSubgrupaComboBox();
         }

        public static bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
            }
        }

        private void Grid_Unloaded_1(object sender, RoutedEventArgs e)
        {
            _isOpen = false;
        }

        private void backm_click(object sender, RoutedEventArgs e)
        {
            OrarWin orarW = new OrarWin();
            orarW.Show();
            this.Close();
        }
        private List<string> adaugaDisciplina()
        {
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT denumire FROM Disciplina where an='"+OrarWin.GetAnComboBox()+"'", connection);
            SqlDataReader myreader;
            myreader = SelectCommand.ExecuteReader();

            //List<String> lstEmails = new List<String>();
            while (myreader.Read())
            {
                listaDiscipline.Add(myreader[0].ToString());
            }
            connection.Close();
            return listaDiscipline;

        }
        private List<string> adaugaProfesor()
        {

            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT nume FROM Profesor", connection);
            SqlDataReader myreader;
            myreader = SelectCommand.ExecuteReader();

            //List<String> lstEmails = new List<String>();
            while (myreader.Read())
            {
               listaProfesori.Add(myreader[0].ToString());
            }
            connection.Close();


            return listaProfesori;

        }

        private List<string> adaugaSala()
        {
            tip = TipCombo.Text;
            connection = DatabaseConnection.Instance.getDatabaseConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT nume FROM Sala where tip='" + tip.Trim() + "'", connection);
            SqlDataReader myreader;
            myreader = SelectCommand.ExecuteReader();

            //List<String> lstEmails = new List<String>();
            while (myreader.Read())
            {
                listaSali.Add(myreader[0].ToString());
            }
            connection.Close();
            return listaSali;

        }

        public String getOra()
        {
            return oraOrar;
        }

        public String getDisciplina()
        {
            return disciplina;
        }

        public String getProfesor()
        {
            return profesor;
        }
        public String getModul()
        {
            return modul;
        }

        public String getTip()
        {
            return tip;
        }
        public String getSala()
        {
            return sala;
        }
        public void setSelectedCell(DataGridCellInfo cell)
        {
            selectedCell = cell;
            ObiectOrar item = selectedCell.Item as ObiectOrar;
            OraText.Text = item.Ora;
        }

        private void adauga(object sender, RoutedEventArgs e)
        {
            disciplina = DiscipinaCombo.Text;
            profesor = ProfesorCombo.Text;
            sala = SalaCombo.Text;
            modul = ModulCombo.Text;
            subgrupa = OrarWin.GetSubgrupaComboBox();
            saptamana = OrarWin.GetSaptamanaComboBox();
            

            MessageBox.Show("Saved");
            isAdd = true;
            OrarWin orar = new OrarWin();
            orar.Show();
            this.Close();

        }
        private void click(object sender, EventArgs e)
        {
            SalaCombo.ItemsSource = adaugaSala();         
               
        }
        public List<String> getListaProfesori() {
            return listaProfesori;
        }
        public List<String> getListaDiscipline() {
            return listaDiscipline;
        }
        public List<String> getListaSali() {
            return listaSali;
        }
    }
}
