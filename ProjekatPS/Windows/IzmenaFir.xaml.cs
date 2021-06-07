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
    /// Interaction logic for IzmenaFir.xaml
    /// </summary>
    public partial class IzmenaFir : Window
    {
        public IzmenaFir()
        {
            InitializeComponent();
            one.Text = GlobZap.ime;
            one1.Text = GlobZap.brojTelefona;
            one2.Text = GlobZap.username;
            one3.Text = GlobZap.password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobZap.ime = one.Text;
            GlobZap.brojTelefona = one1.Text;
            GlobZap.username = one2.Text;
            GlobZap.password = one3.Text;

            Classes.SQLACCESS sqlAccess = new Classes.SQLACCESS();

            if (sqlAccess.UpdateFir())
            {
                MessageBox.Show("Korisnik je uspesno kreiran!");
                one.Text = null;
                one1.Text = null;
                one2.Text = null;
                one3.Text = null;
            }

            else MessageBox.Show("Greska u kreiranju!");

            var myWindow = GetWindow(this);
            this.Close();

        }
    }
}
