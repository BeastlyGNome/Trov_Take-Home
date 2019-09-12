using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trov_TakeHome.Models;

namespace Trov_TakeHome.Interfaces
{
    public interface IOrderSummary
    {
        Response GetOrderSummary(int orderId);
    }
}
