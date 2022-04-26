using System;

namespace EagleRock.Api.Data.Traffic
{
    /// The traffic data payload should be serialized/de-serialized using an industry-recognized, selfdescribing, language-independent format that can easily be extended. In its first iteration, the 
    /// content is expected to include the following data elements:
    /// - EagleBot unique identifier
    /// - Current location/co-ordinates of the EagleBot
    /// - Timestamp for the data exchange
    /// - Road name under inspection
    /// • Direction of traffic flow
    /// - Rate of traffic flow
    /// - Average vehicle speed

    public class TrafficData
    {
        public Guid EagleBotId { get; set; }

        public GPSCoordinate CurrentLocation { get; set; }

        public DateTimeOffset DataRecordedAt { get; set; }

        public string RoadName { get; set; }

        public TrafficDirection FlowDirection { get; set; }

        public float FlowRate { get; set; }

        public float VehicleSpeed { get; set; }
    }
}
