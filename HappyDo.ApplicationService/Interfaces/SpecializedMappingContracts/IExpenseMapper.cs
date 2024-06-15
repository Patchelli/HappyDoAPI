using HappyDo.ApplicationService.DataTransferObject.Requests.Expense;
using HappyDo.ApplicationService.DataTransferObject.Responses.Expense;
using HappyDo.Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts
{
    public interface IExpenseMapper
    {
        Expense DtoRegisterExpenseToDomain(ExpenseRegisterRequest expenseRegisterRequest);
        Expense DtoUpdateExpenseToDomain(Expense expenseInDb, ExpenseUpdateRequest expenseUpdateRequest);
        ExpenseResponse DomainToDtoExpense(Expense expense);
    }
}
