using HappyDo.ApplicationService.AutoMapperSettings.Settings;
using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Responses.Expense;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.ExpenseServices
{
    public class ExpenseQueryService : IExpenseQueryService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseMapper _expenseMapper;
        public ExpenseQueryService(IExpenseRepository expenseRepository, IExpenseMapper expenseMapper)
        {
            _expenseRepository = expenseRepository;
            _expenseMapper = expenseMapper;
        }

        public async Task<IEnumerable<ExpenseResponse>> FindAllExpensesAsync(UserCredentialsRequest userCredentialsRequest)
        {
            var expenses = await _expenseRepository.FindAllWithPredicateAsync(
                e => e.ApplicationUserId == userCredentialsRequest.UserApplicationId,
                include: query => query.Include(e => e.ApplicationUser)
            );

            return expenses.MapTo<IEnumerable<Expense>, IEnumerable<ExpenseResponse>>();
        }

        public async Task<ExpenseResponse> FindExpenseByIdAsync(int id)
        {
            var expense = await _expenseRepository.FindByPredicateAsync(x => x.ExpenseId == id, null, true);

            return expense is null
                ? null
                : _expenseMapper.DomainToDtoExpense(expense);
        }
    }
}
