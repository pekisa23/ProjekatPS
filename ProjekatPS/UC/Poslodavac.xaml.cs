using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Poslodavac.xaml
    /// </summary>
    public partial class Poslodavac : UserControl
    {
        public Poslodavac()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nmbr = phonenumber.Text;
            int lngt = nmbr.Length;
            if (String.IsNullOrEmpty(compname.Text) || lngt < 9 || !Regex.IsMatch(phonenumber.Text, @"^\d+$") || lngt > 10 || String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(pass.Password))
            {
                MessageBox.Show("Unesite podatke!");
            }
            else
            {
                Firme fir = new Firme(compname.Text, phonenumber.Text, username.Text, pass.Password);
                Classes.SQLACCESS sqlDataAccess = new Classes.SQLACCESS();


                if (sqlDataAccess.SaveFirme(fir))
                    MessageBox.Show("Korisnik je uspesno kreiran!");
                else MessageBox.Show("Greska u kreiranju!");
            }
        }

    }
}
