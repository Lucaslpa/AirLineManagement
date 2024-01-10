using AirLineManagement.domain.Model.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;

using Testes.domain.Interfaces;
using Testes.domain.Interfaces.Repositories;
using Testes.domain.Interfaces.Services;
using Testes.domain.Model;
using Testes.domain.Model.Validators;

namespace AirLineManagement.domain.Services
{
    public class FlightService( IFlightRepository repository  , INotifier notifier  )  : Service<Flight>( notifier ), IFlightService
    { 

        private readonly IFlightRepository Repository = repository;
        public async Task<bool> Add( Flight entity  )
        {
            if (!ModelIsValid( new FlightValidator() , entity ) || !ModelIsValid( new CompanyValidator() , entity.Company )) return false;
          
            await Repository.Add( entity );
            return true;
        }

        public async Task<bool> Delete( Flight entity )
        {
            if (!ModelIsValid( new FlightValidator() , entity )) return false;
            await Repository.Delete( entity );
            return true;
        }

        public async Task<bool> Delete( Guid id )
        {
            await Repository.Delete( id );
            return true;
        }

        public async Task<bool> Update( Flight entity )
        {
            if (!ModelIsValid( new FlightValidator() , entity )) return false;
            await Repository.Update( entity );
            return true;
        }
    }
}
