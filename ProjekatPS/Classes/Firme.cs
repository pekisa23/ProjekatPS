using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Firme
    {

        public Firme() { }

        public Firme(string imef, string brojTelefonaf, string usernamef, string passwordf)
        {
            ImeF = imef;
            BrojTelefonaF = brojTelefonaf;
            UsernameF = usernamef;
            PasswordF = passwordf;
        }

        public string ImeF { get; set; }

        public string BrojTelefonaF { get; set; }

        public string UsernameF { get; set; }

        public string PasswordF { get; set; }

   
}

