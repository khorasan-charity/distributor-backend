using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;

namespace Distributor.Models.ScheduleResultType.Commands
{
    public class AddScheduleResultType : DbDefaultInsertByUserAsync<int>
    {
        public string Name { get; set; }
        
        public AddScheduleResultType() : base("schedule_result_type",
            "name",
            "@Name",
            DatabaseType.Sqlite)
        {
        }
    }
}