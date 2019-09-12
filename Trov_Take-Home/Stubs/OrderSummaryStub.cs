using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trov_TakeHome.Interfaces;
using Trov_TakeHome.Models;

namespace Trov_TakeHome.Stubs
{
    public class OrderSummaryStub : IOrderSummary
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Random random = new Random();

        public OrderSummaryStub()
        {
        }

        public Response GetOrderSummary(int orderId)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < orderId; i++)
            {
                items.Add(new Item
                {
                    Name = GenerateName(),
                    Price = new Price
                    {
                        Type = "USD",
                        Value = random.NextDouble() + Convert.ToDouble(random.Next())
                    },
                    Quantity = 1
                });
            }

            var nonNullItemCount = items.Where(i => !"".Equals(i.Name) && !string.IsNullOrWhiteSpace(i.Name)).Count();

            Response response = new Response
            {
                Items = items.ToArray(),
                Discount = CalculateDiscount(items.Sum(i=>i.Quantity))
            };

            // OrderTotal = nonNullItemCount > 0 ? items.Sum(i => i.Price.Value) : 0;
            response.OrderTotal = CalculateOrderTotal(response);

            return response;
        }

        private double CalculateOrderTotal(Response response)
        {
            double orderTotal = 0;

            foreach(Item item in response.Items)
            {
                orderTotal += (item.Price.Value * item.Quantity);
            }

            return orderTotal;
        }

        private static double CalculateDiscount(int totalQuantity)
        {
            if(totalQuantity > 30)
            {
                return .2;
            }else if(totalQuantity<31 && totalQuantity > 20)
            {
                return .1;
            }else if(totalQuantity<21 && totalQuantity > 10)
            {
                return .05;
            }

            return 0;
        }

        private static string GenerateName()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sb.Append(GenerateLetter());
            }

            return sb.ToString();
        }

        private static string GenerateLetter()
        {
            return letters[random.Next(letters.Length)].ToString();
        }
    }
}