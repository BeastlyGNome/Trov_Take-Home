using NUnit.Framework;
using SpecFlowTests.Drivers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class OrderSummaryTestsSteps
    {
        private readonly OrderSummaryDriver _orderSummaryDriver;
        private int id = 0;

        public OrderSummaryTestsSteps(OrderSummaryDriver orderSummaryDriver)
        {
            _orderSummaryDriver = orderSummaryDriver;
        }

        [Given(@"I have (.*) items in my order")]
        public void GivenIHaveItemsInMyOrder(int itemCount)
        {
            id = itemCount;
        }
        
        [When(@"I view the checkout summary")]
        public void WhenIViewTheCheckoutSummary()
        {
            _orderSummaryDriver.GetOrderSummary(id);
        }
        
        [Then(@"there is a (.*) discount applied")]
        public void ThenThereIsADiscountApplied(double expectedDiscount)
        {
            Assert.AreEqual(expectedDiscount, _orderSummaryDriver.GetDiscount());
        }
    }
}
