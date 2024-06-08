using HappyDo.ApplicationService.DataTransferObject.Responses.ApplicationRoleResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IApplicationRoleQueryService
    {
        Task<IEnumerable<ApplicationRoleSimpleResponse>> FindAllRolesAsync();
    }

}
