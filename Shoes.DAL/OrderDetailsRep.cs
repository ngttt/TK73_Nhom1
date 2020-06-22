using Shoes.Common.DAL;
using System.Linq;

namespace Shoes.DAL
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Models;
    using Shoes.Common.Rsp;
    using System;

    public class OrderDetailsRep : GenericRep<quanlybangiayContext, OrderDetails>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public OrderDetails Read1(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }

        public OrderDetails Read2(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove1(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            m = base.Delete(m); //TODO
            return m.OrderId;
        }

        public int Remove2(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m); //TODO
            return m.ProductId;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
        public SingleRsp CreateOrderDetails(OrderDetails od)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.OrderDetails.Add(od);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
                return res;
            }
        }

        public SingleRsp UpdateOrderDetails(OrderDetails od)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.OrderDetails.Update(od);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
                return res;
            }
        }

        public int RemoveOrderDetails(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            Context.Remove(m);
            Context.SaveChanges();
            return m.OrderId;
        }
    }
}