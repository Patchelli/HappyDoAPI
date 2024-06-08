using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Arguments
{
    public sealed record UserCredentialsForApp(
        Guid UserId,
        string Email,
        string Name,
        string Role);
}
