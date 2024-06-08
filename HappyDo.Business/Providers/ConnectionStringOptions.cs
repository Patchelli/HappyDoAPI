using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Providers
{
    public sealed class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public required string DefaultConnection { get; set; } = string.Empty;
    }

}
