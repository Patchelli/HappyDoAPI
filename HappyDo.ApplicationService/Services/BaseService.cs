using HappyDo.Business.Handlers.NotificationSettings;
using HappyDo.Business.Interfaces.OthersContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services
{
    public class BaseService<T> where T : class
    {
        protected readonly INotificationHandler _notification;
        private readonly IValidate<T> _validate;

        protected BaseService(INotificationHandler notification, IValidate<T> validate)
        {
            _notification = notification;
            _validate = validate;
        }

        protected async Task<bool> EntityValidationAsync(T entity)
        {
            var validationResponse = await _validate.ValidationAsync(entity);

            if (!validationResponse.Valid)
                _notification.CreateNotifications(DomainNotification.Create(validationResponse.Errors));

            return validationResponse.Valid;
        }

        protected bool EntitiesValidation(List<T> entities)
        {
            foreach (var validationResponse in entities.Select(entity => _validate.Validation(entity)).Where(validationResponse => !validationResponse.Valid))
            {
                _notification.CreateNotifications(DomainNotification.Create(validationResponse.Errors));
            }

            return !_notification.HasNotification();
        }
    }

}
