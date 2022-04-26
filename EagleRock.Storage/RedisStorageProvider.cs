using EagleRock.Infrastructure.Storage;
using ServiceStack.Redis;
using System.Collections.Generic;

namespace EagleRock.Cache
{
    public class RedisStorageProvider : IStorageProvider
    {
        private static IRedisClient _redisClient;
        
        public RedisStorageProvider()
        {
            // redis://clientid:password@localhost:6380?ssl=true&db=1
            var clientsManager = new BasicRedisClientManager("localhost:6379");
            _redisClient = clientsManager.GetClient();       
        }

        public void SetValue<T>(string nameSpace, string key, T value) => _redisClient.Set($"{nameSpace}:{key}", value);

        public IEnumerable<T> ReadAllValues<T>(string nameSpace)
        {
            var keys = _redisClient.SearchKeys($"{nameSpace}:"); 
            return _redisClient.GetAll<T>(keys).Values;
        }
    }
}
