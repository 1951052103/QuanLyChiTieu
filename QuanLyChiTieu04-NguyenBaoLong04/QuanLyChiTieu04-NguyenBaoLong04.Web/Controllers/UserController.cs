using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Reg;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System.Collections.Generic;

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

        [HttpPost("/user/login")]
        public IActionResult Login([FromBody] UserReq userReq)
        {
            var res = userSvc.Login(userReq);
            return Ok(res);
        }

        [HttpPut("/user/update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var res = userSvc.UpdateUser(user);
            return Ok(res);
        }

        [HttpPost("/user/get-user-list")]
        public IActionResult GetUserList([FromBody] SearchUserReq user,
             [FromQuery(Name = "page")] string page,
             [FromQuery(Name = "pageSize")] string pageSize)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("username", user.Username);
            paramList.Add("page", page);
            paramList.Add("pageSize", pageSize);

            var res = userSvc.GetUserList(paramList);
            return Ok(res);
        }
    }
}