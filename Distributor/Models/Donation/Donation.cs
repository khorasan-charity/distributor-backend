using NodaTime;

namespace Distributor.Models.Donation
{
    public class Donation
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int DonationTypeId { get; set; }
        public int DonationStateId { get; set; }
        public long DonationMoney { get; set; }
        public long ExtraDonationMoney { get; set; }
        public string OtherDonations { get; set; }
        public Instant CreatedAt { get; set; }
    }
}