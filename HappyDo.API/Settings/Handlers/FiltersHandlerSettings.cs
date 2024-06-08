using HappyDo.API.Filters;

namespace HappyDo.API.Settings.Handlers
{
    public static class FiltersHandlerSettings
    {
        public static IServiceCollection AddFiltersConfiguration(this IServiceCollection services)
        {
            services.AddMvc(config => config.Filters.AddService<NotificationFilter>());
            services.AddMvc(config => config.Filters.AddService<UnitOfWorkFilter>());

            services.AddScoped<NotificationFilter>()
                    .AddScoped<UnitOfWorkFilter>();

            return services;
        }
    }
}