using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Productss = new HashSet<Productss>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Productss> Productss { get; set; }
    }
}
