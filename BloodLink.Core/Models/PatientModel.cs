using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Models
{
    public class PatientModel
    {
            public string patientName { get; set; }
            public string group { get; set; }
            public int unitsRequired { get; set; }
            public string doctorName { get; set; }
            public RequestStatus status { get; set; }
            public DateTime CreatedAt { get; set; }
    }
}
