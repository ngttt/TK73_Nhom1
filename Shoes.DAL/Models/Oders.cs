using System;
using System.Collections.Generic;

namespace Shoes.DAL.Models
{
    public partial class Oders
    {
        public Oders()
        {
            OderDetails = new HashSet<OderDetails>();
        }

        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string City { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ICollection<OderDetails> OderDetails { get; set; }
    }
}
