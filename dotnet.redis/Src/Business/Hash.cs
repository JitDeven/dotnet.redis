using dotnet.redis.Business;
using dotnet.redis.Interface;
using dotnet.redis.Utility;
using ServiceStack.Redis;
using System;
using System.Reflection;
using dotnet.redis.Extetion;

namespace dotnet.redis.Business
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description:外部可访问的接口都在IRHash中，在实例化RHash时用接口变可以控制
    /// </summary>
    public class RHash : HashBaseModel, IRHash
    {
        #region Set

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
                result = MasterRedisClient.HSet(hashID, RedisHelp.GetByte(hashKey), RedisHelp.GetByte(hashVal));
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

        /// <summary>
        /// 提供泛型操作方法，直接保存实体数据到Redis的Hash中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashID"></param>
        /// <param name="entiy"></param>
        public bool Save<T>(string hashID, T entiy) where T : class
        {
            var result = false;
            try
            {
                var entityType = entiy.GetType();
                var entityPropers = entityType.GetProperties();

                // 定义一纬包含一个一纬数组值的二维数组 
                var hashKeys = new byte[entityPropers.Length][];
                var hashValues = new byte[entityPropers.Length][];

                #region 赋值

                var index = 0;
                foreach (var item in entityPropers)
                {
                    hashKeys[index] = RedisHelp.GetByte(item.Name);
                    var itemPro = entityType.GetProperty(item.Name);
                    if (itemPro != null)
                    {
                        var keyVal = string.Empty;
                        if (itemPro.GetValue(entiy, null) != null)
                        {
                            keyVal = (itemPro.GetValue(entiy, null)).ToString();
                        }
                        hashValues[index] = RedisHelp.GetByte(keyVal);
                    }
                    index++;
                }

                MSet(hashID, hashKeys, hashValues);

                #endregion

                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion

        #region Get

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
                var getValue = MasterRedisClient.HGet(hashID, RedisHelp.GetByte(hkey));
                result = (T)Convert.ChangeType(RedisHelp.GetString(getValue), typeof(T));
            }
            catch (RedisException ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取hashID的实体数据
        /// </summary>
        /// <exception cref="NullReferenceException">Return T class instatnce is Null</exception>
        /// <typeparam name="T">Defind model class it property must maping redis return HMGet Byte[][]</typeparam>
        /// <param name="hashid"></param>
        /// <returns>T instatnce</returns>
        public T Get<T>(string hashid) where T : class
        {
            T entity;
            try
            {
                var hKeys = RedisHelp.GetByteProperty<T>().Item1;
                var hValus = MasterRedisClient.HMGet(hashid, hKeys);
                entity = hValus.HValuesToEnity<T>(hKeys, MasterRedisClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        #endregion  
    }
}
