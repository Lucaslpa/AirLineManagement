using FluentValidation;
using FluentValidation.Results;
using Testes.domain.Model;

namespace Testes.domain.Interfaces.Services
{
    public interface IService<T> where T : Entity
    {
        public bool ModelIsValid<TM>( AbstractValidator<TM> validator , TM model );
        public void AddNotifications( ValidationResult validation );
        public void AddNotification( string message ); 


    }
}
