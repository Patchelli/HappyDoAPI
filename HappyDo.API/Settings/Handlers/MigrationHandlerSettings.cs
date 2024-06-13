using HappyDo.Infrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace HappyDo.API.Settings.Handlers
{
    public static class MigrationHandler
    {
        public static void MigrateDatabase(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();

            using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            appContext.Database.Migrate();

            var seedHandler = new DbInitializer(appContext);

            seedHandler.Seeding();
        }
    }
}
