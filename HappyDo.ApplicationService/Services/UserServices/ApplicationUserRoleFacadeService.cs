using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.UserServices
{
    public sealed class ApplicationUserRoleFacadeService : IApplicationUserRoleFacadeService
    {
        private readonly IApplicationUserRoleRepository _applicationUserRoleRepository;

        public ApplicationUserRoleFacadeService(IApplicationUserRoleRepository applicationUserRoleRepository)
        {
            _applicationUserRoleRepository = applicationUserRoleRepository;
        }

        public void Dispose() => _applicationUserRoleRepository.Dispose();

        public Task<bool> ChangeRoleAsync(Guid userId, Guid newRoleId) =>
            _applicationUserRoleRepository.UpdateRoleAsync(new ChangeRole(userId, newRoleId));
    }

}
