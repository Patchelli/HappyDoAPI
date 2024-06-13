using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Infrastructure.ORM.Context;
using HappyDo.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HappyDo.Infrastructure.Repository
{
    public sealed class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(ApplicationContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
            : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<bool> HaveInTheDatabaseAsync(Expression<Func<ApplicationUser, bool>> where) => DbSet.AnyAsync(where);

        public Task<ApplicationUser?> FindByPredicateWithSelectorAsync(
            Expression<Func<ApplicationUser, bool>> predicate,
            Expression<Func<ApplicationUser, ApplicationUser>>? selector = null,
            bool asNoTracking = false)
        {
            IQueryable<ApplicationUser> query = DbSet;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (selector is not null)
                query = query.Select(selector);

            return query.FirstOrDefaultAsync(predicate);
        }

        public Task<IList<string>> FindAllRolesAsync(ApplicationUser applicationUser) =>
            _userManager.GetRolesAsync(applicationUser);

        public Task<IdentityResult> SaveAsync(ApplicationUser entity) =>
            _userManager.CreateAsync(entity, entity.PasswordHash!);

        public Task<IdentityResult> UpdateAsync(ApplicationUser applicationUser) =>
            _userManager.UpdateAsync(applicationUser);

        public Task<string> GenerateTokenToChangePasswordAsync(ApplicationUser entity) =>
            _userManager.GeneratePasswordResetTokenAsync(entity);

        public Task<IdentityResult> ChangePasswordAsync(
            ApplicationUser entity,
            string currentPassword,
            string newPassword)
        {
            DetachedObject(entity);

            return _userManager.ChangePasswordAsync(entity, currentPassword, newPassword);
        }


        public Task<SignInResult> PasswordSignInAsync(string login, string password) =>
            _signInManager.PasswordSignInAsync(login, password, false, false);
    }
}
