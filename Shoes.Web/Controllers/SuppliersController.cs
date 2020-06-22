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
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public SuppliersController()
        {
            _svc = new SuppliersSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getSupplierById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllSupplier()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search-supplier")]

        public IActionResult SearchSupplier([FromBody]SearchSupplierReq1 req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchSupplier(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        [HttpPost("create-supplier")]

        public IActionResult CreateSupplier([FromBody]CreateSupplierReq req)
        {
            var res = _svc.CreateSupplier(req);
            return Ok(res);
        }

        [HttpPost("update-supplier")]

        public IActionResult UpdateSupplier([FromBody]SupplierReq req)
        {
            var res = _svc.UpdateSupplier(req);
            return Ok(res);
        }

        [HttpPost("delete-suppliers")]
        public IActionResult DeleteSuppliers (SupplierReq req)
        {
            var res = _svc.DeleteSuppliers(req.SuppliersId);
            return Ok(res);
        }

        private readonly SuppliersSvc _svc;
    }
}