using HappyDo.Business.Handlers.NotificationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.OthersContracts
{
    public interface INotificationHandler
    {
        bool CreateNotification(string key, string value);
        void CreateNotification(DomainNotification notification);
        void CreateNotifications(IEnumerable<DomainNotification> notifications);
        bool HasNotification();
        List<DomainNotification> GetNotifications();
    }

}
