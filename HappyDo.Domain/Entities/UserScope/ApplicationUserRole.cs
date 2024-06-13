
using HappyDo.Domain.Entities.UserScope;

using Microsoft.AspNetCore.Identity;

namespace HappyDo.Domain.Entities.UserScope
{
    public sealed class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationUser? User { get; set; }
        public ApplicationRole? Role { get; set; }
    }
}
