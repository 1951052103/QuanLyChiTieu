using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using System.Collections.Generic;

namespace QuanLyChiTieu04_NguyenBaoLong04.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private ExpenseSvc expenseSvc;
        public ExpenseController()
        {
            expenseSvc = new ExpenseSvc();

        }
        [HttpGet("/expense/{userId}")]
        public IActionResult GetIncomeByUserId(int userId,
             [FromQuery(Name = "date")] string date,
             [FromQuery(Name = "reason")] string reason) //[FromBody] SimpleReq simpleReq
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("date", date);
            paramList.Add("reason", reason);

            var res = new SingleRsp();
            res = expenseSvc.Get(paramList);
            return Ok(res);
        }
    }
}
