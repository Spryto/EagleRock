using System;

namespace EagleRock.EagleBot.Data.Traffic
{
    public class BotData
    {
        public Guid EagleBotId { get; set; }

        public GPSCoordinate CurrentLocation { get; set; }

        public DateTimeOffset DataRecordedAt { get; set; }

        public TrafficData TrafficData { get; set; }
        
    }
}
