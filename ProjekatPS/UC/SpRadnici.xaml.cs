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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatPS.UC
{
    /// <summary>
    /// Interaction logic for SpRadnici.xaml
    /// </summary>
    public partial class SpRadnici : UserControl
    {
        public SpRadnici()
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
    }
}
