using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class OderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? Discount { get; set; }

        public virtual Oders Order { get; set; }
        public virtual Productss Product { get; set; }
    }
}
