using HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.SpecializedMappings
{
    public sealed class UserMapper : IUserMapper
    {
        public User DtoUpdateToDomain(User userInDb, UserUpdateRequest userUpdateRequest)
        {
            userInDb.Name = userUpdateRequest.Name;
            userInDb.UserStatus = userUpdateRequest.UserStatus;

            return userInDb;
        }
    }

}
