using QuanLyChiTieu04_NguyenBaoLong04.Common.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.BLL
{
    public class IncomeSvc : GenericSvc<IncomeRep, IncomeAndExpense>
    {
        private IncomeRep incomeRep;
        public IncomeSvc()
        {
            incomeRep = new IncomeRep();
        }

        public override SingleRsp Get(int userId)
        {
            var res = new SingleRsp();
            res.Data = _rep.Get(userId);
            return res;
        }
    }
}
