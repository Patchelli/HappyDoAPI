using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
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
    public sealed class ApplicationRoleRepository : IApplicationRoleRepository
    {
        private readonly ApplicationContext _context;
        private DbSet<ApplicationRole> DbSet => _context.Set<ApplicationRole>();

        public ApplicationRoleRepository(ApplicationContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<ApplicationRole>> FindAllRoleAsync()
        {
            IQueryable<ApplicationRole> query = DbSet;

            return await query.AsNoTracking().ToListAsync();
        }

        public Task<ApplicationRole?> FindByPredicateAsync(
            Expression<Func<ApplicationRole, bool>> predicate,
            Func<IQueryable<ApplicationRole>, IIncludableQueryable<ApplicationRole, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<ApplicationRole> query = DbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            return query.FirstOrDefaultAsync(predicate);
        }
    }
}
