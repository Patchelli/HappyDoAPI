using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Responses.UserResponse
{
    public sealed record UserGridResponse
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string RoleName { get; set; }
        public EUserStatus UserStatus { get; set; }
    }

}
