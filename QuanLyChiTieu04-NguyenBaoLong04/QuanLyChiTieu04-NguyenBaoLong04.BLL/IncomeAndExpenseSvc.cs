using QuanLyChiTieu04_NguyenBaoLong04.Common.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Reg;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.BLL
{
    public class IncomeAndExpenseSvc : GenericSvc<IncomeAndExpenseRep, IncomeAndExpense>
    {
        private IncomeAndExpenseRep incomeAndExpenseRep;
        public IncomeAndExpenseSvc()
        {
            incomeAndExpenseRep = new IncomeAndExpenseRep();
        }

        public SingleRsp DeleteIncomeAndExpenseById(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.DeleteIncomeAndExpenseById(id);
            return res;
        }

        public SingleRsp AddIncomeAndExpense(IncomeAndExpense item)
        {
            var res = new SingleRsp();
            item.UserId = item.UserId > 0 ? item.UserId : null;
            item.GroupId = item.GroupId > 0 ? item.GroupId : null;
            res = incomeAndExpenseRep.AddIncomeAndExpense(item);

            return res;
        }

        public SingleRsp UpdateIncomeAndExpense(IncomeAndExpense item)
        {
            var res = new SingleRsp();
            item.UserId = item.UserId > 0 ? item.UserId : null;
            item.GroupId = item.GroupId > 0 ? item.GroupId : null;
            res = incomeAndExpenseRep.UpdateIncomeAndExpense(item);

            return res;
        }
    }
}
