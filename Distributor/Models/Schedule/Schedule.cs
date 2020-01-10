using NodaTime;

namespace Distributor.Models.Schedule
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int ScheduleTypeId { get; set; }
        public long DueAt { get; set; }
        public long DoneAt { get; set; }
        public int ScheduleResultTypeId { get; set; }
        public string Description { get; set; }
        public Instant CreatedAt { get; set; }
    }
}