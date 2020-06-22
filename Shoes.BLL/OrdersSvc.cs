using Shoes.BLL;
using Shoes.Common.Rsp;
using Shoes.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using Shoes.Common.Req;

namespace Shoes.BLL
{
    using DAL;
    using DAL.Models;

    public class OrdersSvc : GenericSvc<OrdersRep, Orders>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(Orders m)
        {
            var res = new SingleRsp();

            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.ShipName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        


        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public OrdersSvc() { }


        #endregion

        public object SearchOrder(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.ShipName.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPage = ((total) % size) == 0 ? (total / size) : ((int)(total / size) + 1);
            var data = pro.OrderBy(x => x.OrderId).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPage = totalPage,
                Size = size,
                Page = page,
            };
            return res;
        }

        public SingleRsp CreateOrder (CreateOrdersReq ord)
        {
            var res = new SingleRsp();
            Orders orders = new Orders();
            //orders.OrderId= ord.OrderId;
            orders.EmployeeId = ord.EmployeeId;
            orders.OrderDate = ord.OrderDate;
            orders.ShipName = ord.ShipName;
            orders.City = ord.City;
            //orders.Note = ord.Note;
            res = _rep.CreateOrder(orders);
            return res;
        }

        public SingleRsp UpdateOrder(OrdersReq ord)
        {
            var res = new SingleRsp();
            Orders orders = new Orders();
            orders = _rep.Read(ord.OrderId);
            orders.EmployeeId= ord.EmployeeId;
            orders.OrderDate= ord.OrderDate;
            res = _rep.UpdateOrder(orders);
            return res;
        }
        public SingleRsp DeleteOrders(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.RemoveOrders(id);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}