using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System.Collections.Generic;

namespace QuanLyChiTieu04_NguyenBaoLong04.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private GroupSvc groupSvc;
        public GroupController()
        {
            groupSvc = new GroupSvc();
        }

        [HttpGet("/group/")]
        public IActionResult GetGroup([FromQuery(Name = "name")] string name,
             [FromQuery(Name = "page")] string page,
             [FromQuery(Name = "pageSize")] string pageSize)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("name", name);
            paramList.Add("page", page);
            paramList.Add("pageSize", pageSize);

            var res = new SingleRsp();
            res = groupSvc.Get(paramList);
            return Ok(res);
        }

        [HttpDelete("/group/delete/{id}")]
        public IActionResult DeleteGroupById(int id)
        {
            var res = new SingleRsp();
            res = groupSvc.Delete(id);
            return Ok(res);
        }

        [HttpPost("/group/add")]
        public IActionResult Add([FromBody] Group item)
        {
            var res = groupSvc.Add(item);
            return Ok(res);
        }
    }
}
