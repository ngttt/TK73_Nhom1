using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Orders = new HashSet<Orders>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
