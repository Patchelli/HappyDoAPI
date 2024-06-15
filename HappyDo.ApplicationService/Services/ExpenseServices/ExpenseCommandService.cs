using HappyDo.ApplicationService.DataTransferObject.Requests.Expense;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Business.Enums;
using HappyDo.Business.Extensions;
using HappyDo.Business.Handlers.Trace;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.Finance;

namespace HappyDo.ApplicationService.Services.ExpenseServices
{
    public class ExpenseCommandService : BaseService<Expense>, IExpenseCommandService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseMapper _expenseMapper;

        public ExpenseCommandService(INotificationHandler notification,
                                     IValidate<Expense> validate,
                                     IExpenseRepository expenseRepository,
                                     IExpenseMapper expenseMapper)
        : base(notification, validate)
        {
            _expenseRepository = expenseRepository;
            _expenseMapper = expenseMapper;
        }

        public async Task<bool> CreateExpenseAsync(ExpenseRegisterRequest expenseRegisterRequest)
        {
            var expense = _expenseMapper.DtoRegisterExpenseToDomain(expenseRegisterRequest);

            if (!await EntityValidationAsync(expense)) return false;

            var saveResult = await _expenseRepository.SaveAsync(expense);
            if (!saveResult)
            {
                return _notification.CreateNotification(
                    ExpenseTrace.RegisterExpense,
                    "Erro ao salvar despesa.");
            }

            return true;
        }

        public async Task<bool> UpdateExpenseAsync(ExpenseUpdateRequest expenseUpdateRequest)
        {
            var expenseInDb = await _expenseRepository.FindByPredicateAsync(
                x => x.ExpenseId == expenseUpdateRequest.Id && x.ApplicationUserId == expenseUpdateRequest.ApplicationUserId);

            if (expenseInDb is null)
            {
                return _notification.CreateNotification(
                    ExpenseTrace.UpdateExpense,
                    EMessage.NotFound.GetDescription().FormatTo("Despesa não encontrada"));
            }

            var updatedExpense = _expenseMapper.DtoUpdateExpenseToDomain(expenseInDb, expenseUpdateRequest);

            if (!await EntityValidationAsync(updatedExpense)) return false;

            var updateResult = await _expenseRepository.UpdateAsync(updatedExpense);
            if (!updateResult)
            {
                return _notification.CreateNotification(
                    ExpenseTrace.UpdateExpense,
                    "Erro ao atualizar despesa.");
            }

            return true;
        }
    }
}
