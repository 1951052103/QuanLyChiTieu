using QuanLyChiTieu04_NguyenBaoLong04.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu04_NguyenBaoLong04.DAL.Models;
using System.Linq;

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL
{
    public class CategoryRep:GenericRep<NorthwindContext,Category>
    {
        public CategoryRep()
        {

        }
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(c => c.CategoryId == id);
            return res;
        }
    }
}
