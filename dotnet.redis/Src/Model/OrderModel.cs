using System;

namespace dotnet.redis.Model
{
    public class OrderModel
    {
        public OrderModel()
        {
            CreateTime = DateTime.Now;
        }

        public string OrderNo { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public Nullable<DateTime> OrderTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string OrderName { get; set; }
    }
}
