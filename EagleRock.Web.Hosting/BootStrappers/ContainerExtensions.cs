using Autofac;
using AutofacSerilogIntegration;
using Microsoft.Extensions.Configuration; 

namespace EagleRock.Web.Hosting.BootStrappers
{
    static class ContainerExtensions
    {
        internal static void ConfigureContainer(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterLogger(autowireProperties: true);

            //var storageSettings = configuration.GetSection(nameof(StorageSettings)).Get<StorageSettings>();
            //if (storageSettings == null)
            //{
            //    throw new InvalidOperationException($"{nameof(StorageSettings)} is required.");
            //}

            // builder.RegisterInstance(storageSettings).SingleInstance();
            Configure(builder);
        }

        static void Configure(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(
                typeof(EagleRock.Infrastructure.AutofacModule).Assembly,
                typeof(EagleRock.Web.Api.AutofacModule).Assembly,
                typeof(EagleRock.EagleBot.Api.AutofacModule).Assembly,
                typeof(EagleRock.Cache.AutofacModule).Assembly);
        }
    }
}
