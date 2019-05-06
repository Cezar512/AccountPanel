using System;
using System.Collections.Generic;

namespace L2AccountPanel.Infrastructure.EF.Models
{
    public partial class Accounts
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Serial { get; set; }
        public string Email { get; set; }
        public decimal? Lastactive { get; set; }
        public DateTime? LastActive1 { get; set; }
        public int? AccessLevel { get; set; }
        public string LastIp { get; set; }
        public int? LastServer { get; set; }
        public sbyte? Ipblock { get; set; }
        public string Hwidblock { get; set; }
        public int? HwidblockOn { get; set; }
    }
}