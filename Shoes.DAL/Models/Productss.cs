using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class Productss
    {
        public Productss()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
