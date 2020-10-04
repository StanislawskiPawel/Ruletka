using Oracle.ManagedDataAccess.Client;
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

namespace Program2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Window1 win1 = new Window1(TextBox1.Text, Int32.Parse(TextBox2.Text));
            win1.Show();
        }



        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> s = Database.instance.ReadData();
            textbox0.Text = "";
            foreach(string k in s)
            {
                textbox0.Text += k + "\n";
            }
        }


    }
}

