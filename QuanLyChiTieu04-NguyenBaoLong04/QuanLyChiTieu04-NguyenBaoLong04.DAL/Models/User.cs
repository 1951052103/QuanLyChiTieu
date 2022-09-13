using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL.Models
{
    public partial class User
    {
        public User()
        {
            GroupsUsers = new HashSet<GroupsUser>();
            IncomeAndExpenses = new HashSet<IncomeAndExpense>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Active { get; set; }

        [JsonIgnore]
        public virtual ICollection<GroupsUser> GroupsUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<IncomeAndExpense> IncomeAndExpenses { get; set; }
    }
}
