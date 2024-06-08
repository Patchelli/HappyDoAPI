namespace HappyDo.API.Settings.Handlers
{
    public static class CorsHandlerSettings
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            return services.AddCors(p => p.AddPolicy("DfPolicy", builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed(origin => true)
                       .AllowCredentials();
            }));
        }
    }

}
