using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trov_TakeHome.Models
{
    public class Response
    {
        public Item[] Items { get; set; }
        public double OrderTotal { get; set; }
        public double Discount { get; set; }
    }
}
