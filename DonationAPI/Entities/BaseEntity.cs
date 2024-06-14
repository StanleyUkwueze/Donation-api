namespace DonationAPI.Entities
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }
    }
}
