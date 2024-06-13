using HappyDo.API.Settings.Handlers;

namespace HappyDo.API.Settings
{
    public static class SettingsHandler
    {
        public static void AddSettingsConfigurations(this IServiceCollection services)
        {
            services.AddControllersConfiguration();
            services.AddCorsConfiguration();
            services.AddFiltersConfiguration();
            services.AddSwaggerConfiguration();
        }
    }


}
