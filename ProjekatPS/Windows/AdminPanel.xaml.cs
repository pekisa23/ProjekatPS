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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            Spisak1x.IsChecked = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Spisak1(object sender, RoutedEventArgs e)
        {
            GridUserControl.Children.Clear();
            GridUserControl.Children.Add(new UC.SpRadnici());
        }

        private void Spisak2(object sender, RoutedEventArgs e)
        {
            GridUserControl.Children.Clear();
            GridUserControl.Children.Add(new UC.SpFirme());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Windows.Login log = new Windows.Login();
            log.Show();
            var mywindow = GetWindow(this);
            mywindow.Close();
            
        }


    }
}
