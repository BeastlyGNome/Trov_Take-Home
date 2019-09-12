using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trov_TakeHome.Interfaces;
using Trov_TakeHome.Models;
using Trov_TakeHome.Stubs;

namespace Trov_TakeHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderSummaryController : ControllerBase
    {
        private readonly IOrderSummary _orderSummary;

        public OrderSummaryController(IOrderSummary orderSummary)
        {
            _orderSummary = orderSummary;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Response> GetOrderSummary(int id)
        {
            return _orderSummary.GetOrderSummary(id);
        }
    }
}
