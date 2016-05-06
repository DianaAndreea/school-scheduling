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

namespace Orar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;
        public static bool _isOpenW = false;
        SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            _isOpenW = true;
        }
        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _isOpenW = false;
        }
        //public static MainWindow GetInstance()
        //{

        //}



    }
}
