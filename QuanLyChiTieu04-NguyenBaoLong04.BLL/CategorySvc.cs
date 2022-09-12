using QuanLyChiTieu04_NguyenBaoLong04.Common.BLL;
using QuanLyChiTieu04_NguyenBaoLong04.Common.Rsp;
using QuanLyChiTieu04_NguyenBaoLong04.DAL;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu04_NguyenBaoLong04.BLL
{
    public class CategorySvc:GenericSvc<CategoryRep,Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data= _rep.Read(id);
            return res;
        }
    }
}
