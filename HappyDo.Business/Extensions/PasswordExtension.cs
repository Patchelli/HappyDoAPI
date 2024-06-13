using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HappyDo.Business.Extensions
{
    public static partial class PasswordExtension
    {
        public static bool ValidatePassword(this string? password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            Regex regex = ValidatePasswordRegex();

            Match match = regex.Match(password);

            return match.Success;
        }

        public static string GeneratePassword(this string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return string.Empty;

            const string passwordDefault = "@Enaex";

            return $"{passwordDefault}{password}";
        }

        [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,20}$")]
        private static partial Regex ValidatePasswordRegex();
    }

}
