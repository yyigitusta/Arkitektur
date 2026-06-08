using Amazon.Runtime;
using Amazon.S3;
using Artitektur.Business.Services.AboutServices;
using Artitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection AddServicesExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.Scan(opt => opt.FromAssemblyOf<BusinessAssembly>()
            .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var awsOptions = configuration.GetAWSOptions("Aws");
            awsOptions.Region=Amazon.RegionEndpoint.EUNorth1;
            awsOptions.Credentials=new BasicAWSCredentials(
                configuration["Aws:AccessKey"],
                configuration["Aws:SecretKey"]);
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();
            return services;
        }
    }
}
