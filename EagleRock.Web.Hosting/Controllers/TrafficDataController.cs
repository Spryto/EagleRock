using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EagleRock.EagleBot.Api;
using EagleRock.Infrastructure;
using EagleRock.Web.Api.Data;
using EagleRock.Web.Api.Queries;
using EagleRock.EagleBot.Data.Traffic;
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

        [HttpPut]
        public async Task RecordEagleBotData([FromBody] EagleBotDataRecord record, CancellationToken token)
        {
            var command = new SubmitTrafficDataCommand()
            {
                RecievedAt = DateTime.UtcNow,
                Record = new BotData
                {
                    EagleBotId = record.Id,
                    CurrentLocation = new GPSCoordinate { Latitude = record.Latitude, Longitude = record.Longitude },
                    DataRecordedAt = record.TimeRecorded,
                    TrafficData = new TrafficData
                    {
                        RoadName = record.RoadName,
                        FlowRate = record.TrafficFlowRate,
                        VehicleSpeed = record.VehicleSpeed,
                        FlowDirection = TryParseDirection(record)
                    }
                }

            };
            await _mediator.Command<SubmitTrafficDataCommand>(command, token);
        }

        private static TrafficDirection TryParseDirection(EagleBotDataRecord record)
        {
            object direction;
            if (Enum.TryParse(typeof(TrafficDirection), record.TrafficDirection, true, out direction))
            {
                return (TrafficDirection)direction;
            }
            return TrafficDirection.Northbound;
        }
    }
}
