using FluentValidation;
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
            Firme fir = new Firme(compname.Text, phonenumber.Text, username.Text, pass.Password);

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
                
                Classes.SQLACCESS sqlDataAccess = new Classes.SQLACCESS();


                if (sqlDataAccess.SaveFirme(fir))
                { 
                    MessageBox.Show("Korisnik je uspesno kreiran!", "Odradjeno!");
                    compname.Text = null;
                    phonenumber.Text = null;
                    username.Text = null;
                    pass.Password = null;
                }
                else MessageBox.Show("Greska u kreiranju!","Greska!");
            }
        }

    }
}
