using System.Text.Json.Serialization;

namespace HappyDo.API.Settings.Handlers
{
    public static class ControllersHandlerSettings
    {
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            return services;
        }
    }
}