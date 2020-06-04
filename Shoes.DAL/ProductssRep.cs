using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Shoes.Common.DAL;

namespace Shoes.DAL
{
    using Shoes.Common.Rsp;
    using Shoes.DAL.Models;
    public class ProductssRep : GenericRep<quanlybangiayContext, Productss>
    {
        #region Overrides
        public override Productss Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id );
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        #endregion
        public SingleRsp CreateProduct(Productss pro)
        {
            var res = new SingleRsp();
            using (var context = new quanlybangiayContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Productss.Add(pro);
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

            public SingleRsp UpdateProduct(Productss pro)
            {
                var res = new SingleRsp();
                using (var context = new quanlybangiayContext())
                {
                    using (var tran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var t = context.Productss.Update(pro);
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
    }
}
