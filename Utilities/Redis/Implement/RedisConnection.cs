using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Utilities.Redis.Interface;

namespace Utilities.Redis.Implement
{
    public class RedisConnection : IRedisConnection, IDisposable
    {
        public IConnectionMultiplexer Connection { get; }
        public RedisConnection(IConfiguration cfg)
        {
            var cs = cfg.GetConnectionString("Redis") ?? throw new InvalidOperationException("Redis CS missing");
            Connection = ConnectionMultiplexer.Connect(cs);
        }
        public void Dispose() => Connection?.Dispose();
    }
}
