using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest
{
    public sealed record UserLoginRequest
    {
        public required string Login { get; set; }
        public required string Password { get; set; }
    }

}
