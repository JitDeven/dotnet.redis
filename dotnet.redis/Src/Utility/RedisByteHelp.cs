using System.Text;

namespace dotnet.redis.Utility
{
    /// <summary>
    /// Auth:annydi
    /// Date:2017-07-05
    /// Description: 
    /// </summary>
    public static class RedisByteHelp
    {
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
    }
}
