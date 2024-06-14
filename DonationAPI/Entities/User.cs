using Microsoft.AspNetCore.Identity;

namespace DonationAPI.Entities
{
    public class User : IdentityUser
    {
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }
        public List<Donation> Donations { get; set; } = [];
    }
}
