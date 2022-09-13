using QuanLyChiTieu04_NguyenBaoLong04.Common.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.BLL
{
    public class ExpenseSvc : GenericSvc<ExpenseRep, IncomeAndExpense>
    {
        private ExpenseRep expenseRep;
        public ExpenseSvc()
        {
            expenseRep = new ExpenseRep();
        }

        public override SingleRsp Get(Dictionary<string, string> paramList)
        {
            var res = new SingleRsp();
            res.Data = _rep.Get(paramList);
            return res;
        }

        public SingleRsp GetTotalExpenseByMonth(Dictionary<string, string> paramList)
        {
            var res = new SingleRsp();
            res.Data = _rep.GetTotalExpenseByMonth(paramList);
            return res;
        }
    }
}