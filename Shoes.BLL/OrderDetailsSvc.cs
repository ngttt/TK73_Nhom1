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
    using Shoes.Common.Req;

    public class OrderDetailsSvc : GenericSvc<OrderDetailsRep, OrderDetails>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public  SingleRsp Read1 (int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read1(id);
            res.Data = m;

            return res;
        }

        public SingleRsp Read2(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read2(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(OrderDetails m)
        {
            var res = new SingleRsp();

            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.ProductId);
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
        public OrderDetailsSvc() { }


        #endregion
        public object SearchOrderDetails(string keword, int page, int size)
        {
            var pro = All.Where(x => x.OrderDetailsName.Contains(keword));
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

        public SingleRsp CreateOrderDetails(CreateOrderDetailReq od)
        {
            var res = new SingleRsp();
            OrderDetails orderdetail = new OrderDetails();
            //orderdetail.OrderId = od.OrderId;
            orderdetail.ProductId = od.ProductId;
            orderdetail.Quantity = od.Quantity;
            orderdetail.Discount = od.Discount;
            orderdetail.OrderDetailsName = od.OrderDetailsName;
            res = _rep.CreateOrderDetails(orderdetail);
            return res;
        }

        public SingleRsp UpdateOrderDetails(OrderDetailsReq od)
        {
            var res = new SingleRsp();
            OrderDetails orderdetail = new OrderDetails();
            orderdetail = _rep.Read1(od.OrderId);
            orderdetail = _rep.Read2(od.ProductId);
            orderdetail.Quantity = od.Quantity;
            orderdetail.Discount = od.Discount;
            orderdetail.OrderDetailsName = od.OrderDetailsName;
            res = _rep.UpdateOrderDetails(orderdetail);
            return res;
        }
        public SingleRsp DeleteOrderDetails(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.RemoveOrderDetails(id);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}