using PromoEngineTestApp.BusinessLayer.Interface;
using PromoEngineTestApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PromoEngineTestApp.BusinessLayer
{
    public class Promotion : Order, IPromotion
    {
        public IEnumerable<OrderItem> Validate(Order order, IEnumerable<OrderItem> validatedItems)
        {
            var orderItems = new List<OrderItem>();
            if (Items == null || Items.Count < 1)
            { 
                return orderItems; 
            }
               
            foreach (var (promotionItem, orderItem) in from promotionItem in Items
                                                       let orderItem =
                                                       validatedItems.FirstOrDefault(x => x.SKUId == promotionItem.SKUId)
                                                       ?? order.Items.FirstOrDefault(x => x.SKUId == promotionItem.SKUId)
                                                       select (promotionItem, orderItem))
            {
                if (orderItem != null && orderItem.Quantity >= promotionItem.Quantity)
                {
                    if (!orderItems.Any(x => x.SKUId == orderItem.SKUId))
                        orderItems.Add(new OrderItem(orderItem));
                }
                else
                    return null;
            }

            ApplyPromotionPriceAndCalculateRestQuantity(order, orderItems);

            return orderItems;
        }

        private void ApplyPromotionPriceAndCalculateRestQuantity(Order order, List<OrderItem> foundItems)
        {
            var found = foundItems.Count() > 0;
            if (found)
            {
                do
                {
                    order.TotalAmount += TotalAmount;
                    foreach (var (promotionItem, item) in from promotionItem in Items
                                                          let item = foundItems.FirstOrDefault(x => x.SKUId == promotionItem.SKUId)
                                                          where item != null
                                                          select (promotionItem, item))
                    {
                        item.Quantity -= promotionItem.Quantity;
                        if (found)
                            found = item.Quantity >= promotionItem.Quantity;
                    }
                } while (found);
            }
        }
    }
}