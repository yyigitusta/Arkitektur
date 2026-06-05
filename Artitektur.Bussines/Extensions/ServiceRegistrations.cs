using Artitektur.Business.Services.AboutServices;
using Artitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExt(this IServiceCollection services)
        {
            services.Scan(opt => opt.FromAssemblyOf<BusinessAssembly>()
            .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
