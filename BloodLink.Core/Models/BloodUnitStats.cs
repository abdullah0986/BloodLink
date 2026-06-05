using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Models
{
    public class BloodUnitStats
    {
        public int TotalUnits { get; set; }
        public int AvailableUnits { get; set; }
        public int ReservedUnits { get; set; }
        public int UsedUnits { get; set; }
        public int ExpiredUnits { get; set; }
    }
}
