using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Responses.ApplicationRoleResponse
{
    public sealed record ApplicationRoleSimpleResponse
    {
        public Guid ApplicationRoleId { get; init; }
        public required string RoleName { get; init; }
    }

}
