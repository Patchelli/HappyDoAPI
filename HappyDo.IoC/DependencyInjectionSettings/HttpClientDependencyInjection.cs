﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.IoC.DependencyInjectionSettings
{
    public static class HttpClientDependencyInjection
    {
        public static void AddHttpClientDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuring third-party HttpRequest integrations
        }
    }

}
