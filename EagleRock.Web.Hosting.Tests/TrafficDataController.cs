using EagleRock.Controllers;
using EagleRock.EagleBot.Data.Traffic;
using EagleRock.Web.Api.Data;
using Xunit;
using FluentAssertions;

namespace EagleRock.Web.Hosting.Tests
{
    public sealed class TrafficDataControllerTests
    {
        [Theory]
        [InlineData("Northbound", TrafficDirection.Northbound)]
        [InlineData("northbound", TrafficDirection.Northbound)]
        [InlineData("NORTHBOUND", TrafficDirection.Northbound)]
        [InlineData("Southbound", TrafficDirection.Southbound)]
        [InlineData("Eastbound", TrafficDirection.Eastbound)]
        [InlineData("Westbound", TrafficDirection.Westbound)]
        public void ParsesTrafficDirection(string directionString, TrafficDirection expectedDirection)
        {
            var record = new EagleBotDataRecord
            {
                TrafficDirection = directionString
            };
            TrafficDataController.TryParseDirection(record).Should().Be(expectedDirection);
        }
    }
}
