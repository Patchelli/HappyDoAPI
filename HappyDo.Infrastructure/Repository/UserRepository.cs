using HappyDo.Business.Handlers.PaginationSettings.PaginationFilters;
using HappyDo.Business.Handlers.PaginationSettings;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
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

namespace HappyDo.Infrastructure.Repository
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IPaginationQueryService<User> _paginationQueryService;

        public UserRepository(ApplicationContext context,
            IPaginationQueryService<User> paginationQueryService)
            : base(context)
        {
            _paginationQueryService = paginationQueryService;
        }

        public Task<bool> HaveInTheDatabaseAsync(Expression<Func<User, bool>> predicate) =>
            DbSet.AnyAsync(predicate);

        public Task<PageList<User>> FindAllWitPaginationAsync(PagingParamsUserFilter pagingParams,
            Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
        {
            IQueryable<User> query = DbSet;

            if (include is not null)
                query = include(query);

            query = CreateFilter(query, pagingParams);
            query = query.OrderByDescending(u => u.UserId);

            return _paginationQueryService.CreatePaginationAsync(query, pagingParams.PageSize, pagingParams.PageNumber);
        }

        public Task<User?> FindByPredicateAsync(
            Expression<Func<User, bool>> predicate,
            Expression<Func<User, User>>? selector = null,
            bool asNoTracking = false)
        {
            IQueryable<User> query = DbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (selector is not null)
                query = query.Select(selector);

            return query.FirstOrDefaultAsync(predicate);
        }

        public Task<User?> FindByPredicateWithIncludeAsync(
            Expression<Func<User, bool>> predicate,
            Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<User> query = DbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            return query.FirstOrDefaultAsync(predicate);
        }

        public Task<bool> UpdateAsync(User user)
        {
            DetachedObject(user);

            DbSet.Update(user);

            return SaveInDatabaseAsync();
        }
        private static IQueryable<User> CreateFilter(IQueryable<User> query, PagingParamsUserFilter pagingParams)
        {
            if (pagingParams.UserStatus is not null)
                query = query.Where(u => u.UserStatus == pagingParams.UserStatus);

            if (pagingParams.RoleId is not null)
                query = query.Where(u => u.ApplicationUser!.UserRoles.Any(r => r.RoleId == pagingParams.RoleId));

            return query;
        }
    }
}
