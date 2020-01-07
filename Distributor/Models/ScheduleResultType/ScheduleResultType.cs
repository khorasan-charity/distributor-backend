using NodaTime;

namespace Distributor.Models.ScheduleResultType
{
    public class ScheduleResultType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Instant CreatedAt { get; set; }
    }
}