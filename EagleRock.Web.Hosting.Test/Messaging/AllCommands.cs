using EagleRock.Infrastructure;
using System;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace EagleRock.Convention.Tests
{
    public class AllCommands
    {
        [Theory]
        [MemberData(nameof(GetCommandTypes))]
        public void HaveExactlyOneHandler(Type commandType)
        {
            var commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            var countResponseHandler = SourceAssembly
                .AllDefinedTypes()
                .Count(t => t.ImplementedInterfaces.Contains(commandHandlerType));
            countResponseHandler.Should().Be(1);
        }

        public static TheoryData<Type> GetCommandTypes()
        {
            var data = new TheoryData<Type>();
            var commandInterface = typeof(ICommand);
            var types = SourceAssembly
                .AllDefinedTypes()
                .Where(t => !t.IsInterface && commandInterface.IsAssignableFrom(t))
                .ToList();

            types.ForEach(x =>
            {
                data.Add(x);
            });

            return data;
        }
    }
}
