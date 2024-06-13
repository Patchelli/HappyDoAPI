using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IApplicationUserRoleFacadeService : IDisposable
    {
        Task<bool> ChangeRoleAsync(Guid userId, Guid newRoleId);
    }

}
