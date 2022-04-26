using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace EagleRock.IntegrationTests
{
    public class IntegrationTestContext : IAsyncLifetime
    {
        readonly IHost host;

        public IntegrationTestContext()
        {
            var args = new string[] { };
            host = AppHostBuilder
                .Create(args)
                .Build();
            host.Start();
        }

        public Task DisposeAsync()
        {
            host.Dispose();
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            // todo execute test query in data store
            return Task.CompletedTask;
        }
    }
}
