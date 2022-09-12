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

        public override List<IncomeAndExpense> Get(int userId)
        {
            var res = All.Where(i => i.Active == true).Where(i => i.UserId == userId).ToList();//All.FirstOrDefault(i => i.Id == id);
            return res;
        }
    }
}
