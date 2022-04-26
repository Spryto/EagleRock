
namespace EagleRock.EagleBot.Data.Traffic
{
    public class TrafficData
    {
        public string RoadName { get; set; }

        public TrafficDirection FlowDirection { get; set; }

        public float FlowRate { get; set; }

        public float VehicleSpeed { get; set; }
    }
}
