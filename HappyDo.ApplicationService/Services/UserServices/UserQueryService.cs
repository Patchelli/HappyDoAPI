using HappyDo.ApplicationService.DataTransferObject.Responses.UserResponse;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Handlers.PaginationSettings.PaginationFilters;
using HappyDo.Business.Handlers.PaginationSettings;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HappyDo.ApplicationService.AutoMapperSettings.Settings;

namespace HappyDo.ApplicationService.Services.UserServices
{

    public sealed class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository _userRepository;

        public UserQueryService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PageList<UserGridResponse>> FindAllUsersWithPaginationAsync(PagingParamsUserFilter pagingParams)
        {
            var users = await _userRepository.FindAllWitPaginationAsync(pagingParams,
                i => i.Include(u => u.ApplicationUser)
                    .ThenInclude(a => a!.UserRoles)
                    .ThenInclude(ur => ur.Role)!);

            return users.MapTo<PageList<User>, PageList<UserGridResponse>>();
        }

        public async Task<UserDataResponse?> FindByUserIdAsync(int userId)
        {
            var user = await _userRepository.FindByPredicateWithIncludeAsync(u => u.UserId == userId,
                i => i.Include(u => u.ApplicationUser)
                    .ThenInclude(a => a!.UserRoles)
                    .ThenInclude(ur => ur.Role),
                true);

            return user?.MapTo<User, UserDataResponse>();
        }


        private static Expression<Func<User, User>> QueryProjectionToSupervisorResponse() =>
            u => new User
            {
                ApplicationUserId = u.ApplicationUserId,
                Name = u.Name,
            };
    }
}
