using Shoes.Common.DAL;
using System.Linq;

namespace Shoes.DAL
{
    using Models;
    using Shoes.Common.Req;
    using Shoes.Common.Rsp;
    using System;

    public class OrdersRep : GenericRep<quanlybangiayContext, Orders>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Orders Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            m = base.Delete(m); //TODO
            return m.OrderId;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion

        public SingleRsp CreateOrder(Orders ord)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Orders.Add(ord);
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

        public SingleRsp UpdateOrder(Orders ord)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Orders.Update(ord);
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

        public int RemoveOrders (int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            Context.Remove(m);
            Context.SaveChanges();
            return m.OrderId;
        }
        }
}