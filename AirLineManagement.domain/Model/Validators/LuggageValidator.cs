using FluentValidation;
using Testes.domain.Enums;
using Testes.domain.Model;

namespace AirLineManagement.domain.Model.Validators
{
    public class LuggageValidator : AbstractValidator<Luggage>
    {
        public LuggageValidator()
        {

            When(x => x.LuggageType == LuggageType.CarryOn, () =>
            {
                RuleFor(x => x.Weight)
                    .NotEmpty()
                    .WithMessage( "Weight deve ser preenchido" )
                    .GreaterThan( 5 )
                    .WithMessage( "CarryOn luggage deve ter pelo menos 5kg" )
                    .LessThan(30)
                    .WithMessage( "CarryOn luggage deve ter menos de 30kg. Mais de 30kg, deve ser Checked luggage" )
                    ;
            });

            When(x => x.LuggageType == LuggageType.Checked, () =>
            {
                RuleFor( x => x.Weight )
                    .NotEmpty()
                    .WithMessage( "Weight deve ser preenchido" )
                    .GreaterThan( 30 )
                    .WithMessage( "Checked luggage deve ter pelo menos 30kg" )
                    .LessThan( 100 )
                    .WithMessage( "Checked luggage deve ter menos de 100kg" );
            } );

            RuleFor( x => x.Owner )
                .NotEmpty()
                .WithMessage( "Owner deve ser preenchido" );

            RuleFor( x => x.Flight )
                .NotEmpty()
                .WithMessage( "Flight deve ser preenchido" );

        }
    }
}
