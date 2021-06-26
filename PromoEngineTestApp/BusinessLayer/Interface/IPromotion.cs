using PromoEngineTestApp.Entity;
using System.Collections.Generic;

namespace PromoEngineTestApp.BusinessLayer.Interface
{
    public interface IPromotion
    {
        IEnumerable<OrderItem> Validate(Order order, IEnumerable<OrderItem> validatedItems);
    }
}