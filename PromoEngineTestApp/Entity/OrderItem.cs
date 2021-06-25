namespace PromoEngineTestApp.Entity
{
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(OrderItem item)
        {
            SKU_Id = item.SKU_Id;
            Quantity = item.Quantity;
        }

        public char SKU_Id { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{SKU_Id} {Quantity}";
        }
    }
}
