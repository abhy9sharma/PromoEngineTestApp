using PromoEngineTestApp.BusinessLayer.Interface;
using PromoEngineTestApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PromoEngineTestApp.BusinessLayer
{
    public class PromoEngine : IPromoEngine
    {
        private IEnumerable<SKUPrice> PriceList;
        private IEnumerable<Promotion> Promotions;

        public PromoEngine(IEnumerable<SKUPrice> priceList, IEnumerable<Promotion> promotions)
        {
            PriceList = priceList;
            Promotions = promotions;
        }

        public void CheckOut(Order order)
        {
            var foundItems = new List<OrderItem>();
            if (Promotions != null && Promotions.Count() > 0)
                foreach (var promotion in Promotions)
                {
                    var validatedItems = promotion.Validate(order, foundItems);
                    UpdateValidatedItems(foundItems, validatedItems);
                }

            ApplyRegularPrice(order, foundItems);
        }

        private void ApplyRegularPrice(Order order, List<OrderItem> foundItems)
        {
            foreach (var item in order.Items)
            {
                var validateItem = foundItems.FirstOrDefault(x => x.SKUId == item.SKUId) ?? item;
                var quantity = validateItem.Quantity;
                if (quantity > 0)
                    order.TotalAmount += quantity * PriceList.First(x => x.SKUId == item.SKUId).UnitPrice;
            }
        }

        private static void UpdateValidatedItems(List<OrderItem> foundItems, IEnumerable<OrderItem> validatedItems)
        {
            if (validatedItems == null || validatedItems.Count() < 1)
                return;

            foreach (var item in validatedItems)
                if (!foundItems.Any(x => x.SKUId == item.SKUId))
                    foundItems.Add(item);
        }
    }
}