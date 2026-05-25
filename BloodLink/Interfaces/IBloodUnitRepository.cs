using BloodLink.Models;
using BloodLink.Database;
using System.ComponentModel;

namespace BloodLink.Interfaces
{
    public interface IBloodUnitRepository
    {
        public int AddBloodUnit(BloodUnit bloodUnit);
        public int UpdateBloodUnit(BloodUnit bloodunit);
        public int DeleteBloodUnit(string id);
        public List<BloodUnit> GetAllBloodUnits();
        public BloodUnitStats GetBloodUnitStats();
        public List<BloodUnit> SearchBloodUnits(BloodGroup? bloodGroup, BloodUnitStatus? bloodUnitStatus);
        public int getBloodGroupCount(Enum BloodGroup);
        public int getExpiringSoonCount();
        public Dictionary<string, int> GetStockByBloodGroup();
        public Dictionary<string, int> GetMonthlyDonations(int monthsBack);
        public Dictionary<string, int> getExpiringUnits();
        public int MarkExpiredUnits();

    }
}
