using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<GroupsUser> GroupsUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<IncomeAndExpense> IncomeAndExpenses { get; set; }
    }
}
