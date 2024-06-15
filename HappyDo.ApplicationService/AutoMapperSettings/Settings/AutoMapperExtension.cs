using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.AutoMapperSettings.Settings
{
    public static class AutoMapperExtension
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source) =>
            AutoMapperFactoryConfiguration.Mapper!.Map<TSource, TDestination>(source);
    }
}
