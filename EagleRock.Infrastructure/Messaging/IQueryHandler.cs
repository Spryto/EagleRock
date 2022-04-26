using System.Threading;
using System.Threading.Tasks;

namespace EagleRock.Infrastructure
{
    public interface IQueryHandler<in TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : IQueryResponse
    {
        Task<TResponse> HandleAsync(TQuery query, CancellationToken token);
    }
}
