using HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts
{
    public interface IUserMapper
    {
        User DtoUpdateToDomain(User userInDb, UserUpdateRequest userUpdateRequest);
    }

}
