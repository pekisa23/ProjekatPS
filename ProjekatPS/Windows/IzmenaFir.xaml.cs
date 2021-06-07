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
            one.Text = GlobFir.ime;
            one1.Text = GlobFir.brojTelefona;
            one2.Text = GlobFir.username;
            one3.Text = GlobFir.password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            GlobFir.ime = one.Text;
            GlobFir.brojTelefona = one1.Text;
            GlobFir.username = one2.Text;
            GlobFir.password = one3.Text;

            Firme fir = new Firme(GlobFir.ime, GlobFir.brojTelefona, GlobFir.username, GlobFir.password);
            var ValidatorFirma = new ValidatorFirma();
            var result = ValidatorFirma.Validate(fir);
            if (!result.IsValid)
            {
                foreach (var faliure in result.Errors)
                {
                    MessageBox.Show(faliure.ErrorMessage);
                }
            }
            else
            { 
                Classes.SQLACCESS sqlAccess = new Classes.SQLACCESS();

            if (sqlAccess.UpdateFir())
            {
                MessageBox.Show("Korisnik je uspesno apdejtovan!");
                var myWindow = GetWindow(this);
                this.Close();
            }

            else MessageBox.Show("Greska u apdejtovanju!");
            }
        }
    }
}
