using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Providers
{
    public sealed class ActiveDirectoryOptions
    {
        public const string SectionName = "ActiveDirectory";

        public required string Domain { get; init; }
        public required string Ip { get; init; }
    }

}
