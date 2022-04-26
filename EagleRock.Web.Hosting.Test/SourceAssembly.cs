using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace EagleRock.Convention.Tests
{
    static class SourceAssembly
    {
        internal static IEnumerable<TypeInfo> AllDefinedTypes()
        {
            var list = new[]
            {
                typeof(EagleRock.EagleBot.Api.IAssemblyMarker),
                typeof(EagleRock.Web.Api.IAssemblyMarker)
            };
            var types = list.SelectMany(x => x.Assembly.DefinedTypes);

            return types;
        }
    }
}
