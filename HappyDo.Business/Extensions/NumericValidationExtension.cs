using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Extensions
{
    public static class NumericValidationExtension
    {
        public static bool NumericalProportionInFloatValidation(this float value, float min = 0, float max = 10)
        {
            if (value < min) return false;

            return !(value > max);
        }

        public static bool NumericalProportionInIntegerValidation(this int value, int min = 0, int max = 10)
        {
            if (value < min) return false;

            return !(value > max);
        }
    }

}
