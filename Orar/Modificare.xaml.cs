using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Modificare : Window
    {
        public static bool isUpdateDisciplina;
        public static bool isInsertDisciplina;
        public static bool isUpdateProfesor;
        public static bool isInsertProfesor;
        public static bool isUpdateSala;
        public static bool isInsertSala;
        public static bool isUpdatePromotie;
        public static bool isInsertPromotie;
        public static int Id;
        public static String an;
        public static String grupa;
        public static String subgrupa;
        ReadExcel excel = new ReadExcel();

        public Modificare()
        {
            InitializeComponent();

            if (Administrare.isProfesor == true)
            {
                TabelModificare.ItemsSource = Utils.Display("Select cod_p AS ID, nume AS Nume, prenume AS Prenume from Profesor").Tables[0].DefaultView;
                btnExcel.Visibility = Visibility.Visible;
            }
            else if (Administrare.isDisciplina == true)
            {
                TabelModificare.ItemsSource = Utils.Display("Select cod_d AS ID, denumire AS Disciplina, nr_ore_c AS OreCurs, nr_ore_s AS OreSeminar, nr_ore_l AS OreLaborator, nr_ore_p AS OreProiect, an AS An, sem AS Semestru from Disciplina").Tables[0].DefaultView;
                btnExcel.Visibility = Visibility.Visible;
            }
            else if (Administrare.isSali == true)
            {
                TabelModificare.ItemsSource = Utils.Display("Select cod_s AS ID, nume AS Nume, capacitate AS Capacitate, tip AS Tip from Sala").Tables[0].DefaultView;
            }
            if (Administrare.isPromotie == true)
            {
                TabelModificare.ItemsSource = Utils.Display("Select an AS An, grupa AS Grupa, subgrupa AS Subgrupa from promotie").Tables[0].DefaultView;
            }
        }

        private void backm_click(object sender, RoutedEventArgs e)
        {
            Administrare adm = new Administrare();
            adm.Show();
            this.Close();
        }

        private void btnAdauga_Click(object sender, RoutedEventArgs e)
        {
            if (Administrare.isDisciplina == true)
            {
                isInsertDisciplina = true;
                Discipline adaugaDisciplina = new Discipline();
                adaugaDisciplina.Show();
                this.Close();

            }
            else if (Administrare.isProfesor == true)
            {
                isInsertProfesor = true;
                Profesori adaugaProfesori = new Profesori();
                adaugaProfesori.Show();
                this.Close();
            }
            else if (Administrare.isSali == true)
            {
                isInsertSala = true;
                Sali adaugaSali = new Sali();
                adaugaSali.Show();
                this.Close();

            }

            else  if(Administrare.isPromotie == true){
                isInsertPromotie = true;
                isUpdatePromotie = false;
                Promotie adaugaProm = new Promotie();
                adaugaProm.Show();
                this.Close();
            }
        }


        private void Sterge_Click(object sender, RoutedEventArgs e)
        {
            if (Administrare.isDisciplina == true)
            {
                Disciplina disciplina = new Disciplina();
                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                disciplina.Delete(Convert.ToInt16(row.Row["ID"].ToString()));
                TabelModificare.ItemsSource = Utils.Display("Select cod_d AS ID, denumire AS Disciplina, nr_ore_c AS OreCurs, nr_ore_s AS OreSeminar, nr_ore_l AS OreLaborator, nr_ore_p AS OreProiect, an AS An, sem AS Semestru from Disciplina").Tables[0].DefaultView;

            }
            else if (Administrare.isProfesor == true)
            {
                Profesor profesor = new Profesor();
                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                profesor.Delete(Convert.ToInt16(row.Row["ID"].ToString()));
                TabelModificare.ItemsSource = Utils.Display("Select cod_p AS ID, nume AS Nume, prenume AS Prenume from Profesor").Tables[0].DefaultView;

            }
            else if (Administrare.isSali == true)
            {
                Sala sala = new Sala();
                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                sala.Delete(Convert.ToInt16(row.Row["ID"].ToString()));
                TabelModificare.ItemsSource = Utils.Display("Select Select cod_s AS ID, nume AS Nume, capacitate AS Capacitate, tip AS Tip from Sala ").Tables[0].DefaultView;

            }

            else  if (Administrare.isPromotie == true)
            {
                An an = new An();
                Grupa grupa = new Grupa();
                Subgrupa subgrupa = new Subgrupa();
                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                //subgrupa.Delete(row.Row["subgrupa"].ToString());
                //grupa.Delete(row.Row["grupa"].ToString());
                int a= an.getGrupaId(row.Row["An"].ToString());
                an.Delete(a);
              
                TabelModificare.ItemsSource = Utils.Display("Select an AS An, grupa AS Grupa, subgrupa AS Subgrupa from promotie").Tables[0].DefaultView;
            }
        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {
            if (Administrare.isDisciplina == true)
            {
                isUpdateDisciplina = true;
                Disciplina disciplina = new Disciplina();

                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                Id = Convert.ToInt16(row.Row["ID"].ToString());               
                
                Discipline adaugaDisciplina = new Discipline();

                //adaugaDisciplina.codD.Text = row.Row["ID"].ToString();
                adaugaDisciplina.denumire.Text = row.Row["Disciplina"].ToString();
                adaugaDisciplina.oreCurs.Text = row.Row["OreCurs"].ToString();
                adaugaDisciplina.oreSeminar.Text = row.Row["OreSeminar"].ToString();
                adaugaDisciplina.oreLab.Text = row.Row["OreLaborator"].ToString();
                adaugaDisciplina.oreProiect.Text = row.Row["OreProiect"].ToString();
                adaugaDisciplina.an.Text = row.Row["An"].ToString();
                adaugaDisciplina.sem.Text = row.Row["Semestru"].ToString();

                adaugaDisciplina.Show();
                this.Close();
             }
            else if (Administrare.isProfesor == true)
            {
                isUpdateProfesor = true;
                Profesor profesor = new Profesor();

                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                Id = Convert.ToInt16(row.Row["ID"].ToString());

                Profesori profesori = new Profesori();

               // profesori.textCodProfesor.Text = Id.ToString();
                profesori.textNume.Text = row.Row["Nume"].ToString();
                profesori.textPrenume.Text = row.Row["Prenume"].ToString();

                profesori.Show();
                this.Close();
            }
            else if (Administrare.isSali == true)
            {
                isUpdateSala = true;
                Sala sala = new Sala();
                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                Id = Convert.ToInt16(row.Row["ID"].ToString());

                Sali sali = new Sali();
                //sali.textCodSala.Text = row.Row["ID"].ToString();
                sali.textNumeSala.Text = row.Row["Nume"].ToString();
                sali.textCapacitateSala.Text = row.Row["Capacitate"].ToString();
                sali.textTipSala.Text = row.Row["Tip"].ToString();

                sali.Show();
                this.Close();
            }

            else if (Administrare.isPromotie )
            {
                isUpdatePromotie = true;
                DataRowView row = TabelModificare.SelectedItem as DataRowView;
                an = row.Row["An"].ToString();
                grupa = row.Row["Grupa"].ToString();
                subgrupa = row.Row["Subgrupa"].ToString();

                Promotie prom = new Promotie();

                prom.textAn.Text = an;
                prom.textGrupa.Text = grupa;
                prom.textSubgrupa.Text = subgrupa;

                prom.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (Administrare.isProfesor == true)
            {               
                if (result == true)
                {
                    string filename = dlg.FileName;
                    excel.InSertProfesorExcel(filename);
                    MessageBox.Show("acest buton functioneaza");
                }
                TabelModificare.ItemsSource = Utils.Display("Select cod_p AS ID, nume AS Nume, prenume AS Prenume from Profesor").Tables[0].DefaultView;
            }

            else if (Administrare.isDisciplina == true)
            {
                if (result == true)
                {
                    string filename = dlg.FileName;
                    excel.InSertDisciplinaExcel(filename);
                    MessageBox.Show("acest buton functioneaza");
                }
                TabelModificare.ItemsSource = Utils.Display("Select cod_d AS ID, denumire AS Disciplina, nr_ore_c AS OreCurs, nr_ore_s AS OreSeminar, nr_ore_l AS OreLaborator, nr_ore_p AS OreProiect, an AS An, sem AS Semestru from Disciplina").Tables[0].DefaultView;
            }

        }
    }
}
