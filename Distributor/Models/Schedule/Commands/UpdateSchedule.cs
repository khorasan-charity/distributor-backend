using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Commands
{
    public class UpdateSchedule: DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int ScheduleTypeId { get; set; }
        public long DueAt { get; set; }
        public long DoneAt { get; set; }
        public string Description { get; set; }

        public UpdateSchedule(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateSchedule() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("schedule",
                    "distributor_id=@DistributorId, donor_id=@DonorId, schedule_type_id=@ScheduleTypeId," +
                    "due_at=@DueAt, done_at=@DoneAt, description=@Description")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}