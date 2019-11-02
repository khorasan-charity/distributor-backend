using NodaTime;

namespace Distributor.Models.Donor
{
    public class Donor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string GeoLocation { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        public Instant CreatedAt { get; set; }
    }
}