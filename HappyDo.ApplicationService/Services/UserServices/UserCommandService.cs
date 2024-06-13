using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRoleRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.LoggersRequest;
using HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Business.Enums;
using HappyDo.Business.Extensions;
using HappyDo.Business.Handlers.Trace;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.UserServices
{
    public sealed class UserCommandService : BaseService<User>, IUserCommandService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IApplicationUserRoleFacadeService _applicationUserRoleFacadeService;
        private readonly IUserLoggerFacadeService _userLoggerFacadeService;

        public UserCommandService(INotificationHandler notification,
            IValidate<User> validate,
            IUserRepository userRepository,
            IUserMapper userMapper,
            IApplicationUserRoleFacadeService applicationUserRoleFacadeService,
            IUserLoggerFacadeService userLoggerFacadeService)
            : base(notification, validate)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _applicationUserRoleFacadeService = applicationUserRoleFacadeService;
            _userLoggerFacadeService = userLoggerFacadeService;
        }

        public void Dispose() => _userRepository.Dispose();

        public async Task<bool> UpdateRoleAsync(ApplicationUserRoleChangeRoleRequest userRoleChangeRoleRequest,
            UserCredentialsRequest userCredentialsRequest)
        {
            var user = await _userRepository.FindByPredicateAsync(u => u.UserId == userRoleChangeRoleRequest.UserId,
                QueryProjectionForUpdateRole(),
                true);

            if (user is null)
                return _notification.CreateNotification(
                    UserTrace.ChangeRole,
                    EMessage.NotFound.GetDescription().FormatTo("Usuário"));

            if (user.ApplicationUserId == userCredentialsRequest.UserApplicationId)
                return _notification.CreateNotification(
                    UserTrace.ChangeRole,
                    "Adm não pode alterar seu proprio perfil.");

            if (!await _applicationUserRoleFacadeService.ChangeRoleAsync(user.ApplicationUserId,
                    userRoleChangeRoleRequest.NewRoleId))
                return _notification.CreateNotification(
                    UserTrace.ChangeRole,
                    "Erro ao persistir as alterações de função.");

            return await _userLoggerFacadeService.CreateLoggerAsync(
                new UserLoggerRequest(ELoggerAction.Update,
                    userRoleChangeRoleRequest.UpdateDate,
                    userCredentialsRequest.UserRole,
                    UserTrace.ChangeRole,
                    userRoleChangeRoleRequest.ReasonForUpdate,
                    userRoleChangeRoleRequest.UserId,
                    userCredentialsRequest.UserApplicationId));
        }

        public async Task<bool> UpdateUserAsync(UserUpdateRequest userUpdateRequest)
        {
            var user = await _userRepository.FindByPredicateAsync(
                u => u.UserId == userUpdateRequest.UserId,
                QueryProjectionForUpdate());

            if (user is null)
                return _notification.CreateNotification(
                    UserTrace.Update,
                    EMessage.NotFound.GetDescription().FormatTo("Usuário"));

            var updatedUser = _userMapper.DtoUpdateToDomain(user, userUpdateRequest);

            if (!await EntityValidationAsync(updatedUser)) return false;

            return await _userRepository.UpdateAsync(updatedUser);
        }


        public async Task<bool> ActivateOrDeactivateUserAsync(int userId)
        {
            var user = await _userRepository.FindByPredicateAsync(u => u.UserId == userId);

            if (user is null)
                return _notification.CreateNotification(
                    UserTrace.ActiveOrInactive,
                    EMessage.NotFound.GetDescription().FormatTo("Usuário"));

            user.UserStatus = user.UserStatus == EUserStatus.Active
                ? EUserStatus.Inactive
                : EUserStatus.Active;

            return await _userRepository.UpdateAsync(user);
        }


        private static Expression<Func<User, User>> QueryProjectionForUpdate() =>
            u => new User
            {
                UserId = u.UserId,
                Name = u.Name,
                ApplicationUserId = u.ApplicationUserId,
                UserStatus = u.UserStatus,
            };


        private static Expression<Func<User, User>> QueryProjectionForUpdateRole() =>
            u => new User
            {
                UserId = u.UserId,
                Name = u.Name,
                ApplicationUserId = u.ApplicationUserId
            };
    }
}
