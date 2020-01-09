using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Commands
{
    public class UpdateSchedule: DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int ScheduleTypeId { get; set; }
        public long DueAt { get; set; }
        public long DoneAt { get; set; }
        public int ScheduleResultTypeId { get; set; }
        public string Description { get; set; }

        public UpdateSchedule() : base("schedule",
            "distributor_id=@DistributorId, donor_id=@DonorId, schedule_type_id=@ScheduleTypeId," +
            "due_at=@DueAt, done_at=@DoneAt, schedule_result_type_id=@ScheduleResultTypeId, description=@Description")
        {
        }
    }
}