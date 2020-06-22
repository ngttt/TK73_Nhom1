using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes.Common.Req
{
    public class OrderDetailsReq
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? Discount { get; set; }
        public string OrderDetailsName { get; set; }
    }
}
