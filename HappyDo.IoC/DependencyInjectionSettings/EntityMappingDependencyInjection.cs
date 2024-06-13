using AutoMapper;
using HappyDo.ApplicationService.Interfaces.SpecializedMappingContracts;
using HappyDo.ApplicationService.SpecializedMappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC.DependencyInjectionSettings
{
    public static class EntityMapperDependencyInjection
    {
        public static void AddEntityMapperDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUserMapper, ApplicationUserMapper>();
            services.AddTransient<IUserMapper, UserMapper>();
        }
    }


}
