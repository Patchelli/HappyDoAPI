using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Extensions
{
    public static class InterpolationExtension
    {
        public static string FormatTo(this string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }

}
