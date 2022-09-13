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
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Delete(id);
            return res;
        }

        public SingleRsp Add(User item)
        {
            var res = new SingleRsp();
            res = userRep.Add(item);
            return res;

        }

        public SingleRsp Login(UserReq userReq)
        {
            var res = new SingleRsp();

            User u = new User();
            u.Username = userReq.Username;
            u.Pass = userReq.Pass;

            res.Data = userRep.Login(u);
            return res;

        }

        public SingleRsp UpdateUser(User item)
        {
            var res = new SingleRsp();
            res = userRep.UpdateUser(item);

            return res;
        }

        public SingleRsp GetUserList(Dictionary<string, string> paramList)
        {
            var res = new SingleRsp();
            res.Data = userRep.GetUserList(paramList);

            return res;
        }
    }
}