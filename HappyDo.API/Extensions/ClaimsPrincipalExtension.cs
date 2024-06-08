using System.Security.Claims;

namespace HappyDo.API.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetEmail(this ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Name)?.Value!;

        public static string GetName(this ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Actor)?.Value!;

        public static string GetUserRole(this ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Role)?.Value!;

        public static Guid GetUserId(this ClaimsPrincipal user) =>
            Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    }

}
