namespace Distributor.Models.Schedule.Dto
{
    public class ScheduleWithNames : Schedule
    {
        public string DistributorFullName { get; set; }
        public string DonorFullName { get; set; }
        public string ScheduleTypeName { get; set; }
        public string ScheduleResultTypeName { get; set; }
    }
}