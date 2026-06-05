using BloodLink.Core.Models;
using System.ComponentModel;

namespace BloodLink.Core.Interfaces
{
    public interface IBloodUnitRepository
    {
        public int AddBloodUnit(BloodUnit bloodUnit);
        public int UpdateBloodUnit(BloodUnit bloodunit);
        public int DeleteBloodUnit(string id);
        public List<BloodUnit> GetAllBloodUnits();
        public Task<BloodUnitStats> GetBloodUnitStatsAsync();
        public Task<int> CollectionThisMonthAsync();
        public List<BloodUnit> SearchBloodUnits(BloodGroup? bloodGroup, BloodUnitStatus? bloodUnitStatus);
        public Task<int> getBloodGroupCountAsync(Enum BloodGroup);
        public Task<int> getExpiringSoonCountAsync();
        public Task<Dictionary<string, int>> GetStockByBloodGroupAsync();
        public Task<Dictionary<string, int>> GetMonthlyDonationsAsync(int monthsBack);
        public Task<Dictionary<string, int>> getExpiringUnitsAsync();
        public int MarkExpiredUnits();

    }
}
