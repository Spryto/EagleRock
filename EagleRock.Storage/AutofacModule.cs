using Autofac;
using EagleRock.Infrastructure.Storage;

namespace EagleRock.Cache
{   
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // storage providers
            builder.RegisterType<RedisStorageProvider>()
                .As<IStorageProvider>()
                .InstancePerLifetimeScope();
        }
    }
}