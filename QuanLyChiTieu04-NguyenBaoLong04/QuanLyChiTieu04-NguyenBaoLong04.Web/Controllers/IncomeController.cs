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
             [FromQuery(Name = "reason")] string reason,
             [FromQuery(Name = "page")] string page,
             [FromQuery(Name = "pageSize")] string pageSize)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("date", date);
            paramList.Add("reason", reason);
            paramList.Add("page", page);
            paramList.Add("pageSize", pageSize);

            var res = new SingleRsp();
            res = incomeSvc.Get(paramList);
            return Ok(res);
        }

        [HttpGet("/income/{userId}/get-total-income-by-month/")]
        public IActionResult GetTotalIncomeByMonth(int userId,
             [FromQuery(Name = "month")] string month,
             [FromQuery(Name = "year")] string year)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("month", month);
            paramList.Add("year", year);

            var res = new SingleRsp();
            res = incomeSvc.GetTotalIncomeByMonth(paramList);
            return Ok(res);
        }

        [HttpGet("/income/{userId}/get-income-stat-by-year/")]
        public IActionResult GetIncomeStatByYear(int userId,
             [FromQuery(Name = "year")] string year)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("year", year);

            var res = new SingleRsp();
            res = incomeSvc.GetIncomeStatByYear(paramList);
            return Ok(res);
        }
    }
}
