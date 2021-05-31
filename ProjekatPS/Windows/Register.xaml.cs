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

namespace ProjekatPS.Windows
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            RegisterBTN1.IsChecked = true;
        }

        private void RgtBtn1(object sender, RoutedEventArgs e)
        {
            GridUserControl.Children.Clear();
            GridUserControl.Children.Add(new UC.Poslodavac());
        }

        private void RgtBtn2(object sender, RoutedEventArgs e)
        {
            GridUserControl.Children.Clear();
            GridUserControl.Children.Add(new UC.Radnik());
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

     private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            var mywindow = GetWindow(this);
            mywindow.Close();
        }

    }

}
