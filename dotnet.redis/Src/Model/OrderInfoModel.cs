using System.Collections.Generic;

namespace dotnet.redis.Model
{
    /// <summary>
    /// 复杂对象
    /// </summary>
    public class OrderInfoModel
    {
        public string Token { get; set; }
        public OrderModel OrderModel { get; set; }
        public OrderLink OrderLink { get; set; }
        public List<OrderItemModel> OrderItemModels { get; set; }
    }
}
