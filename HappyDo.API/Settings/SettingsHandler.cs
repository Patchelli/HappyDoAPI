using HappyDo.API.Settings.Handlers;

namespace HappyDo.API.Settings
{
    public static class SettingsHandler
    {
        public static IServiceCollection AddSettingsHandler(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddProviderOptionsHandler(configuration)
                           .AddControllersConfiguration()
                           .AddFiltersConfiguration()
                           .AddSwaggerConfiguration()
                           .AddCorsConfiguration();
        }
    }

}
