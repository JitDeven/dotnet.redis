using dotnet.redis.Common;
using dotnet.redis.Interface;
using ServiceStack.Redis;

namespace dotnet.redis.Business
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description: 
    /// </summary>
    public class HashBaseModel : IRedisSocket
    {
        public RedisClient MasterRedisClient { get; set; }
        public RedisClient SlaveRedisClient { get; set; }

        private static object lockMaster = new object();
        private static object lockSlave = new object();

        public HashBaseModel()
        {
            lock (lockMaster)
            {
                if (MasterRedisClient == null)
                {
                    MasterRedisClient = new RedisClient(Config.AppConfig.RedisMasterHost, Config.AppConfig.RedisMasterHostPort);
                }
            }
            lock (lockSlave)
            {
                if (SlaveRedisClient == null)
                {
                    SlaveRedisClient = new RedisClient(Config.AppConfig.RedisSlaveHost, Config.AppConfig.RedisSlavePort);
                }
            }
        }

        public HashBaseModel(string host, int port, string password = null, long db = 0)
        {
            lock (lockMaster)
            {
                if (MasterRedisClient == null)
                {
                    MasterRedisClient = new RedisClient(host, port);
                }
            }
            //lock (lockSlave)
            //{
            //    if (SlaveRedisClient == null)
            //    {
            //        SlaveRedisClient = new RedisClient(Config.AppConfig.RedisSlaveHost, Config.AppConfig.RedisSlavePort);
            //    }
            //}
        }
    }
}
