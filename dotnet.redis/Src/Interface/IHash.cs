namespace dotnet.redis.Interface
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description:继承IRedisSocket将对外暴露MasterRedisClient
    /// </summary>
    public interface IRHash : IRedisService
    {
        /// <summary>
        /// 将单个 field-value (域-值)对设置到哈希表 key 中
        /// </summary>
        /// <param name="hashID"></param>
        /// <param name="hashKey">读取的键</param>
        /// <returns></returns>
        long Set(string hashID, string hashKey, string hsValue);

        /// <summary>
        /// 读取单个hash的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashID"></param>
        /// <param name="hkey"></param>
        /// <returns></returns>
        T Get<T>(string hashID, string hkey);

        /// <summary>
        /// 获取hashID的实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashid"></param>
        /// <returns></returns>
        T Get<T>(string hashid) where T : class;

        /// <summary>
        /// 同时将多个 field-value (域-值)对设置到哈希表的key中
        /// </summary>
        /// <param name="hashID"></param>
        /// <param name="hashKeys"></param>
        /// <param name="values"></param>
        void MSet(string hashID, byte[][] hashKeys, byte[][] values);

        /// <summary>
        /// Save entity to redis hash
        /// if hashID has exists then edit values
        /// if hashid not exists then insert values to redis database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashID"></param>
        /// <param name="entiy"></param>
        bool Save<T>(string hashID, T entiy) where T : class;
    }
}
