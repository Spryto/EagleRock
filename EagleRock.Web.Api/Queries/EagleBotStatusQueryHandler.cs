using EagleRock.EagleBot.Data.Traffic;
using EagleRock.Infrastructure;
using EagleRock.Infrastructure.Storage;
using EagleRock.Web.Api.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.Web.Api.Queries
{
    sealed class EagleBotStatusQueryHandler : IQueryHandler<EagleBotStatusQuery, EagleBotStatusQueryResponse>
    {
        private IStorageProvider storageProvider;

        public EagleBotStatusQueryHandler(IStorageProvider _storageProvider)
        {
            storageProvider = _storageProvider;
        }

        public async Task<EagleBotStatusQueryResponse> HandleAsync(EagleBotStatusQuery query, CancellationToken token)
        {
            // TODO remove hard-coded redis namespacing
            var allStatuses = storageProvider.ReadAllValues<BotData>("EagleBot:Record");
            var botStatuses = allStatuses.Select(Status).ToList();
            return new EagleBotStatusQueryResponse { BotStatuses = botStatuses };
        }

        private static EagleBotStatus Status(BotData data)
        {
            return new EagleBotStatus
            {
                EagleBotId = data.EagleBotId,
                Location = data.CurrentLocation,
                Status = StatusDescription(data.DataRecordedAt),
                Traffic = data.TrafficData
            };
        }

        private static string StatusDescription(DateTimeOffset timeRecorded)
        {
            if (DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(2)) > timeRecorded)
            {
                return "Online";
            }

            if (DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(15)) > timeRecorded)
            {
                return "Recent Data";
            }

            if (DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(60)) > timeRecorded)
            {
                return "Disconnected";
            }

            return "Serious Issue";
        }
    }
}