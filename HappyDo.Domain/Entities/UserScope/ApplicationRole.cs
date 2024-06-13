using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities.UserScope
{
    public sealed class ApplicationRole : IdentityRole<Guid>
    {
        public List<ApplicationUserRole>? UserRoles { get; set; }
    }

}
