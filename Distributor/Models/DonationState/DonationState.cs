using NodaTime;

namespace Distributor.Models.DonationState
{
    public class DonationState
    {
        public int Id { get; set; }
        public int DonationTypeId { get; set; }
        public string Name { get; set; }
        public Instant CreatedAt { get; set; }
    }
}