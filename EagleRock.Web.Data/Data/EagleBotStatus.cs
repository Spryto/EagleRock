using EagleRock.EagleBot.Data.Traffic;
using System;
using System.Collections.Generic;
using System.Text;

namespace EagleRock.Web.Api.Data
{
    public class EagleBotStatus
    {

        public Guid EagleBotId { get; set; }

        public GPSCoordinate Location { get; set; }

        public string Status { get; set; }

        public TrafficData Traffic { get; set; }
    }
}
