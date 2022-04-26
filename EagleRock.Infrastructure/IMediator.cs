using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.Infrastructure
{
    public interface IMediator
    {
        Task Command<TCommand>(
            TCommand command,
            CancellationToken cancellationToken)
            where TCommand : class, ICommand;

        Task<TQueryResponse> Query<TQuery, TQueryResponse>(
            TQuery query,
            CancellationToken cancellationToken)
            where TQuery : IQuery<TQueryResponse>
            where TQueryResponse : class, IQueryResponse;
    }
}