using BloodLink.Core.Database;
using BloodLink.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Interfaces
{
    public interface IDonorRepository
    {
        public int AddDonor(Donor donor);
        public List<Donor> GetAllDonors();
        public int DonorsThisMonth();
        public List<Donor> SearchDonors(string searchTerm, List<string>? bloodGroups, DonorEligibility? eligibility);
        public bool UpdateDonor(Donor donor);
        public Task<DonorStats> GetDonorStatsAsync();
        public bool DeleteDonor(string donorId);

    }
}
