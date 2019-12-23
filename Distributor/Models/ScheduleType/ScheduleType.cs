using NodaTime;

namespace Distributor.Models.ScheduleType
{
    public class ScheduleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Instant CreatedAt { get; set; }
    }
}