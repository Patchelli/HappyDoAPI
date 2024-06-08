using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HappyDo.API.Extensions
{
    public static class PrivacyOptionsExtension
    {
        public static bool CanExecuteAction(this AuthorizationHandlerContext context, Dictionary<string, string> roles)
        {
            if (context.User.Claims.Any(c => c.Type == ClaimTypes.Role))
                return context.User.Claims.Any(c => c.Type == ClaimTypes.Role && roles.ContainsValue(c.Value));

            return false;
        }
    }
}
