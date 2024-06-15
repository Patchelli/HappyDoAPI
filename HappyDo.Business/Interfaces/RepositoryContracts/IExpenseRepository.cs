using HappyDo.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HappyDo.Business.Interfaces.RepositoryContracts
{
    public interface IExpenseRepository : IDisposable
    {
        Task<bool> SaveAsync(Expense expense);
        Task<bool> UpdateAsync(Expense expense);
        Task<bool> DeleteAsync(int expenseId);
        Task<bool> HaveInTheDatabaseAsync(Expression<Func<Expense, bool>> predicate);
        Task<Expense?> FindByPredicateAsync(Expression<Func<Expense, bool>> predicate,
                                           Func<IQueryable<Expense>, IIncludableQueryable<Expense, object>>? include = null,
                                           bool asNoTracking = false);
        Task<IEnumerable<Expense>> FindAllWithPredicateAsync(Expression<Func<Expense, bool>> predicate,
                                                            Func<IQueryable<Expense>, IIncludableQueryable<Expense, object>>? include = null);
    }

}
