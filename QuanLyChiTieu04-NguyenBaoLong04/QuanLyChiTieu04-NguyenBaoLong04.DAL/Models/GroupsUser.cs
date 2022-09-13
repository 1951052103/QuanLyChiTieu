using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace QuanLyChiTieu04_NguyenBaoLong04.DAL.Models
{
    public partial class GroupsUser
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }
        public bool? IsGroupLeader { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? Active { get; set; }

        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
