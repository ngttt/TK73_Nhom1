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
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
            _svc = new OrdersSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getOrderById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllOrders()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search-order")]

        public IActionResult SearchOrder([FromBody]SearchOrderReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchOrder(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        [HttpPost("create-order")]

        public IActionResult CreateOrder([FromBody]CreateOrdersReq req)
        {
            var res = _svc.CreateOrder(req);
            return Ok(res);
        }

        [HttpPost("update-order")]

        public IActionResult UpdateOrder([FromBody]OrdersReq req)
        {
            var res = _svc.UpdateOrder(req);
            return Ok(res);
        }

        [HttpPost("delete-orders")]
        public IActionResult DeleteOrders(OrdersReq req)
        {
            var res = _svc.DeleteOrders(req.OrderId);
            return Ok(res);
        }
        private readonly OrdersSvc _svc;
    }
}