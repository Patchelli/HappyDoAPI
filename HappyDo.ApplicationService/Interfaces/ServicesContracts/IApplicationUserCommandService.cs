using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IApplicationUserCommandService : IDisposable
    {
        Task<bool> CreateUserAsync(ApplicationUserRegisterRequest applicationUserRegisterRequest);
        Task<bool> ChangePasswordAsync(ApplicationUserChangePasswordRequest applicationUserChangePasswordRequest);
    }

}
