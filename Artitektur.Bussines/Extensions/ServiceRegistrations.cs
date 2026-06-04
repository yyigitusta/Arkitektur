using Artitektur.Business.Services.AboutServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExt(this IServiceCollection services)
        {
            services.AddScoped<IAboutService,AboutService>();


            return services;
        }
    }
}
