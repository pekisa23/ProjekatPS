using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

class Zaposleni
{

    public Zaposleni() { }

    public Zaposleni (string ime, string brojTelefona, string username, string password )
    {
        Ime = ime;
        BrojTelefona = brojTelefona;
        Username = username;
        Password = password;
    }

    public string Ime { get; set; }

    public string BrojTelefona { get; set; }
    
    public string Username { get; set; }

    public string Password { get; set; }

    public bool Status { get; set; }

    


}

