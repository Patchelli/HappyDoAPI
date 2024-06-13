using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Extensions
{
    public static class EncodingExtensions
    {
        public static string GetAllWritableCharacters(this Encoding encoding)
        {
            encoding = Encoding.GetEncoding(encoding.WebName, new EncoderExceptionFallback(), new DecoderExceptionFallback());
            var builder = new StringBuilder();

            var chars = new char[1];
            var bytes = new byte[16];

            for (var i = 20; i <= char.MaxValue; i++)
            {
                chars[0] = (char)i;
                try
                {
                    int count = encoding.GetBytes(chars, 0, 1, bytes, 0);

                    if (count != 0)
                    {
                        builder.Append(chars[0]);
                    }
                }
                catch
                {
                    break;
                }
            }
            return builder.ToString();
        }
    }

}
