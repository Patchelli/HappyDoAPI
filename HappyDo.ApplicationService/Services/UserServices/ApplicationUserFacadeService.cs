using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.UserServices
{
    public sealed class ApplicationUserFacadeService : IApplicationUserFacadeService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserFacadeService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public Task<bool> HasApplicationUserAsync(Expression<Func<ApplicationUser, bool>> predicate) =>
            _applicationUserRepository.HaveInTheDatabaseAsync(predicate);

        public Task<ApplicationUser?> FindApplicationUserByPredicateAsync(
            Expression<Func<ApplicationUser, bool>> predicate,
            Expression<Func<ApplicationUser, ApplicationUser>>? selector = null,
            bool asNoTracking = false) =>
            _applicationUserRepository.FindByPredicateWithSelectorAsync(predicate, selector, asNoTracking);

        public async Task<bool> ValidateUserStatusAsync(string userName)
        {
            var applicationUser = await _applicationUserRepository.FindByPredicateWithSelectorAsync(
                a => a.NormalizedUserName == userName.ToUpper(),
                QueryProjectionUserIdentityData(),
                true);

            if (applicationUser?.User is null) return false;

            return applicationUser.User.UserStatus == EUserStatus.Active;
        }

        public async Task<bool> CheckLoginAndPasswordAsyncAsync(UserLoginRequest login)
        {
            var loginResult = await _applicationUserRepository.PasswordSignInAsync(login.Login, login.Password);

            return loginResult.Succeeded;
        }

        public async Task<List<Claim>> FindClaimsByUserNameAsync(string userName)
        {
            var applicationUser = await _applicationUserRepository.FindByPredicateWithSelectorAsync(
                u => u.NormalizedUserName == userName.ToUpper(),
                QueryProjectionUserIdentityData(),
                true);

            var userRoles = await _applicationUserRepository.FindAllRolesAsync(applicationUser!);

            var claim = DefaultClaims(applicationUser!);

            claim.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claim;
        }

        private static List<Claim> DefaultClaims(ApplicationUser userApplication) =>
            new()
            {
            new Claim(ClaimTypes.Name, userApplication.UserName!),
            new Claim(ClaimTypes.NameIdentifier, userApplication.Id.ToString()),
            new Claim(ClaimTypes.Actor, userApplication.User.Name)
            };

        private static Expression<Func<ApplicationUser, ApplicationUser>> QueryProjectionUserIdentityData() =>
            a => new ApplicationUser
            {
                Id = a.Id,
                UserName = a.UserName,
                CPF = a.CPF,
                NormalizedUserName = a.NormalizedUserName,
                UserRoles = a.UserRoles,
                User = a.User
            };
    }
}
