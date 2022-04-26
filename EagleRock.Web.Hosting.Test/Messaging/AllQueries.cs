using System;
using System.Linq;
using Autofac;
using EagleRock.Infrastructure;
using FluentAssertions;
using Xunit;

namespace EagleRock.Convention.Tests
{

    public class AllQueries
    {
        [Theory]
        [MemberData(nameof(GetQueryTypes))]
        public void HaveExactlyOneHandler(Type queryType)
        {
            var queryResponseType = queryType.GetInterfaces()[0].GenericTypeArguments[0];
            var queryHandlerType =
                typeof(IQueryHandler<,>).MakeGenericType(queryType, queryResponseType);
            var list = SourceAssembly
                .AllDefinedTypes()
                .Where(t => t.ImplementedInterfaces.Contains(queryHandlerType));

            list.Count().Should().Be(1);
        }

        public static TheoryData<Type> GetQueryTypes()
        {
            var data = new TheoryData<Type>();
            var types = SourceAssembly.AllDefinedTypes();

            foreach (var type in types)
            {
                if (type.IsClosedTypeOf(typeof(IQuery<>)))
                {
                    data.Add(type);
                }
            }

            return data;
        }
    }
}
