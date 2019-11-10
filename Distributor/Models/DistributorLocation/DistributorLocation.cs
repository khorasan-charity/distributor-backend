using NodaTime;

namespace Distributor.Models.DistributorLocation
{
    public class DistributorLocation
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int ScheduleId { get; set; }
        public string GeoLocation { get; set; }
        public Instant CreatedAt { get; set; }
    }
}