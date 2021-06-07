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

            Zaposleni zap = new Zaposleni(GlobZap.ime, GlobZap.brojTelefona, GlobZap.username, GlobZap.password);
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
                Classes.SQLACCESS sqlAccess = new Classes.SQLACCESS();

                if (!sqlAccess.CheckZap() && !(GlobZap.radiKod == "0"))
                {
                    MessageBox.Show("Greska u apdejtovanju! Izaberite postojeci ID firme.");
                } else

                    if (sqlAccess.UpdateRad())
                {
                    MessageBox.Show("Korisnik je uspesno apdejtovan!");
                    var myWindow1 = GetWindow(this);
                    this.Close();
                }

                else MessageBox.Show("Greska pri unosu u bazu!");

                }
            }
        

            private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
            {
                DragMove();
            }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                var mywindow = GetWindow(this);
                mywindow.Close();
            }
        }

}
