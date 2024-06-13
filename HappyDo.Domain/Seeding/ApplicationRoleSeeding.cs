using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Seeding
{
    public sealed class ApplicationRoleSeeding
    {
        public List<ApplicationRole> CreateRoles()
        {
            return new List<ApplicationRole>()
        {
            new()
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                UserRoles = new()
            },

            new()
            {
                Name = "Mentor",
                NormalizedName = "MENTOR",
                UserRoles = new()
            },

            new()
            {
                Name = "Mentored",
                NormalizedName = "MENTORED",
                UserRoles = new()
            },
        };
        }
    }

}
