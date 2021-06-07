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
            Zaposleni zap = new Zaposleni(compname.Text, phonenumber.Text, username.Text, pass.Password);

            var ValidatorZaposleni = new ValidatorZaposleni();
            var result = ValidatorZaposleni.Validate(zap);
            if (!result.IsValid)
            {
                foreach (var faliure in result.Errors)
                {
                    MessageBox.Show(faliure.ErrorMessage);
                }
            }

            else
            {
                Classes.SQLACCESS sqlDataAccess = new Classes.SQLACCESS();


                if (sqlDataAccess.SaveZaposleni(zap))
                { 
                    MessageBox.Show("Korisnik je uspesno kreiran!", "Odradjeno!");
                    compname.Text = null;
                    phonenumber.Text = null;
                    username.Text = null;
                    pass.Password = null;
                }
                
                else MessageBox.Show("Greska prilikom cuvanja podataka!","Greska!");
            }
        }
    }
}

