namespace dotnet.redis.Common
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description: 
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 基础配置
        /// </summary>
        public static class AppConfig
        {
            public const string RedisMasterHost = "192.168.254.137";
            public const int RedisMasterHostPort = 6379;

            public const string RedisSlaveHost = "192.168.254.137";
            public const int RedisSlavePort = 6479;
        }

        /// <summary>
        /// 
        /// </summary>
        public static class MsgConfig
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public static class WebConfig
        {

        }
    }
}
