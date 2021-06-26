using System.Collections.Generic;

namespace PromoEngineTestApp.Entity
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}