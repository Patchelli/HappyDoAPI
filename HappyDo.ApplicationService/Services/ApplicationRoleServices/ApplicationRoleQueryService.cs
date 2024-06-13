using HappyDo.ApplicationService.AutoMapperSettings.Settings;
using HappyDo.ApplicationService.DataTransferObject.Responses.ApplicationRoleResponse;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.ApplicationRoleServices
{
    public sealed class ApplicationRoleQueryService : IApplicationRoleQueryService
    {
        private readonly IApplicationRoleRepository _applicationRoleRepository;

        public ApplicationRoleQueryService(IApplicationRoleRepository applicationRoleRepository)
        {
            _applicationRoleRepository = applicationRoleRepository;
        }

        public async Task<IEnumerable<ApplicationRoleSimpleResponse>> FindAllRolesAsync()
        {
            var roles = await _applicationRoleRepository.FindAllRoleAsync();

            return roles.MapTo<IEnumerable<ApplicationRole>, IEnumerable<ApplicationRoleSimpleResponse>>();
        }
    }

}
