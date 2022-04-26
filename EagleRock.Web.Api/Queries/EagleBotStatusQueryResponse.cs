using EagleRock.Infrastructure;
using EagleRock.Web.Api.Data;
using System.Collections.Generic;

namespace EagleRock.Web.Api.Queries
{
    public class EagleBotStatusQueryResponse : IQueryResponse
    {
        public List<EagleBotStatus> BotStatuses { get; set; }
    }
}
