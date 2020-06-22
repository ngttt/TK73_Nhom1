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

    public class CategoriesSvc : GenericSvc<CategoriesRep, Categories>
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
        public override SingleRsp Update(Categories m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.CategoryName);
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
        public CategoriesSvc() { }


        #endregion

        public object SearchCategory(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.CategoryName.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPage = ((total) % size) == 0 ? (int)(total / size) : ((int)(total / size) + 1);
            var data = pro.OrderBy(x => x.CategoryId).Skip(offset).Take(size).ToList();
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

        public SingleRsp CreateCategory(CreateCategoriesReq ctg)
        {
            var res = new SingleRsp();
            Categories categories= new Categories();
            //categories.CategoryId = ctg.CategoryId;
            categories.CategoryName = ctg.CategoryName;
            res = _rep.CreateCategories(categories);
            return res;
        }

        public SingleRsp UpdateCategory(CategoriesReq spl)
        {
            var res = new SingleRsp();
            Categories categories = new Categories();
            categories = _rep.Read(spl.CategoryId);

            categories.CategoryName = spl.CategoryName;

            res = _rep.UpdateCategories(categories);
            return res;
        }
        public SingleRsp DeleteCategories(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.RemoveCategories(id);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}