using EagleRock.Infrastructure;
using EagleRock.Web.Api.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.Web.Api.Queries
{
    sealed class EagleBotStatusQueryHandler : IQueryHandler<EagleBotStatusQuery, EagleBotStatusQueryResponse>
    {
        public async Task<EagleBotStatusQueryResponse> HandleAsync(EagleBotStatusQuery query, CancellationToken token)
        {
            var fake1 = new EagleBotStatus
            {
                Description = "one"
            };
            var fake2 = new EagleBotStatus
            {
                Description = "two"
            };
            var fake3 = new EagleBotStatus
            {
                Description = "three"
            };
            var fakes = new List<EagleBotStatus>() { fake1, fake2, fake3 };
            return new EagleBotStatusQueryResponse { BotStatuses = fakes };
        }
    }
}