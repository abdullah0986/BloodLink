using BloodLink.Database;
using BloodLink.Helpers;
using BloodLink.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Services
{
    public class BloodUnitService
    {
        private readonly BloodUnitRepository _bloodUnitRepository;

        public BloodUnitService()
        {
            _bloodUnitRepository = new BloodUnitRepository();
        }

        public (bool success, string message, int bloodUnitId) AddBloodUnit(BloodUnit unit)
        {
            if (unit == null)
            {
                return (false, "Blood unit cannot be null.", 0);
            }
            if (!Enum.IsDefined(typeof(BloodGroup), unit.BloodGroup))
            {
                return (false, "Blood group is required.", 0);
            }
            if (unit.DonorId == 0)
            {
                return (false, "Donor ID is required.", 0);
            }
            if (!Enum.IsDefined(typeof(BloodUnitStatus), unit.Status))
            {
                return (false, "Blood unit status is required.", 0);
            }
            if (string.IsNullOrWhiteSpace(unit.CollectedDate.ToString()))
            {
                return (false, "Collected date is required.", 0);
            }
            unit.BagId = BloodUnit.GenerateBagId(EnumHelper.GetDescription(unit.BloodGroup));
            unit.CreatedAt = DateTime.UtcNow;
            unit.ExpiryDate = unit.CreatedAt.AddDays(35);

            int confirm = _bloodUnitRepository.AddBloodUnit(unit);
            if (confirm > 0)
                return (true, "Blood unit added.", _bloodUnitRepository.AddBloodUnit(unit));
            else
                return (false, "Failed to add blood unit.", 0);
        }

        public int GetTotalBloodUnits()
        {
            return _bloodUnitRepository.getTotalBloodUnits();
        }

        public int getBloodGroupCount(Enum BloodGroup)
        {
            if(!Enum.IsDefined(BloodGroup.GetType(), BloodGroup))
            {
                return -1;
            }
            return _bloodUnitRepository.getBloodGroupCount(BloodGroup);
        }

        public int getExpiringSoonCount()
        {
            return _bloodUnitRepository.getExpiringSoonCount();
        }

        public Dictionary<string, int> getExpiringUnits()
        {
            return _bloodUnitRepository.getExpiringUnits();
        }
    }
}
