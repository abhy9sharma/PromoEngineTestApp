using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoEngineTestApp.Entity;
using System.Collections.Generic;
using TestPromoEnginApp.Base;

namespace TestPromoEnginApp
{
    [TestClass]
    public class PromoEnginUnitTest : PromoEnginBaseClass
    {
        [TestMethod]
        [TestCategory(@"Unit")]
        public void TestScenarioA()
        {
            //Arrange
            GivenOrderForScenarioA();

            // Act
            WhenCheckOut();

            //Assert
            ThenTotalAmountShouldBe(100);
        }

        [TestMethod]
        public void TestScenarioB()
        {
            //Arrange
            GivenOrderForScenarioB();

            // Act
            WhenCheckOut();

            //Assert
            ThenTotalAmountShouldBe(370);
            
        }

        [TestMethod]
        public void TestScenarioC()
        {
            //Arrange
            GivenOrderForScenarioC();

            // Act
            WhenCheckOut();

            //Assert
            ThenTotalAmountShouldBe(280);
           
        }
    }
}