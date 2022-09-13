using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;

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
