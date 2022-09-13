using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChiTieu04_NguyenBaoLong04.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Reg;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System.Collections.Generic;

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
        
        [HttpGet("/income/{userId}")]
        public IActionResult GetIncomeByUserId(int userId,
             [FromQuery(Name = "date")] string date,
             [FromQuery(Name = "reason")] string reason) //[FromBody] SimpleReq simpleReq
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("date", date);
            paramList.Add("reason", reason);

            var res = new SingleRsp();
            res = incomeSvc.Get(paramList);
            return Ok(res);
        }

        [HttpGet("/income/{userId}/get-total-income-by-month/")]
        public IActionResult GetTotalIncomeByMonth(int userId,
             [FromQuery(Name = "month")] string month)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("month", month);

            var res = new SingleRsp();
            res = incomeSvc.GetTotalIncomeByMonth(paramList);
            return Ok(res);
        }
    }
}
