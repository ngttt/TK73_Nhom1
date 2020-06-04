using Shoes.BLL;
using Shoes.Common.Rsp;
using Shoes.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shoes.BLL
{
    using DAL;
    using DAL.Models;

    public class OrderDetailsSvc : GenericSvc<OrderDetailsRep, OderDetails>
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
        public override SingleRsp Update(OderDetails m)
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
    }
}