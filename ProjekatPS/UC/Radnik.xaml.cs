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
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace ProjekatPS.UC
{
    /// <summary>
    /// Interaction logic for Radnik.xaml
    /// </summary>
    public partial class Radnik : UserControl
    {
        public Radnik()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string lgt1 = phonenumber.Text;
            int lngt = lgt1.Length;
            string lgt2 = username.Text;
            int lngt2 = lgt2.Length;
            string lgt3 = pass.Password;
            int lngt3 = lgt3.Length;

            if (String.IsNullOrEmpty(compname.Text) || lngt3 < 5 || lngt3 > 15 || lngt2 < 5 || lngt2 > 15 || lngt < 9 || !Regex.IsMatch(phonenumber.Text, @"^\d+$") || lngt > 10 || String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(pass.Password))
            {
                MessageBox.Show("Unesite podatke pravilno!");
            }
            else
            {
                Zaposleni zap= new Zaposleni(compname.Text, phonenumber.Text, username.Text, pass.Password);
                Classes.SQLACCESS sqlDataAccess = new Classes.SQLACCESS();


                if (sqlDataAccess.SaveZaposleni(zap))
                { 
                    MessageBox.Show("Korisnik je uspesno kreiran!");
                    compname.Text = null;
                    phonenumber.Text = null;
                    username.Text = null;
                    pass.Password = null;
                }
                
                else MessageBox.Show("Greska u kreiranju!");
            }
        }
    }
}

