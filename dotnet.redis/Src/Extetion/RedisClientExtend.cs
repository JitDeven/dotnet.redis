using dotnet.redis.Utility;
using E6GPS.Logger;
using ServiceStack.Redis;
using System;

namespace dotnet.redis.Extetion
{
    /// <summary>
    /// Auth:wyg
    /// Data:2018-03-19 14:44:40
    /// Description:文件操作
    /// </summary>
    public static class RedisClientExtend
    {
        #region Hash Extention

        /// <summary>
        /// Set property value of class type use byte[][] array from  redis database return 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Hvalues">byte[][] arry of hash values from hash database</param>
        /// <returns></returns>
        public static T HValuesToEnity<T>(this byte[][] hValues, byte[][] hKeys, RedisClient db) where T : class
        {
            T entity;
            try
            {
                if (db == null)
                {
                    LoggerFactory.Error("RedisClientExtend HValuesToEnity Method db is Null references.");
                    throw new ArgumentException("RedisClientExtend HValuesToEnity Method db is Null references.");
                }
                entity = (T)Activator.CreateInstance(typeof(T));
                var index = 0;

                /// TODO: 需要判断hKeys和hValues不相等的情况，记录到日志中
                for (int i = 0; i < hValues.Length; i++)
                {
                    var property = typeof(T).GetProperty(RedisHelp.GetString(hKeys[index]));
                    var propertyType = property.DeclaringType;

                    if (property != null)
                    {
                        var value = RedisHelp.GetString(hValues[index]);

                        #region Value值设定

                        /// TODO:兼容各种Nullable的定义，在这转换成功
                        ///在定义Nullable类型时全部使用Nullable<int>等,不能使用 int?方式定义
                        if (!property.PropertyType.IsGenericType)
                        {
                            // 非泛型
                            property.SetValue(entity, string.IsNullOrEmpty(value) ? null :
                                Convert.ChangeType(value, property.PropertyType), null);
                        }
                        else
                        {
                            //泛型Nullable<>
                            Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                            if (genericTypeDefinition == typeof(Nullable<>))
                            {
                                property.SetValue(entity, string.IsNullOrEmpty(value) ? null :
                                    Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType)), null);
                            }
                        }   
                        #endregion  
                    }
                    else
                    {
                        LoggerFactory.Error("Get Property from redis database is not match with type of class property,May be number is not equals,or property name not equals,or class");
                    }

                    index++;
                }
                return entity;
            }
            catch (System.InvalidCastException castEx)
            {
                throw new ArgumentException(castEx.Message + "\n The exception help information as follo\n If Model class property delcare type is Nullable then please use genericType define,not use character ?" + "\n");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region string

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldVal"></param>
        /// <returns></returns>
        public static Object ToObject(this string oldVal)
        {
            return (Object)oldVal;
        }

        #endregion
    }
}

//if (!property.PropertyType.IsGenericType)
//{
//    //非泛型
//    property.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, property.PropertyType), null);
//}
//else
//{
//    //泛型Nullable<>
//    Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
//    if (genericTypeDefinition == typeof(Nullable<>))
//    {
//        property.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType)), null);
//    }
//}