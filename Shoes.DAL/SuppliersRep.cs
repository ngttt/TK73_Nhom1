using Shoes.Common.DAL;
using System.Linq;

namespace Shoes.DAL
{
    using Models;
    using Shoes.Common.Rsp;
    using System;

    public class SuppliersRep : GenericRep<quanlybangiayContext, Suppliers>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Suppliers Read(int id)
        {
            var res = All.FirstOrDefault(p => p.SuppliersId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.SuppliersId == id);
            m = base.Delete(m); //TODO
            return m.SuppliersId;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion

        public SingleRsp CreateSupplier(Suppliers spl)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Suppliers.Add(spl);
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

        public SingleRsp UpdateSupplier(Suppliers spl)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Suppliers.Update(spl);
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

        public int RemoveSuppliers(int id)
        {
            var m = base.All.First(i => i.SuppliersId == id);
            Context.Suppliers.Remove(m);
            Context.SaveChanges();
            return m.SuppliersId;
        }

    }
}