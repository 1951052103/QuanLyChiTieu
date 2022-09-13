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

        public override List<Group> Get(Dictionary<string, string> paramList)
        {
            var res = All.Where(g => g.Active == true);

            string name = paramList["name"];
            if (!string.IsNullOrEmpty(name))
            {
                res = res.Where(g => g.GroupName.Contains(name));
            }

            try
            {
                int pageSize = Int32.Parse(string.IsNullOrEmpty(paramList["pageSize"]) ? "0" : paramList["pageSize"]);
                int page = Int32.Parse(string.IsNullOrEmpty(paramList["page"]) ? "1" : paramList["page"]);

                if (pageSize > 0)
                {
                    int offset = (page - 1) * pageSize;
                    return res.Skip(offset).Take(pageSize).ToList();
                }
            }
            catch
            {
                return null;
            }

            return res.ToList();
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
                        res.Data = id;
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
                        res.Data = item;
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

        public SingleRsp UpdateGroup(Group item)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Groups.Update(item);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = item;
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