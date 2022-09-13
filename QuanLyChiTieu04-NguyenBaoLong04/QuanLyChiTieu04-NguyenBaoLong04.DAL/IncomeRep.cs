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

            return res.ToList();
        }

        public decimal GetTotalIncomeByMonth(Dictionary<string, string> paramList)
        {
            try
            {
                int userId = Int32.Parse(paramList["userId"]);
                int month = Int32.Parse(paramList["month"]);

                var res = All.Where(e => e.Active == true)
                    .Where(e => e.IsIncome == true)
                    .Where(e => e.UserId == userId)
                    .Where(e => e.Date.Value.Month == month)
                    .Select(e => e.Amount).Sum();

                return (decimal)res;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
