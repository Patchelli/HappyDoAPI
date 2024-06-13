using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC.DependencyInjectionSettings
{
    public static class PaginationDependencyInjection
    {
        public static void AddPaginationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPaginationQueryService<User>, PaginationQueryService<User>>();
        }
    }

}
