using NodaTime;

namespace Distributor.Models.Distributor
{
    public class Distributor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        public Instant CreatedAt { get; set; }
    }
}