using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRoleRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IUserCommandService : IDisposable
    {
        Task<bool> UpdateRoleAsync(ApplicationUserRoleChangeRoleRequest userRoleChangeRoleRequest, UserCredentialsRequest userCredentialsRequest);
        Task<bool> UpdateUserAsync(UserUpdateRequest userUpdateRequest);
        Task<bool> ActivateOrDeactivateUserAsync(int userId);
    }

}
