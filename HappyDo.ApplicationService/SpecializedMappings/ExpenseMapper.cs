using HappyDo.ApplicationService.DataTransferObject.Requests.Expense;
using HappyDo.ApplicationService.DataTransferObject.Responses.Expense;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.SpecializedMappings
{
    public sealed class ExpenseMapper : IExpenseMapper
    {
        public Expense DtoRegisterExpenseToDomain(ExpenseRegisterRequest expenseRegisterRequest)
        {
            var expense = new Expense
            {
                Description = expenseRegisterRequest.Description,
                Amount = expenseRegisterRequest.Value,
                Date = expenseRegisterRequest.Date,
                CategoryId = expenseRegisterRequest.CategoryId,
                Situation = expenseRegisterRequest.Situation,
                ApplicationUserId = expenseRegisterRequest.ApplicationUserId
            };

            return expense;
        }

        public Expense DtoUpdateExpenseToDomain(Expense expense , ExpenseUpdateRequest expenseUpdateRequest)
        {
            expense .Description = expenseUpdateRequest.Description;
            expense .Amount = expenseUpdateRequest.Value;
            expense .Date = expenseUpdateRequest.Date;
            expense .CategoryId = expenseUpdateRequest.CategoryId;
            expense .Situation = expenseUpdateRequest.Situation;

            return expense;
        }

        public ExpenseResponse DomainToDtoExpense(Expense expense)
        {
            return new ExpenseResponse
            {
                Id = expense.ExpenseId,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date,
                Situation = expense.Situation
            };
        }
    }
}
