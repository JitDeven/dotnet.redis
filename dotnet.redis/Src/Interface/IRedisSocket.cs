using ServiceStack.Redis;

namespace dotnet.redis.Interface
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description: 
    /// </summary>
    public interface IRedisSocket
    {
        RedisClient MasterRedisClient { get; set; }
        RedisClient SlaveRedisClient { get; set; }
    }
}
