using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts
{
    public interface IApplicationUserMapper
    {
        ApplicationUser DtoRegisterToDomain(ApplicationUserRegisterRequest applicationUserRegisterRequest);
    }

}
