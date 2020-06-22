using System;
using System.Collections.Generic;

namespace Shoes.Web.Models
{
    public partial class OrderDetails
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? Discount { get; set; }
        public string OrderDetailsName { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Productss Product { get; set; }
    }
}
