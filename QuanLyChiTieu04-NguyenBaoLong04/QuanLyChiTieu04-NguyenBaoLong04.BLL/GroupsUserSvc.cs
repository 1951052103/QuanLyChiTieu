using QuanLyChiTieu04_NguyenBaoLong04.Common.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.BLL
{
    public class GroupsUserSvc : GenericSvc<GroupsUserRep, GroupsUser>
    {
        private GroupsUserRep groupsUserRep;
        public GroupsUserSvc()
        {
            groupsUserRep = new GroupsUserRep();
        }

        public SingleRsp DeleteGroupUserById(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.DeleteGroupUserById(id);
            return res;
        }

        public SingleRsp JoinGroup(GroupsUser item)
        {
            var res = new SingleRsp();
            res = groupsUserRep.JoinGroup(item);
            return res;
        }
    }
}
