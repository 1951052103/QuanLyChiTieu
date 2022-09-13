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

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Delete(id);
            return res;
        }

        public SingleRsp Add(IncomeAndExpenseReq itemReq)
        {
            var res = new SingleRsp();
            IncomeAndExpense item = new IncomeAndExpense();
            item.UserId = itemReq.UserId;
            item.GroupId = itemReq.GroupId;
            item.Amount = itemReq.Amount;
            item.Reason = itemReq.Reason;
            item.Detail = itemReq.Detail;
            item.Date = itemReq.Date;
            item.IsIncome = itemReq.IsIncome;
            item.Approved = itemReq.Approved;
            item.Confirmed = itemReq.Confirmed;
            item.Active = itemReq.Active;

            res = incomeAndExpenseRep.Add(item);
            return res;
        }
    }
}
