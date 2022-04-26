using Autofac;

namespace EagleRock.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacMediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

        }
    }
}