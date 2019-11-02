using NodaTime;

namespace Distributor.Models.DonationType
{
    public class DonationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Instant CreatedAt { get; set; }
    }
}