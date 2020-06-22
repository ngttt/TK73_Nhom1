using System;
using System.Collections.Generic;
using System.Text;
using Shoes.Common.Rsp;
using Shoes.Common.BLL;

namespace Shoes.BLL
{
    using DAL;
    using DAL.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Shoes.Common.Req;
    using System.Linq;

    public class ProductssSvc: GenericSvc<ProductssRep, Productss>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        public override SingleRsp Update(Productss m)
        {
            var res = new SingleRsp();
            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.Image);
            if (m1 == null)
            {
                res = base.Update(m);
                res.Data= m;
            }
            return res;
        }

        //Search Product
        public object SearchProduct(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.ProductName.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPage = ((total)%size) == 0 ? (total/size) : ((int) (total/size) +1);
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

        public SingleRsp CreateProduct(CreateProductReq pro)
        {
            var res = new SingleRsp();
            Productss products = new Productss();
            //products.ProductId = pro.ProductId;
            products.ProductName = pro.ProductName;
            products.CategoryId = pro.CategoryId;
            products.SupplierId = pro.SupplierId;
            products.UnitPrice = pro.UnitPrice;
            products.UnitInStock = pro.UnitInStock;
            products.Color = pro.Color;
            products.Image = pro.Image;
            res = _rep.CreateProduct(products);
            return res;
        }

        public SingleRsp UpdateProduct(ProductssReq pro)
        {
            var res = new SingleRsp();
            Productss products = new Productss();
            products = _rep.Read(pro.ProductId.Value);            
            
            products.ProductName = pro.ProductName;
            products.CategoryId = pro.CategoryId;
            products.SupplierId = pro.SupplierId;
            products.UnitPrice = pro.UnitPrice;
            products.UnitInStock = pro.UnitInStock;
            products.Color = pro.Color;
            products.Image = pro.Image;

            res = _rep.UpdateProduct(products);
            return res;
        }
        public SingleRsp DeleteProductss(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.RemoveProductss(id);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}
