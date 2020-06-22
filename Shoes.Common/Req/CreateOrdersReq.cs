using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes.Common.Req
{
    public class CreateOrdersReq
    {
        public int EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string City { get; set; }
    }
}
