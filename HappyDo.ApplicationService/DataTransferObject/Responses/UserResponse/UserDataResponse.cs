using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Responses.UserResponse
{
    public sealed record UserDataResponse
    {
        public int UserId { get; set; }
        public required string UserLogin { get; set; }
        public required string Name { get; set; }
        public required string RoleName { get; set; }
        public required Guid RoleId { get; set; }
        public EUserStatus UserStatus { get; set; }
    }
}
