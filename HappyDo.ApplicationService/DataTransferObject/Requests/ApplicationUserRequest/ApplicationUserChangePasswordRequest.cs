using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRequest
{
    public sealed record ApplicationUserChangePasswordRequest
    {
        public required Guid ApplicationUserId { get; init; }
        public required string OldPassword { get; init; }
        public required string NewPassword { get; init; }
    }

}
