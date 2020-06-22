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
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            _svc = new CategoriesSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("search-categories")]

        public IActionResult SearchCategories([FromBody]SearchCategoriesReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchCategory(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        [HttpPost("create-categories")]

        public IActionResult CreateCategories([FromBody]CreateCategoriesReq req)
        {
            var res = _svc.CreateCategory(req);
            return Ok(res);
        }

        [HttpPost("update-categories")]

        public IActionResult UpdateCategories([FromBody]CategoriesReq req)
        {
            var res = _svc.UpdateCategory(req);
            return Ok(res);
        }

        [HttpPost("delete-categories")]
        public IActionResult DeleteCategories(CategoriesReq req)
        {
            var res = _svc.DeleteCategories(req.CategoryId);
            return Ok(res);
        }
        private readonly CategoriesSvc _svc;
    }
}