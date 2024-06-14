namespace DonationAPI.Entities
{
    public class Donation : BaseEntity
    {
        public string DonationId { get; set; } = Guid.NewGuid().ToString();
        public decimal AmountDonated { get; set; }
        public string DonatedBy { get; set; }
        public string ProjectId { get; set; }
    }
}
