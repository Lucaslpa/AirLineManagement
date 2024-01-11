using AirLineManagement.domain.Interfaces.Repositories;
using AirLineManagement.domain.Model.Validators;
using Testes.domain.Interfaces;
using Testes.domain.Interfaces.Services;
using Testes.domain.Model;
using Testes.domain.Model.Validators;

namespace AirLineManagement.domain.Services
{
    public class TicketService( ITicketRepository repository  , INotifier notifier  )  : Service<Ticket>( notifier ), ITicketService
    { 

        private readonly ITicketRepository Repository = repository;
        public async Task<bool> Add( Ticket entity  )
        {
            if (!ModelIsValid( new TicketValidator() , entity ) || 
                !ModelIsValid( new FlightValidator() , entity.Flight ) || 
                !ModelIsValid( new UserValidator() , entity.Passenger ) || 
                !ModelIsValid( new SeatValidator() , entity.Seat )) return false;
          
            await Repository.Add( entity );
            return true;
        }

        public async Task<bool> Delete( Ticket entity )
        {
            if (!ModelIsValid( new TicketValidator() , entity ) ||
           !ModelIsValid( new FlightValidator() , entity.Flight ) ||
           !ModelIsValid( new UserValidator() , entity.Passenger ) ||
           !ModelIsValid( new SeatValidator() , entity.Seat )) return false;
            await Repository.Delete( entity );
            return true;
        }

        public async Task<bool> Delete( Guid id )
        {
            await Repository.Delete( id );
            return true;
        }

        public async Task<bool> Update( Ticket entity )
        {
            if (!ModelIsValid( new TicketValidator() , entity ) ||
           !ModelIsValid( new FlightValidator() , entity.Flight ) ||
           !ModelIsValid( new UserValidator() , entity.Passenger ) ||
           !ModelIsValid( new SeatValidator() , entity.Seat )) return false;
            await Repository.Update( entity );
            return true;
        }
    }
}
