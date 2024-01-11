

using FluentValidation;
using Testes.domain.Model;

namespace AirLineManagement.domain.Model.Validators
{
    public class FlightValidator : AbstractValidator<Flight>
    { 
        public FlightValidator()
        {
            RuleFor( flight => flight.Origin )
                .NotEmpty()
                .WithMessage( "Origin deve ser preenchido" );

            RuleFor( flight => flight.Destiny )
                .NotEmpty()
                .WithMessage( "Destiny deve ser preenchido" );

            RuleFor( flight => flight.Price )
                .GreaterThan( 100 )
                .WithMessage( "Price deve ser maior que 100" )
                .NotEmpty()
                .WithMessage( "Price deve ser preenchido" );

            RuleFor( flight => flight.MaxCarryOnLuggageWeight )
                .GreaterThan( 100 )
                .WithMessage( "MaxCarryOnLuggageWeight deve ser maior que 100" )
                .NotEmpty()
                .WithMessage( "MaxCarryOnLuggageWeight deve ser preenchido" );

            RuleFor( flight => flight.MaxCheckedLuggageWeight )
                .GreaterThan( 100 )
                .WithMessage( "MaxCheckedLuggageWeight deve ser maior que 100" )
                .NotEmpty()
                .WithMessage( "MaxCheckedLuggageWeight deve ser preenchido" );

            RuleFor( flight => flight.Departure )
                .NotEmpty()
                .WithMessage( "DepartureTime deve ser preenchido" );

            RuleFor( flight => flight.CarryOnLuggagePrice )
                .GreaterThan( 10 )
                .WithMessage( "CarryOnLuggagePrice deve ser maior que 10" )
                .NotEmpty()
                .WithMessage( "CarryOnLuggagePrice deve ser preenchido" );

            RuleFor( flight => flight.FlightTimeInHours )
                .GreaterThan( 0 )
                .WithMessage( "FlightTimeInHours deve ser maior que 0" )
                .NotEmpty()
                .WithMessage( "FlightTimeInHours deve ser preenchido" );

            RuleFor( flight => flight.TotalSeats )
                .GreaterThan( 20 )
                .WithMessage( "TotalSeats deve ser maior que 20" )
                .NotEmpty()
                .WithMessage( "TotalSeats deve ser preenchido" );

            RuleFor( flight => flight.Company )
                .NotEmpty()
                .WithMessage( "Company deve ser preenchido" );
        }
    }
}
