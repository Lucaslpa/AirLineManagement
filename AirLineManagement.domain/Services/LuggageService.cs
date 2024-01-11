using AirLineManagement.domain.Interfaces.Repositories;
using AirLineManagement.domain.Model.Validators;
using Testes.domain.Interfaces;
using Testes.domain.Interfaces.Services;
using Testes.domain.Model;

namespace AirLineManagement.domain.Services
{
    public class LuggageService( ILuggageRepository repository  , INotifier notifier  )  : Service<Luggage>( notifier ), ILuggageService
    { 

        private readonly ILuggageRepository Repository = repository;
        public async Task<bool> Add( Luggage entity  )
        {
            if (
                !ModelIsValid( new LuggageValidator() , entity ) || 
                !ModelIsValid( new FlightValidator() , entity.Flight ) || 
                !ModelIsValid( new UserValidator() , entity.Owner ) ) return false;
          
            await Repository.Add( entity );
            return true;
        }

        public async Task<bool> Delete( Luggage entity )
        {
            if (
            !ModelIsValid( new LuggageValidator() , entity ) ||
            !ModelIsValid( new FlightValidator() , entity.Flight ) ||
            !ModelIsValid( new UserValidator() , entity.Owner )) return false;

            await Repository.Delete( entity );
            return true;
        }

        public async Task<bool> Delete( Guid id )
        {
            await Repository.Delete( id );
            return true;
        }

        public async Task<bool> Update( Luggage entity )
        {
            if (
            !ModelIsValid( new LuggageValidator() , entity ) ||
            !ModelIsValid( new FlightValidator() , entity.Flight ) ||
            !ModelIsValid( new UserValidator() , entity.Owner )) return false;

            await Repository.Update( entity );
            return true;
        }
    }
}
