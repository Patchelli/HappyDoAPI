using HappyDo.Business.Providers;
using Microsoft.Extensions.Options;

namespace HappyDo.API.Settings.Handlers
{
    public static class ProviderHandlerSettings
    {
        public static IServiceCollection AddProviderOptionsHandler(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

            services.AddScoped(sp => sp.GetService<IOptionsMonitor<JwtTokenOptions>>()!.CurrentValue);
            services.Configure<JwtTokenOptions>(configuration.GetSection(JwtTokenOptions.SectionName));

            return services;
        }
    }
}
