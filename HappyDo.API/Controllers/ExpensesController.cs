using HappyDo.API.Extensions;
using HappyDo.API.Settings.AuthorizationSettings;
using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.Expense;
using HappyDo.ApplicationService.DataTransferObject.Responses.Expense;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Handlers.NotificationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyDo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseCommandService _expenseCommandService;
        private readonly IExpenseQueryService _expenseQueryService;

        public ExpensesController(IExpenseCommandService expenseCommandService, IExpenseQueryService expenseQueryService)
        {
            _expenseCommandService = expenseCommandService;
            _expenseQueryService = expenseQueryService;

        }

        [Authorize(Roles = UserPolicy.Mentor)]
        [HttpGet("get_all_expenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IEnumerable<ExpenseResponse>> GetAllExpenseAsync()
        {
           var userCredential = new UserCredentialsRequest(
           User.GetUserId(),
           User.GetUserRole());

           return await _expenseQueryService.FindAllExpensesAsync(userCredential);
        }

        [Authorize(Roles = UserPolicy.Mentor)]
        [HttpGet("get_by_id_expense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<ExpenseResponse> GetByExpenseIdAsync([FromQuery] int expenseId) =>
            _expenseQueryService.FindExpenseByIdAsync(expenseId);

        [Authorize(Roles = UserPolicy.Mentor)]
        [HttpPost("register_expense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(IEnumerable<DomainNotification>))]
        public Task<bool> RegisterExpenseAsync([FromBody] ExpenseRegisterRequest expenseRegisterRequest) =>
            _expenseCommandService.CreateExpenseAsync(expenseRegisterRequest);


        // PUT api/<ExpensesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
