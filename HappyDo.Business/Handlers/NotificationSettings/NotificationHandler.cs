using HappyDo.Business.Interfaces.OthersContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Handlers.NotificationSettings
{
    public sealed class NotificationHandler : INotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public bool CreateNotification(string key, string value)
        {
            _notifications.Add(new DomainNotification(key, value));

            return false;
        }

        public void CreateNotification(DomainNotification notification) => _notifications.Add(notification);

        public void CreateNotifications(IEnumerable<DomainNotification> notifications) => _notifications.AddRange(notifications);

        public List<DomainNotification> GetNotifications() => _notifications;

        public bool HasNotification() => _notifications.Any();
    }

}
