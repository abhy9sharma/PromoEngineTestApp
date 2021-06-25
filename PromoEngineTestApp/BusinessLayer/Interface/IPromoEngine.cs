using PromoEngineTestApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngineTestApp.BusinessLayer.Interface
{
    interface IPromoEngine
    {
        void CheckOut(Order order);
    }
}
