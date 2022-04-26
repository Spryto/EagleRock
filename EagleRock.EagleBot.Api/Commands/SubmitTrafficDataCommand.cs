using EagleRock.EagleBot.Data.Traffic;
using EagleRock.Infrastructure;
using System;

namespace EagleRock.EagleBot.Api
{
    public class SubmitTrafficDataCommand : ICommand
    {
        public BotData Record { get; set; }

        public DateTimeOffset RecievedAt { get; set; } 
    }
}
