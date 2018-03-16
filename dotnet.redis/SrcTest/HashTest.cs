using dotnet.redis.Business;
using dotnet.redis.Interface;
using dotnet.redis.Utility;
using E6GPS.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.redis.SrcTest
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description: 
    /// </summary>
    public class HashTest
    {
        private const string entityHash = "u_order";

        public static void Run()
        {
            HSet();
            HMSet();
        }

        private static void HSet()
        {
            IRHash hash = new RHash();
            try
            {
                hash.Set(entityHash, "name", "SKU-1");
                LoggerFactory.Info(hash.Get<string>(entityHash, "name"));

                hash.Set(entityHash, "name", "SKU-2");
                LoggerFactory.Info(hash.Get<string>(entityHash, "name"));
            }
            catch (Exception ex)
            {
                LoggerFactory.Error(
                     String.Format("数据查询异常,存储过程:{0}", "prAlarmUnload"), ex);
            }
        }

        private static void HMSet()
        {
            try
            {
                IRHash hash = new RHash();
                var keys = new byte[][]
                {
                     RedisByteHelp.GetByte("name"),
                     RedisByteHelp.GetByte("price"),
                     RedisByteHelp.GetByte("width"),
                     RedisByteHelp.GetByte("productor data"),
                };

                var values = new byte[][]
                    {
                          RedisByteHelp.GetByte("SKU-3"),
                          RedisByteHelp.GetByte("200.10"),
                          RedisByteHelp.GetByte("25"),
                          RedisByteHelp.GetByte(DateTime.Now.ToString()),
                    };

                hash.MSet(entityHash, keys, values);
            }
            catch (Exception ex)
            {
                LoggerFactory.Error(
                     String.Format("数据查询异常,存储过程:{0}", "prAlarmUnload"), ex);
            }
        }
    }
}
