using HappyDo.Domain.Entities.UserScope;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.RepositoryContracts
{
    public interface IApplicationUserRepository : IDisposable
    {
        Task<IdentityResult> SaveAsync(ApplicationUser applicationUser);
        Task<IdentityResult> UpdateAsync(ApplicationUser applicationUser);
        Task<SignInResult> PasswordSignInAsync(string login, string password);
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser entity, string currentPassword, string newPassword);
        Task<string> GenerateTokenToChangePasswordAsync(ApplicationUser applicationUser);
        Task<bool> HaveInTheDatabaseAsync(Expression<Func<ApplicationUser, bool>> where);

        Task<IList<string>> FindAllRolesAsync(ApplicationUser applicationUser);
        Task<ApplicationUser?> FindByPredicateWithSelectorAsync(Expression<Func<ApplicationUser, bool>> predicate,
                                                                Expression<Func<ApplicationUser, ApplicationUser>>? selector = null,
                                                                bool asNoTracking = false);
    }

}
