using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidiling.Models
{
    public class MembershipType
    {
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public byte Id { get; set; }
        public string Name { get; set; }
        public static readonly byte Uknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}