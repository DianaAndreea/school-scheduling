using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdaugaDisciplina.xaml
    /// </summary>
    public partial class AdaugaDisciplina : Window
    {
        public AdaugaDisciplina()
        {
            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {   if(Modificare.isUpdateDisciplina == true){
            Disciplina disciplina = new Disciplina();
            disciplina.Update(Modificare.Id, denumire.Text, Convert.ToInt16(oreCurs.Text), Convert.ToInt16(oreSeminar.Text), Convert.ToInt16(oreLab.Text), Convert.ToInt16(oreProiect.Text), Convert.ToInt16(an.Text), Convert.ToInt16(sem.Text));
            MessageBox.Show("Updated!");
        } else if(Modificare.isInsertDisciplina == true){
            Disciplina disciplina = new Disciplina();
            disciplina.Insert(denumire.Text, Convert.ToInt16(oreCurs.Text), Convert.ToInt16(oreSeminar.Text), Convert.ToInt16(oreLab.Text), Convert.ToInt16(oreProiect.Text), Convert.ToInt16(an.Text), Convert.ToInt16(sem.Text));
            MessageBox.Show("Saved!");
        }


        }

     
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Modificare modificare = new Modificare();
            modificare.Show();
            this.Close();
        }
    }
}
