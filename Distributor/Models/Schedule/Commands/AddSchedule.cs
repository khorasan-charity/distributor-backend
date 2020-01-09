using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;

namespace Distributor.Models.Schedule.Commands
{
    public class AddSchedule : DbDefaultInsertByUserAsync<int>
    {
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int ScheduleTypeId { get; set; }
        public long DueAt { get; set; }
        public long DoneAt { get; set; }
        public int ScheduleResultTypeId { get; set; }
        public string Description { get; set; }
        
        public AddSchedule() : base("schedule",
            "distributor_id, donor_id, schedule_type_id, due_at, done_at, schedule_result_type_id, description",
            "@DistributorId, @DonorId, @ScheduleTypeId, @DueAt, @DoneAt, @ScheduleResultTypeId, @Description",
            DatabaseType.Sqlite)
        {
        }
    }
}