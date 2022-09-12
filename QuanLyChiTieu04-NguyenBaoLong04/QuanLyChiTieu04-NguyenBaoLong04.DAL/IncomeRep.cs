using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public IncomeAndExpense Delete(int incomeId)
        {
            var income = base.All.First(i => i.Id == incomeId);
            
            using (var context = new QuanLyChiTieuContext())
            {
                context.IncomeAndExpenses.Remove(income);
                context.SaveChanges();
            }
            return income;
        }
    }
}
