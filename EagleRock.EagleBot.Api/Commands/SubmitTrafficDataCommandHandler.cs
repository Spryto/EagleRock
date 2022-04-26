using EagleRock.Infrastructure;
using EagleRock.Infrastructure.Storage;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.EagleBot.Api
{
    sealed class SubmitTrafficDataCommandHandler : ICommandHandler<SubmitTrafficDataCommand>
    {
        readonly ILogger logger;
        readonly IStorageProvider storageProvider;

        public SubmitTrafficDataCommandHandler(ILogger _logger, IStorageProvider _storageProvider)        
        {
            logger = _logger;
            storageProvider = _storageProvider;
        }

        public async Task HandleAsync(SubmitTrafficDataCommand command, CancellationToken token)
        {
            logger.Verbose($"Traffic data recieved from EagleBot-{command.EagleBotId}");
            await Task.CompletedTask;
            return;
        }
    }
}
