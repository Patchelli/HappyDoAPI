using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IExpenseCommandService
    {
        Task<bool> CreateExpenseAsync(ExpenseRegisterRequest expenseRegisterRequest);
        Task<bool> UpdateExpenseAsync(ExpenseUpdateRequest expenseUpdateRequest);
    }
}
