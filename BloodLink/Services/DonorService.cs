using BloodLink.Core.Database;
using BloodLink.Helpers;
using BloodLink.Core.Models;
using BloodLink.Core.Interfaces;
namespace BloodLink.Services
{
    public class DonorService
    {
        private readonly IDonorRepository _donorRepo;

        public DonorService()
        {
            _donorRepo = new DonorRepository();
        }
        public bool RegisterDonor(Donor donor)
        {
            if (donor == null)
            {
                MessageBox.Show("Donor information is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.FullName))
            {
                MessageBox.Show("Full Name is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.Phone))
            {
                MessageBox.Show("Phone number is required.");
                return false;
            }

            if(donor.Age == 0)
            {
                MessageBox.Show("Age is required");
                return false;
            }

            if (donor.Age < 18 || donor.Age > 80)
            {
                MessageBox.Show("Valid Age is required");
                return false;
            }

            if (donor.BloodGroup == null)
            {
                MessageBox.Show("Blood group is required");
                return false;
            }

            if(donor.Gender == null)
            {
                MessageBox.Show("Gender is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.City))
            {
                MessageBox.Show("City is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.UserId))
            {
                MessageBox.Show("User ID is not found.");
                return false;
            }

            string generatedId = donor.generateDonorId();
            donor.Id = generatedId;
            donor.FullName = donor.FullName.Trim();
            donor.City = donor.City.Trim();
            donor.Area = donor.Area?.Trim();
            donor.CreatedAt = donor.CreatedAt == default ? DateTime.Now : donor.CreatedAt;
            if (donor.LastDonationDate.HasValue)
                donor.NextEligibleDate = donor.LastDonationDate.Value.AddDays(120);
            int id = _donorRepo.AddDonor(donor);
            if (id <= 0)
                return false;

            return id > 0;
        }

        public bool UpdateDonor(Donor donor)
        {
            if (donor == null)
            {
                MessageBox.Show("Donor information is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.FullName))
            {
                MessageBox.Show("Full Name is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.Phone))
            {
                MessageBox.Show("Phone number is required.");
                return false;
            }

            if (donor.Age == 0)
            {
                MessageBox.Show("Age is required");
                return false;
            }

            if (donor.Age < 18 || donor.Age > 80)
            {
                MessageBox.Show("Valid Age is required");
                return false;
            }

            if (donor.BloodGroup == null)
            {
                MessageBox.Show("Blood group is required");
                return false;
            }

            if (donor.Gender == null)
            {
                MessageBox.Show("Gender is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.City))
            {
                MessageBox.Show("City is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(donor.UserId))
            {
                MessageBox.Show("User ID is not found.");
                return false;
            }

            donor.FullName = donor.FullName.Trim();
            donor.City = donor.City.Trim();
            donor.Area = donor.Area?.Trim();
            if (donor.LastDonationDate.HasValue)
                donor.NextEligibleDate = donor.LastDonationDate.Value.AddDays(90);

            bool success = _donorRepo.UpdateDonor(donor);

            if (!success)
                return false;
            

            return true;
        }

        public bool DeleteDonor(string donorId)
        {
            if (string.IsNullOrEmpty(donorId))
            {
                MessageBox.Show("Invalid donor ID.");
                return false;
            }
            bool success = _donorRepo.DeleteDonor(donorId);
            if (!success)
                MessageBox.Show("Failed to delete donor. Please try again.");
            return success;
        }   

        public int DonorsThisMonth()
        {
            int donorThisMonths = _donorRepo.DonorsThisMonth();
            if (donorThisMonths <= 0)
                return 0;
            return donorThisMonths;
        }
        public async Task<DonorStats> GetDonorStatsAsync()
        {
            return await _donorRepo.GetDonorStatsAsync();
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