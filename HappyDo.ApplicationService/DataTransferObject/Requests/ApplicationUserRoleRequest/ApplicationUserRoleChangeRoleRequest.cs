using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.ApplicationUserRoleRequest
{
    public sealed record ApplicationUserRoleChangeRoleRequest
    {
        public required int UserId { get; init; }
        public required Guid NewRoleId { get; init; }
        public required DateTime UpdateDate { get; init; }
        public required string ReasonForUpdate { get; init; }
    }

}
