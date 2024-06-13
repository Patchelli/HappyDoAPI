using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Arguments;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Infrastructure.ORM.Context;
using HappyDo.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.Repository
{
    public sealed class ApplicationUserRoleRepository : BaseRepository<ApplicationUserRole>, IApplicationUserRoleRepository
    {
        public ApplicationUserRoleRepository(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<bool> UpdateRoleAsync(ChangeRole changeRole) =>
            await DbSet.Where(ur => ur.UserId == changeRole.ApplicationUserId)
                .ExecuteUpdateAsync(setter => setter.SetProperty(ur => ur.RoleId, changeRole.NewRoleId)) > 0;
    }

}
