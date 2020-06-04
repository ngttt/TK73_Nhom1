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
    public class OrderDetailsController : ControllerBase
    {
        public OrderDetailsController()
        {
            _svc = new OrderDetailsSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getODByIdOfOrderID([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read1(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllOD()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        private readonly OrderDetailsSvc _svc;
    }
}