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
    /// Interaction logic for IzmenaZap.xaml
    /// </summary>
    public partial class IzmenaZap : Window
    {
        public IzmenaZap()
        {
            InitializeComponent();

            one1.Text = GlobZap.ime;
            one2.Text = GlobZap.brojTelefona;
            one3.Text = GlobZap.username;
            one4.Text = GlobZap.password;
            one5.Text = GlobZap.radiKod;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobZap.ime = one1.Text;
            GlobZap.brojTelefona = one2.Text;
            GlobZap.username = one3.Text;
            GlobZap.password = one4.Text;
            GlobZap.radiKod = one5.Text;


            Classes.SQLACCESS sqlAccess = new Classes.SQLACCESS();

            if (sqlAccess.CheckZap() && sqlAccess.UpdateRad())
            {
                MessageBox.Show("Korisnik je uspesno apdejtovan!");
            }

            else MessageBox.Show("Greska u apdejtovanju!");

            var myWindow = GetWindow(this);
            this.Close();

        }
    }
}
