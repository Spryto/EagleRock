using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EagleRock.Infrastructure;
using EagleRock.Web.Api.Data;
using EagleRock.Web.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EagleRock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrafficDataController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TrafficDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EagleBotStatus>>> GetActiveEagleBots(CancellationToken token)
        {
            var query = new EagleBotStatusQuery() { };
            var response = await _mediator.Query<EagleBotStatusQuery, EagleBotStatusQueryResponse>(query, token);
            return response.BotStatuses;
        }
    }
}
