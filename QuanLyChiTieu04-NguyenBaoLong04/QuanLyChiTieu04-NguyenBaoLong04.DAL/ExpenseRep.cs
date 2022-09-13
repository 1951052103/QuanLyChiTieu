using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
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

            return res.ToList();
        }
    }
}