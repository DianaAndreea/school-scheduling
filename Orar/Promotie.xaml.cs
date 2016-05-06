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
using System.Windows.Shapes;

namespace Orar
{
    /// <summary>
    /// Interaction logic for Promotie.xaml
    /// </summary>
    public partial class Promotie : Window
    {
        public Promotie()
        {
            InitializeComponent();
        }

        private void backm_click(object sender, RoutedEventArgs e)
        {           
            Modificare mod = new Modificare();
            mod.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Modificare.isUpdatePromotie == true)
            {
                An an = new An();
                Grupa grupa = new Grupa();
                Subgrupa subgrupa = new Subgrupa();
                an.Update(Convert.ToInt16(textAn.Text),Convert.ToInt16(Modificare.an));
                grupa.Update(textGrupa.Text, Modificare.grupa);
                subgrupa.Update(textSubgrupa.Text, Modificare.subgrupa);
                MessageBox.Show("Updated!");
            }
            else if (Modificare.isInsertPromotie== true)
            {
                An an = new An();
                Grupa grupa = new Grupa();
                Subgrupa subgrupa = new Subgrupa();
                subgrupa.Insert(textSubgrupa.Text);
                grupa.Insert(textGrupa.Text, textSubgrupa.Text);
                an.Insert(Convert.ToInt16(textAn.Text), textGrupa.Text,textSubgrupa.Text);
                MessageBox.Show("Saved!");
            }

        }

        private void textGrupa_TextChanged(object sender, TextChangedEventArgs e)
        {
            textSubgrupa.Text =textGrupa.Text;
        }
    }
}
