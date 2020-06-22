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

        [HttpPost("search-order-details")]

        public IActionResult SearchOrderDetails([FromBody]SearchOrderDetailsReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchOrderDetails(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        [HttpPost("create-order-details")]

        public IActionResult CreateOrderDetails([FromBody]CreateOrderDetailReq req)
        {
            var res = _svc.CreateOrderDetails(req);
            return Ok(res);
        }

        [HttpPost("update-order-details")]

        public IActionResult UpdateOrderDetails([FromBody]OrderDetailsReq req)
        {
            var res = _svc.UpdateOrderDetails(req);
            return Ok(res);
        }

        [HttpPost("delete-order-details")]
        public IActionResult DeleteOrderDetails(OrderDetailsReq req)
        {
            var res = _svc.DeleteOrderDetails(req.OrderId);
            return Ok(res);
        }
        private readonly OrderDetailsSvc _svc;
    }
}