using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockItAPI.Models
{
    public class OrderSpacingProperties
    {
        public int OrderSpacingMinutes { get; set; } = 5;
        public int OrderTimePeriodMinutes { get; set; } = 10;
        public int OrderLimit { get; set; } = 10;
    }
}
