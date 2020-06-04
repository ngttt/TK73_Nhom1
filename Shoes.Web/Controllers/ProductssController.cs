using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shoes.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductssController : ControllerBase
    {
        public ProductssController()
        {
            _svc = new ProductssSvc();
        }

        [HttpPost("Get-by-id")]

        public IActionResult GetProductssById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("Get-all")]

        public IActionResult GetAllProductss()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search-product")]

        public IActionResult SearchProduct([FromBody]SearchProductReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchProduct(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        [HttpPost("create-product")]

        public IActionResult CreateProduct([FromBody]ProductssReq req)
        {        
            var res = _svc.CreateProduct(req);
            return Ok(res);
        }

        [HttpPost("update-product")]

        public IActionResult UpdateProduct([FromBody]ProductssReq req)
        {
            var res = _svc.UpdateProduct(req);
            return Ok(res);
        }

        private readonly ProductssSvc _svc;
    }
}