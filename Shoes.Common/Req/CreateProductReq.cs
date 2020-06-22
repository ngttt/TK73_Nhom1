using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes.Common.Req
{
    public class CreateProductReq
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
    }
}
