using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class GroupRep : GenericRep<QuanLyChiTieuContext, Group>
    {
        public GroupRep()
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
                        context.Groups.Remove(item);
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

        public SingleRsp Add(Group item)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Groups.Add(item);
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