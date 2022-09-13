using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;

namespace QuanLyChiTieu04_NguyenBaoLong04.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsUserController : ControllerBase
    {
        private GroupsUserSvc groupsUserSvc;
        public GroupsUserController()
        {
            groupsUserSvc = new GroupsUserSvc();
        }

        [HttpDelete("/group-user/delete/{id}")]
        public IActionResult DeleteGroupUserById(int id)
        {
            var res = new SingleRsp();
            res = groupsUserSvc.DeleteGroupUserById(id);
            return Ok(res);
        }

        [HttpPost("/group-user/join-group")]
        public IActionResult JoinGroup([FromBody] GroupsUser item)
        {
            var res = groupsUserSvc.JoinGroup(item);
            return Ok(res);
        }
    }
}
