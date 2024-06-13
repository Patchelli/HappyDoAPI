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
        public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddProviderOptionsHandler(configuration);
            services.AddScoped<ApplicationContext>();
            services.AddScoped<INotificationHandler, NotificationHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationContext>((serviceProvider, options) =>
                options.UseSqlServer(serviceProvider.GetRequiredService<ConnectionStringOptions>().DefaultConnection, sql => sql.CommandTimeout(180)));

            services.AddEntityMapperDependencyInjection();
            services.AddRepositoryDependencyInjection();
            services.AddServiceDependencyInjection();
            services.AddValidationDependencyInjection();
            services.AddHttpClientDependencyInjection(configuration);
            services.AddAuthenticationDependencyInjection(configuration);
            services.AddIdentityDependencyInjection();
            services.AddPaginationDependencyInjection();
        }
    }


}
