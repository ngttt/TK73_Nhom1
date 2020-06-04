using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Productss = new HashSet<Productss>();
        }

        public int SuppliersId { get; set; }
        public string SuppliersName { get; set; }
        public string City { get; set; }

        public virtual ICollection<Productss> Productss { get; set; }
    }
}
