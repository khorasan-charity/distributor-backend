using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.Schedule.Commands
{
    public class AddSchedule : DbMessageByUserAsync<int>
    {
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int ScheduleTypeId { get; set; }
        public long DueAt { get; set; }
        public long DoneAt { get; set; }
        public string Description { get; set; }
        
        public AddSchedule(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public AddSchedule() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("schedule",
                    "distributor_id, donor_id, schedule_type_id, due_at, done_at, description",
                    "@DistributorId, @DonorId, @ScheduleTypeId, @DueAt, @DoneAt, @Description")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}