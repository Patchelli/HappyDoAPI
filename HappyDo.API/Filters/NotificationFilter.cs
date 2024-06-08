using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.API.Extensions;

namespace HappyDo.API.Filters
{
    public sealed class NotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationHandler _notificationHandler;

        public NotificationFilter(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!ExternalMethodExtension.IsMethodGet(context) && _notificationHandler.HasNotification())
                context.Result = new BadRequestObjectResult(_notificationHandler.GetNotifications());

            base.OnActionExecuted(context);
        }
    }

}
