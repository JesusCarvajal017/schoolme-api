using StackExchange.Redis;

namespace Utilities.Redis.Interface
{
    public interface IRedisConnection
    {
        IConnectionMultiplexer Connection { get; }
    }
}
