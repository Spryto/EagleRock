using System.Collections.Generic;

namespace EagleRock.Infrastructure.Storage
{
    public interface IStorageProvider
    {
        IEnumerable<T> ReadAllValues<T>(string nameSpace);
        void SetValue<T>(string nameSpace, string key, T value);
    }
}