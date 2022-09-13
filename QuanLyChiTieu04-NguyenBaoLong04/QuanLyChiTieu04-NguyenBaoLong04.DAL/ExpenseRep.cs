using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class ExpenseRep : GenericRep<QuanLyChiTieuContext, IncomeAndExpense>
    {
        public ExpenseRep()
        {

        }

        public override List<IncomeAndExpense> Get(Dictionary<string, string> paramList)
        {
            int userId = Int32.Parse(paramList["userId"]);
            var res = All.Where(e => e.Active == true)
                .Where(e => e.IsIncome == false)
                .Where(e => e.UserId == userId);

            string date = paramList["date"];
            if (!string.IsNullOrEmpty(date))
            {
                DateTime validDate;
                DateTime.TryParse(paramList["date"], out validDate);

                res = res.Where(e => e.Date.Equals(validDate));
            }

            string reason = paramList["reason"];
            if (!string.IsNullOrEmpty(reason))
            {
                res = res.Where(e => e.Reason.Contains(reason));
            }

            try
            {
                int pageSize = Int32.Parse(string.IsNullOrEmpty(paramList["pageSize"]) ? "0" : paramList["pageSize"]);
                int page = Int32.Parse(string.IsNullOrEmpty(paramList["page"]) ? "1" : paramList["page"]);

                if (pageSize > 0)
                {
                    int offset = (page - 1) * pageSize;
                    return res.Skip(offset).Take(pageSize).ToList();
                }
            }
            catch
            {
                return null;
            }

            return res.ToList();
        }

        public decimal GetTotalExpenseByMonth(Dictionary<string, string> paramList)
        {
            try
            {
                int userId = Int32.Parse(paramList["userId"]);
                int month = Int32.Parse(paramList["month"]);
                int year = Int32.Parse(paramList["year"]);

                var res = All.Where(e => e.Active == true)
                    .Where(e => e.IsIncome == false)
                    .Where(e => e.UserId == userId)
                    .Where(e => e.Date.Value.Month == month)
                    .Where(i => i.Date.Value.Year == year)
                    .Select(e => e.Amount).Sum();

                return (decimal)res;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public dynamic GetExpenseStatByYear(Dictionary<string, string> paramList)
        {
            try
            {
                int userId = Int32.Parse(paramList["userId"]);
                int year = Int32.Parse(paramList["year"]);

                var res = All.Where(e => e.Active == true)
                    .Where(e => e.IsIncome == false)
                    .Where(e => e.UserId == userId)
                    .Where(e => e.Date.Value.Year == year)
                    .GroupBy(e => e.Date.Value.Month)
                    .Select(e => new { Month = e.Key, TotalAmount=e.Sum(e1 => e1.Amount) } );

                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}