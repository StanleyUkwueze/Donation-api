namespace DonationAPI.Entities
{
    public class Project: BaseEntity
    {
        public string ProjectId { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public decimal AmountNeeded { get; set; }
        public decimal AmountCovered { get; set; }

        public List<Donation> Donations { get; set; } = [];
    }
}
