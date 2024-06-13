using HappyDo.Business.Handlers.NotificationSettings;
using HappyDo.Business.Handlers.PaginationSettings.PaginationFilters;
using HappyDo.Business.Handlers.PaginationSettings;
using HappyDo.Domain.Entities.UserScope;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HappyDo.API.Settings.AuthorizationSettings;
using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRoleRequest;
using HappyDo.API.Extensions;
using HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest;
using HappyDo.ApplicationService.DataTransferObject.Responses.UserResponse;

namespace HappyDo.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandService _userCommandService;
        private readonly IUserQueryService _userQueryService;

        public UserController(IUserCommandService userCommandService, IUserQueryService userQueryService)
        {
            _userCommandService = userCommandService;
            _userQueryService = userQueryService;
        }

        [Authorize(Roles = UserPolicy.Administrator)]
        [HttpPatch("activate_or_deactivate_user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<bool> ActivateOrDeactivateUserAsync([FromQuery] int userId) =>
            await _userCommandService.ActivateOrDeactivateUserAsync(userId);


        [Authorize(Roles = UserPolicy.Administrator)]
        [HttpPatch("change_user_role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<bool> ChangeUserRoleAsync([FromBody] ApplicationUserRoleChangeRoleRequest userRoleChangeRoleRequest)
        {
            var userCredentials = new UserCredentialsRequest(User.GetUserId(),
                                                             User.GetUserRole());

            return await _userCommandService.UpdateRoleAsync(userRoleChangeRoleRequest, userCredentials);
        }


        [Authorize(Roles = UserPolicy.Administrator)]
        [HttpPut("update_user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<bool> UpdateUserAsync([FromBody] UserUpdateRequest userUpdateRequest) =>
            await _userCommandService.UpdateUserAsync(userUpdateRequest);

        [Authorize(Roles = $"{UserPolicy.Administrator}")]
        [HttpGet("get_user_by_id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<UserDataResponse?> GetUserByIdAsync(int userId) =>
            await _userQueryService.FindByUserIdAsync(userId);


        [Authorize(Roles = $"{UserPolicy.Mentor}")]
        [HttpGet("get_all_users_with_pagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<PageList<UserGridResponse>> GetAllUsersAsync([FromQuery] PagingParamsUserFilter pagingParams) =>
            await _userQueryService.FindAllUsersWithPaginationAsync(pagingParams);
    }

}
