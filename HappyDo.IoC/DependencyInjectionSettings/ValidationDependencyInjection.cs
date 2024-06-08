using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC.DependencyInjectionSettings
{
    public static class ValidationDependencyInjection
    {
        public static IServiceCollection AddValidationDependencyInjection(this IServiceCollection services)
        {
            return services;
        }
    }

}
