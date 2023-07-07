using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Station
    {
        public int? StationId { get; set; }
        public string Address { get; set; } = null!;
        public int Data1 { get; set; }
        public int Data2 { get; set; }
        public int Data3 { get; set; }
        public int Data4 { get; set; }

    }
}
