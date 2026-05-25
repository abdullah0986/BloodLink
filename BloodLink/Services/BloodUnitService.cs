using BloodLink.Database;
using BloodLink.Helpers;
using BloodLink.Interfaces;
using BloodLink.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Services
{
    public class BloodUnitService
    {
        private readonly IBloodUnitRepository _bloodUnitRepository;

        public BloodUnitService()
        {
            _bloodUnitRepository = new BloodUnitRepository();
        }

        public bool AddBloodUnit(BloodUnit unit)
        {
            if (unit == null)
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(BloodGroup), unit.BloodGroup))
            {
                return false;
            }
            if (unit.DonorId == null || unit.UserId == null)
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(BloodUnitStatus), unit.Status))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(unit.CollectedDate.ToString()))
            {
                return false;
            }
            unit.CreatedAt = DateTime.UtcNow;
            unit.ExpiryDate = unit.CollectedDate.AddDays(35);

            int confirm = _bloodUnitRepository.AddBloodUnit(unit);
            if (confirm > 0)
                return true;
            else
                return false;
        }

        public bool UpdateBloodUnit(BloodUnit unit)
        {
            if (unit == null || string.IsNullOrWhiteSpace(unit.Id))
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(BloodGroup), unit.BloodGroup))
            {
                return false;
            }
            if (unit.DonorId == null || unit.UserId == null)
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(BloodUnitStatus), unit.Status))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(unit.CollectedDate.ToString()))
            {
                return false;
            }

            unit.ExpiryDate = unit.CollectedDate.AddDays(35);
            int confirm = _bloodUnitRepository.UpdateBloodUnit(unit);
            if (confirm > 0)
                return true;
            else
                return false;
        }

        public bool DeleteBloodUnit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            int confirm = _bloodUnitRepository.DeleteBloodUnit(id);
            if (confirm > 0)
                return true;
            else
                return false;
        }

        public List<BloodUnit> GetAllUnits()
        {
            return _bloodUnitRepository.GetAllBloodUnits();
        }

        public List<BloodUnit> SearchUnits(BloodGroup? bg, BloodUnitStatus? status)
        {
            return _bloodUnitRepository.SearchBloodUnits(bg, status);
        }

        public BloodUnitStats GetBloodUnitStats()
        {
            return _bloodUnitRepository.GetBloodUnitStats();
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

        public Dictionary<string, int> GetStockByBloodGroup()
        {
            return _bloodUnitRepository.GetStockByBloodGroup();
        }

        public Dictionary<string, int> GetMonthlyDonations(int monthsBack = 6)
        {
            return _bloodUnitRepository.GetMonthlyDonations(monthsBack);
        }

        public void CheckAndExpireUnits()
        {
            _bloodUnitRepository.MarkExpiredUnits();
        }
    }
}
