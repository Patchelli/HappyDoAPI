using HappyDo.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HappyDo.Infrastructure.ORM.Context;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.ActionLoggerScope;

namespace HappyDo.Infrastructure.Repository
{
    public sealed class UserLoggerRepository : BaseRepository<UserLogger>, IUserLoggerRepository
    {
        public UserLoggerRepository(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<UserLogger>> FindAllByPredicate(
            Expression<Func<UserLogger, bool>> predicate,
            Func<IQueryable<UserLogger>, IIncludableQueryable<UserLogger, object>>? include = null)
        {
            IQueryable<UserLogger> query = DbSet;

            if (include is not null)
                query = include(query);

            query = query.Where(predicate)
                .AsNoTracking();

            return await query.ToListAsync();
        }

        public Task<UserLogger?> FindByPredicateAsync(
            Expression<Func<UserLogger, bool>> predicate,
            Func<IQueryable<UserLogger>, IIncludableQueryable<UserLogger, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<UserLogger> query = DbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            return query.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> SaveAsync(UserLogger userLogger)
        {
            await DbSet.AddAsync(userLogger);

            return await SaveInDatabaseAsync();
        }
    }
}
