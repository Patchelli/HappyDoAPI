using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IApplicationUserFacadeService
    {
        Task<bool> ValidateUserStatusAsync(string userName);
        Task<bool> HasApplicationUserAsync(Expression<Func<ApplicationUser, bool>> predicate);
        Task<bool> CheckLoginAndPasswordAsyncAsync(UserLoginRequest login);
        Task<List<Claim>> FindClaimsByUserNameAsync(string UserName);
        Task<ApplicationUser?> FindApplicationUserByPredicateAsync(Expression<Func<ApplicationUser, bool>> predicate,
                                                                   Expression<Func<ApplicationUser, ApplicationUser>>? selector = null,
                                                                   bool asNoTracking = false);
    }

}
