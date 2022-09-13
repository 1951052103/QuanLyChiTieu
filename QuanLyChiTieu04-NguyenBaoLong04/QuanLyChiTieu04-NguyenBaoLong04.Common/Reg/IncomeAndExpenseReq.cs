using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyChiTieu04_NguyenBaoLong04.Common.Reg
{
    public class IncomeAndExpenseReq
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
    }
}
