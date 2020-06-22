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
    public class EmployeesController : ControllerBase
    {
        public EmployeesController()
        {
            _svc = new EmployeesSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getEmployeesById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllEmployees()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search-employees")]

        public IActionResult SearchEmployees([FromBody]SearchEmployeesReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchEmployees(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        [HttpPost("create-employees")]

        public IActionResult CreateEmployees([FromBody]CreateEmployeesReq req)
        {
            var res = _svc.CreateEmployees(req);
            return Ok(res);
        }

        [HttpPost("update-employees")]

        public IActionResult UpdateEmployees([FromBody]EmployeesReq req)
        {
            var res = _svc.UpdateEmployees(req);
            return Ok(res);
        }

        [HttpPost("delete-employees")]
        public IActionResult DeleteEmployees(EmployeesReq req)
        {
            var res = _svc.DeleteEmployees(req.EmployeeId);
            return Ok(res);
        }
        private readonly EmployeesSvc _svc;
    }
}