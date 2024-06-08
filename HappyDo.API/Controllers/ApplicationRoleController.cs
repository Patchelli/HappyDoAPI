using HappyDo.API.Settings.AuthorizationSettings;
using HappyDo.ApplicationService.DataTransferObject.Responses.ApplicationRoleResponse;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyDo.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationRoleController : ControllerBase
    {
        private readonly IApplicationRoleQueryService _applicationRoleQueryService;

        public ApplicationRoleController(IApplicationRoleQueryService applicationRoleQueryService)
        {
            _applicationRoleQueryService = applicationRoleQueryService;
        }

        [Authorize(Roles = UserPolicy.Administrator)]
        [HttpGet("get_all_roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IEnumerable<ApplicationRoleSimpleResponse>> GetAllRolesAsync() =>
            await _applicationRoleQueryService.FindAllRolesAsync();
    }

}
