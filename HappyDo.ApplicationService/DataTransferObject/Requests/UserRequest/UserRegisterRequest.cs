using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.UserRequest
{
    public sealed record UserRegisterRequest
    {
        public required string UserLogin { get; set; }
        public required string Name { get; set; }
        public EUserStatus UserStatus { get; set; }
        public Guid RoleId { get; set; }
    }
}
