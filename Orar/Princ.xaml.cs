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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Princ : Window
    {
        public static bool _isOpenP = false;
        public Princ()
        {
            InitializeComponent();
            _isOpenP = true;
        }
        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _isOpenP = false;
        }

        private void Orar_Click(object sender, RoutedEventArgs e)
        {
                OrarWin orar = new OrarWin();
                orar.Show();
                this.Close();
            

        }

        private void Administrare_Click(object sender, RoutedEventArgs e)
        {
            Administrare admin = new Administrare();
            admin.Show();
            this.Close();          

        }
    }
}
