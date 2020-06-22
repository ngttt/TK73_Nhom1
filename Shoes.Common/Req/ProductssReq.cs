using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes.Common.Req
{
    public class ProductssReq
    {
        public int Page { get; set; }
        public int Size { get; set;}
        public int Id { get; set; }
        public string Type { get; set; }
        public string Keyword { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
    }
}
