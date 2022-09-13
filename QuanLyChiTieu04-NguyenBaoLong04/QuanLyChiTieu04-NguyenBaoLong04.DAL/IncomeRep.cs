using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class IncomeRep : GenericRep<QuanLyChiTieuContext, IncomeAndExpense>
    {
        public IncomeRep()
        {

        }

        public override List<IncomeAndExpense> Get(Dictionary<string, string> paramList)
        {
            int userId = Int32.Parse(paramList["userId"]);
            var res = All.Where(i => i.Active == true)
                .Where(i => i.IsIncome == true)
                .Where(i => i.UserId == userId);

            string date = paramList["date"];
            if (!string.IsNullOrEmpty(date)) 
            {
                DateTime validDate;
                DateTime.TryParse(paramList["date"], out validDate);

                res = res.Where(i => i.Date.Equals(validDate));
            }

            string reason = paramList["reason"];
            if (!string.IsNullOrEmpty(reason))
            {
                res = res.Where(i => i.Reason.Contains(reason));
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

        public decimal GetTotalIncomeByMonth(Dictionary<string, string> paramList)
        {
            try
            {
                int userId = Int32.Parse(paramList["userId"]);
                int month = Int32.Parse(paramList["month"]);
                int year = Int32.Parse(paramList["year"]);

                var res = All.Where(i => i.Active == true)
                    .Where(i => i.IsIncome == true)
                    .Where(i => i.UserId == userId)
                    .Where(i => i.Date.Value.Month == month)
                    .Where(i => i.Date.Value.Year == year)
                    .Select(i => i.Amount).Sum();

                return (decimal)res;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public dynamic GetIncomeStatByYear(Dictionary<string, string> paramList)
        {
            try
            {
                int userId = Int32.Parse(paramList["userId"]);
                int year = Int32.Parse(paramList["year"]);

                var res = All.Where(i => i.Active == true)
                    .Where(i => i.IsIncome == true)
                    .Where(i => i.UserId == userId)
                    .Where(i => i.Date.Value.Year == year)
                    .GroupBy(i => i.Date.Value.Month)
                    .Select(i => new { Month = i.Key, TotalAmount = i.Sum(i1 => i1.Amount) });

                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
