using System;

namespace EagleRock.Infrastructure
{
    public interface ICommand
    {
        DateTimeOffset RecievedAt { get; set; }
    }
}
