using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.ScheduleType.Commands
{
    public class UpdateScheduleType : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public UpdateScheduleType(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateScheduleType() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("schedule_type",
                    "name=@Name")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}