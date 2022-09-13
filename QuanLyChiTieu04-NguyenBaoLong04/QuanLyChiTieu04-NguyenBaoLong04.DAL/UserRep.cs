using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class UserRep : GenericRep<QuanLyChiTieuContext, User>
    {
        public UserRep()
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
                        context.Users.Remove(item);
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

        public SingleRsp Add(User item)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Add(item);
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