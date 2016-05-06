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
    /// Interaction logic for Adauga.xaml
    /// </summary>
    public partial class Profesori : Window
    {
        
        bool succes = false;
        public Profesori()
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
            
            try 
            {
                if (Modificare.isUpdateProfesor == true)
                {
                    Profesor profesor = new Profesor();
                    profesor.Update(Modificare.Id, textNume.Text, textPrenume.Text);
                    MessageBox.Show("Updated!");
                }
                else if (Modificare.isInsertProfesor == true)
                {
                    Profesor profesor = new Profesor();
                    profesor.Insert( textNume.Text, textPrenume.Text);
                    MessageBox.Show("Saved!");
                }
               
                succes = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }


    }
}
