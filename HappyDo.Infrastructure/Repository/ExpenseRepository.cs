using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.Finance;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Infrastructure.ORM.Context;
using HappyDo.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HappyDo.Infrastructure.Repository
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationContext context)
        : base(context)
        {
        }

        public Task<bool> HaveInTheDatabaseAsync(Expression<Func<Expense, bool>> predicate) => DbSet.AnyAsync(predicate);

        public Task<Expense?> FindByPredicateAsync(
         Expression<Func<Expense, bool>> predicate,
         Func<IQueryable<Expense>, IIncludableQueryable<Expense, object>>? include = null,
         bool asNoTracking = false)
        {
            IQueryable<Expense> query = DbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            return query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Expense>> FindAllWithPredicateAsync(
         Expression<Func<Expense, bool>> predicate,
         Func<IQueryable<Expense>, IIncludableQueryable<Expense, object>>? include = null)
        {
            IQueryable<Expense> query = DbSet;

            if (include is not null)
                query = include(query);

            query = query.Where(predicate);
            query = query.OrderByDescending(d => d.ExpenseId);

            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<bool> SaveAsync(Expense expense)
        {
            await DbSet.AddAsync(expense);

            return await SaveInDatabaseAsync();
        }

        public Task<bool> UpdateAsync(Expense expense)
        {
            DbSet.Update(expense);

            return SaveInDatabaseAsync();
        }

        public async Task<bool> DeleteAsync(int expenseId) =>
           await DbSet.Where(b => b.ExpenseId == expenseId).ExecuteDeleteAsync() > 0;
    }
}
