using System;

namespace dotnet.redis.Extetion
{
    /// <summary>
    /// Auth:wyg
    /// Data:2018-03-20 10:25:54
    /// Description:Chare 
    /// </summary>
    public static class ConvertionExtensions
    {
        //public static T? ConvertTo<T>(this IConvertible convertibleValue) where T : struct
        //{
        //    if (null == convertibleValue)
        //    {
        //        return null;
        //    }
        //    return (T?)Convert.ChangeType(convertibleValue, typeof(T));
        //}

        public static T ConvertTo<T>(this IConvertible convertibleValue)
        {
            if (null == convertibleValue)
            {
                return default(T);
            }

            if (!typeof(T).IsGenericType)
            {
                return (T)Convert.ChangeType(convertibleValue, typeof(T));
            }
            else
            {
                Type genericTypeDefinition = typeof(T).GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    return (T)Convert.ChangeType(convertibleValue, Nullable.GetUnderlyingType(typeof(T)));
                }
            }
            throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", convertibleValue.GetType().FullName, typeof(T).FullName));
        }
    }
}
