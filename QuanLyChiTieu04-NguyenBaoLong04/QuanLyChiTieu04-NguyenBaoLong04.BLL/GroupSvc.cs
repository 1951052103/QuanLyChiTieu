using QuanLyChiTieu04_NguyenBaoLong04.Common.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.BLL
{
    public class GroupSvc : GenericSvc<GroupRep, Group>
    {
        private GroupRep groupRep;
        public GroupSvc()
        {
            groupRep = new GroupRep();
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Delete(id);
            return res;
        }

        public SingleRsp Add(Group item)
        {
            var res = new SingleRsp();
            res = groupRep.Add(item);
            return res;
        }
    }
}