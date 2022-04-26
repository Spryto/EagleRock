using System;
using System.Collections.Generic;
using System.Text;

namespace EagleRock.Infrastructure
{
    public interface IQuery<T>
        where T : IQueryResponse
    {
    }
}
