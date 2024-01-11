using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.domain.Model;

namespace AirLineManagement.domain.Model.Validators
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor( t => t.Flight )
                .NotNull()
                .WithMessage( "Flight deve ser preenchido" )
                .NotEmpty()
                .WithMessage( "Flight deve ser preenchido" ); 
          
            RuleFor(t => t.Seat)
                 .NotNull()
                .WithMessage( "Seat deve ser preenchido" )
                .NotEmpty()
                .WithMessage( "Seat deve ser preenchido" );
           
            RuleFor(t => t.Passenger )
                .NotNull()
                .WithMessage( "User deve ser preenchido" )
                .NotEmpty()
                .WithMessage( "User deve ser preenchido" );
        }

    }
}
