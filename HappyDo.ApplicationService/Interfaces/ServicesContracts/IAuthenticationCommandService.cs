using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Responses.AuthenticationLoginResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IAuthenticationCommandService
    {
        Task<AuthenticationLoginResponse?> GenerateAccessTokenAsync(UserLoginRequest userLogin);
        Task<AuthenticationLoginResponse?> GenerateAccessTokenByActiveDirectoryAsync(UserLoginRequest userLogin, bool successfullyValidated);
    }

}
