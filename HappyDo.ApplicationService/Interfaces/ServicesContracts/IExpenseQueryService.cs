using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Responses.Expense;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IExpenseQueryService
    {
        Task<IEnumerable<ExpenseResponse>> FindAllExpensesAsync(UserCredentialsRequest userCredentials);
        Task<ExpenseResponse> FindExpenseByIdAsync(int expenseId);
    }
}
