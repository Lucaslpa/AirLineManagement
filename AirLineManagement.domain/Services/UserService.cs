using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.domain.Interfaces.Repositories;
using Testes.domain.Interfaces.Services;
using Testes.domain.Interfaces;
using Testes.domain.Model.Validators;
using Testes.domain.Model;
using AirLineManagement.domain.Interfaces.Repositories;
using AirLineManagement.domain.Model.Validators;

namespace AirLineManagement.domain.Services
{
    public class UserService( IUserRepository repository , INotifier notifier ) : Service<User>( notifier ), IUserService
    {

        private readonly IUserRepository Repository = repository;
        public async Task<bool> Add( User entity )
        {
            if (!ModelIsValid( new UserValidator() , entity )) return false;
            var existEmail = Repository.Search( e => e.Email.Equals( entity.Email ) ).Result.Any();
            var existPhone = Repository.Search( e => e.Phone.Equals( entity.Phone ) ).Result.Any();

            if (existEmail)
            {
                AddNotification( "Não pode criar um novo, pois já existe usuário com esse email" );
                return false;
            } else if (existPhone)
            {
                AddNotification( "Não pode criar um novo, pois já existe usuário com esse telefone" );
                return false;
            }

            await Repository.Add( entity );
            return true;
        }

        public async Task<bool> Delete( User entity )
        {
            if (!ModelIsValid( new UserValidator() , entity )) return false;
            await Repository.Delete( entity );
            return true;
        }

        public async Task<bool> Delete( Guid id )
        {
            await Repository.Delete( id );
            return true;
        }

        public async Task<bool> Update( User entity )
        {
            if (!ModelIsValid( new UserValidator() , entity )) return false;
            await Repository.Update( entity );
            return true;
        }
    }
}
