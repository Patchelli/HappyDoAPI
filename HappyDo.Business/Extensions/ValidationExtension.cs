using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Extensions
{
    public static class ValidationExtension
    {
        public static Dictionary<string, string> ToDictionary(this IList<ValidationFailure> errors)
        {
            var result = new Dictionary<string, string>();

            foreach (var error in errors)
            {
                if (!result.ContainsKey(error.PropertyName))
                    result.Add(error.PropertyName, error.ErrorMessage);
            }

            return result;
        }
    }

}
