using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL.Models
{
    public partial class IncomeAndExpense
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public decimal? Amount { get; set; }
        public string Reason { get; set; }
        public string Detail { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsIncome { get; set; }
        public bool? Approved { get; set; }
        public bool? Confirmed { get; set; }
        public bool? Active { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
