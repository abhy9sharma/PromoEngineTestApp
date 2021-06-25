using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngineTestApp.Entity
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
