using BloodLink.Core.Database;
using BloodLink.Helpers;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
                MessageBox.Show("Something went wrong");
                return false;
            }
            if (unit.BloodGroup == null)
            {
                MessageBox.Show("Blood Group is required");
                return false;
            }
            if (string.IsNullOrWhiteSpace(unit.CollectedDate.ToString()))
            {
                MessageBox.Show("Collection Date of Blood is required");
                return false;
            }
            if (unit.Status == null)
            {
                MessageBox.Show("Status is required");
                return false;
            }
            if (unit.UserId == null)
            {
                MessageBox.Show("Something went wrong");
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
            if (unit == null)
            {
                MessageBox.Show("Something went wrong");
                return false;
            }
            if (unit.BloodGroup == null)
            {
                MessageBox.Show("Blood Group is required");
                return false;
            }
            if (string.IsNullOrWhiteSpace(unit.CollectedDate.ToString()))
            {
                MessageBox.Show("Collection Date of Blood is required");
                return false;
            }
            if (unit.Status == null)
            {
                MessageBox.Show("Status is required");
                return false;
            }
            if (unit.UserId == null)
            {
                MessageBox.Show("Something went wrong");
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

        public async Task<BloodUnitStats> GetBloodUnitStatsAsync()
        {
            return await _bloodUnitRepository.GetBloodUnitStatsAsync();
        }

        public async Task<int> CollectionThisMonthAsync()
        {
            return await _bloodUnitRepository.CollectionThisMonthAsync();
        }
        public async Task<int> getBloodGroupCountAsync(Enum BloodGroup)
        {
            if(!Enum.IsDefined(BloodGroup.GetType(), BloodGroup))
            {
                return -1;
            }
            return await _bloodUnitRepository.getBloodGroupCountAsync(BloodGroup);
        }

        public async Task<int> getExpiringSoonCountAsync()
        {
            return await _bloodUnitRepository.getExpiringSoonCountAsync();
        }

        public async Task<Dictionary<string, int>> getExpiringUnitsAsync()
        {
            return await _bloodUnitRepository.getExpiringUnitsAsync();
        }

        public async Task<Dictionary<string, int>> GetStockByBloodGroupAsync()
        {
            return await _bloodUnitRepository.GetStockByBloodGroupAsync();
        }

        public async Task<Dictionary<string, int>> GetMonthlyDonationsAsync(int monthsBack = 6)
        {
            return await _bloodUnitRepository.GetMonthlyDonationsAsync(monthsBack);
        }

        public void CheckAndExpireUnits()
        {
            _bloodUnitRepository.MarkExpiredUnits();
        }
    }
}
