using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string City { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
