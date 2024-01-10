

using FluentValidation;
using Testes.domain.Validators;

namespace Testes.domain.Model.Validators
{
    public class SeatValidator : AbstractValidator<Seat>
    {
        public SeatValidator()
        {

            RuleFor( seat => seat.Number )
                .GreaterThan( 0 )
                .WithMessage( "Number deve ser maior que 0" )
                .NotEmpty()
                .WithMessage( "Number deve ser preenchido" );


            RuleFor( seat => seat.Flight )
                .NotEmpty()
                .WithMessage( "Flight deve ser preenchido" );


            RuleFor( seat => seat.MinAgeGroup )
                .NotEmpty()
                .WithMessage( "MinAgeGroup deve ser preenchido" );

        }

    }
}
