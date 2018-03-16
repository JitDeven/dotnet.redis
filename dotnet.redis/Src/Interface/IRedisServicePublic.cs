using dotnet.redis.Interface;

namespace dotnet.redis.Src.Interface
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-07
    /// Description:
    /// 1 继承IRedisSocket将对外暴露MasterRedisClient，具体的实现又HashBaseModel完成；
    /// 2 不继承则是在使用各个Redis对象时不能直接管理对Redis服务器的访问，只提供数据的操作
    /// 3 如果有些对象需要访问Redis的服务，则有另一个接口来完成
    /// </summary>
    // public interface IHash : IRedisSocket
    interface IRedisServicePublic : IRedisSocket
    {

    }
}
