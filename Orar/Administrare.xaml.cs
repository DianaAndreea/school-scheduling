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
    public partial class Administrare : Window
    {
        private static bool _isProfesor;
        private static bool  _isDisciplina;
        private static bool _isSali;
        private static bool _isPromotie;
        

       public Administrare()
        {
            InitializeComponent();            
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            Princ princ = new Princ();
            princ.Show();
            this.Close();           

        }

        private void profesori_admin(object sender, RoutedEventArgs e)
        {
            isProfesor = true;
            isDisciplina = false;
            isSali = false;
            isPromotie = false;

            Modificare mod = new Modificare();
            mod.Show();
            this.Close();          

        }

        private void disc_admin(object sender, RoutedEventArgs e)
        {
            isDisciplina = true;
            isProfesor = false;
            isSali = false;
            isPromotie = false;

            Modificare mod = new Modificare();
            mod.Show();
            this.Close();           

        }

        private void sali_admin(object sender, RoutedEventArgs e)
        {
            isSali = true;
            isProfesor = false;
            isDisciplina = false;
            isPromotie = false;

            Modificare mod = new Modificare();
            mod.Show();
            this.Close();           
            
        }

        private void prom_admin(object sender, RoutedEventArgs e)
        {
            isPromotie = true;
            isSali = false;
            isProfesor = false;
            isDisciplina = false;
           
            Modificare mod = new Modificare();
            mod.Show();
            this.Close();            
        }


        public static bool isProfesor
        {
            get { return _isProfesor; }
            set { _isProfesor = value; }
        }

        public static bool isDisciplina
        {
            get { return _isDisciplina; }
            set { _isDisciplina = value; }
        }

        public static bool isSali
        {
            get { return _isSali; }
            set { _isSali = value; }
        }

        public static bool isPromotie
        {
            get { return _isPromotie; }
            set { _isPromotie = value; }
        }
    }
}
