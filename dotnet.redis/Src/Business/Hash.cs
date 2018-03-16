using dotnet.redis.Business;
using dotnet.redis.Interface;
using dotnet.redis.Utility;
using ServiceStack.Redis;
using System;

namespace dotnet.redis.Business
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description:外部可访问的接口都在IRHash中，在实例化RHash时用接口变可以控制
    /// </summary>
    public class RHash : HashBaseModel, IRHash
    {
        /// <summary>
        /// 将单个 field-value (域-值)对设置到哈希表 key 中
        /// </summary>
        /// <param name="hashID"></param>
        /// <param name="hashKey">读取的键</param>
        /// <returns></returns>
        public long Set(string hashID, string hashKey, string hashVal)
        {
            var result = 0L;
            try
            {
                result = MasterRedisClient.HSet(hashID, RedisByteHelp.GetByte(hashKey), RedisByteHelp.GetByte(hashVal));
            }
            catch (RedisException ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 读取单个hash的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashID"></param>
        /// <param name="hkey"></param>
        /// <returns></returns>
        public T Get<T>(string hashID, string hkey)
        {
            var result = default(T);
            try
            {
                var getValue = MasterRedisClient.HGet(hashID, RedisByteHelp.GetByte(hkey));
                result = (T)Convert.ChangeType(RedisByteHelp.GetString(getValue), typeof(T));
            }
            catch (RedisException ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 同时将多个 field-value (域-值)对设置到哈希表 key 中
        /// </summary>
        /// <param name="hashID"></param>
        /// <param name="hashKeys"></param>
        /// <param name="values"></param>
        public void MSet(string hashID, byte[][] hashKeys, byte[][] values)
        {
            try
            {
                MasterRedisClient.HMSet(hashID, hashKeys, values);

                //redis_write.HMSet(string.Format("u:{0}:info", Request.Cookies["UserID"].Value),
                //new byte[][] {
                //    Encoding.Unicode.GetBytes("Name") ,
                //    Encoding.Unicode.GetBytes("Sex") ,
                //    Encoding.Unicode.GetBytes("Birth") ,
                //    Encoding.Unicode.GetBytes("iURL") ,
                //    Encoding.Unicode.GetBytes("Info") ,
                //    Encoding.Unicode.GetBytes("RegLocal")
                //},
                //new byte[][] {
                //    Encoding.Unicode.GetBytes(Request["Name"].ToString()),
                //    Encoding.Unicode.GetBytes(Request["Sex"].ToString()),
                //    Encoding.Unicode.GetBytes(Request["Birth"].ToString()),
                //    Encoding.Unicode.GetBytes(Request["iURL"].ToString()),
                //    Encoding.Unicode.GetBytes(Request["Info"].ToString()),
                //    Encoding.Unicode.GetBytes(Request["country"].ToString()+","+Request["province"].ToString()+","+Request["city"].ToString())
                //});
            }
            catch (RedisException ex)
            {
                throw ex;
            }
        }
    }
}
