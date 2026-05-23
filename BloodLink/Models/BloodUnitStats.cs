using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Models
{
    public class BloodUnitStats
    {
        public int TotalUnits { get; set; }
        public int AvailableUnits { get; set; }
        public int ReservedUnits { get; set; }
        public int ExpiredUnits { get; set; }
    }
}
