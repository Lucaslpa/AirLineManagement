﻿using FluentValidation;
using FluentValidation.Results;
using Testes.domain.Interfaces;
using Testes.domain.Interfaces.Services;
using Testes.domain.Model;
using Testes.domain.Notifications;

namespace AirLineManagement.domain.Services
{
    public class Service<T>( INotifier notifier) : IService<T> where T : Entity
    {   
         
        private readonly INotifier Notifier = notifier;

        public void AddNotifications( ValidationResult validation )
        {
            foreach (var error in validation.Errors)
            {
                Notifier.AddNotification( new NotificationWarning( error.ErrorMessage ) );
            }
        }

        public void AddNotification( string message )
        {
            Notifier.AddNotification( new NotificationWarning( message ) );
        }

        public bool ModelIsValid( AbstractValidator<T> validator, T model ) 
        {
            var validaor = validator.Validate( model );

            if (validaor.IsValid) return true;

            AddNotifications( validaor );

            return false;
        }
    }
}