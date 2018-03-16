using System;

namespace dotnet.redis.Model
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderItemModel
    {
        public OrderItemModel()
        {
            CreateTime = DateTime.Now;
        }

        public string ProductorName { get; set; }
        public decimal ProductorPrice { get; set; }

        public string OrderNo { get; set; }
        public DateTime? OrderTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
