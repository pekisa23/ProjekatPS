using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ValidatorFirma : AbstractValidator<Firme>
{
    public ValidatorFirma()
    {

        RuleFor(f => f.ImeF).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Niste uneli ime!").Length(5, 30).WithMessage("Pogresno uneto ime!  Mora imati izmedju 5 i 30 karaktera!")
            ;
        RuleFor(f => f.BrojTelefonaF).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Niste uneli broj!").Length(9, 10).WithMessage("Pogresno unet broj telefona! Mora imati izmedju 9 i 10 karaktera!").Must(NumValid).WithMessage("Mozete unositi samo brojeve!")
            ; ;
        RuleFor(f => f.UsernameF).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Niste uneli username!").Length(5, 15).WithMessage("Pogresno unet username! Mora imati izmedju 5 i 15 karaktera!")
            ; ;
        RuleFor(f => f.PasswordF).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Niste uneli password!").Length(5, 15).WithMessage("Pogresno unet password! Mora imati izmedju 5 i 15 karaktera!")
            ; ;
    }

    private bool NumValid(string brojFona)
    {
        return brojFona.All(Char.IsDigit);
    }
}

