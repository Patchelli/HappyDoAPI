using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Business.Enums;
using HappyDo.Business.Extensions;
using HappyDo.Business.Handlers.NotificationSettings;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.UserServices
{
    public sealed class ApplicationUserCommandService : BaseService<ApplicationUser>, IApplicationUserCommandService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IApplicationUserMapper _applicationUserMapper;

        public ApplicationUserCommandService(INotificationHandler notificationHandler,
                                             IValidate<ApplicationUser> validate,
                                             IApplicationUserRepository applicationUserRepository,
                                             IApplicationUserMapper applicationUserMapper)
            : base(notificationHandler, validate)
        {
            _applicationUserRepository = applicationUserRepository;
            _applicationUserMapper = applicationUserMapper;
        }

        public void Dispose() => _applicationUserRepository.Dispose();

        public async Task<bool> CreateUserAsync(ApplicationUserRegisterRequest applicationUserRegisterRequest)
        {
            if (await _applicationUserRepository.HaveInTheDatabaseAsync(u => u.NormalizedUserName == applicationUserRegisterRequest.UserLogin.ToUpper()))
                return _notification.CreateNotification("Cadastro de usuário", EMessage.Exist.GetDescription().FormatTo("Login"));

            var applicationUser = _applicationUserMapper.DtoRegisterToDomain(applicationUserRegisterRequest);

            if (!await EntityValidationAsync(applicationUser)) return false;

            var saveResult = await _applicationUserRepository.SaveAsync(applicationUser);

            if (!saveResult.Succeeded)
                AddIdentityErrors(saveResult);

            return saveResult.Succeeded;
        }

        public async Task<bool> ChangePasswordAsync(ApplicationUserChangePasswordRequest applicationUserChangePasswordRequest)
        {
            var applicationUser = await _applicationUserRepository.FindByPredicateWithSelectorAsync(
                a => a.Id == applicationUserChangePasswordRequest.ApplicationUserId,
                QueryProjectionForChangePassword());

            if (applicationUser is null)
                return _notification.CreateNotification("Alterar senhar", EMessage.NotFound.GetDescription().FormatTo("User"));

            if (!applicationUserChangePasswordRequest.NewPassword.ValidatePassword())
                return _notification.CreateNotification("Alterar senhar", "A senha não atende aos requisitos.");

            var updateResult = await _applicationUserRepository.ChangePasswordAsync(applicationUser,
                                                                                    applicationUserChangePasswordRequest.OldPassword,
                                                                                    applicationUserChangePasswordRequest.NewPassword);

            if (!updateResult.Succeeded)
                AddIdentityErrors(updateResult);

            return updateResult.Succeeded;
        }

        private static Expression<Func<ApplicationUser, ApplicationUser>> QueryProjectionForChangePassword() =>
         a => new()
         {
             Id = a.Id,
             UserName = a.UserName,
             PasswordHash = a.PasswordHash,
             CPF = a.CPF,
             SecurityStamp = a.SecurityStamp,
             ConcurrencyStamp = a.ConcurrencyStamp,
             UserRoles = a.UserRoles
         };

        private void AddIdentityErrors(IdentityResult identityResult)
        {
            foreach (var error in identityResult.Errors)
            {
                _notification.CreateNotification(new DomainNotification("Identidade do usuário", error.Description));
            }
        }
    }

}
