using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
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
using SimpleWPFReporting;

namespace ProjekatPS.Windows
{
    /// <summary>
    /// Interaction logic for FirmaPanel.xaml
    /// </summary>
    public partial class FirmaPanel : Window
    {
        public FirmaPanel()
        {
            InitializeComponent();
            LoadRadnike();
        }

        private void LoadRadnike()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source=database1.db;Version=3;");
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM radnici";
                SQLiteDataAdapter DB = new SQLiteDataAdapter(command.CommandText, connection);
                connection.Close();

                DataSet DS = new DataSet();
                DB.Fill(DS);

                if (DS.Tables[0].Rows.Count > 0)
                {
                    Radnici.ItemsSource = DS.Tables[0].DefaultView;
                }



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Windows.Login lgn = new Windows.Login();
            lgn.Show();
            var mywindow = GetWindow(this);
            mywindow.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Report.ExportVisualAsPdf(Radnici);

            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
