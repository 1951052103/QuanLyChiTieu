using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupsUsers = new HashSet<GroupsUser>();
            IncomeAndExpenses = new HashSet<IncomeAndExpense>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<GroupsUser> GroupsUsers { get; set; }
        public virtual ICollection<IncomeAndExpense> IncomeAndExpenses { get; set; }
    }
}
