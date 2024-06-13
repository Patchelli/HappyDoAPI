using HappyDo.Business.Handlers.PaginationSettings;
using HappyDo.Business.Handlers.PaginationSettings.PaginationFilters;
using HappyDo.Domain.Entities.UserScope;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.RepositoryContracts
{
    public interface IUserRepository : IDisposable
    {
        Task<bool> UpdateAsync(User user);
        Task<bool> HaveInTheDatabaseAsync(Expression<Func<User, bool>> predicate);

        Task<User?> FindByPredicateAsync(Expression<Func<User, bool>> predicate,
                                         Expression<Func<User, User>>? selector = null,
                                         bool asNoTracking = false);

        Task<User?> FindByPredicateWithIncludeAsync(Expression<Func<User, bool>> predicate,
                                                    Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
                                                    bool asNoTracking = false);

        Task<PageList<User>> FindAllWitPaginationAsync(PagingParamsUserFilter pagingParams,
                                                        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null);
    }
}
