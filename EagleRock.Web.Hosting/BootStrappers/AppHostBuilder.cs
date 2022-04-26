using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Serilog;
//using Serilog.Events;
using EagleRock.Web.Hosting.BootStrappers;

namespace EagleRock
{
    public static class AppHostBuilder
    {
        //public static void InitializeLogger(string[] args, string logLevel = null)
        //{
        //    // TODO configure sink
        //    var loggerBuilder = new LoggerConfiguration()
        //                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
        //                .WriteTo.Sink(, 
        //                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {Message} {NewLine}{Exception}");

        //    if (Enum.TryParse(logLevel, true, out LogEventLevel level))
        //    {
        //        loggerBuilder.MinimumLevel.Is(level);
        //    }

        //    var logger = loggerBuilder
        //        .Enrich.FromLogContext()
        //        .Enrich.WithProperty("AppName", "EagleRock")
        //        .CreateLogger();

        //    Log.Logger = logger;
        //}

        //public static void FlushLogger() => Log.CloseAndFlush();

        public static IHostBuilder Create(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureContainer<ContainerBuilder>(
                    (context, builder) =>
                    {
                        builder.RegisterInstance(args)
                            .AsSelf()
                            .SingleInstance();
                        builder.ConfigureContainer(context.Configuration);
                    })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
                //.UseSerilog();
            return hostBuilder;
        }
    }
}
