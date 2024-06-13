using HappyDo.Business.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC
{
    public static class ProviderOptionsHandler
    {
        public static void AddProviderOptionsHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

            services.AddScoped(sp => sp.GetService<IOptionsMonitor<JwtTokenOptions>>()!.CurrentValue);
            services.Configure<JwtTokenOptions>(configuration.GetSection(JwtTokenOptions.SectionName));

            services.AddScoped(sp => sp.GetService<IOptionsMonitor<ActiveDirectoryOptions>>()!.CurrentValue);
            services.Configure<ActiveDirectoryOptions>(configuration.GetSection(ActiveDirectoryOptions.SectionName));
        }
    }

}
