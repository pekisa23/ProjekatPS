using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class ValidatorZaposleni : AbstractValidator<Zaposleni>
    {
        public ValidatorZaposleni() {

            RuleFor(z => z.Ime).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Niste uneli ime").Length(5, 15).WithMessage("Pogresno uneto ime")
                ;
            RuleFor(z => z.BrojTelefona).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Niste uneli broj").Length(9, 10).WithMessage("Pogresno unet broj telefona").Must(NumValid).WithMessage("Mozete unositi samo brojeve")
                ; ;
            RuleFor(z => z.Username).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Niste uneli username").Length(5, 15).WithMessage("Pogresno unet username")
                ; ;
            RuleFor(z => z.Password).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Niste uneli password").Length(5, 15).WithMessage("Pogresno unet password")
                ; ;
        }

        private bool NumValid (string brojFona)
        {
            return brojFona.All(Char.IsDigit);
        }
    }

