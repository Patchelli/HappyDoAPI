using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyDo.Domain.Arguments;

namespace HappyDo.Business.Interfaces.RepositoryContracts
{
    public interface IApplicationUserRoleRepository : IDisposable
    {
        Task<bool> UpdateRoleAsync(ChangeRole changeRole);
    }

}