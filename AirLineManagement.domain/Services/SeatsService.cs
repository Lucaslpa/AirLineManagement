using AirLineManagement.domain.Interfaces.Repositories;
using AirLineManagement.domain.Model.Validators;
using Testes.domain.Interfaces;
using Testes.domain.Interfaces.Services;
using Testes.domain.Model;
using Testes.domain.Model.Validators;

namespace AirLineManagement.domain.Services
{
    public class SeatService( ISeatRepository repository  , INotifier notifier  )  : Service<Seat>( notifier ), ISeatServices
    { 

        private readonly ISeatRepository Repository = repository;
        public async Task<bool> Add( Seat entity  )
        {
            if (!ModelIsValid( new SeatValidator() , entity ) || !ModelIsValid( new FlightValidator() , entity.Flight )) return false;
          
            await Repository.Add( entity );
            return true;
        }

        public async Task<bool> Delete( Seat entity )
        {
            if (!ModelIsValid( new SeatValidator() , entity ) || !ModelIsValid( new FlightValidator() , entity.Flight )) return false;

            await Repository.Delete( entity );
            return true;
        }

        public async Task<bool> Delete( Guid id )
        {
            await Repository.Delete( id );
            return true;
        }

        public async Task<bool> Update( Seat entity )
        {
            if (!ModelIsValid( new SeatValidator() , entity ) || !ModelIsValid( new FlightValidator() , entity.Flight )) return false;

            await Repository.Update( entity );
            return true;
        }
    }
}
