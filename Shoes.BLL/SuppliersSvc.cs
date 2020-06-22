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
    using Shoes.Common.Req;

    public class SuppliersSvc : GenericSvc<SuppliersRep, Suppliers>
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
        public override SingleRsp Update(Suppliers m)
        {
            var res = new SingleRsp();

            var m1 = m.SuppliersId > 0 ? _rep.Read(m.SuppliersId) : _rep.Read(m.SuppliersName);
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

        public object SearchSupplier(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.SuppliersName.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPage = ((total) % size) == 0 ? (total / size) : ((int)(total / size) + 1);
            var data = pro.OrderBy(x => x.SuppliersId).Skip(offset).Take(size).ToList();
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

        public SingleRsp CreateSupplier(CreateSupplierReq spl)
        {
            var res = new SingleRsp();
            Suppliers suppliers = new Suppliers();
            //suppliers.SuppliersId = spl.SuppliersId;
            suppliers.SuppliersName = spl.SuppliersName;
            suppliers.City = spl.City;
            res = _rep.CreateSupplier(suppliers);
            return res;
        }

        public SingleRsp UpdateSupplier(SupplierReq spl)
        {
            var res = new SingleRsp();
            Suppliers suppliers= new Suppliers();
            suppliers = _rep.Read(spl.SuppliersId);

            suppliers.SuppliersName = spl.SuppliersName;
            suppliers.City = spl.City;

            res = _rep.UpdateSupplier(suppliers);
            return res;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SuppliersSvc() { }
        #endregion
        public SingleRsp DeleteSuppliers(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.RemoveSuppliers(id);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}