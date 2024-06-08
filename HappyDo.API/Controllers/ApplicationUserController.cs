using HappyDo.API.Settings.AuthorizationSettings;
using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Handlers.NotificationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyDo.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserCommandService _applicationUserCommandService;

        public ApplicationUserController(IApplicationUserCommandService applicationUserCommandService)
        {
            _applicationUserCommandService = applicationUserCommandService;
        }

        //[Authorize(Roles = UserPolicy.Administrator)]
        [AllowAnonymous]
        [HttpPost("register_user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<bool> CreateUserAsync([FromBody] ApplicationUserRegisterRequest applicationUserRegisterRequest) =>
            await _applicationUserCommandService.CreateUserAsync(applicationUserRegisterRequest);

        [Authorize(Roles = UserPolicy.Administrator)]
        [HttpPatch("change_password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<bool> ChangePassworAsync(ApplicationUserChangePasswordRequest applicationUserChangePasswordRequest) =>
            await _applicationUserCommandService.ChangePasswordAsync(applicationUserChangePasswordRequest);
    }

}
