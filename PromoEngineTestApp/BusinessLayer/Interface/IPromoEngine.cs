using PromoEngineTestApp.Entity;

namespace PromoEngineTestApp.BusinessLayer.Interface
{
    public interface IPromoEngine
    {
        void CheckOut(Order order);
    }
}