using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace BloodLink.Core.Models
{
    public enum Role
    {
        Admin,
        Operator
    }

    public enum BloodGroup
    {
        [Description("A+")] APositive,
        [Description("A-")] ANegative,
        [Description("B+")] BPositive,
        [Description("B-")] BNegative,
        [Description("O+")] OPositive,
        [Description("O-")] ONegative,
        [Description("AB+")] ABPositive,
        [Description("AB-")] ABNegative
    }

    public enum Gender
    {
        Male,
        Female,
    }

    public enum BloodUnitStatus
    {
        [Description("Available")] Available,
        [Description("Reserved")] Reserved,
        [Description("Used")] Used,
        [Description("Expired")] Expired
    }

    public enum RequestStatus
    {
        Pending,
        Fulfilled,
        Cancelled
    }

    public enum DonorEligibility
    {
        [Description("Not Eligible")] NotEligible,
        [Description("Eligible")] Eligible
    }

    public enum FormMode
    {
        Add, 
        Edit, 
        View
    }
    public enum SessionTimeout
    {
        [Description("15 Minutes")] FifteenMinutes = 15,
        [Description("30 Minutes")] ThirtyMinutes = 30,
        [Description("1 Hour")] OneHour = 60,
        [Description("2 Hours")] TwoHours = 120,
        [Description("Never")] Never = 0
    }
}
