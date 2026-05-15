using BloodLink.Database;
using BloodLink.Helpers;
using BloodLink.Models;
namespace BloodLink.Services
{
    public class DonorService
    {
        private readonly DonorRepository _donorRepo;

        public DonorService()
        {
            _donorRepo = new DonorRepository();
        }
        public (bool success, string message, int donorId) RegisterDonor(Donor donor)
        {
            if (donor == null)
                return (false, "Invalid donor data.", -1);

            if (string.IsNullOrWhiteSpace(donor.FullName))
                return (false, "Full name is required.", -1);

            if (string.IsNullOrWhiteSpace(donor.Phone))
                return (false, "Phone number is required.", -1);

            if (string.IsNullOrWhiteSpace(donor.City))
                return (false, "City is required.", -1);

            if (donor.UserId.HasValue)
            {
                var existing = _donorRepo.GetDonorByUserId(donor.UserId.Value);
                if (existing != null && existing.Id != donor.Id)
                    return (false, "A donor profile already exists for this account.", -1);
            }

            donor.FullName = donor.FullName.Trim();
            donor.City = donor.City.Trim();
            donor.Area = donor.Area?.Trim();
            donor.IsEligible = true;
            donor.CreatedAt = donor.CreatedAt == default ? DateTime.Now : donor.CreatedAt;
            if (donor.LastDonationDate.HasValue)
                donor.NextEligibleDate = donor.LastDonationDate.Value.AddDays(90);
            int id = _donorRepo.AddDonor(donor);
            if (id <= 0)
                return (false, "Failed to save donor. See logs.", -1);

            return (true, "Donor registered.", id);
        }


        public DonorStats GetDashboardStats()
        {
            return _donorRepo.GetDonorStats();
        }

        public List<Donor> GetAllDonors() 
        {
            return _donorRepo.GetAllDonors();
        }

        public List<Donor> SerachDonors(string searchTerm, BloodGroup? bloodGroup, DonorEligibility? eligibility)
        {
            List<string>? bloodGroupDescriptions = null;

            if (bloodGroup.HasValue)
            {
                var compatibles = GetCompatibleBloodGroupDescriptions(bloodGroup.Value);
                bloodGroupDescriptions = compatibles;
            }

            return _donorRepo.SearchDonors(searchTerm, bloodGroupDescriptions, eligibility);
        }

        private List<string> GetCompatibleBloodGroupDescriptions(BloodGroup requested)
        {
            List<BloodGroup> donors = requested switch
            {
                BloodGroup.APositive => new[] { BloodGroup.APositive, BloodGroup.ANegative, BloodGroup.OPositive, BloodGroup.ONegative }.ToList(),
                BloodGroup.ANegative => new[] { BloodGroup.ANegative, BloodGroup.ONegative }.ToList(),
                BloodGroup.BPositive => new[] { BloodGroup.BPositive, BloodGroup.BNegative, BloodGroup.OPositive, BloodGroup.ONegative }.ToList(),
                BloodGroup.BNegative => new[] { BloodGroup.BNegative, BloodGroup.ONegative }.ToList(),
                BloodGroup.ABPositive => Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>().ToList(), // AB+ accepts all
                BloodGroup.ABNegative => new[] { BloodGroup.ANegative, BloodGroup.BNegative, BloodGroup.ONegative, BloodGroup.ABNegative }.ToList(),
                BloodGroup.OPositive => new[] { BloodGroup.OPositive, BloodGroup.ONegative }.ToList(),
                BloodGroup.ONegative => new[] { BloodGroup.ONegative }.ToList(),
                _ => new[] { requested }.ToList()
            };

            var descriptions = donors.Select(d => EnumHelper.GetDescription(d)).Distinct().ToList();
            return descriptions;
        }
    }
}