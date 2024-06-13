using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Arguments
{
    public sealed record ChangeRole(Guid ApplicationUserId,
                                 Guid NewRoleId);

}
