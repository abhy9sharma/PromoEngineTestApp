using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoEngineTestApp.BusinessLayer;
using PromoEngineTestApp.BusinessLayer.Interface;
using PromoEngineTestApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPromoEnginApp.Base
{
   public class PromoEnginBaseClass
    {
        private static readonly IEnumerable<SKUPrice> PriceList =
      new List<SKUPrice>
      {
        new SKUPrice { SKUId = 'A', UnitPrice = 50 },
        new SKUPrice { SKUId = 'B', UnitPrice = 30 },
        new SKUPrice { SKUId = 'C', UnitPrice = 20 },
        new SKUPrice { SKUId = 'D', UnitPrice = 15 }
      };

        private static readonly IEnumerable<Promotion> Promotions =
          new List<Promotion>
          {
        new Promotion {
          Items = new List<OrderItem> {
            new OrderItem { SKUId = 'A', Quantity = 3 }},
          TotalAmount = 130 },
        new Promotion {
          Items = new List<OrderItem> {
            new OrderItem { SKUId = 'B', Quantity = 2 }},
          TotalAmount = 45 },
        new Promotion {
          Items = new List<OrderItem> {
            new OrderItem { SKUId = 'C', Quantity = 1 },
            new OrderItem { SKUId = 'D', Quantity = 1 }},
          TotalAmount = 30 } };

        protected static readonly IPromoEngine promoEngine = new PromoEngine(PriceList, Promotions);

        protected Order Order;


        protected void GivenOrderForScenarioA()
        {
            Order = new Order
            {
                Items = new List<OrderItem>
                {
                        new OrderItem { SKUId = 'A', Quantity = 1 },
                        new OrderItem { SKUId = 'B', Quantity = 1 },
                        new OrderItem { SKUId = 'C', Quantity = 1 }}
            };
        }

         protected void  GivenOrderForScenarioB()
        {
            Order =
             new Order
             {
                 Items = new List<OrderItem>
               {
            new OrderItem { SKUId = 'A', Quantity = 5 },
            new OrderItem { SKUId = 'B', Quantity = 5 },
            new OrderItem { SKUId = 'C', Quantity = 1 }}
             };
        }

        protected void GivenOrderForScenarioC()
        {
            Order =
              new Order
              {
                  Items = new List<OrderItem>
                {
            new OrderItem { SKUId = 'A', Quantity = 3 },
            new OrderItem { SKUId = 'B', Quantity = 5 },
            new OrderItem { SKUId = 'C', Quantity = 1 },
            new OrderItem { SKUId = 'D', Quantity = 1 }}
              };
        }

        protected void WhenCheckOut()
        {
            promoEngine.CheckOut(Order);
        }

        protected void ThenTotalAmountShouldBe(double ExpectedAmount)
        {
            Assert.IsTrue(Order.TotalAmount == ExpectedAmount);
        }
    }
}
