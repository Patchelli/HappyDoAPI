using HappyDo.Domain.Arguments;
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
    public interface IApplicationRoleRepository
    {
        Task<IEnumerable<ApplicationRole>> FindAllRoleAsync();
        Task<ApplicationRole?> FindByPredicateAsync(Expression<Func<ApplicationRole, bool>> predicate,
                                                    Func<IQueryable<ApplicationRole>, IIncludableQueryable<ApplicationRole, object>>? include = null,
                                                    bool asNoTracking = false);
    }

}
