using HappyDo.Business.Handlers.ValidationSettings.EntityValidation;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Domain.Entities.UserScope;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC.DependencyInjectionSettings
{
    public static class ValidationDependencyInjection
    {
        public static void AddValidationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IValidate<ApplicationUser>, ApplicationUserValidation>();
            services.AddScoped<IValidate<User>, UserValidation>();
        }
    }

}
