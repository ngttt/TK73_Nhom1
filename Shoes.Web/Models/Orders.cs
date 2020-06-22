using System;
using System.Collections.Generic;

namespace Shoes.Web.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string City { get; set; }
        public string Note { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
