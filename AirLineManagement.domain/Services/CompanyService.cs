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
    public class CompanyService( ICompanyRepository repository  , INotifier notifier  )  : Service<Company>( notifier ), ICompanyService
    { 

        private readonly ICompanyRepository Repository = repository;
        public async Task<bool> Add( Company entity  )
        {
            if (!ModelIsValid( new CompanyValidator() , entity )) return false;
            var exist = Repository.Search( e => e.Cnpj.Equals( entity.Cnpj ) ).Result.Any();
            if (exist)
            {
                AddNotification( "Não pode criar um novo, pois já existe" );
                return false;
            }
            await Repository.Add( entity );
            return true;
        }

        public async Task<bool> Delete( Company entity )
        {
            if (!ModelIsValid( new CompanyValidator() , entity )) return false;
            await Repository.Delete( entity );
            return true;
        }

        public async Task<bool> Delete( Guid id )
        {
            await Repository.Delete( id );
            return true;
        }

        public async Task<bool> Update( Company entity )
        {
            if (!ModelIsValid( new CompanyValidator() , entity )) return false;
            await Repository.Update( entity );
            return true;
        }
    }
}
