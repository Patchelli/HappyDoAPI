using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Responses.AuthenticationLoginResponse
{
    public sealed record AuthenticationLoginResponse
    {
        public required string AccessToken { get; init; }
        public required double Expiry { get; init; }
        public required string Message { get; init; }
    }

}
