using System;

namespace EagleRock.Web.Api.Data
{
    [Serializable]
    public class EagleBotDataRecord
    {
        public Guid Id { get; set; }
        
        public DateTime TimeRecorded { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string RoadName { get; set; }

        public string TrafficDirection { get; set; }

        public float TrafficFlowRate { get; set; }

        public float VehicleSpeed { get; set; }
    }
}
