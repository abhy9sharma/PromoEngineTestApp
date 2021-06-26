namespace PromoEngineTestApp.Entity
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(OrderItem item)
        {
            SKUId = item.SKUId;
            Quantity = item.Quantity;
        }

        public char SKUId { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{SKUId} {Quantity}";
        }
    }
}