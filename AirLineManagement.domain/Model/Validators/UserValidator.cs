using FluentValidation;
using Testes.domain.Model;
using Testes.domain.Validators;

namespace AirLineManagement.domain.Model.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage( "Name deve ser preenchido" );

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage( "Email deve ser preenchido" )
                .EmailAddress()
                .WithMessage( "Email inválido" );

            RuleFor( x => x.Password )
                .NotEmpty()
                .WithMessage( "Password deve ser preenchido" )
                .Length( 6 , 12 )
                .WithMessage( "Password must be between 6 and 12 characters" );

            RuleFor( x => x.Cpf)
                .NotEmpty()
                .WithMessage( "Cpf deve ser preenchido" )
                .Must( CpfCnpjValidator.CpfIsValid )
                .WithMessage( "Cpf inválido" );

            RuleFor( x => x.Phone )
                .Must( PhoneValidator.IsValid )
                .WithMessage( "Phone inválido. Deve ter a seguinte estrutura. Ex: (XX) 91234-5678" );

            RuleFor( x => x.BirthDate )
                .NotEmpty()
                .WithMessage( "BirthDate deve ser preenchido" );

            RuleFor( x => x.Country )
                .NotEmpty()
                .WithMessage( "Country deve ser preenchido" )
                .Length( 2 )
                .WithMessage( "Country deve ter 2 caracteres. Ex: BR, EN, ES" )
                .Must( MustBeUpperCase )
                .WithMessage("Country deve ser maiúsculo");
               

        }

        bool MustBeUpperCase( string country)
        {
            return country [0] >= 'A' && country [0] <= 'Z' && country [1] >= 'A' && country [1] <= 'Z';
        }
    }
}
