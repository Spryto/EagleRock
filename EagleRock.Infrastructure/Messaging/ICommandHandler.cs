using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.Infrastructure
{
    public interface ICommandHandler<in T>
        where T : ICommand
    {
        Task HandleAsync(T command, CancellationToken token);
    }
}
