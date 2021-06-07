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

namespace ProjekatPS.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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

            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection.State == ConnectionState.Closed)
                sQLiteConnection.Open();

            try
            {
                String query1 = "select count(1) from radnici where username=@username and password=@password";
                SQLiteCommand cmd1 = new SQLiteCommand(query1, sQLiteConnection);

                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("username", username.Text);
                cmd1.Parameters.AddWithValue("password", password.Password);
                int count1 = Convert.ToInt32(cmd1.ExecuteScalar());

                String query = "select count(1) from poslodavci where username=@username and password=@password";
                SQLiteCommand cmd = new SQLiteCommand(query, sQLiteConnection);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("username", username.Text);
                cmd.Parameters.AddWithValue("password", password.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1 || count1 == 1)
                {

                    if (count1 == 1)
                    {
                        Windows.RadnikPanel rp = new Windows.RadnikPanel();
                        rp.Show();

                        var myWindow = Window.GetWindow(this);
                        myWindow.Close();

                    }
                    else if (count == 1)
                    {
                        Windows.FirmaPanel fp = new Windows.FirmaPanel();
                        fp.Show();
                        var myWindow = Window.GetWindow(this);
                        myWindow.Close();

                    }
                }
                else if (username.Text.Equals("admin") || password.Password.Equals("admin"))
                {
                    Windows.AdminPanel adm = new Windows.AdminPanel();
                    adm.Show();
                    var mywindow = GetWindow(this);
                    mywindow.Close();
                }
                else
                {
                    MessageBox.Show("Uneti podaci su pogresni!");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sQLiteConnection.Close();
            }


           

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

