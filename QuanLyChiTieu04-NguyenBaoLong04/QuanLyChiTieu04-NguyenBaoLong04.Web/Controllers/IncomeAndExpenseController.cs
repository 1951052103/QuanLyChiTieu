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
    public class IncomeAndExpenseController : ControllerBase
    {
        private IncomeAndExpenseSvc incomeAndExpenseSvc;
        public IncomeAndExpenseController()
        {
            incomeAndExpenseSvc = new IncomeAndExpenseSvc();
        }

        [HttpDelete("/income-and-expense/delete/{id}")]
        public IActionResult DeleteIncomeById(int id)
        {
            var res = new SingleRsp();
            res = incomeAndExpenseSvc.Delete(id);
            return Ok(res);
        }

        [HttpPost("/income-and-expense/add")]
        public IActionResult AddIncome([FromBody] IncomeAndExpenseReq itemReq)
        {
            var res = incomeAndExpenseSvc.Add(itemReq);
            return Ok(res);
        }
    }
}
