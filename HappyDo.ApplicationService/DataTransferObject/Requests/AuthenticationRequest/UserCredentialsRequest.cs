using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest
{
    public sealed record UserCredentialsRequest(Guid UserApplicationId,
                                              string UserRole);

}
