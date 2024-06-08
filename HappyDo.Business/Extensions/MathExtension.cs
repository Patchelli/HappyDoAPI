using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Extensions
{
    public static class MathExtension
    {
        public static float GetValueReferringToPercentage(this float value, float percent) => value * percent;

        public static float RoundValue(this float value)
        {
            var lowerBound = Math.Floor(value * 10) / 10;
            var upperBound = Math.Ceiling(value * 10) / 10;

            if (value - lowerBound < upperBound - value)
            {
                var lowerResult = MathF.Round((float)lowerBound, 1);

                return lowerResult;
            }

            var upperResult = MathF.Round((float)upperBound, 1);

            return upperResult;
        }
    }
}
