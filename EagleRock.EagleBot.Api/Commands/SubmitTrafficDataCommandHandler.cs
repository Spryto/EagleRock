using EagleRock.EagleBot.Data.Traffic;
using EagleRock.Infrastructure;
using EagleRock.Infrastructure.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.EagleBot.Api
{
    sealed class SubmitTrafficDataCommandHandler : ICommandHandler<SubmitTrafficDataCommand>
    {
        readonly IStorageProvider storageProvider;

        public SubmitTrafficDataCommandHandler(IStorageProvider _storageProvider)        
        {
            storageProvider = _storageProvider;
        }

        public async Task HandleAsync(SubmitTrafficDataCommand command, CancellationToken token)
        {
            var record = command.Record;
            storageProvider.SetValue<BotData>("EagleBot:Record", record.EagleBotId.ToString(), record);
            return;
        }
    }
}
