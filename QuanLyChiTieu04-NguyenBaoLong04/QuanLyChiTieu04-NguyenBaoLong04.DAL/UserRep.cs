using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class UserRep : GenericRep<QuanLyChiTieuContext, User>
    {
        public UserRep()
        {

        }

        private static string Hash(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(hashedPassword);
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

        public SingleRsp Add(User item)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        item.Pass = Hash(item.Pass);

                        context.Users.Add(item);
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

        public User Login(User item)
        {

            try
            {
                var res = All.Where(u => u.Username == item.Username)
                        .Where(u => u.Pass == Hash(item.Pass));

                return res.ToList()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SingleRsp UpdateUser(User item)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChiTieuContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        item.Pass = Hash(item.Pass);

                        context.Users.Update(item);
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

        public List<User> GetUserList(Dictionary<string, string> paramList)
        {
            var res = All;

            string username = paramList["username"];
            if (!string.IsNullOrEmpty(username))
            {
                res = res.Where(u => u.Username.Contains(username));
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
    }
}