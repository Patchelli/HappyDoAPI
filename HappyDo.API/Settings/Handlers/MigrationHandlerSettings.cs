using HappyDo.Infrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace HappyDo.API.Settings.Handlers
{
    public static class MigrationHandlerSettings
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            appContext.Database.Migrate();

            return webApp;
        }
    }
}
