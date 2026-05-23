using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace BloodLink.Models
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
}
