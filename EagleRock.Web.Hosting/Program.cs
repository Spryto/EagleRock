using Serilog;
using System;
using Microsoft.Extensions.Hosting;

namespace EagleRock.Web.Hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // AppHostBuilder.InitializeLogger(args, "Error");
            // AppHostBuilder.InitializeLogger(args, "Information");
            // AppHostBuilder.InitializeLogger(args, "Verbose");

            // TODO add configuration 
            //var settings = new AppSettings
            //{
            //    StorageSettings = new RedisSettings
            //    {
            //    }
            //};

            try
            {
                var host = AppHostBuilder.Create(args).Build();
                host.Run();                
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                // AppHostBuilder.FlushLogger();
            }
        }
    }
}
