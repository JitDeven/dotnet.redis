using System;
using System.Text;

namespace dotnet.redis.Utility
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-05
    /// Description: 
    /// </summary>
    public static class RedisHelp
    {
        #region byte string switch

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ortStr"></param>
        /// <returns></returns>
        public static byte[] GetByte(string ortStr)
        {
            return Encoding.Default.GetBytes(ortStr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ortStr"></param>
        /// <returns></returns>
        public static string GetString(byte[] itme)
        {
            return Encoding.Default.GetString(itme);
        }
           

        #endregion

        #region model property

        /// <summary>
        /// Set class propertys  into new byte[][] Array
        /// Create byte[][] Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Tuple<byte[][], int> GetByteProperty<T>() where T : class
        {
            try
            {
                var entityType = typeof(T);
                var entityPropers = entityType.GetProperties();
                var keys = new byte[entityPropers.Length][];

                for (int i = 0; i < entityPropers.Length; i++)
                {
                    keys[i] = RedisHelp.GetByte(entityPropers[i].Name);
                }
                return Tuple.Create<byte[][], int>(keys, 1);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
