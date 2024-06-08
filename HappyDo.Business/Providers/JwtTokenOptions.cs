using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Providers
{
    public sealed class JwtTokenOptions
    {
        public const string SectionName = "JwtToken";

        public required string JwtKey { get; init; }
        public required string Issuer { get; init; }
        public required string Audience { get; init; }
        public required double DurationInHours { get; init; }
    }
}
