using HappyDo.Domain.Entities.ActionLoggerScope;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.RepositoryContracts
{
    public interface IUserLoggerRepository : IDisposable
    {
        Task<bool> SaveAsync(UserLogger userLogger);
        Task<UserLogger?> FindByPredicateAsync(Expression<Func<UserLogger, bool>> predicate,
                                               Func<IQueryable<UserLogger>, IIncludableQueryable<UserLogger, object>>? include = null,
                                               bool asNoTracking = false);

        Task<IEnumerable<UserLogger>> FindAllByPredicate(Expression<Func<UserLogger, bool>> predicate,
                                                         Func<IQueryable<UserLogger>, IIncludableQueryable<UserLogger, object>>? include = null);
    }

}
