using Google.Rpc;
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
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace ProjekatPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Register reg = new Windows.Register();
            reg.Show();
            var mywindow = GetWindow(this);
            mywindow.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Windows.Login log = new Windows.Login();
            log.Show();
            var mywindow = GetWindow(this);
            mywindow.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Process.Start("file://C:\\Users\\Petar\\source\\repos\\ProjekatPS\\ProjekatPS\\helper1.chm");
        }
        }
    }

