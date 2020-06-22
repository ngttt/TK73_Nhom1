using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes.Common.Req
{
    public class CreateOrderDetailReq
    {
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? Discount { get; set; }
        public string OrderDetailsName { get; set; }
    }
}
