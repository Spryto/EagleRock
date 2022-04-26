using EagleRock.Api.Data.Traffic;
using EagleRock.Infrastructure;
using System;

namespace EagleRock.EagleBot.Api
{
    public class SubmitTrafficDataCommand : ICommand
    {
        public Guid EagleBotId { get; set; }

        public GPSCoordinate CurrentLocation { get; set; }

        public string RoadName { get; set; }

        public TrafficDirection FlowDirection { get; set; }

        public float FlowRate { get; set; }

        public float VehicleSpeed { get; set; }

        public DateTimeOffset RecievedAt { get; set; } 
    }
}
