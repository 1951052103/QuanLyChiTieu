using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Reg;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;

namespace QuanLyChiTieu04_NguyenBaoLong04.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }

        [HttpDelete("/user/delete/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var res = new SingleRsp();
            res = userSvc.Delete(id);
            return Ok(res);
        }

        [HttpPost("/user/add")]
        public IActionResult Add([FromBody] User item)
        {
            var res = userSvc.Add(item);
            return Ok(res);
        }
    }
}