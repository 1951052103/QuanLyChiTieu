using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Reg;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;

namespace QuanLyChiTieu04_NguyenBaoLong04.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private IncomeSvc incomeSvc;
        public IncomeController()
        {
            incomeSvc = new IncomeSvc();

        }
        [HttpGet("/{userId}")]
        public IActionResult GetIncomeByUserId(int userId) //[FromBody] SimpleReq simpleReq
        {
            var res = new SingleRsp();
            res = incomeSvc.Get(userId);
            return Ok(res);
        }
    }
}
