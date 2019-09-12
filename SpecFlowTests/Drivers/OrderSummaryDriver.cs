using Trov_TakeHome.Controllers;
using Trov_TakeHome.Interfaces;
using Trov_TakeHome.Stubs;

namespace SpecFlowTests.Drivers
{
    public class OrderSummaryDriver
    {
        private readonly OrderSummaryState _state;
        private readonly IOrderSummary _orderSummary;

        public OrderSummaryDriver(OrderSummaryState state)
        {
            _state = state;
            _orderSummary = new OrderSummaryStub();
        }

        public void GetOrderSummary(int id)
        {
            var controller = new OrderSummaryController(_orderSummary);
            _state.ActionResult = controller.GetOrderSummary(id);
        }

        public double GetDiscount()
        {
            return _state.ActionResult.Value.Discount;
        }
    }
}