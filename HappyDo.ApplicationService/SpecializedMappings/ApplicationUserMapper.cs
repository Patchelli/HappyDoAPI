using HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.Domain.Entities.UserScope;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.SpecializedMappings
{
    public sealed class ApplicationUserMapper : IApplicationUserMapper
    {
        public ApplicationUser DtoRegisterToDomain(ApplicationUserRegisterRequest applicationUserRegisterRequest) =>
            new()
            {
                UserName = applicationUserRegisterRequest.UserLogin,
                Email = applicationUserRegisterRequest.UserLogin,
                PhoneNumber = applicationUserRegisterRequest.PhoneNumber,
                CPF = applicationUserRegisterRequest.CPF,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                PasswordHash = applicationUserRegisterRequest.Password,
                UserRoles = new List<ApplicationUserRole>()
                {
                new()
                {
                    RoleId = applicationUserRegisterRequest.RoleId
                }
                },
                User = new User()
                {
                    Name = applicationUserRegisterRequest.Name,
                    UserStatus = applicationUserRegisterRequest.UserStatus,
                }
            };
    }

}
