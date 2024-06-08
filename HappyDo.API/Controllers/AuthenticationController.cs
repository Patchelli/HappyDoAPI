using HappyDo.API.Extensions;
using HappyDo.ApplicationService.DataTransferObject.Arguments;
using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Responses.AuthenticationLoginResponse;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Handlers.NotificationSettings;
using HappyDo.Business.Providers;
using HappyDo.Domain.Entities.UserScope;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.DirectoryServices.AccountManagement;

namespace HappyDo.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly ActiveDirectoryOptions _activeDirectoryOptions;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService,
                                        IOptions<ActiveDirectoryOptions> options)
        {
            _authenticationCommandService = authenticationCommandService;
            _activeDirectoryOptions = options.Value;
        }

        [AllowAnonymous]
        [HttpPost("generate_access_token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<AuthenticationLoginResponse?> CreateAccessTokenAsync(UserLoginRequest userLogin) =>
            await _authenticationCommandService.GenerateAccessTokenAsync(userLogin);


        [AllowAnonymous]
        [HttpPost("generate_access_token_by_active_directory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<AuthenticationLoginResponse?> CreateAccessTokenByActiveDirectoryAsync(UserLoginRequest userLogin)
        {
            bool isValid;
            var userName = userLogin.Login.Split('@')[0];

#pragma warning disable CA1416 // Validate platform compatibility
            using (PrincipalContext pc = new(
                       ContextType.Domain,
                       _activeDirectoryOptions.Domain,
                       _activeDirectoryOptions.Ip,
                       ContextOptions.SimpleBind))
            {

                isValid = pc.ValidateCredentials(userName, userLogin.Password);
            }
#pragma warning restore CA1416 // Validate platform compatibility

            return await _authenticationCommandService.GenerateAccessTokenByActiveDirectoryAsync(userLogin, isValid);
        }

        [Authorize]
        [HttpGet("get_application_user_id_by_access_token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public UserCredentialsForApp GetApplicationUserId() =>
            new(
                User.GetUserId(),
                User.GetEmail(),
                User.GetName(),
                User.GetUserRole());


    }

}
