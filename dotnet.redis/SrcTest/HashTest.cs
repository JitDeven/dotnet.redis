using dotnet.redis.Business;
using dotnet.redis.Interface;
using dotnet.redis.Model;
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
            //HSet();
            //HMSet();

            Save();
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
                     String.Format("数据查询异常,HMSet", "HMSet"), ex);
            }
        }

        private static void HMSet()
        {
            try
            {
                IRHash hash = new RHash();
                var keys = new byte[][]
                {
                     RedisHelp.GetByte("name"),
                     RedisHelp.GetByte("price"),
                     RedisHelp.GetByte("width"),
                     RedisHelp.GetByte("productor data"),
                };

                var values = new byte[][]
                    {
                          RedisHelp.GetByte("SKU-3"),
                          RedisHelp.GetByte("200.10"),
                          RedisHelp.GetByte("25"),
                          RedisHelp.GetByte(DateTime.Now.ToString()),
                    };

                hash.MSet(entityHash, keys, values);
            }
            catch (Exception ex)
            {
                LoggerFactory.Error(
                     String.Format("数据查询异常,HMSet", "HMSet"), ex);
            }
        }

        /// <summary>
        /// 保存一个Entity实体
        /// </summary>
        private static void Save()
        {
            try
            {
                IRHash hash = new RHash();
                var order = new OrderModel
                {
                    OrderNo = "order1",
                    CreateTime = System.DateTime.Now,
                    OrderTime = System.DateTime.Now.AddDays(-10),
                    OrderName = "wyg"
                };

                // 保存
                var result = hash.Save<OrderModel>(order.OrderNo, order);

                // 保存完了执行更新
                order.OrderName = "wyg1";
                hash.Save<OrderModel>(order.OrderNo, order);

                // 
                var ReaderTest = hash.Get<OrderModel>(order.OrderNo);
                Console.WriteLine(ReaderTest.OrderName);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                LoggerFactory.Error(
                     String.Format("数据查询异常,存储过程:{0}", "Save"), ex);
            }
        }
    }
}