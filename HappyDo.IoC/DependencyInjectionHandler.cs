using HappyDo.Business.Handlers.NotificationSettings;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Business.Providers;
using HappyDo.Infrastructure.ORM.Context;
using HappyDo.Infrastructure.ORM.UoW;
using HappyDo.IoC.DependencyInjectionSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HappyDo.IoC
{
    public static class DependencyInjectionHandler
    {
        public static IServiceCollection AddDependencyInjectionHandler(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ApplicationContext>()
                    .AddScoped<INotificationHandler, NotificationHandler>()
                    .AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationContext>((serviceProv, options) =>
                options.UseSqlServer(serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection,
                                     sql => sql.CommandTimeout(180)));

            services.AddEntityMappingDependencyInjection()
                .AddRepositoryDependencyInjection()
                .AddServiceDependencyInjection()
                .AddValidationDependencyInjection()
                .AddAuthenticationDependencyInjection(configuration)
                ;

            return services;
        }
    }


}
