

using FluentValidation;
using Testes.domain.Validators;

namespace Testes.domain.Model.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            NameValidation();
            CnpjValidation();
            AddressValidation();
            PhoneValidation();
            EmailValidation();
        }

        private bool StartWithCapitalLetter(string name)
        {
            return name [0] >= 'A' && name [0] <= 'Z';
        }

        private void NameValidation()
        {
            RuleFor( x => x.Name )
              .NotEmpty().WithMessage( "Name deve ser preenchido" )
              .Length( 1 , 100 ).WithMessage( "Name deve ter entre 1 e 100 caracteres" )
              .Matches( @"^[a-zA-Z0-9\s]*$" ).WithMessage( "Name deve ser alphanumérico" )
              .Must( StartWithCapitalLetter ).WithMessage( "Name deve começar com letra maiúscula" );
        }

        private void CnpjValidation()
        {
            RuleFor( x => x.Cnpj )
              .NotEmpty().WithMessage( "Cnpj deve ser preenchido" )
              .Must( CpfCnpjValidator.CnpjIsValid ).WithMessage( "Cnpj inválido" );
        }   

        private void AddressValidation()
        {
            RuleFor( x => x.Address )
              .NotEmpty().WithMessage( "Address deve ser preenchido" )
              .Length( 1 , 100 ).WithMessage( "Address deve ter entre 1 e 100 caracteres" )
              .Matches( @"^[a-zA-Z0-9\s]*$" ).WithMessage( "Address deve ser alphanumérico" );
        }

       private void PhoneValidation()
        {  
               RuleFor( x => x.Phone )
              .NotEmpty().WithMessage( "Phone deve ser preenchido" )
              .Must( PhoneValidator.IsValid ).WithMessage( "Phone inválido. Deve ter a seguinte estrutura. Ex: (XX) 91234-5678" );
        }

        private void EmailValidation()
        { 
            RuleFor( x => x.Email )
              .NotEmpty().WithMessage( "Email deve ser preenchido" )
              .EmailAddress().WithMessage( "Email inválido" );

        }

    }
}
