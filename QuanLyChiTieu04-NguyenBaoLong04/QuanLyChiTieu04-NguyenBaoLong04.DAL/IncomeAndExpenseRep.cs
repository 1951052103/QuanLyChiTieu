using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class IncomeAndExpenseRep : GenericRep<QuanLyChiTieuContext, IncomeAndExpense>
    {
        public IncomeAndExpenseRep()
        {

        }

        public SingleRsp Delete(int id)
        {
            var res = new SingleRsp();

            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var item = base.All.FirstOrDefault(i => i.Id == id);
                        context.IncomeAndExpenses.Remove(item);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        public SingleRsp Add(IncomeAndExpense item)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.IncomeAndExpenses.Add(item);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
