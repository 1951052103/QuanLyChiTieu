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
            res = expenseSvc.Get(paramList);
            return Ok(res);
        }

        [HttpGet("/expense/{userId}/get-total-expense-by-month/")]
        public IActionResult GetTotalExpenseByMonth(int userId,
             [FromQuery(Name = "month")] string month,
             [FromQuery(Name = "year")] string year)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("month", month);
            paramList.Add("year", year);

            var res = new SingleRsp();
            res = expenseSvc.GetTotalExpenseByMonth(paramList);
            return Ok(res);
        }

        [HttpGet("/expense/{userId}/get-expense-stat-by-year/")]
        public IActionResult GetExpenseStatByYear(int userId,
             [FromQuery(Name = "year")] string year)
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            paramList.Add("userId", userId.ToString());
            paramList.Add("year", year);

            var res = new SingleRsp();
            res = expenseSvc.GetExpenseStatByYear(paramList);
            return Ok(res);
        }
    }
}
