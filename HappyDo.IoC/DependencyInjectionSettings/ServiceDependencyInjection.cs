using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.ApplicationService.Services.ApplicationRoleServices;
using HappyDo.ApplicationService.Services.AuthenticationServices;
using HappyDo.ApplicationService.Services.LoggersServices;
using HappyDo.ApplicationService.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC.DependencyInjectionSettings
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserLoggerFacadeService, UserLoggerFacadeService>();

            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

            services.AddScoped<IApplicationRoleQueryService, ApplicationRoleQueryService>();
            services.AddScoped<IApplicationUserRoleFacadeService, ApplicationUserRoleFacadeService>();

            services.AddScoped<IApplicationUserCommandService, ApplicationUserCommandService>();
            services.AddScoped<IApplicationUserFacadeService, ApplicationUserFacadeService>();

            services.AddScoped<IUserCommandService, UserCommandService>();
            services.AddScoped<IUserQueryService, UserQueryService>();


            return services;
        }
    }

}
