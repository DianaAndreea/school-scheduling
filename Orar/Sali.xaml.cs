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
    /// Interaction logic for Sali.xaml
    /// </summary>
    public partial class Sali : Window
    {
        public Sali()
        {
            InitializeComponent();
        }

        private void backm_click(object sender, RoutedEventArgs e)
        {            
            Modificare mod = new Modificare();
            mod.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Modificare.isUpdateSala == true)
            {
                Sala sala = new Sala();
                sala.Update(Modificare.Id,textNumeSala.Text,Convert.ToInt16(textCapacitateSala.Text),textTipSala.Text);
                MessageBox.Show("Updated!");
            }
            else if (Modificare.isInsertSala == true)
            {
                Sala sala = new Sala();
                sala.Insert(Modificare.Id, textNumeSala.Text, Convert.ToInt16(textCapacitateSala.Text), textTipSala.Text);
                MessageBox.Show("Saved!");
            }
        }

       

      

    }
}
